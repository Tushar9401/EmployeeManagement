//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeManagementt
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmployeeEducationDetail
    {
        public int EducationID { get; set; }
        public int EmployeeID { get; set; }
        public string Degree { get; set; }
        public string Institution { get; set; }
        public string State { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public string DegreeType { get; set; }
        public decimal Percentage { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
    
        public virtual EmployeeDetail EmployeeDetail { get; set; }
    }
}
