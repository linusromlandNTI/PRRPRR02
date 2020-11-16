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
        private int GridWidth = 4;
        
        public MainWindow()
        {
            InitializeComponent();
            
            for (int i = 0; i < GridWidth; i++)
            {
                mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < GridHeight; i++)
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
            
            for (int i = 0; i < buttons.GetLength(0); i++)
            {
                for (int j = 0; j < buttons.GetLength(1); j++)
                {
                    if (buttons[i, j] == "") continue;
                    Button tmp = new Button();
                    tmp.SetValue(Grid.ColumnProperty, j);
                    tmp.SetValue(Grid.RowProperty, i);
                    tmp.SetValue(ContentProperty, buttons[i,j]);
                    mainGrid.Children.Add(tmp);
                }
            }
        }
    }
}
