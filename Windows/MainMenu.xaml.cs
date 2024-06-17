using ST10252746_PROG6221_POE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ST10252746_PROG6221_POE.Windows
{
    /// <summary>
    /// Interaction logic for ViewRecipe.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        //Variable Declaration
        private ManageRecipe manageRecipe;
        private List<Recipe> sortedRecipes;
        private int selection;
        public MainMenu(ManageRecipe manageRecipe)
        {
            InitializeComponent();
            this.manageRecipe = manageRecipe;
            DisplayRecipes();
        }
        //Method to Load Recipes and displaying recipes in the list box
        private void DisplayRecipes()
        {//LoadRecipes begin
            //Clear the list box
            lstbxRecipeDisplay.Items.Clear();
            //Store the alphabetically sorted recipes in a variable
            sortedRecipes = manageRecipe.Recipes.OrderBy(r => r.Name).ToList();

            //Validation for no recipes added - if sortedRecipes is null
            if (sortedRecipes.Count == 0)
            {//if begin
                //display message in list boxx
                lstbxRecipeDisplay.Items.Add("No recipes available to display.");
            }//if end
            else
            {//else if there are recipes stored in sortedrecipes display it
                //foreach method to display all recipes stored in sortedRecipes
                foreach (var recipe in sortedRecipes)
                {//for each begin
                 //display the Name of the recipe and Total Calories of Recipe
                    lstbxRecipeDisplay.Items.Add($"{recipe.Name}\n{recipe.CalculateTotalCalories()} total calories");
                }//foreach end
            }//else

        }//LoadRecipe end

        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {//AddRecipeButton begin
            //Open addRecipe window and close the current window
            var addRecipeWindow = new AddRecipe(manageRecipe);
            addRecipeWindow.Show();
            this.Hide();
        }//AddRecipeButton end

        private void btnViewRecipe_Click(object sender, RoutedEventArgs e)
        {//ViewRecipeButton begin
            //Stored the index value for the recipe the user selected
            int selection = lstbxRecipeDisplay.SelectedIndex;

            //if statement for validation if the user did not select a recipe or if there are no recipes to select
            if (selection < 0 || sortedRecipes.Count == 0)
            {//if begin
                //Display message in a message box to alret user that they need to select a recipe
                MessageBox.Show("Please select a recipe to view.");
                return;
            }//if end

            //Open the viewReci[pe window to display the recipe thew user has sleected
            var selectedRecipe = sortedRecipes[selection];
            //Pass the selected recipe to the viewRecipe Window
           // var viewRecipeWindow = new ViewRecipe(selectedRecipe, manageRecipe);
            //Open viewRecipeWindow and close the current window
           // viewRecipeWindow.Show();
            this.Hide();
        }//end ViewRecipeButton

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {//ExitButton begin
            //Display message to let user know that they are exiting the App
            MessageBox.Show("Exiting Application! Thank You for using The Recipe Managament Application");

            //close the window
            this.Close();

            //Exit the application
            Application.Current.Shutdown();
        }//ExitButton end

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {//FilterRecipeButton
            //Open the Filter window passing the manage recipe class as a parameter
           // var filterRecipesWindow = new FilterRecipes(manageRecipe);
           // filterRecipesWindow.Show();
            //close the current window
            this.Hide();
        }//FilterRecipeButton
    }
}
