namespace EventSourcingImplementation.Core;

public record Event
{
    public int Id { get; set; }
    public string Name => GetType().Name;
}

public record AddedCart(string UserId): Event;
public record AddedItemToCart(int ProductId, int Quantity): Event;
public record AddedShippingInformationCart(string Address, string PhoneNumber): Event;