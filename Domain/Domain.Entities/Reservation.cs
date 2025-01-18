using System;

namespace Domain.Entities;

public class Reservation
{
    public int Id { get; init; }
    
    public int CarId { get; set; }
    
    public DateTime StartDateUtc { get; set; }
    
    public DateTime EndDateUtc { get; set; }
    
    public DateTime ReservedAtUtc { get; set; }

    public virtual Car Car { get; set; }
}