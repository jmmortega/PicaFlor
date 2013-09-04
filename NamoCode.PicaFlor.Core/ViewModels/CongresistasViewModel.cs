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
    public class CongresistasViewModel : CustomPicaFlorMvxViewModel
    {
        #region Services

        private IPicaFlorService m_picaflor;

        private IAssetsManager m_assetsManager;
        private INetwork m_network;

        #endregion

        #region Constructor

        public CongresistasViewModel()
        {
            m_picaflor = new PicaFlorService();

            m_assetsManager = Cirrious.CrossCore.Mvx.GetSingleton<IAssetsManager>();
            m_network = Cirrious.CrossCore.Mvx.GetSingleton<INetwork>();

            this.ApplicationBar = new ApplicationBarViewModel(Cirrious.CrossCore.Mvx.GetSingleton<IMarketServices>());

            LoadData();
        }

        #endregion

        #region ViewModels

        private ApplicationBarViewModel m_applicationBar;

        public ApplicationBarViewModel ApplicationBar
        {
            get { return m_applicationBar; }
            set { m_applicationBar = value; }
        }


        #endregion

        #region Properties

        private string m_BackgroundImage;

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

        private List<ParlamentaryMember> m_congresistas;

        public List<ParlamentaryMember> Congresistas
        {
            get 
            {
                if (m_congresistas == null)
                {
                    m_congresistas = new List<ParlamentaryMember>();
                }
                return m_congresistas; 
            }
            set { m_congresistas = value; }
        }

        private ObservableCollection<ParlamentaryMember> m_congresistasShowed;

        public ObservableCollection<ParlamentaryMember> CongresistasShowed
        {
            get 
            {
                if (m_congresistasShowed == null)
                {
                    m_congresistasShowed = new ObservableCollection<ParlamentaryMember>();
                }
                return m_congresistasShowed; 
            }
            set { m_congresistasShowed = value; }
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

        public ICommand CommandGoCongresistaDetail
        {
            get
            {
                return new MvxCommand<long>((id) =>
                    {
                        var congresista = m_congresistas.Where(x => x.Id == id).FirstOrDefault();

                        if (congresista != null)
                        {
                            CongresistaDetailViewModel.ThisParlamentary = congresista;
                            this.ShowViewModel<CongresistaDetailViewModel>();                            
                        }
                        else
                        {
                            this.MessageText = AppResources.NoLocalized;
                        }                        
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
            if (m_network.isNetworkAvailable == true)
            {
                this.ProgressBarVisibility = true;
                m_picaflor.GetMembers(400, 0,
                (parlamentaryMembers) =>
                {
                    m_congresistas = parlamentaryMembers;

                    m_congresistasShowed = new ObservableCollection<ParlamentaryMember>(parlamentaryMembers);

                    RaisePropertyChanged(() => this.CongresistasShowed);

                    this.ProgressBarVisibility = false;
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
            this.ProgressBarVisibility = false;
        }

        #endregion


    }
}
