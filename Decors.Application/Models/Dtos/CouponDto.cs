using System;

namespace Decors.Application.Models
{
    public class CouponDto
    {
        public string Code { get; set; }
        public int Discount { get; set; }
        public DateTime Expires { get; set; }
    }
}
