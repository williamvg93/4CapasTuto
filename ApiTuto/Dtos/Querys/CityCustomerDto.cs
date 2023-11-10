using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTuto.Dtos.Post;

namespace ApiTuto.Dtos.Querys;

public class CityCustomerDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<CustomerPDto> Customers { get; set; }
}
