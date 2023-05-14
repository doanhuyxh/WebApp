namespace WebApp.Models
{
    public class JsonResultViewModel
    {
        public bool Success { get; set; }
        public string Mesaage { get; set; }
        public dynamic Object { get; set; }
    }
}
