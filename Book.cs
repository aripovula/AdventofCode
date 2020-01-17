namespace Advent3
{
  public class Book
  {
    public int? Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public int Price { get; set; }
    public Book() { }
    public Book(string Name)
    {
      this.Name = Name;
    }
    public Book(string Name, int Price)
    {
      this.Name = Name;
      this.Price = Price;
    }
    public Book(string Name, string Author, int Price)
    {
      this.Name = Name;
      this.Author = Author;
      this.Price = Price;
    }
  }

  public class Library
  {
    Book book1 = new Book("Refactoring");
    Book book2 = new Book("Refactoring", 32);
    Book book3 = new Book("Refactoring", "Martin Fowler", 32);
    Book book4 = new Book { Name = "Refactoring", Author = "Martin Fowler", Price = 32 };
    Book book5 = new Book();

    void newBook(string theName)
    {
      book5.Name = theName;
      book5.Author = "Martin Fowler";
    }
  }

}