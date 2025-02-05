using System;

public class Carta
{
    private string palo;
    private int numero;

    public string Palo { get => palo; set => palo = value; }
    public int Numero { get => numero; set => numero = value; }

    public Carta()
    {

    }

    public Carta(string palo, int numero)
    {
        this.Palo = palo;
        this.Numero = numero;
    }
}
