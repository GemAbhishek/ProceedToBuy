using Product.Model;

namespace Product.Repository
{
    public interface IProductRepo
    {
        ProductItem GetDetail(int Id);
    }
}