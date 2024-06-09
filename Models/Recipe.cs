using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10252746_PROG6221_POE.Models
{
    public delegate void RecipeDelegate(string message);  
    public class Recipe
    {
        public string Name { get; set; } 
        public int NumIngredients { get; set; } 
        public int NumSteps { get; set; } 
        public List<Ingredient> Ingredients { get; set; }  
        public List<Step> Steps { get; set; } 

        private double totalCalories; 
        private StringBuilder CalorieInformation;

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<Step>();
            CalorieInformation = new StringBuilder();
        }

        public Recipe(string name, int numIngredients, int numSteps)
        {
            Name = name;
            NumIngredients = numIngredients;
            NumSteps = numSteps;
            Ingredients = new List<Ingredient>();
            Steps = new List<Step>();
            CalorieInformation = new StringBuilder();
        }

        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
        }

        public void AddStep(Step step)
        {
            Steps.Add(step);
        }

        public void SetIngredients(List<Ingredient> ingredients)
        {
            Ingredients = ingredients;
        }

        public void SetSteps(List<Step> steps)
        {
            Steps = steps;
        }

        public double CalculateTotalCalories()
        {
            double totalCalories = 0;
            foreach (var ingredient in Ingredients)
            {
                totalCalories += ingredient.Calories;
            }
            return totalCalories;
        }

        private void DisplayCalorieInformation(string message)
        {
            CalorieInformation.AppendLine(message);
        }

        public string DisplayRecipe()
        {
            CalorieInformation.Clear();
            RecipeDelegate recipeDelegate = new RecipeDelegate(DisplayCalorieInformation);

            string recipeDetails = $"Recipe: {Name}\n=======================================";
            recipeDetails += "Ingredients:n=======================================";
            foreach (var ingredient in Ingredients)
            {
                recipeDetails += $"- {ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.Calories} calories)\nFood Group: {ingredient.FoodGroup}\n=======================================";
            }
            recipeDetails += "Steps:\n=======================================";
            for (int i = 0; i < Steps.Count; i++)
            {
                recipeDetails += $"Step {i + 1}: {Steps[i].Description}\n";
            }

            recipeDetails += "=======================================\n";

            DisplayCalories(recipeDelegate);
            recipeDetails += CalorieInformation.ToString();
            return recipeDetails;
        }

        private void DisplayCalories(RecipeDelegate recipeDelegate)
        {

            totalCalories = CalculateTotalCalories();
            recipeDelegate($"Total number of calories in recipe: {totalCalories}");

            if (totalCalories > 300)
            {
                recipeDelegate("CALORIES EXCEED 300");
            }

            if (totalCalories > 0 && totalCalories <= 200)
            {
                recipeDelegate("This amount of calories is enough to satisfy you without interfering with appetite typically designed for weight loss or as part of a calorie-restricted diet and is a good ULTRA LOW-CALORIE MEAL");
            }
            else if (totalCalories > 200 && totalCalories <= 400)
            {
                recipeDelegate("This amount of calories is suitable for a LOW CALORIE MEAL, which can aid in weight management and promote overall health by helping to maintain a healthy weight and reduce the risk of certain health conditions");
            }
            else if (totalCalories > 400 && totalCalories <= 700)
            {
                recipeDelegate("This amount of calories is suitable for a MODERATE CALORIE MEAL, which provides a balanced intake of energy to support daily activities and metabolic functions, promoting sustained energy levels and overall well-being "); 
            }
            else if (totalCalories > 700)
            {
                recipeDelegate("This amount of calories is suitable for a HIGH CALORIE MEAL, which provide a substantial energy intake suitable for individuals with higher energy requirements, aiding in fueling intense physical activity and supporting growth or muscle gain goals"); 
            }
        }

        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                double scaledQuantity = ingredient.Quantity * factor;
                ingredient.CalculateScaledCalories(factor);

                switch (ingredient.Unit)
                {
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
                }
            }
        }

        private void ConvertCups(Ingredient ingredient, double newQuantity)
        {
            if (newQuantity < 1)
            {
                double tablespoons = newQuantity * 16;
                ingredient.Quantity = tablespoons;
                ingredient.Unit = UnitsOfMeasurement.TABLESPOONS;
            }
            else if (newQuantity == 1)
            {
                ingredient.Quantity = newQuantity;
                ingredient.Unit = UnitsOfMeasurement.CUP;
            }
            else
            {
                ingredient.Quantity = newQuantity;
                ingredient.Unit = UnitsOfMeasurement.CUPS;
            }
        }

        private void ConvertTablespoons(Ingredient ingredient, double newQuantity)
        {
            if (newQuantity >= 16)
            {
                if (newQuantity == 16)
                {
                    ingredient.Quantity = 1;
                    ingredient.Unit = UnitsOfMeasurement.CUP;
                }
                else
                {
                    double cups = newQuantity / 16;
                    ingredient.Quantity = cups;
                    ingredient.Unit = UnitsOfMeasurement.CUPS;
                }
            }
            else if (newQuantity < 1)
            {
                double teaspoons = newQuantity * 3;
                ingredient.Quantity = teaspoons;
                ingredient.Unit = UnitsOfMeasurement.TEASPOONS;
            }   
            else
            {
                if (newQuantity == 1)
                {
                    ingredient.Quantity = 1;
                    ingredient.Unit = UnitsOfMeasurement.TABLESPOON;
                }
                else
                {
                    ingredient.Quantity = newQuantity;
                    ingredient.Unit = UnitsOfMeasurement.TABLESPOONS;
                }
            }
        }

        private void ConvertTeaspoons(Ingredient ingredient, double newQuantity)
        {
            if (newQuantity >= 3)
            {
                if (newQuantity == 3)
                {
                    ingredient.Quantity = 1;
                    ingredient.Unit = UnitsOfMeasurement.TABLESPOON;
                }
                else
                {
                    double tablespoons = newQuantity / 3;
                    ingredient.Quantity = tablespoons;
                    ingredient.Unit = UnitsOfMeasurement.TABLESPOONS;
                }
            }
            else if (newQuantity <= 1)
            {
                ingredient.Quantity = newQuantity;
                ingredient.Unit = UnitsOfMeasurement.TEASPOON;
            }
            else
            {
                ingredient.Quantity = newQuantity;
                ingredient.Unit = UnitsOfMeasurement.TEASPOONS;
            }
        }

        public void ResetRecipe()
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity = ingredient.originalQuantity;
                ingredient.Unit = ingredient.originalUnit;
                ingredient.Calories = ingredient.originalCalories;
            }

            totalCalories = CalculateTotalCalories();
        }
    }
}