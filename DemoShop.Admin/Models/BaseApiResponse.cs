namespace DemoShop.Admin.Models;

public class BaseApiResponse
{
    public BaseApiResponse()
    {
        
    }
    public BaseApiResponse(object body)
    {
        Body = body;
        IsSuccess = true;
    }

    public bool IsSuccess { get; set; }
    public object Body { get; set; }
}