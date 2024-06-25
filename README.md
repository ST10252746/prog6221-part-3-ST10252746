# README FILE: ST10252746: Theshara Narain
# Recipe Management Windows Presentation Foundation application
# Portfolio of Evidence: Windows Presentation Foundation application

## Table of Contents:
1. [Description](#1-description)
2. [Installation](#2-installation)
3. [Usage](#3-usage)
4. [Changes/Updates based on feedback](#4-changesupdates-based-on-feedback)
5. [Features implemented in POE](#5-features-implemented-in-poe)
6. [Contact](#6-contact)


## 1. Description
With the use of windows/buttons/listboxes/comboboxes/textblocks/richEdits
This WPF application will allow for the user to enter the ingredients, as well as the steps for an UNLIMITED amount of recipe. 
The user will be prompted to enter the name of the recipe, the number of ingredients in the recipe and the number of steps in the recipe, 
for each recipe the user enters. The user will then have to input the name, quantity, unit of measurement, number of calories and food group for each ingredient which will be stored in memory using a generic list, storing ingredient objects. 
The same will be done for each step in the recipe, storing each string step in a generic list. The application will receive user input about various recipes, store it in memory using generic collections, and then allow to the user to select a recipe from a list of recipes to display.
The application will implement unique features to allow the user to scale the selected recipe by a desired factor (0.5, 2 or 3). The user will be able to select the option to display either half the recipe, double the recipe, triple the recipe or to show the original recipe. 
The application also allows for the unit of measurement for each ingredient entered by the user, to scale along with the quantities. 
The application is able to calculate and display the total number of calories in a recipe to the user. 
The application displays a unique message to the user depending on the number of calories in the recipe and offers an explanation for this range 
of calories. The application is also able to display an ALERT message to the user once the given recipe has exceeded 300 total calories. 
The application allows the user to exit the application. The user shall be able to filter the list of recipes by: entering the name of an ingredient that must be in the recipe, choosing a food group (combo box) that must be in the recipe, or selecting a maximum number of calories


Features:
•	Allows users to enter details for an unlimited amount of recipes, including ingredients(units of measurements, food group, calories, quantities) and steps (amount and description).
•	Displays the full recipe in a neat format.
•	Supports scaling of recipe quantities by a factor of 0.5, 2, or 3.
•	Enables resetting ingredient quantities to their original values.
•	Provides an option to clear recipe data.
•	Does not persist user data between runs; data is stored in memory only.

Provides an option to display a list of all recipes in alphabetical order by name
Users can choose which recipe to display from the list using a search option.
Calculates and displays the total calories of all ingredients in a recipe.
Notifies the user when the total calories of a recipe exceed 300 and provides explanations specific to certain ranges of total calories.
The user shall be able to filter the list of recipes by:
- a. entering the name of an ingredient that must be in the recipe,
- b. choosing a food group (combo box) that must be in the recipe, or
- c. selecting a maximum number of calories


## 2. Installation
1. Download the zip folder containing the C# code from VCLearn or GitHub.
2. Unzip the folder and add it to the directory containing your Visual Studio projects (typically found in This PC > Windows (C:) > Users > [Your Username] > source >repos).
3. Open Visual Studio, select "Open Project," and navigate to the Recipe Application (ST10252746_PROG6221_POE_PART_3) folder to open it.
4. Once this is working and you have access to the code, select the build button (the green play button) in visual studio to run the application.


## 3. Usage
-With the use of windows/buttons/listboxes/comboboxes/textblocks/richEdits
1. When the application starts, enter the name of the recipe.
2. Input the number of ingredients and provide details (name, quantity, unit, calories, food group) for each ingredient.
3. Enter the number of steps in the recipe and input each step description.
4. After input, the recipe with ingredients, steps will be displayed neatly and total calories with the appropriate message regarding calories will display.
5. A menu will appear, offering options:
Menu 1-
   - Add Recipe: add new recipe (unlimited)
   - Display all Recipes: will display recipes in alphabetical order
   - Exit
If Display Recipe is selected another menu will appear
To select a recipe from the menu or to return to the main menu if then a specific recipe is chosen another menu will appear:
   - Display Recipe: will display recipes in alphabetical order
   - Scale Recipe: Scale ingredient quantities/unit measurements (e.g., half, double, triple)
   - Reset Recipe: Reverse the scaling to display original ingredient quantities/unit measurements
   - Clear Recipe: Clear the current recipe
   - Add Recipe: add new recipe (unlimited)
   - Display all Recipes: will display recipes in alphabetical order
   - Filter Recipes: filter the list of recipes by either entering the name of an ingredient that must be in the recipe, choosing a food group (combo box) that must be in the recipe, or selecting a maximum number of                         calories
   - Return to main menu: Goes back to the previous window menu
6. Users can access these functions multiple times before exiting by selecting the respective option exit button.


## 4. Changes/Updates based on feedback:
I received 100% for part 2 and therefore received no feedback.

## 5. Features implemented in Part 3:
Several features have been added to the application and implemented in Part 3 of the POE. 
- Features including different windows for the flow of events/functions of the app.
- Features such as the use of buttons for user input and user selection.
- Features such as the use of comboboxes and listboxes for user selection.
- Features such as the use of richedit boxes for the display of information.

The following features added:
1. The user shall be able to filter the list of recipes by:
- a. entering the name of an ingredient that must be in the recipe,
- b. choosing a food group (combo box) that must be in the recipe, or
- c. selecting a maximum number of calories

- This makes the app smoother to use and decreases the chance of input errors.

## 6. Contact
- **Theshara Narain**
- **Email:** ST102527465@vcconnect.edu.za
- **GitHub Repo Link:** [GitHub Repository](https://github.com/ST10252746/prog6221-part-3-ST10252746.git)
