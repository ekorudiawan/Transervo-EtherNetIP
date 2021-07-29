using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace Transervo_EIP_PLC_Gateway
{
    public partial class MainForm : Form
    {
        private TranservoSingleton transervo = TranservoSingleton.GetInstance();
        private MitshubisiPLCSingleton plc = MitshubisiPLCSingleton.GetInstance();

        bool readWriteIO = false;
        Thread threadReadWriteIO;

        public MainForm()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            textBoxServo1IPAddress.Text = Properties.Settings.Default.Servo1_IP_Address;
            textBoxPLCStationNumber.Text = Properties.Settings.Default.PLC_Station_Number.ToString();

            if(Properties.Settings.Default.Force_User_Input)
            {
                radioButtonUser.Checked = true;
                radioButtonPLC.Checked = false;

                ledOT0_SV1.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.SwitchWhenPressed;
                ledOT1_SV1.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.SwitchWhenPressed;
                ledOT2_SV1.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.SwitchWhenPressed;
                ledOT3_SV1.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.SwitchWhenPressed;
                ledOT4_SV1.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.SwitchWhenPressed;
                ledOT5_SV1.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.SwitchWhenPressed;
                ledOT6_SV1.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.SwitchWhenPressed;
                ledOT7_SV1.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.SwitchWhenPressed;
                ledOT8_SV1.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.SwitchWhenPressed;
                ledOT9_SV1.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.SwitchWhenPressed;
                ledOT10_SV1.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.SwitchWhenPressed;
                ledOT11_SV1.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.SwitchWhenPressed;
                ledOT12_SV1.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.SwitchWhenPressed;
                ledOT13_SV1.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.SwitchWhenPressed;
                ledOT14_SV1.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.SwitchWhenPressed;
                ledOT15_SV1.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.SwitchWhenPressed;

                ledOT0_SV2.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.SwitchWhenPressed;
                ledOT1_SV2.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.SwitchWhenPressed;
                ledOT2_SV2.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.SwitchWhenPressed;
                ledOT3_SV2.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.SwitchWhenPressed;
                ledOT4_SV2.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.SwitchWhenPressed;
                ledOT5_SV2.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.SwitchWhenPressed;
                ledOT6_SV2.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.SwitchWhenPressed;
                ledOT7_SV2.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.SwitchWhenPressed;
                ledOT8_SV2.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.SwitchWhenPressed;
                ledOT9_SV2.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.SwitchWhenPressed;
                ledOT10_SV2.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.SwitchWhenPressed;
                ledOT11_SV2.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.SwitchWhenPressed;
                ledOT12_SV2.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.SwitchWhenPressed;
                ledOT13_SV2.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.SwitchWhenPressed;
                ledOT14_SV2.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.SwitchWhenPressed;
                ledOT15_SV2.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.SwitchWhenPressed;
            }
            else
            {
                radioButtonUser.Checked = false;
                radioButtonPLC.Checked = true;

                ledOT0_SV1.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.Indicator;
                ledOT1_SV1.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.Indicator;
                ledOT2_SV1.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.Indicator;
                ledOT3_SV1.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.Indicator;
                ledOT4_SV1.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.Indicator;
                ledOT5_SV1.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.Indicator;
                ledOT6_SV1.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.Indicator;
                ledOT7_SV1.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.Indicator;
                ledOT8_SV1.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.Indicator;
                ledOT9_SV1.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.Indicator;
                ledOT10_SV1.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.Indicator;
                ledOT11_SV1.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.Indicator;
                ledOT12_SV1.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.Indicator;
                ledOT13_SV1.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.Indicator;
                ledOT14_SV1.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.Indicator;
                ledOT15_SV1.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.Indicator;

                ledOT0_SV2.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.Indicator;
                ledOT1_SV2.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.Indicator;
                ledOT2_SV2.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.Indicator;
                ledOT3_SV2.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.Indicator;
                ledOT4_SV2.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.Indicator;
                ledOT5_SV2.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.Indicator;
                ledOT6_SV2.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.Indicator;
                ledOT7_SV2.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.Indicator;
                ledOT8_SV2.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.Indicator;
                ledOT9_SV2.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.Indicator;
                ledOT10_SV2.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.Indicator;
                ledOT11_SV2.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.Indicator;
                ledOT12_SV2.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.Indicator;
                ledOT13_SV2.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.Indicator;
                ledOT14_SV2.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.Indicator;
                ledOT15_SV2.InteractionMode = NationalInstruments.UI.BooleanInteractionMode.Indicator;
            }
                        
            if (!Properties.Settings.Default.Debug)
            {
                if (!transervo.Connected)
                {
                    transervo.Connect(Properties.Settings.Default.Servo1_IP_Address);
                }

                if (plc.Connected == false)
                {
                    int stationNumber = Properties.Settings.Default.PLC_Station_Number;

                    plc.Connect(stationNumber);
                    var devInfo = plc.GetDeviceInfo();
                    // Check connection
                    plc.ReadAll();
                }

                threadReadWriteIO = new Thread(new ThreadStart(ReadWriteIO));
                threadReadWriteIO.Start();
                readWriteIO = true;
            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Servo1_IP_Address = textBoxServo1IPAddress.Text;
            Properties.Settings.Default.PLC_Station_Number = Int32.Parse(textBoxPLCStationNumber.Text);

            if (radioButtonUser.Checked)
            {
                Properties.Settings.Default.Force_User_Input = true;
            }
            else
            {
                Properties.Settings.Default.Force_User_Input = false;
            }
            Properties.Settings.Default.Save();

            if(!Properties.Settings.Default.Debug )
            {
                readWriteIO = false;
                if (transervo.Connected)
                {
                    transervo.Disconnect();
                }
                if (plc.Connected)
                {
                    plc.Disconnect();
                }
            }
        }

        private void ReadWriteIO()
        {
            try
            {
                while (readWriteIO)
                {
                    UpdateUI();

                    transervo.ReadData();
                    plc.ReadData();

                    // Mapping IO
                    if(radioButtonPLC.Checked)
                    {
                        MapIODataPLCTranservo();
                    }

                    transervo.WriteData();
                    plc.WriteData();

                    Thread.Sleep(5);
                }
            }
            catch (ThreadAbortException err)
            {
                Debug.WriteLine("Thread Read/Write IO Aborted Manually");
            }
            
        }

        private void MapIODataPLCTranservo()
        {
            PLC.DataOutput.Servo1.POUT0 = Servo1.TO.POUT0;
            PLC.DataOutput.Servo1.POUT1 = Servo1.TO.POUT1;
            PLC.DataOutput.Servo1.POUT2 = Servo1.TO.POUT2;
            PLC.DataOutput.Servo1.POUT3 = Servo1.TO.POUT3;
            PLC.DataOutput.Servo1.POUT4 = Servo1.TO.POUT4;
            PLC.DataOutput.Servo1.POUT5 = Servo1.TO.POUT5;
            PLC.DataOutput.Servo1.POUT6 = Servo1.TO.POUT6;
            PLC.DataOutput.Servo1.POUT7 = Servo1.TO.POUT7;
            PLC.DataOutput.Servo1.OUT0 = Servo1.TO.OUT0;
            PLC.DataOutput.Servo1.OUT1 = Servo1.TO.OUT1;
            PLC.DataOutput.Servo1.OUT2 = Servo1.TO.OUT2;
            PLC.DataOutput.Servo1.OUT3 = Servo1.TO.OUT3;
            PLC.DataOutput.Servo1.BUSY = Servo1.TO.BUSY;
            PLC.DataOutput.Servo1.END = Servo1.TO.END;
            PLC.DataOutput.Servo1._ALARM = Servo1.TO._ALARM;
            PLC.DataOutput.Servo1.SRV_S = Servo1.TO.SRV_S;

            PLC.DataOutput.Servo2.POUT0 = Servo2.TO.POUT0;
            PLC.DataOutput.Servo2.POUT1 = Servo2.TO.POUT1;
            PLC.DataOutput.Servo2.POUT2 = Servo2.TO.POUT2;
            PLC.DataOutput.Servo2.POUT3 = Servo2.TO.POUT3;
            PLC.DataOutput.Servo2.POUT4 = Servo2.TO.POUT4;
            PLC.DataOutput.Servo2.POUT5 = Servo2.TO.POUT5;
            PLC.DataOutput.Servo2.POUT6 = Servo2.TO.POUT6;
            PLC.DataOutput.Servo2.POUT7 = Servo2.TO.POUT7;
            PLC.DataOutput.Servo2.OUT0 = Servo2.TO.OUT0;
            PLC.DataOutput.Servo2.OUT1 = Servo2.TO.OUT1;
            PLC.DataOutput.Servo2.OUT2 = Servo2.TO.OUT2;
            PLC.DataOutput.Servo2.OUT3 = Servo2.TO.OUT3;
            PLC.DataOutput.Servo2.BUSY = Servo2.TO.BUSY;
            PLC.DataOutput.Servo2.END = Servo2.TO.END;
            PLC.DataOutput.Servo2._ALARM = Servo2.TO._ALARM;
            PLC.DataOutput.Servo2.SRV_S = Servo2.TO.SRV_S;

            Servo1.OT.PIN0 = PLC.DataInput.Servo1.PIN0;
            Servo1.OT.PIN1 = PLC.DataInput.Servo1.PIN1;
            Servo1.OT.PIN2 = PLC.DataInput.Servo1.PIN2;
            Servo1.OT.PIN3 = PLC.DataInput.Servo1.PIN3;
            Servo1.OT.PIN4 = PLC.DataInput.Servo1.PIN4;
            Servo1.OT.PIN5 = PLC.DataInput.Servo1.PIN5;
            Servo1.OT.PIN6 = PLC.DataInput.Servo1.PIN6;
            Servo1.OT.PIN7 = PLC.DataInput.Servo1.PIN7;
            Servo1.OT.JOG_PLUS = PLC.DataInput.Servo1.JOG_PLUS;
            Servo1.OT.JOG_MIN = PLC.DataInput.Servo1.JOG_MIN;
            Servo1.OT.MANUAL = PLC.DataInput.Servo1.MANUAL;
            Servo1.OT.ORG = PLC.DataInput.Servo1.ORG;
            Servo1.OT._LOCK = PLC.DataInput.Servo1._LOCK;
            Servo1.OT.START = PLC.DataInput.Servo1.START;
            Servo1.OT.RESET = PLC.DataInput.Servo1.RESET;
            Servo1.OT.SERVO = PLC.DataInput.Servo1.SERVO;

            Servo2.OT.PIN0 = PLC.DataInput.Servo2.PIN0;
            Servo2.OT.PIN1 = PLC.DataInput.Servo2.PIN1;
            Servo2.OT.PIN2 = PLC.DataInput.Servo2.PIN2;
            Servo2.OT.PIN3 = PLC.DataInput.Servo2.PIN3;
            Servo2.OT.PIN4 = PLC.DataInput.Servo2.PIN4;
            Servo2.OT.PIN5 = PLC.DataInput.Servo2.PIN5;
            Servo2.OT.PIN6 = PLC.DataInput.Servo2.PIN6;
            Servo2.OT.PIN7 = PLC.DataInput.Servo2.PIN7;
            Servo2.OT.JOG_PLUS = PLC.DataInput.Servo2.JOG_PLUS;
            Servo2.OT.JOG_MIN = PLC.DataInput.Servo2.JOG_MIN;
            Servo2.OT.MANUAL = PLC.DataInput.Servo2.MANUAL;
            Servo2.OT.ORG = PLC.DataInput.Servo2.ORG;
            Servo2.OT._LOCK = PLC.DataInput.Servo2._LOCK;
            Servo2.OT.START = PLC.DataInput.Servo2.START;
            Servo2.OT.RESET = PLC.DataInput.Servo2.RESET;
            Servo2.OT.SERVO = PLC.DataInput.Servo2.SERVO;
        }

        private void UpdateUI()
        {
            // Servo 1
            if (radioButtonPLC.Checked)
            {
                ledOT0_SV1.Value = Servo1.OT.PIN0;
                ledOT1_SV1.Value = Servo1.OT.PIN1;
                ledOT2_SV1.Value = Servo1.OT.PIN2;
                ledOT3_SV1.Value = Servo1.OT.PIN3;
                ledOT4_SV1.Value = Servo1.OT.PIN4;
                ledOT5_SV1.Value = Servo1.OT.PIN5;
                ledOT6_SV1.Value = Servo1.OT.PIN6;
                ledOT7_SV1.Value = Servo1.OT.PIN7;
                ledOT8_SV1.Value = Servo1.OT.JOG_PLUS;
                ledOT9_SV1.Value = Servo1.OT.JOG_MIN;
                ledOT10_SV1.Value = Servo1.OT.MANUAL;
                ledOT11_SV1.Value = Servo1.OT.ORG;
                ledOT12_SV1.Value = Servo1.OT._LOCK;
                ledOT13_SV1.Value = Servo1.OT.START;
                ledOT14_SV1.Value = Servo1.OT.RESET;
                ledOT15_SV1.Value = Servo1.OT.SERVO;
            }

            ledTO0_SV1.Value = Servo1.TO.POUT0;
            ledTO1_SV1.Value = Servo1.TO.POUT1;
            ledTO2_SV1.Value = Servo1.TO.POUT2;
            ledTO3_SV1.Value = Servo1.TO.POUT3;
            ledTO4_SV1.Value = Servo1.TO.POUT4;
            ledTO5_SV1.Value = Servo1.TO.POUT5;
            ledTO6_SV1.Value = Servo1.TO.POUT6;
            ledTO7_SV1.Value = Servo1.TO.POUT7;
            ledTO8_SV1.Value = Servo1.TO.OUT0;
            ledTO9_SV1.Value = Servo1.TO.OUT1;
            ledTO10_SV1.Value = Servo1.TO.OUT2;
            ledTO11_SV1.Value = Servo1.TO.OUT3;
            ledTO12_SV1.Value = Servo1.TO.BUSY;
            ledTO13_SV1.Value = Servo1.TO.END;
            ledTO14_SV1.Value = Servo1.TO._ALARM;
            ledTO15_SV1.Value = Servo1.TO.SRV_S;

            // Servo 2
            if (radioButtonPLC.Checked)
            {
                ledOT0_SV2.Value = Servo2.OT.PIN0;
                ledOT1_SV2.Value = Servo2.OT.PIN1;
                ledOT2_SV2.Value = Servo2.OT.PIN2;
                ledOT3_SV2.Value = Servo2.OT.PIN3;
                ledOT4_SV2.Value = Servo2.OT.PIN4;
                ledOT5_SV2.Value = Servo2.OT.PIN5;
                ledOT6_SV2.Value = Servo2.OT.PIN6;
                ledOT7_SV2.Value = Servo2.OT.PIN7;
                ledOT8_SV2.Value = Servo2.OT.JOG_PLUS;
                ledOT9_SV2.Value = Servo2.OT.JOG_MIN;
                ledOT10_SV2.Value = Servo2.OT.MANUAL;
                ledOT11_SV2.Value = Servo2.OT.ORG;
                ledOT12_SV2.Value = Servo2.OT._LOCK;
                ledOT13_SV2.Value = Servo2.OT.START;
                ledOT14_SV2.Value = Servo2.OT.RESET;
                ledOT15_SV2.Value = Servo2.OT.SERVO;
            }

            ledTO0_SV2.Value = Servo2.TO.POUT0;
            ledTO1_SV2.Value = Servo2.TO.POUT1;
            ledTO2_SV2.Value = Servo2.TO.POUT2;
            ledTO3_SV2.Value = Servo2.TO.POUT3;
            ledTO4_SV2.Value = Servo2.TO.POUT4;
            ledTO5_SV2.Value = Servo2.TO.POUT5;
            ledTO6_SV2.Value = Servo2.TO.POUT6;
            ledTO7_SV2.Value = Servo2.TO.POUT7;
            ledTO8_SV2.Value = Servo2.TO.OUT0;
            ledTO9_SV2.Value = Servo2.TO.OUT1;
            ledTO10_SV2.Value = Servo2.TO.OUT2;
            ledTO11_SV2.Value = Servo2.TO.OUT3;
            ledTO12_SV2.Value = Servo2.TO.BUSY;
            ledTO13_SV2.Value = Servo2.TO.END;
            ledTO14_SV2.Value = Servo2.TO._ALARM;
            ledTO15_SV2.Value = Servo2.TO.SRV_S;
        }

        private void ledOT0_SV1_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if(radioButtonUser.Checked)
            {
                Servo1.OT.PIN0 = !Servo1.OT.PIN0;
            }
        }

        private void ledOT1_SV1_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if (radioButtonUser.Checked)
            {
                Servo1.OT.PIN1 = !Servo1.OT.PIN1;
            }
        }

        private void ledOT2_SV1_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if (radioButtonUser.Checked)
            {
                Servo1.OT.PIN2 = !Servo1.OT.PIN2;
            }
        }

        private void ledOT3_SV1_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if (radioButtonUser.Checked)
            {
                Servo1.OT.PIN3 = !Servo1.OT.PIN3;
            }
        }

        private void ledOT4_SV1_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if (radioButtonUser.Checked)
            {
                Servo1.OT.PIN4 = !Servo1.OT.PIN4;
            }
        }

        private void ledOT5_SV1_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if (radioButtonUser.Checked)
            {
                Servo1.OT.PIN5 = !Servo1.OT.PIN5;
            }
        }

        private void ledOT6_SV1_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if (radioButtonUser.Checked)
            {
                Servo1.OT.PIN6 = !Servo1.OT.PIN6;
            }
        }

        private void ledOT7_SV1_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if (radioButtonUser.Checked)
            {
                Servo1.OT.PIN7 = !Servo1.OT.PIN7;
            }
        }

        private void ledOT8_SV1_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if (radioButtonUser.Checked)
            {
                Servo1.OT.JOG_PLUS = !Servo1.OT.JOG_PLUS;
            }
        }

        private void ledOT9_SV1_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if (radioButtonUser.Checked)
            {
                Servo1.OT.JOG_MIN = !Servo1.OT.JOG_MIN;
            }
        }

        private void ledOT10_SV1_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if (radioButtonUser.Checked)
            {
                Servo1.OT.MANUAL = !Servo1.OT.MANUAL;
            }
        }

        private void ledOT11_SV1_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if (radioButtonUser.Checked)
            {
                Servo1.OT.ORG = !Servo1.OT.ORG;
            }
        }

        private void ledOT12_SV1_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if (radioButtonUser.Checked)
            {
                Servo1.OT._LOCK = !Servo1.OT._LOCK;
            }
        }

        private void ledOT13_SV1_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if (radioButtonUser.Checked)
            {
                Servo1.OT.START = !Servo1.OT.START;
            }
        }

        private void ledOT14_SV1_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if (radioButtonUser.Checked)
            {
                Servo1.OT.RESET = !Servo1.OT.RESET;
            }
        }

        private void ledOT15_SV1_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if (radioButtonUser.Checked)
            {
                Servo1.OT.SERVO = !Servo1.OT.SERVO;
            }
        }

        private void ledOT0_SV2_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if (radioButtonUser.Checked)
            {
                Servo2.OT.PIN0 = !Servo2.OT.PIN0;
            }
        }

        private void ledOT1_SV2_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if (radioButtonUser.Checked)
            {
                Servo2.OT.PIN1 = !Servo2.OT.PIN1;
            }
        }

        private void ledOT2_SV2_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if (radioButtonUser.Checked)
            {
                Servo2.OT.PIN2 = !Servo2.OT.PIN2;
            }
        }

        private void ledOT3_SV2_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if (radioButtonUser.Checked)
            {
                Servo2.OT.PIN3 = !Servo2.OT.PIN3;
            }
        }

        private void ledOT4_SV2_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if (radioButtonUser.Checked)
            {
                Servo2.OT.PIN4 = !Servo2.OT.PIN4;
            }
        }

        private void ledOT5_SV2_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if (radioButtonUser.Checked)
            {
                Servo2.OT.PIN5 = !Servo2.OT.PIN5;
            }
        }

        private void ledOT6_SV2_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if (radioButtonUser.Checked)
            {
                Servo2.OT.PIN6 = !Servo2.OT.PIN6;
            }
        }

        private void ledOT7_SV2_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if (radioButtonUser.Checked)
            {
                Servo2.OT.PIN7 = !Servo2.OT.PIN7;
            }
        }

        private void ledOT8_SV2_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if (radioButtonUser.Checked)
            {
                Servo2.OT.JOG_PLUS = !Servo2.OT.JOG_PLUS;
            }
        }

        private void ledOT9_SV2_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if (radioButtonUser.Checked)
            {
                Servo2.OT.JOG_MIN = !Servo2.OT.JOG_MIN;
            }
        }

        private void ledOT10_SV2_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if (radioButtonUser.Checked)
            {
                Servo2.OT.MANUAL = !Servo2.OT.MANUAL;
            }
        }

        private void ledOT11_SV2_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if (radioButtonUser.Checked)
            {
                Servo2.OT.ORG = !Servo2.OT.ORG;
            }
        }

        private void ledOT12_SV2_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if (radioButtonUser.Checked)
            {
                Servo2.OT._LOCK = !Servo2.OT._LOCK;
            }
        }

        private void ledOT13_SV2_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if (radioButtonUser.Checked)
            {
                Servo2.OT.START = !Servo2.OT.START;
            }
        }

        private void ledOT14_SV2_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if (radioButtonUser.Checked)
            {
                Servo2.OT.RESET = !Servo2.OT.RESET;
            }
        }
        
        private void ledOT15_SV2_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if (radioButtonUser.Checked)
            {
                Servo2.OT.SERVO = !Servo2.OT.SERVO;
            }
        }
        
    }
}
