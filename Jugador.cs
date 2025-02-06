using System;

public class Jugador
{
    private string nombre;
    private List<Carta?> mano;

    public string Nombre { get => nombre; set => nombre = value; }
    public List<Carta?> Mano { get => mano; set => mano = value; }

    public Jugador(string nombre)
    {
        this.nombre = nombre;
        mano = new List<Carta?>();
    }

    public void Robar(Baraja baraja) 
    {
        Carta? robada = baraja.RobarPrimeraCarta();
        mano.Add(robada);
        Console.WriteLine("Carta robada");
    }

    public void MostrarMano()
    {
        Console.WriteLine($"Cartas de {Nombre}");

        foreach (Carta? c in mano)
        {
            Console.WriteLine($"{c.Numero} de {c.Palo}");
        }
    }
}
