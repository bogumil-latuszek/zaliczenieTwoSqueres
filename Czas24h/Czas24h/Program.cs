using System;

public class Program
{
    public static void Main()
    {
        string[] napis = null;
        Czas24h t = null;

        // wczytanie i parsowanie napisu oznaczającego godzinę, np. 2:15:27
        napis = Console.ReadLine().Split(':');
        int[] czas = Array.ConvertAll(napis, int.Parse);
        try
        {
            t = new Czas24h(czas[0], czas[1], czas[2]);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("error");
            return;
        }

        // wczytanie liczby poleceń
        int liczbaPolecen = int.Parse(Console.ReadLine());

        for (int i = 1; i <= liczbaPolecen; i++)
        {
            // wczytanie polecenia
            napis = Console.ReadLine().Split(' ');
            string typPolecenia = napis[0];
            int liczba = int.Parse(napis[1]);

            // wykonanie polecenia na obiekcie t typu Czas24h
            try
            {
                switch (typPolecenia)
                {
                    case "g":
                        if (liczba < 0 || liczba > 23)
                        {
                            throw new ArgumentException();
                        }
                        t.Godzina = liczba;
                        break;
                    case "m":
                        if (liczba < 0 || liczba > 60)
                        {
                            throw new ArgumentException();
                        }
                        t.Minuta = liczba;
                        break;
                    case "s":
                        if (liczba < 0 || liczba > 60)
                        {
                            throw new ArgumentException();
                        }
                        t.Sekunda = liczba;
                        break;
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("error");
                return;
            }
        }
        Console.WriteLine(t);
    }
}

public class Czas24h
{
    private int liczbaSekund;
    private int aktualizacjaCzasu(int staryCzas, int nowyCzas, string jednostkaCzasu)
    {
        int h;
        int min;
        int s;
        int zaktCzas;
        h = staryCzas / 3600;
        staryCzas = staryCzas % 3600;
        min = staryCzas / 60;
        staryCzas = staryCzas % 60;
        s = staryCzas;
        if(jednostkaCzasu == "godzina")
        {
            zaktCzas = nowyCzas * 3600 + min * 60 + s;
        }
        else if(jednostkaCzasu == "minuta")
        {
            zaktCzas = h * 3600 + nowyCzas * 60 + s;
        }
        else if (jednostkaCzasu == "sekunda")
        {
            zaktCzas = h * 3600 + min * 60 + nowyCzas;
        }
        else
        {
            throw new Exception("unnown exception");
        }
        return zaktCzas;
    }
    public int Sekunda
    {
        get => liczbaSekund - Godzina * 60 * 60 - Minuta * 60;
        set => liczbaSekund = aktualizacjaCzasu(liczbaSekund, value , "sekunda");
    }

    public int Minuta
    {
        get => (liczbaSekund / 60) % 60;
        set => liczbaSekund = aktualizacjaCzasu(liczbaSekund, value, "minuta");
    }

    public int Godzina
    {
        get => liczbaSekund / 3600;
        set => liczbaSekund = aktualizacjaCzasu(liczbaSekund, value, "godzina");
    }

    public Czas24h(int godzina, int minuta, int sekunda)
    {
        // uzupełnij kod zgłaszając wyjątek ArgumentException
        // w sytuacji niepoprawnych danych

            if (godzina < 0 || godzina > 23|| minuta < 0 || minuta > 60||sekunda < 0 || sekunda > 60)
            {
                throw new ArgumentException();
            }
        liczbaSekund = sekunda + 60 * minuta + 3600 * godzina;
    }

    public override string ToString() => $"{Godzina}:{Minuta:D2}:{Sekunda:D2}";
}
