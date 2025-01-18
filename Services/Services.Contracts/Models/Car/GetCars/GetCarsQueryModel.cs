using System;

namespace Services.Contracts.Models.Car.GetCars;

public class GetCarsQueryModel
{
    public DateTime SelectedDateUtc { get; set; }
}