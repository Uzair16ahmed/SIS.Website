using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Models.Models
{
    public class Courses:BaseEntity
    {
       // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        
        [Display(Name = "Number")]
        public int CourseID { get; set; }

       //// [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Range(0, 5)]
        public int Credits { get; set; }

        public string DepartmentID { get; set; }

        public string Department { get; set; }
    
        
        // public ICollection<Enrollment> Enrollments { get; set; }
       // public ICollection<CourseAssignment> CourseAssignments { get; set; }
    
    }
}
