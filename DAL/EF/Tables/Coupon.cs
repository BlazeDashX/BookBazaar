using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Coupon
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public decimal DiscountPercentage { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
