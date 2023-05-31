namespace Jewel_Collector;
using System;
public class JewelCollector
{
      public static void Main() {
  
      bool running = true;
  
      do {
  
          Console.WriteLine("Enter the command: ");
          char cki = Console.ReadKey().KeyChar;
          //string command = Console.ReadKey();
          Console.WriteLine(cki);
  
          if (cki.Equals('q')) {
              running = false;
          } else if (cki.Equals('w')) {
              
          } else if (cki.Equals('a')) {
              
          } else if (cki.Equals('s')) {
            
          } else if (cki.Equals('d')) {
          
          } else if (cki.Equals('g')) {
              
          }
          
      } while (running);
  }
}
