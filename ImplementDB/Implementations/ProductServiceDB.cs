using ProdDAL.BindingModels;
using ProdDAL.Interfaces;
using ProdDAL.ViewModels;
using ImplementDB;
using ProdModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ImplementDB.Implementations
{
    public class ProductServiceDB : IProductService
    {
        private DBContext context;
        public ProductServiceDB(DBContext context)
        {
            this.context = context;
        }
        public List<ProductViewModel> GetList()
        {
            List<ProductViewModel> result = context.Products.Select(rec => new
            ProductViewModel
            {
                Id = rec.Id,
                ProductName = rec.ProductName,
                ProductUnit = rec.ProductUnit,
                ProductAmount = rec.ProductAmount,
                ProductData = rec.ProductData,
            })
            .ToList();
            return result;
        }

        public ProductViewModel GetElement(int id)
        {
            Product element = context.Products.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new ProductViewModel
                {
                    Id = element.Id,
                    ProductName = element.ProductName,
                    ProductUnit = element.ProductUnit,
                    ProductAmount = element.ProductAmount,
                    ProductData = element.ProductData,
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(ProductBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Product element = context.Products.FirstOrDefault(rec =>
                    rec.ProductName == model.ProductName);
                    if (element != null)
                    {
                        throw new Exception("Уже есть изделие с таким названием");
                    }
                    element = new Product ()
                    {
                        ProductName = model.ProductName,
                        ProductUnit = model.ProductUnit,
                        ProductAmount = model.ProductAmount,
                        ProductData = model.ProductData,
                    };
                    context.Products.Add(element);
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void UpdElement(ProductBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Product element = context.Products.FirstOrDefault(rec =>
                    rec.ProductName == model.ProductName && rec.Id != model.Id);
                    if (element != null)
                    {
                        throw new Exception("Уже есть изделие с таким названием");
                    }
                    element = context.Products.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    element.ProductName = model.ProductName;
                    element.ProductUnit = model.ProductUnit;
                    element.ProductAmount = model.ProductAmount;
                    element.ProductData = model.ProductData;
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void DelElement(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Product element = context.Products.FirstOrDefault(rec => rec.Id ==
                    id);
                    if (element != null)
                    {
                        // удаяем записи по компонентам при удалении изделия
                        context.Products.Remove(element);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Элемент не найден");
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}