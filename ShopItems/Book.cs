namespace AOKata.ShopItems;

/// <summary>
/// A class representing a shop book
/// </summary>
public class Book {
    public string Title { get; }
    public decimal Price { get; }

    public Book(string Title, decimal Price) {
        this.Price = Price;
        this.Title = Title;
    }
}
