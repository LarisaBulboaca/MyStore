using MyStore.Domain;

namespace MyStore.Models
{
    public class OrderDetailModel
    {
        public int Orderid { get; set; }

        public int Productid { get; set; }

        public decimal Unitprice { get; set; }

        public short Qty { get; set; }

        public decimal Discount { get; set; }

        public virtual Order Order { get; set; } = null!;

        public virtual Product Product { get; set; } = null!;
    }
}
