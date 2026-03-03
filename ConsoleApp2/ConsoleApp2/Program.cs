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


