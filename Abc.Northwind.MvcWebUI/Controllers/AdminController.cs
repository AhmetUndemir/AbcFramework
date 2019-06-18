using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc.Northwind.Business.Abstract;
using Abc.Northwind.Entities.Concrete;
using Abc.Northwind.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Abc.Northwind.MvcWebUI.Controllers
{
    public class AdminController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var productListViewModel = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };
            return View(productListViewModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new ProductAddViewModel
            {
                Product = new Product(),
                Categories = _categoryService.GetAll()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(product);
                TempData.Add("message", "Product was successfully added");
            }
            return RedirectToAction("Add");
        }
    }




}