using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using AlertDialog = Android.App.AlertDialog;

namespace 练习App
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            EditText phoneNumberText = FindViewById<EditText>(Resource.Id.editText1);
            Button translateButton = (Button)FindViewById(Resource.Id.TranslateButton);
            Button callButton = FindViewById<Button>(Resource.Id.CallButton);
            callButton.Enabled = false;
            string translateNumber = string.Empty;
            translateButton.Click += (s, e) => {
                translateNumber = PhoneTranslator.ToNumber(phoneNumberText.Text);
                if (string.IsNullOrEmpty(translateNumber))
                {
                    callButton.Text = "Call";
                    callButton.Enabled = false;
                }
                else
                {
                    callButton.Text = "Call" + translateNumber;
                    callButton.Enabled = true;
                }
            };
            callButton.Click += (s, e) => 
            {
                //对话框
                var callDialog = new AlertDialog.Builder(this);

                //对话框内容
                callDialog.SetMessage("Call" + translateNumber + "?");


                
                //拨打按钮
                callDialog.SetNegativeButton("Call", delegate          //SetPositiveButton
                {
                    //使用意图拨打电话
                    var callIntent = new Intent(Intent.ActionCall);

                    //将需要拨打的电话设置为意图的参数
                    callIntent.SetData(Android.Net.Uri.Parse("tel:" + translateNumber));

                    StartActivity(callIntent);
                });
                //取消按钮
                callDialog.SetNeutralButton("Cancel", delegate { });
                callDialog.Show();

            };
        }
    }
}