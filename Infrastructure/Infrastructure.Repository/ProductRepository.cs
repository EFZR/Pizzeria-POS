using Dapper;
using Domain.Entity;
using Infrastructure.Interface;
using Transversal.Common;

namespace Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IFactoryConnection _factoryConnection;
        public ProductRepository(IFactoryConnection factoryConnection)
        {
            _factoryConnection = factoryConnection;
        }

        #region Queries
        private readonly string INSERT = "INSERT INTO Products (Prod_Name, Prod_Description, Prod_Price, Prod_Availability) VALUES (@Prod_Name, @Prod_Description, @Prod_Price, @Prod_Availability);";
        private readonly string SELECT = "SELECT * FROM Products;";
        private readonly string SELECT_BY_ID = "SELECT * FROM Products WHERE Prod_Id = @Prod_Id;";
        private readonly string UPDATE = "UPDATE Products SET Prod_Name = @Prod_Name, Prod_Description = @Prod_Description, Prod_Price = @Prod_Price, Prod_Availability = @Prod_Availability WHERE Prod_Id = @Prod_Id;";
        private readonly string DELETE = "DELETE FROM Products WHERE Prod_Id = @Prod_Id;";
        #endregion

        #region Synchronous Methods
        public bool Insert(Product product)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("Prod_Name", product.Prod_Name);
            parameters.Add("Prod_Description", product.Prod_Description);
            parameters.Add("Prod_Price", product.Prod_Price);
            parameters.Add("Prod_Availability", product.Prod_Availability);
            var result = connection.Execute(INSERT, parameters);
            return result > 0;
        }

        public IEnumerable<Product> GetAll()
        {
            using var connection = _factoryConnection.GetConnection;
            var products = connection.Query<Product>(SELECT);
            return products;
        }

        public Product Get(string ProductId)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("Prod_Id", ProductId);
            var product = connection.QuerySingle<Product>(SELECT_BY_ID, parameters);
            return product;
        }

        public bool Update(Product product)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("Prod_Id", product.Prod_Id);
            parameters.Add("Prod_Name", product.Prod_Name);
            parameters.Add("Prod_Description", product.Prod_Description);
            parameters.Add("Prod_Price", product.Prod_Price);
            parameters.Add("Prod_Availability", product.Prod_Availability);
            var result = connection.Execute(UPDATE, parameters);
            return result > 0;
        }

        public bool Delete(string ProductId)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("Prod_Id", ProductId);
            var result = connection.Execute(DELETE, parameters);
            return result > 0;
        }
        #endregion

        #region Asynchronous Methods
        public async Task<bool> InsertAsync(Product product)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("Prod_Name", product.Prod_Name);
            parameters.Add("Prod_Description", product.Prod_Description);
            parameters.Add("Prod_Price", product.Prod_Price);
            parameters.Add("Prod_Availability", product.Prod_Availability);
            var result = await connection.ExecuteAsync(INSERT, parameters);
            return result > 0;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            using var connection = _factoryConnection.GetConnection;
            var products = await connection.QueryAsync<Product>(SELECT);
            return products;
        }

        public async Task<Product> GetAsync(string ProductId)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("Prod_Id", ProductId);
            var product = await connection.QuerySingleAsync<Product>(SELECT_BY_ID, parameters);
            return product;
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("Prod_Id", product.Prod_Id);
            parameters.Add("Prod_Name", product.Prod_Name);
            parameters.Add("Prod_Description", product.Prod_Description);
            parameters.Add("Prod_Price", product.Prod_Price);
            parameters.Add("Prod_Availability", product.Prod_Availability);
            var result = await connection.ExecuteAsync(UPDATE, parameters);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(string ProductId)
        {
            using var connection = _factoryConnection.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("Prod_Id", ProductId);
            var result = await connection.ExecuteAsync(DELETE, parameters);
            return result > 0;
        }
        #endregion
    }
}
