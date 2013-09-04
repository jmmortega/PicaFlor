using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.WindowsStore.Platform;
using NamoCode.Mvx.Core.Services.Interfaces;
using NamoCode.Mvx.W8.Services;
using Windows.UI.Xaml.Controls;

namespace NamoCode.PicaFlor.W8
{
    public class Setup : MvxStoreSetup
    {
        public Setup(Frame rootFrame) : base(rootFrame)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            Cirrious.CrossCore.Mvx.RegisterSingleton<INetwork>(new Network());
            Cirrious.CrossCore.Mvx.RegisterSingleton<IMarketServices>(new MarketServiceW8());
            LoadAssets();


            return new Core.App();
        }

        private void LoadAssets()
        {
            AssetsManager m_assetsManager = new AssetsManager();

            Cirrious.CrossCore.Mvx.RegisterSingleton<IAssetsManager>(m_assetsManager);
        }
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
    }
}