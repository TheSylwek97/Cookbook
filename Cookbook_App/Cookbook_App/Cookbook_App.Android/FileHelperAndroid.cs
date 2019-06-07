using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cookbook_App.Droid;
using Cookbook_App.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelperAndroid))]
namespace Cookbook_App.Droid
{
    public class FileHelperAndroid : IFileHelper
    {
        public string GetLocalFilepath(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
        
    }
}