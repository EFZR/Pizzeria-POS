using Dapper;
using Domain.Entity;
using Infrastructure.Interface;
using Transversal.Common;

namespace Infrastructure.Repository
{
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly IFactoryConnection _factoryConnection;
        public ProvinceRepository(IFactoryConnection factoryConnection)
        {
            _factoryConnection = factoryConnection;
        }

        #region Queries
        private readonly string INSERT = "INSERT INTO Province (Provi_CountryId, Provi_Name) VALUES (@Provi_CountryId, @Provi_Name);";
        private readonly string SELECT = "SELECT * FROM Province;";
        private readonly string SELECT_BY_ID = "SELECT * FROM Province WHERE Provi_Id = @Provi_Id;";
        private readonly string UPDATE = "UPDATE Province SET Provi_CountryId = @Provi_CountryId, Provi_Name = @Provi_Name WHERE Provi_Id = @Provi_Id;";
        private readonly string DELETE = "DELETE FROM Province WHERE Provi_Id = @Provi_Id;";
        #endregion

        #region Synchronous Methods
        public bool Insert(Province province)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("Provi_CountryId", province.Provi_CountryId);
            parameters.Add("Provi_Name", province.Provi_Name);
            var result = connection.Execute(INSERT, parameters);
            return result > 0;
        }

        public IEnumerable<Province> GetAll()
        {
            using var connection = _factoryConnection.GetConnection;
            var provinces = connection.Query<Province>(SELECT);
            return provinces;
        }

        public Province Get(string ProvinceId)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("Provi_Id", ProvinceId);
            var province = connection.QuerySingle<Province>(SELECT_BY_ID, parameters);
            return province;
        }

        public bool Update(Province province)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("Provi_Id", province.Provi_Id);
            parameters.Add("Provi_CountryId", province.Provi_CountryId);
            parameters.Add("Provi_Name", province.Provi_Name);
            var result = connection.Execute(UPDATE, parameters);
            return result > 0;
        }

        public bool Delete(string ProvinceId)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("Provi_Id", ProvinceId);
            var result = connection.Execute(DELETE, parameters);
            return result > 0;
        }
        #endregion

        #region Asynchronous Methods
        public async Task<bool> InsertAsync(Province province)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("Provi_CountryId", province.Provi_CountryId);
            parameters.Add("Provi_Name", province.Provi_Name);
            var result = await connection.ExecuteAsync(INSERT, parameters);
            return result > 0;
        }

        public async Task<IEnumerable<Province>> GetAllAsync()
        {
            using var connection = _factoryConnection.GetConnection;
            var provinces = await connection.QueryAsync<Province>(SELECT);
            return provinces;
        }

        public async Task<Province> GetAsync(string ProvinceId)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("Provi_Id", ProvinceId);
            var province = await connection.QuerySingleAsync<Province>(SELECT_BY_ID, parameters);
            return province;
        }

        public async Task<bool> UpdateAsync(Province province)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("Provi_Id", province.Provi_Id);
            parameters.Add("Provi_CountryId", province.Provi_CountryId);
            parameters.Add("Provi_Name", province.Provi_Name);
            var result = await connection.ExecuteAsync(UPDATE, parameters);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(string ProvinceId)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("Provi_Id", ProvinceId);
            var result = await connection.ExecuteAsync(DELETE, parameters);
            return result > 0;
        }
        #endregion
    }
}
