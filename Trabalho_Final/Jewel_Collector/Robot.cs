namespace Jewel_Collector;

/// <summary>
/// Classe Robot
/// Objetivo: Navegar pelo mapa e coletar jóias.
/// </summary>
public class Robot : Cell {
    public Map map {get; private set;}
    private int x, y;
    private List<Jewel> Bag = new List<Jewel>();
    public int energy {get; set;}
    
    /// <summary>
    /// Método Robot
    /// Objetivo: Responsável por colocar o robo em sua posição inicial, atribuir energia que inicia o nível.
    /// </summary>
    public Robot(Map map, int x=0, int y=0, int energy=5) : base("ME "){
        this.map = map;
        this.x = x;
        this.y = y;
        this.energy = energy;
        this.map.Insert(this, x, y);
    }

    /// <summary>
    /// Método GoUp
    /// Objetivo: Movimentacao do robo: GoUp, GoDown, GoRight, GoLeft.
    /// </summary>
    public void GoUp(){
        try
        {
            map.Update(this.x, this.y, this.x-1, this.y);
            this.x--;
            this.energy--;
        }
        catch (OccupiedPositionException e)
        {
            Console.WriteLine($"\nPosição {this.x-1}, {this.y} está ocupada");
            Console.ReadLine();
        }
        catch (OutOfMapException e)
        {
            Console.WriteLine($"\nPosição {this.x-1}, {this.y} está fora do mapa");
           // Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine($"\nPosição não permitida");
        }
    }
    /// <summary>
    /// Método GoDown
    /// Objetivo: Descer as casas no mapa.
    /// </summary>
    public void GoDown(){
        try
        {
            map.Update(this.x, this.y, this.x+1, this.y);
            this.x++;
            this.energy--;
        }
        catch (OccupiedPositionException e)
        {
            Console.WriteLine($"\nPosição {this.x+1}, {this.y} está ocupada");
       //     Console.ReadLine();
        }
        catch (OutOfMapException e)
        {
            Console.WriteLine($"\nPosição {this.x+1}, {this.y} está fora do mapa");
          //  Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine($"\nPosição não permitida");
            Console.ReadLine();
        }
    }
    /// <summary>
    /// Método GoRight
    /// Objetivo: Ir para direita nas casas no mapa.
    /// </summary>
    public void GoRight(){
        try
        {
            map.Update(this.x, this.y, this.x, this.y+1);
            this.y++;
            this.energy--;
        }
        catch (OccupiedPositionException e)
        {
            Console.WriteLine($"\nPosição {this.x}, {this.y+1} está ocupada");
       //     Console.ReadLine();
        }
        catch (OutOfMapException e)
        {
            Console.WriteLine($"\nPosição {this.x}, {this.y+1} fora do mapa");
      //      Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine($"\nPosição não permitida");
            Console.ReadLine();
        }
    }
    /// <summary>
    /// Método GoLeft
    /// Objetivo: Ir para esquerda nas casas no mapa.
    /// </summary>
    public void GoLeft(){
        try
        {
            map.Update(this.x, this.y, this.x, this.y-1);
            this.y--;
            this.energy--;
        }
        catch (OccupiedPositionException e)
        {
            Console.WriteLine($"\nPosição {this.x}, {this.y-1} está ocupada");
            Console.ReadLine();
        }
        catch (OutOfMapException e)
        {
            Console.WriteLine($"\nPosição {this.x}, {this.y-1} fora do mapa");
       //     Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine($"\nPosição não permitida");
            Console.ReadLine();
        }
    }
    /// <summary>
    /// Método GetJ
    /// Objetivo: Fazer a recarga de energia para conseguir andar pelo mapa.
    /// </summary>
    public void GetJ(){
        //Console.Clear();
        Rechargeable? RechargeEnergy = map.RecarregaRobo(this.x, this.y);
        RechargeEnergy?.Recharge(this);
        List<Jewel> NearJewels = map.GetJewels(this.x, this.y);
        foreach (Jewel j in NearJewels)
            Bag.Add(j);
    }
    /// <summary>
    /// Método GetBagInfo
    /// Objetivo: Pontos acumulados na sacola.
    /// </summary>
    private (int, int) GetBagInfo()
    {
        int Points = 0;
        foreach (Jewel j in this.Bag)
            Points += j.Points;
        return (this.Bag.Count, Points);
    }
    /// <summary>
    /// Método Print
    /// Objetivo: Imprimir energia, pontos e itens coletados na sacola.
    /// </summary>
    public void Print()
    {
        map.PrintMap();
        (int ItensBag, int TotalPoints) = this.GetBagInfo();
        Console.WriteLine($"\nSacola: {ItensBag} - Pontos: {TotalPoints} - Energia: {this.energy} - x:{this.x}, y: {this.y}\n\n");
    }
    public bool HasEnergy()
    {
        return this.energy > 0;
    }
}


public interface Rechargeable
{
    public void Recharge(Robot r);
}