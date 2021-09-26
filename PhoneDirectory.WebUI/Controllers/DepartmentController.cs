using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhoneDirectory.Domain.Entity;
using PhoneDirectory.Domain.Abstract;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Newtonsoft.Json;

namespace PhoneDirectory.WebUI.Controllers
{
    [ApiController]
    [Route("api/departments")]
    public class DepartmentController : Controller
    {
        private IDepartmentRepository DepartmentRepository;

        public DepartmentController(IDepartmentRepository depRepo)
        {
            DepartmentRepository = depRepo;
        }
        
        [Authorize]
        [HttpGet]
        [Route("getrootdepartments")]
        public IEnumerable<Department> Get()
        {
            return DepartmentRepository.GetRootDepartments().Where(x => x.ParentId == null).ToList();
        }
    }
}
