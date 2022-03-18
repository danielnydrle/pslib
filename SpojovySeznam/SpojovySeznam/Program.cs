// See https://aka.ms/new-console-template for more information
SpojovySeznam<int> seznam = new SpojovySeznam<int>();
seznam.VlozNaZacatek(1);
seznam.VlozNaKonec(2);
seznam.VlozNaIndex(1, 4);
seznam.VypisPrvky();

class SpojovySeznam<T>
{
    Uzel zacatek/*, konec*/;
    class Uzel
    {
        public T data;
        public Uzel dalsi/*, predchozi*/;

        public Uzel(T data, SpojovySeznam<T>.Uzel dalsi, SpojovySeznam<T>.Uzel predchozi)
        {
            this.data = data;
            this.dalsi = dalsi;
            //this.predchozi = predchozi;
        }
    }

    public void VlozNaZacatek(T vstup)
    {
        Uzel novy = new Uzel(vstup, zacatek, null);
        zacatek = novy;
    }

    public void VlozNaKonec(T vstup)
    {
        Uzel docasny = zacatek;
        Uzel novy = new Uzel(vstup, null, docasny);
        if (zacatek == null)
        {
            zacatek = novy;
            return;
        }
        while (docasny.dalsi != null)
        {
            docasny = docasny.dalsi;
        }
        //novy.predchozi = docasny;
        docasny.dalsi = novy;
        //konec = novy;
    }

    public void VypisPrvky()
    {
        Uzel docasny = zacatek;
        while (docasny != null)
        {
            Console.WriteLine(docasny.data);
            if (docasny.dalsi != null) docasny = docasny.dalsi;
            else docasny = null;
        }
    }

    public void VlozNaIndex(int index, T vstup)
    {
        Uzel docasny = zacatek;
        for (int i = 0; i < index - 1; i++)
        {
            docasny = docasny.dalsi;
        }
        if (index == 0) zacatek = new Uzel(vstup, zacatek, null);
        else docasny.dalsi = new Uzel(vstup, docasny.dalsi, null);
    }

    public void Zatrid(T vstup)
    {

    }

    public void Odeber()
    {

    }
}