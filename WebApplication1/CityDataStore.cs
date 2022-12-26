using WebApplication1.Models;

namespace WebApplication1
{
    public class CityDataStore
    {
        public List<CityDto> Cities { get; set; }
        public static CityDataStore current { get; } = new CityDataStore();
        public CityDataStore()
        {
            Cities = new List<CityDto> //collection initiallizer
            {
              new CityDto(){Id=1 , CityName="Tehran" , Description="smoky" , PointsOfInterest= new List<PointOfInterestDto>(){
                  new PointOfInterestDto {Id=1, Name="Trafic" , Description="nothing"},
                  new PointOfInterestDto {Id=2, Name="Polution" , Description="nothing"},
                  new PointOfInterestDto {Id=3, Name="Busy" , Description="nothing"}
              } },
              new CityDto(){Id=2 , CityName="Shiraz" , Description="Beautiful"  , PointsOfInterest= new List<PointOfInterestDto>(){
                 new PointOfInterestDto {Id=1, Name="cars" , Description="nothing"},
                 new PointOfInterestDto {Id=2, Name="sound" , Description="nothing"},
                 new PointOfInterestDto {Id=3, Name="lazy" , Description="nothing"}
              } },
              new CityDto(){Id=3 , CityName="Esfahan" , Description="Historical"  , PointsOfInterest= new List<PointOfInterestDto>(){
                 new PointOfInterestDto {Id=1, Name="Expensive" , Description="nothing"},
                 new PointOfInterestDto {Id=2, Name="Poverty" , Description="nothing"},
                 new PointOfInterestDto {Id=3, Name="sorrow" , Description="nothing"}
              } },
              new CityDto(){Id=4 , CityName="Kerman" , Description="Pestashio"}
            };
        }
    }
}
