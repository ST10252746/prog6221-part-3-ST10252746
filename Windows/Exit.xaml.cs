/*
 Theshara Narain - ST10252746
 PROG6221
 BCAD 2 GROUP 1
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
    /// Interaction logic for Exit.xaml
    /// </summary>
    public partial class Exit : Window
    {//exit window begin
        public Exit()
        {//exit begin
            InitializeComponent(); //initializes components defined
        }//exit end

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {//btnExit_Click begin
         //Exit the application
            Application.Current.Shutdown();
        }//btnExit_Click end
    }//exit window end
}//namespace end
