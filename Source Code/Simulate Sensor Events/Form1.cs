using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulate_Sensor_Events
{
    public partial class Form1 : Form
    {
        string eventHubName = ConfigurationManager.AppSettings["inputeventhub"];
        string connectionString = ConfigurationManager.AppSettings["servicebusconnectionstring"];
        Random random = new Random();
        int countEventsSent = 0;
        string[] machines = { "TISensorTagB", "TISensorTagB", "TISensorTagB" };

        double lowtemp, hightemp, lowhumidity, highhumidity;
        string machineName;

        public Form1()
        {
            InitializeComponent();
           
        }

        private async void btnSimulateEvent_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            
            richtextStatus.Text = "Sending events now ....";

            lowtemp = double.Parse(ConfigurationManager.AppSettings["lowtemp"]);
            hightemp = double.Parse(ConfigurationManager.AppSettings["hightemp"]);
            lowhumidity = double.Parse(ConfigurationManager.AppSettings["lowhumidity"]);
            highhumidity = double.Parse(ConfigurationManager.AppSettings["highhumidity"]);


            while (true)
            {
                //introduce spike after a few normal events
                if (countEventsSent++ > 600)
                {
                    countEventsSent = 0;
                    btnSpike_Click(sender, e);
                }
                



                machineName = machines[random.Next(0, 2)];
                try
                {
                    await SendDataToEH();

                    richtextStatus.ForeColor = Color.Black;
                }
                catch (Exception exception)
                {
                    //Console.ForegroundColor = ConsoleColor.Red;
                    //Console.WriteLine("{0} > Exception: {1}", DateTime.Now.ToString(), exception.Message);
                    //Console.ResetColor();
                    richtextStatus.ForeColor = Color.Red;
                    richtextStatus.Text = string.Format("{0} > Exception: {1}", DateTime.Now.ToString(), exception.Message);                    
                }

                Cursor.Current = Cursors.Default;

                await Task.Delay(1000);
            }
        }


        private async Task SendDataToEH()
        {
            var eventHubClient = EventHubClient.CreateFromConnectionString(connectionString, eventHubName);

            double rand = 0;

            if (countEventsSent % 5 == 0)
            {
                rand = random.Next(-50,50) ;
                rand = rand / 100;

            }
            else
            {
                rand = 0;
            }

            lowtemp += rand;
            lowhumidity += rand;

            var info = new SensorData()
            {
                //temp = Math.Round(lowtemp + random.NextDouble() * (hightemp - lowtemp), 2),
                //hmdt = Math.Round(lowhumidity + random.NextDouble() * (highhumidity - lowhumidity), 2),
                
                temp = Math.Round(lowtemp, 2),
                hmdt = Math.Round(lowhumidity,2),
                
                time = DateTime.UtcNow,
                dspl = machineName
            };

            var serializedString = JsonConvert.SerializeObject(info);
            EventData data = new EventData(Encoding.UTF8.GetBytes(serializedString));
            //{
            //    PartitionKey = info.productId.ToString()
            //};

            // Set user properties if needed
            data.Properties.Add("Type", "Telemetry_" + DateTime.Now.ToLongTimeString());
            //Console.WriteLine("{0} > Sending message: {1}", DateTime.Now.ToString(), data.ToString());                                        
            richtextStatus.Text = string.Format("{0} > Sending message: {1}", DateTime.Now.ToString(), serializedString.ToString());
            //await eventHubClient.SendAsync(new EventData(Encoding.UTF8.GetBytes(data.ToString())));
            await eventHubClient.SendAsync(data);
        }

        private async void btnSpike_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            lowtemp = 79;
            hightemp = 80;
            lowhumidity = 60;
            highhumidity = 65;

            machineName = machines[0];

            for ( int i=1; i<10; i++)
            {
                try
                {
                    machineName = machines[0];
                    await SendDataToEH();

                    richtextStatus.ForeColor = Color.Black;
                }
                catch (Exception exception)
                {
                    //Console.ForegroundColor = ConsoleColor.Red;
                    //Console.WriteLine("{0} > Exception: {1}", DateTime.Now.ToString(), exception.Message);
                    //Console.ResetColor();
                    richtextStatus.ForeColor = Color.Red;
                    richtextStatus.Text = string.Format("{0} > Exception: {1}", DateTime.Now.ToString(), exception.Message);
                }

                await Task.Delay(200);
            }

            Cursor.Current = Cursors.Default;

            btnSimulateEvent_Click(sender, e);

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            richtextStatus.Text = "Not sending any event";
        }

       
    }
}
