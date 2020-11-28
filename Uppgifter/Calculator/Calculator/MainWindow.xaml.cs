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

        private String theNumbers = "";

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
            switch (tmp.Content)
            {
                case "EQUALS":
                    if (theNumbers != "")
                    {
                        CalcModel tmpNumber = new CalcModel();
                        tmpNumber.NumberMath = int.Parse(theNumbers);
                        calculateList.Add(tmpNumber);
                        theNumbers = "";
                    }

                    display.Text = CalcWithoutCheat();
                    goto skipNumberCheck;
                case "CLEAR":
                    display.Text = "";
                    if (calculateList.Count > 0) calculateList.Clear();
                    goto skipNumberCheck;
            }

            {
                try
                {
                    int pos = Array.IndexOf(numbers, tmp.Content);
                    theNumbers += numbers[pos];
                }
                catch (Exception exception)
                {
                    try
                    {
                        if (theNumbers != "")
                        {
                            CalcModel tmpNumber = new CalcModel();
                            tmpNumber.NumberMath = int.Parse(theNumbers);
                            calculateList.Add(tmpNumber);
                            theNumbers = "";
                        }

                        int pos = Array.IndexOf(operators, tmp.Content);
                        CalcModel tmpOperator = new CalcModel();
                        tmpOperator.OperatorMath = operators[pos];
                        calculateList.Add(tmpOperator);
                    }
                    catch (Exception e1)
                    {
                        Console.WriteLine("Something went wrong!");
                        throw;
                    }
                }
            }
            display.Text += tmp.Content;
            skipNumberCheck:
            Console.Write("");
        }

        private string Calc()
        {
            //Måste tyvärr lösa denna även fast den gör allt jag vill. 
            return new DataTable().Compute(display.Text, null).ToString();
        }

        private string CalcWithoutCheat()
        {
            string output = "";
            for (int i = 1; i < calculateList.Count; i = i + 2)
            {
                output = calculateList[i].print() switch
                {
                    "+" => addTwoItems(calculateList[i - 1].NumberMath, calculateList[i + 1].NumberMath),
                    "-" => subtractTwoItems(calculateList[i - 1].NumberMath, calculateList[i + 1].NumberMath),
                    "/" => divideTwoItems(calculateList[i - 1].NumberMath, calculateList[i + 1].NumberMath),
                    "*" => multiplyTwoItems(calculateList[i - 1].NumberMath, calculateList[i + 1].NumberMath),
                    _ => output
                };
            }
            if (output == "" && calculateList.Count > 0) output = calculateList[0].print();
            return output;
        }

        private string addTwoItems(int num1, int num2)
        {
            return (num1 + num2).ToString();
        }
        private string subtractTwoItems(int num1, int num2)
        {
            return (num1 - num2).ToString();
        }
        private string multiplyTwoItems(int num1, int num2)
        {
            return (num1 * num2).ToString();
        }
        private string divideTwoItems(int num1, int num2)
        {
            return (num1 / num2).ToString();
        }
    }
}