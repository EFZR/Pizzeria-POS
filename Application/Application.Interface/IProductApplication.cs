using Application.DTO;
using Transversal.Common;

namespace Application.Interface;

public interface IProductApplication
{
#region Synchronous Methods
    Response<bool> Insert(ProductDTO productDTO);
    Response<bool> Update(ProductDTO productDTO);
    Response<bool> Delete(string ProductId);
    Response<ProductDTO> Get(string ProductId);
    Response<IEnumerable<ProductDTO>> GetAll();
    #endregion

    #region Asynchronous Methods
    Task<Response<bool>> InsertAsync(ProductDTO productDTO);
    Task<Response<bool>> UpdateAsync(ProductDTO productDTO);
    Task<Response<bool>> DeleteAsync(string ProductId);
    Task<Response<ProductDTO>> GetAsync(string ProductId);
    Task<Response<IEnumerable<ProductDTO>>> GetAllAsync();
    #endregion

}
