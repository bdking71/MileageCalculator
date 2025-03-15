using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mileage_Calculator
{
    /// <summary>
    /// Main form for the Mileage Calculator application. It calculates the driving distance between two addresses.
    /// </summary>
    public partial class Form1 : Form
    {
        private OpenStreetMapDistance distanceCalculator;

        /// <summary>
        /// Initializes the form and sets up the OpenStreetMapDistance calculator.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            distanceCalculator = new OpenStreetMapDistance("MyApp", "1.0", "contact@myapp.com");
        }

        /// <summary>
        /// Event handler for the form load event. Currently not used.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Event handler for the "Get Mileage" button click event. Calculates the driving distance between two addresses.
        /// </summary>
        /// <param name="sender">The source of the event (button click).</param>
        /// <param name="e">Event arguments.</param>
        private async void btnGetMileage_Click(object sender, EventArgs e)
        {
            string fromAddress = tbFrom.Text.Trim();
            string toAddress = tbToAddress.Text.Trim();

            if (string.IsNullOrEmpty(fromAddress) || string.IsNullOrEmpty(toAddress))
            {
                MessageBox.Show("Please enter both addresses.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnGetMileage.Enabled = false;
            btnGetMileage.Text = "Calculating...";

            try
            {
                double distanceKm = await distanceCalculator.GetDrivingDistanceAsync(fromAddress, toAddress);
                double distanceMiles = ConvertKmToMiles(distanceKm);

                tbDistance.Text = distanceMiles.ToString("0.00");
            }
            finally
            {
                btnGetMileage.Enabled = true;
                btnGetMileage.Text = "Get Mileage";
            }
        }

        /// <summary>
        /// Converts a distance in kilometers to miles.
        /// </summary>
        /// <param name="kilometers">The distance in kilometers.</param>
        /// <returns>The distance in miles.</returns>
        public static double ConvertKmToMiles(double kilometers)
        {
            return kilometers * 0.621371;
        }

    }
}
