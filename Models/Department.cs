using System;

namespace MVC_Assignment.Models;

public class Department
{

    public int Id { get; set; }

    public string Name { get; set; }

    public ICollection<Student> Students { get; set; }
}
