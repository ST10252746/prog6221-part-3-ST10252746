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
using System.Windows;

namespace ST10252746_PROG6221_POE.Windows
{//namespace begin
    /// <summary>
    /// Interaction logic for FilterRecipe.xaml
    /// </summary>
    public partial class FilterRecipe : Window
    {//FilterRecipe window begin
        //Variable Declaration
        private int filter; //variable to hold the value of which catergory to filter by
        private ManageRecipe manageRecipe;
        private List<Recipe> recipes;
        private List<Recipe> filteredRecipes; // New member variable to store filtered recipes
        //List to hold the FoodGroup Values
        private List<FoodGroup> groups = new List<FoodGroup>();
        public FilterRecipe(ManageRecipe manageRecipe)
        {//FilterRecipe begin
            InitializeComponent(); // Initializes the components 
            this.manageRecipe = manageRecipe; // Assigns the provided ManageRecipe instance to the class field
            this.recipes = manageRecipe.Recipes; // Assigns the recipes to the class field
            PopulateFoodGroupComboBox(); //method to populate food group comnobox with values from the enum
        }//FilterRecipe end

        //Method to populate foodgroup combobox with the enum values
        private void PopulateFoodGroupComboBox()
        {//PopulateFoodGroupComboBox begin
            groups = Enum.GetValues(typeof(FoodGroup)).Cast<FoodGroup>().ToList();
            foreach (var group in groups)
            {//foreach begin
                cmbFoodGroup.Items.Add(group.ToString());
            }//foreach end
        }//PopulateFoodGroupComboBoxend

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {//btnMainMenu_Click begin
            //open AllRecipesWindow and close the current window
            var MainMenuWindow = new MainMenu(manageRecipe);
            MainMenuWindow.Show(); //shows main menu window
            this.Close(); //closes current window
        }//btnMainMenu_Clickend

        //Method to hide the components to get user input for filter options
        private void HideFilterOptions()
        {//HideFilterOption begin
            txtIngredientName.Visibility = Visibility.Hidden;
            cmbFoodGroup.Visibility = Visibility.Hidden;
            txtNumberCalories.Visibility = Visibility.Hidden;
        }//HideFilterOption end


        //Method to display the recipes in a filtered list
        private void DisplayRecipes(List<Recipe> filteredRecipes)
        {//DisplayRecipes begin

            //Clear listbox
            lstbxFilter.Items.Clear();

            //if statement to validate if there are no recipes found 
            if (filteredRecipes.Count == 0)
            {//if there are no results for filter begin
                lstbxFilter.Items.Add("No recipes found."); //display error message in listbox
            }//if there are no results for filter end
            else
            {//else if there are no results for filter begin
                foreach (var recipe in filteredRecipes)
                {//for each to display all recipes in the recipe list begin
                    lstbxFilter.Items.Add($"{recipe.Name}\n{recipe.CalculateTotalCalories()} total calories");
                }//for each end
            }//else if there are no results for filter end
        }//DisplayRecipes end

        //Method to take in the ingredient name entered by user as a parameter and search through the recipes
        private void IngredientNameFilter(string ingredientName)
        {//IngredientNameFilter begin
         //Using the lambda expression to find if the recipe contains the name of the ingredient user entered display the filtered list of recipes
            filteredRecipes = recipes
       .Where(r => r.Ingredients.Any(i => i.Name.IndexOf(ingredientName, StringComparison.OrdinalIgnoreCase) >= 0))
       .ToList();
            DisplayRecipes(filteredRecipes);
        }//IngredientNameFilter end

        //Method to take in the food group selected by user as a parameter and search through the recipes
        private void FoodGroupFilter(FoodGroup selectedGroup)
        {// FoodGroupFilter begin
         //Using the lambda expression to find if the recipe contains the food group of the ingredient user entered display the filtered list of recipes
            filteredRecipes = recipes
      .Where(r => r.Ingredients.Any(i => i.FoodGroup == selectedGroup))
      .ToList();
            DisplayRecipes(filteredRecipes);
        }// FoodGroupFilter end

        //Method to take in the number of calories entered by user as a parameter and search through the recipes
        private void NumberCaloriesFilter(double maxCalories)
        {//NumberCaloriesFilter begin
         //Using the lambda expression to find if the recipe contains the max calories of the ingredient user entered display the filtered list of recipes
            filteredRecipes = recipes
               .Where(r => r.CalculateTotalCalories() <= maxCalories)
               .ToList();
            DisplayRecipes(filteredRecipes); //calls method to display method based on filteredRecipes parameters
        }//NumberCaloriesFilter end

        private void btnViewRecipe_Click(object sender, RoutedEventArgs e)
        {//btnViewRecipe_Click begin
            int selectedIndex = lstbxFilter.SelectedIndex;

            // Check if there are any recipes in the ListBox
            if (lstbxFilter.Items.Count == 0 || (lstbxFilter.Items.Count > 0 && lstbxFilter.Items[0].ToString() == "No recipes found."))
            {//if begin
                // Display a message if no recipes are found
                MessageBox.Show("No recipes found to view. Please apply a different filter or add recipes.");   //Display error message in messagebox
                return;
            }//if end

            //if statement to valid if the user selected a recipe to view
            if (selectedIndex >= 0)
            {//if begin
                // Get the selected recipe from the filtered list
                var selectedRecipe = filteredRecipes[selectedIndex];

                if (selectedRecipe != null)
                {//if begin
                    // Open ViewRecipeWindow and close the current window
                    var viewRecipeWindow = new ViewRecipe(selectedRecipe, manageRecipe);
                    viewRecipeWindow.Show(); //shows viewRecipe window
                    this.Hide(); //hides current window
                }//if end
                else
                {//else begin
                    // Display error message if the recipe is not found in the filtered list
                    MessageBox.Show("Selected recipe not found in the filtered list.");   //Display error message in messagebox
                }//else end
            }//if end
            else
            {//else begin
                MessageBox.Show("Please select a recipe to view.");    //Display error message in messagebox
            }//else end
        }//btnViewRecipe_Click end

        private void btnIngredientName_Click(object sender, RoutedEventArgs e)
        {//btnIngredientName_Click begin
            HideFilterOptions();//calls method to hide the filter options once the button is clicked
            txtIngredientName.Visibility = Visibility.Visible;   //the txtIngredientName is made visiable
            filter = 1; //sets filter to value
        }//btnIngredientName_Click end

        private void btnFoodGroup_Click(object sender, RoutedEventArgs e)
        {//btnFoodGroup_Click begin
            HideFilterOptions(); //calls method to hide the filter options once the button is clicked
            cmbFoodGroup.Visibility = Visibility.Visible; //the cmbFoodGroup is made visiable
            filter = 2;  //sets filter to value
        }//btnFoodGroup_Click end

        private void btnCalories_Click(object sender, RoutedEventArgs e)
        {// btnCalories_Click begin
            HideFilterOptions(); //calls method to hide the filter options once the button is clicked
            txtNumberCalories.Visibility = Visibility.Visible; //the txtNumberCalories is made visiable
            filter = 3; //sets filter to value
        }// btnCalories_Click end

        private void btnApplyFilter_Click(object sender, RoutedEventArgs e)
        {// btnApplyFilter_Click begin
            lstbxFilter.Items.Clear(); //clears listbox of items
            //use the filter value in a switch case to decide on what catergory  to filter the recipes
            switch (filter)
            {//switch begin
                case 1:
                    string ingredientName = txtIngredientName.Text; //sets user input to variable 
                    IngredientNameFilter(ingredientName); // Calls   IngredientNameFilter method with the parsed ingredientName value as an argument
                    break;
                case 2:
                    int selectedIndex = cmbFoodGroup.SelectedIndex;
                    if (selectedIndex >= 0)
                    {//if begin
                        FoodGroup selectedGroup = groups[selectedIndex];
                        FoodGroupFilter(selectedGroup); // Calls theFoodGroupFilter method with the parsed selectedGroup value as an argument
                    }//if end
                    break;
                case 3:
                    if (double.TryParse(txtNumberCalories.Text, out double maxCalories)) //checks if the text in txtNumberCalories can be parsed to a double (maxCalories)
                    {//if begin
                        NumberCaloriesFilter(maxCalories); // Calls the NumberCaloriesFilter method with the parsed maxCalories value as an argument
                    }//if end
                    else
                    {//else begin
                        MessageBox.Show("Please enter a valid number for calories."); //message to display in message box
                    }//else end
                    break;
                default:
                    MessageBox.Show("Please select a filter criteria."); //message to display in message box
                    break;
            }//switch end
        }// btnApplyFilter_Click end
    }//FilterRecipe window end
}//namespace end
