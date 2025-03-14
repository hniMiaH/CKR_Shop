﻿using DAL.Entities.Product;
using DAL.Entities.Product.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModels
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        [DisplayName("Code")]
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        public string SKU { get; set; } = string.Empty;

        [DisplayName("Tên sản phẩm")]
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        public string Name { get; set; } = string.Empty;

        [DisplayName("Thương Hiệu")]
        public string Branch { get; set; } = string.Empty;

        [DisplayName("Mô tả")]
        public string Description { get; set; } = string.Empty;

        [DisplayName("Giá (VNĐ)")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        [DefaultValue(0)]
        public int Price { get; set; } = 0;

        [DisplayName("Tồn kho")]
        [DefaultValue(0)]
        public int Stock { get; set; } = 0;

        [DisplayName("Loại Sản Phẩm")]
        public Guid ProductTypeId { get; set; }     
        public ProductTypeModel ProductType { get; set; }

        [DisplayName("Ảnh Sản Phẩm")]
        public string Image { get; set; } = string.Empty;

        [DisplayName("Ảnh Sản Phẩm")]

        [NotMapped]
        //[RegularExpression(@"^.*\.(jpg|JPG|gif|GIF|png|PNG)$", ErrorMessage = "Sai kiểu dữ liệu")]
        public IFormFile ImageFile { get; set; }

        [DisplayName("Ngày tạo")]
        public DateTime CreatedAt { get; set; }

        [DisplayName("Còn hiệu lực")]
        public StatusEnum Status { get; set; } = StatusEnum.NotSet;

        // Collection reference property cho khóa ngoại từ Cart
        //public List<Cart> Carts { get; set; }

        //// Collection reference property cho khóa ngoại từ InvoiceDetail
        //public List<InvoiceDetail> InvoiceDetails { get; set; }

        //public List<Advertisement> Advertisements { get; set; }

        //public List<Comment> Comments { get; set; }
    }
}
