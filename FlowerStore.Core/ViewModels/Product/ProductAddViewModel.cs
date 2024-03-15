﻿using FlowerStore.Components;
using FlowerStore.Core.ViewModels.Category;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static FlowerStore.Infrastructure.Constants.DataConstants;
using static FlowerStore.Infrastructure.Constants.ErrorConstants;

namespace FlowerStore.Core.ViewModels.Product
{
    /// <summary>
    /// This ViewModel represents Product entity, that will be added to database via form. Only the Admin should be able to access this.
    /// Availability is by default false, it will be calculated by FlowersCount.
    /// </summary>
    public class ProductAddViewModel
    {
        [Required]
        [StringLength(ProductNameMaxLength,
            MinimumLength = ProductNameMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Name { get; set; } = string.Empty;


        [Required]
        [DecimalRange(ProductPriceMinLength,
            ProductPriceMaxLength,
            ErrorMessage = NumberRangeErrorMessage)]
        public decimal Price { get; set; }


        [Required]
        [Display(Name = "Image Url")]
        [RegularExpression(@"(https:\/\/)([^\s([""<,>/]*)(\/)[^\s["",><]*(.png|.jpg)(\?[^\s["",><]*)?", 
            ErrorMessage = ImageUrlErrorMessage)]
        public string ImageUrl { get; set; } = string.Empty;


        [Required]
        [StringLength(ProductDescriptionMaxLength,
            MinimumLength = ProductDescriptionMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "Detailed description of the product")]
        public string FullDescription { get; set; } = string.Empty;


        [Required]
        [DisplayFormat(DataFormatString = DateFormatNeeded, ApplyFormatInEditMode = true)]
        [Display(Name = "Date of the add")]
        public DateTime DateAdded { get; set; }


        [Required]
        [Range(ProductCountMinLength,
            ProductCountMaxLength,
            ErrorMessage = NumberRangeErrorMessage)]
        [Display(Name = "Received quantity")]
        public int FlowersCount { get; set; }


        [Required]
        public bool Availability { get; set; }


        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
