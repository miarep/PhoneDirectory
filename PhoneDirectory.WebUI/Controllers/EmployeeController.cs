using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhoneDirectory.Domain.Entity;
using PhoneDirectory.Domain.Abstract;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace PhoneDirectory.WebUI.Controllers
{
    [ApiController]
    [Route("api/employee")]
    public class EmployeeController : Controller
    {
        private string EmpId => User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value;

        private IEmployeeRepository EmployeeRepository;

        public EmployeeController(IEmployeeRepository empRepo)
        {
            EmployeeRepository = empRepo;
        }
        
        /// <summary>
        /// Возвращает сотрудника по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор сотрудника</param>
        /// <returns>Сотрудник</returns>
        [Authorize]
        [HttpGet]
        [Route("getbyid")]
        public Employee Get(int id)
        {
            var result = EmployeeRepository.Get(id);
            return result;
        }

        /// <summary>
        /// Возвращает объект аутентифицированного сотрудника
        /// </summary>
        /// <returns>Сотрудник</returns>
        [Authorize]
        [HttpGet]
        [Route("getauthorizeemployee")]
        public Employee GetAuthorizeEmployee()
        {
            int employeeId;

            if(int.TryParse(EmpId, out employeeId))
            {
                var result = EmployeeRepository.Get(employeeId);
                return result;
            }

            return null;
        }
    }
}
