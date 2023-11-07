using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Persontype
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
