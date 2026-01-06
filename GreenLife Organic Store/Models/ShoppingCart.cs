namespace GreenLife_Organic_Store.Models
{
    /// <summary>
    /// Static ShoppingCart class for managing in-memory shopping cart
    /// </summary>
    public static class ShoppingCart
    {
        private static List<CartItem> _items = new();

        public static List<CartItem> Items => _items;

        public static decimal GetTotal()
        {
            return _items.Sum(i => i.Subtotal);
        }

        public static int GetItemCount()
        {
            return _items.Sum(i => i.Quantity);
        }

        public static void AddItem(Product product, int quantity)
        {
            var existing = _items.FirstOrDefault(i => i.Product.ID == product.ID);
            if (existing != null)
            {
                existing.Quantity += quantity;
            }
            else
            {
                _items.Add(new CartItem
                {
                    Product = product,
                    Quantity = quantity
                });
            }
        }

        public static void RemoveItem(int productId)
        {
            _items.RemoveAll(i => i.Product.ID == productId);
        }

        public static void UpdateQuantity(int productId, int quantity)
        {
            var item = _items.FirstOrDefault(i => i.Product.ID == productId);
            if (item != null)
            {
                if (quantity <= 0)
                    RemoveItem(productId);
                else
                    item.Quantity = quantity;
            }
        }

        public static void Clear()
        {
            _items.Clear();
        }

        public static bool HasItems()
        {
            return _items.Any();
        }

        public static bool HasProduct(int productId)
        {
            return _items.Any(i => i.Product.ID == productId);
        }

        public static int GetProductQuantity(int productId)
        {
            var item = _items.FirstOrDefault(i => i.Product.ID == productId);
            return item?.Quantity ?? 0;
        }
    }

    /// <summary>
    /// CartItem class representing an item in the shopping cart
    /// </summary>
    public class CartItem
    {
        public Product Product { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Subtotal => Product.GetFinalPrice() * Quantity;

        public override string ToString()
        {
            return $"{Product.ProductName} x {Quantity} = Rs. {Subtotal:N2}";
        }
    }
}
