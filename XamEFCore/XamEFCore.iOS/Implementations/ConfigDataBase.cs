﻿using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using System.IO;
using Xamarin.Forms;
using XamEFCore.Interfaces;
using XamEFCore.iOS.Implementations;

[assembly: Dependency(typeof(ConfigDataBase))]
namespace XamEFCore.iOS.Implementations
{
    public class ConfigDataBase : IConfigDataBase
    {
        public string GetFullPath(string databaseFileName)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", databaseFileName);
        }
    }
}
