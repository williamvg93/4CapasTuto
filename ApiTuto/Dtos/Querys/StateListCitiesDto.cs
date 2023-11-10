using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTuto.Dtos.Get;

namespace ApiTuto.Dtos.Querys;

public class StateListCitiesDto
{
    public string Name { get; set; }
    public List<CityDto> Cities { get; set; }
}
