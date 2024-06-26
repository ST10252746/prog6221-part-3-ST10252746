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
using ST10252746_PROG6221_POE.Windows;
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
using System.Windows.Navigation;
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

namespace ST10252746_PROG6221_POE
{//namespace begin
    /// <summary>
    /// Interaction logic for WelcomeWindow.xaml
    /// </summary>
    /// 
    public partial class Welcome : Window
    {//welcome window begin
        private ManageRecipe manageRecipes; //Instance of the ManageRecipe class to handle recipe management tasks

        public Welcome()
        {//welcome begin
            InitializeComponent(); // Initializes the components 
            this.manageRecipes = new ManageRecipe(); // Creates a new instance of the ManageRecipe class
           
        }//welcome end
        public Welcome(ManageRecipe manageRecipes)
        {//welcome begin
            InitializeComponent();
            this.manageRecipes = manageRecipes; // Assigns the provided ManageRecipe instance to the class field
        }////welcome end

        private void btnWelcome_Click(object sender, RoutedEventArgs e)
        {//btnWelcome_Click
            AddRecipe addRecipeWindow = new AddRecipe(manageRecipes); // Creates a new instance of the AddRecipe window, passing the manageRecipes instance
            addRecipeWindow.Show(); //shows new window
            this.Close(); //closes current window
        }//btnWelcome_Click end

        private void txtHeading_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }//welcome window end
}//namespace end
