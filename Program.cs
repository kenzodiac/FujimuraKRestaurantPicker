//Kenneth Fujimura
//Date Revised: 10-20-2022
//GitHub Challenges: Restaurant Picker
//This is a console program that helps a user select a restaurant to eat from. The user selects a cateogry of restaurant, and then the program chooses at random which restaurant to pick from a list of predetermined choices, discriminating based on the preselected category.
//Peer Reviewed By: see attached README file

Console.Clear();
//declare variables
int input = 0;
int num = 0;
bool playAgain = true;

//method that holds the process that asks the user for an input and then does a validation check on their response
int InputValidation(){
    bool isValid = false;
    int inputPass = 0;
    while (!isValid) {
        string stringInput = Console.ReadLine();
        bool isNumber = Int32.TryParse(stringInput, out inputPass);
        if (isNumber == true && inputPass >= 1 && inputPass <= 3){
                isValid = true;
            } else {
                Console.Write("\nInvalid entry. Please enter a whole number or 'Integer' between 1 and 3: ");
            }
    }
    return inputPass;
}

//method that narrows down which restaurants get selected by category
int RestaurantCategory(int inputPass){
    Random rnd = new Random();
    int output = 0;
    if (inputPass == 1){
        output = rnd.Next(0,9);
    } else if (inputPass == 2) {
        output = rnd.Next(10, 19);
    } else {
        output = rnd.Next(20, 29);
    }
    return output;
} 

//method that holds the restaurant selection process
void RestaurantSelection(int inputPass, int rndNumPass) {
    //array that holds all the restaurant names
    string[] restaurantList = {
        //Lodi Restaurants = index 0-9:
        "Komachi Sushi",
        "Dumpling House In Lodi",
        "Fiori’s Butcher Shoppe & Deli",
        "Hazumi Sushi Bar and Japanese Cuisine",
        "Thai Kitchen",
        "Zin Bistro",
        "Yen Ching Restaurant",
        "Friends Indian Restaurant",
        "La Campana Taqueria",
        "Rick's New York Style Pizza",

        //Stockton Restaurants = index 10-19:
        "Seoul Soon Dubu Tofu House",
        "Tasty Pot",
        "ShoMi",
        "Jitaro Truck",
        "Tandoori Nites",
        "German Guys",
        "Bonchon",
        "Cocoro Japanese Bistro & Sushi Bar",
        "Yen Du Restaurant",
        "Green Papaya",
        "Mama's Pho & Sandwiches",

        //Fast Food Restaurants = index 20-29:
        "Raising Canes",
        "In-N-Out Burger",
        "Luu’s Chicken Bowl",
        "El Pollo Loco",
        "Chipotle Mexican Grill",
        "The Habit Burger Grill",
        "Panera Bread",
        "Fire Wings",
        "Mr Pickle's Sandwich Shop",
        "Fosters Freeze",
        "Panda Express"
        };
    
    //switch statement that determines which response is printed out to the user
    switch (inputPass){
        case 1:
            Console.WriteLine($"You should eat at {restaurantList[rndNumPass]}.");
            break;
        case 2:
            Console.WriteLine($"You sould eat at {restaurantList[rndNumPass]}.");
            break;
        case 3:
            Console.WriteLine($"You should eat at {restaurantList[rndNumPass]}.");
            break;
        default:
            break;
    }
}
//method for determining if the program should be repeated
bool Repeat(){
    Console.Write("Would you like to get a different recommendation? Type \"Y\"/\"Yes\" or \"N\"/\"No\": ");
    bool answerCheck = true;
    while (answerCheck == true){
        string input = Console.ReadLine().ToLower();
        if (input == "y" || input == "yes"){
            answerCheck = false;
        } else if (input == "n" || input == "no"){
            answerCheck = false;
            playAgain = false;
            Console.WriteLine("Good Bye");
        } else {
            Console.Write("I do not understand that input. Please either type \"Y\"/\"Yes\" or \"N\"/\"No\": ");
        }
    }
    return playAgain;
}

//greet player
Console.WriteLine("Welcome to Restaurant Picker! Please choose a category and we'll help you select a restaurant to eat at:\n");

//while loop containing main body of program
while (playAgain == true){
    Console.WriteLine("Type \"1\" if you would like to eat in Lodi");
    Console.WriteLine("Type \"2\" if you would like to eat in Stockton");
    Console.WriteLine("Type \"3\" if you would like to eat Fast Food\n");

    input = InputValidation();
    num = RestaurantCategory(input);
    RestaurantSelection(input, num);

    playAgain = Repeat();
}