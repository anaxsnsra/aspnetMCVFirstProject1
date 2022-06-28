using aspneMVCProject1.Data;
using aspneMVCProject1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspneMVCProject1.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly applicationDBContext applicationDBContext;

        public ApplicationTypeController(applicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }

        public IActionResult Index()
        {
            try
            {
                IEnumerable<ApplicationType> applicationTypesList = applicationDBContext.ApplicationType;
                return View(applicationTypesList);
            }
            catch (Exception ex)
            {
                throw;
            }
          
        }

        //GET Create
        public IActionResult Create()
        {
            return View();
        }

        //POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(ApplicationType applicationType)
        {
            try
            {
                applicationDBContext.ApplicationType.Add(applicationType);
                await applicationDBContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
