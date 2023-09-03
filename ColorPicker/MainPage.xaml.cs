using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace ColorPicker
{
    public partial class MainPage : ContentPage
    {
        bool isRandom = false;
        string hexValue;

        public MainPage()
        {
            InitializeComponent();
        }

        private void SliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (!isRandom)
            {
                var red = sldRed.Value;
                var green = sldGreen.Value;
                var blue = sldBlue.Value;

                Color color = Color.FromRgb(red, green, blue);
                SetColorAndHexValue(color);
            }
        }

        private void SetColorAndHexValue(Color color)
        {
            Container.BackgroundColor = color;
            sts.StatusBarColor = color;
            hexValue = color.ToHex();
            lblHex.Text = hexValue;
        }

        private void RandomColor(object sender, EventArgs e)
        {
            isRandom = true;
            Random randomValue = new Random();
            var redColor = randomValue.Next(0, 256);
            var greenColor = randomValue.Next(0, 256);
            var blueColor = randomValue.Next(0, 256);

            Color randomColor = Color.FromRgb(redColor, greenColor, blueColor);
            sldRed.Value = randomColor.Red;
            sldGreen.Value = randomColor.Green;
            sldBlue.Value = randomColor.Blue;
            SetColorAndHexValue(randomColor);
            isRandom = false;
        }

        private async void CopyClick(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(hexValue);
            await Toast.Make($"{hexValue} Hex value copied", ToastDuration.Short).Show();
        }
    }
}