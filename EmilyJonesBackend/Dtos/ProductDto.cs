namespace EmilyJonesBackend.Dtos
{
    public record class ProductDto(int id, 
        string Name,  
        string Description, 
        string Category, 
        decimal Price, 
        string ImageUrl);
    
}
