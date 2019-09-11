namespace SSC.Api.Controllers
{
    public class PatchOperation
    {
        public string op { get; set; }
        public string field { get; set; }
        public string value { get; set; }
        public int key { get; set; }
    }
}