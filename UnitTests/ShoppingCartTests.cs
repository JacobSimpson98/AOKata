
using AOKata.Cart;
using AOKata.ShopItems;
using NUnit.Framework;

namespace AOKata.UnitTests;
/// <summary>
/// Unit test set to test and assess functionality of the shopping cart
/// </summary>
[TestFixture]
public class ShoppingCartTests {
    private const decimal BOOK_PRICE = 8m;

    [Test]
    public void GetTotalPrice_WhenBasketIsEmpty_Returns_0() {
        ShoppingCart cart = new();
        decimal totalPrice = cart.GetTotalPrice();

        Assert.AreEqual(0m, totalPrice);
    }

    [Test]
    public void GetTotalPrice_WhenOneBookInBasket_Returns_8() {
        Book book = new("The First Book", BOOK_PRICE);
        ShoppingCart cart = new();
        cart.AddBook(book);

        decimal totalPrice = cart.GetTotalPrice();

        Assert.AreEqual(8m, totalPrice);
    }

    [Test]
    public void GetTotalPrice_WhenTwoSameBooksInBasket_Returns_16() {
        Book book1 = new("The First Book", BOOK_PRICE);
        Book book2 = new("The First Book", BOOK_PRICE);

        ShoppingCart cart = new();
        cart.AddBook(book1);
        cart.AddBook(book2);

        decimal totalPrice = cart.GetTotalPrice();

        Assert.AreEqual(16m, totalPrice);
    }

    [Test]
    public void GetTotalPrice_WhenTwoDifferentBooksInBasket_Returns_15_20() {
        Book book1 = new("The First Book", BOOK_PRICE);
        Book book2 = new("The Second Book", BOOK_PRICE);

        ShoppingCart cart = new();
        cart.AddBook(book1);
        cart.AddBook(book2);

        decimal totalPrice = cart.GetTotalPrice();

        Assert.AreEqual(15.20m, totalPrice);
    }

    [Test]
    public void GetTotalPrice_WhenThreeDifferentBooksInBasket_Returns_21_60() {
        Book book1 = new("The First Book", BOOK_PRICE);
        Book book2 = new("The Second Book", BOOK_PRICE);
        Book book3 = new("The Third Book", BOOK_PRICE);

        ShoppingCart cart = new();
        cart.AddBook(book1);
        cart.AddBook(book2);
        cart.AddBook(book3);

        decimal totalPrice = cart.GetTotalPrice();

        Assert.AreEqual(21.60m, totalPrice);
    }

    [Test]
    public void GetTotalPrice_WhenFourDifferentBooksInBasket_Returns_25_60() {
        Book book1 = new("The First Book", BOOK_PRICE);
        Book book2 = new("The Second Book", BOOK_PRICE);
        Book book3 = new("The Third Book", BOOK_PRICE);
        Book book4 = new("The Fourth Book", BOOK_PRICE);

        ShoppingCart cart = new();
        cart.AddBook(book1);
        cart.AddBook(book2);
        cart.AddBook(book3);
        cart.AddBook(book4);

        decimal totalPrice = cart.GetTotalPrice();

        Assert.AreEqual(25.60m, totalPrice);
    }

    [Test]
    public void GetTotalPrice_WhenFiveDifferentBooksInBasket_Returns_30() {
        Book book1 = new("The First Book", BOOK_PRICE);
        Book book2 = new("The Second Book", BOOK_PRICE);
        Book book3 = new("The Third Book", BOOK_PRICE);
        Book book4 = new("The Fourth Book", BOOK_PRICE);
        Book book5 = new("The Fifth Book", BOOK_PRICE);

        ShoppingCart cart = new();
        cart.AddBook(book1);
        cart.AddBook(book2);
        cart.AddBook(book3);
        cart.AddBook(book4);
        cart.AddBook(book5);

        decimal totalPrice = cart.GetTotalPrice();

        Assert.AreEqual(30m, totalPrice);
    }

    [Test]
    public void GetTotalPrice_WhenFiveDifferentBooksInBasket_Returns_51_20() {
        Book book1 = new("The First Book", BOOK_PRICE);
        Book book2 = new("The Second Book", BOOK_PRICE);
        Book book3 = new("The Third Book", BOOK_PRICE);
        Book book4 = new("The Fourth Book", BOOK_PRICE);
        Book book5 = new("The Fifth Book", BOOK_PRICE);

        ShoppingCart cart = new();
        cart.AddBook(book1);
        cart.AddBook(book1);
        cart.AddBook(book2);
        cart.AddBook(book2);
        cart.AddBook(book3);
        cart.AddBook(book3);
        cart.AddBook(book4);
        cart.AddBook(book5);

        decimal totalPrice = cart.GetTotalPrice();

        Assert.AreEqual(51.20m, totalPrice);
    }

    [Test]
    public void GetTotalPrice_WhenMoreThanFiveDifferentBooksInBasket_Returns_30() {
        Book book1 = new("The First Book", BOOK_PRICE);
        Book book2 = new("The Second Book", BOOK_PRICE);
        Book book3 = new("The Third Book", BOOK_PRICE);
        Book book4 = new("The Fourth Book", BOOK_PRICE);
        Book book5 = new("The Fifth Book", BOOK_PRICE);
        Book book6 = new("The Sixth Book", BOOK_PRICE);

        ShoppingCart cart = new();
        cart.AddBook(book1);
        cart.AddBook(book2);
        cart.AddBook(book3);
        cart.AddBook(book4);
        cart.AddBook(book5);
        cart.AddBook(book6);

        decimal totalPrice = cart.GetTotalPrice();

        Assert.AreEqual(36m, totalPrice);
    }
}
