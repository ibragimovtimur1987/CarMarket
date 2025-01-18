namespace Domain.Entities;

public class CarModel
{
    public int Id { get; set; }
    
    public int BrandId { get; set; }
    
    public string Name { get; set; }

    public virtual Brand Brand { get; set; }
}