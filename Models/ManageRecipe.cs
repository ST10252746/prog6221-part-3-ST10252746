using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace ST10252746_PROG6221_POE.Models
{//namespace begin
    public class ManageRecipe
    {//ManageRecipe class begin
        // Property to hold a list of recipes
        public List<Recipe> Recipes { get; private set; }

        // Constructor initializes the list of recipes
        public ManageRecipe()
        {//ManageRecipe begin
            Recipes = new List<Recipe>();
        }// ManageRecipe end

        // Method to add a recipe to the list
        public void AddRecipe(Recipe recipe)
        {//Addrecipe begin
            Recipes.Add(recipe);
        }//AddRecipe end

        // Method to display all recipes in a list box
        public void DisplayAllRecipes(ListBox recipeListBox)
        {//DisplayAllRecipes begin
            recipeListBox.Items.Clear();
            var sortedRecipes = Recipes.OrderBy(r => r.Name).ToList();

            foreach (var recipe in sortedRecipes)
            {//foreach begin
                recipeListBox.Items.Add(recipe.Name);
            }//foreach end
        }//DisplayAllRecipes end

        // Method to display details of a recipe in a text block
        public void DisplayRecipeDetails(Recipe recipe, TextBlock recipeDetailsTextBlock)
        {//DisplayRecipeDetails begin
            recipeDetailsTextBlock.Text = recipe.DisplayRecipe();
        }//DisplayRecipeDetails end

        // Method to scale a recipe by a factor
        public void ScaleRecipe(Recipe recipe, double factor)
        {//ScaleRecipe begin
            recipe.ScaleRecipe(factor);
        }//ScaleRecipe begin

        // Method to reset a recipe to its original values
        public void ResetRecipe(Recipe recipe)
        {// ResetRecipe begin
            recipe.ResetRecipe();
        }//ResetRecipe end

        // Method to delete a recipe from the list
        public void DeleteRecipe(Recipe recipe)
        {//deleteRecipe begin
            if (Recipes.Contains(recipe))
            {//if begin
                Recipes.Remove(recipe);
                MessageBox.Show($"Recipe '{recipe.Name}' has been deleted.", "Delete Recipe", MessageBoxButton.OK, MessageBoxImage.Information);
            }//if end
            else
            {//else begin
                MessageBox.Show($"Recipe '{recipe.Name}' not found.", "Delete Recipe", MessageBoxButton.OK, MessageBoxImage.Error);
            }//el;se end
        }//deleteRecipe class end
    }// managerecipe class end
}//namespace end