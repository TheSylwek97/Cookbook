using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook_App.Data
{
    class LocalDatabase
    {
        private readonly SQLiteAsyncConnection db;

        public LocalDatabase(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            //db.CreateTableAsync<Student>().Wait();
           // db.CreateTableAsync<Teacher>().Wait();
        }

    }
}
