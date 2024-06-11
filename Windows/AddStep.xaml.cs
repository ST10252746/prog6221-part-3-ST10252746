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
    /// Interaction logic for AddStep.xaml
    /// </summary>
    public partial class AddStep : Window
    {
        private Recipe recipe;
        private int numSteps;
        private int currentStepIndex = 0;
        ManageRecipe manageRecipe;
        public AddStep(Recipe recipe, int numSteps, ManageRecipe manageRecipe)
        {
            InitializeComponent();
            this.recipe = recipe;
            this.numSteps = numSteps;
            UpdateHeading();
            this.manageRecipe = manageRecipe;
        }

        private void btnAddStep_Click_1(object sender, RoutedEventArgs e)
        {
            string description = txtStep.Text;
            if (string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Step description cannot be empty.");
                return;
            }

            recipe.Steps.Add(new Step { Description = description });

            currentStepIndex++;

            if (currentStepIndex < numSteps)
            {
                MessageBox.Show("Step added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ResetFields();
                UpdateHeading();
            }
            else
            {
                MessageBox.Show("All steps added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();

                MessageBox.Show("Recipe added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

              //  var displayRecipes = new DisplayRecipes(manageRecipe);
             //   displayRecipes.Show();
            }
        }

        private void ResetFields()
        {
            txtStep.Text = "";
        }

        private void UpdateHeading()
        {
            lblHeading.Content = $"Add Step {currentStepIndex + 1} of {numSteps}";
        }
    }
}
