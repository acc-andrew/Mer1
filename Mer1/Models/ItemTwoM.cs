namespace Mer1.Models
{
    public class ItemTwoM
    {
        public int ID { get; set; }
        public required string Reason { get; set; }
        public Decimal Spent{ get; set; }

        public required string Category { get; set; }

        public Decimal Balance{ get; set; }

        public DateTime TradeDate { get; set; }
        public DateTime CreatedAt { get; set; }

    }// public class ItemTwoM
}
