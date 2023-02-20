using One.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.Services
{
    public class OneEmailServices : IOneEmailServices
    {

        private SQLiteAsyncConnection _dbConnection;


        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "OneAuthenticator.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<OneEmailModel>();
            }
        }


        
        public async Task<int> AddOneEmail(OneEmailModel oneEmailModel)
        {
            await SetUpDb();
            return await _dbConnection.InsertAsync(oneEmailModel);
        }

        public async Task<int> DeleteOneEmail(OneEmailModel oneEmailModel)
        {
            await SetUpDb();
            return await _dbConnection.DeleteAsync(oneEmailModel);
        }

        public async Task<List<OneEmailModel>> GetOneEmailList()
        {
            await SetUpDb();
            var oneEmailList = await _dbConnection.Table<OneEmailModel>().ToListAsync();
            return oneEmailList;
        }

        public async Task<int> UpdatOneEmail(OneEmailModel oneEmailModel)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(oneEmailModel);
        }
    }
}
