using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        //CONFIG VARIABLES
        private int GridHeight = 5;
        private int GridWidth = 4;

        private TextBlock display;
        public MainWindow()
        {
            InitializeComponent();
            
            display = new TextBlock
            {
                FontSize = 50,
                TextAlignment = TextAlignment.Right,
                HorizontalAlignment = HorizontalAlignment.Right
            };

            display.Background = Brushes.White;
            mainGrid.Children.Add(display);
            display.SetValue(Grid.RowProperty, 0);
            display.SetValue(Grid.ColumnProperty, 0);
            display.SetValue(Grid.ColumnSpanProperty, 3);
            
            
            
            for (int i = 0; i < GridWidth; i++)
            {
                mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < GridHeight; i++)
            {
                mainGrid.RowDefinitions.Add(new RowDefinition());
            }
            
            string[,] buttons = new string[,] {
                {"", "", "", "*" },
                {"7", "8", "9", "/"},
                {"4", "5", "6", "-"},
                {"1", "2", "3", "+"},
                {".", "0", "CLEAR", "EQUALS"}
            };
            
            for (int i = 0; i < buttons.GetLength(0); i++)
            {
                for (int j = 0; j < buttons.GetLength(1); j++)
                {
                    if (buttons[i, j].Equals("")) continue;

                    Button tmp = new Button();
                    tmp.SetValue(Grid.ColumnProperty, j);
                    tmp.SetValue(Grid.RowProperty, i);
                    tmp.SetValue(ContentProperty, buttons[i, j]);
                    tmp.Click += new RoutedEventHandler(BtnClick);
                    tmp.Background = Brushes.Aqua;
                    if (buttons[i, j].Equals("EQUALS")) tmp.Background = Brushes.LimeGreen;


                    mainGrid.Children.Add(tmp);
                }
            }
        }
        
        private void BtnClick(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is Button tmp)
            {
                if (tmp.Content == "EQUALS")
                {
                    display.Text = calcWithoutCheat(display.Text);
                    return;
                }
                if (tmp.Content == "CLEAR")
                {
                    display.Text = "";
                    return;
                }
                display.Text += tmp.Content;
            }

        }

        private string calc(string input)
        {
            //Måste tyvärr lösa denna även fast den gör allt jag vill. 
            return new DataTable().Compute(display.Text, null).ToString();
        }
        private string calcWithoutCheat(string input)
        {
            string output = "";
            List<CalcModel> calculate = new List<CalcModel>();
            char[] operators = {'*', '/', '+', '-'};
            if (input != "")
            {
                for (int i = 0; i < input.Length; i++)
                {
                    for (int j = 0; j < operators.Length; j++)
                    {
                        if (input[i] == operators[j])
                        {
                            CalcModel tmp = new CalcModel();
                            tmp.OperatorMath = input[i];
                            calculate.Add(tmp);
                        }
                    }
                }

                for (int i = 0; i < calculate.Count; i++)
                {
                    
                }

            }
            return output;
        }
    }
}
