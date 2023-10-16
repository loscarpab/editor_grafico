using System.Transactions;

interface IGrafico
{
    public Boolean Mover(int x, int y);
    public void Dibujar();
}

public class Punto : IGrafico
{
    public int X {  get; private set; }
    public int Y{ get; private set; }
    
    public Punto(int x, int y)
    {
        X = x;
        Y = y;
    }

    public bool Mover(int x, int y)
    {
        if  ((0 > (x + X) && (x + X) > 800) && (0 > (y + Y) && (y + Y) > 600)) return true;
        else return false;
    }

    public void Dibujar()
    {
        Console.WriteLine("X -> "+ X + "Y  -> " + Y);
    }
}

public class Circulo : Punto
{
    public int Radio {  get; private set; }
    public Circulo(int x, int y, int radio) : base(x, y)
    {
        Radio = radio;
    }
    public new bool Mover (int x, int y)
    {
        if (!base.Mover(x, y)) return false;
        else if ((0 > (y + Y + Radio) || (y + Y + Radio) > 600)) return false;
        else if (0 > (x + X + Radio) || (x + X + Radio ) > 800) return false;
        else if ((0 > (y + Y - Radio) || (y + Y - Radio) > 600)) return false;
        else if (0 > (x + X - Radio) || (x + X - Radio) > 800) return false;
        else return true;
    }
    public new void Dibujar() { 
        base.Dibujar();
        Console.WriteLine("Radio -> "+Radio);
    }
}

public class Rectangulo : Punto
{
    public int Ancho { get; private set; }
    public int Alto { get; private set; }
    public Rectangulo(int x, int y, int ancho, int alto) : base(x, y)
    {
        Ancho = ancho;
        Alto = alto;
    }
    public new bool Mover(int x, int y)
    {
       if(!base.Mover(x, y)) return false;
       else if((0 < (y + Y + Alto) || (y + Y + Alto) > 600)) return true;
       else if (0 < (x + X + Ancho) || (x + X + Ancho) > 800) return true;
       else return false;
    }
    public new void Dibujar()
    {
        base.Dibujar();
        Console.WriteLine("Ancho -> " + Ancho + "Alto -> " + Alto);
    }
}

public class GraficoCompuesto : IGrafico
{
    private List<IGrafico> Elementos = new List<IGrafico>();


    public void Dibujar()
    {
        foreach (var item in Elementos)
        {
            item.Dibujar(); 
        }
    }

    public bool Mover(int x, int y)
    {
        foreach (var item in Elementos)
        {
            if (!item.Mover(x, y)) return false;
        }
        return true;
    }
}
