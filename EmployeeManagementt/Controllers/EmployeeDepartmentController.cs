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
        EmployeeManagementEntities entity = new EmployeeManagementEntities();

       
        //To Get All The Departments.
        public IHttpActionResult Get()
        {
            try
            {
                var result = entity.usp_EmployeeDepartment(0, "",  "GET");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        //To Insert A New Department
        public IHttpActionResult Post([FromBody] EmployeeDepartment emp)
        {
            try
            {
                var result = entity.usp_EmployeeDepartment(0,emp.Department, "Insert");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //To Update A Department.
        public IHttpActionResult Put([FromBody] EmployeeDepartment emp)
        {
            try
            {
                var result = entity.usp_EmployeeDepartment(emp.DepartmentID, emp.Department, "Update");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //To Delete A Department.
        public IHttpActionResult Delete([FromBody] EmployeeDepartment emp)
        {
            try
            {
                var result = entity.usp_EmployeeDepartment(0, emp.Department,"DELETE");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
