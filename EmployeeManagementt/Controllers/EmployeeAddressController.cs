using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeManagementt.Controllers
{
    public class EmployeeAddressController : ApiController
    {
        EmployeeManagementEntities entity = new EmployeeManagementEntities();

        //To Get Employee's Address.
        public IHttpActionResult Get()
        {
            try
            {
                var result = entity.usp_EmployeeAddress(0, 0, "", "", "", "", "", "", false, false, 0, 0, "GET");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //To Get Specific Employee's Address
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var result = entity.usp_EmployeeAddress(0, id, "", "", "", "", "", "", false, false, 0, 0, "GetEmployeeAddress");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //To Insert Employee Address.
        public IHttpActionResult Post([FromBody] EmployeeAddress emp)
        {
            try
            {
                var result = entity.usp_EmployeeAddress(0,emp.EmployeeID, emp.AddressLine1, emp.AddressLine2, emp.PostalCode, emp.City, emp.State, emp.Country, emp.IsCurrent, emp.IsPermanent, emp.EmployeeID, 0, "Insert");
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //To Update Employee's Address
        public IHttpActionResult Put([FromBody] EmployeeAddress emp)
        {
            try
            {
                var result = entity.usp_EmployeeAddress(emp.AddressID, emp.EmployeeID, emp.AddressLine1, emp.AddressLine2, emp.PostalCode, emp.City, emp.State, emp.Country, emp.IsCurrent, emp.IsPermanent, 0, emp.EmployeeID, "Update");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //To Delete a Employee's Address.
        public IHttpActionResult Delete([FromBody] EmployeeAddress emp)
        {
            try
            {
                var result = entity.usp_EmployeeAddress(emp.AddressID,emp.EmployeeID,"", "", "", "", "", "",false,false,0, 0, "Delete");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
