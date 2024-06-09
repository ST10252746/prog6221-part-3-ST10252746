﻿using ST10252746_PROG6221_POE.Models;
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

namespace ST10252746_PROG6221_POE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ManageRecipe manageRecipes;
        public MainWindow()
        {
            InitializeComponent();
            this.manageRecipes = new ManageRecipe(); // initialize ManageRecipe instance here
        }
        public MainWindow(ManageRecipe manageRecipes)
        {
            InitializeComponent();
            this.manageRecipes = manageRecipes;
        }

        private void btnMain_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
