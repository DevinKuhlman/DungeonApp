using DungeonLibrary;
using MonsterLibrary;


namespace Dungeon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Devin's Super Hard Dungeon!");
            int score = 0;

            Weapon sword = new Weapon(8, 1, "Long Sword", 10, false, WeaponType.Sword);

            Console.Write("Hello traveler what art thou called?\n ");
            string userName = Console.ReadLine();           
            var races = Enum.GetValues(typeof(Race));
            int index = 1;
            foreach (var race in races)
            {
                Console.WriteLine($"{index}) {race}");
                index++;
            }
            Console.WriteLine("Please select a race from the list above...");            
            int userInput = int.Parse(Console.ReadLine()) - 1;
            Race userRace = (Race)userInput;
            Console.WriteLine(userRace);            
            Player player = new Player(userName, 70, 5, 40, 40, userRace, sword);
            Console.Clear();
            Console.WriteLine($"Welcome {player.Name}, your journey begins! There are 10 Monsters in this dungeon defeat all and you will be rewarded with freedom!");
            bool exit = false; 

            do
            {               
                string room = GetRoom();
                Console.WriteLine(room);               
                Monster monster = Monster.GetMonster();

                Console.WriteLine("In this room... \n\n" + monster.Name );

                bool reload = false;
                do
                {
                    Console.Write("\nPlease choose an action:\n" +
                        "A) Attack\n" +
                        "R) Run away\n" +
                        "P) Player Info\n" +
                        "M) Monster Info\n" +
                        "X) Exit\n");
                    string userChoice = Console.ReadKey(true).Key.ToString();
                    Console.Clear();

                    switch (userChoice)
                    {
                        case "A":
                            Console.WriteLine("Attack!");
                            
                            Combat.DoBattle(player, monster);
                            if (monster.Life <= 0)
                            {

                                score++;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"\nYou Defeated {monster.Name}!");
                                Console.ResetColor();
                                reload = true;
                            }
                            if (player.Life <= 0)
                            {
                                Console.WriteLine("You are Just T\a");
                                exit = true;
                            }
                            if (score == 10)
                            {
                                Console.WriteLine("\n\nYou Won! Congrats Now please go outside and touch some grass, you deserved it");
                                exit = true;
                            }

                                
                            break;
                        case "R":
                            Console.WriteLine("Run away!");
                            
                            Console.WriteLine($"{monster.Name} attacks you as you flee!");
                            Combat.DoAttack(monster, player);
                            reload = true;
                            break;
                        case "P":
                            Console.WriteLine("Player Info");
                            Console.WriteLine(player);
                            Console.WriteLine("Monsters Defeated: " + score);
                            break;

                        case "M":
                            Console.WriteLine("Monster Info");
                            Console.WriteLine(monster);
                            break;

                        case "X":
                        case "E":
                        case "Escape":
                            Console.WriteLine("Escaping the Carnage Already?");
                            
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Try Again");
                            break;

                        
                            
                    }

                } while (!exit && !reload);

            } while (!exit);
            Console.WriteLine("You defeated " + score + " monster" + (score == 1 ? "." : "s."));
            Console.WriteLine("\n\nThanks for playing! Press any key to exit...");
            Console.ReadKey();
        }
        
        private static string GetRoom()
        {
            string[] rooms =
            {
                "This small, square bedroom has matching metal furniture.  The floor is wood and the walls are painted and decorated with a wallpaper border.  " +
                "Light is provided by wall and floor lamps.  The room is done in colors that remind you of a coffee shop and overall looks very eclectic.  " +
                "Among the first things one notices walking in are a collection of knickknacks and a well-stocked bookshelf.",
                "This small, rectangular bedroom has coordinating metal furniture.  " +
                "The floor is carpeted and the walls are papered.  Light is provided by table lamps.  " +
                "The room is done in a cat theme in rich colors and overall looks fairly modern.  " +
                "Among the first things one notices walking in are several houseplants and a windowseat.",
                "This large, square dining room has matching plastic furniture.  " +
                "The seating is cushioned.  The floor is carpeted and the walls are painted and decorated with a wallpaper border.  " +
                "Light is provided by table lamps and a ceiling light.  The room is done in colors that remind you of a vampire's lair and overall looks very eclectic.  " +
                "Faded symbols are sketched upon the walls here. " +
                "Upon inspection it can be seen that there are symbols of good deities drawn with a white paint while the symbols of several evil deities are drawn in black. " +
                "The remains of a small leather-bound book that has been burned lies discarded along one wall.",
                "The air in the room is clear and windy. The room smells earthy. A loud chanting noise can be heard.",
                "The walls of this room are smooth and regular, showing ancient dwarven craftsmanship. " +
                "A small hole is dug in one corner, it has been used as a latrine and shows recent use.",
                "Carved into one wall is the face of a twisted goblin. An amber sap-like substance oozes from its mouth. " +
                "A ratty old cloak hangs from a hook on one wall.",
                "Two walls of this room glitter as the stone is full of small mica flakes. " +
                "Four damaged fixtures are on the walls, it appears they once held oil lamps, but little now remains.",
                "Two walls of this room glitter as the stone is full of small mica flakes. " +
                "A single rusted sabaton lies discarded along the wall.",
                "Carved in relief at waist height around the room is an elaborate scrollwork style molding." +
                " A ratty old cloak hangs from a hook on one wall.",
            };
            return rooms[new Random().Next(rooms.Length)];
        }
    }
}