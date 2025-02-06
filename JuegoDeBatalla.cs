using System;

public class JuegoDeBatalla
{
	private Baraja baraja;
	private Jugador jugador;
	private Jugador maquina;

    public Baraja Baraja { get => baraja; set => baraja = value; }
    public Jugador Jugador { get => jugador; set => jugador = value; }
    public Jugador Maquina { get => maquina; set => maquina = value; }

    public JuegoDeBatalla(Baraja baraja, Jugador jugador, Jugador maquina)
    {
        this.Baraja = baraja;
        this.Jugador = jugador;
        this.Maquina = maquina;
    }

    public void Jugar(int rondas) 
    {
        int puntosJ1 = 0, puntosCPU = 0;

        for (int ronda = 1; ronda <= rondas; ronda++) 
        {
            Console.WriteLine($"--- Ronda {ronda} ---");
            Jugada(ref puntosJ1, ref puntosCPU);
        }

        ResultadosPartida(puntosJ1, puntosCPU);
    }

    public void Jugada(ref int puntosJugador, ref int puntosMaquina)
    {
        baraja.Barajar();
        jugador.Robar(baraja);
        Console.WriteLine($"Quedan {baraja.Cartas.Count} cartas");
        baraja.Barajar();
        maquina.Robar(baraja);
        Console.WriteLine($"Quedan {baraja.Cartas.Count} cartas");

        Carta cartaJ1 = Jugador.Mano[Jugador.Mano.Count - 1];
        Carta cartaCPU = Maquina.Mano[Maquina.Mano.Count - 1];

        Console.WriteLine($"Carta del Jugador: {cartaJ1.Numero} de {cartaJ1.Palo}");
        Console.WriteLine($"Carta de la Máquina: {cartaCPU.Numero} de {cartaCPU.Palo}");

        if (cartaJ1.Numero > cartaCPU.Numero)
        {
            Console.WriteLine("Enhorabuena!! Has ganado la ronda :)");
            puntosJugador++;
        }
        else if (cartaJ1.Numero < cartaCPU.Numero)
        {
            Console.WriteLine("Gana la máquina!");
            puntosMaquina++;
        }
        else
            Console.WriteLine("Habemus empate");

        Console.WriteLine("Pulsa una tecla para continuar...");
        Console.ReadKey();

    }

    public void ResultadosPartida(int puntosJ1, int puntosMaquina)
    { 
        Console.WriteLine("--- Final ---");
        Console.WriteLine($"Puntos J1 ({jugador.Nombre}): {puntosJ1}");
        Console.WriteLine($"Puntos Máquina: {puntosMaquina}");

        if (puntosJ1 > puntosMaquina)
            Console.WriteLine("Ganaste la partida!! :)");
        else if (puntosMaquina > puntosJ1)
            Console.WriteLine("Ganó la máquina la partida! >:)");
        else
            Console.WriteLine("Hay empate!");
    }
}
