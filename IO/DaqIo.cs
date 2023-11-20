
namespace Knv.DAQ
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO.Ports;
    using System.Globalization;
    using System.ComponentModel;
    using System.Drawing.Drawing2D;

    public class DaqIo
    {
        public static DaqIo Instance { get; } = new DaqIo();
        const string GenericTimestampFormat = "yyyy.MM.dd HH:mm:ss";
        public event EventHandler ConnectionChanged;
        public event EventHandler ErrorHappened;
        public bool TracingEnable { get; set; } = false;

        public Queue<string> TraceQueue = new Queue<string>();
        public int TraceLines { get; private set; }

        SerialPort _sp;
        public bool IsOpen
        {
            get
            {
                if (_sp == null)
                    return false;
                else
                    return _sp.IsOpen;
            }
        }

        public int ReadTimeout
        {
            get { return _sp.ReadTimeout; }
            set { _sp.ReadTimeout = value; }
        }

        public static string[] GetPortNames()
        {
            return (SerialPort.GetPortNames());
        }
        static readonly object _syncObject = new object();

        /// <summary>
        /// Srosport Nyitása
        /// </summary>
        /// <param name="port">Port:COMx</param>
        public void Open(string port)
        {
            try
            {
                _sp = new SerialPort(port)
                {
                    ReadTimeout = 1000,
                    BaudRate = 115200,
                    NewLine = "\n"
                };
                _sp.Open();
                _sp.DiscardInBuffer();
                Trace("Serial Port: " + port + " is Open.");
                Test();
                OnConnectionChanged();
            }
            catch (Exception ex)
            {
                _sp?.Close();
                TraceError("IO ERROR Serial Port is: " + port + " Open fail... beacuse:" + ex.Message);
                OnConnectionChanged();
            }
        }

        public void Test()
        {
            if (_sp == null || !_sp.IsOpen)
            {
                Trace("IO ERROR: port is closed.");
            }

            try
            {
                var resp = WriteRead("*OPC?");
                if (resp == null || !(resp == "*OPC" || resp == "*OPC? OK"))
                    Trace("Connection TEST ERROR");
            }
            catch (Exception ex)
            {
                TraceError("IO-ERROR:" + ex.Message);
            }
        }

        public void ExitDfuMode()
        {
            WriteRead("RST");
        }

        public void EnterDfuMode()
        {

            WriteRead("RST");
            System.Threading.Thread.Sleep(1000);


            int temp = _sp.ReadTimeout;
            _sp.ReadTimeout = 20;
            string response = string.Empty;

            for (int i = 0; i < 5; i++)
            {
                try
                {
                    response = WriteRead("DFU");
                    if (response == "OK")
                        break;
                }
                catch (Exception)
                {

                }
            }
            _sp.ReadTimeout = temp;

            if (response != "OK")
                throw new ApplicationException("");
        }


        internal string WriteRead(string request)
        {
            string response = string.Empty;
            Exception exception = null;
            int rxErrors = 0;
            int txErrors = 0;

            do
            {
                if (_sp == null || !_sp.IsOpen)
                {
                    var msg = $"The {_sp.PortName} Serial Port is closed. Please open it.";
                    Trace(msg);
                    OnConnectionChanged();
                    throw new ApplicationException(msg);
                }
                try
                {
                    Trace("Tx: " + request);
                    _sp.WriteLine(request);

                    try
                    {
                        response = _sp.ReadLine().Trim(new char[] { '\0', '\r', '\n' }); ;
                        Trace("Rx: " + response);
                        return response;
                    }
                    catch (Exception ex) //TODO: Nem jol van kezelve a TIMOUT
                    {
                        Trace("Rx ERROR Serial Port is:" + ex.Message);
                        exception = new TimeoutException($"Last Request: {request}", ex);
                        rxErrors++;
                        OnErrorHappened();
                    }
                }
                catch (Exception ex)
                {
                    Trace("Tx ERROR Serial Port is:" + ex.Message);
                    exception = ex;
                    txErrors++;
                    OnErrorHappened();
                }

            } while (rxErrors < 3 && txErrors < 3);

            TraceError("There were three consecutive io error. I close the connection.");
            Close();
            throw exception;
        }

        internal string WriteReadWoTracing(string request)
        {
            string response = string.Empty;
            Exception exception = null;
            int rxErrors = 0;
            int txErrors = 0;

            do
            {
                if (_sp == null || !_sp.IsOpen)
                {
                    var msg = $"The {_sp.PortName} Serial Port is closed. Please open it.";
                    Trace(msg);
                    OnConnectionChanged();
                    throw new ApplicationException(msg);
                }
                try
                {
                    _sp.WriteLine(request);
                    try
                    {
                        response = _sp.ReadLine().Trim(new char[] { '\0', '\r', '\n' }); ;
                        return response;
                    }
                    catch (Exception ex)
                    {
                        exception = new TimeoutException($"Last Request: {request}", ex);
                        rxErrors++;
                        OnErrorHappened();
                    }
                }
                catch (Exception ex)
                {
                    Trace("Tx ERROR Serial Port is:" + ex.Message);
                    exception = ex;
                    txErrors++;
                    OnErrorHappened();
                }

            } while (rxErrors < 3 && txErrors < 3);

            Trace("There were three consecutive io error. I close the connection.");
            Close();
            throw exception;
        }

        public void Close()
        {
            Trace("Serial Port is: " + "Close");
            _sp?.Close();
            OnConnectionChanged();
        }

        internal void Trace(string msg)
        {
            if (TracingEnable)
            {
                TraceLines++;
                TraceQueue.Enqueue(DateTime.Now.ToString(GenericTimestampFormat) + " " + msg);
            }
        }

        internal void TraceError(string errorMsg)
        {
            TraceLines++;
            TraceQueue.Enqueue(DateTime.Now.ToString(GenericTimestampFormat) + " " + errorMsg);
        }

        public void TraceClear()
        {
            TraceQueue.Clear();
            TraceLines = 0;
        }
        protected virtual void OnConnectionChanged()
        {
            EventHandler handler = ConnectionChanged;
            handler?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnErrorHappened()
        {
            EventHandler handler = ErrorHappened;
            handler?.Invoke(this, EventArgs.Empty);
        }
        /// <summary>
        /// Firmware Verziószáma
        /// </summary>
        /// <returns>pl. 1.0.0.0</returns>
        public string GetVersion()
        {
            var resp = WriteRead("*IDN?");
            if (resp == null)
                return "n/a";
            else
                return resp;
        }
        /// <summary>
        /// Processzor egyedi azonsítója, hosza nem változik
        /// </summary>
        /// <returns>pl:20001E354D501320383252</returns>
        public string UniqeId()
        {
            var resp = WriteRead("*UID?");
            if (resp == null)
                return "n/a";
            else
                return resp;
        }
        /// <summary>
        /// Bekapcsolás óta eltelt idő másodpercben
        /// </summary>
        /// <returns>másodperc</returns>
        public int GetUpTime()
        {
            if (int.TryParse(WriteRead("UPTIME?"), NumberStyles.AllowHexSpecifier, CultureInfo.GetCultureInfo("en-US"), out int retval))
                return retval;
            else
                return 0;
        }

        /// <summary>
        /// A panel varáció neve pl: MGUI201222V00-PCREF
        /// </summary>
        /// <returns></returns>
        public string WhoIs()
        {
            var resp = WriteRead("VER?");
            if (resp == null)
                return "n/a";
            else
                return resp;
        }

        public double Ao1
        {
            get
            {
                int adc = int.Parse(WriteRead("AO1?"), NumberStyles.AllowHexSpecifier, CultureInfo.GetCultureInfo("en-US"));
                double value = (3.3 / 4095.0) * adc * 3;
                double rounded = Math.Round(value, 2);
                return rounded;
            }
            set 
            {
                double divVolts = value / 3;
                int adc = (int)(divVolts / (3.3 / 4095.0));
                if (adc >= 4095)
                    adc = 4095;
                WriteRead($"AO1 {adc:X2}");

            }
        }

        public double Ao2
        {
            get
            {
                int adc = int.Parse(WriteRead("AO2?"), NumberStyles.AllowHexSpecifier, CultureInfo.GetCultureInfo("en-US"));
                double value = (3.3 / 4095.0) * adc * 3;
                double rounded = Math.Round(value, 2);
                return rounded;
            }
            set
            {
                double divVolts = value / 3;
                int adc = (int)(divVolts / (3.3 / 4095.0));
                if (adc >= 4095)
                    adc = 4095;
                WriteRead($"AO2 {adc:X2}");
            }
        }

        public double Ai1
        {
            get 
            {
                int adc =  int.Parse(WriteRead("AI1?"), NumberStyles.AllowHexSpecifier, CultureInfo.GetCultureInfo("en-US"));
                double value = (3.3/ 4095.0) * adc * 3.06;
                double rounded = Math.Round(value, 2);
                return rounded;
            }
        }

        public double Ai2
        {
            get
            {
                int adc = int.Parse(WriteRead("AI2?"), NumberStyles.AllowHexSpecifier, CultureInfo.GetCultureInfo("en-US"));
                double value = (3.3 / 4095.0) * adc * 3.06;
                double rounded = Math.Round(value, 2);
                return rounded;
            }
        }

        public double Ai3
        {
            get
            {
                int adc = int.Parse(WriteRead("AI3?"), NumberStyles.AllowHexSpecifier, CultureInfo.GetCultureInfo("en-US"));
                double value = (3.3 / 4095.0) * adc * 3.06;
                double rounded = Math.Round(value, 2);
                return rounded;
            }
        }

        public double Ai4
        {
            get
            {
                int adc = int.Parse(WriteRead("AI4?"), NumberStyles.AllowHexSpecifier, CultureInfo.GetCultureInfo("en-US"));
                double value = (3.3 / 4095.0) * adc * 3.06;
                double rounded = Math.Round(value, 2);
                return rounded;
            }
        }

    }
}
