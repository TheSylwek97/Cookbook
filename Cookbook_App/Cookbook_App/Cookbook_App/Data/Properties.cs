using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Cookbook_App.Data
{
    class Properties
    {
        public static IDictionary<string, object> AppProperties { get => Application.Current.Properties; }
    }
}
