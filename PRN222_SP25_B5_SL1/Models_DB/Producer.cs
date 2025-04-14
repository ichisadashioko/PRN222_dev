using System;
using System.Collections.Generic;

namespace PRN222_SP25_B5_SL1.Models_DB;

public partial class Producer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
