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
        throw new NotImplementedException();
    }

    public void Dibujar()
    {
        throw new NotImplementedException();
    }
}

public class Circulo : Punto
{
    public int Radio {  get; private set; }
    public Circulo(int x, int y, int radio) : base(x, y)
    {
        Radio = radio;
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
}

public class GraficoCompuesto : IGrafico
{
    private List<IGrafico> Graficos = new List<IGrafico>();


    public void Dibujar()
    {
        throw new NotImplementedException();
    }

    public bool Mover(int x, int y)
    {
        throw new NotImplementedException();
    }
}
