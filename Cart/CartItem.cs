using AOKata.ShopItems;

namespace AOKata.Cart {
    /// <summary>
    /// A class encapsulating a shop book item, to facilitate quantity tracking
    /// </summary>
    internal class CartItem {
        private int _quantity = 1;

        internal Book Book { get; }

        internal int Quantity {
            get => _quantity;
            set {
                if (value > 0) {
                    _quantity = value;
                }
                else {
                    _quantity = 0;
                }
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="Book">The book item to represent</param>
        internal CartItem(Book Book) {
            this.Book = Book;
            Quantity = 1;
        }
    }
}
