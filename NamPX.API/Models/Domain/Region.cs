namespace NamPX.API.Models.Domain
{
    public class Region
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public Double Area { get; set; }

        public Double Lat { get; set; }

        public Double Long { get; set; }

        public long Population { get; set; }

        // Navigation property
        // 1 Regions => multiple walk
        public IEnumerable<Walk> Walks { get; set; }

    }
}
