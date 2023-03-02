using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeManagementt.Controllers
{
    public class EmployeeAddressController : ApiController
    {
        EmployeeManagementtEntities entity = new EmployeeManagementtEntities();

        //To Get Employee's Address.
        public IHttpActionResult Get()
        {
            var result = entity.usp_EmployeeAddress(0, 0, "", "", "", "", "", "", false, false,0,0,"GET");
            return Ok(result);
        }

        //To Get Specific Employee's Address
        public IHttpActionResult GetById(int id)
        {
            var result = entity.usp_EmployeeAddress(0, id, "", "", "", "", "", "", false, false,0,0, "GetEmployeeAddress");
            return Ok(result);
        }

        //To Insert Employee Address.
        public IHttpActionResult Post(EmployeeAddress emp)
        {
            var result = entity.usp_EmployeeAddress(emp.AddressID, emp.EmployeeID, emp.AddressLine1, emp.AddressLine2, emp.PostalCode, emp.City, emp.State, emp.Country, emp.IsCurrent, emp.IsPermanent, emp.EmployeeID,0, "Insert");
            return Ok(result);
        }

        //To Update Employee's Address
        public IHttpActionResult Put(EmployeeAddress emp)
        {
            var result = entity.usp_EmployeeAddress(emp.AddressID, emp.EmployeeID, emp.AddressLine1, emp.AddressLine2, emp.PostalCode, emp.City, emp.State, emp.Country, emp.IsCurrent, emp.IsPermanent, 0, emp.EmployeeID, "Update");
            return Ok(result);
        }

        //To Delete a Employee's Address.
        public IHttpActionResult Delete(EmployeeAddress emp)
        {
            var result = entity.usp_EmployeeAddress(0, emp.EmployeeID, "", "", "", "", "", "", emp.IsCurrent, emp.IsPermanent,0,0, "Delete");
            return Ok(result);
        }

    }
}
