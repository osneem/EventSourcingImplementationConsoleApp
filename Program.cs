using EventSourcingImplementation.Core;
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        var events = new List<Event>
        {
            new AddedCart("userId"),
            new AddedItemToCart(1, 2),
            new AddedItemToCart(2, 3),
            new AddedItemToCart(3, 1),
            new RemovedItemFromCart(1, 1),
            new AddedShippingInformationCart("42 Wallaby Way, Sydney", "1234567")
        };

        var orderAggregate = events.Aggregate(new Order(), (order, e) =>
        {
            if (e is AddedCart addedCart)
            {
                order.UserId = addedCart.UserId;
            }
            else if (e is AddedItemToCart addedItemToCart)

            {
                for (int i = 0; i < addedItemToCart.Quantity; i++)
                {
                    order.Products.Add(new Product() { Id = addedItemToCart.ProductId });
                }
            }
            else if (e is RemovedItemFromCart removedItemFromCart)
            {
                for(int i = 0;i < removedItemFromCart.Quantity; i++)
                {
                    var productToRemove = order.Products.FirstOrDefault(x => x.Id == removedItemFromCart.ProductId);
                    order.Products.Remove(productToRemove);
                }
            }
            else if (e is AddedShippingInformationCart addedShippingInformationCart)
            {
                order.Address = addedShippingInformationCart.Address;
                order.PhoneNumber = addedShippingInformationCart.PhoneNumber;
            }
            return order;
        });

        string printedOrder = JsonConvert.SerializeObject(orderAggregate);

        Console.WriteLine(printedOrder);
    }
}