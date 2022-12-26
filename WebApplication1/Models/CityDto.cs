namespace WebApplication1.Models
{
    public class CityDto
    {
        public int Id { get; set; }
        public string CityName { get; set; } = string.Empty;
        public string Description { get; set; }
        public int NumberOfPointOfInterset 
        { 
           get { return PointsOfInterest.Count; }
        }

        public ICollection<PointOfInterestDto> PointsOfInterest { get; set; } = new List<PointOfInterestDto>();
    }
}
