using System;
using System.Collections.Generic;

namespace PRN222_SP25_B5_SL1.Models_DB;

public partial class Department
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<Student>? Students { get; set; } = new List<Student>();
}
