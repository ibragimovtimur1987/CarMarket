using System.Collections.Generic;

namespace Domain.Entities;

public class Car
{
    public Car()
    {
        Reservations = new List<CarReservation>();
        CarPrices = new List<CarPrice>();
    }
    
    public int Id { get; set; }
    
    public int ModelId { get; set; }
    
    public string Vin { get; set; }

    public virtual CarModel Model { get; set; }
    
    public virtual ICollection<CarReservation> Reservations { get; set; }
    
    public virtual ICollection<CarPrice> CarPrices { get; set; }
}
