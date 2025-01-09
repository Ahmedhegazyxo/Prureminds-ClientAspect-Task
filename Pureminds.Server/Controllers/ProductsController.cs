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
        return await _service.GetProductsWithAttachments();
    }
}
