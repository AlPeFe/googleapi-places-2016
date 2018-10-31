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

namespace B.ViewHolders
{
    public class ItemsViewHolder : RecyclerView.ViewHolder
    {
        public ImageView thumbnail;
        public TextView title;
        public TextView description;

        public ItemsViewHolder(View itemView, Action<int> listener): base(itemView)
        {
            thumbnail = itemView.FindViewById<ImageView>(Resource.Id.thumbnail);
            title = itemView.FindViewById<TextView>(Resource.Id.title);
            description = itemView.FindViewById<TextView>(Resource.Id.des);

            itemView.Click += (sender, e) => listener(AdapterPosition);
        }
    }
}