using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LegalDrinking
{
    public partial class MainPage : ContentPage
    {
        private List<string> countryList = new List<string> {
            "United States",
            "Canada",
            "Japan",
            "Iceland",
            "Pakistan"
        };

        private int[] map = new int[] {
            21,
            19,
            20,
            20,
            -1
        };

        public MainPage()
        {
            InitializeComponent();

            countryPicker.ItemsSource = countryList;
            countryPicker.SelectedIndex = 0;

        }

        private void birthPicker_DateSelected(object sender, DateChangedEventArgs e) { computeLegality(); }
        private void countryPicker_SelectedIndexChanged(object sender, EventArgs e) { computeLegality(); }

        private void computeLegality() {
            DateTime date = birthPicker.Date;
            DateTime now = DateTime.Now;
            int days = (int)now.Subtract(date).TotalDays;
            int years = days / 365;

            int mapIndex = countryPicker.SelectedIndex;
            int legalAge = map[mapIndex];

            bool legal = true;
            if (legalAge <= 0) { legal = false; }
            else if (legalAge > years) { legal = false; }

            string howMany = "";
            if (legalAge > 0) { howMany = $" {legalAge - years} More Years!"; }

            qualify.Text = legal ? "You Can Legally Buy Alcohol!" : $"You Can Not Legally Buy Alcohol...{howMany}";
        }
    }
}
