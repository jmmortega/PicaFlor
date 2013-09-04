using Cirrious.MvvmCross.ViewModels;
using NamoCode.Mvx.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace NamoCode.PicaFlor.Core.ViewModels
{

    /// <summary>
    /// Include here all the commands and other fields for the ApplicationBar that repeats in all screens
    /// </summary>
    public class ApplicationBarViewModel : MvxViewModel
    {

        #region Services

        private IMarketServices m_marketServices;

        #endregion

        #region Fields

        private CustomPicaFlorMvxViewModel m_parentViewModel;

        public CustomPicaFlorMvxViewModel ParentViewModel
        {
            get { return m_parentViewModel; }
            set 
            { 
                m_parentViewModel = value;                
            }
        }


        #endregion

        #region Constructor

        public ApplicationBarViewModel(IMarketServices marketServices)
        {
            m_marketServices = marketServices;            
        }

        #endregion

        #region Commands

        public ICommand CommandRate
        {
            get
            {
                return new MvxCommand(() =>
                    {
                        m_marketServices.GoRate();
                    });
            }
        }

        public ICommand CommandMarket
        {
            get
            {
                return new MvxCommand<string>((searchTerm) =>
                    {
                        if (searchTerm == null)
                        {
                            m_marketServices.GoMarket("namocode");
                        }
                        else
                        {
                            m_marketServices.GoMarket(searchTerm);
                        }
                    });
            }
        }

        public ICommand CommandAbout
        {
            get
            {
                return new MvxCommand(() =>
                    {
                        this.ShowViewModel<AboutViewModel>();
                    });
            }
        }
                
        #endregion
    }
}
