namespace Jewel_Collector;

/// <summary>
/// Joia que sera capturada no jogo e pontuacao acumulada.
/// </summary>
public abstract class Jewel : ItemMap {
    public int Points {get; private set;}
    public Jewel(string Symbol, int Points) : base(Symbol)
    {
        this.Points = Points;
    }
}

/// <summary>
/// Obstaculo de agua do jogo.
/// </summary>
public class Water : Obstacle {
    public Water() : base("## "){}
}

/// <summary>
/// Joia azul com recarga de 5 pontos de energia.
/// </summary>
public class JewelBlue : Jewel, Rechargeable {
    
    public void Recharge(Robot r)
    {
        r.energy = r.energy+5;
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

