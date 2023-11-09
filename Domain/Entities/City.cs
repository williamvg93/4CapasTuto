using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class City : BaseEntity
{
    public string Name { get; set; } = null!;

    public int IdStateFk { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual State IdStateFkNavigation { get; set; } = null!;
}
