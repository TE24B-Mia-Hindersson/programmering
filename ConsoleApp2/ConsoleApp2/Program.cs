

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
// --PLAYER DATA--
int GameStage = 0; // vad spelets stadie beror på, ändrar difficulty
int PlayerHealth = 20; //spelaren start hälsa
int Radiation = 0; //hur npc behandlar spelaren (har noll relevance just nu)
int Reputation = 0; //tracks how others view you
List<string> StatName = ["Strength", "Perception", "Endurance", "Charisma", "Intelligence", "Agility", "Luck"];//stat namnen
List<int> Stats = [0, 0, 0, 0, 0, 0, 0]; //Tar siffer input från distrubutestats metoden och stoppar in dem här
List<string> Memories = new List<string>(); //stores memories 
List<string> Inventory = new List<string>(); //stores items
Random rng = new Random(); //random generetor
// --GAME STARTS--
Console.WriteLine("You slowly start to gain conciousness as the cryosleep chamber opens.. \nAs you look around you realize you have no recollection of anything. \nYou stand up, shakingly, and move slowly forward. \nYou glance at your surroundings and find an abandoned facility. You start to feel worried, thinking of what couldve happened. \nYour memory is hazy. You reach a mirror and peer into it.");
Console.ReadLine();
Console.Clear();
// --NAME SELECTION--
string Name = ""; //plats för ditt namn
Name = GetName(Name);
// --STAT DISTRUBUTION --
DistrubuteStats(Stats, StatName);
Console.ReadLine();
Console.Clear();
Console.WriteLine($"Welcome, {Name}");
Inventory.Add("Bandage"); //starter item
ShowStats(Stats, StatName);
GameStage++;
Console.WriteLine("press enter to leave");
Console.ReadLine();
Console.Clear();
// -- MAIN STORY BEGIN -- 
if (Stats[1] >= 5) // perception check (if perception is chosen stat: applies)
// --LAKE--
{
    Console.WriteLine("\nYour sharp senses notice strange footprints in the dirt");
    Console.WriteLine("Following the tracks, you arrive at a small lake");
    Console.WriteLine("The water is strangely clear");
}
else
{
    Console.WriteLine("\nYou feel uneasy, but you cant pinpoint why");
    Console.WriteLine("You walk between the trees..");
    Console.WriteLine("Suddenly you fall down and injure yourself");
    Console.WriteLine("Upon getting back up you notice a lake a while infront of you");
    Console.WriteLine("You limp over..");
    PlayerHealth -= 3;
}
Console.WriteLine("1) Drink some");
Console.WriteLine("2) Leave it alone..");
Console.WriteLine("3) Examine the water");
int LakeChoice = GetChoice(1, 3);

if (LakeChoice == 1)
{
    Console.WriteLine("You drink the water.");
    Console.WriteLine("The water has an odd taste that almost burns your mouth");
    Radiation += 10;
    PlayerHealth -= 2;
    Console.WriteLine("Your stomach twists painfully.");
    Console.WriteLine("Radiation +10");
    Console.WriteLine("Health -4");
    //explain radiation and health?
    Stats[2] += 1; //endurance
    Console.WriteLine("Endurance +1");
    Addmemories(Memories, "A burning sensation.. a lab.. people screaming about contamination");
    Console.ReadLine();
}
else if (LakeChoice == 2)
{
    Console.WriteLine("Something about the water feels off...");
    Console.WriteLine("You decide to not risk drinking it..");
    Stats[6] += 1; //luck
    Console.WriteLine("Luck +1");
    Console.ReadLine();
}
else if (LakeChoice == 3)
{
    if (Stats[4] >= 4 || Stats[1] >= 4) //intelligence or perception which allows better observation
    {
        Console.WriteLine("\nLooking closely at the water..");
        Console.WriteLine("You notice dead fish floating beneath the surface");
        Console.WriteLine("A strange oily residue moves across the water..");
        Console.WriteLine("This water is contaminated!");
        Stats[4] += 1; //intelligence 
        Console.WriteLine("Intelligence +1");
        Addmemories(Memories, "You remember studying water samples... were you a scientist?");
        Console.ReadLine();
    }
    else
    {
        Console.WriteLine("\nYou stare at the water and cant decide if anythings wrong..");
        Console.WriteLine("You end up not drinking any.");
        Console.ReadLine();
    }
}
Console.Clear();
// -- intro to radiation --
PlayerHealth = ApplyRadiation(PlayerHealth, Radiation);

// -- first fight encounter --
PlayerHealth = Combat(GameStage, PlayerHealth, Stats, Inventory, rng);
if (PlayerHealth <= 0)
{
    Console.WriteLine("You have died!");
    Console.WriteLine("Game over..");
    return;
}
Console.WriteLine("After a near death experience, and one of your first combat encounters you quickly move as far away from the area as possible. \nSuddenly you arrive at an old abandoned road. \nContinuing forward you start to notice signs of human life..");
Console.WriteLine("You see a corpse ahead.. \nYou decide to search it.");

// inventory check..
Getitem(Inventory, "Medkit");
Console.WriteLine("You discover a small settlement. A sign hangs ifront of a wooden wall.. 'Ash hallow'");
// --Ash hallow--
Console.ReadLine();
Console.Clear();
Console.WriteLine("A guard stops you..");
Console.WriteLine("Guard: Halt! Explain your purpose for coming here!");
Console.WriteLine("1) 'I am just a traveler seeking shelter.. i mean no harm!' \n2) 'None of your business.' \n3) Stay silent. \n4) *lie* I am a trader with supplies!");
int GuardDialogueChoice = GetChoice(1, 4);
if (GuardDialogueChoice == 1)
{
    //good outcome 
    Console.WriteLine("Guard: Alright, ill let you in. You seem trustworthy enough..");
    Stats[3] += 1;
    Reputation += 2;
    Console.WriteLine("You gained trust in ash hollow.. \nCharisma +1");
    //bonus if charisma already high
    if (Stats[3] >= 5)
    {
        Console.WriteLine("Guard: We could use someone like you around these parts..");
        Reputation += 1;
    }
}
else if (GuardDialogueChoice == 2)
{
    //bad outcome
    Console.WriteLine("Guard: Dont even joke lad.");
    Reputation -= 1;
    PlayerHealth -= 2;
    Console.WriteLine("The guard shoves you back! \nHealth -2");
}
else if (GuardDialogueChoice == 3)
{
    //neautral/suspicious
    Console.WriteLine("The guard watches you carefully.. \nGuard: You arent very talkative are you?");
    Reputation--;
    //perception comes in handy typ
    if (Stats[1] >= 5)
    {
        Console.WriteLine("You maintain eye contact confidently. \nThe guard lets you past");
        Reputation += 1; //cancels prior hit to reputation
    }
    else
    {
        Console.WriteLine("The guard seems suspisious but lets you in");
    }
}
else if (GuardDialogueChoice == 4)
{
    //risky choice 
    Console.WriteLine("Guard: Oh really? A trader? What are you selling?");
    //intelligence or charisma comes in handy
    if (Stats[4] >= 4 || Stats[3] >= 4)
    {
        Console.WriteLine("You quickly come up with a believable story");
        Reputation += 2;
        Console.WriteLine("Guard: Alright come on in! Just dont cause any trouble");
    }
    else
    {
        Console.WriteLine("You hesitate. Your story falls apart");
        Reputation -= 3;
        Console.WriteLine("Guard: Youre lying!");
        Console.WriteLine("The guard hits you and searches you");
        PlayerHealth -= 4;
        Console.WriteLine("Health -4");
    }
}
Console.ReadLine();
Console.Clear();
Console.WriteLine("You step inside Ash Hollow..");
//for now this has no purpose
if (Reputation >= 3)
{
    Console.WriteLine("People seem to welcome you");
}
else if (Reputation <= -2)
{
    Console.WriteLine("People seem to avoid you.. whispering as you pass");
}
else
{
    Console.WriteLine("No one takes notice to you");
}
Console.WriteLine("People move cautiously and many look sick.. \nA man approaches you, he seems to be the leader.");
Console.ReadLine();
Console.Clear();
Console.WriteLine("Leader: You dont look like you are from around here.. \nLeader: The names Rohan. I keep this place together.");
Console.WriteLine("1) Ask about the settlement. \n2) Ask about what happened to the world. \n3) Stay quiet");
int LeaderChoice = GetChoice(1, 3);
if (LeaderChoice == 1)
{
    Console.WriteLine("Rohan: We survived.. barely. Radiation took most of the land.");
}
if (LeaderChoice == 2)
{
    Console.WriteLine("Rohan: Something went real wrong.. Maybe old world experiments? It happened so long ago all the folks who lived through it have died off");
    Addmemories(Memories, "A large underground facility.. alarms.. running frantically");
}
else
{
    Console.WriteLine("Rohan studies you silently...");
}
GameStage++;
Console.ReadLine();
Console.Clear();
Console.WriteLine("Rohan: Enough of this.. if you want to settle down here youll need to contribute! \nRohan: Theres an old research bunker nearby.. \nRohan: We think it has supplies... or maybe answers.");
Console.WriteLine("QUEST: Investigate The Old Bunker");
Console.WriteLine("Press enter to continue..");
Console.ReadLine();
Console.Clear();
//-- 1st QUEST begins--
Console.WriteLine("You leave Ash Hallow and head towards the bunker.. trying to stay safe.");
PlayerHealth = Combat(GameStage, PlayerHealth, Stats, Inventory, rng);
Console.WriteLine("You stumble forward to your destination");
Console.WriteLine("Your head feels heavy and the air feels suffocating..");
Radiation += 7; //entering dangerous area
Console.ReadLine();
Console.Clear();
Console.WriteLine("You find the bunker entrance.. \nInside everything is covered in dust. \n1)Search the room? \n2) Look for computers?");
int BunkerChoice = GetChoice(1, 2);
if (BunkerChoice == 1)
{
    Console.WriteLine("You search through old containers.. \nYou find documents about raditation exposure.");
    Addmemories(Memories, "Test subjects.. radiation trials.. this WASNT an accident.");
}
else if (BunkerChoice == 2)
{
    Console.WriteLine("You find an old rusty computer. You power on the old terminal");
    Addmemories(Memories, "Cryosleep program initiated... world collapse imminent... YOU were part of it...");
}
//BIG story thing
Addmemories(Memories, "You remember entering a cryosleep chamber willingly.. why?");
Console.ReadLine();
Console.Clear();
Console.WriteLine("After some crazy finds you wander back to Ash Hollow. \nRohan: Youre back! What did you find? ");
Console.WriteLine("1) Tell the truth \n2) Lie \n3) Say nothing");
int ReportChoice = GetChoice(1, 3);
if (ReportChoice == 1)
{
    Console.WriteLine("Rohan: ....So it WAS caused by humans. \nRohan looks worried");
}
else if (ReportChoice == 2)
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
Console.WriteLine("That night, you struggle to sleep.. \nYour head throbs as fragments of memory return..");
Addmemories(Memories, "A voice echoes: 'Subject stability failing.. increase sedation levels..'");
Console.ReadLine();
Console.Clear();
Showmemories(Memories); //temp fix till i can be bothered to add a way to look at memories whenever 
Console.WriteLine("You wake up suddenly. \nSomething feels.. wrong \nOutside you hear shouting.");
Console.ReadLine();
Console.Clear();
//--Problem--
Console.WriteLine("You rush outside \nPeople are panicking.");
Console.WriteLine("Guard: Something attacked the outer wall \nGuard: We lost people..");
Console.WriteLine("1) Help defend the settlement \n2) Stand back and observe \n3) Sneak off to investigate on your own");
int CrisisChoice = GetChoice(1, 3);
if (CrisisChoice == 1)
{
    Console.WriteLine("You rush in to help defend");
    PlayerHealth = Combat(GameStage + 1, PlayerHealth, Stats, Inventory, rng);
    if (PlayerHealth <= 0)
    {
        Console.WriteLine("You fall in battle");
        Console.ReadLine();
        return;
    }
    Console.WriteLine("to be continued");
}
else if (CrisisChoice == 2)
{
    Console.WriteLine("You stand and observe.. \nSuddenly a huge beast lunges at you and rips you apart.");
    Console.WriteLine("You died. Better luck next time!");
    return;
}
else
{
    Console.WriteLine("You sneak away and run into a feral human.");
    Console.WriteLine("You die.. sorry!");
    return;
}
// applies neg effect based on radiation level
static int ApplyRadiation(int PlayerHealth, int Radiation)
{
    if (Radiation >= 10)
    {
        Console.WriteLine("\nYou feel weak");
        Console.WriteLine("Your body feels strange.. the radiation might be effecting you.");
        PlayerHealth -= 1;
    }
    if (Radiation >= 20)
    {
        Console.WriteLine("\nYou feel incredibly weak and nautious");
        Console.WriteLine("Your body feels like its decaying.. the radiation is effecting you.");
        PlayerHealth -= 3;
    }
    Console.WriteLine($"Health: {PlayerHealth}");
    Console.WriteLine($"Radiation: {Radiation}");
    Console.ReadLine();
    Console.Clear();
    return PlayerHealth;
}
static string GetEnemy(int GameStage, Random rng)
{

    //enemy depends on stage progression.. not working rn?
    if (GameStage <= 0)
    {
        string[] Enemies = { "Mutated Rat", "Rad Roach" };
        return Enemies[rng.Next(Enemies.Length)];
    }
    else if (GameStage >= 3)
    {
        string[] Enemies = { "Wild Dog", "Feral Human" };
        return Enemies[rng.Next(Enemies.Length)];
    }
    else
    {
        string[] Enemies = { "Mutant Wolf", "Radiated Bear" };
        return Enemies[rng.Next(Enemies.Length)];
    }
}
// handles combat between a rnd gen enemy and player
static int Combat(int GameStage, int PlayerHealth, List<int> Stats, List<string> Inventory, Random rng)
{
    // get emeny based on gamestage
    string Enemy = GetEnemy(GameStage, rng);
    // scales damage with gamestage
    int EnemyHealth = 5 + (GameStage * 4);
    int EnemyDamage = 1 + (GameStage * 2);
    Console.WriteLine("\nYou suddenly hear movement in the forest");
    Console.WriteLine($"A {Enemy} comes out from behind the trees!");
    Console.WriteLine($" Enemy Health: {EnemyHealth}");
    Console.WriteLine($" Enemy Damage: {EnemyDamage}");
    //loop continues till someone dies
    while (EnemyHealth > 0 && PlayerHealth > 0)
    {
        Console.WriteLine($"\nYour health: {PlayerHealth}");
        Console.WriteLine("Choose action: \n1)Attack \n2)Run \n3)Use item");
        // get valid input
        int FightChoice = GetChoice(1, 3);
        if (FightChoice == 1) //attack
        {
            // player dmg is rnd + strength stat
            int Damage = rng.Next(2, 7) + Stats[0]; //player dmg 
            EnemyHealth -= Damage;
            Console.WriteLine($"You hit the {Enemy} for {Damage} damage!");
            // checks if enemy is still alive
            if (EnemyHealth <= 0)
            {
                Console.WriteLine($"You defeated the {Enemy}!");
                break;
            }
            // enemy attacks back
            int EnemyAttack = rng.Next(1, EnemyDamage + 1);
            PlayerHealth -= EnemyAttack;
            Console.WriteLine($"The {Enemy} hits you for {EnemyAttack} damage");
        }
        else if (FightChoice == 2) //run
        {
            // chance to escape based on agility
            int EscapeChance = rng.Next(0, 10); //1/2 chance 
            if (EscapeChance < 5 + Stats[5])
            {
                Console.WriteLine("You managed to escape!");
                break;
            }
            else
            {
                Console.WriteLine("You failed to escape!");
                // enemy gets a free hit
                int EnemyAttack = rng.Next(1, EnemyDamage + 1);
                PlayerHealth -= EnemyAttack;
                Console.WriteLine($"The {Enemy} hits you for {EnemyAttack} damage!");
            }
        }
        else if (FightChoice == 3)
        {
            // player uses an item from inven
            UseItem(Inventory, ref PlayerHealth);
        }
        else
        {
            Console.WriteLine("Invalid choice!!");
        }
        Console.ReadLine();
        Console.Clear();
    }
    Console.WriteLine($"After the fight your health is: {PlayerHealth}");
    return PlayerHealth; //returns updated health
}
static int DistrubuteStats(List<int> Stats, List<string> StatName)
{
    int Points = 20;
    //loop until all points are used
    while (Points > 0)
    {
        Console.WriteLine($"You have {Points} stat points to spend. Where would you like them?");
        //show all stats
        for (int i = 0; i < StatName.Count; i++)
        {
            Console.WriteLine($"{i + 1} {StatName[i]} : {Stats[i]}");
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
        Stats[statChoice - 1] += addPoints;
        Points -= addPoints;
    }
    return 100;
}
static void ShowStats(List<int> Stats, List<string> StatName)
{
    Console.WriteLine("Your stats: \n");
    for (int i = 0; i < StatName.Count; i++)
    {
        Console.WriteLine($"{StatName[i]}: {Stats[i]}"); //visar namnen på alla stats inklusive mängden poäng du delat ut
    }
}
static void Addmemories(List<string> Memories, string MemoryText)
{
    //adds memories and shows to player
    Memories.Add(MemoryText);
    Console.WriteLine("--Memory unlocked--");
    Console.WriteLine(MemoryText);
    Console.WriteLine("--------------------");
    Console.ReadLine();
}

static void Showmemories(List<string> Memories)
{
    Console.WriteLine("\nYour memories:");
    if (Memories.Count == 0)
    {
        Console.WriteLine("You dont remember anything..");
    }
    else
    {
        //loop through all your memories and print
        foreach (string mem in Memories)
        {
            Console.WriteLine("- " + mem);
        }
    }
}
static string GetName(string Name)
{
    while (Name.Length <= 1 || Name.Length >= 12) //stoppar spelaren från att ha ett för kort/långt namn
    {
        Console.WriteLine("Upon seeing your reflection you gain a glimps into your memory... Your name is:");
        Name = Console.ReadLine();
        if (Name.Length <= 1)
        {
            Console.WriteLine("Thats very short... try again?");
        }
        if (Name.Length >= 12)
        {
            Console.WriteLine("Thats very long... try again?");
        }
        Console.ReadLine();
        Console.Clear();
    }

    return Name;
}

static int GetChoice(int min, int max)
{
    while (true)
    {
        string input = Console.ReadLine();
        if (int.TryParse(input, out int val) && val >= min && val <= max)
            return val;
        Console.WriteLine("invalid choice");
    }
}

static void Getitem(List<string> inventory, string item)
{
    inventory.Add(item);
    Console.WriteLine($"You found: {item}!");
}
// allows player to use item from inv
static void UseItem(List<string> inventory, ref int health)
{
    // checks if inv is empty
    if (inventory.Count == 0)
    {
        Console.WriteLine("No item!");
        return;
    }
    Console.WriteLine("Inventory:");
    // displays all items with index nr
    for (int i = 0; i < inventory.Count; i++)
    {
        Console.WriteLine($"{i + 1}) {inventory[i]} ");
    }
    Console.WriteLine("Choose item number!");
    int itemchoice = GetChoice(1, inventory.Count);
    string item = inventory[itemchoice - 1];
    // handles item effect
    if (item == "Medkit")
    {
        Console.WriteLine("You used a Medkit!");
        health += 7;
        // removes after use
        inventory.RemoveAt(itemchoice - 1);
    }
    if (item == "Bandage")
    {
        Console.WriteLine("You used a Bandage!");
        health += 4;
        // removes after use
        inventory.RemoveAt(itemchoice - 1);
    }
}
Console.ReadLine();