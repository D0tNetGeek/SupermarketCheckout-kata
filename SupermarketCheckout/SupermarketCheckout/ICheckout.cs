namespace SupermarketCheckout
{
    public interface ICheckout
    {
        void Scan(char item);

        decimal CalculateTotal();
    }
}