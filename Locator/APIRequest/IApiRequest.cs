using GoogleApi.Entities.Places.Search.NearBy.Request;
using GoogleApi.Entities.Places.Search.NearBy.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.APIRequest
{
    public interface IApiRequest
    {

        Task<List<ItemPlace>> RequestPlaces();
    }
}
