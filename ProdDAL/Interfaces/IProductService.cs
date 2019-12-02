using ProdDAL.BindingModels;
using ProdDAL.ViewModels;
using ProdModel;
using System.Collections.Generic;

namespace ProdDAL.Interfaces
{
    public interface IProductService
    {
        ProductViewModel GetElement(int id);
        List<ProductViewModel> GetList();
        void AddElement(ProductBindingModel model);
        void UpdElement(ProductBindingModel model);
        void DelElement(int id);
    }
}
