using Discounts.Domain.Enums;

namespace Discounts.Domain.Coupons;

public class CouponDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ProductTitle { get; set; }
    public DiscountType DiscountType { get; set; }
    public int Value { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}