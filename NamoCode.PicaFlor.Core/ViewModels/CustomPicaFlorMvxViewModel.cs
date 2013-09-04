using Cirrious.MvvmCross.ViewModels;
using NamoCode.Mvx.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NamoCode.PicaFlor.Core.ViewModels
{
    public class CustomPicaFlorMvxViewModel : MvxViewModel
    {
        public void ShowViewModel<TViewModel>() where TViewModel : MvxViewModel
        {            
            base.ShowViewModel<TViewModel>();
        }

        private ApplicationBarViewModel m_applicationBarViewModel;

        public ApplicationBarViewModel ApplicationBar
        {
            get
            {
                if (m_applicationBarViewModel == null)
                {
                    m_applicationBarViewModel = new ApplicationBarViewModel(Cirrious.CrossCore.Mvx.GetSingleton<IMarketServices>());
                }
                return m_applicationBarViewModel; 
            }
            set { m_applicationBarViewModel = value; }
        }

        private string m_messageText;

        public string MessageText
        {
            get { return m_messageText; }
            set 
            { 
                m_messageText = value;
                this.MessageVisibility = true;
                this.RaisePropertyChanged(() => this.MessageText);
            }
        }

        private bool m_MessageVisibility;

        public bool MessageVisibility
        {
            get { return m_MessageVisibility; }
            set 
            { 
                m_MessageVisibility = value;
                this.RaisePropertyChanged(() => this.MessageVisibility);
            }

        }

        private bool m_progressBarVisibility;

        public bool ProgressBarVisibility
        {
            get { return m_progressBarVisibility; }
            set 
            { 
                m_progressBarVisibility = value;
                this.RaisePropertyChanged(() => this.ProgressBarVisibility);
            }
        }
        

        

    }
}
