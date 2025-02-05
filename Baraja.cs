using System;

public class Baraja
{
    private List<Carta> cartas;
    public List<Carta> Cartas { get => cartas; }
    public Baraja()
    {
        cartas = new List<Carta>();
        // Añadir las cartas de la baraja española
        string[] palos = { "Oros", "Copas", "Espadas", "Bastos" };
        for (int i = 1; i <= 12; i++)  // Asumiendo que la baraja tiene 12 cartas por palo
        {
            foreach (string palo in palos)
            {
                cartas.Add(new Carta(palo, i));  // Crear cartas del 1 al 12 para cada palo
            }
        }
    }

    public Baraja(List<Carta> cartas)
    {
        this.cartas = new List<Carta>(cartas);
    }

    public void Barajar() 
    { 
        Random rnd = new Random();
        for (int i = 0; i < cartas.Count - 1; i++)
        { 
            int j = rnd.Next(i, cartas.Count);
            (cartas[i], cartas[j]) = (cartas[j], cartas[i]);
        }
    }

    public Carta RobarPrimeraCarta() 
    {
        return RobarCartaEnPosicion(0);
    }

    public Carta RobarCartaAlAzar()
    {
        Random rnd = new Random();
        int azar = rnd.Next(cartas.Count);
        return RobarCartaEnPosicion(azar);
    }

    public Carta RobarCartaEnPosicion(int posicion) 
    {
        if (cartas.Count == 0)
        {
            Console.WriteLine("La baraja se acabó :(");
            return null;
        }
        
        if (posicion < 0 || posicion >= cartas.Count) 
        {
            Console.WriteLine("Por favor, roba dentro de una posición válida");
            return null;
        }
        Carta robada = cartas[posicion];
        cartas.RemoveAt(posicion);
        return robada;
    }

    public void Mostrar()
    {
        if (cartas.Count == 0)
        {
            Console.WriteLine("La baraja está vacía.");
            return;
        }

        foreach (var carta in cartas)
        {
            Console.WriteLine($"{carta.Numero} de {carta.Palo}");
        }
    }

}
