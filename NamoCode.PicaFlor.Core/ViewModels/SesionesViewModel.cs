using Cirrious.MvvmCross.ViewModels;
using NamoCode.Mvx.Core.Services.Interfaces;
using NamoCode.PicaFlor.Core.Model;
using NamoCode.PicaFlor.Core.Resources;
using NamoCode.PicaFlor.Core.Services;
using NamoCode.PicaFlor.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace NamoCode.PicaFlor.Core.ViewModels
{
    public class SesionesViewModel : CustomPicaFlorMvxViewModel
    {
        #region Services

        private IPicaFlorService m_picaFlorService;
        private INetwork m_network;
        private IAssetsManager m_assetsManager;
        
        #endregion

        #region Constructor

        private SesionesViewModel()
        {
            m_picaFlorService = new PicaFlorService();

            m_network = Cirrious.CrossCore.Mvx.GetSingleton<INetwork>();
            m_assetsManager = Cirrious.CrossCore.Mvx.GetSingleton<IAssetsManager>();

            this.ApplicationBar = new ApplicationBarViewModel(Cirrious.CrossCore.Mvx.GetSingleton<IMarketServices>());

            LoadData();
        }

        public SesionesViewModel(IPicaFlorService picaflorService , INetwork network, IAssetsManager assetsManager)
        {
            m_picaFlorService = new PicaFlorService();

            m_network = network;
            m_assetsManager = assetsManager;

            this.ApplicationBar = new ApplicationBarViewModel(Cirrious.CrossCore.Mvx.GetSingleton<IMarketServices>());

            LoadData();
        }
        
        #endregion

        #region ViewModel

        private ApplicationBarViewModel m_applicationBar;

        public ApplicationBarViewModel ApplicationBar
        {
            get { return m_applicationBar; }
            set { m_applicationBar = value; }
        }


        #endregion

        #region Properties

        public string BackgroundImage
        {
            get
            {
                if (m_assetsManager != null)
                {
                    return m_assetsManager.GetThemeAsset("Background");
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        private List<Session> m_sessiones;

        public List<Session> Sessiones
        {
            get 
            {
                if (m_sessiones == null)
                {
                    m_sessiones = new List<Session>();
                }
                return m_sessiones; 
            }
            set { m_sessiones = value; }
        }

        private ObservableCollection<Session> m_sessionesShowed;

        public ObservableCollection<Session> SessionesShowed
        {
            get { return m_sessionesShowed; }
            set 
            { 
                m_sessionesShowed = value;
                RaisePropertyChanged(() => this.SessionesShowed);
            }
        }


        #endregion

        #region Visibility Properties

        private bool m_ProgressBarVisibility;

        public bool ProgressBarVisibility
        {
            get { return m_ProgressBarVisibility; }
            set 
            { 
                m_ProgressBarVisibility = value;
                RaisePropertyChanged(() => this.ProgressBarVisibility);
            }
        }


        #endregion

        #region Message Properties

        private string m_messageText;

        public string MessageText
        {
            get { return m_messageText; }
            set 
            { 
                m_messageText = value;
                RaisePropertyChanged(() => this.MessageText);
                this.MessageVisibility = true;
            }
        }

        private bool m_messageVisibility;

        public bool MessageVisibility
        {
            get { return m_messageVisibility; }
            set 
            { 
                m_messageVisibility = value;
                RaisePropertyChanged(() => this.MessageVisibility);
            }
        }

        #endregion

        #region Command

        public ICommand CommandSessionSelected
        {
            get
            {
                return new MvxCommand<int>((id) =>
                    {
                        Session session = m_sessiones.Where(x => x.Id == id).FirstOrDefault();

                        if (session != null)
                        {
                            SesionesDetailViewModel.MySession = session;
                            this.ShowViewModel<SesionesDetailViewModel>();
                        }
                        else
                        {
                            this.MessageText = AppResources.NoLocalized;
                        }
                    });
            }
        }

        public ICommand CommandOKPopUpMessage
        {
            get
            {
                return new MvxCommand(() =>
                    {
                        this.MessageVisibility = false;
                    });
            }
        }

        public ICommand CommandGoBack
        {
            get
            {
                return new MvxCommand(() =>
                    {
                        this.Close(this);
                    });
            }
        }

        #endregion

        #region Methods

        private void LoadData()
        {
            this.ProgressBarVisibility = true;

            if (m_network.isNetworkAvailable == true)
            {
                m_picaFlorService.GetSessions(30, 0, false,
                    (sessions) =>
                    {
                        m_sessiones = sessions;

                        this.SessionesShowed = new ObservableCollection<Session>(m_sessiones.OrderBy(x => x.Date).Reverse().ToList());
                    },
                    (error) =>
                    {
                        this.MessageText = AppResources.ConectError;
                    });
            }
            else
            {
                this.MessageText = AppResources.NoNetworkData;
            }
            
        }

        #endregion
    }
}
