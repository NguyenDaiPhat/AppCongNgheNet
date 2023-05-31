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
            _database.CreateTableAsync<Chapter>();
            _database.CreateTableAsync<Article>();
            _database.CreateTableAsync<Section>();
        }
        //get
        public Task<List<Chapter>> GetChapterAsync()
        {
            return _database.Table<Chapter>().ToListAsync();
        }
        public Task<List<Article>> GetArticleAsync()
        {
            return _database.Table<Article>().ToListAsync();
        }
        public Task<List<Section>> GetSectionAsync()
        {
            return _database.Table<Section>().ToListAsync();
        }
        public Task<List<User>> GetUserAsync()
        {
            return _database.Table<User>().ToListAsync();
        }
        // insert
        public Task InsertChapterAsync(Chapter chapter)
        {
            return _database.InsertAsync(chapter);
        }
        public Task InsertArticleAsync(Article article)
        {
            return _database.InsertAsync(article);
        }
        public Task InsertSectionAsync(Section section)
        {
            return _database.InsertAsync(section);
        }
        public Task InsertUserAsync(User user)
        {
            return _database.InsertAsync(user);
        }
        //update
        public Task UpdateChapterAsync(Chapter chapter)
        {
            return _database.UpdateAsync(chapter);
        }
        public Task UpdateArticleAsync(Article article)
        {
            return _database.UpdateAsync(article);
        }
        public Task UpdateSectionAsync(Section section)
        {
            return _database.UpdateAsync(section);
        }
        public Task UpdateUserAsync(User user)
        {
            return _database.UpdateAsync(user);
        }
        //delete
        public Task DeleteChapterAsync(Chapter chapter)
        {
            return _database.DeleteAsync(chapter);
        }
        public Task DeleteArticleAsync(Article article)
        {
            return _database.DeleteAsync(article);
        }
        public Task DeleteSectionAsync(Section section)
        {
            return _database.DeleteAsync(section);
        }
        public Task DeleteUserAsync(User user)
        {
            return _database.DeleteAsync(user);
        }
        //query
        public Task QueryAsync(string username, string password, string email, int mobie)
        {
            return _database.QueryAsync<User>("SELECT * FROM Person WHERE Subscribed = true");
        }
        public async Task<User> GetUserByUsername(string username)
        {
            return await _database.Table<User>().FirstOrDefaultAsync(u => u.UserName == username);
        }
    }
}
