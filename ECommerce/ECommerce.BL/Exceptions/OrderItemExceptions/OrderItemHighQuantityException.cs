namespace ECommerce.BL.Exceptions;

public class OrderItemHighQuantityException : Exception
{
    public OrderItemHighQuantityException(string message) : base(message) { }

    public OrderItemHighQuantityException() : base("The number of products is less than the quantity in the order") { }
}
