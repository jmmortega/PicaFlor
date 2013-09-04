using Cirrious.MvvmCross.WindowsPhone.Views;
using NamoCode.PicaFlor.Core.ViewModels;

namespace NamoCode.PicaFlor.WP7.Views
{
    public partial class MainView : CustomPicaFlorPhoneView
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void TapSesionesGrid(object sender, System.Windows.Input.GestureEventArgs e)
        {
            (ViewModel as MainViewModel).GoSesionesCommand.Execute(null);
        }

        private void TapCongresistasGrid(object sender, System.Windows.Input.GestureEventArgs e)
        {
            (ViewModel as MainViewModel).GoCongresistasCommand.Execute(null);
        }
        
        private void RateClick(object sender, System.EventArgs e)
        {
            base.RateClick(sender, e);
        }

        private void MoreClick(object sender, System.EventArgs e)
        {
            base.MoreClick(sender, e);
        }

        private void AboutClick(object sender, System.EventArgs e)
        {
            base.AboutClick(sender, e);
        }                
    }
}