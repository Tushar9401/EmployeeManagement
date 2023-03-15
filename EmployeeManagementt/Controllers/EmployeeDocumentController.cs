using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeManagementt.Controllers
{
    public class EmployeeDocumentController : ApiController
    {
        EmployeeManagementEntities entity = new EmployeeManagementEntities();

        public IHttpActionResult Get()
        {
            try
            {
                var result = entity.usp_EmployeeDocument(0, "", "", 0, 0, "Get");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Post([FromBody] EmployeeDocument emp)
        {
            try
            {
                var result = entity.usp_EmployeeDocument(emp.EmployeeID, emp.DocumentImage, emp.DocumentName, emp.EmployeeID, 0, "Insert");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Put([FromBody] EmployeeDocument emp)
        {
            try
            {
                var result = entity.usp_EmployeeDocument(emp.EmployeeID, emp.DocumentImage, emp.DocumentName, 0, emp.EmployeeID, "Update");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Delete([FromBody] EmployeeDocument emp)
        {
            try
            {
                var result = entity.usp_EmployeeDocument(emp.EmployeeID, "", emp.DocumentName, 0, 0, "Delete");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
