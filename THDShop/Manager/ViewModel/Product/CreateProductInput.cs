using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Manager.ViewModel.Product
{
    public class CreateProductInput
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập tên ")]
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bạn chưa chọn loại sản phẩm")]
        [Display(Name = "Loại sản phẩm")]
        public int? CategoryId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Số lượng không được âm")]
        [Required(ErrorMessage = "Bạn chưa nhập số lượng")]
        [Display(Name = "Số lượng")]
        public int? Quantity { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Giá không được âm")]
        [Required(ErrorMessage = "Bạn chưa nhập giá")]
        [Display(Name = "Giá")]
        public int? Price { get; set; }


        [Required(ErrorMessage = "Bạn chưa nhập mô tả")]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }


        public string Image { get; set; }


        [NotMapped]
        public HttpPostedFile UploadImage { get; set; }
    }
    public class UpdateProductInput : CreateProductInput
    {
        public string Name { get; set; }

        [Required(ErrorMessage = "Bạn chưa chọn loại sản phẩm")]
        [Display(Name = "Loại sản phẩm")]
        public int? CategoryId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Số lượng không được âm")]
        [Required(ErrorMessage = "Bạn chưa nhập số lượng")]
        [Display(Name = "Số lượng")]
        public int? Quantity { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Giá không được âm")]
        [Required(ErrorMessage = "Bạn chưa nhập giá")]
        [Display(Name = "Giá")]
        public int? Price { get; set; }


        [Required(ErrorMessage = "Bạn chưa nhập mô tả")]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }


        public string Image { get; set; }


        [NotMapped]
        public HttpPostedFile UploadImage { get; set; }
    }
}