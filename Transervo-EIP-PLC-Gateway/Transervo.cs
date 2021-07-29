using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sres.Net.EEIP;

namespace Transervo_EIP_PLC_Gateway
{
    
    class TranservoSingleton
    {
        private bool _connected;
        private TranservoSingleton() { }
        private static TranservoSingleton _instance;
        private static EEIPClient _eeipClient;
        private static readonly object _lock = new object();
        public static TranservoSingleton GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new TranservoSingleton();
                        _eeipClient = new EEIPClient();
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

        public void Connect(string ipAddress1)
        {
            if (!_connected)
            {
                _eeipClient.RegisterSession(ipAddress1);

                //Parameters from Originator -> Target
                _eeipClient.O_T_InstanceID = 150;              //Instance ID of the Output Assembly
                _eeipClient.O_T_Length = 48;                     //The Method "Detect_O_T_Length" detect the Length using an UCMM Message
                _eeipClient.O_T_RealTimeFormat = Sres.Net.EEIP.RealTimeFormat.Header32Bit;   //Header Format
                _eeipClient.O_T_OwnerRedundant = false;
                _eeipClient.O_T_Priority = Sres.Net.EEIP.Priority.Scheduled;
                _eeipClient.O_T_VariableLength = true;
                _eeipClient.O_T_ConnectionType = Sres.Net.EEIP.ConnectionType.Point_to_Point;
                _eeipClient.RequestedPacketRate_O_T = 2000;        //500ms is the Standard value

                //Parameters from Target -> Originator
                _eeipClient.T_O_InstanceID = 100;
                _eeipClient.T_O_Length = 48;
                _eeipClient.T_O_RealTimeFormat = Sres.Net.EEIP.RealTimeFormat.Modeless;
                _eeipClient.T_O_OwnerRedundant = false;
                _eeipClient.T_O_Priority = Sres.Net.EEIP.Priority.Scheduled;
                _eeipClient.T_O_VariableLength = true;
                _eeipClient.T_O_ConnectionType = Sres.Net.EEIP.ConnectionType.Multicast;
                _eeipClient.RequestedPacketRate_T_O = 2000;    //RPI in  500ms is the Standard value

                _eeipClient.ForwardOpen();
                
                _connected = true;
            }
        }

        public void Disconnect()
        {
            if (_connected)
            {
                _eeipClient.ForwardClose();
                _eeipClient.UnRegisterSession();
                
                _connected = false;
            }
        }

        public void ReadData()
        {
            if (_connected)
            {
                byte[] data;

                //Read the Inputs Transfered form Target -> Originator
                data = _eeipClient.GetAttributeSingle(4, 100, 3);
                Servo1.TO.POUT0 = EEIPClient.ToBool(data[0], 0);
                Servo1.TO.POUT1 = EEIPClient.ToBool(data[0], 1);
                Servo1.TO.POUT2 = EEIPClient.ToBool(data[0], 2);
                Servo1.TO.POUT3 = EEIPClient.ToBool(data[0], 3);
                Servo1.TO.POUT4 = EEIPClient.ToBool(data[0], 4);
                Servo1.TO.POUT5 = EEIPClient.ToBool(data[0], 5);
                Servo1.TO.POUT6 = EEIPClient.ToBool(data[0], 6);
                Servo1.TO.POUT7 = EEIPClient.ToBool(data[0], 7);
                Servo1.TO.OUT0 = EEIPClient.ToBool(data[1], 0);
                Servo1.TO.OUT1 = EEIPClient.ToBool(data[1], 1);
                Servo1.TO.OUT2 = EEIPClient.ToBool(data[1], 2);
                Servo1.TO.OUT3 = EEIPClient.ToBool(data[1], 3);
                Servo1.TO.BUSY = EEIPClient.ToBool(data[1], 4);
                Servo1.TO.END = EEIPClient.ToBool(data[1], 5);
                Servo1.TO._ALARM = EEIPClient.ToBool(data[1], 6);
                Servo1.TO.SRV_S = EEIPClient.ToBool(data[1], 7);
                
                Servo2.TO.POUT0 = EEIPClient.ToBool(data[12], 0);
                Servo2.TO.POUT1 = EEIPClient.ToBool(data[12], 1);
                Servo2.TO.POUT2 = EEIPClient.ToBool(data[12], 2);
                Servo2.TO.POUT3 = EEIPClient.ToBool(data[12], 3);
                Servo2.TO.POUT4 = EEIPClient.ToBool(data[12], 4);
                Servo2.TO.POUT5 = EEIPClient.ToBool(data[12], 5);
                Servo2.TO.POUT6 = EEIPClient.ToBool(data[12], 6);
                Servo2.TO.POUT7 = EEIPClient.ToBool(data[12], 7);
                Servo2.TO.OUT0 = EEIPClient.ToBool(data[13], 0);
                Servo2.TO.OUT1 = EEIPClient.ToBool(data[13], 1);
                Servo2.TO.OUT2 = EEIPClient.ToBool(data[13], 2);
                Servo2.TO.OUT3 = EEIPClient.ToBool(data[13], 3);
                Servo2.TO.BUSY = EEIPClient.ToBool(data[13], 4);
                Servo2.TO.END = EEIPClient.ToBool(data[13], 5);
                Servo2.TO._ALARM = EEIPClient.ToBool(data[13], 6);
                Servo2.TO.SRV_S = EEIPClient.ToBool(data[13], 7);
            }
        }

        public void WriteData()
        {
            if (_connected)
            {
                //Transfered form Originator -> Target
                bool[] LowByteSV1 =
                {
                    Servo1.OT.PIN0,
                    Servo1.OT.PIN1,
                    Servo1.OT.PIN2,
                    Servo1.OT.PIN3,
                    Servo1.OT.PIN4,
                    Servo1.OT.PIN5,
                    Servo1.OT.PIN6,
                    Servo1.OT.PIN7
                };
                bool[] HighByteSV1 =
                    {
                    Servo1.OT.JOG_PLUS,
                    Servo1.OT.JOG_MIN,
                    Servo1.OT.MANUAL,
                    Servo1.OT.ORG,
                    Servo1.OT._LOCK,
                    Servo1.OT.START,
                    Servo1.OT.RESET,
                    Servo1.OT.SERVO
                };

                    
                bool[] LowByteSV2 =
                {
                    Servo2.OT.PIN0,
                    Servo2.OT.PIN1,
                    Servo2.OT.PIN2,
                    Servo2.OT.PIN3,
                    Servo2.OT.PIN4,
                    Servo2.OT.PIN5,
                    Servo2.OT.PIN6,
                    Servo2.OT.PIN7
                };
                bool[] HighByteSV2 =
                {
                    Servo2.OT.JOG_PLUS,
                    Servo2.OT.JOG_MIN,
                    Servo2.OT.MANUAL,
                    Servo2.OT.ORG,
                    Servo2.OT._LOCK,
                    Servo2.OT.START,
                    Servo2.OT.RESET,
                    Servo2.OT.SERVO
                };
                _eeipClient.O_T_IOData[0] = Utility.ConvertBoolArrayToByte(LowByteSV1);
                _eeipClient.O_T_IOData[1] = Utility.ConvertBoolArrayToByte(HighByteSV1);
                _eeipClient.O_T_IOData[12] = Utility.ConvertBoolArrayToByte(LowByteSV2);
                _eeipClient.O_T_IOData[13] = Utility.ConvertBoolArrayToByte(HighByteSV2);

            }
        }
    }
}
