using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GoogleApi.Entities.Places;
using GoogleApi.Entities.Places.Search.NearBy.Request;
using GoogleApi;
using GoogleApi.Entities.Places.Search.Common.Enums;
using GoogleApi.Entities.Places.Search.NearBy.Response;
using GoogleApi.Entities.Places.Photos.Request;
using static System.Net.Mime.MediaTypeNames;

namespace Locator.APIRequest
{
    public class ApiRquest : AppSettings, IApiRequest
    {                    
        public async Task<List<ItemPlace>> RequestPlaces()
        {
            List<NearByResult> results = new List<NearByResult>();
            List<ItemPlace> res = new List<ItemPlace>();
           
            try
            {
                var request = new PlacesNearBySearchRequest
                {
                    Key = this.ApiKey,
                    Keyword = "Ocata",//filter.Keyword,
                    Location = new GoogleApi.Entities.Common.Location(41.47978, 2.3188),
                    Sensor = true,
                    Radius = 500,
                    Type = SearchPlaceType.Restaurant                                      
                };

                var response = await GooglePlaces.NearBySearch.QueryAsync(request);

                results = response.Results.ToList();

                foreach(var item in results)
                {

                    var photoRequest = await GoogleApi.GooglePlaces.Photos.QueryAsync(new PlacesPhotosRequest { PhotoReference = item.Photos.ToList()[0].PhotoReference, Key = this.ApiKey, MaxHeight = 1000, MaxWidth = 1000});

                    res.Add(new ItemPlace
                    {
                        Place = item,
                        Img = photoRequest

                    });

                }

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return res;
        }
    }
}
