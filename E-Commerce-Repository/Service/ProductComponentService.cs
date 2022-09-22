using E_Commerce_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Service {
    interface ProductComponentService {
        // QUẢN LÝ DANH MỤC SẢN PHẨM
        Category getCategory(int Id);

        List<Category> GetCategories();

        void CreateCategory(Category category);

        void UpdateCategory(Category category);

        void DeleteCategory(int Id);
        // QUẢN LÝ LOẠI SẢN PHẨM
        TypeProduct getProductType(int Id);

        List<TypeProduct> GetProductTypes();

        void CreateTypeProduct(TypeProduct typeProduct);

        void UpdateTypeProduct(TypeProduct typeProduct);

        void DeleteTypeProduct(int Id);
        // QUẢN LÝ NHÀ CUNG CẤP
        Supplier GetSupplier(int Id);

        List<Supplier> GetSuppliers();

        void CreateSuplier(Supplier supplier);

        void UpdateSuplier(Supplier supplier);

        void DeleteSuplier(int Id);

        // QUẢN LÝ HÃNG
        Company GetCompany(int Id);

        List<Company> GetCompanies();

        void CreateCompany(Company company);

        void UpdateCompany(Company company);

        void DeteleCompany(int Id);
        // QUẢN LÝ KHO
        Warehouse GetWarehouse(int Id);
        List<Warehouse> GetWareHouse();

        void CreateWareHouse(Warehouse warehouse);

        void UpdateWareHouse(Warehouse wareHouse);

        void DeteleWareHouse(int Id);

        // QUẢN LÝ COMMENT;
        // Lấy sản feedback của sản phẩm
        List<Feedback> GetFeedbacks(int productId);

        // Lấy feedback của account consumer
        List<Feedback> GetFeedbackOfAccountConsumer(int AccountConsumerId);
        void CreateFeedback(Feedback feedback);
        void UpdateFeedBack(Feedback feedback);
        void DeteteFeedback(int Id);


    }
}
