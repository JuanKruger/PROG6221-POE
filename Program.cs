namespace Prog6221POE
{
    /*
     * Version 0.3 NonFunctional
     * 
     * 
     * Internal dev notes
    *
    * ignore/delete anything related to ingredients per step, user must manually enter ingredients in the step description
    *
    *
    *
    *
    *
    */
    public class RecipeMachine_driver
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
        InputChecker check = new InputChecker();
        public void Run()
        {
            dataEntry();
        }
        private void dataEntry() //used to call methods in order for the data entry
        {
            //declaration for varibles only used inside the class
            string tempStr; //temporary variable, will be overwritten multiple times
            int tempInt;  //temporary variable, will be overwritten multiple times


            //prompt user, the cast the answer into the format needed
            Console.WriteLine("Please Enter The Amount Of Ingredients In This Recipe");
            tempStr = Console.ReadLine().Trim();
            if (!check.validInput(tempStr))
            {
                while(!check.validInput(tempStr))
                {
                    Console.WriteLine("Invalid Number Format Entered");
                    Console.WriteLine("Please Ensure That Only Numbers Are Entered");
                }
            }
            tempInt = int.Parse(tempStr);
            rl.setNumIngredients(tempInt);
            
            

            //prompt user, the cast the answer into the format needed
            Console.WriteLine("Please Enter The Amount Of Steps In This Recipe");
            Console.ReadLine().Trim();
            if (!check.validInput(tempStr))
            {
                while (!check.validInput(tempStr))
                {
                    Console.WriteLine("Invalid Number Format Entered");
                    Console.WriteLine("Please Ensure That Only Numbers Are Entered");
                }
            }
            tempInt = int.Parse(tempStr);
            rl.setNumStep(tempInt);
        }
    }
    public class InputChecker
    {
        public bool validInput(string str)
        {
            try
            {
                int.Parse(str);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }

    public class Scaler //used to scale the units measured
    {
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
        public string[] getIngredients()
        {
            return null;
        }
        //setter method to either clear or set which ingredients are in the list
        public void setIngredient()
        {

        }
        //getter to get the measurement unit of the ingredient
        public string[] getUnitMeasured()
        {
            return null;
        }
        //setter for the measurment  unit of the ingredient
        public void setUnitMeasured()
        {

        }
        //getter to get the amount of the ingredient
        public double[] getUnitAmount()
        {
            return null;
        }
        //setter for the amount of the ingredient
        public void setUnitAmount()
        {

        }
        //getter to get step description
        public string[] getStepDescrip()
        {
            return null;
        }
        //setter to set step description
       public void setStepDescrip()
        {

        }
    }
    
}