using FirstApp.DataAccess.Data;
using FirstApp.DataAccess.Repository.IRepository;
using FirstApp.Models;
using FirstApp.Models.ViewModels;
using FirstApp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata.Ecma335;

namespace FirstAppWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
   [Authorize(Roles = SD.Role_Admin)]

    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitofWork;
        public CompanyController(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public IActionResult Index()
        {
            List<Company> objCompanyList = _unitofWork.Company.GetAll().ToList();           

            return View(objCompanyList);
        }

        public IActionResult Upsert(int? id) //UpdateInsert
        {
        
            if(id == null || id == 0)
            {
                //create
                return View(new Company());
            }
            else
            {
                //update
                Company companyObj = _unitofWork.Company.Get(u => u.Id == id);
                return View(companyObj);
            }
        }
        [HttpPost]
        public IActionResult Upsert(Company  CompanyObj)
        {
            if (ModelState.IsValid)
            {
               
                if(CompanyObj.Id == 0)
                {
                    _unitofWork.Company.Add(CompanyObj);
                    
                }
                else
                {
                    _unitofWork.Company.Update(CompanyObj);

                    
                }

                _unitofWork.Save();
                TempData["success"] = "Company Created Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(CompanyObj);
            }
            
        }



        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> objCompanyList = _unitofWork.Company.GetAll().ToList();

            return Json(new {data = objCompanyList});
        }

        [HttpDelete]
        public IActionResult Delete(int? id )
        {
            var CompanyToBeDeleted   = _unitofWork.Company.Get(u => u.Id==id);   

            if (CompanyToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }           

           
            _unitofWork.Company.Remove(CompanyToBeDeleted);
            _unitofWork.Save();
            return Json(new {success = true , message = "Delete Successful" });
        }


        #endregion


    }
}
