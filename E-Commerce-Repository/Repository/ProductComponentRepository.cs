using E_Commerce_Repository.InitializationDB;
using E_Commerce_Repository.Models;
using E_Commerce_Repository.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Repository
{
    public class ProductComponentRepository : ProductComponentService
    {
        public EcommerIntializationDB repository = new EcommerIntializationDB();

        public void CreateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void CreateCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public void CreateFeedback(Feedback feedback)
        {
            throw new NotImplementedException();
        }

        public void CreateSuplier(Supplier supplier)
        {
            throw new NotImplementedException();
        }

        public void CreateTypeProduct(TypeProduct typeProduct)
        {
            throw new NotImplementedException();
        }

        public void CreateWareHouse(Warehouse warehouse)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(int Id)
        {
            throw new NotImplementedException();
        }

        public void DeleteSuplier(int Id)
        {
            throw new NotImplementedException();
        }

        public void DeleteTypeProduct(int Id)
        {
            throw new NotImplementedException();
        }

        public void DeteleCompany(int Id)
        {
            throw new NotImplementedException();
        }

        public void DeteleWareHouse(int Id)
        {
            throw new NotImplementedException();
        }

        public void DeteteFeedback(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Category getCategory(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Company> GetCompanies()
        {
            throw new NotImplementedException();
        }

        public Company GetCompany(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Feedback> GetFeedbackOfAccountConsumer(int AccountConsumerId)
        {
            throw new NotImplementedException();
        }

        public List<Feedback> GetFeedbacks(int productId)
        {
            throw new NotImplementedException();
        }

        public TypeProduct getProductType(int Id)
        {
            throw new NotImplementedException();
        }

        public List<TypeProduct> GetProductTypes()
        {
            throw new NotImplementedException();
        }

        public Supplier GetSupplier(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Supplier> GetSuppliers()
        {
            throw new NotImplementedException();
        }

        public Warehouse GetWarehouse(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Warehouse> GetWareHouse()
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void UpdateCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public void UpdateFeedBack(Feedback feedback)
        {
            throw new NotImplementedException();
        }

        public void UpdateSuplier(Supplier supplier)
        {
            throw new NotImplementedException();
        }

        public void UpdateTypeProduct(TypeProduct typeProduct)
        {
            throw new NotImplementedException();
        }

        public void UpdateWareHouse(Warehouse wareHouse)
        {
            throw new NotImplementedException();
        }
    }
}
