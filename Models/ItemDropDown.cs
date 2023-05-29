namespace WebApp.Models
{
    public class ItemDropDown
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; } = 0;
    }
}
