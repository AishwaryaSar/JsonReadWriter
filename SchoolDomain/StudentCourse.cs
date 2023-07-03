using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDomain
{
    public class StudentCourse
    {
        public Student student { get; set; }
        public Course course { get; set; }
        public string grade { get; set; }  
        public bool isDirty { get; set; }=false;
    }
}
