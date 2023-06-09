/// <summary>
/// Realizar a movimentacao do robo no mapa criado.
/// </summary>
namespace Jewel_Collector;
using System;
public class JewelCollector
{
    
    delegate void GoUp();
    static event GoUp OnGoUp;
    delegate void GoDown();
    static event GoDown OnGoDown;
    delegate void GoRight();
    static event GoRight OnGoRight;

    delegate void GoLeft();
    static event GoLeft OnGoLeft;
         
    delegate void GetJ();
    static event GetJ OnGet;

    /// <summary>
    /// Carrega o mapa e inicia o jogo. 
    /// A cada nova letra, recarrega o mapa já com a nova acao realizada.
    /// </summary>
      public static void Main() {
  
      bool running = true;

      int w = 10;
      int h = 10;
      int level = 1;
  
      do {
  
            Map map = new Map (w, h, level);
            Robot robot = new Robot(map);

            Console.WriteLine($"Level: {level}");

            try{
                bool Result = Run(robot);
                if(Result)
                {
                    w++;
                    h++;
                    level++;
                }
                else
                {
                    break;
                }
            }
            catch(RanOutOfEnergyException e)
            {
                Console.WriteLine("Robot ran out of energy!");
            }
          
      } while (running);
  }
    /// <summary>
    /// Ler o teclado e executar a acao indicada.
    /// </summary>
    private static bool Run(Robot robot)  
    {
        OnGoUp += robot.GoUp;
        OnGoDown += robot.GoDown;
        OnGoRight += robot.GoRight;
        OnGoLeft += robot.GoLeft;
        OnGet += robot.GetJ;

        do {
            if(!robot.HasEnergy()) throw new RanOutOfEnergyException();
            robot.Print();
            Console.WriteLine("\n Enter the command: ");
            ConsoleKeyInfo command = Console.ReadKey(true);

            switch (command.Key.ToString())
            {
                case "W": Console.WriteLine($"\n Comando:{command.Key.ToString()}"); OnGoUp() ; break;
                case "S" : Console.WriteLine($"\n Comando:{command.Key.ToString()}"); OnGoDown() ; break;
                case "D" : Console.WriteLine($"\n Comando:{command.Key.ToString()}"); OnGoRight() ; break;
                case "A" : Console.WriteLine($"\n Comando:{command.Key.ToString()}"); OnGoLeft() ; break;
                case "G" : Console.WriteLine($"\n Comando:{command.Key.ToString()}"); OnGet() ; break;
                case "Q" : return false;
                default: Console.WriteLine($"\n Comando inválido:{command.Key.ToString()}"); break;
            }
        } while (!robot.map.IsDone());
        return true;
    }

}

static class Constants
{
    public const int cCarga10 = 10;
    public const int cCarga50 = 50;
    public const int cCarga100 = 100;
}
