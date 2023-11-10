using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTuto.Dtos.Post;

public class CustomerPDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string IdentiNumber { get; set; } = null!;
    public DateOnly RegisterDate { get; set; }
    public int IdPersonTypeFk { get; set; }
    public int IdCityFk { get; set; }
}
