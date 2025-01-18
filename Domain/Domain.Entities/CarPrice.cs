using System;

namespace Domain.Entities;

public class CarPrice
{
    public int Id { get; set; }
    
    public int CarId { get; set; }
    
    public DateTime StartDateUtc { get; set; }
    
    public DateTime EndDateUtc { get; set; }
    
    public decimal PriceAmount { get; set; }

    public virtual Car Car { get; set; }
}