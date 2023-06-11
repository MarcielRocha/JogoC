namespace Jewel_Collector;
/// <summary>
/// Classe abstrada Obstacle
/// Objetivo: Possibilitar que classes derivadas como árvores sejam obstáculos no mapa.
/// </summary>
public abstract class Obstacle : Cell {
    public Obstacle(string Symbol) : base(Symbol) {}
}
