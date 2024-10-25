using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("AuthUser")]
public class AuthUser
{
    [Key]
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public string? PasswordHash { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool? EmailConfirmed { get; set; }

    public string? PasswordResetToken { get; set; }

    public string? Role { get; set; }
}

