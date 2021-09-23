using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhoneDirectory.Domain.Entity;
using PhoneDirectory.Domain.Abstract;

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
        
        public IEnumerable<Department> Get()
        {
            var result = DepartmentRepository.GetAll().ToList();
           
            return result;
        }
    }
}
