using System;
using System.Data.Entity;

namespace StudentDatabaseApp
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }

    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("StudentContextDB")
        {
        }
        public DbSet<Student> Students { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing database...");
            using (var context = new SchoolContext())
            {
                var newStudent = new Student()
                {
                    FirstName = "Alex",
                    LastName = "Smith",
                    EnrollmentDate = DateTime.Now
                };
                context.Students.Add(newStudent);
                context.SaveChanges();
                Console.WriteLine("Successfully added student!");
            }
            Console.ReadKey();
        }
    }
}
