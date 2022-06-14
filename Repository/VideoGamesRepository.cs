using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDVideoGamesApp.Repository
{
    public class VideoGamesRepository<T> : IVideoGamesRepository<T> where T : class
    {


        private readonly DbConfig _dbConfig;

        public VideoGamesRepository(DbConfig dbConfig)
        {
            _dbConfig = dbConfig;
        }

        public async Task<IEnumerable<T>> GetVideoGames()
        {

            using (var connection = CreateConnection.CreateCnn(_dbConfig.Name))
            {
                await connection.OpenAsync();
                var storedProc = "dbo.GetAll_VideoGames";
                var result = await connection.QueryAsync<T>(storedProc, commandType: CommandType.StoredProcedure);
           
                return result;
            }
        }
        public async Task<IEnumerable<T>> GetEntityById(string spname, int id)
        {
            using (var connection = CreateConnection.CreateCnn(_dbConfig.Name))
            {
                await connection.OpenAsync();

                var parameters = new DynamicParameters();
                parameters.Add("id", id, DbType.String);

                var result = await connection
                   .QueryAsync<T>(spname,
                                  parameters,
                                  commandType: CommandType.StoredProcedure);

                return result;
            }
        }
        public async Task DeleteEntities(string spname, int id)
        {
            using (var connection = CreateConnection.CreateCnn(_dbConfig.Name))
            {
                await connection.OpenAsync();

                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.String);

                await connection
                   .ExecuteAsync(spname,
                                   parameters,
                                   commandType: CommandType.StoredProcedure);
            }
        }
    }
}
