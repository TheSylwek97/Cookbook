using System;
using System.Collections.Generic;
using System.Text;

namespace Cookbook_App.Model
{
    public class Recpie : ISqliteModel
    {

        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public CategoryDataType Category { get; set; }
    }
}
