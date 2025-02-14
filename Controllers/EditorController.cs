using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using UrunSatisSistemi.Models;

namespace UrunSatisSistemi.Controllers
{
    public class EditorController : Controller
    {
        private readonly IDbConnection _connection;

        public EditorController(IDbConnection connection)
        {
            _connection = connection;
        }

        public IActionResult Editor()
        {
            var productList = _connection.Query<Products>("SELECT * FROM Products");
            return View(productList);
        }

        public IActionResult InsertProducts(Products product) 
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var insertProduct = _connection.Execute(
                                                      @"INSERT INTO Products
                                                        (Name,Stok,PurchasePrice,SalesPrice,ImageURL)
                                                        VALUES
                                                        (@Name,@Stok,@PurchasePrice,@SalesPrice,@ImageURL)",product
                                                       );
            return RedirectToAction("Editor");
        }

        [HttpPost]
        public IActionResult UpdateProduct(Products product) 
        {
            var updateProduct = _connection.Execute(
                                                    @"UPDATE Products 
                                                      SET
                                                     Name=@Name,
                                                     Stok =@Stok,
                                                     PurchasePrice =@PurchasePrice,
                                                     SalesPrice =@SalesPrice,
                                                     ImageURL = @ImageURL
                                                     WHERE Id=@Id", product
                                                   );
            return RedirectToAction("Editor");
        }

        [HttpPost]
        public IActionResult DeleteProduct(int Id) 
        {
            var deleteProduct = _connection.Execute("DELETE FROM Products WHERE Id=@Id", new {Id});

            return RedirectToAction("Editor");
        }
    }
}
