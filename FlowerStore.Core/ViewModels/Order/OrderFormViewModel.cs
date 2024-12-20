﻿using FlowerStore.Core.ViewModels.PaymentMethod;
using System.ComponentModel.DataAnnotations;
using static FlowerStore.Infrastructure.Constants.DataConstants;
using static FlowerStore.Infrastructure.Constants.ErrorConstants;

namespace FlowerStore.Core.ViewModels.Order
{
    public class OrderFormViewModel
    {
        /// <summary>
        /// This view model represents a form that collects user's chosen payment method, shipping details, personal data and etc. 
        /// The user's input from this viewModel will be transferred to OrderViewModel, which will hold the detailed information about the user's order. It will be saved in session.
        /// </summary>
        public int Id { get; set; }

        [Required]
        [StringLength(AddressMaxLength, 
            MinimumLength = AddressMinLength, 
            ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "Shipping address")]
        public string ShippingAddress { get; set; } = string.Empty;

        [Display(Name = "Order details")]
        public string? OrderDetails { get; set; } 

        [Required]
        [Display(Name = "Payment Method")]
        public int PaymentMethodId { get; set; }

        [Required]
        [StringLength(FirstNameMaxLength,
            MinimumLength = FirstNameMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(LastNameMaxLength,
            MinimumLength = LastNameMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress(ErrorMessage = InvalidFieldErrorMessage)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(UserPhoneExactlyLength)]
        [Phone(ErrorMessage = InvalidFieldErrorMessage)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; } = string.Empty;

        public IEnumerable<PaymentMethodViewModel> PaymentMethods { get; set; } = new List<PaymentMethodViewModel>();
    }
}
