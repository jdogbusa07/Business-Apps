using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    private int studentID;
    private string studentName;

    public static List<Student> studentList = new List<Student>();

    public Student(int id, string name)
    {
        this.studentID = id;
        this.studentName = name;
        studentList.Add(this);
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Student ID: {studentID}, Name: {studentName}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Student s1 = new Student(111, "Alice");
        Student s2 = new Student(222, "Bob");
        Student s3 = new Student(333, "Cathy");
        Student s4 = new Student(444, "David");

        Dictionary<string, double> gradebook = new Dictionary<string, double>()
        {
            { "Alice", 4.0 },
            { "Bob", 3.6 },
            { "Cathy", 2.5 },
            { "David", 1.8 }
        };

        if (!gradebook.ContainsKey("Tom"))
        {
            gradebook.Add("Tom", 3.3);
        }

        double totalGPA = gradebook.Values.Sum();
        double averageGPA = totalGPA / gradebook.Count;

        Console.WriteLine($"Average GPA: {averageGPA:F2}");

        Console.WriteLine("Students with GPA greater than average:");
        foreach (var student in Student.studentList)
        {
            if (gradebook.ContainsKey(student.studentName) && gradebook[student.studentName] > averageGPA)
            {
                Console.WriteLine($"Student ID: {student.studentID}, Name: {student.studentName}");
            }
        }
    }
}
