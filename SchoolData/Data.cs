//data layer
using Newtonsoft.Json;
using SchoolDomain;

namespace SchoolData
{
    public class Data
    {
        static School school = null;
        static Data() { 
            school = new School();
            school.Students = new List<Student>();
            school.Instructors = new List<Instructor>();
            school.Courses = new List<Course>();
            school.studentCourses = new List<StudentCourse>();
        }
        public void CreateStudent(Student student)
        {
            student.Id = Guid.NewGuid();
            school.Students.Add(student);
            Console.WriteLine("1");
        }
        public void CreateInstructor(Instructor instructor)
        {
            instructor.Id = Guid.NewGuid();
            school.Instructors.Add(instructor);
            Console.WriteLine("2");
        }
        public void SaveCourse(Course course)
        {
            if (course.isDirty)
            {
                for(int i = 0;i<school.Courses.Count;i++)
                {
                    if (school.Courses[i].Id == course.Id)
                    {
                        course.isDirty = false;
                        school.Courses[i] = course;
                        Console.WriteLine("4");
                        return;
                    }
                }
            }
            course.Id = Guid.NewGuid();
            school.Courses.Add(course);
            Console.WriteLine("3");
        }
        public void SaveStudentCourse(StudentCourse studentcourse)
        {
            if(studentcourse.isDirty)
            {
                for(int i = 0;i<school.studentCourses.Count;i++)
                {
                    if (school.studentCourses[i].student.Id == studentcourse.student.Id &&
                        school.studentCourses[i].course.Id == studentcourse.course.Id)
                    {
                        studentcourse.isDirty = false;
                        school.studentCourses[i] = studentcourse;
                        Console.WriteLine("student course modified");
                        return;
                    }
                }
            }
            school.studentCourses.Add(studentcourse);
            Console.WriteLine(studentcourse.student);
        }
        public Student GetStudentById(Guid id)
        {
            foreach(var student in school.Students)
            {
                if(student.Id == id) return student;
            }
            return null;
        }
        public Instructor GetInstructorById(Guid id)
        {
            foreach(var instructor in school.Instructors)
            {
                if (instructor.Id == id) { return instructor; }
            }
            return null;
        }
        public Course GetCourseById(Guid id)
        {
            foreach(var  course in school.Courses)
            {
                if(course.Id == id) return course;
            }
            return null;
        }
        public StudentCourse GetStudentCourseById(Guid studentid, Guid courseid)
        {
            foreach (var studentcourse in school.studentCourses)
            {
                if (studentcourse.student.Id == studentid && 
                    studentcourse.course.Id == courseid) return studentcourse;
            }
            return null;
        }
        public List<Course> GetCourses()
        {
            return school.Courses;
        }
        public List<Instructor> GetInstructors()
        {
            return school.Instructors;
        }
        public void PersistDataStore()
        {
            var jsonObj = JsonConvert.SerializeObject(school);
            using (var writer = new StreamWriter(@"C:\Users\AISHWARYA\source\repos\Univeristy database\Output Files\schooldata.txt"))
            {
                writer.WriteLine(jsonObj);
            }
        }
        public void LoadData()
        {
            string jsonObj = string.Empty;
            using(var writer = new StreamReader(@"C:\Users\AISHWARYA\source\repos\Univeristy database\Output Files\schooldata.txt"))
            {
                jsonObj = writer.ReadLine();
            }
            school = (School)JsonConvert.DeserializeObject(jsonObj, typeof(School));
            Console.WriteLine(school.Students.Count);
        }
    }
}