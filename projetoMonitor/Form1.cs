using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace projetoMonitor
{
    public partial class Form1 : Form
    {

        PerformanceCounter perfCPUCounter = new PerformanceCounter("Processor Information","% Processor Time","_Total");
        CpuTemperatureReader tempReader = new CpuTemperatureReader();
        //PerformanceCounter perfCPUtemperaure = new PerformanceCounter("Thermal Zone Information", "Temperature", @"\_TZ.THRM");
            public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {


             label1.Text = "CPU:" + " " + (int)perfCPUCounter.NextValue() + " " + "%";
          //  label2.Text = (perfCPUtemperaure.NextValue() - 273.15).ToString() + " °C";

            foreach (var temp in tempReader.GetTemperaturesInCelsius()) {

                label2.Text = "GPU "+ temp.Value+ " °C";
               

            }


//  

;        }
    }
}
