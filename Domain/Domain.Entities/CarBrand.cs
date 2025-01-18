using System.Collections.Generic;

namespace Domain.Entities;

public class CarBrand
{
    public CarBrand()
    {
        CarModels = new List<CarModel>();
    }
    
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public virtual ICollection<CarModel> CarModels { get; set; }
}