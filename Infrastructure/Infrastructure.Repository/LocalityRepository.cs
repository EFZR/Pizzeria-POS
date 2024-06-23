using Dapper;
using Domain.Entity;
using Infrastructure.Interface;
using Transversal.Common;

namespace Infrastructure.Repository
{
    public class LocalityRepository : ILocalityRepository
    {
        private readonly IFactoryConnection _factoryConnection;
        public LocalityRepository(IFactoryConnection factoryConnection)
        {
            _factoryConnection = factoryConnection;
        }

        #region Queries
        private readonly string INSERT = "INSERT INTO Locality (Local_ProviId, Local_Name) VALUES (@Local_ProviId, @Local_Name);";
        private readonly string SELECT = "SELECT * FROM Locality;";
        private readonly string SELECT_BY_ID = "SELECT * FROM Locality WHERE Local_Id = @Local_Id;";
        private readonly string UPDATE = "UPDATE Locality SET Local_ProviId = @Local_ProviId, Local_Name = @Local_Name WHERE Local_Id = @Local_Id;";
        private readonly string DELETE = "DELETE FROM Locality WHERE Local_Id = @Local_Id;";
        #endregion

        #region Synchronous Methods
        public bool Insert(Locality locality)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("Local_ProviId", locality.Local_ProviId);
            parameters.Add("Local_Name", locality.Local_Name);
            var result = connection.Execute(INSERT, parameters);
            return result > 0;
        }

        public IEnumerable<Locality> GetAll()
        {
            using var connection = _factoryConnection.GetConnection;
            var localities = connection.Query<Locality>(SELECT);
            return localities;
        }

        public Locality Get(string LocalityId)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("Local_Id", LocalityId);
            var locality = connection.QuerySingle<Locality>(SELECT_BY_ID, parameters);
            return locality;
        }

        public bool Update(Locality locality)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("Local_Id", locality.Local_Id);
            parameters.Add("Local_ProviId", locality.Local_ProviId);
            parameters.Add("Local_Name", locality.Local_Name);
            var result = connection.Execute(UPDATE, parameters);
            return result > 0;
        }

        public bool Delete(string LocalityId)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("Local_Id", LocalityId);
            var result = connection.Execute(DELETE, parameters);
            return result > 0;
        }
        #endregion

        #region Asynchronous Methods
        public async Task<bool> InsertAsync(Locality locality)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("Local_ProviId", locality.Local_ProviId);
            parameters.Add("Local_Name", locality.Local_Name);
            var result = await connection.ExecuteAsync(INSERT, parameters);
            return result > 0;
        }

        public async Task<IEnumerable<Locality>> GetAllAsync()
        {
            using var connection = _factoryConnection.GetConnection;
            var localities = await connection.QueryAsync<Locality>(SELECT);
            return localities;
        }

        public async Task<Locality> GetAsync(string LocalityId)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("Local_Id", LocalityId);
            var locality = await connection.QuerySingleAsync<Locality>(SELECT_BY_ID, parameters);
            return locality;
        }

        public async Task<bool> UpdateAsync(Locality locality)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("Local_Id", locality.Local_Id);
            parameters.Add("Local_ProviId", locality.Local_ProviId);
            parameters.Add("Local_Name", locality.Local_Name);
            var result = await connection.ExecuteAsync(UPDATE, parameters);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(string LocalityId)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("Local_Id", LocalityId);
            var result = await connection.ExecuteAsync(DELETE, parameters);
            return result > 0;
        }
        #endregion
    }
}
