using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quicksort
{
    class Program
    {
        static double[] ResultData;

        static void Main(string[] args)
        {
            bool isNumber = true;
            char[] delimiter = { ' ' };

            Console.WriteLine("---Quick Sort---");
            do
            {
                Console.Write("Input Data:");
                string input = Console.ReadLine();
                string[] cal = input.Split(delimiter,StringSplitOptions.RemoveEmptyEntries);
                ResultData = new double[cal.Length];
                for (int i = 0; i < cal.Length; i++)
                {
                    isNumber = double.TryParse(cal[i], out ResultData[i]);
                    if (!isNumber)
                    {
                        Console.WriteLine("Error, this input's not number.");
                        break;
                    }
                }
                
            } while (!isNumber);
            qSort(0,ResultData.Length-1);

            Console.WriteLine("Output :");
            foreach (double item in ResultData)
            {
                Console.Write(" "+item.ToString());
            }

            Console.ReadKey();
        }

        static void qSort(int p, int r)
        {
            if (p<r)
            {
                int q = Partition(p, r);
                qSort(p,q-1);
                qSort(q+1,r);
            }
        }

        static int Partition(int p, int r)
        {
            double x =ResultData[r];
            int i = p - 1;
            for (int j = p; j < r; j++)
            {
                if (ResultData[j] <= x)
                {
                    i = i + 1;
                    Exchange(i, j);
                
                }
            }
            Exchange(i + 1, r);
            return i + 1;

        }

        static void Exchange(int i, int j)
        {
            double temp = ResultData[i];
            ResultData[i] = ResultData[j];
            ResultData[j] = temp;
        }
    }
}
