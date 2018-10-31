using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using B.ViewHolders;
using GoogleApi.Entities.Places.Search.NearBy.Response;
using Locator;


namespace B.Adapters
{
    public class ItemsAdapter : RecyclerView.Adapter
    {
        private List<ItemPlace> _dataSet;
        public event EventHandler<int> ItemClick;

        public ItemsAdapter(List<ItemPlace> results)
        {
            _dataSet = results;
        }

        public override int ItemCount => _dataSet.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ItemsViewHolder itemsViewHolder = holder as ItemsViewHolder;
            itemsViewHolder.thumbnail.SetImageBitmap(Android.Graphics.BitmapFactory.DecodeStream(_dataSet[position].Img.Photo));
            itemsViewHolder.description.Text = _dataSet[position].Place.Name;
            itemsViewHolder.title.Text = _dataSet[position].Place.Rating.ToString();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                Inflate(Resource.Layout.item_place, parent, false);
            ItemsViewHolder vh = new ItemsViewHolder(itemView, OnClick);
            return vh;
        }

        void OnClick(int position)
        {
            ItemClick(this, position);//Aqui deberiamos abrir el dialog
        }

    }
}