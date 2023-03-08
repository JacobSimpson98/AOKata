using AOKata.ShopItems;

namespace AOKata.Cart;

/// <summary>
/// A class representing a shopping cart for books.
/// </summary>
public class ShoppingCart {
    private List<CartItem> _cartItems { get; set; } = new List<CartItem>();

    /// <summary>
    /// Returns the total price of the items within the cart, accounting for any appropriate discounts.
    /// </summary>
    /// <returns>Decimal price of the cart items</returns>
    public decimal GetTotalPrice() {
        List<BookSet> cartBookSets = CartItemsToBookSets(_cartItems);
        return cartBookSets.Sum(set => set.GetSetPrice());
    }

    /// <summary>
    /// Adds a new instance of the input book to the cart.
    /// </summary>
    /// <param name="NewBook">The book to add</param>
    public void AddBook(Book NewBook) {
        CartItem? foundBookCartItem = _cartItems.FirstOrDefault(cartItem => cartItem.Book.Title == NewBook.Title);

        if (foundBookCartItem != null) {
            foundBookCartItem.Quantity++;
        }
        else {
            _cartItems.Add(new CartItem(NewBook));
        }
    }

    /// <summary>
    /// Converts the input cart items into a collection of book sets.
    /// </summary>
    /// <param name="CartItems">The cart items to convert</param>
    /// <returns>A list of book sets representing the cart items input</returns>
    private static List<BookSet> CartItemsToBookSets(List<CartItem> CartItems) {
        List<BookSet> bookSets = new();

        //For each cart item, add a new instance of this item's shop book into a book set, perform this once for each quantity of this book
        foreach (CartItem cartItem in CartItems) {
            for (int i = 0; i < cartItem.Quantity; i++) {
                bool bookAdded = false;

                //Sorts the list of book sets to ensure we are first assessing book sets whose counts are the lowest.
                //This allows the book sets to be sorted into the largest amount of unique sets, resulting in the largest discount, as per the requirements.
                IOrderedEnumerable<BookSet> orderedBookSets = bookSets.OrderBy(set => set.GetBookCount());

                //Find the first existing book set that does not already contain an instance of this book
                foreach (BookSet bookSet in orderedBookSets) {
                    if (!bookSet.ContainsBook(cartItem.Book)) {
                        bookSet.AddBook(cartItem.Book);
                        bookAdded = true;
                        break;
                    }
                }

                if (!bookAdded) {
                    //If we reached here, then no suitable existing book set was found, so we need to establish a new one
                    BookSet newBookSet = new();
                    newBookSet.AddBook(cartItem.Book);
                    bookSets.Add(newBookSet);
                }
            }
        }

        return bookSets;
    }
}
