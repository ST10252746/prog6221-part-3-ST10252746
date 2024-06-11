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
    /// Interaction logic for AddIngredient.xaml
    /// </summary>
    public partial class AddIngredient : Window
    {
        private Recipe recipe;
        ManageRecipe manageRecipe;

        List<UnitsOfMeasurement> units = new List<UnitsOfMeasurement>();
        // list to store units in enum
        List<FoodGroup> groups = new List<FoodGroup>();
        // list to store food groups in enum

        private int numIngredients;
        private int currentIngredientIndex = 0;

        public AddIngredient(Recipe recipe, int numIngredients, ManageRecipe manageRecipe)
        {
            InitializeComponent();
            this.recipe = recipe;
            this.numIngredients = numIngredients;
            UpdateHeading();
            PopulateComboBoxes();
            this.manageRecipe = manageRecipe;

        }

        private void PopulateComboBoxes()
        {
            units.Add(UnitsOfMeasurement.SMALL);
            units.Add(UnitsOfMeasurement.MEDIUM);
            units.Add(UnitsOfMeasurement.LARGE);
            units.Add(UnitsOfMeasurement.EXTRALARGE);
            units.Add(UnitsOfMeasurement.TEASPOON);
            units.Add(UnitsOfMeasurement.TEASPOONS);
            units.Add(UnitsOfMeasurement.TABLESPOON);
            units.Add(UnitsOfMeasurement.TABLESPOONS);
            units.Add(UnitsOfMeasurement.CUP);
            units.Add(UnitsOfMeasurement.CUPS);
            // add all enum values to units list

            for (int i = 0; i < units.Count(); i++)
            {
               cmbUnit.Items.Add(units[i]);
            }// add all enum values from the list to the correct combo box

            groups.Add(FoodGroup.CARBOHYDRATE);
            groups.Add(FoodGroup.PROTEIN);
            groups.Add(FoodGroup.FAT);
            groups.Add(FoodGroup.FRUIT);
            groups.Add(FoodGroup.VEGETABLE);
            groups.Add(FoodGroup.DAIRY);
            // add all enum values to groups list

            for (int i = 0; i < groups.Count(); i++)
            {
                cmbFoodGroup.Items.Add(groups[i]);
            }// add all enum values from list to the correct combo box
        }

        private void btnAddIngredient_Click(object sender, RoutedEventArgs e)
        {
            string name = txtIngredientName.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Ingredient name cannot be empty.");
                return;
            }

            if (!double.TryParse(txtQuantity.Text, out double quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity.");
                return;
            }

            if (!double.TryParse(txtCalories.Text, out double calories) || calories < 0)
            {
                MessageBox.Show("Please enter a valid number of calories.");
                return;
            }

            if (!Enum.TryParse<UnitsOfMeasurement>(cmbUnit.SelectedItem?.ToString(), out UnitsOfMeasurement unit))
            {
                MessageBox.Show("Please select a unit of measurement.");
                return;
            }

            if (!Enum.TryParse<FoodGroup>(cmbFoodGroup.SelectedItem?.ToString(), out FoodGroup group))
            {
                MessageBox.Show("Please select a food group.");
                return;
            }

            recipe.Ingredients.Add(new Ingredient(name, quantity, unit, group, calories));

            currentIngredientIndex++;

            if (currentIngredientIndex < numIngredients)
            {
                MessageBox.Show("Ingredient added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ResetFields();
                UpdateHeading();
            }
            else
            {
                MessageBox.Show("All ingredients added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                this.Close();

                // Open the AddStep window
                var addStepWindow = new AddStep(recipe, recipe.NumSteps, manageRecipe);
                addStepWindow.Show();
            }

            recipe.CalculateTotalCalories();
        }

        private void ResetFields()
        {
            txtIngredientName.Clear();
            txtQuantity.Clear();
            txtCalories.Clear();
           cmbUnit.SelectedIndex = -1;
            cmbFoodGroup.SelectedIndex = -1;
        }

        private void UpdateHeading()
        {
            lblHeading.Content = $"Add Ingredient {currentIngredientIndex + 1} of {numIngredients}";
        }

    }
}
