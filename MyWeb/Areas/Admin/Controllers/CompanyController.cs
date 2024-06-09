using BookUrBook.DataAccess.Repositories.IRepository;
using BookUrBook.Models;
using BookUrBook.Models.ViewModels;
using BookUrBook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookUrBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = StaticDetails.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Companies> companies = _unitOfWork.CompanyRepository
                .GetAll()
                .ToList();

            return View(companies);
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                // Create
                return View(new Companies());
            }
            else
            {
                // Update
                Companies companyObj = _unitOfWork.CompanyRepository
                    .Get(x => x.Id == id);
                return View(companyObj);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Companies companies)
        {

            if (ModelState.IsValid)
            {
                if (companies.Id == 0)
                {
                    _unitOfWork.CompanyRepository.Add(companies);
                    TempData["success"] = "Company created successfully";

                }
                else
                {
                    _unitOfWork.CompanyRepository.Update(companies);
                    TempData["success"] = "Company updated successfully";
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(companies);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Companies> companies = _unitOfWork.CompanyRepository
                .GetAll()
                .ToList();

            return Json(new { data = companies });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var companyToBeDeleted = _unitOfWork.CompanyRepository.Get(x => x.Id == id);
            if (companyToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.CompanyRepository.Remove(companyToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });
        }

        
    }
}
