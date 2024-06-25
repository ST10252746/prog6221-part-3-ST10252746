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

namespace ST10252746_PROG6221_POE.Windows
{//namespace begin
    /// <summary>
    /// Interaction logic for AddStep.xaml
    /// </summary>
    public partial class AddStep : Window
    {//addStep window begin
        private Recipe recipe;
        private int numSteps;
        private int currentStepIndex = 0; //sets step index to 0
        ManageRecipe manageRecipe;
        public AddStep(Recipe recipe, int numSteps, ManageRecipe manageRecipe)
        {//add step method begin
            InitializeComponent(); // Initializes the components 
            this.recipe = recipe; // Assigns the provided Recipe instance to the class field
            this.numSteps = numSteps; // Assigns the number of steps to the class field
            UpdateHeading(); // Updates the heading to reflect the current step count
            this.manageRecipe = manageRecipe; // Assigns the provided ManageRecipe instance to the class field
        }//add step method end

        private void btnAddStep_Click(object sender, RoutedEventArgs e)
        {//btnAddStep_Click begin
            string description = txtStep.Text; // Retrieve the text entered in the txtStep textbox
            if (string.IsNullOrWhiteSpace(description)) // Check if the description is null, empty, or contains only whitespace
            {//if begin 
                MessageBox.Show("Step description cannot be empty."); // Show error message if step description is empty
                return;
            }//if end

            recipe.Steps.Add(new Step { Description = description }); // Add the step to the recipe

            currentStepIndex++; // Increment the current step index

            if (currentStepIndex < numSteps) // Check if there are remaining steps to be added (if the current number of steps are less than the steps added in by the user)
            {//if begin
                MessageBox.Show("Step added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);// Show steps added success message
                ResetTextBox(); //calls methods to resettextbox
                UpdateHeading();//calls methods to updateheading
            }//if end
            else
            {//else begin
                MessageBox.Show("All steps added successfully! Recipe added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information); // Show final success message
                var MainMenuWindow = new MainMenu(manageRecipe); // Creates a new instance of the MainMenu window, passing the manageRecipe instance
                MainMenuWindow.Show(); //open mainMenu window

              this.Close(); //closes current window
            }//else end
        }//btnAddStep_Click end

         //Method to reset the textbox
        private void ResetTextBox()
        {//ResetHeading begin
            txtStep.Text = ""; //clears the textbox of any input by the user
        }//ResetHeading end

        //Method to update the heading based on the number of steps
        private void UpdateHeading()
        {//UpdateHeading begin
            lblHeading.Content = $"Add Step {currentStepIndex + 1} of {numSteps}"; // Updates the heading label to display the current step number out of the total number of steps
        }//UpdateHeading end
    }//addStep Window end
}//namespace end
