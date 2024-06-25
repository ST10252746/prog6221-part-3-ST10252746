/*
 Theshara Narain - ST10252746
 PROG6221
 BCAD GROUP 1
 POE Part 3
 Github Link for Part 1: https://github.com/VCDN-2024/prog6221-part-1-ST10252746.git 
 Github Link for Part 2: https://github.com/VCDN-2024/prog6221-part-2-ST10252746.git 
 Github Link for Part 3: https://github.com/ST10252746/prog6221-part-3-ST10252746.git 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10252746_PROG6221_POE.Models
{//namespace begin
    /*
         *--------------------CODE ATTRIBUTION--------------------
                Author: Fatima Shaik
                Website: https://github.com/fb-shaik/PROG6221-Group1-2024/blob/main/AddressBookApp/Program.cs
                Date: 3 April 2024

                Author: Fatima Shaik 
                Website: https://github.com/fb-shaik/PROG6221-Group1-2024/tree/main/Generics_Library_App
                Date: 3 April 2024

                Author: Fatima Shaik 
                Website: https://github.com/fb-shaik/PROG6221-Group1-2024/tree/main/Collection_Generics_LU3
                Date: 3 April 2024
         *--------------------CODE ATTRIBUTION--------------------

    */
    public class Ingredient
    {// Ingredient class begin
     //attribute variable declaration - with getter and setter methods

        //GETTER AND SETTER METHODS
        public string Name { get; set; } 
        public double Quantity { get; set; }
        public double originalQuantity { get; set; } //Created new value
        public UnitsOfMeasurement originalUnit { get; set; } //Created new value
        public UnitsOfMeasurement Unit { get; set; }  //enum
        public FoodGroup FoodGroup { get; set; } //enum
        public double Calories { get; set; }
        public double originalCalories { get; set; } //Created new value

        // Constructor method for the Ingredient class with parameters
        public Ingredient(string name, double quantity, UnitsOfMeasurement unit, FoodGroup foodGroup, double calories)
        {// constructor begin
            Name = name; // Set the name of the ingredient
            Quantity = quantity; // Set the quantity of the ingredient
            Unit = unit; // Set the unit of measurement of the ingredient
            originalQuantity = quantity; // Store the original quantity for later reference
            originalUnit = unit; // Store the original unit of measurement for later reference
            FoodGroup = foodGroup;  // Set the food group of the ingredient
            this.Calories = calories; // set the calories to the class parameter
            originalCalories = calories; // Store the original calories for later reference


        }// constructor end

        // Method to reset the quantity of the ingredient to its original state
        public void ResetQuantity()
        {//resetQuantity start
            Quantity = originalQuantity; // Restore the quantity to its original value
        }//resetQuantity end

        // Method to reset the unit of measurement of the ingredient to its original state
        public void ResetUnit()
        {//ResetUnit start
            Unit = originalUnit; // Restore the unit of measurement to its original value
        }//ResetUnit end

        //method to calculate scaled calories based on factor selected
        public void CalculateScaledCalories(double factor)
        {//CalculateScaledCalories begin
            Calories = factor * Calories; //Scaled calories is calculated by multiplying the current calorie value by the selected factor
        }// CalculateScaledCalorie end

        //Method to reset calories
        public void ResetCalories()
        {// ResetCalories begin
            this.Calories = originalCalories; //reset calories to the value in the parameters
        }// ResetCalories end

        //Method to diaply the additional information related to the ingredients
        public void DisplayIngredient()
        {// display begin
            Console.WriteLine($"{Quantity} {Unit} of {Name}\nFood Group: {FoodGroup}\n{Calories} Calories: \n");
        }// display end

    }// Ingredient class end
}//namespace end