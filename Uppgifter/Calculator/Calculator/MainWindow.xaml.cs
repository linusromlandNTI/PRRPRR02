using System;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            TextBlock dsply = new TextBlock();

            InitializeComponent();

            for (int i = 0; i < 5; i++)
            {
                mainGrid.RowDefinitions.Add(new RowDefinition());
                mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            
            for (int i = 0; i < 10; i++)
            {
                String btnName = "btn" + i.ToString();
                Button btn = new Button
                {
                    Name = btnName,
                    Content = i
                };
                btn.SetValue(Grid.ColumnProperty, i%3);
                btn.SetValue(Grid.RowProperty, i/3);
                mainGrid.Children.Add(btn);
            }
        }
    }
}
