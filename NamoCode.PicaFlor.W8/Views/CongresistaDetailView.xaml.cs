using Cirrious.MvvmCross.WindowsStore.Views;
using NamoCode.PicaFlor.Core.ViewModels;
using NamoCode.PicaFlor.W8.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página básica está documentada en http://go.microsoft.com/fwlink/?LinkId=234237

namespace NamoCode.PicaFlor.W8.Views
{
    /// <summary>
    /// Página básica que proporciona características comunes a la mayoría de las aplicaciones.
    /// </summary>
    public sealed partial class CongresistaDetailView : LayoutAwarePage
    {
        public CongresistaDetailView()
        {
            this.InitializeComponent();
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            (ViewModel as CongresistaDetailViewModel).CommandGoBack.Execute(null);
        }

      
    }
}
