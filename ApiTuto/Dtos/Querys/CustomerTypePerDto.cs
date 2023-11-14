using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTuto.Dtos.Get;

namespace ApiTuto.Dtos.Querys;

public class CustomerTypePerDto
{
    public string Name { get; set; } = null!;

    public string IdentiNumber { get; set; } = null!;

    public DateOnly RegisterDate { get; set; }

    public string PersonType { get; set; }
}
