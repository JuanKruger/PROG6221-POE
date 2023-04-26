namespace Prog6221POE
{
    /*
     * Version (NF)0.5 NonFunctional  
     * 
     * 
     * Internal dev notes
    *
    * 
    * currently working on
    * storing info on ingredients line 69, use loops, working on ingredient name
    *
    *
    *
    *
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
        private Scaler scl = new Scaler(); //scl short for scaler
        InputChecker check = new InputChecker();// checking if input is in an acceptable format
        public void Run()//runs through all relevant methods
        {
            dataEntry();
        }
        private void dataEntry() //used to call methods in order for the data entry
        {
            //declaration for varibles only used inside the class
            string tempStr; //temporary variable, will be overwritten multiple times
            int tempInt;  //temporary variable, will be overwritten multiple times
            int switchInt; // used to opperate the switch case 
            //declaration of arrays
            string[] ingredients = new string[20];
            string[] units = new string[20];
            string[] stepDescript = new string[20];
            double[] amount = new double[20];


            //prompt user, the cast the answer into the format needed
            Console.WriteLine("Please Enter The Amount Of Ingredients In This Recipe");
            tempStr = Console.ReadLine().Trim();
            if (!check.validInput(tempStr))
            {
                while(!check.validInput(tempStr))
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
            if (!check.validInput(tempStr))
            {
                while (!check.validInput(tempStr))
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
                Console.WriteLine("Please Enter Information On The Ingredient for the following parameters             Ingredient{0}/{1}", i, rl.getNumIngredients());
                Console.WriteLine("Please enter the Ingredients Name");
                tempStr = Console.ReadLine().Trim();
                if (!check.notNullInput(tempStr))
                {
                    while (!check.notNullInput(tempStr));
                    {
                        Console.WriteLine("Please Enter The Name Of The Ingredient, Please don't leave it empty");
                        tempStr = Console.ReadLine();
                    }
                }
                ingredients[i] = tempStr; //adding to local array, setting it on the setter array after all data entry is complete

                Console.WriteLine("Please Select The Unit Used To measure the ingredient");//gives several options, of bakeing units
                tempStr = Console.ReadLine().Trim();
                if (!check.validInput(tempStr) || !check.intConstricCheck(tempStr, 1, 10))
                {
                    while (!check.validInput(tempStr) || !check.intConstricCheck(tempStr, 1, 10))
                    {
                        Console.WriteLine("Invalid Number Format Entered");
                        Console.WriteLine("Please Ensure That Only Numbers Are Entered");
                        tempStr = Console.ReadLine().Trim();
                    }
                }
                switchInt = int.Parse(tempStr);//parsing int to get a valid input


                switch (switchInt)
                {
                    case 0:
                        {
                            // Code to execute for option 0
                            break;
                        }
                    case 1:
                        {
                            // Code to execute for option 1
                            break;
                        }
                    case 2:
                        {
                            // Code to execute for option 2
                            break;
                        }
                    case 3:
                        {
                            // Code to execute for option 3
                            break;
                        }
                    case 4:
                        {
                            // Code to execute for option 4
                            break;
                        }
                    case 5:
                        {
                            // Code to execute for option 5
                            break;
                        }
                    case 6:
                        {
                            // Code to execute for option 6
                            break;
                        }
                    case 7:
                        {
                            // Code to execute for option 7
                            break;
                        }
                    case 8:
                        {
                            // Code to execute for option 8
                            break;
                        }
                    case 9:
                        {
                            // Code to execute for option 9
                            break;
                        }
                    default:
                        {
                            // Code to execute if no case matches
                            break;
                        }
                }

            }

            for (int i = 0; i < rl.getNumStep(); i++)//used to enter info to describe each step
            {

            }
            //adding methods that set null for now, just to ensure i remember to implement them/easy refrence
            //rl.setIngredient(null);//null value, replace with output
            //rl.setUnitMeasured(null);
            //rl.setUnitAmount(null);
            //rl.setStepDescrip(null);

        }
    }
    public class InputChecker
    {
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
                Console.WriteLine("INVALID CHARACTER INPUT ERROR");
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
            else
            {
                return true;
            }
        }
    }

    //Scaler Does not have the required functionallity, but is suitible for now
    public class Scaler //used to scale the units measured
    {//will possible be called ony at time of display
        public double scaleIngredient(double scaleUnit, double amount)//scaleUnit = what the recipe is scalled by, amount = amount of ingredient
        {
            amount = amount * scaleUnit;
            return amount; 
        }
    }

    public class RecipeList//used to set,store and get details for the recipe/steps
    {
        //declarations
        private int numStep; // number of steps
        private int numIngredients; // number of ingredients
        private string[] ingredients = new string[20]; //list of ingredients
        private string[] unitMeasured = new string[20]; // descriptor of the measurment unit
        private double[] amount = new double[20]; //the amount of ingredient
        private string[] stepDescrip = new string[20];

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
        public string[] getIngredients(int x)
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
                ingredients[temp] = str;
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