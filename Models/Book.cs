namespace Book_Management.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public double Price { get; set; }

        //foreign key
        public int CartId { get; set; }

        //navigation property

        public CartItem CartItem { get; set; }

    }
}
