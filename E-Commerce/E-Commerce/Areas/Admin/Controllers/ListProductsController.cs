using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using E_Commerce_Repository.InitializationDB;
using E_Commerce_Repository.Models;

namespace E_Commerce.Areas.Admin.Controllers
{
    public class ListProductsController : BaseController {
        private EcommerIntializationDB db = new EcommerIntializationDB();

        // GET: Admin/ListProducts
        public ActionResult Index()
        {
            //var products = db.Products.Include(p => p.Describe);
            //return View(products.ToList());
            return View(db.Products.ToList());
        }

        // GET: Admin/ListProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/ListProducts/Create
        [HttpGet]
        public ActionResult Create()
        {
            //ViewBag.Id = new SelectList(db.Describes, "Id", "Description");
            /*ViewBag.DescribeID = new SelectList(db.Describes.ToList().OrderBy(x=>x.Description), "Id", "Description");*/
            ViewBag.PromotionID = new SelectList(db.Promotions.ToList().OrderBy(x => x.Name), "Id", "Name");
            ViewBag.CompanyID = new SelectList(db.Companys.ToList().OrderBy(x => x.Name), "Id", "Name");
            ViewBag.SupplierID = new SelectList(db.Suppliers.ToList().OrderBy(x => x.Name), "Id", "Name");
            ViewBag.TypeProductID = new SelectList(db.TypeProducts.ToList().OrderBy(x => x.Name), "Id", "Name");
            return View();
        }

        // POST: Admin/ListProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Product product, HttpPostedFileBase fileupload)
        {
            /*ViewBag.DescribeID = new SelectList(db.Describes.ToList().OrderBy(x => x.Description), "Id", "Description");*/
            ViewBag.PromotionID = new SelectList(db.Promotions.ToList().OrderBy(x => x.Name), "Id", "Name");
            ViewBag.CompanyID = new SelectList(db.Companys.ToList().OrderBy(x => x.Name), "Id", "Name");
            ViewBag.SupplierID = new SelectList(db.Suppliers.ToList().OrderBy(x => x.Name), "Id", "Name");
            ViewBag.TypeProductID = new SelectList(db.TypeProducts.ToList().OrderBy(x => x.Name), "Id", "Name");
            if(fileupload == null)
            {
                ViewBag.Thongbao = "Vui lòng chọn ảnh";
                return View();
            }
            else
            {
                if(ModelState.IsValid)
                {
                    var fileName = Path.GetFileName(fileupload.FileName);
                    var path = Path.Combine(Server.MapPath("~/Resources/ProductImage/"), fileName);
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                    }
                    else
                    {
                        fileupload.SaveAs(path);
                    }
                   
                    // TẠO SẢN PHẨM TRƯỚC - VÌ EM NÓ LÀ CHA
                    db.Products.Add(product);
                    db.SaveChanges();
                    // GỌI SẢN PHẨM ĐÃ LƯU RA
                    var productStoreInDb = db.Products.FirstOrDefault(prop => prop.Name == product.Name);

                    // Tạo mới cái hình 
                    ProductImage image = new ProductImage() { URL = "/Resources/ProductImage/" + fileName , ProductID = productStoreInDb.Id};

                    // thêm cái hình vào db
                    db.ProductImages.Add(image);
                    db.SaveChanges();

                    // gọi sản phẩm trong db ra và thêm hình cho nó
                    productStoreInDb.ProductImages.Add(image);
                    db.SaveChanges();
                    // luuư hình xong ròi

                    /*Describe describe = new Describe() { ProductID = productStoreInDb.Id };
                    db.Describes.Add(describe);
                    db.SaveChanges();*/
                  
                }
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/ListProducts/Edit/5
        public ActionResult Edit(int id)
        {
            /*ViewBag.Id = new SelectList(db.Describes, "Id", "Description");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }*/
            Product product = db.Products.FirstOrDefault(x=>x.Id==id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.PromotionID = new SelectList(db.Promotions.ToList().OrderBy(x => x.Name), "Id", "Name", product.PromotionID);
            ViewBag.CompanyID = new SelectList(db.Companys.ToList().OrderBy(x => x.Name), "Id", "Name", product.CompanyID);
            ViewBag.SupplierID = new SelectList(db.Suppliers.ToList().OrderBy(x => x.Name), "Id", "Name", product.SupplierID);
            ViewBag.TypeProductID = new SelectList(db.TypeProducts.ToList().OrderBy(x => x.Name), "Id", "Name", product.TypeProductID);
            var mota = db.Describes.ToList();


            if (mota != null)
            {
               // ViewBag.MOTA = mota.Description;
            }
           
            return View(product);
        }

        // POST: Admin/ListProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Product product, HttpPostedFileBase fileupload)
        {
            //Đưa dữ liệu vào dropdownload
            ViewBag.PromotionID = new SelectList(db.Promotions.ToList().OrderBy(x => x.Name), "Id", "Name", product.PromotionID);
            ViewBag.CompanyID = new SelectList(db.Companys.ToList().OrderBy(x => x.Name), "Id", "Name", product.CompanyID);
            ViewBag.SupplierID = new SelectList(db.Suppliers.ToList().OrderBy(x => x.Name), "Id", "Name", product.SupplierID);
            ViewBag.TypeProductID = new SelectList(db.TypeProducts.ToList().OrderBy(x => x.Name), "Id", "Name", product.TypeProductID);
            //Kiểm tra đường dẫn file
            if(fileupload == null)
            {
                ViewBag.Thongbao = "Vui lòng chọn ảnh";
                return View();
            }
            //Thêm vào CSDL
            else
            {
                if(ModelState.IsValid)
                {
                    //Lưu tên file
                    var fileName = Path.GetFileName(fileupload.FileName);
                    //Lưu đường dẫn file
                    var path = Path.Combine(Server.MapPath("~/Resources/ProductImage/"), fileName);
                    //Kiểm tra hình ảnh tồn tạo chưa?
                    if(System.IO.File.Exists(path))
                    {
                        ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                    }
                    else
                    {
                        fileupload.SaveAs(path);
                    }
                    UpdateModel(product);
                    db.SaveChanges();
                    // GỌI SẢN PHẨM ĐÃ LƯU RA
                    var productStoreInDb = db.Products.FirstOrDefault(prop => prop.Name == product.Name);

                    // Tạo mới cái hình 
                    ProductImage image = new ProductImage() { URL = "/Resources/ProductImage/" + fileName, ProductID = productStoreInDb.Id };

                    // thêm cái hình vào db
                    UpdateModel(image);
                    db.SaveChanges();

                    Describe describe = db.Describes.FirstOrDefault(x => x.ProductID == product.Id);
                    UpdateModel(describe);
                    db.SaveChanges();
                    //gọi sản phẩm trong db ra và thêm hình cho nó
                    //productStoreInDb.ProductImages.Add(image);
                    //db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        // GET: Admin/ListProducts/Delete/5
        public ActionResult Delete(int id)
        {
            Product product = db.Products.Find(id);
            ViewBag.IDProduct = product.Id;
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/ListProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Phải có try catch
            /*

             */
            try
            {
                // Tìm sản phẩm trong db
                Product product = db.Products.Find(id);
                ViewBag.IDProduct = product.Id;

                // Lấy danh sách hình ảnh có id bằng product.id
                // Foreach() -> xóa hình trong db
                List<ProductImage> imageNeedToDelete = db.ProductImages.Where(x => x.ProductID == product.Id).ToList();
                foreach (ProductImage img in imageNeedToDelete) {
                    db.ProductImages.Remove(img);
                    db.SaveChanges();
                }
                
                // Lấy bản mô tả trong db
                Describe describeStoreInDB = db.Describes.FirstOrDefault(prop => prop.ProductID == id);
                if (describeStoreInDB != null)
                {
                    // Xóa nó
                    db.Describes.Remove(describeStoreInDB);
                    db.SaveChanges();
                }
               
                // Xóa product
                db.Products.Remove(product);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
