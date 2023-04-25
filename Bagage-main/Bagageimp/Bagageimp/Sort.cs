using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagageimp
{
    internal class Sort
    {

        public static Queue<Bagage> termPar = new();
        public static Queue<Bagage> termAla = new();
        public static Queue<Bagage> termHar = new();
        // Sorting/Splitter class with a method that takes 2 object parameters and cast them to their respective datatype in the method
        //It takes bagage from the first buffer and assign it to a new buffer depending on where they're heading
        public static void Sorting(Object terms, Object dest)
        {
            Bagage bag;
            Queue<Bagage> term = (Queue<Bagage>)terms;
            string destination = (string)dest;
            


            while (true)
            {
                try
                {
                    if (Monitor.TryEnter(Producer.bagages))
                    {
                        if (Producer.bagages.Count == 0)
                        {
                            Monitor.Wait(Producer.bagages);
                        }
                        else
                        {
                            bag = Producer.bagages.Dequeue();

                            if (bag.Destination == destination)
                            {
                                if (Monitor.TryEnter(term))
                                {
                                    while (term.Count < 10)
                                    {
                                        term.Enqueue(bag);
                                        Monitor.PulseAll(term);
                                    }
                                    Monitor.Exit(term);
                                }
                            }
                        }
                    }

                    Debug.WriteLine("{0} unsorted", Producer.bagages.Count);
                    Debug.WriteLine("{0} Bags for Paris", termPar.Count);
                    Debug.WriteLine("{0} Bags for Alabama", termAla.Count);
                    Debug.WriteLine("{0} Bags for Harare", termHar.Count);

                }
                finally
                {
                    
                   
                }
               

            }
        }

    }
}
