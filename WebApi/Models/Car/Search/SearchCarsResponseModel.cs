namespace WebApi.Models.Car.Search;

public class SearchCarsResponseModel
{
    public int CarId { get; set; }
    
    public decimal Price { get; set; }
    
    public string Brand { get; set; }
    
    public string Model { get; set; }
}