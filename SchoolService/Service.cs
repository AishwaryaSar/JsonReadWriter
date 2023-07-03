//responsible for recieving requests from
//presentation layer and sending it back
//web service running on web server
using SchoolBusiness;
using System.Runtime.ExceptionServices;

namespace SchoolService
{
    public class Service
    {
        public void Controller(string methodName, string[] vars)
        {
            try
            {
                var business = new Business();
                switch (methodName.ToLower())
                {
                    case "createstudent":
                        string studentName = vars[1];
                        float gpa = (float)Convert.ToDouble(vars[2]);
                        business.AddStudent(studentName, gpa);
                        break;
                    case "createinstructor":
                        string instructorName = vars[1];
                        business.AddInstructor(instructorName);
                        break;
                    case "createcourse":
                        string courseName = vars[1];
                        int creditHours = Convert.ToInt32(vars[2]);
                        business.AddCourse(courseName, creditHours);
                        break;
                    case "addstudenttocourse":
                        Guid studentIdAssigned = new Guid(vars[0]);
                        Guid courseIdRegistered = new Guid(vars[1]);
                        business.AddStudentToCourse(studentIdAssigned, courseIdRegistered);
                        break;
                    case "addinstructortocourse":
                        business.AddInstructorToCourse();
                        break;
                    case "addstudentgrade":
                        Guid studentIdGrade = new Guid(vars[0]);
                        Guid courseIdGrade = new Guid(vars[1]);
                        string courseGrade = vars[2];
                        business.AddGradeToStudent(studentIdGrade, courseIdGrade, courseGrade);
                        break;
                    case "datapersistence":
                        business.PersistBusinessObjects();
                        break;
                    case "loaddatafromjson":
                        business.LoadJSONdata();
                        break;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"This method had a problem : {methodName}"+ex.Message);
            }
        }
    }
}