using Cirrious.MvvmCross.WindowsPhone.Views;
using NamoCode.PicaFlor.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NamoCode.PicaFlor.WP7.Views
{
    public class CustomPicaFlorPhoneView : MvxPhonePage
    {
        public virtual void RateClick(object sender, System.EventArgs e)
        {
            (ViewModel as CustomPicaFlorMvxViewModel).ApplicationBar.CommandRate.Execute(null);
        }

        public virtual void MoreClick(object sender, System.EventArgs e)
        {
            (ViewModel as CustomPicaFlorMvxViewModel).ApplicationBar.CommandMarket.Execute(null);
        }

        public virtual void AboutClick(object sender, System.EventArgs e)
        {
            (ViewModel as CustomPicaFlorMvxViewModel).ApplicationBar.CommandAbout.Execute(null);
        }
    }
}
