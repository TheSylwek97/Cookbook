﻿using Cookbook_App.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(Cookbook_App.UWP.FileHelperUWP))]
namespace Cookbook_App.UWP
{
    public class FileHelperUWP : IFileHelper
    {
        public string GetLocalFilepath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}
