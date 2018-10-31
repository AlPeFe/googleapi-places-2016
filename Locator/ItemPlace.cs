using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoogleApi.Entities.Places.Search.NearBy.Request;
using GoogleApi.Entities.Places.Search.NearBy.Response;
using GoogleApi.Entities.Places.Photos.Response;

namespace Locator
{
    public class ItemPlace
    {

        public NearByResult Place {get;set;}

        public PlacesPhotosResponse Img { get; set; }


    }
}