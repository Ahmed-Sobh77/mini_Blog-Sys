namespace blog.Data
{
    internal class DataContext
    {
        ///instead of making them static,i will passing the same object to constructor so i will collect all data in the same
        /// to make it still available to seperate some alone and alot of better options
        ///that is called dependency injection
        public List<Models.User> Users { get; private set; }
        public List<Models.Post> Posts { get; private set; }
        public List<Models.Comment> Comments { get; private set; }
        public DataContext()
        {
            Users = new List<Models.User>();
            Posts = new List<Models.Post>();
            Comments = new List<Models.Comment>();
        }

    }
}