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
    /// Interaction logic for AddRecipe.xaml
    /// </summary>
    public partial class AddRecipe : Window
    {//AddRecipe window begin
        private ManageRecipe manageRecipes; // Declares private field to hold an instance of the ManageRecipe class

        public AddRecipe(ManageRecipe manageRecipes)
        {//AddRecipe begin
            InitializeComponent(); // Initializes the components 
            this.manageRecipes = manageRecipes; // Assigns the provided ManageRecipes instance to the class field 
        }//AddRecipe end

        private void btnAddRecipe_Click_1(object sender, RoutedEventArgs e)
        {//btnAddRecipe_Click_1 begin
            string recipeName = txtRecipeName.Text; //assign user input to variable
            if (string.IsNullOrEmpty(recipeName)) //(if) recipe name entered by user is empty
            {//if begin
                MessageBox.Show("Please enter Recipe name, recipe name cannot be empty."); //error message display in messagebox
                return;
            }//if end

            if (!int.TryParse(txtNumberIngredients.Text, out int numIngredients) || numIngredients <= 0) // (if) checks if the text in txtNumberIngredients can be parsed to an integer (numIngredients) and if numIngredients is less than or equal to 0
            {//if begin
                MessageBox.Show("Please enter a valid number of ingredients."); //error message display in messagebox
                return;
            }//if end

            if (!int.TryParse(txtNumberSteps.Text, out int numSteps) || numSteps <= 0) // (if) checks if the text in txtNumberSteps can be parsed to an integer (numSteps) and if numSteps is less than or equal to 0
            {//if begin
                MessageBox.Show("Please enter a valid number of steps.");//error message display in messagebox
                return;
            }//if end

            // Create the recipe object
            Recipe recipe = new Recipe(recipeName, numIngredients, numSteps);
            var addIngredientWindow = new AddIngredient(recipe, numIngredients, manageRecipes);
            addIngredientWindow.Show(); //opens addIngredient window
            this.Close(); //closes current window

            manageRecipes.AddRecipe(recipe); // Calls the AddRecipe method of the manageRecipes instance to add the recipe object

            // Clears the fields for the next recipe
            txtRecipeName.Clear(); //clears recipe name
            txtNumberIngredients.Clear(); //clears number of ingredients
            txtNumberSteps.Clear(); //clears number of steps
        }//btnAddRecipe_Click_1 end
    }//addRecipe window end
}//namespace end
