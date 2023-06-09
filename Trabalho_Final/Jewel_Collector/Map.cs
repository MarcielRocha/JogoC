namespace Jewel_Collector;
/// <summary>
/// Map - Classe geradora pelo mapa.
/// </summary>
public class Map
{
    private ItemMap[,] Matriz;
    public int x {get; private set;}
    public int y {get; private set;}

    /// <summary>
    /// Classe mapa.
    /// </summary>
    public Map (int x=10, int y=10, int level=1)
    {
        this.x = x <= 30 ? x : 30;
        this.y = y <= 30 ? y : 30;
        Matriz = new ItemMap[x, y];
        for (int i = 0; i < Matriz.GetLength(0); i++) {
            for (int j = 0; j < Matriz.GetLength(1); j++) {
                Matriz[i, j] = new Empty();
            }
        }
        if (level == 1) GenerateFixed();
        else GenerateRandom();
    }
    /// <summary>
    /// Responsável por posicionar itens no mapa dentro da matriz.
    /// </summary>
    public void Insert (ItemMap Item, int x, int y)
    {
        Matriz[x, y] = Item;
    }
    /// <summary>
    /// Responsável por atualizar o Status do mapa.
    /// </summary>
    public void Update(int x_old, int y_old, int x, int y)
    {
        if (x < 0 || y < 0 || x> this.x-1 || y> this.y-1)
        {
            Console.WriteLine($"\nOutOfMapException:x({x}) > w({this.x-1}) ou y({y}) > h({this.y-1})");
            throw new OutOfMapException();
        }
        if (IsAllowed(x, y))
        {
            Matriz[x, y] = Matriz[x_old, y_old];
            Matriz[x_old, y_old] = new Empty();
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
        int[,] Coords = GenerateCoord(x, y);
        for (int i = 0; i < Coords.GetLength(0); i++){
            Jewel? jewel = GetJewel(Coords[i, 0], Coords[i, 1]);
            if (jewel is not null) NearJewels.Add(jewel);
        }
        return NearJewels;
    }
    /// <summary>
    /// Responsável por atualizar a posição do mapa onde havia a joia para um item vazio.
    /// </summary>
    private Jewel? GetJewel(int x, int y)
    {
        if (Matriz[x, y] is Jewel jewel)
        {
            Matriz[x, y] = new Empty();
            return jewel;
        }
        return null;
    }
    /// <summary>
    /// Responsável por incrementar a energia do robo conforme coletados itens válidos.
    /// </summary>
    public Rechargeable? GetRechargeable(int x, int y){
        int[,] Coords = GenerateCoord(x, y);
        for (int i = 0; i < Coords.GetLength(0); i++)
            if (Matriz[Coords[i, 0], Coords[i, 1]] is Rechargeable r) return r;
        return null;
    }
    /// <summary>
    /// Responsável por Gerar coordenadas.
    /// </summary>
    private int[,] GenerateCoord(int i, int j)
    {
        int[,] Coords = new int[4, 2]{
            {i,  j+1 < x-1 ? j+1 : x-1},
            {i, j-1 > 0 ? j-1 : 0},
            {i+1 < y-1 ? i+1 : y-1, j},
            {i-1 > 0 ? i-1 : 0, j}
        };
        return Coords;
    }
    /// <summary>
    /// Booleana que verifica se a posição está vazia e permitida para robo transitar.
    /// </summary>
    private bool IsAllowed(int x, int y){
        return Matriz[x, y] is Empty;
    }
    public void Print() {
        for (int i = 0; i < Matriz. GetLength(0); i++){
            for (int j = 0; j < Matriz.GetLength(1); j++){
                Console.Write(Matriz[i, j]);
            }
            Console.Write("\n");
        }
    }
    public bool IsDone()
    {
        for (int i = 0; i < Matriz.GetLength(0); i++) {
            for (int j= 0; j < Matriz.GetLength(1); j++){
                if (Matriz[i, j] is Jewel) return false;
            }
        }
        return true;
    }
    /// <summary>
    /// Gera a posição inicial das Joias, água e árvores no primeiro nível.
    /// </summary>
    private void GenerateFixed()
    {
        this.Insert(new JewelRed(), 1, 9);
        this.Insert(new JewelRed(), 8, 8);
        this.Insert(new JewelGreen(), 9, 1);
        this.Insert(new JewelGreen(), 7, 6);
        this.Insert(new JewelBlue(), 3, 4);
        this.Insert(new JewelBlue(), 2, 1);

        this.Insert(new Water(), 5, 0);
        this.Insert(new Water(), 5, 1);
        this.Insert(new Water(), 5, 2);
        this.Insert(new Water(), 5, 3);
        this.Insert(new Water(), 5, 4);
        this.Insert(new Water(), 5, 5);
        this.Insert(new Water(), 5, 6);
        this.Insert(new Tree(), 5, 9);
        this.Insert(new Tree(), 3, 9);
        this.Insert(new Tree(), 8, 3);
        this.Insert(new Tree(), 2, 5);
        this.Insert(new Tree(), 1, 4);
    }
    /// <summary>
    /// Gera posição aleatória dos itens do mapa no nível 2 em diante.
    /// </summary>
    private void GenerateRandom()
    {
        Random r = new Random(1);
        for(int i = 0; i < 3; i++)
        {
            int xRandom = r.Next(0, x);
            int yRandom = r.Next(0, y);
            this.Insert(new JewelBlue(), xRandom, yRandom);
        }
        for(int i = 0; i < 3; i++)
        {
            int xRandom = r.Next(0, x);
            int yRandom = r.Next(0, y);
            this.Insert(new JewelGreen(), xRandom, yRandom);
        }
        for(int i = 0; i < 3; i++)
        {
            int xRandom = r.Next(0, x);
            int yRandom = r.Next(0, y);
            this.Insert(new JewelRed(), xRandom, yRandom);
        }
        for(int i = 0; i < 10; i++)
        {
            int xRandom = r.Next(0, x);
            int yRandom = r.Next(0, y);
            this.Insert(new Water(), xRandom, yRandom);
        }
        for(int i = 0; i < 10; i++)
        {
            int xRandom = r.Next(0, x);
            int yRandom = r.Next(0, y);
            this.Insert(new Tree(), xRandom, yRandom);
        }
    }


}

/// <summary>
/// Classe dos itens Jewels e espaços.
/// </summary>
public abstract class ItemMap {
    private string Symbol;
    public ItemMap(string Symbol)
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
public class Empty : ItemMap {
    public Empty() : base("-- "){}
}

/// <summary>
/// Classe responsável pelo item do mapa árvore
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
        r.energy++;
        r.energy++;
        r.energy++;
    }
}
