namespace Prog6221POE
{
    public class RecipeMachine
    {
        static void Main(string[] args)
        {
            RecipeList rl = new RecipeList();//rl stands for recipe list
            Scaler scl = new Scaler(); //scl short for scaler
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
        private string[] ingredientsPerStep = new string[20]; // the list that groups which ingredients go in which steps
        private string[] stepDescrip = new string[20];


        //setter for the number of steps
        public void setNumStep()
        {

        }
        //setter for the number of ingredients
        public void setNumIngredients()
        {

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
        //getter to get the ingredients needed for each step
        public string[] getIngredientsPerStep() //possible solution, use format ;x;x;x/ where ; = there is an item next, x = ingredient related to getIngredient
                                             // / = end of list, # = no further steps
        {
            return null;
        }
        //setter to set the ingredients needed for each step
        public void setIngredientsPerStep()
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