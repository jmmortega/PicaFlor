using Cirrious.MvvmCross.ViewModels;
using NamoCode.Mvx.Core.Services.Interfaces;
using NamoCode.PicaFlor.Core.Services.Interfaces;
using System.Windows.Input;

namespace NamoCode.PicaFlor.Core.ViewModels
{
    public class MainViewModel
        : CustomPicaFlorMvxViewModel
    {
        #region ViewModels

        private ApplicationBarViewModel m_applicationGeneric;

        public ApplicationBarViewModel ApplicationBar
        {
            get
            {                
                return m_applicationGeneric; 
            }
            set
            {
                m_applicationGeneric = value;
            }
        }


        #endregion

        #region Services

        private IAssetsManager m_assetsManager;
                
        #endregion

        #region Constructors

        public MainViewModel()
        {
            m_assetsManager = Cirrious.CrossCore.Mvx.GetSingleton<IAssetsManager>();
            this.ApplicationBar = new ApplicationBarViewModel(Cirrious.CrossCore.Mvx.GetSingleton<IMarketServices>());

            RaisePropertyChanged(() => this.BackgroundImage);
            
        }

        public MainViewModel(IAssetsManager assetsManager , IMarketServices marketService)
        {
            m_assetsManager = assetsManager;
            
            this.ApplicationBar = new ApplicationBarViewModel(Cirrious.CrossCore.Mvx.GetSingleton<IMarketServices>());

            RaisePropertyChanged(() => this.BackgroundImage);
            
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


        #endregion

        #region Commands

        public ICommand GoSesionesCommand
        {
            get
            {
                return new MvxCommand(() =>
                    {
                        this.ShowViewModel<SesionesViewModel>();
                    });
            }
        }

        public ICommand GoCongresistasCommand
        {
            get
            {
                return new MvxCommand(() =>
                    {
                        this.ShowViewModel<CongresistasViewModel>();
                    });
            }
        }
        
        #endregion
    }
}
