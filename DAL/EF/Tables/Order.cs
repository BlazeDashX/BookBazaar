using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Order
{
    public int Id { get; set; }

    public Guid ReferenceId { get; set; }

    public int UserId { get; set; }

    public string Status { get; set; } = null!;

    public decimal TotalAmount { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal FinalAmount { get; set; }

    public int? CouponId { get; set; }

    public string ShippingAddress { get; set; } = null!;

    public string? Note { get; set; }

    public DateTime PlacedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Coupon? Coupon { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual User User { get; set; } = null!;
}
