using System;

namespace Ophelia.Model
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool State { get; set; }
        public int Amount { get; set; }
        public int AllowMin { get; set; }

        
    }
}
