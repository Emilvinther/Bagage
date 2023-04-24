using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagageimp
{
    internal class Planes
    {
        // A plane method that takes the bagage from the buffer, and assign it to a list(plane) where it will be emptied when it departs.
        
        public static void Departure(object terms, object flight)
        {
            Bagage bag;
            List<Bagage> bagage = new();
            Random ran = new Random();
            int rando;
            Queue<Bagage> term = (Queue<Bagage>)terms;
            string flights = (string)flight;

            while (true)
            {
                try
                {
                    if (Monitor.TryEnter(term))
                    {
                        Monitor.Wait(term);
                    }
                    else
                    {
                        bag = term.Dequeue();

                        while (term.Count < 25)
                        {
                            if (Monitor.TryEnter(term))
                            {
                                bagage.Add(bag);
                                Monitor.PulseAll(term);
                            }
                        }
                    }
                }
                finally
                {
                    if (Monitor.IsEntered(term))
                    {

                       Monitor.Exit(term);

                    }

                    bagage.Clear();
                    Console.WriteLine("Flight to {0} have now departed", flights);
                    rando = ran.Next(3000, 7001);
                    Thread.Sleep(rando);
                    
                }
            }
        }


    }
}
