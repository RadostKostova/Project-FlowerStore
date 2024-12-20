﻿using FlowerStore.Components;
using FlowerStore.Infrastructure.Data.Models.Cart;
using FlowerStore.Infrastructure.Data.Models.Payment;
using FlowerStore.Infrastructure.Data.Models.Roles;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FlowerStore.Infrastructure.Constants.DataConstants;

namespace FlowerStore.Infrastructure.Data.Models.Orders.Order
{
    /// <summary>
    /// An order represents a user's purchase of one or more products and all the data needed for a single purchase.
    /// </summary>
    public class Order
    {
        [Key]
        [Comment("Order identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("User identifier")]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [DisplayFormat(DataFormatString = DateFormatNeeded,
            ApplyFormatInEditMode = true)]
        [Comment("Order date")]
        public DateTime OrderDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [DecimalRange(OrderTotalPriceMinLength, OrderTotalPriceMaxLength)]
        [Comment("Payment amount")]
        public decimal TotalPrice { get; set; }

        [Required]
        [Comment("Chosen payment identifier")]
        public int PaymentMethodId { get; set; }

        [Comment("More details of the order")]
        public string? OrderDetails { get; set; }

        [Required]
        [MaxLength(AddressMaxLength)]
        [Comment("Shipping address")]
        public string ShippingAddress { get; set; } = string.Empty;

        [Required]
        [Comment("Order status identifier")]
        public int OrderStatusId { get; set; }

        [Required]
        [Comment("Shopping Cart identifier")]
        public int ShoppingCartId { get; set; }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        [Comment("First name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(LastNameMaxLength)]
        [Comment("Last name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [Comment("Email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone]
        [MaxLength(UserPhoneExactlyLength)]
        [Comment("Phone number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Comment("Card identifier")]
        public int? CardDetailsId { get; set; }

        [ForeignKey("CardDetailsId")]
        public CardDetails? CardDetails { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        [ForeignKey(nameof(PaymentMethodId))]
        public PaymentMethod PaymentMethod { get; set; } = null!;

        [ForeignKey(nameof(OrderStatusId))]
        public OrderStatus OrderStatus { get; set; } = null!;

        [ForeignKey(nameof(ShoppingCartId))]
        public ShoppingCart ShoppingCart { get; set; } = null!;

        public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}