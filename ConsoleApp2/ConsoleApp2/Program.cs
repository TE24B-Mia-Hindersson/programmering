

using System.ComponentModel;
using System.Runtime.Serialization;
Console.WriteLine("You slowly start to gain conciousness as the cryosleep chamber opens.. \nAs you look around you realize you have no recollection of anything. \nYou stand up, shakingly, and move slowly forward. \nYou glance at your surroundings and find an abandoned facility. You start to feel worried, thinking of what couldve happened. \nYour memory is hazy. You reach a mirror and peer into it.");
Console.ReadLine();
Console.Clear(); 
int gamestage = 0; // vad spelets stadie beror på, ändrar difficulty
// -- name selection--
string name = ""; //plats för ditt namn
while (name.Length <= 1 || name.Length >= 12) //stoppar spelaren från att ha ett för kort/långt namn
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
List<string> memories = new List<string>(); //stores memories
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
    Addmemories(memories, "A burning sensation.. a lab.. people screaming about contamination");
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
    if (siffers[4] >= 4 || siffers[1] >= 4) //intelligence or perception which allows better observation
    {
        Console.WriteLine("\nLooking closely at the water..");
        Console.WriteLine("You notice dead fish floating beneath the surface");
        Console.WriteLine("A strange oily residue moves across the water..");
        Console.WriteLine("This water is contaminated!");
        siffers[4] += 1; //intelligence 
        Console.WriteLine("Intelligence +1");
        Addmemories(memories, "You remember studying water samples... were you a scientist?");
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
playerhealth = applyradiation(playerhealth, radiation);

// -- first fight encounter --
playerhealth = threat(gamestage, playerhealth);
if (playerhealth <= 0)
{
    Console.WriteLine("You have died!");
    Console.WriteLine("Game over..");
    return;
}
Console.WriteLine("After a near death experience, and one of your first combat encounters you quickly move as far away from the area as possible.");
Console.WriteLine("Suddenly you arrive at an old abandoned road.");
Console.WriteLine("Continuing forward you start to notice signs of human life..");
Console.WriteLine("You discover a small settlement. A sign hangs ifront of a wooden wall.. 'Ash hallow'");
// --Ash hallow--
Console.ReadLine();
Console.Clear();
int reputation = 0; //tracks how others view you
Console.WriteLine("A guard stops you..");
Console.WriteLine("Guard: Halt! Explain your purpose for coming here!");
Console.WriteLine("1) 'I am just a traveler seeking shelter.. i mean no harm!' \n2) 'None of your business.' \n3) Stay silent. \n4) *lie* I am a trader with supplies!");
string guarddialoguechoice = Console.ReadLine();
   if (guarddialoguechoice == "1") 
     {
        //good outcome 
       Console.WriteLine("Guard: Alright, ill let you in. You seem trustworthy enough.."); 
        siffers[3] += 1;
        reputation += 2;
        Console.WriteLine("You gained trust in ash hollow.. \nCharisma +1"); 
        //bonus if charisma already high
        if (siffers[3]  >= 5)
    {
         Console.WriteLine("Guard: We could use someone like you around these parts.."); 
         reputation += 1;
    }
    }
else if (guarddialoguechoice == "2")
    {
        //bad outcome
       Console.WriteLine("Guard: Dont even joke lad."); 
       reputation -= 1;
       playerhealth -= 2;
        Console.WriteLine("The guard shoves you back! \nHealth -2"); 
    }
else if (guarddialoguechoice == "3")
    {
        //neautral/suspicious
       Console.WriteLine("The guard watches you carefully.. \nGuard: You arent very talkative are you?"); 
       reputation --;
//perception comes in handy typ
if (siffers[1] >= 5)
    {
        Console.WriteLine("You maintain eyecontact confidently. \nThe guard lets you past");
        reputation += 1; //cancels prior hit to reputation
    }
    else
    {
        Console.WriteLine("The guard seems suspisious but lets you in");
    }
    } 
    else if (guarddialoguechoice == "4")
{
    //risky choice 
    Console.WriteLine("Guard: Oh really? A trader? What are you selling?");
//intelligence or charisma comes in handy
if (siffers[4]>= 4 || siffers[3] >= 4)
    {
        Console.WriteLine("You quickly come up with a believable story");
        reputation += 2;
        Console.WriteLine("Guard: Alright come on in! Just dont cause any trouble");
    }
    else
    {
        Console.WriteLine("You hesitate. Your story falls apart");
        reputation -= 3;
        Console.WriteLine("Guard: Youre lying!");
        Console.WriteLine("The guard hits you and searches you");
        playerhealth -= 4;
        Console.WriteLine("Health -4");
    }
}
else
{
    Console.WriteLine("Invalid choice!");
}
Console.ReadLine();
Console.Clear();
 Console.WriteLine("You step inside Ash Hollow..");
 if (reputation >= 3) 
{
     Console.WriteLine("People seem to welcome you");
}
 else if (reputation <= -2) 
{
     Console.WriteLine("People seem to avoid you.. whispering as you pass");
}
else 
{
     Console.WriteLine("No one takes notice to you");
}
Console.WriteLine ("People move cautiously and many look sick.. \nA man approaches you, he seems to be the leader.");
Console.ReadLine();
Console.Clear();
 Console.WriteLine("Leader: You dont look like you are from around here.. \nLeader: The names Rohan. I keep this place together.");
 Console.WriteLine("1) Ask about the settlement. \n2) Ask about what happened to the world. \n3) Stay quiet");
 string leaderchoice = Console.ReadLine();
 if (leaderchoice == "1")
{
     Console.WriteLine("Rohan: We survived.. barely. Radiation took most of the land.");
}
if (leaderchoice == "2")
{
     Console.WriteLine("Rohan: Something went real wrong.. Maybe old world experiments? It happened so long ago all the folks who lived through it have died off");
     Addmemories(memories, "A large underground facility.. alarms.. running frantically");
}
else
{
  Console.WriteLine("Rohan studies you silently...");
}
gamestage ++;
Console.ReadLine();
Console.Clear();
Console.WriteLine("Rohan: Enough of this.. if you want to settle down here youll need to contribute! \nRohan: Theres an old research bunker nearby.. \nRohan: We think it has supplies... or maybe answers.");
Console.WriteLine("QUEST: Investigate The Old Bunker");
Console.WriteLine("Press enter to continue..");
Console.ReadLine();
Console.Clear();
Console.WriteLine("You leave Ash Hallow and head towards the bunker.. trying to stay safe.");
threat(gamestage, playerhealth);
Console.WriteLine("You stumble forward to your destination");
Console.WriteLine("Your head feels heavy and the air feels suffocating..");
radiation += 7; //entering dangerous area
Console.ReadLine();
Console.Clear();
Console.WriteLine("You find the bunker entrance.. \nInside everything is covered in dust. \n1)Search the room? \n2) Look for computers?");
string bunkerchoice = Console.ReadLine();
if (bunkerchoice == "1")
{
  Console.WriteLine("You search through old containers.. \nYou find documents about raditation exposure.");  
  Addmemories(memories, "Test subjects.. radiation trials.. this WASNT an accident.");
}
else if (bunkerchoice == "2")
{
    Console.WriteLine("You find an old rusty computer. You power on the old terminal");
    Addmemories(memories, "Cryosleep program initiated... world collapse imminent... YOU were part of it...");
}
//BIG story thing 
Addmemories(memories, "You remember entering a cryosleep chamber willingly.. why?");
Console.ReadLine();
Console.Clear();
Console.WriteLine("After some crazy finds you wander back to Ash Hollow. \nRohan: Youre back! What did you find? ");
Console.WriteLine("1) Tell the truth \n2) Lie \n3) Say nothing");
string reportchoice = Console.ReadLine();
if (reportchoice == "1")
{
  Console.WriteLine("Rohan: ....So it WAS caused by humans. \nRohan looks worried");  
}
else if (reportchoice == "2")
{
    Console.WriteLine("Rohan: I dont believe you. \nRohan looks annoyed"); 
}
else
{
    Console.WriteLine("Rohan: keeping secrets wont help anyone!"); 
}
Console.WriteLine("QUEST completed: The Old Bunker"); 
Console.ReadLine();
Console.Clear();
static int applyradiation(int playerhealth, int radiation)
{
    if (radiation >= 10)
    {
        Console.WriteLine("\nYou feel weak");
        Console.WriteLine("Your body feels strange.. the radiation might be effecting you.");
        playerhealth -= 1;
    }
    if (radiation >= 20)
    {
        Console.WriteLine("\nYou feel incredibly weak and nautious");
        Console.WriteLine("Your body feels like its decaying.. the radiation is effecting you.");
        playerhealth -= 3;
    }
    Console.WriteLine($"Health: {playerhealth}");
    Console.WriteLine($"Radiation: {radiation}");
    Console.ReadLine();
    Console.Clear();
    return playerhealth;
}
static int threat(int gamestage, int playerhealth)
{
    Random rng = new Random(); //random gen
    string enemy;
    //enemy depends on stage progression
    if (gamestage <= 0)
    {
        string[] enemies = { "Mutated Rat", "Rad Roach" };
        enemy = enemies[rng.Next(enemies.Length)];
    }
    else if (gamestage >= 3)
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
    //loop continues till someone dies
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
        else if (fightchoice == "2") //run
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
    return playerhealth;
}
static int DistrubuteStats(List<int> siffers, List<string> namestat)
{
    int Points = 20;
    //loop until all points are used
    while (Points > 0)
    {
        Console.WriteLine($"You have {Points} stat points to spend. Where would you like them?");
        //show all stats
        for (int i = 0; i < namestat.Count; i++)
        {
            Console.WriteLine($"{i + 1} {namestat[i]} : {siffers[i]}");
        }
        Console.WriteLine("Choose a stat (1-7):");
        string input = Console.ReadLine();
        int statChoice;
        //avoids crash
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
        Console.WriteLine($"{StatName[i]}: {siffers[i]}"); //visar namnen på alla stats inklusive mängden poäng du delat ut
    }
}
static void Addmemories(List<string> memories, string memorytext)
{
    //adds memories and shows to player
    memories.Add(memorytext);
    Console.WriteLine("--Memory unlocked--");
    Console.WriteLine(memorytext);
    Console.WriteLine("--------------------");
Console.ReadLine();
}

static void Showmemories(List<string> memories)
{
    Console.WriteLine("\nYour memories:");
    if (memories.Count == 0)
    {
    Console.WriteLine("You dont remember anything..");
    }
    else
    {
        //loop through all your memories and print
        foreach (string mem in memories)
        {
            Console.WriteLine("- " + mem);
        }
    }
}
Console.ReadLine();

