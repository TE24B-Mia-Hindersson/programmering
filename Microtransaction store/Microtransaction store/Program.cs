int itempricing(string itemname)
{
    if (itemname == "Magical glowing amethyst ring") return 30;
    else if (itemname == "Gorgeous amulet") return 20;
    else if (itemname == "Pearl from the deepest depths of the ocean") return 40;
    else if (itemname == "Mystical flower") return 10;
    else if (itemname == "Goblin horn") return 40;
    else if (itemname == "Potion with powers of invisibility") return 40;
    else if (itemname == "Basic wizards hat") return 10;
    else if (itemname == "Dragons tooth that was harvested with precision") return 50;
    else if (itemname == "My own wand!!") return 100;
    else return 0;
}
int money = 100;
string choice = "";
string choice2 = "";
string choice3 = "";
List<string> items = new List<string>();
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
            items.Add("Magical glowing amethyst ring");
            Console.WriteLine($"          You now have {money} coins left!");
            Console.WriteLine("--------------------------------------------------------");
            Console.ReadLine();
            Console.Clear();
            break;
        }
        else if (choice == "2" && money >= 20)
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("        You have chosen my gorgeous amulet!");
            Console.WriteLine($"    This item has removed {amulet} coins from your wallet");
            money -= amulet;
            items.Add("Gorgeous amulet");
            Console.WriteLine($"          You now have {money} coins left!");
            Console.WriteLine("--------------------------------------------------------");
            Console.ReadLine();
            Console.Clear();
            break;
        }
        else if (choice == "3" && money >= 40)
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("You have chosen my pearl from the deepest depths of the ocean!");
            Console.WriteLine($"     This item has removed {pearl} coins from your wallet");
            money -= pearl;
            items.Add("Pearl from the deepest depths of the ocean");
            Console.WriteLine($"          You now have {money} coins left!");
            Console.WriteLine("--------------------------------------------------------");
            Console.ReadLine();
            Console.Clear();
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
            Console.Clear();
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
            items.Add("Mystical flower");
            Console.WriteLine($"         You now have {money} coins left!");
            Console.WriteLine("--------------------------------------------------------");
            Console.ReadLine();
            Console.Clear();
            break;
        }
        else if (choice2 == "2" && money >= 40)
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("          You have chosen my goblin horn!");
            Console.WriteLine($"    This item has removed {horn} coins from your wallet");
            money -= horn;
            items.Add("Goblin horn");
            Console.WriteLine($"         You now have {money} coins left!");
            Console.WriteLine("--------------------------------------------------------");
            Console.ReadLine();
            Console.Clear();
            break;
        }
        else if (choice2 == "3" && money >= 40)
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("You have chosen my magical potion with powers of invisibility!");
            Console.WriteLine($"    This item has removed {potion} coins from your wallet");
            money -= potion;
            items.Add("Potion with powers of invisibility");
            Console.WriteLine($"          You now have {money} coins left!");
            Console.WriteLine("--------------------------------------------------------");
            Console.ReadLine();
            Console.Clear();
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
            Console.Clear();
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
            items.Add("Basic wizards hat");
            Console.WriteLine($"          You now have {money} coins left!");
            Console.WriteLine("--------------------------------------------------------");
            Console.ReadLine();
            Console.Clear();
            break;
        }
        else if (choice3 == "2" && money >= 50)
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("You have chosen the dragons tooth that was harvested with precision!");
            Console.WriteLine($"    This item has removed {tooth} coins from your wallet");
            money -= tooth;
            items.Add("Dragons tooth that was harvested with precision");
            Console.WriteLine($"          You now have {money} coins left!");
            Console.WriteLine("--------------------------------------------------------");
            Console.ReadLine();
            Console.Clear();
            break;
        }
        else if (choice3 == "3" && money >= 100)
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("             You have chosen my own wand!!");
            Console.WriteLine("                           ._.");
            Console.WriteLine($"    This item has removed {wand} coins from your wallet");
            money -= wand;
            items.Add("My own wand!!");
            Console.WriteLine($"            You now have {money} coins left!");
            Console.WriteLine("--------------------------------------------------------");
            Console.ReadLine();
            Console.Clear();
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
            Console.Clear();
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
        if (items.Count == 0)
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("               You have no items to sell.");
            Console.WriteLine("--------------------------------------------------------");
            Console.ReadLine();
            break;
        }
        Console.WriteLine("---------------------------------------------------------------------------------");
        Console.WriteLine("                        Here are you items:");
        for (int i = 0; i < items.Count; i++)
        {
            int sellPrice = itempricing(items[i]) / 2;
            Console.WriteLine($"          {i + 1}. {items[i]} (Sell for {sellPrice} coins)");
        }
        Console.WriteLine("Tell me the number of what item youd like to sell or type no to leave my store:");
        Console.WriteLine("---------------------------------------------------------------------------------");
        string sellchoice = Console.ReadLine().Trim().ToLower();
        Console.Clear();
        if (sellchoice == "no")
        {
            break;
        }
        else if (sellchoice == "1" && items.Count >= 1)
        {
            int sellPrice = itempricing(items[0]) / 2;
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine($"   You sold {items[0]} for {sellPrice} coins.");
            Console.WriteLine("--------------------------------------------------------");
            money += sellPrice;
            items.RemoveAt(0);
            Console.ReadLine();
            Console.Clear();
        }
        else if (sellchoice == "2" && items.Count >= 2)
        {
            int sellPrice = itempricing(items[1]) / 2;
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine($"   You sold {items[1]} for {sellPrice} coins.");
            Console.WriteLine("--------------------------------------------------------");
            money += sellPrice;
            items.RemoveAt(1);
            Console.ReadLine();
            Console.Clear();
        }
        else if (sellchoice == "3" && items.Count >= 3)
        {
            int sellPrice = itempricing(items[2]) / 2;
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine($"   You sold {items[2]} for {sellPrice} coins.");
            Console.WriteLine("--------------------------------------------------------");
            money += sellPrice;
            items.RemoveAt(2);
            Console.ReadLine();
            Console.Clear();
        }
        else if (sellchoice == "4" && items.Count >= 4)
        {
            int sellPrice = itempricing(items[3]) / 2;
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine($"    You sold {items[3]} for {sellPrice} coins.");
            Console.WriteLine("--------------------------------------------------------");
            money += sellPrice;
            items.RemoveAt(3);
            Console.ReadLine();
            Console.Clear();
        }
        else if (sellchoice == "5" && items.Count >= 5)
        {
            int sellPrice = itempricing(items[4]) / 2;
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine($"   You sold {items[4]} for {sellPrice} coins.");
            Console.WriteLine("--------------------------------------------------------");
            money += sellPrice;
            items.RemoveAt(4);
            Console.ReadLine();
            Console.Clear();
        }
        else if (sellchoice == "6" && items.Count >= 6)
        {
            int sellPrice = itempricing(items[5]) / 2;
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine($"   You sold {items[5]} for {sellPrice} coins.");
            Console.WriteLine("--------------------------------------------------------");
            money += sellPrice;
            items.RemoveAt(5);
            Console.ReadLine();
            Console.Clear();
        }
        else if (sellchoice == "7" && items.Count >= 7)
        {
            int sellPrice = itempricing(items[6]) / 2;
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine($"   You sold {items[6]} for {sellPrice} coins.");
            Console.WriteLine("--------------------------------------------------------");
            money += sellPrice;
            items.RemoveAt(6);
            Console.ReadLine();
            Console.Clear();
        }
        else if (sellchoice == "8" && items.Count >= 8)
        {
            int sellPrice = itempricing(items[7]) / 2;
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine($"   You sold {items[7]} for {sellPrice} coins.");
            Console.WriteLine("--------------------------------------------------------");
            money += sellPrice;
            items.RemoveAt(7);
            Console.ReadLine();
            Console.Clear();
        }
        else if (sellchoice == "9" && items.Count >= 9)
        {
            int sellPrice = itempricing(items[8]) / 2;
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine($"    You sold {items[8]} for {sellPrice} coins.");
            Console.WriteLine("--------------------------------------------------------");
            money += sellPrice;
            items.RemoveAt(8);
            Console.ReadLine();
            Console.Clear();
        }
        else
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("        I didnt catch that.. try again!");
            Console.WriteLine("--------------------------------------------------------");
            Console.ReadLine();
            continue;
        }
        Console.Clear();
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine($"         You now have {money} coins!");
        Console.WriteLine("   Press Enter to continue selling or type no to stop.");
        Console.WriteLine("--------------------------------------------------------");
        string cont = Console.ReadLine().Trim().ToLower();
        Console.Clear();
        if (cont == "no")
            break;
    }
    Console.Clear();
    while (true)
    {
        if (money == 0)
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("                You have no money left");
            Console.WriteLine("                  GET OUT OF HERE!!");
            Console.WriteLine("                 Current items:");

            if (items.Count > 0)
            {
                foreach (var item in items)
                {
                    Console.WriteLine($"                - {item}");
                }
            }
            else
            {
                Console.WriteLine("            No items purchased yet.");
            }
            Console.WriteLine("--------------------------------------------------------");
            Console.ReadLine();
            return;
        }
        else if (money >= 0)
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("         Would you like to take another look?");
            Console.WriteLine("                 Current items:");

            if (items.Count > 0)
            {
                foreach (var item in items)
                {
                    Console.WriteLine($"            - {item}");
                }
            }
            else
            {
                Console.WriteLine("            No items purchased yet.");
            }
            Console.WriteLine("--------------------------------------------------------");
            string response = Console.ReadLine().Trim().ToLower();
            if (response != "no")
            {
                Console.Clear();
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine("           Thank you for coming to my shop!");
                Console.WriteLine($"         You have {money} coins remaining..");
                Console.WriteLine($"            Have a continued nice day!!");
                Console.WriteLine("                 Current items:");

                if (items.Count > 0)
                {
                    foreach (var item in items)
                    {
                        Console.WriteLine($"            - {item}");
                    }
                }
                else
                {
                    Console.WriteLine("            No items purchased yet.");
                }

                Console.WriteLine("--------------------------------------------------------");
                Console.ReadLine();
                Console.Clear();
                Console.ReadLine();
                break;
            }

            else if (response != "yes")
            {
                Console.Clear();
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine("           Thank you for coming to my shop!");
                Console.WriteLine($"         You have {money} coins remaining..");
                Console.WriteLine("                 Current items:");

                if (items.Count > 0)
                {
                    foreach (var item in items)
                    {
                        Console.WriteLine($"            - {item}");
                    }
                }
                else
                {
                    Console.WriteLine("            No items purchased yet.");
                }

                Console.WriteLine("--------------------------------------------------------");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine("   I assume that is a no.. Goodbye");
                Console.WriteLine("                 Current items:");

                if (items.Count > 0)
                {
                    foreach (var item in items)
                    {
                        Console.WriteLine($"            - {item}");
                    }
                }
                else
                {
                    Console.WriteLine("            No items purchased yet.");
                }
                Console.WriteLine("--------------------------------------------------------");
                Console.ReadLine();
            }
        }
    }
}

Console.ReadLine();