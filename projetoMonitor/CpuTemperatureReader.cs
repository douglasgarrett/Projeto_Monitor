﻿using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoMonitor
{
    class CpuTemperatureReader : IDisposable
    {
        private readonly Computer _computer;

        public CpuTemperatureReader()
        {
            _computer = new Computer { GPUEnabled = true };
            _computer.Open();
        }

        public IReadOnlyDictionary<string, float> GetTemperaturesInCelsius()
        {
            var coreAndTemperature = new Dictionary<string, float>();

            foreach (var hardware in _computer.Hardware)
            {
                hardware.Update(); //use hardware.Name to get CPU model
                foreach (var sensor in hardware.Sensors)
                {
                    if ((sensor.SensorType == SensorType.Temperature )  && sensor.Value.HasValue)
                    {
                        coreAndTemperature.Add(sensor.Name, sensor.Value.Value);
                    }
                }
            }

            return coreAndTemperature;
        }

        public void Dispose()
        {
            try
            {
                _computer.Close();
            }
            catch (Exception)
            {
                //ignore closing errors
            }
        }
    }
}
