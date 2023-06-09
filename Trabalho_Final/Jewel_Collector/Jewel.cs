namespace Jewel_Collector;


/// <summary>
/// Classe responsável pelas Jóias e contabilizar pontuação.
/// </summary>
public abstract class Jewel : ItemMap {
    public int Points {get; private set;}
    public Jewel(string Symbol, int Points) : base(Symbol)
    {
        this.Points = Points;
    }
}

/// <summary>
/// Classe reponsável pela Jóia Azul, pontuação e recarregar energia
/// </summary>
public class JewelBlue : Jewel, Rechargeable {
    
    public void Recharge(Robot r)
    {
        r.energy++;
        r.energy++;
        r.energy++;
    }

    public JewelBlue() : base("JB ", 10) {}
}

/// <summary>
/// Classe reponsável pela Jóia Verde e pontuação.
/// </summary>
public class JewelGreen : Jewel {
    public JewelGreen() : base("JG ", 50){}
}

/// <summary>
/// Classe reponsável pela Jóia Vermelha e pontuação.
/// </summary>
public class JewelRed : Jewel{
    public JewelRed() : base("JR ", 100){}
}

/// <summary>
/// Classe responsável pelo obstáculo água no mapa, e sua representação visual.
/// </summary>
public class Water : Obstacle {
    public Water() : base("## "){}
}