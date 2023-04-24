using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagageimp
{
    internal class Producer
    {
        // The method produce bagage by assigning a number and randomly pick a number to determin where the bagage is heading
        public static void ProducerSkrank()
        {
            Random random = new Random();
            int rando;

            while (true)
            {
                Monitor.Enter(Program.bagages);
                try
                {
                    if (Program.bagages.Count < 3)
                    {
                        while (Program.bagages.Count < 10)
                        {
                            rando = random.Next(1, 4);

                            if (rando == 1)
                            {
                                Program.bagages.Enqueue(new Bagage("Paris"));
                            }
                            else if (rando == 2)
                            {
                                Program.bagages.Enqueue(new Bagage("Alabama"));
                            }
                            else if (rando == 3)
                            {
                                Program.bagages.Enqueue(new Bagage("Harare"));
                            }

                        }
                        Monitor.PulseAll(Program.bagages);
                    }
                }
                finally
                {

                    Monitor.Exit(Program.bagages);
                    Thread.Sleep(200);
                }
            }
        }
    }
}
