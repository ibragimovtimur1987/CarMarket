namespace Services.Contracts.Models.Car.Search;

public class SearchCarsResultModel
{
    public int CarId { get; set; }
    
    public string Brand { get; set; }
    
    public string Model { get; set; }
    
    public decimal Price { get; set; }
}