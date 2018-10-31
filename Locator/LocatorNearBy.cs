using GoogleApi.Entities.Places.Search.NearBy.Request;
using GoogleApi.Entities.Places.Search.NearBy.Response;
using Locator.APIRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator
{
    public class LocatorNearBy
    {
        private static IApiRequest _apiRequest;

        public LocatorNearBy() : this(new ApiRquest()) { }

        public LocatorNearBy(IApiRequest apiRequest)
        {
            _apiRequest = apiRequest;
        }
        
        public async Task<List<ItemPlace>> GetNearByLocations(PlacesNearBySearchRequest filter)
        {
            List<ItemPlace> result = new List<ItemPlace>();

            try
            {
               result = await _apiRequest.RequestPlaces();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
