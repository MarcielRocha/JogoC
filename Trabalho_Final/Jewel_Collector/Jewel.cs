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
/// Classe responsável pelo obstáculo água no mapa, e sua representação visual.
/// </summary>
public class Water : Obstacle {
    public Water() : base("## "){}
}

/// <summary>
/// Classe reponsável pela Jóia Azul, pontuação e recarregar energia
/// </summary>
public class JewelBlue : Jewel, Rechargeable {
    
    public void Recharge(Robot r)
    {
        r.energy = r.energy+3;
    }

    public JewelBlue() : base("JB ", Constants.cCarga10) {}
}

/// <summary>
/// Classe reponsável pela Jóia Verde e pontuação.
/// </summary>
public class JewelGreen : Jewel {
    public JewelGreen() : base("JG ", Constants.cCarga50){}
}

/// <summary>
/// Classe reponsável pela Jóia Vermelha e pontuação.
/// </summary>
public class JewelRed : Jewel{
    public JewelRed() : base("JR ", Constants.cCarga100){}
}

