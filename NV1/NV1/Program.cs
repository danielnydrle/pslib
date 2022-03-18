using NV1.Models;

Console.Write("Vek: ");
int vek = Int32.Parse(Console.ReadLine());
PohlaviEnum pohlavi;
Console.Write("Pohlavi (M/F): ");
string pohlaviString = Console.ReadLine();
switch (pohlaviString)
{
    case "M":
        pohlavi = PohlaviEnum.Muz;
        break;
    case "F":
        pohlavi = PohlaviEnum.Zena;
        break;
    default:
        pohlavi = PohlaviEnum.Jine;
        break;
}

Console.Write("Jmeno: ");
string jmeno = Console.ReadLine();

Osoba osoba = Osoba.GetInstance(vek, pohlavi, jmeno);
Console.WriteLine(osoba);