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
        public double scaleIngredient(string unit, double amount)//unit = measurning unit, amount = amount of ingredient
        {
            return 0.0; 
        }
    }

    public class RecipeList//used to set,store and get details for the recipe/steps
    {
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
        //getter to get the measurement of the ingredient
        public string[] getUnitMeasured()
        {
            return null;
        }
        //setter for the measurment of the ingredient
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
        public string[] getIngredientsStep() //possible solution, use format ;x;x;x/ where ; = there is an item next, x = ingredient related to getIngredient
                                             // / = end of list, # = no further steps
        {
            return null;
        }
        //setter to set the ingredients needed for each step
        public void setIngredientsStep()
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