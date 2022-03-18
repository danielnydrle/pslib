using NV2.Models;

Console.WriteLine("Robot 1");
Console.Write("\n");
Robot robot1 = new Robot();
Ovladac.PredejPovel(robot1, new Povel(Modul.ModulType.Brouseni, 5, "karoserie"));
Ovladac.PredejPovel(robot1, new Povel(Modul.ModulType.Brouseni, 5, "karoserie"));
robot1.VypisCinnosti();
Ovladac.PredejPovel(robot1, new Povel(Modul.ModulType.Svarovani, 10, "karoserie"));
robot1.VypisCinnosti();
Console.Write("\n\n\n");

Console.WriteLine("Robot 2");
Console.Write("\n");
Robot robot2 = new Robot();
Ovladac.PredejPovel(robot2, new Povel(Modul.ModulType.Svarovani, 15, ""));
Ovladac.PredejPovel(robot2, new Povel(Modul.ModulType.Rezani, 10, ""));
robot2.VypisCinnosti();
Ovladac.PredejPovel(robot2, new Povel(Modul.ModulType.Rezani, 10, ""));
Ovladac.PredejPovel(robot2, new Povel(Modul.ModulType.Rezani, 10, ""));
robot2.VypisCinnosti();