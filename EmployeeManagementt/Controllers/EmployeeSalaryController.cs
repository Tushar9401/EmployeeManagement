using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeManagementt.Controllers
{
    public class EmployeeSalaryController : ApiController
    {
        EmployeeManagementtEntities entity = new EmployeeManagementtEntities();

        //To Get Employee's Salary.
        public IHttpActionResult Get()
        {
            var result = entity.usp_EmployeeSalaryStructure(0, 0, 0, 0, 0, 0, 0, 0, 0,0,0, "GET");
            return Ok(result);
        }

        //To Get Specific Employee's Salary.
        public IHttpActionResult GetById(int id)
        {
            var result = entity.usp_EmployeeSalaryStructure(0, id, 0, 0, 0, 0, 0, 0, 0,0,0, "GetEmployeeSalary");
            return Ok(result);
        }

        //To Insert Employee's Salary.
        public IHttpActionResult Post(EmployeeSalaryStructure emp)
        {
            var result = entity.usp_EmployeeSalaryStructure(emp.EmployeeSalaryID, emp.EmployeeID, emp.BasicSalary, emp.HRA, emp.DA, emp.TA, emp.OtherAllowances, emp.Deductions, emp.NetSalary, emp.EmployeeID,0, "Insert"); ;
            return Ok(result);
        }
        //To Update A Employee's Salary.
        public IHttpActionResult Put(EmployeeSalaryStructure emp)
        {
            var result = entity.usp_EmployeeSalaryStructure(emp.EmployeeSalaryID, emp.EmployeeID, emp.BasicSalary, emp.HRA, emp.DA, emp.TA, emp.OtherAllowances, emp.Deductions, emp.NetSalary,0, emp.EmployeeID, "Update");
            return Ok(result);
        }
        //To Delete A Employee's Salary.
        public IHttpActionResult Delete(int id)
        {
            var result = entity.usp_EmployeeSalaryStructure(0, id, 0, 0, 0, 0, 0, 0, 0,0,0, "Delete");
            return Ok(result);
        }
    }
}
