using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTuto.Dtos.Post;

public class CityPDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int IdStateFk { get; set; }
}
