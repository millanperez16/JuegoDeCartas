using System;

public class Juego
{
    static void Main(string[] args)
    {
        InicializacionJuego();
    }

    static void InicializacionJuego()
    {
        Baraja baraja = new Baraja();

        Console.WriteLine("Te invito a jugar conmigo a las cartas. ¿Cómo te llamas?");
        string nombreJ1 = Console.ReadLine();
        Jugador jugador = new Jugador(nombreJ1);
        Jugador maquina = new Jugador("Máquina");

        JuegoDeBatalla juego = new JuegoDeBatalla(baraja, jugador, maquina);

        baraja.Barajar();
        AsignarCartas(baraja, jugador, maquina);

        Console.WriteLine("¿A cuántas rondas jugamos?");
        int numRondas = Convert.ToInt32(Console.ReadLine());
        juego.Jugar(numRondas);
    }

    static void AsignarCartas(Baraja baraja, Jugador jugador, Jugador maquina)
    {
        for (int i = 0; i < 5; i++)
        {
            jugador.Robar(baraja);
            maquina.Robar(baraja);
        }
    }
}
