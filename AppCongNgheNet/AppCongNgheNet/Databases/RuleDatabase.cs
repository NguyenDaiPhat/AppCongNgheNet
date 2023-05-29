using AppCongNgheNet.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AppCongNgheNet.Databases
{
    public class RuleDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public static string DbPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "net03.db");

        public RuleDatabase()
        {
            _database = new SQLiteAsyncConnection(DbPath);
            _database.CreateTableAsync<User>();
        }

        public Task<List<User>> GetUserAsync()
        {
            return _database.Table<User>().ToListAsync();
        }

        public Task<int> DeletePersonAsync(User user)
        {
            return _database.DeleteAsync(user);
        }
    }
}
