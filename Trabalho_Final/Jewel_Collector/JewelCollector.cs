/// <summary>
/// Classe: Jewel_Collector
/// Objetivo: Realizar a movimentacao do robo no mapa criado.
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
    /// Método inicial Main
    /// Objetivo: Carrega o mapa e inicia o jogo. A cada nova letra, recarrega o mapa já com a nova acao realizada.
    /// </summary>
      public static void Main() 
      {
            bool running = true;
            bool gonextlevel = false;
            int w = 10;
            int h = 10;
            int level = 1;

           
            do 
            {

                Map map = new Map (w, h, level);
                Robot robot = new Robot(map);

                OnGoUp += robot.GoUp;
                OnGoDown += robot.GoDown;
                OnGoRight += robot.GoRight;
                OnGoLeft += robot.GoLeft;
                OnGet += robot.GetJ;
        
                do
                {
                    try
                    {
                        if(!robot.HasEnergy()) throw new RanOutOfEnergyException();
                        Console.Clear();
                        robot.Print();
                        Console.WriteLine("\n Digite o comando(W,S,D,A,G,Q): ");
                        ConsoleKeyInfo command = Console.ReadKey(true);

                        gonextlevel = robot.map.IsDone(); //Terminou de coletar objetos

                        switch (command.Key.ToString())
                        {
                            case "W": Console.WriteLine($"\n Comando:{command.Key.ToString()}"); OnGoUp() ; break;
                            case "S" : Console.WriteLine($"\n Comando:{command.Key.ToString()}"); OnGoDown() ; break;
                            case "D" : Console.WriteLine($"\n Comando:{command.Key.ToString()}"); OnGoRight() ; break;
                            case "A" : Console.WriteLine($"\n Comando:{command.Key.ToString()}"); OnGoLeft() ; break;
                            case "G" : Console.WriteLine($"\n Comando:{command.Key.ToString()}"); OnGet() ; break;
                            case "Q" : running = false; break;
                            default: Console.WriteLine($"\n Comando inválido:{command.Key.ToString()}"); break;
                        }
                    }
                    catch(RanOutOfEnergyException e)
                    {
                        Console.WriteLine("Nível crítico de energia atingido!");
                         running = false;
                         break;
                    }                        
                } while(!gonextlevel && running);

               if(gonextlevel)
               {
                w++;
                h++;
                level++;
                Console.WriteLine($"Parabéns! Estágio: {level} liberado!");
                Console.ReadLine();
               }

               if(!running)
               {
                Console.WriteLine($"Obrigado pela participação!");
               }


                
            } while (running);
        }
}

static class Constants
{
    public const int cCarga10 = 10;
    public const int cCarga50 = 50;
    public const int cCarga100 = 100;
}
