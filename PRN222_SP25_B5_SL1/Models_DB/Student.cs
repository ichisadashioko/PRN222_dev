using System;
using System.Collections.Generic;

namespace PRN222_SP25_B5_SL1.Models_DB;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool Gender { get; set; }

    public string DepartId { get; set; } = null!;

    public DateOnly? Dob { get; set; }

    public double Gpa { get; set; }
    public string new_Dob
    {
        get
        {
            if (Dob == null)
            {
                return "";
            }

            return Dob.Value.ToString("dd-MM-yyyy");
        }
    }
    public virtual Department Depart { get; set; } = null!;
}
