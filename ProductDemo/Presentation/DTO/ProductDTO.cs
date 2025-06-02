using NJsonSchema.Annotations;

namespace ProductDemo.Presentation.DTO
{
    [JsonSchema("Product")]
    public class ProductDTO : CreateProductDTO
    {
        /// <summary>
        /// Id(Primary Key).
        /// </summary>
        public int Id { get; set; }
    }
}
