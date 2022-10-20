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
        //Add category
        public void CreateCategory(Category category)
        {
            repository.Categorys.Add(category);
            repository.SaveChanges();
        }
        //Add company
        public void CreateCompany(Company company)
        {
            repository.Companys.Add(company);
            repository.SaveChanges();
        }
        //Add feedback
        public void CreateFeedback(Feedback feedback)
        {
            repository.Feedbacks.Add(feedback);
            repository.SaveChanges();
        }
        //Add supplier
        public void CreateSuplier(Supplier supplier)
        {
            repository.Suppliers.Add(supplier);
            repository.SaveChanges();
        }
        //Add typeproduct
        public void CreateTypeProduct(TypeProduct typeProduct)
        {
            repository.TypeProducts.Add(typeProduct);
            repository.SaveChanges();
        }
        //Add warehouse
        public void CreateWareHouse(Warehouse warehouse)
        {
            repository.Warehouses.Add(warehouse);
            repository.SaveChanges();
        }
        //Delete category
        public void DeleteCategory(int Id)
        {
            var cate = repository.Categorys.Find(Id);
            repository.Categorys.Remove(cate);
            repository.SaveChanges();
        }
        //Delete suplier
        public void DeleteSuplier(int Id)
        {
            var sup = repository.Suppliers.Find(Id);
            repository.Suppliers.Remove(sup);
            repository.SaveChanges();
        }
        //Delete typeproduct
        public void DeleteTypeProduct(int Id)
        {
            var ty = repository.TypeProducts.Find(Id);
            repository.TypeProducts.Remove(ty);
            repository.SaveChanges();
        }
        //Detele company
        public void DeteleCompany(int Id)
        {
            var com = repository.Companys.Find(Id);
            repository.Companys.Remove(com);
            repository.SaveChanges();
        }
        //Detele warehouse
        public void DeteleWareHouse(int Id)
        {
            var wh = repository.Warehouses.Find(Id);
            repository.Warehouses.Remove(wh);
            repository.SaveChanges();
        }
        //Detete feedback
        public void DeteteFeedback(int Id)
        {
            var fb = repository.Feedbacks.Find(Id);
            repository.Feedbacks.Remove(fb);
            repository.SaveChanges();
        }
        //Lấy toàn bộ danh sách category
        public List<Category> GetCategories()
        {
            return repository.Categorys.ToList();
        }
        //Lấy category theo id
        public Category getCategory(int Id)
        {

            return (from category in repository.Categorys
                    where category.Id == Id
                    select category).FirstOrDefault();

        }
        //Lấy toàn bộ danh sách company
        public List<Company> GetCompanies()
        {

            //  return (from company in repository.Companys
            //         select company).ToList();
            return repository.Companys.ToList();
        }
        //Lấy company theo id
        public Company GetCompany(int Id)
        {
            return (from company in repository.Companys
                    where company.Id == Id
                    select company).FirstOrDefault();
        }
        //Lấy feedback từ accountconsumerId
        public List<Feedback> GetFeedbackOfAccountConsumer(int AccountConsumerId)
        {
            /*  return (from feedback in repository.Feedbacks
                      from account in repository.Accounts
                      from accountconsumer in repository.Accounts
                      from accountrole in repository.AccountRoles
                      where account.Id == AccountConsumerId && account.AccountRoles == accountrole.Account
                            && accountrole.isActive == true && feedback.AccountConsumer == accountconsumer.Feedbacks
                      select feedback).ToList();
            */
            return null;
        }
        //Lấy feedback từ productId
        public List<Feedback> GetFeedbacks(int productId)
        {
            return (from feedback in repository.Feedbacks
                    from product in repository.Products
                    where product.Id == productId && product.Feedbacks == feedback.Product
                    select feedback).ToList();
        }
        //Lấy typeproduct theo id
        public TypeProduct getProductType(int Id)
        {
            return (from typeproduct in repository.TypeProducts
                    where typeproduct.Id == Id
                    select typeproduct).FirstOrDefault();
        }
        //Lấy toàn bộ danh sách typeproduct
        public List<TypeProduct> GetProductTypes()
        {
            return (from typeproduct in repository.TypeProducts
                    select typeproduct).ToList();
        }
        //Lấy supplier theo id
        public Supplier GetSupplier(int Id)
        {
            return (from supplier in repository.Suppliers
                    where supplier.Id == Id
                    select supplier).FirstOrDefault();
        }
        //Lấy toàn bộ danh sách supplier
        public List<Supplier> GetSuppliers()
        {
            return (from supplier in repository.Suppliers
                    select supplier).ToList();
        }
        //Lấy warehouse theo id
        public Warehouse GetWarehouse(int Id)
        {
            return (from warehouse in repository.Warehouses
                    where warehouse.Id == Id
                    select warehouse).FirstOrDefault();
        }
        //Lấy toàn bộ danh sách warehouse
        public List<Warehouse> GetWareHouse()
        {
            return (from warehouse in repository.Warehouses
                    select warehouse).ToList();
        }
        
        public void UpdateCategory(Category category)
        {
            repository.Categorys.Attach(category);
            repository.Entry(category).State = System.Data.Entity.EntityState.Modified;
            repository.SaveChanges();
        }

        public void UpdateCompany(Company company)
        {
            repository.Companys.Attach(company);
            repository.Entry(company).State = System.Data.Entity.EntityState.Modified;
            repository.SaveChanges();
        }

        public void UpdateFeedBack(Feedback feedback)
        {
            repository.Feedbacks.Attach(feedback);
            repository.Entry(feedback).State = System.Data.Entity.EntityState.Modified;
            repository.SaveChanges();
        }

        public void UpdateSuplier(Supplier supplier)
        {
            repository.Suppliers.Attach(supplier);
            repository.Entry(supplier).State = System.Data.Entity.EntityState.Modified;
            repository.SaveChanges();
        }

        public void UpdateTypeProduct(TypeProduct typeProduct)
        {
            repository.TypeProducts.Attach(typeProduct);
            repository.Entry(typeProduct).State = System.Data.Entity.EntityState.Modified;
            repository.SaveChanges();
        }

        public void UpdateWareHouse(Warehouse wareHouse)
        {
            repository.Warehouses.Attach(wareHouse);
            repository.Entry(wareHouse).State = System.Data.Entity.EntityState.Modified;
            repository.SaveChanges();
        }
    }
}
