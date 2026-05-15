using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class User
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PasswordHash { get; set; }

    public string Role { get; set; } = null!;

    public string? OauthProvider { get; set; }

    public string? OauthId { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Token { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
