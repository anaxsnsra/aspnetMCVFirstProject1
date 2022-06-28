using aspneMVCProject1.Data;
using aspneMVCProject1.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspneMVCProject1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly applicationDBContext applicationDBContext;

        public CategoryController(applicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> listCategory = applicationDBContext.Category;
            return View(listCategory);
        }

        //GET Create
        public IActionResult Create()
        {
            return View();
        }

        //POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    applicationDBContext.Category.Add(category);
                    await applicationDBContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(category);
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
