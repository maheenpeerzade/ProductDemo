using NJsonSchema.Annotations;
using System.ComponentModel.DataAnnotations;

namespace ProductDemo.Domain.DTO
{
    [JsonSchema("CreateProduct")]
    public class CreateProductDTO
    {
        /// <summary>
        /// Product name.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        /// <summary>
        /// Product description.
        /// </summary>
        [StringLength(300)]
        public string? Description { get; set; }

        /// <summary>
        /// Product category.
        /// </summary>
        public string? Category { get; set; }

        /// <summary>
        /// Product unit price.
        /// </summary>
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// Indicates if the product is discontinued.
        /// </summary>
        public bool Discontinued { get; set; } = false;

        /// <summary>
        /// Product's production data.
        /// </summary>
        public DateTime ProductionData { get; set; } = DateTime.Now;
    }
}
