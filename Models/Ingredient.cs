using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10252746_PROG6221_POE.Models
{
    public class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public double originalQuantity { get; set; }
        public UnitsOfMeasurement originalUnit { get; set; }
        public UnitsOfMeasurement Unit { get; set; }
        public FoodGroup FoodGroup { get; set; }
        public double Calories { get; set; }
        public double originalCalories { get; set; }

        public Ingredient(string name, double quantity, UnitsOfMeasurement unit, FoodGroup foodGroup, double calories)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            originalQuantity = quantity;
            originalUnit = unit;
            FoodGroup = foodGroup;
            this.Calories = calories;
            originalCalories = calories;
        }

        public void ResetQuantity()
        {
            Quantity = originalQuantity;
        }

        public void ResetUnit()
        {
            Unit = originalUnit;
        }

        public void CalculateScaledCalories(double factor)
        {
            Calories = factor * Calories;
        }

        public void ResetCalories()
        {
            this.Calories = originalCalories;
        }

        public void DisplayIngredient()
        {
            Console.WriteLine($"{Quantity} {Unit} of {Name}\nFood Group: {FoodGroup}\n{Calories} Calories: \n");
        }
    }
}
