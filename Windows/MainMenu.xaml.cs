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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {//mainMenu window begin
        //Variable Declaration
        private ManageRecipe manageRecipe;
        private List<Recipe> sortedRecipes;
        private int selection;
        public MainMenu(ManageRecipe manageRecipe)
        {//mainMenu begin
            InitializeComponent();
            this.manageRecipe = manageRecipe;
            DisplayRecipes();
        }//mainMenu end

        //Method to display recipes in the list box
        private void DisplayRecipes()
        {//DisplayRecipe begin
            //Clear the list box
            lstbxRecipeDisplay.Items.Clear();
            //Store the alphabetically sorted recipes in a variable
            sortedRecipes = manageRecipe.Recipes.OrderBy(r => r.Name).ToList();

            //Validation for no recipes added - if sortedRecipes is null
            if (sortedRecipes.Count == 0)
            {//if begin
                lstbxRecipeDisplay.Items.Add("No recipes available to display.");//display error message in list box
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
        }//DisplayRecipe end

        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {//btnAddRecipe_Click begin
            //Open addRecipe window and close the current window
            var addRecipeWindow = new AddRecipe(manageRecipe);
            addRecipeWindow.Show(); //shows the addRecipe Window
            this.Hide(); //hides window
        }//btnAddRecipe_Click end

        private void btnViewRecipe_Click(object sender, RoutedEventArgs e)
        {//btnViewRecipe_Click begin
            //Stored the index value for the recipe the user selected
            int selection = lstbxRecipeDisplay.SelectedIndex;

            //if statement for validation if the user did not select a recipe or if there are no recipes to select
            if (selection < 0 || sortedRecipes.Count == 0)
            {//if begin
                MessageBox.Show("Please select a recipe to view.");//Display error message in a message box to alret user that they need to select a recipe
                return;
            }//if end

            //Open the viewReci[pe window to display the recipe thew user has sleected
            var selectedRecipe = sortedRecipes[selection];
            //Pass the selected recipe to the viewRecipe Window
           var viewRecipeWindow = new ViewRecipe(selectedRecipe, manageRecipe);
            //Open viewRecipeWindow and close the current window
           viewRecipeWindow.Show(); //shows viewRecipe window
            this.Hide();// hides window
        }//btnViewRecipe_Click end

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {//btnExit_Click begin
            var exitWindow = new Exit();
            //Open  exitWindow and close the current window
            exitWindow.Show(); //shows  exitWindow window
            this.Close();  //close this window
        }//btnExit_Click end

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {//btnFilter_Click begin
         //Open the Filter window passing the manage recipe class as a parameter
            var filterRecipeWindow = new FilterRecipe(manageRecipe);
           filterRecipeWindow.Show();  //shows the filterRecipe window
           
            this.Hide(); //hides current window
        }//btnFilter_Click end
    }//MainMenu Window end
}//namespace end
