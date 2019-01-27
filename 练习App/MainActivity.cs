using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using AlertDialog = Android.App.AlertDialog;
using System.Collections.Generic;

namespace 练习App
{
    [Activity(Label = "Phone_Droid", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity       
    {
        static readonly List<string> phoneNumbers = new List<string>();
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

            Button callHistoryButton = FindViewById<Button>(Resource.Id.callHistoryButton);
            callHistoryButton.Click += (e, t) =>
            {
                //指定意图需要打开的活动
                var intent = new Intent(this, typeof(CallHistoryActivity));
                //设置意图传递参数
                intent.PutStringArrayListExtra("phone_numbers", phoneNumbers);
                StartActivity(intent);
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
                    //将电话加到历史记录列表中
                    phoneNumbers.Add(translateNumber);
                    callHistoryButton.Enabled = true;
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