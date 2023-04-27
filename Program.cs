namespace Prog6221POE
{
    /*
     * Version (NF)0.13 NonFunctional  
     * 
     * 
     * Internal dev notes
    * 
    * Units Used for measuring are, ml, litre, TeaSpoon, TableSpoon, OZ, Cup, Quart, Pint, Gallon
    *
    *add display method
    *test data entry
    */
    public class RecipeMachine_driver//main method and related items
    {
        public static void Main(string [] args)
        {
            RecipeMachine rm = new RecipeMachine();
            rm.Run();
        }
    }
    public class RecipeMachine
    {
        private RecipeList rl = new RecipeList();//rl stands for recipe list
        private ScaleConvert sc = new ScaleConvert(); //sc short for scaleConvert
        InputChecker check = new InputChecker();// checking if input is in an acceptable format

        //declaration of arrays
        private string[] ingredients = new string[99];
        private string[] units = new string[99];
        private string[] stepDescript = new string[99];
        private double[] amount = new double[99];

        public void Run()//runs through all relevant methods
        {
            dataEntry();
        }
        private void menuConfirmClearAndReEnter()//Confirmation for data reEntry
        {
            //variable declaration
            string tempStr;// temporary variable
            int switchInt;// used to control a switch

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Clearing The Recipe Means That You Will No Longer Be Able To Access It!!!!");
            Console.WriteLine("Please Confirm Action: Clear Stored Data And Enter New Recipe");
            Console.ForegroundColor = ConsoleColor.White;        
            Console.WriteLine("1. Clear And Enter New Data");
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
                        dataEntry();
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
            Console.WriteLine("1. Display Stored Recipe");
            Console.WriteLine("2. Clear And Enter New Recipe");
            Console.WriteLine("3. Scale Recipe Or Reset Recipe Scale");
            Console.WriteLine("4. Exit Application");
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
                        menuConfirmClearAndReEnter();
                        break;
                    }
                case 3:
                    {
                        menuScaleConvert();
                        break;
                    }
                case 4:// exit
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
            ingredients = rl.getIngredients();
            units = rl.getUnitMeasured();
            stepDescript = rl.getStepDescrip();
            amount = rl.getUnitAmount();
            
            menuMain();
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

            sc.scaleIngredient(amount, factor, rl.getNumIngredients());

            menuMain();
        }
        private void dataDisplay()// not final display method, only for testing
        {
            int counter; //used where i need some source of counter

            //information about the recipe
            Console.WriteLine("The following information is about the Recipe");
            Console.WriteLine("The Number of Steps In This Recipe Is {0}", rl.getNumStep());
            Console.WriteLine("There Are {0} Ingredients", rl.getNumIngredients());
            Console.WriteLine("The Following Are The Ingredients and the amounts Needed");
            for (int i = 0; i < rl.getNumIngredients(); i++)
            {
                Console.WriteLine("Ingredients");
                Console.WriteLine("Ingredient" + ingredients[i]);
                Console.WriteLine("amount" + amount[i]);
                Console.WriteLine("Unit" + units[i]);


                counter = i + 1;
                Console.WriteLine("Ingredient " + counter + ": " + ingredients[i] + "  " + amount[i] + units[i]);//, counter, ingredients[i], amount[i], units[i]
            }
            Console.WriteLine("Here Are The Steps For The Recipe");
            for (int i = 0; i < rl.getNumStep(); i++)
            {
                counter = i + 1;
                Console.WriteLine("Step {0}:", counter);
                Console.WriteLine(stepDescript[i]);
            }
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("");

            menuMain();
        }
        private void dataEntry() //used to call methods in order for the data entry
        {
            //declaration for varibles only used inside the class
            string tempStr; //temporary variable, will be overwritten multiple times
            int tempInt;  //temporary variable, will be overwritten multiple times
            double tempDouble; // temporary variable, will be overwritten multiple times
            int counter; //used where i need some source of counter
            int switchInt; // used to opperate the switch case 
            


            //prompt user, the cast the answer into the format needed
            Console.WriteLine("Please Enter The Amount Of Ingredients In This Recipe");
            tempStr = Console.ReadLine().Trim();
            if (!check.validInput(tempStr) || !check.intConstricCheck(tempStr, 1, 99))
            {
                while(!check.validInput(tempStr) || !check.intConstricCheck(tempStr, 1, 99))
                {
                    Console.WriteLine("Invalid Number Format Entered");
                    Console.WriteLine("Please Ensure That Only Numbers Are Entered");
                    tempStr = Console.ReadLine().Trim();
                }
            }
            tempInt = int.Parse(tempStr);
            rl.setNumIngredients(tempInt);
            
            //prompt user, the cast the answer into the format needed
            Console.WriteLine("Please Enter The Amount Of Steps In This Recipe");
            tempStr = Console.ReadLine().Trim();
            if (!check.validInput(tempStr) || !check.intConstricCheck(tempStr, 1, 99))
            {
                while (!check.validInput(tempStr) || !check.intConstricCheck(tempStr, 1, 99))
                {
                    Console.WriteLine("Invalid Number Format Entered");
                    Console.WriteLine("Please Ensure That Only Numbers Are Entered");
                    tempStr= Console.ReadLine().Trim();
                }
            }
            tempInt = int.Parse(tempStr);
            rl.setNumStep(tempInt);

            //propmt user to enter info on ingredients, ie name, unit and amount used
            for (int i = 0; i < rl.getNumIngredients(); i++)
            {
                counter = i + 1;
                Console.WriteLine("Please Enter Information On The Ingredient for the following parameters             Ingredient{0}/{1}", counter, rl.getNumIngredients());
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
                ingredients[i] = tempStr; //adding to local array, setting it on the setter array after all data entry is complete

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

                //following switch case used to set what unit an ingredient is stored as
                switch (switchInt) //Units Used for measuring are, ml, litre, TeaSpoon, TableSpoon, OZ, Cup, Quart, Pint, Gallon, other
                {
                    case 1:
                        {
                            units[i] = "ml";//millilitre
                            break;
                        }
                    case 2:
                        {
                            units[i] = "L";//litre
                            break;
                        }
                    case 3:
                        {
                            units[i] = "Teaspoon";
                            break;
                        }
                    case 4:
                        {
                            units[i] = "Tablespoon";
                            break;
                        }
                    case 5:
                        {
                            units[i] = "OZ";//Fluid Ounce
                            break;
                        }
                    case 6:
                        {
                            units[i] = "Cup";
                            break;
                        }
                    case 7:
                        {
                            units[i] = "Quart";
                            break;
                        }
                    case 8:
                        {
                            units[i] = "Pint";
                            break;
                        }
                    case 9:
                        {
                            units[i] = "Gallon";
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
                amount[i] = tempDouble;
            }

            

            for (int i = 0; i < rl.getNumStep(); i++)//used to enter info to describe each step
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
                stepDescript[i] = tempStr;
            }

            //Storing data from the arrays for later acces
            rl.setIngredient(ingredients);
            rl.setUnitMeasured(units);
            rl.setUnitAmount(amount);
            rl.setStepDescrip(stepDescript);

            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("");

            menuMain();

        }
    }
    public class InputChecker// class used to store methods for checking if an input is valid
    {
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

    //Scaler Does not have the required functionallity, but is suitible for now
    public class ScaleConvert //used to scale and convert the units measured
    {//will possible be called ony at time of display
        public double[] scaleIngredient(double[] amount, double factor, int numItems)//amount is the array for the full amount, factor is the scale factor, numItems = number of items to scale
        {
            for (int i = 0; i < numItems; i++)
            {
                amount[i] = amount[i] * factor;
            }
            return amount; 
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