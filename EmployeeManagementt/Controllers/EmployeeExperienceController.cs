using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeManagementt.Controllers
{
    public class EmployeeExperienceController : ApiController
    {
        EmployeeManagementEntities entity = new EmployeeManagementEntities();

        //To Get Employee's all Experience Details.
        [Route("GetExperience")]
        public IHttpActionResult Get()
        {
            try
            {
                var result = entity.usp_EmployeeExperience(0, 0, "", "", DateTime.Now, DateTime.Now, 0, 0, "GET");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // To Get Employee's Specific Experience Details.
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var result = entity.usp_EmployeeExperience(0, id, "", "", DateTime.Now, DateTime.Now, 0, 0, "GetEmployee");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //To Insert Employee's Experience Details
        public IHttpActionResult Post([FromBody] EmployeeExperience emp)
        {
            try
            {
                var result = entity.usp_EmployeeExperience(emp.ExperienceID, emp.EmployeeID, emp.CompanyName, emp.JobTitle, emp.StartDate, emp.EndDate, emp.EmployeeID, 0, "Insert");
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //To Update Employee's Experience Details.
        public IHttpActionResult Put([FromBody] EmployeeExperience emp)
        {
            try
            {
                var result = entity.usp_EmployeeExperience(emp.ExperienceID, emp.EmployeeID, emp.CompanyName, emp.JobTitle, emp.StartDate, emp.EndDate, 0, emp.EmployeeID, "Update");
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //To Delete Employee's Experience Details
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var result = entity.usp_EmployeeExperience(id, 0, "", "", DateTime.Now, DateTime.Now, 0, 0, "Delete");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
