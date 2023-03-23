using System;

namespace OverloadingAssignment
{
    public class PetWalker
    {
        public string Species { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }

        //++ and == overloaded operators
        public static PetWalker operator ++(PetWalker obj)
        {
            obj.Age++;
            return obj;
        }
        public static PetWalker operator --(PetWalker obj)
        {
            obj.Age--;
            return obj;
        }

        //+ and - overloaded operators
        public static PetWalker operator +(PetWalker obj, int amount)
        {
            obj.Age += amount;
            return obj;
        }
        public static PetWalker operator -(PetWalker obj, int amount)
        {
            obj.Age -= amount;
            return obj;
        }

        //< and > overloaded operators
        public static bool operator <(PetWalker obj, PetWalker obj2)
        {
            bool smaller = false;

            if (obj.Age < obj2.Age)
                smaller = true;
            return smaller;
        }
        public static bool operator >(PetWalker obj, PetWalker obj2)
        {
            bool bigger = false;

            if (obj.Age > obj2.Age)
                bigger = true;
            return bigger;
        }

    }

    public class Program
    {
        static void Main(string[] args)
        {
            PetWalker[] petWalkers = new PetWalker[50];
            for (int i = 0; i < petWalkers.Length; i++)
                petWalkers[i] = new PetWalker();
            int selection = Menu();
            int index = 0;
            int userEntry = 0;
            int userEntry2 = 0;
            int ageChange = 0;

            while (selection != 5)
            {
                switch (selection)
                {
                    case 1:
                        if (index < 50)
                        {
                            Console.WriteLine("What is the name of the pet?");
                            petWalkers[index].Name = Console.ReadLine();

                            Console.WriteLine("What is the age of the pet?");
                            petWalkers[index].Age = int.Parse(Console.ReadLine());

                            Console.WriteLine("What is the species of the pet?");
                            petWalkers[index].Species = Console.ReadLine();

                            index++; 
                        }
                        else
                            Console.WriteLine("You're walking too many pets at once. Give yourself a break!");
                        break;

                    case 2:
                        {
                            for(int i = 0; i < petWalkers.Length; i++)
                            {
                                if (petWalkers[i].Name != "" && petWalkers[i].Name != null)
                                {
                                    Console.WriteLine($"Name: {petWalkers[i].Name}");
                                    Console.WriteLine($"Species: {petWalkers[i].Species}");
                                    Console.WriteLine($"Age: {petWalkers[i].Age}");
                                    Console.WriteLine(); 
                                }
                            }
                            break;
                        }
                    case 3:
                        {
                             userEntry = chooseEntry(index);

                            Console.Write("Increase age by 1? Enter 'y' for yes: ");
                            string userResponse = Console.ReadLine();
                            if (userResponse == "y" || userResponse == "Y")
                            {
                                petWalkers[userEntry]++;
                            }

                            Console.Write("Did a pet find a fountain of youth and you would like to decrease their age? Enter 'y' for yes: ");
                            userResponse = Console.ReadLine();
                            if(userResponse == "y" || userResponse == "Y")
                            {
                                petWalkers[userEntry]--;
                            }

                            Console.Write("Would you like to increase the age by more than 1? 'y' for yes: ");
                            userResponse = Console.ReadLine();
                            if(userResponse == "y" || userResponse == "Y")
                            {
                                ageChange = 0;
                                Console.WriteLine("How many years would you like to increase their age by?");

                                while(!int.TryParse(Console.ReadLine(), out ageChange))
                                {
                                    Console.WriteLine("Please enter a valid number.");
                                }
                                petWalkers[userEntry] += ageChange;

                            }

                            Console.Write("Would you like to decrease the age by more than 1? 'y' for yes: ");
                            userResponse = Console.ReadLine();
                            if (userResponse == "y" || userResponse == "Y")
                            {
                                ageChange = 0;
                                Console.WriteLine("How many years would you like to decrease their age by?");

                                while (!int.TryParse(Console.ReadLine(), out ageChange))
                                {
                                    Console.WriteLine("Please enter a valid number.");
                                }
                                petWalkers[userEntry] -= ageChange;
                            }
                            break;
                        }
                    case 4:
                        {
                             userEntry = compareEntry(index);
                             userEntry2 = compareEntry(index);

                            if (petWalkers[userEntry] < petWalkers[userEntry2])
                                Console.WriteLine($"{petWalkers[userEntry].Name} is younger than {petWalkers[userEntry2].Name}");

                            else if (petWalkers[userEntry] > petWalkers[userEntry2])
                                Console.WriteLine($"{petWalkers[userEntry].Name} is older than {petWalkers[userEntry2].Name}");

                            else
                                Console.WriteLine($"{petWalkers[userEntry].Name} is the same age as {petWalkers[userEntry2].Name}");
                            break;
                        }
                }
                 selection = Menu();
            }


            
        }
        public static int Menu()
        {
            int selection = 0;
            Console.WriteLine("------------------------------");
            Console.WriteLine("Welcome to your pet walker app!");
            Console.WriteLine("Please enter a number associated with a selection from the menu.");
            Console.WriteLine("1 - Add\n2 - Print all\n3 - Edit age of a current pet\n4 - Compare ages\n5 - Quit");
            while (!int.TryParse(Console.ReadLine(), out selection))
                Console.WriteLine("Please make a selection between 1 - 4");
            return selection;
        }
        public static int chooseEntry(int index)
        {
            Console.WriteLine("What entry would you like to change?");
            Console.WriteLine($"The valid entry values are between 1 and {index}.");

            int entry;
            while (!int.TryParse(Console.ReadLine(), out entry))
                Console.WriteLine($"Please select a number between 1 and {index}");
            entry -= 1;
            return entry;


        }
        public static int compareEntry(int index)
        {
            int selection;

            Console.WriteLine("What entry would you like to compare?");
            Console.WriteLine($"The valid entry values are between 1 and {index}.");

            while (!int.TryParse(Console.ReadLine(), out selection))
                Console.WriteLine($"Please select a number between 1 and {index}");
            selection -= 1;
            return selection;


        }
    }
}
