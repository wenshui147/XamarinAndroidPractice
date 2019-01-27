using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace Actity_Liftcycle
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        int count = 1;
        private TextView tv;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            if (savedInstanceState!=null)
            {
                count = savedInstanceState.GetInt("_count");
            }

            tv = FindViewById<TextView>(Resource.Id.textView1);
            tv.Text = count.ToString();
            Button btn = FindViewById<Button>(Resource.Id.button1);
            btn.Click += (s, e) => 
            {
                count++;
                tv.Text = count.ToString();
            };
        }
        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            //保存当前状态
            outState.PutInt("_count", count);

        }
    }
}