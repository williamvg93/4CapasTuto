using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Customer : BaseEntity
{
    public string Name { get; set; } = null!;

    public string IdentiNumber { get; set; } = null!;

    public DateOnly RegisterDate { get; set; }

    public int IdPersonTypeFk { get; set; }

    public int IdCityFk { get; set; }

    public virtual City IdCityFkNavigation { get; set; } = null!;

    public virtual Persontype IdPersonTypeFkNavigation { get; set; } = null!;
}
