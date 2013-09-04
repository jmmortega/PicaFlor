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
    public class SesionesDetailViewModel : CustomPicaFlorMvxViewModel
    {

        #region Services

        private IPicaFlorService m_picaflorService;

        private IAssetsManager m_assetsManager;
        private INetwork m_network;

        #endregion

        #region Constructor

        public SesionesDetailViewModel(INetwork network)
        {
            m_picaflorService = new PicaFlorService();

            m_assetsManager = Cirrious.CrossCore.Mvx.GetSingleton<IAssetsManager>();
            m_network = network;

            this.ApplicationBar = new ApplicationBarViewModel(Cirrious.CrossCore.Mvx.GetSingleton<IMarketServices>());

            RaisePropertyChanged(() => this.BackgroundImage);
            LoadData();
        }

        #endregion

        private ApplicationBarViewModel m_applicationBar;

        public ApplicationBarViewModel ApplicationBar
        {
            get { return m_applicationBar; }
            set { m_applicationBar = value; }
        }

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

        private static Session m_mySession;     

        public static Session MySession
        {
            get { return m_mySession; }
            set { m_mySession = value; }
        }

        private List<VotingFull> m_votes;

        public List<VotingFull> Votes
        {
            get 
            {
                if (m_votes == null)
                {
                    m_votes = new List<VotingFull>();
                }
                return m_votes; 
            }
            set { m_votes = value; }
        }

        private ObservableCollection<VotingFull> m_votesShowed;

        public ObservableCollection<VotingFull> VotesShowed
        {
            get 
            {
                if (m_votesShowed == null)
                {
                    m_votesShowed = new ObservableCollection<VotingFull>();
                }
                return m_votesShowed; 
            }
            set { m_votesShowed = value; }
        }
        
        
        #endregion

        #region Visibility Properties
        
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

        #region Commands

        public ICommand CommandRequestData
        {
            get
            {
                return new MvxCommand(() =>
                    {
                        LoadData();
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
                        this.Close(this);
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

        #region Method

        private void LoadData()
        {
            this.ProgressBarVisibility = true;

            if (m_network.isNetworkAvailable == true)
            {
                foreach (VotingFull vote in MySession.Votes)
                {
                    this.ProgressBarVisibility = true;
                    m_picaflorService.GetVoteFullByUri(
                        vote.ResourceUri,
                        (votingFull) =>
                        {
                            this.Votes.Add(votingFull);

                            this.VotesShowed = new ObservableCollection<VotingFull>(m_votes);
                            RaisePropertyChanged(() => this.VotesShowed);

                            this.ProgressBarVisibility = false;
                        },
                        (error) =>
                        {
                            this.MessageText = AppResources.ConectError;
                        });
                }
            }
        }

        #endregion
    }
}
