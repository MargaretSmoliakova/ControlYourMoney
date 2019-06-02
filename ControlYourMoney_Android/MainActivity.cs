using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;

namespace ControlYourMoney_Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            EditText phoneNumberText = FindViewById<EditText>(Resource.Id.InputTest);
            Button translateButton = FindViewById<Button>(Resource.Id.ButtonTest);

            translateButton.Click += (sender, e) =>
            {
                phoneNumberText.Text = TestButton.MakeTestRequest(phoneNumberText.Text);
            };
        }
    }
}

