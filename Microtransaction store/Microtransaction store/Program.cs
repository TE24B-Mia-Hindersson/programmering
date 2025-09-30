int money = 100;
string choice = "";
string choice2 = "";
string choice3 = "";
Console.WriteLine("  -------------------------");
Console.WriteLine("---===       ===       ===---");
Console.WriteLine("");
Console.WriteLine("Welcome to the Mystic Market!");
Console.WriteLine("");
Console.WriteLine("---===       ===       ===---");
Console.WriteLine("  -------------------------");
Console.ReadLine();
Console.Clear();
Console.WriteLine("------------------------------------------------------------");
Console.WriteLine($"             Here is your budget: {money} coins!");
Console.WriteLine("My market is a place full of magical items and hidden gems.");
Console.WriteLine("       Just remember to stay within your budget..");
Console.WriteLine("------------------------------------------------------------");
Console.ReadLine();
Console.Clear();
while (money > 0)
{
    while (true)
    {
        int amethystring = 30;
        int amulet = 20;
        int pearl = 40;
        Console.WriteLine("      To begin, I have three very special items..");
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("         1. A magical glowing amethyst ring");
        Console.WriteLine("                      30 coins");
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("                2. A gorgeous amulet");
        Console.WriteLine("                      20 coins");
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("   3. A pearl from the deepest depths of the ocean");
        Console.WriteLine("                      40 coins");
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("               What will you choose?");
        Console.WriteLine("  Or perhaps does nothing interest you? (write no thx)");
        choice = Console.ReadLine().Trim().ToLower();
        Console.Clear();
        if (choice.ToLower() == "1" && money >= 30)
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("   You have chosen my magical glowing amethyst ring!");
            Console.WriteLine($"    This item has removed {amethystring} coins from your wallet");
            money -= amethystring;
            Console.WriteLine($"          You now have {money} coins left!");
            Console.WriteLine("--------------------------------------------------------");
            Console.ReadLine();
            break;
        }
        else if (choice.ToLower() == "2" && money >= 20)
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("        You have chosen my gorgeous amulet !");
            Console.WriteLine($"    This item has removed {amulet} coins from your wallet");
            money -= amulet;
            Console.WriteLine($"          You now have {money} coins left!");
            Console.WriteLine("--------------------------------------------------------");
            Console.ReadLine();
            break;
        }
        else if (choice.ToLower() == "3" && money >= 40)
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("You have chosen my pearl from the deepest depths of the ocean!");
            Console.WriteLine($"     This item has removed {pearl} coins from your wallet");
            money -= pearl;
            Console.WriteLine($"          You now have {money} coins left!");
            Console.WriteLine("--------------------------------------------------------");
            Console.ReadLine();
            break;
        }
        else if (choice == "no thx")
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("       You decided not to buy anything this round.");
            Console.WriteLine("                      How sad!");
            Console.WriteLine("            Keep your money for now then..");
            Console.WriteLine($"             You have {money} coins left!");
            Console.WriteLine("--------------------------------------------------------");
            Console.ReadLine();
            break;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("       MAKE A CHOICE? or you cannot afford it! :(");
            Console.WriteLine("--------------------------------------------------------");
            Console.ReadLine();
            Console.Clear();
            continue;
        }
    }
    while (true)
    {
        Console.Clear();
        int flower = 10;
        int horn = 40;
        int potion = 40;
        Console.WriteLine("              I will now update my stock");
        Console.WriteLine("           The items I have to offer now are:");
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("                 1. A mystical flower");
        Console.WriteLine("                        10 coins");
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("                   2. A goblin horn");
        Console.WriteLine("                        40 coins");
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("   3. A magical potion with powers of invisibility");
        Console.WriteLine("                        40 coins");
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("                 What will you choose?");
        Console.WriteLine("                Or nothing? (write no thx)");
        choice2 = Console.ReadLine().Trim().ToLower();
        Console.Clear();
        if (choice2.ToLower() == "1" && money >= 10)
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("         You have chosen my mystical flower!");
            Console.WriteLine($"    This item has removed {flower} coins from your wallet");
            money -= flower;
            Console.WriteLine($"         You now have {money} coins left!");
            Console.WriteLine("--------------------------------------------------------");
            Console.ReadLine();
            break;
        }
        else if (choice2.ToLower() == "2" && money >= 40)
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("          You have chosen my goblin horn!");
            Console.WriteLine($"    This item has removed {horn} coins from your wallet");
            money -= horn;
            Console.WriteLine($"         You now have {money} coins left!");
            Console.WriteLine("--------------------------------------------------------");
            Console.ReadLine();
            break;
        }
        else if (choice2.ToLower() == "3" && money >= 40)
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("You have chosen my magical potion with powers of invisibility!");
            Console.WriteLine($"    This item has removed {potion} coins from your wallet");
            money -= potion;
            Console.WriteLine($"          You now have {money} coins left!");
            Console.WriteLine("--------------------------------------------------------");
            Console.ReadLine();
            break;
        }
        else if (choice2 == "no thx")
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("      You decided not to buy anything this time.");
            Console.WriteLine("                      How sad!");
            Console.WriteLine("              Keep your money for now then..");
            Console.WriteLine($"               You have {money} coins left!");
            Console.WriteLine("--------------------------------------------------------");
            Console.ReadLine();
            break;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("       MAKE A CHOICE? or you cannot afford it! :(");
            Console.WriteLine("--------------------------------------------------------");
            Console.ReadLine();
            Console.Clear();
            continue;
        }
    }
    while (true)
    {
        Console.Clear();
        int hat = 10;
        int tooth = 50;
        int wand = 100;
        Console.WriteLine("       I will now update my stock one last time..");
        Console.WriteLine("           The items I have to offer now are:");
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("                1. A basic wizards hat");
        Console.WriteLine("                        10 coins");
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("     2. A dragons tooth harvested with precision");
        Console.WriteLine("                        50 coins");
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("                    3. My own wand!!");
        Console.WriteLine("                        100 coins");
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("                  What will you choose?");
        Console.WriteLine("                Or nothing? (write no thx)");
        choice3 = Console.ReadLine().Trim().ToLower();
        Console.Clear();
        if (choice3.ToLower() == "1" && money >= 10)
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("       You have chosen my basic wizards hat!");
            Console.WriteLine($"    This item has removed {hat} coins from your wallet");
            money -= hat;
            Console.WriteLine($"          You now have {money} coins left!");
            Console.WriteLine("--------------------------------------------------------");
            Console.ReadLine();
            break;
        }
        else if (choice3.ToLower() == "2" && money >= 50)
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("You have chosen the dragons tooth that was harvested with precision!");
            Console.WriteLine($"    This item has removed {tooth} coins from your wallet");
            money -= tooth;
            Console.WriteLine($"          You now have {money} coins left!");
            Console.WriteLine("--------------------------------------------------------");
            Console.ReadLine();
            break;
        }
        else if (choice3.ToLower() == "3" && money >= 100)
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("             You have chosen my own wand!!");
            Console.WriteLine("                           ._.");
            Console.WriteLine($"    This item has removed {wand} coins from your wallet");
            money -= wand;
            Console.WriteLine($"            You now have {money} coins left!");
            Console.WriteLine("--------------------------------------------------------");
            Console.ReadLine();
            break;
        }
        else if (choice3 == "no thx")
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("     You decided not to buy anything this round.");
            Console.WriteLine("                      How sad!");
            Console.WriteLine("              Keep your money for now then..");
            Console.WriteLine($"              You have {money} coins left!");
            Console.WriteLine("--------------------------------------------------------");
            Console.ReadLine();
            break;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("       MAKE A CHOICE? or you cannot afford it! :(");
            Console.WriteLine("--------------------------------------------------------");
            Console.ReadLine();
            Console.Clear();
            continue;
        }
    }
    if (money == 0)
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("                You have no money left");
        Console.WriteLine("                  GET OUT OF HERE!!");
       Console.WriteLine("--------------------------------------------------------");
        Console.ReadLine();
    }
    else if (money >= 0)
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("         Would you like to take another look?");
        Console.WriteLine("                  Current items:");
        Console.WriteLine($"                         ");
        Console.WriteLine("--------------------------------------------------------");

        string response = Console.ReadLine().Trim().ToLower();

        if (response != "no")
        {
            Console.Clear();
        }

        else if (response != "yes")
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("           Thank you for coming to my shop!");
            Console.WriteLine($"         You have {money} coins remaining..");
            Console.WriteLine("--------------------------------------------------------");
            Console.ReadLine();
            Console.Clear();
        }
        else 
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("   I assume that is a no.. Goodbye");
            Console.WriteLine("--------------------------------------------------------");
            Console.ReadLine();
        }
    }
}
Console.Clear();


Console.ReadLine();