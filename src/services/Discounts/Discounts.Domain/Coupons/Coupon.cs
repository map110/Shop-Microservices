using System.ComponentModel.DataAnnotations;
using Discounts.Domain.Base;
using Discounts.Domain.Enums;

namespace Discounts.Domain.Coupons;

public class Coupon : BaseEntity
{
    [Required] public int ProductId { get; set; }
    [MaxLength(300)] public string ProductTitle { get; set; }
    public DiscountType DiscountType { get; set; }
    public int Value { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}