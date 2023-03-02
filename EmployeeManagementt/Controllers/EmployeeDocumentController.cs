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
        EmployeeManagementtEntities entity = new EmployeeManagementtEntities();

        public IHttpActionResult Get()
        {
            var result = entity.usp_EmployeeDocument(0, "", "", 0, 0, "Get");
            return Ok(result);
        }

        public IHttpActionResult Post(EmployeeDocument emp)
        {
            var result = entity.usp_EmployeeDocument(emp.EmployeeID, emp.DocumentImage, emp.DocumentName, emp.EmployeeID,0, "Insert");
            return Ok(result);
        }

        public IHttpActionResult Put(EmployeeDocument emp)
        {
            var result = entity.usp_EmployeeDocument(emp.EmployeeID, emp.DocumentImage, emp.DocumentName, 0, emp.EmployeeID, "Update");
            return Ok(result);
        }

        public IHttpActionResult Delete(EmployeeDocument emp)
        {
            var result = entity.usp_EmployeeDocument(emp.EmployeeID, "", emp.DocumentName, 0, 0, "Delete");
            return Ok(result);
        }
    }
}
