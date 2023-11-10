using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTuto.Dtos.Get;

public class CustomerDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string IdentiNumber { get; set; } = null!;
    public DateOnly RegisterDate { get; set; }
}
