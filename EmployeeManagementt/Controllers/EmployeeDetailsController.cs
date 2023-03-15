using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeManagementt.Controllers
{
    public class EmployeeDetailsController : ApiController
    {
       EmployeeManagementEntities entity=new EmployeeManagementEntities();

        public IHttpActionResult Get()
        {
            try
            {
                var result = entity.usp_EmployeeDetails(0, "", "", "", DateTime.Now, "", "", "", "", "", "", "", "", DateTime.Now, "", "", "", true, 0, 0,"","GET");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var result = entity.usp_EmployeeDetails(id, "", "", "", DateTime.Now, "", "", "", "", "", "", "", "", DateTime.Now, "", "", "", true, 0, 0,"","GetEmployee");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Post(EmployeeDetail emp)
        {
           try
            {
              var result = entity.usp_EmployeeDetails(0, emp.Photo, emp.FirstName, emp.LastName, emp.DateofBirth, emp.Gender, emp.PersonalEmail, emp.OfficialEmail, emp.PhoneNO,
                                                      emp.EmergencyContactNo, emp.WorkLocation, emp.WorkingState, emp.WorkingCountry, emp.Dateofjoining, emp.Designation,
                                                      emp.Department, emp.ReportingManager, emp.IsActive, emp.CreatedBy, 0,emp.Roles,"Insert");
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Put([FromBody] EmployeeDetail emp)
        {
            try
            {
                var updateemp = entity.usp_EmployeeDetails(emp.EmployeeID, emp.Photo, emp.FirstName, emp.LastName, emp.DateofBirth, emp.Gender, emp.PersonalEmail,
                               emp.OfficialEmail, emp.PhoneNO, emp.EmergencyContactNo, emp.WorkLocation, emp.WorkingState, emp.WorkingCountry, emp.Dateofjoining,
                               emp.Designation, emp.Department, emp.ReportingManager, emp.IsActive, 0, emp.EmployeeID,emp.Roles,"Update");
                return Ok(updateemp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var result = entity.usp_EmployeeDetails(id, "", "", "", DateTime.Now, "", "", "", "", "", "", "", "", DateTime.Now, "", "", "", true, 0, 0,"", "Delete");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
