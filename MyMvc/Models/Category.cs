namespace MyMvc.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        List<Item>? Items { get; set; }
        
    }
}
