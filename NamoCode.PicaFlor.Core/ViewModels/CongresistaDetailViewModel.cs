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
    public class CongresistaDetailViewModel : CustomPicaFlorMvxViewModel
    {
        #region Services

        private IPicaFlorService m_picaFlorService;
        private IAssetsManager m_assetsManager;
        private INetwork m_network;

        #endregion

        #region ViewModels
        
        #endregion

        #region Constructor

        public CongresistaDetailViewModel()
        {
            m_picaFlorService = new PicaFlorService();

            m_network = Cirrious.CrossCore.Mvx.GetSingleton<INetwork>();
            m_assetsManager = Cirrious.CrossCore.Mvx.GetSingleton<IAssetsManager>();

            this.ApplicationBar = new ApplicationBarViewModel(Cirrious.CrossCore.Mvx.GetSingleton<IMarketServices>());

            LastVotation();
        }

        #endregion

        #region Properties

        #region Images

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

        public string WebImage
        {
            get
            {
                if (m_assetsManager != null)
                {
                    return m_assetsManager.GetThemeAsset("Web");
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public string TwitterImage
        {
            get
            {
                if (m_assetsManager != null)
                {
                    return m_assetsManager.GetThemeAsset("Twitter");
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public string EmailImage
        {
            get
            {
                if (m_assetsManager != null)
                {
                    return m_assetsManager.GetThemeAsset("Mail");
                }
                else
                {
                    return string.Empty;
                }
            }            
        }

        public string DivisionImage
        {
            get
            {
                if (m_assetsManager != null)
                {
                    return m_assetsManager.GetThemeAsset("Division");
                }
                else
                {
                    return string.Empty;
                }
            }
        }
            
        #endregion

        private static ParlamentaryMember m_thisParlamentary;

        public static ParlamentaryMember ThisParlamentary
        {
            get { return m_thisParlamentary; }
            set { m_thisParlamentary = value; }
        }

        private List<ParlamentaryVote> m_votes;

        public List<ParlamentaryVote> Votes
        {
            get 
            {
                if (m_votes == null)
                {
                    m_votes = new List<ParlamentaryVote>();
                }
                return m_votes; 
            }
            set { m_votes = value; }
        }

        private ObservableCollection<ParlamentaryVote> m_votesShowed;

        public ObservableCollection<ParlamentaryVote> VotesShowed
        {
            get 
            {
                if (m_votesShowed == null)
                {
                    m_votesShowed = new ObservableCollection<ParlamentaryVote>();
                }
                return m_votesShowed; 
            }
            set 
            { 
                m_votesShowed = value;
                RaisePropertyChanged(() => this.VotesShowed);
            }
        }


        #endregion

        #region Methods

        private void LastVotation()
        {
            this.ProgressBarVisibility = true;

            if (m_network.isNetworkAvailable == true)
            {
                m_picaFlorService.GetSessions(0, 1, true,
                    (sessions) =>
                    {
                        var lastSession = sessions.FirstOrDefault();

                        if (lastSession != null)
                        {
                            foreach (VotingFull vote in lastSession.Votes)
                            {
                                m_picaFlorService.GetVoteFullByUri(vote.ResourceUri,
                                    (votingFull) =>
                                    {
                                        var voteObj = votingFull.Votes.Where(x => x.MemberId == m_thisParlamentary.Id).FirstOrDefault();
                                        string voteValue = string.Empty;

                                        if (voteObj != null)
                                        {
                                            voteValue = voteObj.VoteValue;
                                        }

                                        this.Votes.Add(new ParlamentaryVote()
                                        {
                                            Title = votingFull.Title,
                                            Vote = voteValue,
                                            Description = votingFull.RecordText
                                        });

                                        this.VotesShowed = new ObservableCollection<ParlamentaryVote>(m_votes);
                                        this.ProgressBarVisibility = false;

                                    },
                                    GenericError);
                            }
                        }

                    },
                    GenericError);
            }
            else
            {
                this.MessageText = AppResources.NoNetworkData;
            }
            

        }

        #endregion

        #region Commands

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

        public ICommand CommandOK
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

        #endregion


        #region Actions

        private Action<Exception> GenericError
        {
            get
            {
                return new Action<Exception>((error) =>
                    {
                        this.MessageText = AppResources.NoNetworkData;
                    });
            }
        }

        #endregion
    }
}
