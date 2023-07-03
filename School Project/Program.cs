using SchoolDomain;
using SchoolService;
using System;
namespace SchoolProject
{
    class Program
    {
       
        static void Main(string[] args)
        {
            string studentFilePath = @"C:\Users\AISHWARYA\Downloads\Student database - Sheet1.csv";
            string instructorFilePath = @"C:\Users\AISHWARYA\Downloads\Teacher database.csv";
            string courseFilepath = @"C:\Users\AISHWARYA\Downloads\course database - Sheet1.csv";
            manipulateData(studentFilePath, "student");
            manipulateData(instructorFilePath, "instructor");
            manipulateData(courseFilepath, "course");
            manipulateData("", "courseinstructor");
            manipulateData("", "datapersistence");
            manipulateData("", "loaddatafromjson");
            //printClassData();
            

        }
        static void manipulateData(string filePath,string classType)
        {
            var service = new Service();
            switch(classType)
            {
                case "student":
                    using (StreamReader reader = new StreamReader(filePath)) {
                        reader.ReadLine();
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            string[] data = line.Split(',');
                            service.Controller("CreateStudent", new string[] { data[0], data[1], data[2] });
                        }
                    }
                    break;
                case "instructor":
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        reader.ReadLine();
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            string[] data = line.Split(',');
                            service.Controller("CreateInstructor", new string[] { data[0], data[1] });
                        }

                    }
                    break;
                case "course":
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        reader.ReadLine();
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            string[] data = line.Split(',');
                            service.Controller("CreateCourse", new string[] { data[0], data[1], data[2] });
                        }

                    }
                    break;
                case "courseinstructor":
                    service.Controller("AddInstructorToCourse",new string[] { });
                    break;
                case "datapersistence":
                    service.Controller("DataPersistence", new string[] { });
                    break;
                case "loaddatafromjson":
                    service.Controller("LoadDataFromjson", new string[] { });
                    break;
            }

        }
        /**static void printClassData()
        {
            List<Student> students = School.Students;
            List<Instructor> instructors = Instructor.Instructors;
            List<Course> courses = Course.Courses;
            //print student data
            Console.WriteLine("Student List");
            Console.WriteLine("***************************");
            Console.WriteLine("Student ID    Student Name   GPA");

            foreach (Student student in students)
            {
                Console.WriteLine($"{student.Id}    {student.Name}    {student.Gpa}");
            }
            //print instructor data
            Console.WriteLine("Instructor List");
            Console.WriteLine("***************************");
            Console.WriteLine("Instructor ID    Instructor Name");
            foreach (Instructor instructor in instructors)
            {
                Console.WriteLine($"{instructor.Id}    {instructor.Name}");
            }
            //print course data
            Console.WriteLine("Course List");
            Console.WriteLine("***************************");
            Console.WriteLine("Course ID    Course Name    Credit hours    Instructor");
            foreach (Course course in courses)
            {
                Console.WriteLine($"{course.Id}    {course.CourseName}    {course.CreditHours}    {course.CourseInstructor.Name}");
            }
        }**/
    }
}