using System.Collections.Generic;

namespace Domain.Entities;

public class Car
{
    public Car()
    {
        Reservations = new List<Reservation>();
    }
    
    public int Id { get; set; }
    
    public int ModelId { get; set; }
    
    public string Vin { get; set; }

    public CarModel Model { get; set; }
    
    public virtual List<Reservation> Reservations { get; set; }
}
