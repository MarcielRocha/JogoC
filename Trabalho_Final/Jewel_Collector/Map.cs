namespace Jewel_Collector;
/// <summary>
/// Map - Classe geradora pelo mapa.
/// </summary>
public class Map{
    private Cell[,] MapaJogo;
    public int h {get; private set;}
    public int w {get; private set;}

    /// <summary>
    /// Classe reponsável por gerar o mapa com tamanho 10x10.
    /// Posteriormente conforme avança, incrementa +1 ao tamanho do mapa, até o limite 30x30.
    /// </summary>
    public Map (int w=10, int h=10, int level=1)
    {
        this.w = w <= 30 ? w : 30;
        this.h = h <= 30 ? h : 30;
        MapaJogo = new Cell[w, h];
        for (int i = 0; i < MapaJogo.GetLength(0); i++) {
            for (int j = 0; j < MapaJogo.GetLength(1); j++) {
                MapaJogo[i, j] = new PreencheVazio();
            }
        }
        if (level == 1) RoundOne();
        else NextRounds();
    }
    /// <summary>
    /// Responsável por posicionar itens no mapa dentro da MapaJogo.
    /// </summary>
    public void Insert (Cell Item, int x, int y)
    {
        MapaJogo[x, y] = Item;
    }
    /// <summary>
    /// Responsável por atualizar o Status do mapa.
    /// </summary>
    public void Update(int x_old, int y_old, int x, int y)
    {
        if (x < 0 || y < 0 || x> this.w-1 || y> this.h-1)
        {
            Console.WriteLine($"\nOutOfMapException:x({x}) > w({this.w-1}) ou y({y}) > h({this.w-1})");
            throw new OutOfMapException();
        }
        if (CasaVazia(x, y))
        {
            MapaJogo[x, y] = MapaJogo[x_old, y_old];
            MapaJogo[x_old, y_old] = new PreencheVazio();
        }
        else
        {
            Console.WriteLine($"\n OccupiedPositionException:x({x}), y({y})");

            throw new OccupiedPositionException();
        }
    }
    /// <summary>
    /// Responsável por atualizar a quantidade de Jóias coletadas.
    /// </summary>
    public List<Jewel> GetJewels(int x, int y){
        List<Jewel> NearJewels = new List<Jewel>();
        int[,] Coords = GeraCoordenadas(x, y);
        for (int i = 0; i < Coords.GetLength(0); i++){
         Jewel? jewel = GetJewel(Coords[i, 0], Coords[i, 1]);
            if (jewel is not null) {
                NearJewels.Add(jewel);
            }
        }
        return NearJewels;
    }
    /// <summary>
    /// Responsável por atualizar a posição do mapa onde havia a joia para um item vazio.
    /// </summary>
    private Jewel? GetJewel(int x, int y)
    {
        if (MapaJogo[x, y] is Jewel jewel)
        {
            MapaJogo[x, y] = new PreencheVazio();
            return jewel;
        }
        return null;
    }
    /// <summary>
    /// Responsável por incrementar a energia do robo conforme coletados itens válidos.
    /// </summary>
    public Rechargeable? RecarregaRobo(int x, int y){
        int[,] Coords = GeraCoordenadas(x, y);
        for (int i = 0; i < Coords.GetLength(0); i++)
            if (MapaJogo[Coords[i, 0], Coords[i, 1]] is Rechargeable r) return r;
        return null;
    }
    /// <summary>
    /// Responsável por Gerar coordenadas.
    /// </summary>
    private int[,] GeraCoordenadas(int x, int y)
    {
        int[,] Coords = new int[4, 2]{
            {x,  y+1 < w-1 ? y+1 : w-1},
            {x, y-1 > 0 ? y-1 : 0},
            {x+1 < h-1 ? x+1 : h-1, y},
            {x-1 > 0 ? x-1 : 0, y}
        };
        return Coords;
    }
    /// <summary>q
    /// Booleana que verifica se a posição está vazia e permitida para robo transitar.
    /// </summary>
    private bool CasaVazia(int x, int y){
        return MapaJogo[x, y] is PreencheVazio;
    }
    public void PrintMap() {
        Console.Clear();
        for (int i = 0; i < MapaJogo.GetLength(0); i++){
            for (int j = 0; j < MapaJogo.GetLength(1); j++){
                if(MapaJogo[i, j] is JewelRed) Console.ForegroundColor= ConsoleColor.Red;
                else if(MapaJogo[i, j] is JewelGreen) Console.ForegroundColor= ConsoleColor.Green;
                else if(MapaJogo[i, j] is JewelBlue) Console.ForegroundColor= ConsoleColor.Blue;
                else if(MapaJogo[i, j] is Water) Console.ForegroundColor= ConsoleColor.Magenta;
                else if(MapaJogo[i, j] is Tree) Console.ForegroundColor= ConsoleColor.DarkGreen;
                else if(MapaJogo[i, j] is Robot) Console.ForegroundColor= ConsoleColor.Cyan;
                else Console.ForegroundColor= ConsoleColor.Gray;
                Console.Write(MapaJogo[i, j]);
            }
            Console.Write("\n");
        }
    }
    public bool IsDone()
    {
        for (int i = 0; i < MapaJogo.GetLength(0); i++) {
            for (int j= 0; j < MapaJogo.GetLength(1); j++){
                if (MapaJogo[i, j] is Jewel) return false;
            }
        }
        return true;
    }
    /// <summary>
    /// Gera a posição inicial das Joias, água e árvores no primeiro nível.
    /// </summary>
    private void RoundOne()
    {

        this.Insert(new Tree(), 5, 9);
        this.Insert(new Tree(), 3, 9);
        this.Insert(new Tree(), 8, 3);
        this.Insert(new Tree(), 2, 5);
        this.Insert(new Tree(), 1, 4);

        this.Insert(new Water(), 5, 0);
        this.Insert(new Water(), 5, 1);
        this.Insert(new Water(), 5, 2);
        this.Insert(new Water(), 5, 3);
        this.Insert(new Water(), 5, 4);
        this.Insert(new Water(), 5, 5);
        this.Insert(new Water(), 5, 6);

        this.Insert(new JewelGreen(), 9, 1);
        this.Insert(new JewelGreen(), 7, 6);
        this.Insert(new JewelBlue(), 3, 4);
        this.Insert(new JewelBlue(), 2, 1);
        this.Insert(new JewelRed(), 1, 9);
        this.Insert(new JewelRed(), 8, 8);

    }
    /// <summary>
    /// Gera posição aleatória dos itens do mapa no nível 2 em diante.
    /// </summary>
    private void NextRounds()
    {
        Random r = new Random(1);
        this.Insert(new Water(), r.Next(0, w), r.Next(0, h));
        this.Insert(new Water(), r.Next(0, w), r.Next(0, h));
        this.Insert(new Water(), r.Next(0, w), r.Next(0, h));
        this.Insert(new Water(), r.Next(0, w), r.Next(0, h));
        this.Insert(new Water(), r.Next(0, w), r.Next(0, h));
        this.Insert(new Water(), r.Next(0, w), r.Next(0, h));
        this.Insert(new Water(), r.Next(0, w), r.Next(0, h));
        this.Insert(new Water(), r.Next(0, w), r.Next(0, h));
        this.Insert(new Water(), r.Next(0, w), r.Next(0, h));
        this.Insert(new Water(), r.Next(0, w), r.Next(0, h));
        
        this.Insert(new Tree(), r.Next(0, w), r.Next(0, h));
        this.Insert(new Tree(), r.Next(0, w), r.Next(0, h));
        this.Insert(new Tree(), r.Next(0, w), r.Next(0, h));
        this.Insert(new Tree(), r.Next(0, w), r.Next(0, h));
        this.Insert(new Tree(), r.Next(0, w), r.Next(0, h));
        this.Insert(new Tree(), r.Next(0, w), r.Next(0, h));
        this.Insert(new Tree(), r.Next(0, w), r.Next(0, h));
        this.Insert(new Tree(), r.Next(0, w), r.Next(0, h));
        this.Insert(new Tree(), r.Next(0, w), r.Next(0, h));
        this.Insert(new Tree(), r.Next(0, w), r.Next(0, h));

        this.Insert(new JewelRed(), r.Next(0, w), r.Next(0, h));
        this.Insert(new JewelRed(), r.Next(0, w), r.Next(0, h));
        this.Insert(new JewelRed(), r.Next(0, w), r.Next(0, h));
        this.Insert(new JewelBlue(), r.Next(0, w), r.Next(0, h));
        this.Insert(new JewelBlue(), r.Next(0, w), r.Next(0, h));
        this.Insert(new JewelBlue(), r.Next(0, w), r.Next(0, h));
        this.Insert(new JewelGreen(), r.Next(0, w), r.Next(0, h));
        this.Insert(new JewelGreen(), r.Next(0, w), r.Next(0, h));
        this.Insert(new JewelGreen(), r.Next(0, w), r.Next(0, h));
    }
}

/// <summary>
/// Classe dos itens Jewels e espaços.
/// </summary>
public abstract class Cell {
    private string Symbol;
    public Cell(string Symbol)
    {
        this.Symbol = Symbol;
    }
    public sealed override string ToString()
    {
        return Symbol;
    }
}

/// <summary>
/// Classe pública responsável pelos itens vázios do mapa.
/// </summary>
public class PreencheVazio : Cell {
    public PreencheVazio() : base("-- "){}
}

/// <summary>
/// Obstáculo Árvore com recarga de 3 pontos de energia.
/// </summary>
public class Tree : Obstacle, Rechargeable {
    /// <summary>
    /// Atribui simbolo da árvore.
    /// </summary>
    public Tree() : base("$$ ") {}
    /// <summary>
    /// Incrementa energia ao estar pressionar "G" junto a árvore.
    /// </summary>
    public void Recharge(Robot r)
    {
        r.energy = r.energy+3;
    }
}
