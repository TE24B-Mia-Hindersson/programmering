

using System.ComponentModel;
using System.Runtime.Serialization;
Console.WriteLine("You slowly start to gain conciousness as the cryosleep chamber opens.. \nAs you look around you realize you have no recollection of anything. \nYou stand up, shakingly, and move slowly forward. \nYou glance at your surroundings and find an abandoned facility. You start to feel worried, thinking of what couldve happened. \nYour memory is hazy. You reach a mirror and peer into it.");
Console.ReadLine();
Console.Clear();
int gamestage = 0;
// -- name selection--
string name = "";
while (name.Length <= 1 || name.Length >= 12)
{
    Console.WriteLine("Upon seeing your reflection you gain a glimps into your memory... Your name is:");
    name = Console.ReadLine();
    if (name.Length <= 1)
    {
        Console.WriteLine("Thats very short... try again?");
    }
    if (name.Length >= 12)
    {
        Console.WriteLine("Thats very long... try again?");
    }
    Console.ReadLine();
    Console.Clear();
}
// -- stat distrubution --
List<string> StatName = ["Strength", "Perception", "Endurance", "Charisma", "Intelligence", "Agility", "Luck"];
List<int> siffers = [0, 0, 0, 0, 0, 0, 0];
DistrubuteStats(siffers, StatName);
Console.ReadLine();
Console.Clear();
Console.WriteLine($"Welcome, {name} \n");
ShowStats(siffers, StatName);
gamestage++;
Console.WriteLine("press enter to leave (story stuff)");
Console.ReadLine();
Console.Clear();
// -- main story begins --
int playerhealth = 20;
int radiation = 0;
if (siffers[1] >= 5) // perception check (if perception is chosen stat: applies)
// --LAKE--
{
    Console.WriteLine("\n Your sharp senses notice strange footprints in the dirt");
    Console.WriteLine("Following the tracks, you arrive at a small lake");
    Console.WriteLine("The water is strangely clear");
}
else
{
    Console.WriteLine("\n You feel uneasy, but you cant pinpoint why");
    Console.WriteLine("You walk between the trees..");
    Console.WriteLine("Suddenly you fall down and injure yourself");
    Console.WriteLine("Upon getting back up you notice a lake a while infront of you");
    Console.WriteLine("You limp over..");
    playerhealth -= 3;
}
Console.WriteLine("1) Drink some");
Console.WriteLine("2) Leave it alone..");
Console.WriteLine("3) Examine the water");
string WaterChoice = Console.ReadLine();

if (WaterChoice == "1")
{
    Console.WriteLine("You drink the water.");
    Console.WriteLine("The water has an odd taste that almost burns your mouth");
    radiation += 10;
    playerhealth -= 2;
    Console.WriteLine("Your stomach twists painfully.");
    Console.WriteLine("Radiation +10");
    Console.WriteLine("Health -4");
    //explain radiation and health?
    siffers[2] += 1; //endurance
    Console.WriteLine("Endurance +1");
}
else if (WaterChoice == "2")
{
    Console.WriteLine("Something about the water feels off...");
    Console.WriteLine("You decide to not risk drinking it..");
    siffers[6] += 1; //luck
    Console.WriteLine("Luck +1");
}
else if (WaterChoice == "3")
{
    if (siffers[4] >= 4 || siffers[1] >= 4) //intelligence or perception
    {
        Console.WriteLine("\nLooking closely at the water..");
        Console.WriteLine("You notice dead fish floating beneath the surface");
        Console.WriteLine("A strange oily residue moves across the water..");
        Console.WriteLine("This water is contaminated!");
        siffers[4] += 1; //intelligence 
        Console.WriteLine("Intelligence +1");
    }
    else
    {
        Console.WriteLine("\nYou stare at the water and cant decide if anythings wrong..");
        Console.WriteLine("You end up not drinking any.");
    }
}
Console.ReadLine();
Console.Clear();
// -- intro to radiation --
if (radiation >= 10)
{
    Console.WriteLine("\nYou feel weak");
    Console.WriteLine("Your body feels strange.. the radiation might be effecting you.");
    playerhealth -= 1;
}
Console.WriteLine($"Health: {playerhealth}");
Console.WriteLine($"Radiation: {radiation}");
Console.ReadLine();
Console.Clear();

// -- first fight encounter --
threat(gamestage, playerhealth);
if (playerhealth <= 0)
{
    Console.WriteLine("You have died!");
    Console.WriteLine("Game over..");
    return;
}
Console.WriteLine("After a near death experience, and one of your first combat encounters you quickly move as far away from the area as possible.");
Console.WriteLine("Suddenly you arrive at an old abandoned road. The road almost crumbling under your feet..");
Console.WriteLine("Continuing forward you start to notice signs of human life..");
Console.WriteLine("You discover a small settlement. A sign hangs ifront of a wooden wall.. 'Ash hallow'");
// --Ash hallow--
Console.ReadLine();
Console.Clear();
Console.WriteLine("A guard stops you..");
guarddialogue();
static void guarddialogue()
{
    Console.WriteLine("Guard: Halt! Explain your purpose for coming here!");
    Console.WriteLine("1) 'I am just a traveler seeking shelter.. i mean no harm!' \n2) 'None of your business.' \n3) Stay silent.");
    string dialoguechoice = Console.ReadLine();

}
static void threat(int gamestage, int playerhealth)
{
    Random rng = new Random();
    string enemy;
    if (gamestage <= 0)
    {
        string[] enemies = { "Mutated Rat", "Rad Roach" };
        enemy = enemies[rng.Next(enemies.Length)];
    }
    if (gamestage <= 3)
    {
        string[] enemies = { "Wild Dog", "Feral Human" };
        enemy = enemies[rng.Next(enemies.Length)];
    }
    else
    {
        string[] enemies = { "Mutant Wolf", "Radiated Bear" };
        enemy = enemies[rng.Next(enemies.Length)];
    }
    int enemyHealth = 5 + (gamestage * 4);
    int enemyDamage = 1 + gamestage;
    Console.WriteLine("\nYou suddenly hear movement in the forest");
    Console.WriteLine($"A {enemy} comes out from behind the trees!");
    Console.WriteLine($" Enemy Health: {enemyHealth}");
    Console.WriteLine($" Enemy Damage: {enemyDamage}");
    while (enemyHealth > 0 && playerhealth > 0)
    {
        Console.WriteLine($"\nYour health: {playerhealth}");
        Console.WriteLine("Choose action: \n1)Attack \n2)Run");

        string fightchoice = Console.ReadLine();
        if (fightchoice == "1") //attack
        {
            int damage = rng.Next(2, 7); //player dmg
            enemyHealth -= damage;
            Console.WriteLine($"You hit the {enemy} for {damage} damage!");
            if (enemyHealth <= 0)
            {
                Console.WriteLine($"You defeated the {enemy}!");
                break;
            }
            int enemyattack = rng.Next(1, enemyDamage + 1);
            playerhealth -= enemyattack;
            Console.WriteLine($"The {enemy} hits you for {enemyattack} damage");
        }
        else if (fightchoice == "2") //rum
        {
            int escape = rng.Next(0, 2); //1/2 chance 
            if (escape == 1)
            {
                Console.WriteLine("You managed to escape!");
                break;
            }
            else
            {
                Console.WriteLine("You failed to escape!");
                int enemyattack = rng.Next(1, enemyDamage + 1);
                playerhealth -= enemyattack;
                Console.WriteLine($"The {enemy} hits you for {enemyattack} damage!");
            }
        }
        else
        {
            Console.WriteLine("Invalid choice!!");
        }
    }
    Console.WriteLine($"After the fight your health is: {playerhealth}");
}
static int DistrubuteStats(List<int> siffers, List<string> namestat)
{
    int Points = 20;
    while (Points > 0)
    {
        Console.WriteLine($"You have {Points} stat points to spend. Where would you like them?");
        for (int i = 0; i < namestat.Count; i++)
        {
            Console.WriteLine($"{i + 1} {namestat[i]} : {siffers[i]}");
        }
        Console.WriteLine("Choose a stat (1-7):");
        string input = Console.ReadLine();
        int statChoice;
        if (!int.TryParse(input, out statChoice) || statChoice < 1 || statChoice > 7)
        {
            Console.WriteLine("Invalid stat choice");
            Console.ReadLine();
            continue;
        }
        Console.Write("Points to add:");
        string pointInput = Console.ReadLine();

        int addPoints;

        if (!int.TryParse(pointInput, out addPoints))
        {
            Console.WriteLine("Please enter a number");
            Console.ReadLine();
            continue;
        }

        if (addPoints > Points || addPoints <= 0)
        {
            Console.WriteLine("Invalid point amount");
            Console.ReadLine();
            continue;
        }
        siffers[statChoice - 1] += addPoints;
        Points -= addPoints;
    }
    return 100;
}
static void ShowStats(List<int> siffers, List<string> StatName)
{
    Console.WriteLine("Your stats: \n");
    for (int i = 0; i < StatName.Count; i++)
    {
        Console.WriteLine($"{StatName[i]}: {siffers[i]}");
    }
}

Console.ReadLine();

