/*
 Theshara Narain - ST10252746
 PROG6221
 BCAD GROUP 1
 POE Part 3
 Github Link for Part 1: https://github.com/VCDN-2024/prog6221-part-1-ST10252746.git 
 Github Link for Part 2: https://github.com/VCDN-2024/prog6221-part-2-ST10252746.git 
 Github Link for Part 3: https://github.com/ST10252746/prog6221-part-3-ST10252746.git 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace ST10252746_PROG6221_POE.Models
{
    public delegate void RecipeDelegate(string message);  
    public class Recipe
    {// Recipe class begin
        public string Name { get; set; } // Recipe Name
        public int NumIngredients { get; set; }  //Number of Ingredrients
        public int NumSteps { get; set; } //Number of Steps
        public List<Ingredient> Ingredients { get; set; }   //List of ingredients in the recipe
        public List<Step> Steps { get; set; }  //List of steps in the recipe

        private double totalCalories; // Total calorie count of the recipe
        private StringBuilder CalorieInformation; // StringBuilder to store calorie-related information

        //Default constructor initializes lists and StringBuilder
        public Recipe()
        {//Recipe Constructor begin
            Ingredients = new List<Ingredient>();
            Steps = new List<Step>();
            CalorieInformation = new StringBuilder();
        }//Recipe Constructor end

        // Constructor with parameters to set recipe properties
        public Recipe(string name, int numIngredients, int numSteps)
        {//Recipe Constructor begin
            Name = name;
            NumIngredients = numIngredients;
            NumSteps = numSteps;
            Ingredients = new List<Ingredient>();
            Steps = new List<Step>();
            CalorieInformation = new StringBuilder();
        }//Recipe Constructor end

        //Method to Add Ingredient 
        public void AddIngredient(Ingredient ingredient)
        {// AddIngredient begin
            Ingredients.Add(ingredient);
        }// AddIngredient end

        //Method to Add Step 
        public void AddStep(Step step)
        {//AddStep begin
            Steps.Add(step);
        }// AddStep end

       //Sets the list of ingredients for the recipe
        public void SetIngredients(List<Ingredient> ingredients)
        {//  SetIngredients begin
            Ingredients = ingredients;
        }//  SetIngredients end

        //Sets the list of steps for the recipe
        public void SetSteps(List<Step> steps)
        {// SetSteps begin
            Steps = steps;
        }// SetSteps end

        //Calculates the total calories of the recipe based on its ingredients
        public double CalculateTotalCalories()
        {// CalculateTotalCalories begin
            double totalCalories = 0;
            foreach (var ingredient in Ingredients)
            {//foreach begin
                totalCalories += ingredient.Calories;
            }//foreach end
            return totalCalories;
        }// CalculateTotalCalories end

        private void DisplayCalorieInformation(string message)
        {//DisplayCalorieInformation begin
            CalorieInformation.AppendLine(message);
        }// DisplayCalorieInformation end

        //Method to display recipe and its details
        public string DisplayRecipe()
        {// DisplayRecipe begin
            CalorieInformation.Clear();
            RecipeDelegate recipeDelegate = new RecipeDelegate(DisplayCalorieInformation);

            string recipeDetails = $"Recipe: {Name}\n=======================================";
            recipeDetails += "Ingredients:n=======================================";
            foreach (var ingredient in Ingredients)
            {// foreach begin
                recipeDetails += $"- {ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.Calories} calories)\nFood Group: {ingredient.FoodGroup}\n=======================================";
            }// foreach end
            recipeDetails += "Steps:\n=======================================";
            for (int i = 0; i < Steps.Count; i++)
            {// for begin
                recipeDetails += $"Step {i + 1}: {Steps[i].Description}\n";
            }// for end

            recipeDetails += "=======================================\n";

            DisplayCalories(recipeDelegate);
            recipeDetails += CalorieInformation.ToString();
            return recipeDetails;
        }// DisplayRecipe end

        // Displays information about the total calories in the recipe and provides calorie-related recommendations
        private void DisplayCalories(RecipeDelegate recipeDelegate)
        {// DisplayCalories begin

            totalCalories = CalculateTotalCalories();
            recipeDelegate($"Total number of calories in recipe: {totalCalories}");

            if (totalCalories > 300)
            {//if begin
                recipeDelegate("CALORIES EXCEED 300");
            }//if end

            if (totalCalories > 0 && totalCalories <= 200)
            {// if begin
                recipeDelegate("This amount of calories is enough to satisfy you without interfering with appetite typically designed for weight loss or as part of a calorie-restricted diet and is a good ULTRA LOW-CALORIE MEAL");
            }// if end
            else if (totalCalories > 200 && totalCalories <= 400)
            {// else if begin
                recipeDelegate("This amount of calories is suitable for a LOW CALORIE MEAL, which can aid in weight management and promote overall health by helping to maintain a healthy weight and reduce the risk of certain health conditions");
            }// else if end
            else if (totalCalories > 400 && totalCalories <= 700)
            {// else if begin
                recipeDelegate("This amount of calories is suitable for a MODERATE CALORIE MEAL, which provides a balanced intake of energy to support daily activities and metabolic functions, promoting sustained energy levels and overall well-being ");
            }// else if end
            else if (totalCalories > 700)
            {// else if begin
                recipeDelegate("This amount of calories is suitable for a HIGH CALORIE MEAL, which provide a substantial energy intake suitable for individuals with higher energy requirements, aiding in fueling intense physical activity and supporting growth or muscle gain goals");
            }// else if end
        }// DisplayCalories end

        // Method to scale the recipe based on the user's selection
        public void ScaleRecipe(double factor)
        {//ScaleRecipe begin
            foreach (var ingredient in Ingredients) //// Scale each ingredient in the recipe
            {//foreach end
                double scaledQuantity = ingredient.Quantity * factor;
                ingredient.CalculateScaledCalories(factor);

                // Convert quantities based on the unit of measurement
                switch (ingredient.Unit)
                {//switch begin
                    case UnitsOfMeasurement.CUP:
                    case UnitsOfMeasurement.CUPS:
                        ConvertCups(ingredient, scaledQuantity);
                        break;
                    case UnitsOfMeasurement.TABLESPOON:
                    case UnitsOfMeasurement.TABLESPOONS:
                        ConvertTablespoons(ingredient, scaledQuantity);
                        break;
                    case UnitsOfMeasurement.TEASPOON:
                    case UnitsOfMeasurement.TEASPOONS:
                        ConvertTeaspoons(ingredient, scaledQuantity);
                        break;
                    default:
                        ingredient.Quantity = scaledQuantity;
                        break;
                }//switch end
            }//foreach begin
        }// ScaleRecipe end

        public void ConvertTeaspoons(Ingredient ingredient, double newQuantity)
        {//ConvertTeaspoons begin
            // Convert to tablespoons if quantity is 3 teaspoons or more.
            if (newQuantity >= 3)
            {// if begin
                if (newQuantity == 3)
                {//if begin
                    ingredient.Quantity = 1;
                    ingredient.Unit = UnitsOfMeasurement.TABLESPOON;
                }// if end
                else
                {//else begin
                    double tablespoons = newQuantity / 3;
                    ingredient.Quantity = tablespoons;
                    ingredient.Unit = UnitsOfMeasurement.TABLESPOONS;
                }//else end
            }//if end
            // Keep as teaspoons if quantity is 1 teaspoon or less.
            else if (newQuantity <= 1)
            {//else if begin
                ingredient.Quantity = newQuantity;
                ingredient.Unit = UnitsOfMeasurement.TEASPOON;
            }//else end
            // Keep as teaspoons if quantity is between 1 and 3 teaspoons.
            else
            {//else begin
                ingredient.Quantity = newQuantity;
                ingredient.Unit = UnitsOfMeasurement.TEASPOONS;
            }//else end
        }//ConvertTeaspoons method end


        // ConvertTablespoons Method to convert quantities when scaling recipe ingredients measured in tablespoons
        public void ConvertTablespoons(Ingredient ingredient, double newQuantity)
        {// ConvertTablespoons begin
            // Convert to cups if quantity is 16 tablespoons (1 cup) or more.
            if (newQuantity >= 16)
            {// if begin
                if (newQuantity == 16)
                {//if begin
                    ingredient.Quantity = 1;
                    ingredient.Unit = UnitsOfMeasurement.CUP;
                }//if end
                else
                {//else begin
                    double cups = newQuantity / 16;
                    ingredient.Quantity = cups;
                    ingredient.Unit = UnitsOfMeasurement.CUPS;
                }//else end
            }//if end
            // Convert to teaspoons if quantity is less than 1 tablespoon.
            else if (newQuantity < 1)
            {//else if begin
                double teaspoons = newQuantity * 3;
                ingredient.Quantity = teaspoons;
                ingredient.Unit = UnitsOfMeasurement.TEASPOONS;
            }//else if end
            // Keep as tablespoons if quantity is between 1 and 16 tablespoons.
            else
            {//else begin
                if (newQuantity == 1)
                {//if begin
                    ingredient.Quantity = 1;
                    ingredient.Unit = UnitsOfMeasurement.TABLESPOON;
                }//if end
                else
                {//else begin
                    ingredient.Quantity = newQuantity;
                    ingredient.Unit = UnitsOfMeasurement.TABLESPOONS;
                }//else end
            }//else end
        }// ConvertTablespoons end
        // ConvertTeaspoons Method to convert quantities when scaling recipe ingredients measured in teaspoons
   
        // ConvertCups Method to convert quantities when scaling recipe ingredients measured in cups
        public void ConvertCups(Ingredient ingredient, double newQuantity)
        {//ConvertCups begin
            // Convert to tablespoons if quantity is less than 1 cup.
            if (newQuantity < 1)
            {// if begin
                double tablespoons = newQuantity * 16;
                ingredient.Quantity = tablespoons;
                ingredient.Unit = UnitsOfMeasurement.TABLESPOONS;
            }//if end
            // Keep as cups if quantity is exactly 1 cup.
            else if (newQuantity == 1)
            {//else if begin
                ingredient.Quantity = newQuantity;
                ingredient.Unit = UnitsOfMeasurement.CUP;
            }//else if end
            // Keep as cups if quantity is greater than 1 cup.
            else
            {//else begin
                ingredient.Quantity = newQuantity;
                ingredient.Unit = UnitsOfMeasurement.CUPS;
            }//else end
        }// ConvertCups end
        //Reset Recipe mehod
        public void ResetRecipe()
        {// ResetRecipe begin
            foreach (Ingredient ingredient in Ingredients)
            {//foreach begin
                ingredient.Quantity = ingredient.originalQuantity;
                ingredient.Unit = ingredient.originalUnit;
                ingredient.Calories = ingredient.originalCalories;
            }//foreach end

            totalCalories = CalculateTotalCalories();

            Console.ForegroundColor = ConsoleColor.Green; // sets the text color of the console output to that specific colour
            Console.WriteLine("\nRecipe has been reset to its orgin state successfully!\n");
            Console.ResetColor(); //Restore the original console colors
        }// ResetRecipe end
    }
}