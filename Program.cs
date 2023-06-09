﻿namespace Prog6221POE
{
    //version 1.9b
    /*
     * TO DO
     * Multiple named Recipies
     * Display recipies in alphabetical order
     * Calorie calculations with delegate to notify when over 300
     * 
     * Ground Up Approach, go resdesign from start, modify input menue then work from there
     * 
     */
    public class RecipeMachine_driver//main method and related items
    {
        public static void Main(string[] args)
        {
            RecipeMachine rm = new RecipeMachine();
            rm.Run();
        }
    }
    public class RecipeMachine
    {
        private Compacter rl = new Compacter();//rl stands for recipe list
        InputChecker check = new InputChecker();// checking if input is in an acceptable format

        //variables
        private string currentRecipe;

        public void Run()//runs through all relevant methods
        {
            dataEntry();
        }

        private void deleteRecipe()//Confirmation for data removal
        {
            //variable declaration
            string tempStr;// temporary variable
            int switchInt;// used to control a switch
            string itemToDelete;//item to be deleted

            //finding item to delete
            Console.WriteLine("Please Enter The Name Of The Recipe You Would Like To Delete");
            tempStr = Console.ReadLine().Trim().ToLower();
            if (!check.notNullInput(tempStr) || !check.nameCheck(tempStr, rl.recipeNames))
            {
                while (!check.notNullInput(tempStr) || !check.nameCheck(tempStr, rl.recipeNames))
                {
                    Console.WriteLine("Invalid Input Entered");
                    Console.WriteLine("Please Ensure That A Real Recipe Was Entered");
                    tempStr = Console.ReadLine().Trim().ToLower();
                }
            }
            itemToDelete = tempStr;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Clearing The Recipe Means That You Will No Longer Be Able To Access It!!!!");
            Console.WriteLine("Please Confirm Action: Clear Stored Recipe: {0}", itemToDelete);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Clear");
            Console.WriteLine("2. Dont Clear, Return To Main Menu");
            Console.WriteLine("");

            tempStr = Console.ReadLine().Trim();
            if (!check.validInput(tempStr) || !check.intConstricCheck(tempStr, 1, 2))
            {
                while (!check.validInput(tempStr) || !check.intConstricCheck(tempStr, 1, 2))
                {
                    Console.WriteLine("Invalid Number Format Entered");
                    Console.WriteLine("Please Ensure That Only Numbers Are Entered");
                    tempStr = Console.ReadLine().Trim();
                }
            }
            switchInt = int.Parse(tempStr);//parsing int to get a valid input

            switch (switchInt)
            {
                case 1:
                    {
                        rl.removeRecipe(itemToDelete);
                        break;
                    }
                case 2:
                    {
                        menuMain();
                        break;
                    }
            }
        }
        //MainMenu
        private void menuMain()//allow for going through several diffrent items and selecting items
        {
            //variable declaration
            string tempStr;// temporary variable
            int switchInt;// used to control a switch

            Console.WriteLine("Please Select One Of The Following Option");
            Console.WriteLine("1. Display A Stored Recipe");
            Console.WriteLine("2. Enter New Recipe");
            Console.WriteLine("3. Scale Recipe Or Reset Recipe Scale");
            Console.WriteLine("4. Delete A Recipe");
            Console.WriteLine("5. Exit Application");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("");
            tempStr = Console.ReadLine().Trim();
            if (!check.validInput(tempStr) || !check.intConstricCheck(tempStr, 1, 4))
            {
                while (!check.validInput(tempStr) || !check.intConstricCheck(tempStr, 1, 4))
                {
                    Console.WriteLine("Invalid Number Format Entered");
                    Console.WriteLine("Please Ensure That Only Numbers Are Entered");
                    tempStr = Console.ReadLine().Trim();
                }
            }
            switchInt = int.Parse(tempStr);//parsing int to get a valid input

            switch (switchInt)
            {
                case 1:// display data
                    {
                        dataDisplay();
                        break;
                    }
                case 2:// clear and enter new data
                    {
                        dataEntry();
                        break;
                    }
                case 3:
                    {
                        menuScaleConvert();
                        break;
                    }
                case 4:
                    {
                        deleteRecipe();
                        break;
                    }
                case 5:// exit
                    {
                        Environment.Exit(0);
                        break;
                    }
            }
        }
        private void menuScaleConvert()//allow for going through several diffrent items and selecting items
        {
            //variable declaration
            string tempStr;// temporary variable
            int switchInt;// used to control a switch

            Console.WriteLine("Please Choose One Of The Following Options");
            Console.WriteLine("1. Scale");
            Console.WriteLine("2. Reset To Original Scale");
            Console.WriteLine("3. Revert To Main Menu");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("");
            tempStr = Console.ReadLine().Trim();
            if (!check.validInput(tempStr) || !check.intConstricCheck(tempStr, 1, 3))
            {
                while (!check.validInput(tempStr) || !check.intConstricCheck(tempStr, 1, 3))
                {
                    Console.WriteLine("Invalid Number Format Entered");
                    Console.WriteLine("Please Ensure That Only Numbers Are Entered");
                    tempStr = Console.ReadLine().Trim();
                }
            }
            switchInt = int.Parse(tempStr);//parsing int to get a valid input

            switch (switchInt)
            {
                case 1:
                    {
                        scaleItem();
                        break;
                    }
                case 2:
                    {
                        resetChange();
                        break;
                    }
                case 3:
                    {
                        menuMain();
                        break;
                    }
            }
        }
        private void menuBLANK()//allow for going through several diffrent items and selecting items
        {
            //variable declaration
            string tempStr;// temporary variable
            int switchInt;// used to control a switch


            tempStr = Console.ReadLine().Trim();
            if (!check.validInput(tempStr) || !check.intConstricCheck(tempStr, 1, 3))
            {
                while (!check.validInput(tempStr) || !check.intConstricCheck(tempStr, 1, 3))
                {
                    Console.WriteLine("Invalid Number Format Entered");
                    Console.WriteLine("Please Ensure That Only Numbers Are Entered");
                    tempStr = Console.ReadLine().Trim();
                }
            }
            switchInt = int.Parse(tempStr);//parsing int to get a valid input

            switch (switchInt)
            {
                case 1:
                    {
                        break;
                    }
            }
        }
        private void resetChange()
        {
            rl.recipeLoad(currentRecipe);
            dataDisplay();
        }
        private void scaleItem()
        {
            //var declaration
            double factor; //scale factor
            string tempStr;// temporary string var

            Console.WriteLine("Please Enter The Scale Factor");//data entry for entering ingredients
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("");
            tempStr = Console.ReadLine().Trim();
            if (!check.doubleInput(tempStr))
            {
                while (!check.doubleInput(tempStr))
                {
                    Console.WriteLine("Invalid Number Format Entered");
                    Console.WriteLine("Please Ensure That Only Numbers Are Entered");
                    tempStr = Console.ReadLine().Trim();
                }
            }
            factor = double.Parse(tempStr);
            dataDisplay();
        }
        public void scaleIngredient(double factor)// factor is the scale factor
        {
            List<double> newAmount = new List<double>();
            foreach (double d in rl.amountOfIngredient)
            {
                newAmount.Add(d * factor);
            }
            rl.amountOfIngredient.Clear();
            rl.amountOfIngredient = newAmount;
        }
        private bool realRecipe(string str)
        {
            foreach (string nameStr in rl.recipeNames)
            {
                if (nameStr == str)
                {
                    return true;
                }
            }
            return false;
        }
        private void dataDisplay()//Display Method
        {
            int counter; //used where i need some source of counter
            string tempStr;// used for string manipulation
            string recipe;// chosen name of a recipe

            //displaying list of recipies
            Console.WriteLine("Please Select One Of The Following Recipies");
            foreach (string name in rl.recipeNames)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            //prompt user, get selected recipe
            Console.WriteLine("Please Enter The Name Of The Recipe");
            tempStr = Console.ReadLine().Trim();
            if (!check.notNullInput(tempStr) || !realRecipe(tempStr))
            {
                while (!check.notNullInput(tempStr) || !realRecipe(tempStr))
                {
                    Console.WriteLine("Please Enter A Valid Recipe");
                    tempStr = Console.ReadLine().Trim();
                }
            }
            currentRecipe = tempStr;
            recipe = tempStr;
            rl.recipeLoad(recipe);

            //information about the recipe
            Console.WriteLine("The following information is about the Recipe");
            Console.WriteLine("The Number of Steps In This Recipe Is {0}", rl.getNumStep());
            Console.WriteLine("There Are {0} Ingredients", rl.getNumIngredients());
            Console.WriteLine("");
            Console.WriteLine("The Following Are The Ingredients and the amounts Needed");
            counter = 0;
            for (int i = 0; i > rl.recipeNames.Count; i++)
            {
                counter = counter + 1;
                Console.WriteLine("Ingredient " + counter + ": " + rl.ingredientName[i] + "  " + rl.amountOfIngredient[i] + rl.units[i]);//, counter, ingredients[i], amount[i], units[i]
            }

            Console.WriteLine("Here Are The Steps For The Recipe");
            for (int i = 0; i < rl.stepDescription.Count; i++)
            {
                counter = i + 1;
                Console.WriteLine("Step {0}:", counter);
                Console.WriteLine(rl.stepDescription[i]);
            }
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("");

            menuMain();
        }
        private void dataEntry() //used to call methods in order for the data entry
        {

            //variable containing recipe data
            string nameRecipe;
            int numberSteps, numberIngredients;
            double calories = 0;
            List<string> ingredientName = new List<string>();
            List<string> units = new List<string>();
            List<string> stepDescription = new List<string>();
            List<double> amountOfIngredient = new List<double>();

            //declaration for varibles only used inside the class
            string tempStr; //temporary variable, will be overwritten multiple times
            int tempInt;  //temporary variable, will be overwritten multiple times
            double tempDouble; // temporary variable, will be overwritten multiple times
            int counter; //used where i need some source of counter
            int switchInt; // used to opperate the switch case 

            //prompt user, the cast the answer into the format needed
            Console.WriteLine("Please Enter The Name Of The Recipe");
            tempStr = Console.ReadLine().Trim();
            if (!check.notNullInput(tempStr))
            {
                while (!check.notNullInput(tempStr))
                {
                    Console.WriteLine("You Cannot Leave This Step Blank");
                    tempStr = Console.ReadLine().Trim();
                }
            }
            nameRecipe = tempStr;

            //prompt user, the cast the answer into the format needed
            Console.WriteLine("Please Enter The Amount Of Ingredients In This Recipe");
            tempStr = Console.ReadLine().Trim();
            if (!check.validInput(tempStr) || !check.intConstricCheck(tempStr, 1, 99))
            {
                while (!check.validInput(tempStr) || !check.intConstricCheck(tempStr, 1, 99))
                {
                    Console.WriteLine("Invalid Number Format Entered");
                    Console.WriteLine("Please Ensure That Only Numbers Are Entered");
                    tempStr = Console.ReadLine().Trim();
                }
            }
            tempInt = int.Parse(tempStr);
            numberIngredients = tempInt;
            Console.WriteLine("");

            //prompt user, the cast the answer into the format needed
            Console.WriteLine("Please Enter The Amount Of Steps In This Recipe");
            tempStr = Console.ReadLine().Trim();
            if (!check.validInput(tempStr) || !check.intConstricCheck(tempStr, 1, 99))
            {
                while (!check.validInput(tempStr) || !check.intConstricCheck(tempStr, 1, 99))
                {
                    Console.WriteLine("Invalid Number Format Entered");
                    Console.WriteLine("Please Ensure That Only Numbers Are Entered");
                    tempStr = Console.ReadLine().Trim();
                }
            }
            tempInt = int.Parse(tempStr);
            numberSteps = tempInt;
            Console.WriteLine("");

            //propmt user to enter info on ingredients, ie name, unit and amount used
            for (int i = 0; i < numberIngredients; i++)
            {
                Console.WriteLine("");
                counter = i + 1;
                Console.WriteLine("Please Enter Information On The Ingredient for the following parameters             Ingredient{0}/{1}", counter, numberIngredients);
                Console.WriteLine("Please enter the Ingredients Name");
                tempStr = Console.ReadLine().Trim();
                if (!check.notNullInput(tempStr))
                {
                    Console.ReadKey();
                    while (!check.notNullInput(tempStr))
                    {
                        Console.WriteLine("Please Enter The Name Of The Ingredient, Please don't leave it empty");
                        tempStr = Console.ReadLine();
                    }
                }
                ingredientName.Add(tempStr); //adding to local array, setting it on the setter array after all data entry is complete

                Console.WriteLine("");

                Console.WriteLine("Please Select The Unit Used To measure the ingredient");//gives several options, of bakeing units
                Console.WriteLine("1. Millilitre");
                Console.WriteLine("2. Litre");
                Console.WriteLine("3. Teaspoon");
                Console.WriteLine("4. Tablespoon");
                Console.WriteLine("5. Fluid Ounce(oz)");
                Console.WriteLine("6. Cup");
                Console.WriteLine("7. Quart");
                Console.WriteLine("8. Pint");
                Console.WriteLine("9. Gallon");

                tempStr = Console.ReadLine().Trim();
                if (!check.validInput(tempStr) || !check.intConstricCheck(tempStr, 1, 9))
                {
                    while (!check.validInput(tempStr) || !check.intConstricCheck(tempStr, 1, 9))
                    {
                        Console.WriteLine("Invalid Number Format Entered");
                        Console.WriteLine("Please Ensure That Only Numbers Are Entered");
                        tempStr = Console.ReadLine().Trim();
                    }
                }
                switchInt = int.Parse(tempStr);//parsing int to get a valid input
                Console.WriteLine("");

                //following switch case used to set what unit an ingredient is stored as
                switch (switchInt) //Units Used for measuring are, ml, litre, TeaSpoon, TableSpoon, OZ, Cup, Quart, Pint, Gallon, other
                {
                    case 1:
                        {
                            units.Add("ml");//millilitre
                            break;
                        }
                    case 2:
                        {
                            units.Add("L"); //litre
                            break;
                        }
                    case 3:
                        {
                            units.Add("TeaSpoon");
                            break;
                        }
                    case 4:
                        {
                            units.Add("TableSpoon");
                            break;
                        }
                    case 5:
                        {
                            units.Add("OZ");//Fluid Ounce
                            break;
                        }
                    case 6:
                        {
                            units.Add("Cup");
                            break;
                        }
                    case 7:
                        {
                            units.Add("Quart");
                            break;
                        }
                    case 8:
                        {
                            units.Add("Pint");
                            break;
                        }
                    case 9:
                        {
                            units.Add("Gallon");
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

                Console.WriteLine("Please Enter The Amount Of Ingredient");//data entry for entering ingredients
                tempStr = Console.ReadLine().Trim();
                if (!check.doubleInput(tempStr))
                {
                    while (!check.doubleInput(tempStr))
                    {
                        Console.WriteLine("Invalid Number Format Entered");
                        Console.WriteLine("Please Ensure That Only Numbers Are Entered");
                        tempStr = Console.ReadLine().Trim();
                    }
                }
                tempDouble = double.Parse(tempStr);
                amountOfIngredient.Add(tempDouble);

                Console.WriteLine("Please Enter The Amount Of Calories In This Ingredient");//data entry for entering calorie of ingredients
                tempStr = Console.ReadLine().Trim();
                if (!check.doubleInput(tempStr))
                {
                    while (!check.doubleInput(tempStr))
                    {
                        Console.WriteLine("Invalid Number Format Entered");
                        Console.WriteLine("Please Ensure That Only Numbers Are Entered");
                        tempStr = Console.ReadLine().Trim();
                    }
                }
                tempDouble = double.Parse(tempStr);
                calories = calories + tempDouble;
                Console.WriteLine("--------------------------------------------------------------------");
            }

            Console.WriteLine("");
            for (int i = 0; i < numberSteps; i++)//used to enter info to describe each step
            {
                counter = i + 1;
                Console.WriteLine("Please Enter The Description For Step {0}.", counter);
                tempStr = Console.ReadLine();
                if (!check.notNullInput(tempStr))
                {
                    while (!check.notNullInput(tempStr))
                    {
                        Console.WriteLine("Blank Input Detected, Please Enter The Step Description For Step {0}", counter);
                        tempStr = Console.ReadLine();
                    }
                }
                stepDescription.Add(tempStr);
            }

            //Storing data from the arrays for later access
            rl.stringCompress(nameRecipe, numberSteps, numberIngredients, ingredientName, units, amountOfIngredient, calories, stepDescription);

            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("");

            menuMain();
        }
    }
    public class InputChecker// class used to store methods for checking if an input is valid
    {
        public bool nameCheck(string str, List<string> nameList)
        {
            foreach (string tempSTR in nameList)
            {
                if (tempSTR == str)
                {
                    return true;
                }
            }

            return false;
        }
        public bool doubleInput(string str)// checks if input is a double
        {
            if (string.IsNullOrEmpty(str))//null input check
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NULL INPUT ERROR");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            try
            {
                double.Parse(str);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NON VALID INPUT, ENSURE THAT YOU HAVE ONLY ENTERED A NUMBER, ELSE CHECK THAT YOU USED A VALID DECIMAL CHARACTER");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            return true;
        }
        public bool intConstricCheck(string valSTR, int a, int b)//valSTR is the value being checked, a and b are the constraints, a is the lower bound while b is upper
        {
            int c = a - 1;// reasignment done to provide upper and lower bounds
            int d = b + 1;
            int val;

            try
            {
                val = int.Parse(valSTR);
            }
            catch (FormatException e)
            {
                return false;
            }

            if (val > c && val < d)
            {
                return true;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please ensure that the number falls within the accepted range");
            Console.ForegroundColor = ConsoleColor.White;
            return false;

        }
        public bool validInput(string str)//checking if string is null or
        {
            if (string.IsNullOrEmpty(str))//null input check
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NULL INPUT ERROR");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }

            try//using error handeling to check if it is possible to parse the integer
            {
                int.Parse(str);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("INVALID CHARACTER INPUT ERROR #3");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            return true;
        }
        public bool notNullInput(string str)//null input checker
        {
            if (string.IsNullOrEmpty(str))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NULL INPUT ERROR");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            return true;
        }
    }

    public class Compacter//used to set,store and get details for the recipe/steps
    /*
     * String Header: name, num steps, num Ingerdients, total calories (fixed Length)
     * String Body Section A: ingredent, amount, unit measured, ingredeint, amount, unit measured,...,(variable length repeating structure)
     * String body Section B: step description (variable length, repeating item)
     * 
     * using ◙ to separate the strings
     */
    {
        //data mass storage
        private SortedDictionary<string, string> recipeStore = new SortedDictionary<string, string>();
        //variable containing recipe data
        public string nameRecipe;
        public int numberSteps, numberIngredients;
        public double calories;
        public List<string> recipeNames = new List<string>();
        public List<string> ingredientName = new List<string>();
        public List<string> units = new List<string>();
        public List<string> stepDescription = new List<string>();
        public List<double> amountOfIngredient = new List<double>();


        public void removeRecipe(string str)//removes a recipe
        {
            recipeStore.Remove(str);
            updateName();
        }

        //info getters for geting data drom loaded strings
        private void updateName()
        {
            recipeNames.Clear();
            foreach (KeyValuePair<string, string> kvp in recipeStore)
            {
                recipeNames.Add(kvp.Key);
            }
        }
        public string getRecipeName()
        {
            return nameRecipe;
        }
        public int getNumStep()
        {
            return numberSteps;
        }
        public int getNumIngredients()
        {
            return numberIngredients;
        }
        public List<string> getIngredients()
        {
            return ingredientName;
        }
        public List<string> getUnitMeasured()
        {
            return units;
        }
        public double getCalories()
        {
            return calories;
        }
        public List<double> getAmount()
        {
            return amountOfIngredient;
        }

        public List<string> getStepDescrip()
        {
            return stepDescription;
        }
        public void stringCompress(string recipeName, int numStep, int numIngredients, List<string> ingredients, List<string> unitMeasured, List<double> amount, double calorie, List<string> stepDescrip)
        {
            string stringComp;//string comp is used to construct the recipie storage, ◙ is used to indicate end of string, ◙ was chosen as it is not likely to be used by a users
            string tempSTR = ""; //temporary string

            stringComp = recipeName + "?" + numStep + "?" + numIngredients + "?" + calorie + "?"; //header section of string

            //string body section A
            for (int i = 0; i < numIngredients; i++)
            {
                stringComp = stringComp + ingredients[i] + "?" + amount[i] + "?" + unitMeasured[i] + "?";
            }

            tempSTR = "";// clearing for B section manipulations
            for (int i = 0; i < numStep; i++)
            {
                stringComp = stringComp + stepDescrip[i] + "?";
            }

            recipeStore.Add(recipeName.ToLower(), stringComp);
            Console.WriteLine("Recipe Name: {0}, String: {1}", recipeName, stringComp);
            tempSTR = "";
            updateName();
        }

        public void recipeLoad(string compStr)
        {
            // String that recipeLoad loads
            string loadedSTR = "";

            // Variables exclusive to this method
            char tempChar; // Used multiple times for different manipulations
            int contInt = 0; // Control integer for loops
            int tempInt; // Temporary integer
            string tempSTR = ""; // Used to build up data that the string manipulation reveals

            // Loading string
            foreach (KeyValuePair<string, string> kvp in recipeStore)
            {
                if (kvp.Key.ToLower() == compStr.ToLower())
                {
                    loadedSTR = kvp.Value;
                    break; // Exit the loop once the matching key is found
                }
            }

            // Parsing string headers
            // Extracting recipe name
            while (contInt < loadedSTR.Length && loadedSTR[contInt] != '?')
            {
                tempSTR += loadedSTR[contInt];
                contInt++;
            }
            Console.WriteLine("Name " + tempSTR);
            nameRecipe = tempSTR;
            tempSTR = "";

            // Extracting number of steps
            if (contInt < loadedSTR.Length && loadedSTR[contInt] == '?')
            {
                contInt++; // Move past the '?'
                while (contInt < loadedSTR.Length && loadedSTR[contInt] != '?')
                {
                    tempSTR += loadedSTR[contInt];
                    contInt++;
                }
                Console.WriteLine("numSteps " + tempSTR);
                numberSteps = int.Parse(tempSTR);
                tempSTR = "";
            }

            // Extracting number of ingredients
            if (contInt < loadedSTR.Length && loadedSTR[contInt] == '?')
            {
                contInt++; // Move past the '?'
                while (contInt < loadedSTR.Length && loadedSTR[contInt] != '?')
                {
                    tempSTR += loadedSTR[contInt];
                    contInt++;
                }
                Console.WriteLine("Num Ingredients " + tempSTR);
                numberIngredients = int.Parse(tempSTR);
                tempSTR = "";
            }

            // Extracting Total calories
            if (contInt < loadedSTR.Length && loadedSTR[contInt] == '?')
            {
                contInt++; // Move past the '?'
                while (contInt < loadedSTR.Length && loadedSTR[contInt] != '?')
                {
                    tempSTR += loadedSTR[contInt];
                    contInt++;
                }
                Console.WriteLine("CAls " + tempSTR);
                calories = double.Parse(tempSTR);
                tempSTR = "";
            }

            // Parsing string body A
            for (int i = 0; i < numberIngredients; i++)
            {
                contInt++;
                tempChar = loadedSTR[contInt];//ingredient name
                while (contInt < loadedSTR.Length && loadedSTR[contInt] != '?')
                {
                    tempChar = loadedSTR[contInt];
                    tempSTR += loadedSTR[contInt];
                    contInt++;
                }
                ingredientName.Add(tempSTR);
                Console.WriteLine("Ingredient Name " + tempSTR);
                tempSTR = "";

                // Extract ingredient amount
                if (contInt < loadedSTR.Length && loadedSTR[contInt] == '?')
                {
                    contInt++; // Move past the '?'
                    while (contInt < loadedSTR.Length && loadedSTR[contInt] != '?')
                    {
                        tempSTR += loadedSTR[contInt];
                        contInt++;
                    }
                    Console.WriteLine("amount of ingred " + tempSTR);
                    amountOfIngredient.Add(double.Parse(tempSTR));
                    tempSTR = "";
                }

                // Extract ingredient unit
                if (contInt < loadedSTR.Length && loadedSTR[contInt] == '?')
                {
                    contInt++; // Move past the '?'
                    while (contInt < loadedSTR.Length && loadedSTR[contInt] != '?')
                    {
                        tempSTR += loadedSTR[contInt];
                        contInt++;
                    }
                    Console.WriteLine("ingred Units  " + tempSTR);
                    units.Add(tempSTR);
                    tempSTR = "";
                }
            }

            // Parsing string body B
            for (int i = 0; i < numberSteps; i++)
            {
                tempChar = loadedSTR[contInt];
                while (contInt < loadedSTR.Length && loadedSTR[contInt] != '?')
                {
                    tempChar = loadedSTR[contInt];
                    tempSTR += loadedSTR[contInt];
                    contInt++;
                }
                stepDescription.Add(tempSTR);
                tempSTR = "";
            }
        }

        public void rrecipeLoad(string compStr)//loads string for information extraction
        {
            //string that recipeLoad loads
            string loadedSTR = "";

            //variables exclusive to this method
            char tempChar;//used multiple times for diffrent manipulation
            int contInt = 0;// control integer for loops
            int tempInt;// temporary intager
            string tempSTR = "";// used to build up data that the string manipulation reveals
            string compString;

            //loading string 
            foreach (KeyValuePair<string, string> kvp in recipeStore)
            {
                if (kvp.Key.ToLower() == compStr.ToLower())
                {
                    loadedSTR = kvp.Value;
                }
            }

            // Parsing string headers
            // Extracting recipe name
            tempChar = loadedSTR[contInt];
            Console.WriteLine("Beginning parsing: " + loadedSTR);
            while (tempChar != '?')
            {
                tempChar = loadedSTR[contInt];
                if (tempChar != '?')
                {
                    tempSTR = tempSTR + loadedSTR[contInt];
                }
                contInt++;
                Console.WriteLine(tempSTR);
            }

            nameRecipe = tempSTR;
            tempSTR = "";

            // Extracting number of steps
            if (contInt < loadedSTR.Length)
            {
                tempChar = loadedSTR[contInt];
                while (tempChar != '?')
                {
                    tempChar = loadedSTR[contInt];
                    if (tempChar != '?')
                    {
                        tempSTR = tempSTR + loadedSTR[contInt];
                    }
                    contInt++;
                }
                Console.WriteLine(tempSTR);
                numberSteps = int.Parse(tempSTR);
                tempSTR = "";
            }

            // Extracting number of ingredients
            if (contInt < loadedSTR.Length)
            {
                tempChar = loadedSTR[contInt];
                while (tempChar != '?')
                {
                    tempChar = loadedSTR[contInt];
                    if (tempChar != '?')
                    {
                        tempSTR = tempSTR + loadedSTR[contInt];
                    }
                    contInt++;
                }
                Console.WriteLine(tempSTR);
                numberIngredients = int.Parse(tempSTR);
                tempSTR = "";
            }

            // Extracting Total calories
            if (contInt < loadedSTR.Length)
            {
                tempChar = loadedSTR[contInt];
                while (tempChar != '?')
                {
                    tempChar = loadedSTR[contInt];
                    if (tempChar != '?')
                    {
                        tempSTR = tempSTR + loadedSTR[contInt];
                    }
                    contInt++;
                }
                Console.WriteLine(tempSTR);
                calories = double.Parse(tempSTR);
                tempSTR = "";
            }

            //Parsing string body A
            tempInt = numberIngredients * 3;
            for (tempInt = 0; tempInt <= numberIngredients; tempInt++)
            {
                tempChar = loadedSTR[contInt];
                //extract ingredient name
                while (tempChar != '?')
                {
                    tempChar = loadedSTR[contInt];
                    tempSTR = tempSTR + loadedSTR[contInt];
                    contInt++;
                }
                ingredientName.Add(tempSTR);
                tempSTR = "";

                //extract ingredient amount
                while (tempChar != '?')
                {
                    tempChar = loadedSTR[contInt];
                    tempSTR = tempSTR + loadedSTR[contInt];
                    contInt++;
                }
                amountOfIngredient.Add(double.Parse(tempSTR));
                tempSTR = "";

                //extract ingredient unit
                while (tempChar != '?')
                {
                    tempChar = loadedSTR[contInt];
                    tempSTR = tempSTR + loadedSTR[contInt];
                    contInt++;
                }
                units.Add(tempSTR);
                tempSTR = "";
            }
            //parsing string body b
            for (tempInt = 0; tempInt <= numberSteps; tempInt++)
            {
                tempChar = loadedSTR[contInt];
                //extract step descriptions
                while (tempChar != '?')
                {
                    tempChar = loadedSTR[contInt];
                    tempSTR = tempSTR + loadedSTR[contInt];
                    contInt++;
                }
                stepDescription.Add(tempSTR);
                tempSTR = "";
            }

        }
    }
    public class RecipeList//used to set,store and get details for the recipe/steps
    {
        //declarations
        private int numStep; // number of steps
        private int numIngredients; // number of ingredients
        private string[] ingredients = new string[99]; //list of ingredients
        private string[] unitMeasured = new string[99]; // descriptor of the measurment unit
        private double[] amount = new double[99]; //the amount of ingredient
        private string[] stepDescrip = new string[99];

        //getter for the number of steps
        public int getNumStep()
        {
            return numStep;
        }
        //setter for the number of steps
        public void setNumStep(int numberOfSteps)
        {
            numStep = numberOfSteps;
        }
        //getter for the number of ingredients
        public int getNumIngredients()
        {
            return numIngredients;
        }
        //setter for the number of ingredients
        public void setNumIngredients(int numberOfIngredients)
        {
            numIngredients = numberOfIngredients;
        }
        //getter method to fetch the ingredients list
        public string[] getIngredients()
        {
            return ingredients;
        }
        //setter method to either clear or set which ingredients are in the list
        public void setIngredient(string[] strArray)
        {
            int temp = 0; // temporary variable
            foreach (string str in strArray)
            {
                ingredients[temp] = str;
                temp++;
            }
        }
        //getter to get the measurement unit of the ingredient
        public string[] getUnitMeasured()
        {
            return unitMeasured;
        }
        //setter for the measurment  unit of the ingredient
        public void setUnitMeasured(string[] units)
        {
            int temp = 0; // temporary variable
            foreach (string str in units)
            {
                unitMeasured[temp] = str;
                temp++;
            }
        }
        //getter to get the amount of the ingredient
        public double[] getUnitAmount()
        {
            return amount;
        }
        //setter for the amount of the ingredient
        public void setUnitAmount(double[] amountOf)
        {
            int temp = 0; // temporary variable
            foreach (double d in amountOf)
            {
                amount[temp] = d;
                temp++;
            }
        }
        //getter to get step description
        public string[] getStepDescrip()
        {
            return stepDescrip;
        }
        //setter to set step description
        public void setStepDescrip(string[] descrip)
        {
            int temp = 0; // temporary variable
            foreach (string str in descrip)
            {
                stepDescrip[temp] = str;
                temp++;
            }
        }
    }
}