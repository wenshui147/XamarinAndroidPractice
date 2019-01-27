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

namespace 练习App
{
    [Activity(Label = "CallHistoryActivity")]
    public class CallHistoryActivity : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //从意图中获取传递过来的参数
            var phoneNumbers = Intent.Extras.GetStringArrayList("phone_numbers") ?? new string[0]; 
            //将字符串数组显示到列表控件中（ListActivity是视图列表）
            this.ListAdapter = new ArrayAdapter<string>(this,Android.Resource.Layout.SimpleListItem1,phoneNumbers);
            //关于ArrayAdapter中的第二个参数其实就是指定列表中每个项的视图，后面可以通过自定义的方式控制列表项
        }
    }
}