using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeManagementt.Controllers
{
    public class EmployeeDesignationController : ApiController
    {

        EmployeeManagementEntities entity = new EmployeeManagementEntities();

        //To Get All Designations.
        public IHttpActionResult Get()
        {
            try
            {
                var result = entity.usp_EmployeeDesignation(0, "", "Get");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //To Insert A New Designation.
        public IHttpActionResult Post([FromBody] EmployeeDesignation emp)
        {
            try
            {
                var result = entity.usp_EmployeeDesignation(0, emp.Designation, "Insert");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //To Update A Designation
        public IHttpActionResult Put([FromBody] EmployeeDesignation emp)
        {
            try
            {
                var result = entity.usp_EmployeeDesignation(emp.DesignationID, emp.Designation,"Update");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //To Delete A Designation
        public IHttpActionResult Delete([FromBody] EmployeeDesignation emp)
        {
            try
            {
                var result = entity.usp_EmployeeDesignation(emp.DesignationID, emp.Designation, "Delete");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
