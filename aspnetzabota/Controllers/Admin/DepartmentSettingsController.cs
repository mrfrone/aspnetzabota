using aspnetzabota.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using aspnetzabota.Web.Common;
using Microsoft.AspNetCore.Authorization;
using aspnetzabota.Content.Services.Department;
using aspnetzabota.Content.Services.Price;
using aspnetzabota.Content.Datamodel.Department;

namespace aspnetzabota.Controllers
{
    [Route("admin/[controller]/[action]")]
    [Authorize]
    public class DepartmentSettingsController : BaseController
    {
        private readonly IDepartment _department;
        private readonly IPrice _price;

        public DepartmentSettingsController(IDepartment department, IPrice price)
        {
            _department = department;
            _price = price;
        }
        public async Task<ViewResult> List()
        {
            var result = new DepartmentSettingsViewModel
            {
                Departments = await _department.GetDepartments(),
                PriceGroupsAndDepartments = await _price.GroupsAndDepartments()
            };
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddDepartment([FromBody] ZabotaDepartment model)
        {
            var result = await _department.AddDepartment(model);

            return Json(result);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            await _department.DeleteDepartment(id);

            return Redirect("/admin/DepartmentSettings/" + nameof(List));
        }
    }
}