using Android.App;
using Android.Widget;
using Android.OS;
using Locator;
using GoogleApi;
using GoogleApi.Entities.Places.Search.NearBy.Request;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using B.Adapters;
using GoogleApi.Entities.Places.Search.NearBy.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace B
{
    [Activity(Label = "B", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        LocatorNearBy _nearby;
        private RecyclerView mRecyclerView;
        private RecyclerView.Adapter mAdapter;
        private RecyclerView.LayoutManager mLayoutManager;
        private PlacesNearBySearchRequest _filter;

        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recycler_places);
            mRecyclerView.HasFixedSize = true;

            mLayoutManager = new LinearLayoutManager(this);
            mRecyclerView.SetLayoutManager(mLayoutManager);

            var dataSet = await Start();

            mAdapter = new ItemsAdapter(dataSet);
            mRecyclerView.SetAdapter(mAdapter);           

        }

        public async Task<List<ItemPlace>> Start()
        {
            PlacesNearBySearchRequest s = new PlacesNearBySearchRequest();
            _nearby = new LocatorNearBy();
            var res = await _nearby.GetNearByLocations(s);
           
            return res;
        }
    }
}

