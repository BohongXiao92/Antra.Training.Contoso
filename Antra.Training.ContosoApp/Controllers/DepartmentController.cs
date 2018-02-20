using Antra.Training.Contoso.Data;
using Antra.Training.Contoso.Data.Repositories;
using Antra.Training.Contoso.Model;
using Antra.Training.Contoso.Service;
using System.Web.Mvc;

namespace Antra.Training.ContosoApp.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        private IDepartmentService _departmentService;

        public DepartmentController()
        {
            _departmentService = new DepartmentService(new DepartmentRepository(new ContosoDbContext()));
        }
        public ActionResult Index()
        {
            var depts = _departmentService.GetAllDepartments();
            return View(depts);
        }
    }
}