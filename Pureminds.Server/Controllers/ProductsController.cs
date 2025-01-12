namespace Pureminds.Server;
public class ProductsController : BaseController<Product>
{
    IProductService _service;
    public ProductsController(IProductService service) : base(service)
    {
        _service = service;
    }
    [HttpGet("GetProductsWithAttachments")]
    public async Task<List<Product>> GetProductsWithAttachments()
    {
        try
        {
            return await _service.GetProductsWithAttachments();
        }
        catch (Exception ex) 
        {
            throw ex;
        }
    }
    [HttpGet("GetPrioritizedProducts")]
    public async Task<List<Product>> GetPrioritizedProducts()
    {
        try
        {
            return await _service.GetPrioritizedProducts();
        }
        catch (Exception ex) 
        {
            throw ex;
        }
    }
    [HttpGet("GetProductWithAttachments/{id}")]
    public async Task<Product> GetProductWithAttachments(int id)
    {
        try
        {
            return await _service.GetProductWithAttachments(id);
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }
}
