using SQLite;
namespace BSMSShared.Models
{
    public class Author
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
