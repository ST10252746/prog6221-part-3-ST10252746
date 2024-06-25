/*
 Theshara Narain - ST10252746
 PROG6221
 BCAD 2 GROUP 1
 POE Part 3
 Github Link for Part 1: https://github.com/VCDN-2024/prog6221-part-1-ST10252746.git 
 Github Link for Part 2: https://github.com/VCDN-2024/prog6221-part-2-ST10252746.git 
Github Link for Part 3: https://github.com/ST10252746/prog6221-part-3-ST10252746.git 
 */

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
/*
 *--------------------CODE ATTRIBUTION--------------------
        Author: Fatima Shaik
        Website: https://github.com/fb-shaik/PROG6221-Group1-2024/blob/main/WpfVending.zip
        Date: 10 June 2024

        Author: Fatima Shaik 
        Website: https://github.com/fb-shaik/PROG6221-Group1-2024/blob/main/PassingData_WPF.rar
        Date: 10 June 2024

        Author: Fatima Shaik 
        Website: https://github.com/fb-shaik/PROG6221-Group1-2024/blob/main/MyFirstWPF_Build.rar
        Date: 10 June 2024

        Author: Fatima Shaik 
        Website: https://github.com/fb-shaik/PROG6221-Group1-2024/blob/main/InventoryTacking_App.rar
        Date: 10 June 2024

        Author: Fatima Shaik 
        Website: https://github.com/fb-shaik/PROG6221-Group1-2024/blob/main/DonationsWPF-master.zip
        Date: 10 June 2024

        Author: Fatima Shaik 
        Website: https://github.com/fb-shaik/PROG6221-Group1-2024/blob/main/CoffeeShop-WPF.rar
        Date: 10 June 2024

        Author: Fatima Shaik 
        Website: https://github.com/fb-shaik/PROG6221-Group1-2024/blob/main/Calculator_Stack_Grid_WPF.rar
        Date: 10 June 2024
 *--------------------CODE ATTRIBUTION--------------------
 */
namespace ST10252746_PROG6221_POE.Windows
{//namespace begin
    /// <summary>
    /// Interaction logic for AddIngredient.xaml
    /// </summary>
    public partial class AddIngredient : Window
    {//addIngredient window begin
        private Recipe recipe;
        ManageRecipe manageRecipe;

        List<UnitsOfMeasurement> units = new List<UnitsOfMeasurement>();
        // list to store units in enum
        List<FoodGroup> groups = new List<FoodGroup>();
        // list to store food groups in enum

        private int numIngredients;
        private int currentIngredientIndex = 0;

        public AddIngredient(Recipe recipe, int numIngredients, ManageRecipe manageRecipe)
        {//addIngredient begin
            InitializeComponent(); // Initializes the components
            this.recipe = recipe; // Assigns the provided Recipe instance to the class field
            this.numIngredients = numIngredients; // Assigns the number of ingredients to the class field
            UpdateHeading(); // Updates the heading to reflect the current ingredient count
            PopulateComboBoxes(); // Populates combo boxes with predefined units and food groups
            this.manageRecipe = manageRecipe;  // Assigns the provided ManageRecipe instance to the class field

        }//addIngredient end

        //Method to populate comboboxes
        private void PopulateComboBoxes()
        {//PopulateComboBoxes method begin
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

            // Adds each unit from the 'units' list to the cmbUnit combo box
            for (int i = 0; i < units.Count(); i++)
            {//for begin
               cmbUnit.Items.Add(units[i]);
            }//for end
            // add all enum values from the list to the correct combo box

            groups.Add(FoodGroup.CARBOHYDRATE);
            groups.Add(FoodGroup.PROTEIN);
            groups.Add(FoodGroup.FAT);
            groups.Add(FoodGroup.OIL);
            groups.Add(FoodGroup.FRUIT);
            groups.Add(FoodGroup.VEGETABLE);
            groups.Add(FoodGroup.DAIRY);
            groups.Add(FoodGroup.WATER);
            // add all enum values to groups list

             // Adds each food group from the 'food group' list to the cmbFoodGroup combo box
            for (int i = 0; i < groups.Count(); i++)
            {//for begin
                cmbFoodGroup.Items.Add(groups[i]);
            }//for end
            // add all enum values from list to the correct combo box
        }//PopulateComboBoxes method end

        private void btnAddIngredient_Click(object sender, RoutedEventArgs e)
        {//btnAddIngredient_Click begin
            string name = txtIngredientName.Text; //checks if user input empty/unselected
            if (string.IsNullOrWhiteSpace(name)) //checks if there is user input or empty
            {//ig begin
                MessageBox.Show("Ingredient name cannot be empty."); //error message displayed
                return;
            }//if end

            if (!double.TryParse(txtQuantity.Text, out double quantity) || quantity <= 0) //checks if user input empty/unselected
            {//if begin
                MessageBox.Show("Please enter a valid quantity.");//error message displayed
                return;
            }//if end

            if (!double.TryParse(txtCalories.Text, out double calories) || calories < 0)   //checks if user input empty/unselected
            {//if begin
                MessageBox.Show("Please enter a valid number of calories.");//error message displayed
                return;
            }//if end

            if (!Enum.TryParse<UnitsOfMeasurement>(cmbUnit.SelectedItem?.ToString(), out UnitsOfMeasurement unit))   //checks if user input empty/unselected
            {//if begin
                MessageBox.Show("Please select a unit of measurement.");//error message displayed
                return;
            }//if end

            if (!Enum.TryParse<FoodGroup>(cmbFoodGroup.SelectedItem?.ToString(), out FoodGroup group))  //checks if user input empty/unselected
            {//if begin
                MessageBox.Show("Please select a food group."); //error message displayed
                return;
            }//if end

            recipe.Ingredients.Add(new Ingredient(name, quantity, unit, group, calories)); // Add the ingredient to the recipe

            currentIngredientIndex++; // Increment the current ingredient index

            if (currentIngredientIndex < numIngredients) // Check if there are remaining ingredients to be added (if the current number of ingredients are less than the ingredients added in by the user)
            {//if begin
                MessageBox.Show("Ingredient added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information); //success messagebox displayed for specific ingredient
                ResetFields(); //resets heading text
                UpdateHeading();//updates heading text
               
            }//if end
            else
            {//else begin
                MessageBox.Show("All ingredients added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information); //success messagebox displayed for all ingredients

                // creates a new instance of the AddStep window, passing the recipe, number of steps, and manageRecipe instance
                var addStepWindow = new AddStep(recipe, recipe.NumSteps, manageRecipe);
                addStepWindow.Show(); //shows addStep window

                this.Close(); //closes current window
            }//else end

            recipe.CalculateTotalCalories(); // calculates the total calories of the recipe after adding ingredients
        }//btnAddIngredient_Click end

        //Method to reset fields for user input
        private void ResetFields()
        {//ResetFields method begin
            txtIngredientName.Clear();
            txtQuantity.Clear();
            txtCalories.Clear();
           cmbUnit.SelectedIndex = -1;
            cmbFoodGroup.SelectedIndex = -1;
        }//ResetFields method end

        //Method to update the heading text
        private void UpdateHeading()
        {//UpdateHeading method begin
            lblHeading.Content = $"Add Ingredient {currentIngredientIndex + 1} of {numIngredients}"; // Updates the heading label to display the current ingredient number out of the total number of ingredients
        }//UpdateHeading method end

    }//addIngredient window end
}//namespace end
