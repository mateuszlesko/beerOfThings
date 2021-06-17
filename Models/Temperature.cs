using System;
using System.Collections.Generic;

#nullable disable

namespace beerOfThings.Models
{
    public partial class Temperature
    {
        public int Id { get; set; }
        public int? StageId { get; set; }
        public int? Value { get; set; }
        public byte[] Time { get; set; }
        public DateTime? Date { get; set; }
        public int? WarmingId { get; set; }

        public virtual Stage Stage { get; set; }
        public virtual WarmingHistory Warming { get; set; }
    }
}
