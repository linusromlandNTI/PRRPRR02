using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        //CONFIG VARIABLES
        private int GridHeight = 5;
        private int GridWidth = 5;
        
        public MainWindow()
        {
            InitializeComponent();
            
            for (int i = 0; i < GridHeight; i++)
            {
                mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < GridWidth; i++)
            {
                mainGrid.RowDefinitions.Add(new RowDefinition());
            }
            
            string[,] buttons = new string[,] {
                {"", "", "", "C" },
                {"7", "8", "9", "/"},
                {"4", "5", "6", "*"},
                {"1", "2", "3", "+"},
                {".", "0", "=", "-"}
            };

        }
    }
}
