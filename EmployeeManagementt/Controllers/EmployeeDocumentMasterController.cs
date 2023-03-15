using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeManagementt.Controllers
{
    public class EmployeeDocumentMasterController : ApiController
    {
        EmployeeManagementEntities entity = new EmployeeManagementEntities();

        public IHttpActionResult Get()
        {
            try
            {
                var result = entity.usp_EmployeeDocumentMaster(0, "", 0, 0, "Get");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        public IHttpActionResult Post([FromBody] EmployeeDocumentMaster emp)
        {
            try
            {
                var result = entity.usp_EmployeeDocumentMaster(0, emp.DocumentName, 0, 0, "Insert");
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public IHttpActionResult Put([FromBody] EmployeeDocumentMaster emp)
        {
            try
            {
                var result = entity.usp_EmployeeDocumentMaster(emp.DocumentID, emp.DocumentName, 0, 0, "Update");
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        public IHttpActionResult Delete([FromBody] EmployeeDocumentMaster emp)
        {
            try
            {
                var result = entity.usp_EmployeeDocumentMaster(0, emp.DocumentName, 0, 0, "Delete");
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
