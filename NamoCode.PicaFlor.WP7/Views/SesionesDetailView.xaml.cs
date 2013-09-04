using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Cirrious.MvvmCross.WindowsPhone.Views;
using NamoCode.PicaFlor.Core.ViewModels;

namespace NamoCode.PicaFlor.WP7.Views
{
    public partial class SesionesDetailView : CustomPicaFlorPhoneView
    {
        public SesionesDetailView()
        {
            InitializeComponent();
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            (ViewModel as SesionesDetailViewModel).CommandRequestData.Execute(null);
        }

        private void OKPopUpMessage(object sender, System.Windows.Input.GestureEventArgs e)
        {
            (ViewModel as SesionesDetailViewModel).CommandOKPopUpMessage.Execute(null);
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