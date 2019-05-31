using Cookbook_App.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook_App.Data
{
    public class LocalDatabase
    {
        private readonly SQLiteAsyncConnection db;

        public LocalDatabase(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Recipe>().Wait();
        }

        public async Task<int> SaveItem<T>(T item) where T : class, ISqliteModel, new()
        {
            var result = await db.UpdateAsync(item);

            if (result == 0)
            {
                result = await db.InsertAsync(item);
            }

            return result;
        }
        public async Task<List<Recipe>> GetRecpies()
        {
            return await db.Table<Recipe>().ToListAsync();
        }
        public async Task<int> DeleteItem<T>(T item) where T : class, ISqliteModel, new()
        {
            return await db.DeleteAsync(item);
        }

        public async Task<List<Recipe>> GetRecpiesLikeName(string name)
        {
            return await db.Table<Recipe>().Where(x => x.Name.Contains(name)).ToListAsync();

        }

    }
}
