namespace MyWebApi.Models
{
    public class Book:BaseModel<int>
    {
        public string Name { get; set; }
        public string Price { get; set; }
    }
}
