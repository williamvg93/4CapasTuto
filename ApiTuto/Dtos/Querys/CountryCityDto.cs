using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTuto.Dtos.Querys;

public class CountryCityDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<StateCitiesDto> States { get; set; }
}
