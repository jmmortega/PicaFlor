using Cirrious.MvvmCross.ViewModels;
using NamoCode.Mvx.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace NamoCode.PicaFlor.Core.ViewModels
{
    public class AboutViewModel : CustomPicaFlorMvxViewModel
    {

        private IAssetsManager m_assetsManager;

        public AboutViewModel()
        {
            m_assetsManager = Cirrious.CrossCore.Mvx.GetSingleton<IAssetsManager>();
        }

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
    }
}
