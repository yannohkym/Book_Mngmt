namespace Book_Management.Models
{
    public class CartItem
    {
        public int CartId { get; set; }

        public  string CategoryName { get; set; }

        public string Description { get; set; }

        public ICollection<Book> Books { get; set; }

    }
}
  