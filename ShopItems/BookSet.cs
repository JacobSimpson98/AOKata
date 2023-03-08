namespace AOKata.ShopItems;

/// <summary>
/// A class representing a set of related books
/// </summary>
internal class BookSet {

    //As discussed during the interview, in an ideal World these would instead be retrieved from a database,
    //or at minimum configuration file, to allow adjustment without re-compilation
    private const decimal ONE_BOOK_DISCOUNT = 0m;
    private const decimal TWO_BOOK_DISCOUNT = 0.05m;
    private const decimal THREE_BOOK_DISCOUNT = 0.10m;
    private const decimal FOUR_BOOK_DISCOUNT = 0.20m;
    private const decimal FIVE_BOOK_DISCOUNT = 0.25m;

    private readonly List<Book> _booksInSet = new();

    /// <summary>
    /// Retrieves the total price of all books within this set instance, accounting for any relevant discounts
    /// </summary>
    /// <returns>A decimal representing the price</returns>
    internal decimal GetSetPrice() {
        return _booksInSet.Sum(b => b.Price) * (1 - GetDiscount());
    }

    /// <summary>
    /// Retrieves the count amount of books within this set instance.
    /// </summary>
    /// <returns>Integer representing the number of books</returns>
    internal int GetBookCount() {
        return _booksInSet.Count;
    }

    /// <summary>
    /// Returns if the passed in book is already present within this book set
    /// </summary>
    /// <param name="queryBook">The book to query</param>
    /// <returns><see langword="true"/> if the query book is present, otherwise false</returns>
    internal bool ContainsBook(Book queryBook) {
        return _booksInSet.Any(book => book.Title == queryBook.Title);
    }

    /// <summary>
    /// Adds the input book to the book set, if it is not already present.
    /// </summary>
    /// <param name="newBook"></param>
    internal void AddBook(Book newBook) {
        if (!ContainsBook(newBook)) {
            _booksInSet.Add(newBook);
        }
    }

    /// <summary>
    /// Determines and returns the appropriate discount percentage to apply for this book set instance as a decimal.
    /// E.g. 0.2 for 20%.
    /// </summary>
    /// <returns>Decimal discount percentage</returns>
    private decimal GetDiscount() {
        //This class makes some assumptions that any set containing more than five books will still return the discount applicable for sets containing five books.
        if (_booksInSet.Count == 0) { return 0; }
        if (_booksInSet.Count == 1) { return ONE_BOOK_DISCOUNT; }
        if (_booksInSet.Count == 2) { return TWO_BOOK_DISCOUNT; }
        else if (_booksInSet.Count == 3) { return THREE_BOOK_DISCOUNT; }
        else if (_booksInSet.Count == 4) { return FOUR_BOOK_DISCOUNT; }
        else {
            //Count must be five or greater
            return FIVE_BOOK_DISCOUNT;
        }
    }
}
