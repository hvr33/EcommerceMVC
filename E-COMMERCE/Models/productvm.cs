using System.ComponentModel.DataAnnotations;

namespace E_COMMERCE.Models
{
    public class productvm
    {
        [Required(ErrorMessage = "اسم الفئة مطلوب")]
        [StringLength(100, ErrorMessage = "اسم الفئة يجب ألا يتجاوز 100 حرف")]
        public string catname {  get; set; }
        [Required(ErrorMessage = "اسم المنتج مطلوب")]
        [StringLength(100, ErrorMessage = "اسم المنتج يجب ألا يتجاوز 100 حرف")]
        public string productname{ get; set; }
        [Required(ErrorMessage = "سعر المنتج مطلوب")]
        [Range(0.01, double.MaxValue, ErrorMessage = "السعر يجب أن يكون أكبر من 0")]
        public decimal productprice { get; set; }
        [Required(ErrorMessage = "الكمية مطلوبة")]
        [Range(1, int.MaxValue, ErrorMessage = "الكمية يجب أن تكون 1 على الأقل")]
        public required  string productquntity { get; set; }
    }
}
