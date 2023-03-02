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
        EmployeeManagementtEntities entity = new EmployeeManagementtEntities();

        public IHttpActionResult Get()
        {
            var result = entity.usp_EmployeeDocumentMaster(0, "", 0, 0, "Get");
            return Ok(result);
        }

        public IHttpActionResult Post(EmployeeDocumentMaster emp)
        {
            var result = entity.usp_EmployeeDocumentMaster(emp.DocumentID, emp.DocumentName, 0, 0, "Insert");
            return Ok(result);
        }
        public IHttpActionResult Put(EmployeeDocumentMaster emp)
        {
            var result = entity.usp_EmployeeDocumentMaster(emp.DocumentID, emp.DocumentName, 0, 0, "Update");
            return Ok(result);
        }

        public IHttpActionResult Delete(EmployeeDocumentMaster emp)
        {
            var result = entity.usp_EmployeeDocumentMaster(0, emp.DocumentName, 0, 0, "Delete");
            return Ok(result);
        }
    }
}
