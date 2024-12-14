namespace TestApp;

public class ImageDTO
{
    public bool IsMain { get; set; } = false;
    public int ProductId { get; set; }
    //Image file
    public IFormFile ImageFile { get; set; }
}