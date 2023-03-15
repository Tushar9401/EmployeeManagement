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
        EmployeeManagementEntities entity = new EmployeeManagementEntities();
        //string password=Guid.NewGuid().ToString();

        [Route("api/Insert")]
        public IHttpActionResult Insert(int id)
        {
            try
            {
                string password = Guid.NewGuid().ToString();
                var result = entity.usp_EmployeeLoginCredentials(0, id, "", password, id, 0,"", "Insert");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Put([FromBody] EmployeeLoginCredential emp)
        {
            try
            {
                var result = entity.usp_EmployeeLoginCredentials(0, emp.EmployeeID, "", emp.EmployeePassword, 0, emp.EmployeeID,"", "Update");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/Validation")]
        public IHttpActionResult Validate([FromBody] EmployeeLoginCredential emp)
        {

            try
            {
                var result = entity.usp_EmployeeLoginCredentials(0, 0, emp.EmployeeEmail, emp.EmployeePassword, 0, 0,"", "Validate");

                EmployeeLoginCredential loginCredential = new EmployeeLoginCredential()
                {
                    EmployeeEmail=emp.EmployeeEmail,
                    EmployeePassword = emp.EmployeePassword,
                    Role=emp.Role

                };
                var token = JwtToken.JwtToken.GenerateJwtToken(loginCredential);
                return Ok(token);
           
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
