using System;
using MRI_Core_Library;

namespace ConsoleApp2
{
    class Program
    {
        public static void Main(string[] arg)
        {
            int[] args = new int[2];
            if (arg.Length != 0)
            {
                args[0] = (Convert.ToInt32(arg[0]));
                args[1] = (Convert.ToInt32(arg[1]));
                int[] stuff = GetArgs(args);
                Start(stuff);
            }
            else
            {
                int[] stuff = GetArgs();
                Start(stuff);
                

            }
            
        }

        static void Start(int[] stuff)
        {
            WritePortPower(stuff[0], stuff[1]);
            CoreMotorController controller = new CoreMotorController();
            Motor turntable = new Motor(stuff[0], controller);
            turntable.setMode(CoreMotorController.mode.Constant_Power);
            turntable.setPower(stuff[1]);
            Console.WriteLine("Press any key to enter edit mode...");
            _ = Console.ReadKey();
            stuff = GetArgs();
            Start(stuff);
        }

        static void WritePortPower(int port, int power)
        {
            Console.WriteLine("Motor port: " + port);
            Console.WriteLine("Motor power: " + power);
        }

        static int[] GetArgs(int[] array)
        {
            if (array.Length == 0)
            {
                Console.WriteLine("What port?");
                int motorPort = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("What power?");
                int motorPower = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("For future reference, you can pass in port and power as arguements.");
                int[] c = new int[2];
                c[0] = motorPort;
                c[1] = motorPower;
                return c;
            }
            else
            {
                int[] c = new int[2];
                c[0] = array[0];
                c[1] = array[1];
                return c;
            }

        }

        static int[] GetArgs()
        {
            Console.WriteLine("What port");
            int motorPort = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What power");
            int motorPower = Convert.ToInt32(Console.ReadLine());
            int[] c = new int[2];
            c[0] = motorPort;
            c[1] = motorPower;
            return c;
        }
    }
}

