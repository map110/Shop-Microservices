namespace Microsoft.EntityFrameworkCore.Internal;

public class AddProductEvent : IntegrationBaseEvent
{
    public int ProductId { get; set; }
    public string ProductTitle { get; set; }
}