using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Transactions;

    EditorGrafico editorGrafico = new EditorGrafico();
    Punto punto = new Punto(870, 550);
    editorGrafico.AñadirGrafico(punto);
    Circulo circulo = new Circulo(50, 50, 2);
    editorGrafico.AñadirGrafico(circulo);
    Rectangulo rectangulo = new Rectangulo(100, 100, 5, 5);
    editorGrafico.AñadirGrafico(rectangulo);
    Console.WriteLine(editorGrafico.Dibujar());


public interface IGrafico
{
    public Boolean Mover(int x, int y);
    public string Dibujar();
}

public class Punto : IGrafico
{
    public int X {  get; protected set; }
    public int Y{ get; protected set; }
    
    public Punto(int x, int y)
    {
        try {
            if (x < 0 || x > 800) { throw new ArgumentOutOfRangeException("El ancho (x) no corresponde con el permitido"); }
            if (y < 0 || y > 800) { throw new ArgumentOutOfRangeException("El alto (y) no corresponde con el permitido"); }
            X = x;
            Y = y;
        }catch (ArgumentOutOfRangeException ex) 
        {
            Console.WriteLine(ex.Message);
        }
    }

    public virtual bool Mover(int x, int y)
    {
        if ((0 > (x + X) && (x + X) > 800) && (0 > (y + Y) && (y + Y) > 600)) {
            X += x;
            Y += y;
            return true; 
        }
        else return false;
    }

    public virtual string Dibujar()
    {
        return ("X -> "+ X + " Y  -> " + Y);
    }
}

public class Circulo : Punto
{
    public int Radio {  get; private set; }
    public Circulo(int x, int y, int radio) : base(x, y)
    {
        Radio = radio;
        
    }
    public override bool Mover (int x, int y)
    {
        if (!base.Mover(x, y)) return false;
        else if ((0 > (y + Y + Radio) || (y + Y + Radio) > 600)) return false;
        else if (0 > (x + X + Radio) || (x + X + Radio) > 800) return false;
        else if ((0 > (y + Y - Radio) || (y + Y - Radio) > 600)) return false;
        else if (0 > (x + X - Radio) || (x + X - Radio) > 800) return false;
        else {
            X += x;
            Y += y;
            return true;
        }
    }
    public override string Dibujar() { 
        return base.Dibujar() + " Radio -> " + Radio;
        
    }
}

public class Rectangulo : Punto
{
    public int Ancho { get; private set; }
    public int Alto { get; private set; }
    public Rectangulo(int x, int y, int ancho, int alto) : base(x, y)
    {
        try
        {
            if(x + ancho > 800) { throw new ArgumentOutOfRangeException("El ancho (x) no corresponde con el permitido "); }
            if (y + alto > 600) { throw new ArgumentOutOfRangeException("El alto (y) no corresponde con el permitido"); }
            Ancho = ancho;
            Alto = alto;
        }catch(ArgumentOutOfRangeException ex) {
            Console.WriteLine(ex.Message);
        }
        
    }
    public override bool Mover(int x, int y)
    {
        if (!base.Mover(x, y)) return false;
        else if ((0 > (y + Y + Alto) || (y + Y + Alto) > 600)) return false;
        else if (0 > (x + X + Ancho) || (x + X + Ancho) > 800) return false;
        else
        {
            X += x;
            Y += y;
            return true;
        }
    }
    public override string Dibujar()
    {
        return base.Dibujar() + " Ancho -> " + Ancho + " Alto -> " + Alto;
    }
}

public class GraficoCompuesto : IGrafico
{
    private List<IGrafico> Elementos = new List<IGrafico>();


    public void AñadirGrafico(IGrafico grafico)
    {
        Elementos.Add(grafico);
    }

    public string Dibujar()
    {
        string str = "";
        foreach (var item in Elementos)
        {
            str += item.Dibujar()+"\n"; 
        }
        return str;
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

public class EditorGrafico
{
    private GraficoCompuesto Grafico = new GraficoCompuesto();
    private int Alto = 600;
    private int Ancho = 800;

    public void AñadirGrafico(IGrafico grafico) => Grafico.AñadirGrafico(grafico);
    public string Dibujar()
    {
      return Grafico.Dibujar();
    }

}
