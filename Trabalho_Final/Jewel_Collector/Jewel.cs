namespace Jewel_Collector;

/// <summary>
/// Classe abstrata Jewel
/// Objetivo: Joia que sera capturada no jogo e pontuacao acumulada.
/// </summary>
public abstract class Jewel : Cell {
    public int Points {get; private set;}
    public Jewel(string Symbol, int Points) : base(Symbol)
    {
        this.Points = Points;
    }
}

/// <summary>
/// Classe Water
/// Objetivo: Instanciar um obstáculo do tipo água.
/// </summary>
public class Water : Obstacle {
    public Water() : base("## "){}
}

/// <summary>
/// Classe JewelBlue
/// Objetivo: Joia azul com recarga de 5 pontos de energia.
/// </summary>
public class JewelBlue : Jewel, Rechargeable {
    
    public void Recharge(Robot r)
    {
        r.energy = r.energy+5;
    }

    public JewelBlue() : base("JB ", Constants.cCarga10) {}
}

/// <summary>
/// Classe JewelGreen
/// Objetivo: Jóia Verde e pontuação.
/// </summary>
public class JewelGreen : Jewel {
    public JewelGreen() : base("JG ", Constants.cCarga50){}
}

/// <summary>
/// Classe JewelRed
/// Objetivo: Classe reponsável pela Jóia Vermelha e pontuação.
/// </summary>
public class JewelRed : Jewel{
    public JewelRed() : base("JR ", Constants.cCarga100){}
}

