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
    public sealed partial class SesionesView : LayoutAwarePage
    {
        public SesionesView()
        {
            this.InitializeComponent();
        }
        
        private void ItemClick(object sender, TappedRoutedEventArgs e)
        {
            var grid = (Grid)sender;

            string id = grid.Tag.ToString();

            (ViewModel as SesionesViewModel).CommandSessionSelected.Execute(int.Parse(id));
        }
    }
}
