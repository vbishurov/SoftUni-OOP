namespace FarmersCreed
{
    using Simulator;

    class FarmersCreedMain
    {
        static void Main()
        {
            FarmSimulator simulator = new ImprovedFarmSimulator();
            simulator.Run();
        }
    }
}
