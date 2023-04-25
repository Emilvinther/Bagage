using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagageimp
{
    internal class Producer
    {
        public static Queue<Bagage> bagages = new();
        // The method produce bagage by assigning a number and randomly pick a number to determin where the bagage is heading
        public static void ProducerSkrank()
        {
            Random random = new Random();
            int rando;

            while (true)
            {
                Monitor.Enter(bagages);
                try
                {
                    if (bagages.Count < 3)
                    {
                        while (bagages.Count < 10)
                        {
                            rando = random.Next(1, 4);

                            if (rando == 1)
                            {
                                bagages.Enqueue(new Bagage("Paris"));
                            }
                            else if (rando == 2)
                            {
                                bagages.Enqueue(new Bagage("Alabama"));
                            }
                            else if (rando == 3)
                            {
                                bagages.Enqueue(new Bagage("Harare"));
                            }

                        }
                        Monitor.PulseAll(bagages);
                    }
                }
                finally
                {

                    Monitor.Exit(bagages);
                    Thread.Sleep(200);
                }
            }
        }
    }
}
