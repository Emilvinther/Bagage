using Bagageimp;

internal class Program
{
    
    public static void Main()
    {
        // New Threads running different tasks, with a lamda expression (empty function)
        Thread createbags = new Thread(Producer.ProducerSkrank);
        Thread sortPar = new Thread(() => Sort.Sorting(Sort.termPar, "Paris"));
        Thread sortAla = new Thread(() => Sort.Sorting(Sort.termAla, "Alabama"));
        Thread sortHar = new Thread(() => Sort.Sorting(Sort.termHar, "Harare"));
        Thread paris = new Thread(() => Planes.Departure(Sort.termPar, "Paris"));
        Thread alabama = new Thread(() => Planes.Departure(Sort.termAla, "Alabama"));
        Thread harare = new Thread(() => Planes.Departure(Sort.termHar, "Harare"));
        // Start of threads
        createbags.Start();
        sortPar.Start();
        sortAla.Start();
        sortHar.Start();
        paris.Start();
        alabama.Start();
        harare.Start();

    }


}
