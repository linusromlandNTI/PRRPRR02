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

        //List of all inserted items;
        private List<CalcModel> calculateList = new List<CalcModel>();

        //Init of the Textblock/Display
        private TextBlock display;

        private String theNumbers;

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

            string[,] buttons = new string[,]
            {
                {"", "", "", "*"},
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
            string[] numbers = new[] {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};
            string[] operators = new[] {"-", "+", "*", "/"};

            if (!(e.OriginalSource is Button tmp)) return;
            bool skip = false;
            switch (tmp.Content)
            {
                case "EQUALS":
                    display.Text = CalcWithoutCheat();
                    tmp.Content = "";
                    goto skipNumberCheck;
                case "CLEAR":
                    display.Text = "";
                    tmp.Content = "";
                    if (calculateList.Count > 0) calculateList.Clear();
                    goto skipNumberCheck;
            }

            {
                try
                {
                    int pos = Array.IndexOf(numbers, tmp.Content);
                    Console.WriteLine("is number : " + numbers[pos]);
                }
                catch (Exception exception)
                {
                    try
                    {
                        int pos = Array.IndexOf(operators, tmp.Content);
                        Console.WriteLine("is operator: " + operators[pos]);
                    }
                    catch (Exception e1)
                    {
                        Console.WriteLine("Something went wrong!");
                        throw;
                    }
                }
            }
            skipNumberCheck:
            display.Text += tmp.Content;
        }

        private string Calc()
        {
            //Måste tyvärr lösa denna även fast den gör allt jag vill. 
            return new DataTable().Compute(display.Text, null).ToString();
        }

        private string CalcWithoutCheat()
        {
            string output = "";
            output = "don't like constant, stop complaining!";
            return output;
        }
    }
}