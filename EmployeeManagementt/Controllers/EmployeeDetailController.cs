using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace EmployeeManagementt.Controllers
{
    public class EmployeeDetailController : ApiController
    {
        EmployeeManagementtEntities entity = new EmployeeManagementtEntities();

        //To Get Details of Employees.

        /// <summary>
        /// Get EmployeeDetails
        /// </summary>
        public IHttpActionResult Get()
        {
            var result = entity.usp_EmployeeDetails(0, "", "", "", DateTime.Now, "", "", "", "", "", "", "", "", DateTime.Now, "", "", "", true,0,0, "GET").ToList();
            return Ok(result);

        }

        //To Get Details of a Specific Employee
        public IHttpActionResult GetById(int id)
        {
            var result = entity.usp_EmployeeDetails(id, "", "", "", DateTime.Now, "", "", "", "", "", "", "", "", DateTime.Now, "", "", "", true, 0, 0, "GetEmployee").ToList();
            return Ok(result);
        }

        //To Save Employee Photo
        [Route("api/SaveImage")]
        public string SaveFile()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physcialPath = HttpContext.Current.Server.MapPath("~/Photos/" + filename);
                postedFile.SaveAs(physcialPath);
                return filename;
            }
            catch (Exception)
            {
                return "anonymous.png";
            }
        }

        /// <summary>
        /// Add Employee.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///  {        
        ///   "EmployeeID": 0,
        ///   "Photo": "string",
        ///   "FirstName": "string",
        ///   "LastName": "string",
        ///   "DateofBirth": "2023-03-02 ",
        ///   "Gender": "string",
        ///   "PersonalEmail": "string",
        ///   "OfficialEmail": "string",
        ///   "PhoneNO": "string",
        ///   "EmergencyContactNo": "string",
        ///   "WorkLocation": "string",
        ///   "WorkingState": "string",
        ///    "WorkingCountry": "string",
        ///   "Dateofjoining": "2023-03-02",
        ///   "Designation": "string",
        ///   "Department": "string",
        ///   "ReportingManager": "string",
        ///   "IsActive": true,
        ///}
        /// </remarks>
        //To Insert A Employe Details.
        [HttpPost]
        public IHttpActionResult Post(EmployeeDetail emp)
        {
            //var uploadFile="";
            string createFolder = HttpContext.Current.Server.MapPath("~/EmployeePhotos/");
            if (!Directory.Exists(createFolder))
            {
                Directory.CreateDirectory(createFolder);
            }

            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var uploadFile = HttpContext.Current.Request.Files["Imgsave"];

                if (uploadFile != null)
                {
                    var saveimg = Path.Combine(HttpContext.Current.Server.MapPath("~/EmployeePhotos/"), uploadFile.FileName);
                    uploadFile.SaveAs(saveimg);
                }
            }
            var result = entity.usp_EmployeeDetails(0, emp.Photo, emp.FirstName, emp.LastName, emp.DateofBirth, emp.Gender, emp.PersonalEmail,
                         emp.OfficialEmail, emp.PhoneNO, emp.EmergencyContactNo, emp.WorkLocation, emp.WorkingState, emp.WorkingCountry, emp.Dateofjoining,
                         emp.Designation, emp.Department, emp.ReportingManager, emp.IsActive, emp.EmployeeID, 0, "Insert");

            return Ok(result);
        }

        //To Update A Employee Details.

        public IHttpActionResult Put(EmployeeDetail emp)
        {
            var updateemp = entity.usp_EmployeeDetails(emp.EmployeeID, emp.Photo, emp.FirstName, emp.LastName, emp.DateofBirth, emp.Gender, emp.PersonalEmail,
                           emp.OfficialEmail, emp.PhoneNO, emp.EmergencyContactNo, emp.WorkLocation, emp.WorkingState, emp.WorkingCountry, emp.Dateofjoining,
                           emp.Designation, emp.Department, emp.ReportingManager, emp.IsActive, 0, emp.EmployeeID,"Update");
            return Ok(updateemp);

        }

        //To Delete A Employee Details.
        public IHttpActionResult Delete(int id)
        {
            var result = entity.usp_EmployeeDetails(id, "", "", "", DateTime.Now, "", "", "", "", "", "", "", "", DateTime.Now, "", "", "", true, 0, 0, "Delete");
            return Ok(result);
        }
    }
}
