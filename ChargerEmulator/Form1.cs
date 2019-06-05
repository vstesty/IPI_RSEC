using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ChargerEmulator
{
    public partial class Form1 : Form
    {
        Raport raport;
        HttpClient client = new HttpClient();
        

        public Form1()
        {
            InitializeComponent();
            raport = new Raport();
            comboBoxChargingPower.SelectedItem = comboBoxChargingPower.Items[0];
        }

        private void TrackBarChargingTime_ValueChanged(object sender, EventArgs e)
        {
            SetParametrs();
        }

        private void SetParametrs()
        {
            raport.ChargingTime = (uint)trackBarChargingTime.Value;
            labelChargingTime.Text = raport.ChargingTime.ToString();

            raport.EnergyConsumed = Math.Round(((double)trackBarChargingTime.Value / 3600) * Convert.ToUInt16(comboBoxChargingPower.Text), 1);
            labelEnergyConsumed.Text = raport.EnergyConsumed.ToString();
        }

        private void ComboBoxChargingPower_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetParametrs();
        }

        private void ButtonClearLog_Click(object sender, EventArgs e)
        {
            richTextBoxLogs.Clear();
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            raport.BusNumber = textBoxBusNumber.Text;
            raport.ChargingPower = comboBoxChargingPower.Text;
            raport.StartChargingTime = DateTime.Now;
            raport.Id = Guid.NewGuid();

            textBoxLocalHost.Enabled = false;
            richTextBoxLogs.AppendText("\r\n" + "Raport is being sent...");
            SendRaportAsync().GetAwaiter();
        }

        
        async Task<Uri> CreateRaportAsync(Raport rap)
        {                    
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/RaportsApi", rap);
            response.EnsureSuccessStatusCode();          
            return new Uri("https://localhost:" + textBoxLocalHost.Text + "/" +response.Headers.Location);
        }

        async Task<bool> SendRaportAsync()
        {

            // Update port    
            if (client.BaseAddress==null) client.BaseAddress = new Uri("https://localhost:" + textBoxLocalHost.Text + "/");            
            client.DefaultRequestHeaders.Accept.Clear();            
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));           
            
            try
            {               
                var url = await CreateRaportAsync(raport); 
                richTextBoxLogs.AppendText("\r\n" +$"Raport created at {url}");
                return true;
            }
            catch (Exception e)
            {
                richTextBoxLogs.AppendText("\r\n" + e.Message);
                MessageBox.Show(e.Message);
                return false;
            }
                        
            
        }
    }
}
