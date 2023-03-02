using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeManagementt.Controllers
{
    public class EmployeeDepartmentController : ApiController
    {
        EmployeeManagementtEntities entity = new EmployeeManagementtEntities();

        //To Get All The Departments.
        public IHttpActionResult Get()
        {
            var result = entity.sp_EmployeeDepartment(0, "",0,0, "GET");
            return Ok(result);
        }

        //To Insert A New Department
        public IHttpActionResult Post(EmployeeDepartment emp)
        {
            var result = entity.usp_EmployeeDepartment(emp.DepartmentID, emp.Department,0, 0, "Insert");
            return Ok(result);
        }
        //To Update A Department.
        public IHttpActionResult Put(EmployeeDepartment emp)
        {
            var result = entity.usp_EmployeeDepartment(emp.DepartmentID, emp.Department, 0, 0, "Update");
            return Ok(result);
        }

        //To Delete A Department.
        public IHttpActionResult Delete(EmployeeDepartment emp)
        {
            var result = entity.usp_EmployeeDepartment(0, emp.Department, 0, 0, "DELETE");
            return Ok(result);
        }
    }
}
