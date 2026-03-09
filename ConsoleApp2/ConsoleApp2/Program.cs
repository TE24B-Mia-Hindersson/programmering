string name = "";
while (name.Length <= 1 || name.Length >= 12)
{
    Console.WriteLine("Name Plsssssssssssssssssssssss");
    name = Console.ReadLine();
    if (name.Length <= 1)
    {
        Console.WriteLine(",,");
    }
    if (name.Length >= 12)
    {
        Console.WriteLine("....");
    }
    Console.ReadLine();
    Console.Clear();
}
int stats = 0;
List<string> namestat = ["Strength", "Perception", "Endurance", "Charisma", "Intelligence", "Agility", "Luck"];
List<int> siffers = [];
while (stats < 20)
{
    Console.WriteLine($"points? \n1) Strength \n2) Perception \n3) Endurance \n4) Charisma \n5) Intelligence \n6) Agility \n7) Luck ");
    string answer = Console.ReadLine();
    


}

Console.ReadLine();

