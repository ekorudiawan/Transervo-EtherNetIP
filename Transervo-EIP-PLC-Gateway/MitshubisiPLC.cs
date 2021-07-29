using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActUtlTypeLib;

namespace Transervo_EIP_PLC_Gateway
{
    class MitshubisiPLCSingleton
    {
        private bool _connected;
        private MitshubisiPLCSingleton() { }
        private static MitshubisiPLCSingleton _instance;
        private static ActUtlType _plc;
        private static readonly object _lock = new object();
        public static MitshubisiPLCSingleton GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new MitshubisiPLCSingleton();
                        _plc = new ActUtlType();
                    }
                }
            }
            return _instance;
        }

        public bool Connected
        {
            get { return _connected; }
            set { _connected = value; }
        }

        public void Connect(int stationNumber)
        {
            if (!_connected)
            {
                _plc.ActLogicalStationNumber = stationNumber;
                _plc.Open();
                _connected = true;
            }
        }

        public void Disconnect()
        {
            if (_connected)
            {
                _plc.Close();
                _connected = false;
            }
        }

        public string GetDeviceInfo()
        {
            string cpuInfo = "";
            int cpuCode;
            if (_connected)
            {
                _plc.GetCpuType(out cpuInfo, out cpuCode);
            }
            return cpuInfo;
        }

        public void ReadInput()
        {
            if (_connected)
            {
                int result;
                _plc.GetDevice("X0", out result);
                if(result == 1)
                {
                    //MachineInput.IAI_IN_POS_1 = true;
                }
                else
                {
                    //MachineInput.IAI_IN_POS_1 = false;
                }

                _plc.GetDevice("X1", out result);
                if (result == 1)
                {
                    //MachineInput.IAI_IN_POS_2 = true;
                }
                else
                {
                    //MachineInput.IAI_IN_POS_2 = false;
                }

                _plc.GetDevice("X2", out result);
                if (result == 1)
                {
                    //MachineInput.IAI_IN_POS_4 = true;
                }
                else
                {
                    //MachineInput.IAI_IN_POS_4 = false;
                }

                _plc.GetDevice("X3", out result);
                if (result == 1)
                {
                    //MachineInput.IAI_IN_MOV = true;
                }
                else
                {
                    //MachineInput.IAI_IN_MOV = false;
                }

                _plc.GetDevice("X4", out result);
                if (result == 1)
                {
                    //MachineInput.IAI_IN_ZONE = true;
                }
                else
                {
                    //MachineInput.IAI_IN_ZONE = false;
                }

                _plc.GetDevice("X5", out result);
                if (result == 1)
                {
                    //MachineInput.IAI_IN_ZONE2 = true;
                }
                else
                {
                    //MachineInput.IAI_IN_ZONE2 = false;
                }

                _plc.GetDevice("X6", out result);
                if (result == 1)
                {
                    //MachineInput.IAI_IN_MAN = true;
                }
                else
                {
                    //MachineInput.IAI_IN_MAN = false;
                }

                _plc.GetDevice("X7", out result);
                if (result == 1)
                {
                    //MachineInput.IAI_IN_HEND = true;
                }
                else
                {
                    //MachineInput.IAI_IN_HEND = false;
                }

                _plc.GetDevice("X10", out result);
                if (result == 1)
                {
                    //MachineInput.IAI_IN_PEND = true;
                }
                else
                {
                    //MachineInput.IAI_IN_PEND = false;
                }

                _plc.GetDevice("X11", out result);
                if (result == 1)
                {
                    //MachineInput.IAI_IN_SVON = true;
                }
                else
                {
                    //MachineInput.IAI_IN_SVON = false;
                }

                _plc.GetDevice("X12", out result);
                if (result == 1)
                {
                    //MachineInput.IAI_IN_EMG = true;
                }
                else
                {
                    //MachineInput.IAI_IN_EMG = false;
                }

                _plc.GetDevice("X13", out result);
                if (result == 1)
                {
                    //MachineInput.IAI_IN_ALM = true;
                }
                else
                {
                    //MachineInput.IAI_IN_ALM = false;
                }

                _plc.GetDevice("X14", out result);
                if (result == 1)
                {
                    //MachineInput.IAI_IN_ALM2 = true;
                }
                else
                {
                    //MachineInput.IAI_IN_ALM2 = false;
                }

                _plc.GetDevice("X15", out result);
                if (result == 1)
                {
                    //MachineInput.B_Emergency = true;
                }
                else
                {
                    //MachineInput.B_Emergency = false;
                }

                _plc.GetDevice("X16", out result);
                if (result == 1)
                {
                    //MachineInput.B_Reset = true;
                }
                else
                {
                    //MachineInput.B_Reset = false;
                }

                _plc.GetDevice("X17", out result);
                if (result == 1)
                {
                    //MachineInput.B_Manual = true;
                }
                else
                {
                    //MachineInput.B_Manual = false;
                }

                _plc.GetDevice("X20", out result);
                if (result == 1)
                {
                    //MachineInput.S_CY1_FW = true;
                }
                else
                {
                    //MachineInput.S_CY1_FW = false;
                }

                _plc.GetDevice("X21", out result);
                if (result == 1)
                {
                    //MachineInput.S_CY1_BW = true;
                }
                else
                {
                    //MachineInput.S_CY1_BW = false;
                }

                _plc.GetDevice("X22", out result);
                if (result == 1)
                {
                    //MachineInput.B_Auto = true;
                }
                else
                {
                    //MachineInput.B_Auto = false;
                }

                _plc.GetDevice("X24", out result);
                if (result == 1)
                {
                    //MachineInput.P_Printer_Alarm1 = true;
                }
                else
                {
                    //MachineInput.P_Printer_Alarm1 = false;
                }

                _plc.GetDevice("X25", out result);
                if (result == 1)
                {
                    //MachineInput.P_Printer_Alarm2 = true;
                }
                else
                {
                    //MachineInput.P_Printer_Alarm2 = false;
                }

                _plc.GetDevice("X26", out result);
                if (result == 1)
                {
                    //MachineInput.P_Printer_Head_Ready = true;
                }
                else
                {
                    //MachineInput.P_Printer_Head_Ready = false;
                }

                _plc.GetDevice("X27", out result);
                if (result == 1)
                {
                    //MachineInput.P_Busy = true;
                }
                else
                {
                    //MachineInput.P_Busy = false;
                }

                _plc.GetDevice("X30", out result);
                if (result == 1)
                {
                    //MachineInput.S_Product_1 = true;
                }
                else
                {
                    //MachineInput.S_Product_1 = false;
                }

                _plc.GetDevice("X31", out result);
                if (result == 1)
                {
                    //MachineInput.S_Product_2 = true;
                }
                else
                {
                    //MachineInput.S_Product_2 = false;
                }

                _plc.GetDevice("X32", out result);
                if (result == 1)
                {
                    //MachineInput.S_Sensor = true;
                }
                else
                {
                    //MachineInput.S_Sensor = false;
                }
            }
        }

        public void ReadData()
        {
            if (_connected)
            {
                int result;

                // Servo 1
                _plc.GetDevice("M700", out result);
                if (result == 1)
                {
                    PLC.DataInput.Servo1.PIN0 = true;
                }
                else
                {
                    PLC.DataInput.Servo1.PIN0 = false;
                }

                _plc.GetDevice("M701", out result);
                if (result == 1)
                {
                    PLC.DataInput.Servo1.PIN1 = true;
                }
                else
                {
                    PLC.DataInput.Servo1.PIN1 = false;
                }

                _plc.GetDevice("M702", out result);
                if (result == 1)
                {
                    PLC.DataInput.Servo1.PIN2 = true;
                }
                else
                {
                    PLC.DataInput.Servo1.PIN2 = false;
                }

                _plc.GetDevice("M703", out result);
                if (result == 1)
                {
                    PLC.DataInput.Servo1.PIN3 = true;
                }
                else
                {
                    PLC.DataInput.Servo1.PIN3 = false;
                }

                _plc.GetDevice("M704", out result);
                if (result == 1)
                {
                    PLC.DataInput.Servo1.PIN4 = true;
                }
                else
                {
                    PLC.DataInput.Servo1.PIN4 = false;
                }

                _plc.GetDevice("M705", out result);
                if (result == 1)
                {
                    PLC.DataInput.Servo1.PIN5 = true;
                }
                else
                {
                    PLC.DataInput.Servo1.PIN5 = false;
                }

                _plc.GetDevice("M706", out result);
                if (result == 1)
                {
                    PLC.DataInput.Servo1.PIN6 = true;
                }
                else
                {
                    PLC.DataInput.Servo1.PIN6 = false;
                }

                _plc.GetDevice("M707", out result);
                if (result == 1)
                {
                    PLC.DataInput.Servo1.PIN7 = true;
                }
                else
                {
                    PLC.DataInput.Servo1.PIN7 = false;
                }

                _plc.GetDevice("M708", out result);
                if (result == 1)
                {
                    PLC.DataInput.Servo1.JOG_PLUS = true;
                }
                else
                {
                    PLC.DataInput.Servo1.JOG_PLUS = false;
                }

                _plc.GetDevice("M709", out result);
                if (result == 1)
                {
                    PLC.DataInput.Servo1.JOG_MIN = true;
                }
                else
                {
                    PLC.DataInput.Servo1.JOG_MIN = false;
                }

                _plc.GetDevice("M710", out result);
                if (result == 1)
                {
                    PLC.DataInput.Servo1.MANUAL = true;
                }
                else
                {
                    PLC.DataInput.Servo1.MANUAL = false;
                }

                _plc.GetDevice("M711", out result);
                if (result == 1)
                {
                    PLC.DataInput.Servo1.ORG = true;
                }
                else
                {
                    PLC.DataInput.Servo1.ORG = false;
                }

                _plc.GetDevice("M712", out result);
                if (result == 1)
                {
                    PLC.DataInput.Servo1._LOCK = true;
                }
                else
                {
                    PLC.DataInput.Servo1._LOCK = false;
                }

                _plc.GetDevice("M713", out result);
                if (result == 1)
                {
                    PLC.DataInput.Servo1.START = true;
                }
                else
                {
                    PLC.DataInput.Servo1.START = false;
                }

                _plc.GetDevice("M714", out result);
                if (result == 1)
                {
                    PLC.DataInput.Servo1.RESET = true;
                }
                else
                {
                    PLC.DataInput.Servo1.RESET = false;
                }

                _plc.GetDevice("M715", out result);
                if (result == 1)
                {
                    PLC.DataInput.Servo1.SERVO = true;
                }
                else
                {
                    PLC.DataInput.Servo1.SERVO = false;
                }

                // Servo2
                _plc.GetDevice("M800", out result);
                if (result == 1)
                {
                    PLC.DataInput.Servo2.PIN0 = true;
                }
                else
                {
                    PLC.DataInput.Servo2.PIN0 = false;
                }

                _plc.GetDevice("M801", out result);
                if (result == 1)
                {
                    PLC.DataInput.Servo2.PIN1 = true;
                }
                else
                {
                    PLC.DataInput.Servo2.PIN1 = false;
                }

                _plc.GetDevice("M802", out result);
                if (result == 1)
                {
                    PLC.DataInput.Servo2.PIN2 = true;
                }
                else
                {
                    PLC.DataInput.Servo2.PIN2 = false;
                }

                _plc.GetDevice("M803", out result);
                if (result == 1)
                {
                    PLC.DataInput.Servo2.PIN3 = true;
                }
                else
                {
                    PLC.DataInput.Servo2.PIN3 = false;
                }

                _plc.GetDevice("M804", out result);
                if (result == 1)
                {
                    PLC.DataInput.Servo2.PIN4 = true;
                }
                else
                {
                    PLC.DataInput.Servo2.PIN4 = false;
                }

                _plc.GetDevice("M805", out result);
                if (result == 1)
                {
                    PLC.DataInput.Servo2.PIN5 = true;
                }
                else
                {
                    PLC.DataInput.Servo2.PIN5 = false;
                }

                _plc.GetDevice("M806", out result);
                if (result == 1)
                {
                    PLC.DataInput.Servo2.PIN6 = true;
                }
                else
                {
                    PLC.DataInput.Servo2.PIN6 = false;
                }

                _plc.GetDevice("M807", out result);
                if (result == 1)
                {
                    PLC.DataInput.Servo2.PIN7 = true;
                }
                else
                {
                    PLC.DataInput.Servo2.PIN7 = false;
                }

                _plc.GetDevice("M808", out result);
                if (result == 1)
                {
                    PLC.DataInput.Servo2.JOG_PLUS = true;
                }
                else
                {
                    PLC.DataInput.Servo2.JOG_PLUS = false;
                }

                _plc.GetDevice("M809", out result);
                if (result == 1)
                {
                    PLC.DataInput.Servo2.JOG_MIN = true;
                }
                else
                {
                    PLC.DataInput.Servo2.JOG_MIN = false;
                }

                _plc.GetDevice("M810", out result);
                if (result == 1)
                {
                    PLC.DataInput.Servo2.MANUAL = true;
                }
                else
                {
                    PLC.DataInput.Servo2.MANUAL = false;
                }

                _plc.GetDevice("M811", out result);
                if (result == 1)
                {
                    PLC.DataInput.Servo2.ORG = true;
                }
                else
                {
                    PLC.DataInput.Servo2.ORG = false;
                }

                _plc.GetDevice("M812", out result);
                if (result == 1)
                {
                    PLC.DataInput.Servo2._LOCK = true;
                }
                else
                {
                    PLC.DataInput.Servo2._LOCK = false;
                }

                _plc.GetDevice("M813", out result);
                if (result == 1)
                {
                    PLC.DataInput.Servo2.START = true;
                }
                else
                {
                    PLC.DataInput.Servo2.START = false;
                }

                _plc.GetDevice("M814", out result);
                if (result == 1)
                {
                    PLC.DataInput.Servo2.RESET = true;
                }
                else
                {
                    PLC.DataInput.Servo2.RESET = false;
                }

                _plc.GetDevice("M815", out result);
                if (result == 1)
                {
                    PLC.DataInput.Servo2.SERVO = true;
                }
                else
                {
                    PLC.DataInput.Servo2.SERVO = false;
                }
            }
        }
        // Dipakai untuk mengetahui semua status IO
        public void ReadAll()
        {
            ReadInput();
            ReadData();
            
            if (_connected)
            {
                // Initial Output Value
                int result;
                _plc.GetDevice("Y1", out result);
                if (result == 1)
                {
                    //MachineOutput.L_Mc_On = true;
                }
                else
                {
                    //MachineOutput.L_Mc_On = false;
                }

                _plc.GetDevice("Y2", out result);
                if (result == 1)
                {
                    //MachineOutput.L_Auto_Cyc = true;
                }
                else
                {
                    //MachineOutput.L_Auto_Cyc = false;
                }

                _plc.GetDevice("Y3", out result);
                if (result == 1)
                {
                    //MachineOutput.L_Manual_Setting = true;
                }
                else
                {
                    //MachineOutput.L_Manual_Setting = false;
                }

                _plc.GetDevice("Y4", out result);
                if (result == 1)
                {
                    //MachineOutput.L_Unloading = true;
                }
                else
                {
                    //MachineOutput.L_Unloading = false;
                }

                _plc.GetDevice("Y5", out result);
                if (result == 1)
                {
                    //MachineOutput.L_Alarm = true;
                }
                else
                {
                    //MachineOutput.L_Alarm = false;
                }

                _plc.GetDevice("Y12", out result);
                if (result == 1)
                {
                    //MachineOutput.L_Rotating = true;
                }
                else
                {
                    //MachineOutput.L_Rotating = false;
                }

                _plc.GetDevice("Y13", out result);
                if (result == 1)
                {
                    //MachineOutput.Y_CY1_FW = true;
                }
                else
                {
                    //MachineOutput.Y_CY1_FW = false;
                }

                _plc.GetDevice("Y14", out result);
                if (result == 1)
                {
                    //MachineOutput.Y_CY1_BW = true;
                }
                else
                {
                    //MachineOutput.Y_CY1_BW = false;
                }

                _plc.GetDevice("Y24", out result);
                if (result == 1)
                {
                    //MachineOutput.P_Trigger = true;
                }
                else
                {
                    //MachineOutput.P_Trigger = false;
                }

                _plc.GetDevice("Y25", out result);
                if (result == 1)
                {
                    //MachineOutput.IAI_EMERGENCY_RELAY = true;
                }
                else
                {
                    //MachineOutput.IAI_EMERGENCY_RELAY = false;
                }

                _plc.GetDevice("Y26", out result);
                if (result == 1)
                {
                    //MachineOutput.IAI_OUT_COM_1 = true;
                }
                else
                {
                    //MachineOutput.IAI_OUT_COM_1 = false;
                }

                _plc.GetDevice("Y27", out result);
                if (result == 1)
                {
                    //MachineOutput.IAI_OUT_COM_2 = true;
                }
                else
                {
                    //MachineOutput.IAI_OUT_COM_2 = false;
                }

                _plc.GetDevice("Y30", out result);
                if (result == 1)
                {
                    //MachineOutput.IAI_OUT_COM_4 = true;
                }
                else
                {
                    //MachineOutput.IAI_OUT_COM_4 = false;
                }

                _plc.GetDevice("Y31", out result);
                if (result == 1)
                {
                    //MachineOutput.IAI_OUT_BRAKE = true;
                }
                else
                {
                    //MachineOutput.IAI_OUT_BRAKE = false;
                }

                _plc.GetDevice("Y32", out result);
                if (result == 1)
                {
                    //MachineOutput.IAI_OUT_OPMODE = true;
                }
                else
                {
                    //MachineOutput.IAI_OUT_OPMODE = false;
                }

                _plc.GetDevice("Y33", out result);
                if (result == 1)
                {
                    //MachineOutput.IAI_OUT_HOME = true;
                }
                else
                {
                    //MachineOutput.IAI_OUT_HOME = false;
                }

                _plc.GetDevice("Y34", out result);
                if (result == 1)
                {
                    //MachineOutput.IAI_OUT_PAUSE = true;
                }
                else
                {
                    //MachineOutput.IAI_OUT_PAUSE = false;
                }

                _plc.GetDevice("Y35", out result);
                if (result == 1)
                {
                    //MachineOutput.IAI_OUT_START = true;
                }
                else
                {
                    //MachineOutput.IAI_OUT_START = false;
                }

                _plc.GetDevice("Y36", out result);
                if (result == 1)
                {
                    //MachineOutput.IAI_OUT_RESET = true;
                }
                else
                {
                    //MachineOutput.IAI_OUT_RESET = false;
                }

                _plc.GetDevice("Y37", out result);
                if (result == 1)
                {
                    //MachineOutput.IAI_OUT_SVON = true;
                }
                else
                {
                    //MachineOutput.IAI_OUT_SVON = false;
                }
            }
        }

        public void WriteOutput()
        {
            if(_connected)
            {
                
            }
        }

        public void WriteData()
        {
            if (_connected)
            {
                // Servo1
                if (PLC.DataOutput.Servo1.POUT0)
                {
                    _plc.SetDevice("M720", 1);
                }
                else
                {
                    _plc.SetDevice("M720", 0);
                }

                if (PLC.DataOutput.Servo1.POUT1)
                {
                    _plc.SetDevice("M721", 1);
                }
                else
                {
                    _plc.SetDevice("M721", 0);
                }

                if (PLC.DataOutput.Servo1.POUT2)
                {
                    _plc.SetDevice("M722", 1);
                }
                else
                {
                    _plc.SetDevice("M722", 0);
                }

                if (PLC.DataOutput.Servo1.POUT3)
                {
                    _plc.SetDevice("M723", 1);
                }
                else
                {
                    _plc.SetDevice("M723", 0);
                }

                if (PLC.DataOutput.Servo1.POUT4)
                {
                    _plc.SetDevice("M724", 1);
                }
                else
                {
                    _plc.SetDevice("M724", 0);
                }

                if (PLC.DataOutput.Servo1.POUT5)
                {
                    _plc.SetDevice("M725", 1);
                }
                else
                {
                    _plc.SetDevice("M725", 0);
                }

                if (PLC.DataOutput.Servo1.POUT6)
                {
                    _plc.SetDevice("M726", 1);
                }
                else
                {
                    _plc.SetDevice("M726", 0);
                }

                if (PLC.DataOutput.Servo1.POUT7)
                {
                    _plc.SetDevice("M727", 1);
                }
                else
                {
                    _plc.SetDevice("M727", 0);
                }

                if (PLC.DataOutput.Servo1.OUT0)
                {
                    _plc.SetDevice("M728", 1);
                }
                else
                {
                    _plc.SetDevice("M728", 0);
                }

                if (PLC.DataOutput.Servo1.OUT1)
                {
                    _plc.SetDevice("M729", 1);
                }
                else
                {
                    _plc.SetDevice("M729", 0);
                }

                if (PLC.DataOutput.Servo1.OUT2)
                {
                    _plc.SetDevice("M730", 1);
                }
                else
                {
                    _plc.SetDevice("M730", 0);
                }

                if (PLC.DataOutput.Servo1.OUT3)
                {
                    _plc.SetDevice("M731", 1);
                }
                else
                {
                    _plc.SetDevice("M731", 0);
                }

                if (PLC.DataOutput.Servo1.BUSY)
                {
                    _plc.SetDevice("M732", 1);
                }
                else
                {
                    _plc.SetDevice("M732", 0);
                }

                if (PLC.DataOutput.Servo1.END)
                {
                    _plc.SetDevice("M733", 1);
                }
                else
                {
                    _plc.SetDevice("M733", 0);
                }

                if (PLC.DataOutput.Servo1._ALARM)
                {
                    _plc.SetDevice("M734", 1);
                }
                else
                {
                    _plc.SetDevice("M734", 0);
                }

                if (PLC.DataOutput.Servo1.SRV_S)
                {
                    _plc.SetDevice("M735", 1);
                }
                else
                {
                    _plc.SetDevice("M735", 0);
                }

                // Servo2
                if (PLC.DataOutput.Servo2.POUT0)
                {
                    _plc.SetDevice("M820", 1);
                }
                else
                {
                    _plc.SetDevice("M820", 0);
                }

                if (PLC.DataOutput.Servo2.POUT1)
                {
                    _plc.SetDevice("M821", 1);
                }
                else
                {
                    _plc.SetDevice("M821", 0);
                }

                if (PLC.DataOutput.Servo2.POUT2)
                {
                    _plc.SetDevice("M822", 1);
                }
                else
                {
                    _plc.SetDevice("M822", 0);
                }

                if (PLC.DataOutput.Servo2.POUT3)
                {
                    _plc.SetDevice("M823", 1);
                }
                else
                {
                    _plc.SetDevice("M823", 0);
                }

                if (PLC.DataOutput.Servo2.POUT4)
                {
                    _plc.SetDevice("M824", 1);
                }
                else
                {
                    _plc.SetDevice("M824", 0);
                }

                if (PLC.DataOutput.Servo2.POUT5)
                {
                    _plc.SetDevice("M825", 1);
                }
                else
                {
                    _plc.SetDevice("M825", 0);
                }

                if (PLC.DataOutput.Servo2.POUT6)
                {
                    _plc.SetDevice("M826", 1);
                }
                else
                {
                    _plc.SetDevice("M826", 0);
                }

                if (PLC.DataOutput.Servo2.POUT7)
                {
                    _plc.SetDevice("M827", 1);
                }
                else
                {
                    _plc.SetDevice("M827", 0);
                }

                if (PLC.DataOutput.Servo2.OUT0)
                {
                    _plc.SetDevice("M828", 1);
                }
                else
                {
                    _plc.SetDevice("M828", 0);
                }

                if (PLC.DataOutput.Servo2.OUT1)
                {
                    _plc.SetDevice("M829", 1);
                }
                else
                {
                    _plc.SetDevice("M829", 0);
                }

                if (PLC.DataOutput.Servo2.OUT2)
                {
                    _plc.SetDevice("M830", 1);
                }
                else
                {
                    _plc.SetDevice("M830", 0);
                }

                if (PLC.DataOutput.Servo2.OUT3)
                {
                    _plc.SetDevice("M831", 1);
                }
                else
                {
                    _plc.SetDevice("M831", 0);
                }

                if (PLC.DataOutput.Servo2.BUSY)
                {
                    _plc.SetDevice("M832", 1);
                }
                else
                {
                    _plc.SetDevice("M832", 0);
                }

                if (PLC.DataOutput.Servo2.END)
                {
                    _plc.SetDevice("M833", 1);
                }
                else
                {
                    _plc.SetDevice("M833", 0);
                }

                if (PLC.DataOutput.Servo2._ALARM)
                {
                    _plc.SetDevice("M834", 1);
                }
                else
                {
                    _plc.SetDevice("M834", 0);
                }

                if (PLC.DataOutput.Servo2.SRV_S)
                {
                    _plc.SetDevice("M835", 1);
                }
                else
                {
                    _plc.SetDevice("M835", 0);
                }
            }
        }

        public void ReadWrite()
        {
            ReadInput();
            ReadData();
            // WriteOutput();
            WriteData();
        }
    }   
}
