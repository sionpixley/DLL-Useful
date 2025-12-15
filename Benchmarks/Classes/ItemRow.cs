using System;

namespace Benchmarks.Classes
{
    public class ItemRow
    {
        public double Id { get; set; }
        public string Item2 { get; set; }
        public string Item3 { get; set; }
        public string Item4 { get; set; }
        public string Item5 { get; set; }
        public string Item6 { get; set; }
        public bool Item7 { get; set; }
        public string? Item8 { get; set; }
        public DateTime Item9 { get; set; }

        public ItemRow()
        {
            Id = 0.0;
            Item2 = "";
            Item3 = "";
            Item4 = "";
            Item5 = "";
            Item6 = "";
            Item7 = false;
            Item8 = null;
            Item9 = DateTime.UtcNow;
        }
    }
}
