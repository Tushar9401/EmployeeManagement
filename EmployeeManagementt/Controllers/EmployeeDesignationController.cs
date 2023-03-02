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

        EmployeeManagementtEntities entity = new EmployeeManagementtEntities();

        //To Get All Designations.
        public IHttpActionResult Get()
        {
            var result = entity.usp_EmployeeDesignation(0, "",0,0, "Get");
            return Ok(result);
        }

        //To Insert A New Designation.
        public IHttpActionResult Post(EmployeeDesignation emp)
        {
            var result = entity.usp_EmployeeDesignation(emp.DesignationID, emp.Designation,0,0,"Insert");
            return Ok(result);
        }

        //To Update A Designation
        public IHttpActionResult Put(EmployeeDesignation emp)
        {
            var result = entity.usp_EmployeeDesignation(emp.DesignationID, emp.Designation,0,0,"Update");
            return Ok(result);
        }

        //To Delete A Designation
        public IHttpActionResult Delete(EmployeeDesignation emp)
        {
            var result = entity.usp_EmployeeDesignation(emp.DesignationID, emp.Designation, 0, 0, "Delete");
            return Ok(result);
        }
    }
}
