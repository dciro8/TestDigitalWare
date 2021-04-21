namespace Ophelia.Model
{
    public class ProductDto
    {

        public object Id{ get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Price { get; set; }
        public decimal Quantity { get; set; }
        public int MinimunAlloweb { get; set; }

        public bool isSave { get; set; }
    }
}
