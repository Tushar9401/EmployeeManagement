using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeManagementt.Controllers
{
    public class EmployeeEducationController : ApiController
    {
        EmployeeManagementtEntities entity = new EmployeeManagementtEntities();

        //To Get Employee's All Education Details
        public IHttpActionResult Get()
        {
            var result = entity.usp_EmployeeEducationDetails(0, 0, "", "", "", DateTime.Now, DateTime.Now, "", 0, 0, 0, "GET");
            return Ok(result);
        }

        // To Get a Employee's Specific Education Details 
        public IHttpActionResult GetById(int id)
        {
            var result = entity.usp_EmployeeEducationDetails(0, id, "", "", "", DateTime.Now, DateTime.Now, "", 0, 0, 0, "GetEmployeeEducation");
            return Ok(result);
        }

        //To Insert a Employee's Education Details.
        public IHttpActionResult Post(EmployeeEducationDetail emp)
        {
            var result = entity.usp_EmployeeEducationDetails(emp.EducationID, emp.EmployeeID, emp.Degree, emp.Institution, emp.State, emp.StartDate, emp.EndDate, emp.DegreeType,
                                                          emp.Percentage, emp.EmployeeID, 0, "Insert");
            return Ok(result);
        }

        //To Update A Employee's Education Details.
        public IHttpActionResult Put(EmployeeEducationDetail emp)
        {
            var result = entity.usp_EmployeeEducationDetails(emp.EducationID, emp.EmployeeID, emp.Degree, emp.Institution, emp.State, emp.StartDate, emp.EndDate, emp.DegreeType,
                                                          emp.Percentage, 0, emp.EmployeeID, "Update");

            return Ok(result);
        }

        //To Delete A Employee's Education Details
        public IHttpActionResult Delete(int id)
        {
            var result = entity.usp_EmployeeEducationDetails(id, 0, "", "", "", DateTime.Now, DateTime.Now, "", 0, 0, 0, "Delete");
            return Ok(result);
        }
    }
}
