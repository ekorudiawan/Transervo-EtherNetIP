using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transervo_EIP_PLC_Gateway
{
    class Servo1
    {
        // Originator to Target
        public static class OT
        {
            public static bool PIN0;
            public static bool PIN1;
            public static bool PIN2;
            public static bool PIN3;
            public static bool PIN4;
            public static bool PIN5;
            public static bool PIN6;
            public static bool PIN7;
            public static bool JOG_PLUS;
            public static bool JOG_MIN;
            public static bool MANUAL;
            public static bool ORG;
            public static bool _LOCK;
            public static bool START;
            public static bool RESET;
            public static bool SERVO;
        }
        // Target to Originator
        public static class TO
        {
            public static bool POUT0;
            public static bool POUT1;
            public static bool POUT2;
            public static bool POUT3;
            public static bool POUT4;
            public static bool POUT5;
            public static bool POUT6;
            public static bool POUT7;
            public static bool OUT0;
            public static bool OUT1;
            public static bool OUT2;
            public static bool OUT3;
            public static bool BUSY;
            public static bool END;
            public static bool _ALARM;
            public static bool SRV_S;
        }
    }

    class Servo2
    {
        // Originator to Target
        public static class OT
        {
            public static bool PIN0;
            public static bool PIN1;
            public static bool PIN2;
            public static bool PIN3;
            public static bool PIN4;
            public static bool PIN5;
            public static bool PIN6;
            public static bool PIN7;
            public static bool JOG_PLUS;
            public static bool JOG_MIN;
            public static bool MANUAL;
            public static bool ORG;
            public static bool _LOCK;
            public static bool START;
            public static bool RESET;
            public static bool SERVO;
        }
        // Target to Originator
        public static class TO
        {
            public static bool POUT0;
            public static bool POUT1;
            public static bool POUT2;
            public static bool POUT3;
            public static bool POUT4;
            public static bool POUT5;
            public static bool POUT6;
            public static bool POUT7;
            public static bool OUT0;
            public static bool OUT1;
            public static bool OUT2;
            public static bool OUT3;
            public static bool BUSY;
            public static bool END;
            public static bool _ALARM;
            public static bool SRV_S;
        }
    }

    class PLC
    {
        public static class Input
        {

        }
        public static class Output
        {

        }
        public static class DataInput
        {
            public static class Servo1
            {
                public static bool PIN0;
                public static bool PIN1;
                public static bool PIN2;
                public static bool PIN3;
                public static bool PIN4;
                public static bool PIN5;
                public static bool PIN6;
                public static bool PIN7;
                public static bool JOG_PLUS;
                public static bool JOG_MIN;
                public static bool MANUAL;
                public static bool ORG;
                public static bool _LOCK;
                public static bool START;
                public static bool RESET;
                public static bool SERVO;
            }
            public static class Servo2
            {
                public static bool PIN0;
                public static bool PIN1;
                public static bool PIN2;
                public static bool PIN3;
                public static bool PIN4;
                public static bool PIN5;
                public static bool PIN6;
                public static bool PIN7;
                public static bool JOG_PLUS;
                public static bool JOG_MIN;
                public static bool MANUAL;
                public static bool ORG;
                public static bool _LOCK;
                public static bool START;
                public static bool RESET;
                public static bool SERVO;
            }
        }
        public static class DataOutput
        {
            public static class Servo1
            {
                public static bool POUT0;
                public static bool POUT1;
                public static bool POUT2;
                public static bool POUT3;
                public static bool POUT4;
                public static bool POUT5;
                public static bool POUT6;
                public static bool POUT7;
                public static bool OUT0;
                public static bool OUT1;
                public static bool OUT2;
                public static bool OUT3;
                public static bool BUSY;
                public static bool END;
                public static bool _ALARM;
                public static bool SRV_S;
            }
            public static class Servo2
            {
                public static bool POUT0;
                public static bool POUT1;
                public static bool POUT2;
                public static bool POUT3;
                public static bool POUT4;
                public static bool POUT5;
                public static bool POUT6;
                public static bool POUT7;
                public static bool OUT0;
                public static bool OUT1;
                public static bool OUT2;
                public static bool OUT3;
                public static bool BUSY;
                public static bool END;
                public static bool _ALARM;
                public static bool SRV_S;
            }
        }
    }
}
