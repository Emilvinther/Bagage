using Bagageimp;

internal class Program
{
    // Buffers
    public static Queue<Bagage> bagages = new();
    public static Queue<Bagage> termPar = new();
    public static Queue<Bagage> termAla = new();
    public static Queue<Bagage> termHar = new();

    public static void Main()
    {
        // New Threads running different tasks, with a lamda expression (empty function)
        Thread createbags = new Thread(Producer.ProducerSkrank);
        Thread sortPar = new Thread(() => Sort.Sorting(termPar, "Paris"));
        Thread sortAla = new Thread(() => Sort.Sorting(termAla, "Alabama"));
        Thread sortHar = new Thread(() => Sort.Sorting(termHar, "Harare"));
        Thread paris = new Thread(() => Planes.Departure(termPar, "Paris"));
        Thread alabama = new Thread(() => Planes.Departure(termAla, "Alabama"));
        Thread harare = new Thread(() => Planes.Departure(termHar, "Harare"));
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
