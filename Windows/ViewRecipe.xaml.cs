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
    /// Interaction logic for ViewRecipe.xaml
    /// </summary>
    public partial class ViewRecipe : Window
    {//viewRecipe window begin
        //Variable Declaration
        private Recipe currentRecipe;
        private ManageRecipe manageRecipe;
        public ViewRecipe(Recipe recipe, ManageRecipe manageRecipe)
        {// ViewRecipe begin
            InitializeComponent(); //initiliaze components defined 
            this.currentRecipe = recipe;
            DisplayRecipeDetails(); //call method to display the recipe details in a richedit
            this.manageRecipe = manageRecipe;
            //set components to hidden visibility until Scale Button is clicked
            txtScale.Visibility = Visibility.Hidden;
            rbHalf.Visibility = Visibility.Hidden;
            rbDouble.Visibility = Visibility.Hidden;
            rbTriple.Visibility = Visibility.Hidden;
            btnScaleProceed.Visibility = Visibility.Hidden;
        }// ViewRecipe end

        //Method to display the recipe information in the richedit box
        private void DisplayRecipeDetails()
        {// DisplayRecipeDetails() begin
            //Display the recipe details in a richedit so that user can mark of the steps and ingredients they completed
            rtbRecipe.Document.Blocks.Clear(); //clear the richedit 
            rtbRecipe.AppendText(currentRecipe.DisplayRecipe()); //call the method from recipe class to display the recipe the user selected
        }// DisplayRecipeDetails() end

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {//btnMainMenu_Click begin
            //open the main menu passing the current manageRecipe class as a parameter
            var MainMenu = new MainMenu(manageRecipe);
            MainMenu.Show();
            //close the current window
            this.Close();
        }//btnMainMenu_Click end

        private void btnScale_Click(object sender, RoutedEventArgs e)
        {//btnScale_Click begin
            //Make the components visible once the scale button is clicked
            txtScale.Visibility = Visibility.Visible;
            rbHalf.Visibility = Visibility.Visible;
            rbDouble.Visibility = Visibility.Visible;
            rbTriple.Visibility = Visibility.Visible;
            btnScaleProceed.Visibility = Visibility.Visible;
        }// btnScale_Click end

        private void btnScaleProceed_Click(object sender, RoutedEventArgs e)
        {//btnScaleProceed_Click begin
            {//ProccedButton begin
             // Variable to store the scaling factor
                double factor = 0;

                // Check which radiobutton is selected and set the factor
                if (rbHalf.IsChecked == true)
                {//if begin
                    factor = 0.5;
                }//if end
                else if (rbDouble.IsChecked == true)
                {//else if begin
                    factor = 2.0;
                }//else if end
                else if (rbTriple.IsChecked == true)
                {//else if begin
                    factor = 3.0;
                }//else if end

                // Validate that a factor has been selected
                if (factor != 0)
                {//if begin

                    // Clear the richedit block
                    rtbRecipe.Document.Blocks.Clear();

                    // Scale the recipe
                    manageRecipe.ScaleRecipe(currentRecipe, factor); //call the method to scale recipe in the manage recipe class
                    rtbRecipe.AppendText(currentRecipe.DisplayRecipe()); //call the method to display the scaled recipe in the rich edit

                    // Hide the Scaling Components once the proceed button is displayed
                    txtScale.Visibility = Visibility.Hidden;
                    rbHalf.Visibility = Visibility.Hidden;
                    rbDouble.Visibility = Visibility.Hidden;
                    rbTriple.Visibility = Visibility.Hidden;
                    btnScaleProceed.Visibility = Visibility.Hidden;
                }//if end
                else
                {//else if the user didn't select a factor to scale
                 // Display the error message
                    MessageBox.Show("Please select a scaling factor.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }//else end
            }//proceedButton end
        }//btnScaleProceed_Click end

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {//btnReset_Click begin
            //call the resetRecipe method to return the recipe ingreients to the orginal values before scaling
            manageRecipe.ResetRecipe(currentRecipe);
            //clear richedit
            rtbRecipe.Document.Blocks.Clear();
            //display the reseted recipe
            rtbRecipe.AppendText(currentRecipe.DisplayRecipe());
        }//btnReset_Click end

        private void btnClearRecipe_Click(object sender, RoutedEventArgs e)
        {//btnClearRecipe_Click begin

            //Get user confirmation to delete the recipe
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this recipe?", "Delete Recipe", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            //if the result is yes then remove recipe
            if (result == MessageBoxResult.Yes)
            {//if begin
                //call the delete recipe method from manageRecipe class, removing the current recipe from the recipe list
                manageRecipe.DeleteRecipe(currentRecipe);
                //open the Main Menu Window by calling the method
                OpenMainMenuWindow();
            }//if end
        }//btnClearRecipe_Click end

        //Method to open the MainMenu Window
        private void OpenMainMenuWindow()
        {//OpenMainMenuWindow begin
            //open the MainMenu window and close the current window
            MainMenu MainMenuWindow = new MainMenu(manageRecipe);
            MainMenuWindow.Show();
            this.Close();
        }//OpenMainMenuWindow end

    }//viewRecipe window end
}//namespace end
