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
    /// Interaction logic for AddRecipe.xaml
    /// </summary>
    public partial class AddRecipe : Window
    {
        private ManageRecipe manageRecipes;

        public AddRecipe(ManageRecipe manageRecipes)
        {
            InitializeComponent();
            this.manageRecipes = manageRecipes;
        }

        private void txt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = txtRecipeName.Text;
            if (string.IsNullOrEmpty(recipeName))
            {
                MessageBox.Show("Please enter Recipe name, recipe name cannot be empty.");
                return;
            }

            if (!int.TryParse(txtNumberIngredients.Text, out int numIngredients) || numIngredients <= 0)
            {
                MessageBox.Show("Please enter a valid number of ingredients.");
                return;
            }

            if (!int.TryParse(txtNumberSteps.Text, out int numSteps) || numSteps <= 0)
            {
                MessageBox.Show("Please enter a valid number of steps.");
                return;
            }

            // Create the recipe object
            Recipe recipe = new Recipe(recipeName, numIngredients, numSteps);
            var addIngredientWindow = new AddIngredient(recipe, numIngredients, manageRecipes);
            addIngredientWindow.Show();
            this.Close();

            //var addStepWindow = new AddStep
            //(recipe, numSteps);
            //addStepWindow.Show();

            manageRecipes.AddRecipe(recipe);



            // Reset the fields for the next recipe
            txtRecipeName.Clear();
           txtNumberIngredients.Clear();
           txtNumberSteps.Clear();
        }
    }
}
