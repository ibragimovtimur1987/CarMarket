using System.Collections.Generic;

namespace Domain.Entities;

public class CarModel
{
    public CarModel()
    {
        Cars = new List<Car>();
    }

    public int Id { get; set; }
    
    public int BrandId { get; set; }
    
    public string Name { get; set; }

    public virtual CarBrand CarBrand { get; set; }
    
    public virtual ICollection<Car> Cars { get; set; }
}