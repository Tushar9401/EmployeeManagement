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
        EmployeeManagementEntities entity = new EmployeeManagementEntities();

        //To Get Employee's All Education Details
        public IHttpActionResult Get()
        {
            try
            {
                var result = entity.usp_EmployeeEducationDetails(0, 0, "", "", "", DateTime.Now, DateTime.Now, "", 0, 0, 0, "GET");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // To Get a Employee's Specific Education Details 
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var result = entity.usp_EmployeeEducationDetails(0, id, "", "", "", DateTime.Now, DateTime.Now, "", 0, 0, 0, "GetEmployeeEducation");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //To Insert a Employee's Education Details.
        public IHttpActionResult Post([FromBody] EmployeeEducationDetail emp)
        {
            try
            {
                var result = entity.usp_EmployeeEducationDetails(emp.EducationID, emp.EmployeeID, emp.Degree, emp.Institution, emp.State, emp.StartDate, emp.EndDate, emp.DegreeType,
                                                              emp.Percentage, emp.EmployeeID, 0, "Insert");
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //To Update A Employee's Education Details.
        public IHttpActionResult Put([FromBody] EmployeeEducationDetail emp)
        {
            try
            {
                var result = entity.usp_EmployeeEducationDetails(emp.EducationID, emp.EmployeeID, emp.Degree, emp.Institution, emp.State, emp.StartDate, emp.EndDate, emp.DegreeType,
                                                              emp.Percentage, 0, emp.EmployeeID, "Update");

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //To Delete A Employee's Education Details
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var result = entity.usp_EmployeeEducationDetails(id, 0, "", "", "", DateTime.Now, DateTime.Now, "", 0, 0, 0, "Delete");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
