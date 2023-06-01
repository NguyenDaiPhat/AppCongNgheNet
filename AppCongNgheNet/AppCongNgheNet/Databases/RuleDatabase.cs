using AppCongNgheNet.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public async Task<User> GetUserByUsername(string username)
        {
            return await _database.Table<User>().FirstOrDefaultAsync(u => u.UserName == username);
        }
        public async Task<List<Article>> GetArticlesByChapterSelected(int chapterID)
        {
            return await _database.Table<Article>().Where(a => a.ChapterID == chapterID).ToListAsync();
        }
        public async Task<List<Section>> GetSectionsByArticleSelected(int articleID)
        {
            return await _database.Table<Section>().Where(a => a.ArticleID == articleID).ToListAsync();
        }
        public async Task<List<Section>> SearchSections(string searchText)
        {
            List<Section> searchResults = await _database.Table<Section>()
                                                        .Where(s => s.Content.Contains(searchText))
                                                        .ToListAsync();

            return searchResults;
        }
        //public async Task<List<Section>> SearchSectionsAndArticleID(string searchText, int articleID)
        //{
        //    string query = "SELECT * FROM Section WHERE ArticleID = ? AND Content LIKE ?";
        //    List<Section> searchResults = await _database.QueryAsync<Section>(query, articleID, $"%{searchText}%");

        //    return searchResults;
        //}



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
        public async Task DeleteChapter(int chapterID)
        {
            // Xóa Chapter (xóa luôn article và section bên trong)
            List<Article> articlesToDelete = await _database.Table<Article>().Where(a => a.ChapterID == chapterID).ToListAsync();
            foreach (Article article in articlesToDelete)
            {
                // Xóa Section có ArticleID tương ứng
                int t = article.ID + 5;
                await _database.Table<Section>().DeleteAsync(s => s.ArticleID == t);
            }
            await _database.DeleteAsync<Chapter>(chapterID);
            await _database.Table<Article>().DeleteAsync(a => a.ChapterID == chapterID);
        }
        public async Task DeleteArticle(int articleID)
        {
            // Xóa Article ( xóa section bên trong)
            await _database.DeleteAsync<Article>(articleID);
            int t = articleID + 5;
            await _database.Table<Section>().DeleteAsync(a => a.ArticleID == t);
        }
        public async Task DeleteSection(int sectionID)
        {
            // Xóa Section 
            await _database.DeleteAsync<Section>(sectionID);
        }
        //query
        

    }
}
