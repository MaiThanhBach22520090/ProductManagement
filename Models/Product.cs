using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagement.Models
{
    public class Product
    {
        [Key] // Khóa chính
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mã sản phẩm")]
        [StringLength(50)]
        public string ProductCode { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm")]
        [StringLength(100)]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập giá sản phẩm")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá phải là số dương")]
        public double UnitPrice { get; set; }

        [StringLength(200)]
        public string Picture { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn danh mục")]
        public int CatalogID { get; set; }

        [ForeignKey("CatalogID")]
        public virtual Catalog Catalog { get; set; }
    }
}
