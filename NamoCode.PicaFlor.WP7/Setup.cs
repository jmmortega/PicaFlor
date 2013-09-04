using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.WindowsPhone.Platform;
using Microsoft.Phone.Controls;
using NamoCode.Mvx.Core.Services.Interfaces;
using NamoCode.Mvx.WP7.Services;
using NamoCode.PicaFlor.Core.Services.Interfaces;
using System.Windows;

namespace NamoCode.PicaFlor.WP7
{
    public class Setup : MvxPhoneSetup
    {
        public Setup(PhoneApplicationFrame rootFrame) : base(rootFrame)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            Cirrious.CrossCore.Mvx.RegisterSingleton<INetwork>(new Network());
            Cirrious.CrossCore.Mvx.RegisterSingleton<IMarketServices>(new MarketServiceW7());
            LoadAssets();

            return new Core.App();
        }

        private void LoadAssets()
        {
            AssetsManager m_assetsManager = new AssetsManager(Application.Current);

            m_assetsManager.AssetsDictionary.Add("BackgroundBlack", "/Assets/LogoBlack.png");
            m_assetsManager.AssetsDictionary.Add("BackgroundWhite", "/Assets/LogoWhite.png");

            m_assetsManager.AssetsDictionary.Add("DivisionBlack", "/Assets/Icons/DivisionBlack.png");
            m_assetsManager.AssetsDictionary.Add("DivisionWhite", "/Assets/Icons/DivisionWhite.png");
            m_assetsManager.AssetsDictionary.Add("MailBlack", "/Assets/Icons/MailBlack.png");
            m_assetsManager.AssetsDictionary.Add("MailWhite", "/Assets/Icons/MailWhite.png");
            m_assetsManager.AssetsDictionary.Add("TwitterBlack", "/Assets/Icons/TwitterBlack.png");
            m_assetsManager.AssetsDictionary.Add("TwitterWhite", "/Assets/Icons/TwitterWhite.png");
            m_assetsManager.AssetsDictionary.Add("WebBlack", "/Assets/Icons/WebBlack.png");
            m_assetsManager.AssetsDictionary.Add("WebWhite", "/Assets/Icons/WebWhite.png");
            
            Cirrious.CrossCore.Mvx.RegisterSingleton<IAssetsManager>(m_assetsManager);
        }
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
    }
}