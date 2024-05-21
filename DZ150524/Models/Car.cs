namespace DZ150524.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string? marka { get; set; }
        public string? model { get; set; }
        public string? bodytype { get; set; }
        public string? enginetype { get; set; }
        public double engineDisplacement { get; set; }
        public string? transmissionType { get; set; }
        public double averageConsumption { get; set; }
    }
}
