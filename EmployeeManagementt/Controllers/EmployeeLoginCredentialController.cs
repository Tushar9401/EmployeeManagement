using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeManagementt.Controllers
{
    public class EmployeeLoginCredentialController : ApiController
    {
        EmployeeManagementtEntities entity = new EmployeeManagementtEntities();
        //string password=Guid.NewGuid().ToString();

        public IHttpActionResult Insert(int id)
        {
            string password = Guid.NewGuid().ToString();
            var result = entity.usp_EmployeeLoginCredentials(0, id, "", password, id, 0, "Insert");
            return Ok(result);
        }

        public IHttpActionResult Put(EmployeeLoginCredential emp)
        {
            var result = entity.usp_EmployeeLoginCredentials(emp.LoginID, emp.EmployeeID, "", emp.EmployeePassword,0, emp.EmployeeID, "Update");
            return Ok(result);
        }
    }
}
