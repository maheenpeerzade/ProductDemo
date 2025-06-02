using NJsonSchema.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductDemo.Domain.DTO
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
