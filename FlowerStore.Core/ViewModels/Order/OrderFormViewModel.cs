﻿using FlowerStore.Core.ViewModels.PaymentMethod;
using System.ComponentModel.DataAnnotations;
using static FlowerStore.Infrastructure.Constants.DataConstants;
using static FlowerStore.Infrastructure.Constants.ErrorConstants;

namespace FlowerStore.Core.ViewModels.Order
{
    public class OrderFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(AddressMaxLength, 
            MinimumLength = AddressMinLength, 
            ErrorMessage = StringLengthErrorMessage)]
        public string ShippingAddress { get; set; } = string.Empty;

        [Display(Name = "Order details")]
        public string OrderDetails { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Payment Method")]
        public int PaymentMethodId { get; set; }

        public IEnumerable<PaymentMethodViewModel> PaymentMethods { get; set; } = new List<PaymentMethodViewModel>();
    }
}
