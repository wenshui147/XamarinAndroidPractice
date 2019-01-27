using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using System.Net;
using System.IO;
using System.Json;
using System.Linq;

namespace NetJsonList
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity// ListActivity
    {
        TextView tv;
        class Test : Java.Lang.Object
        {
            public string Results { get; set; }
        }

        Test t;
      
    protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            tv = FindViewById<TextView>(Resource.Id.textView1);
            var testtv = FindViewById<TextView>(Resource.Id.textView2);
            LoadXamarin();
        }

        //重写该方法
        public override Java.Lang.Object OnRetainNonConfigurationInstance()
        {
            return t;
        }

        public async void LoadXamarin()
        {
            ////测试
            //string url = "http://www.xamarin-cn.com/test.json";
            ////创建请求
            //var httpReq = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            ////获取响应
            //var httpRes = (HttpWebResponse)httpReq.GetResponse();
            ////读取响应字符串
            //string text = new StreamReader(httpRes.GetResponseStream()).ReadToEnd();
            //tv.Text = text;

            //////测试
            //string url = "http://www.xamarin-cn.com/test.json";
            //var httpReq = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            ////httpReq.BeginGetResponse(new AsyncCallback(ReadXamarin),httpReq);
            //var httpRes = (HttpWebResponse)await httpReq.GetResponseAsync();
            //if (httpRes.StatusCode==HttpStatusCode.OK)
            //{
            //    //var text = new StreamReader(httpRes.GetResponseStream()).ReadToEnd();
            //    //tv.Text = text;
            //    var text = (JsonObject)JsonObject.Load(httpRes.GetResponseStream());
            //    var request = (from item in (JsonArray)text["T"]
            //                   select item.ToString()
            //                 ).ToArray();
            //    ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, request);
            //    //tv.Text = text;
            //}

            t = LastNonConfigurationInstance as Test;
            //判断是否存在之前的状态
            if (t != null)
            {
                //ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, t.Results);
                tv.Text = t.Results;
            }
            else
            {

                //测试用
                string url = "https://api.androidhive.info/volley/person_object.json";//"http://www.xamarin-cn.com/test.json";

                //创建一个请求
                var httpReq = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
                var httpRes = (HttpWebResponse)await httpReq.GetResponseAsync();
                if (httpRes.StatusCode == HttpStatusCode.OK)
                {
                    var text = JsonObject.Load(httpRes.GetResponseStream()).ToString();
                    //var result = (from item in text
                    //select item.ToString()).ToArray();
                    t = new Test()
                    {
                        Results = text
                    };
                   
                    // ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, result);
                    tv.Text =  t.Results;
                }
            }

        }

        public void ReadXamarin(IAsyncResult asyn)
        {
            var httpReq = (HttpWebRequest)asyn.AsyncState;
            //获取响应
            //判断获取是否成功
            using (var httpRes=(HttpWebResponse)httpReq.EndGetResponse(asyn))
            {
                //判断是否获取响应
                if (httpRes.StatusCode==HttpStatusCode.OK)
                {
                    //读取响应
                    var text = new StreamReader(httpRes.GetResponseStream()).ReadToEnd();
                    RunOnUiThread(() =>
                    {
                        tv.Text = text;
                    });
                }
            }
        }
    }
}