using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TinyShop.Controllers
{
    public IActionResult Index()
    {
        return ViewComponent();
    }
    public IActionResult GetAll()
    {
        try
        {
            var result:IEnumerable < ProductDO >= _productService.GetAll();
            return JsonOptions(new
            {
                code = "success",
                data = result
            });
        }
        catch (Exception ex) { }
        return Json(new
        {
            code = "fail",
            message = ex.Message
        });
    }
    public class ProductController : Controller
    {
        public IActionResult GetProductById(long id) {
            try {
                var product = _productService.GetById(id);

                return Json(new
                {

                    code = "success",
                    data = product
                });
            }

            catch (Exception ex) {
                return Json(new {

                    code = "fail",


                 message = ex.Message });
            }
        }

        public IActionResult Edit(long id) {
            ViewBag.Id = id;

            return View();
        }
            public IActionResult GetProductById(long id) ftry

            var product = _ productService.GetById(id);

            return Json(new f
            

            code = "success"data = product

catch (Exception ex) í

return Json(new (

code = "fail"

message = ex.Message

public IActionResult Edit(long id) iViewBag.Id = id;

            return View();

            [HttpPost]

            public IActionResult Delete(long id)
            {
                try
                {

                    _productService.Delete(id);

                    return Json(new
                    {

                        code = "success",
                    });
                }

                catch (Exception ex)
                {
                    return Json(new
                    {

                        code = "fail",

                        message = ex.Message
                    });
                }
            }

        private ProductService _productService;

        public ProductController(DataContext context)
        {
            _productService = new ProductService(context);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductVO product)
        {
            var productDO = new ProductDO
            {
                ProductNumber = product.ProductNumber,
                ProductName = product.ProductName,
                Price = Convert.ToDouble(product.Price),
                Price = product.Price
            };

            try
            {
                var insertedProduct = _productService.Insert(productDO);

                return Json(new
                {
                    code = "success",
                    data = insertedProduct
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    code = "fail",
                    message = ex.Message
                });
            }
        }
    }
}

