using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using str = System.String;

namespace Calc;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    str number_1 = "";
    str number_2 = "";
    str operace = "";
    bool zadanaOperace = false;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void UpdateOutput()
    {
        OutputTextBox.Text = number_1 + " " + operace + " " + number_2;
    }

    private void OperatorButtonClick(object sender, RoutedEventArgs e)
    {
        Button button = (Button)sender;
        str input = button.Content.ToString();

        if (number_1 != "" && number_2 != "")
        {
            IsEqualButtonClick(sender, e);
            zadanaOperace = true;
        }
        
        operace = input;
        zadanaOperace = true;
        UpdateOutput();
    }

    private void DeleteButtonClick(object sender, RoutedEventArgs e)
    {
        OutputTextBox.Clear();
        number_1 = "";
        operace = "";
        zadanaOperace = false;
        number_2 = "";
    }

    private void NumberButtonClick(object sender, RoutedEventArgs e)
    {
        Button button = (Button)sender;
        int input = int.Parse(button.Content.ToString());
        
        if (!zadanaOperace)
        {
            number_1 += input;
        }
        else
        {
            number_2 += input;
        }
        
        UpdateOutput();
    }

    private void IsEqualButtonClick(object sender, RoutedEventArgs e)
    {
        double output = 0;

        if (!zadanaOperace)
        {
            output += double.Parse(number_1);
        }
        
        if (operace == "+")
        {
            output += double.Parse(number_1) + double.Parse(number_2);
        }
        
        if (operace == "-")
        {
            output += double.Parse(number_1) - double.Parse(number_2);
        }
        
        if (operace == "*")
        {
            output += double.Parse(number_1) * double.Parse(number_2);
        }
        
        if (operace == "/")
        {
            output += double.Parse(number_1) / double.Parse(number_2);
        }

        OutputTextBox.Text = output.ToString();

        
        number_1 = output.ToString();
        number_2 = "";
        zadanaOperace = false;
    }

    private void SqrtButtonClick(object sender, RoutedEventArgs e)
    {
        if (!zadanaOperace)
        {
            number_1 = Convert.ToString(double.Parse(number_1) * double.Parse(number_1));
        }

        else
        {
            number_2 = Convert.ToString(double.Parse(number_2) * double.Parse(number_2));
        }
        
        UpdateOutput();
    }
    
    private void SqrRootButtonClick(object sender, RoutedEventArgs e)
    {
        if (!zadanaOperace)
        {
            number_1 = Convert.ToString(Math.Pow(double.Parse(number_1), 0.5));
        }

        else
        {
            number_2 = Convert.ToString(Math.Pow(double.Parse(number_2), 0.5));
        }
        
        UpdateOutput();
    }

    private void OneSlashX(object sender, RoutedEventArgs e)
    {
        if (!zadanaOperace)
        {
            number_1 = Convert.ToString(1 / double.Parse(number_1));
        }

        else
        {
            number_2 = Convert.ToString(1 / double.Parse(number_1));
        }
        
        UpdateOutput();
    }

    private void Carka(object sender, RoutedEventArgs e)
    {
        if (!zadanaOperace)
        {
            number_1 += ",";
        }

        else
        {
            number_2 += ",";
        }
        
        UpdateOutput();
    }

    private void Negate(object sender, RoutedEventArgs e)
    {
        if (!zadanaOperace)
        {
            number_1 = Convert.ToString(0 -(double.Parse(number_1)));
        }

        else
        {
            number_2 = Convert.ToString(0 -(double.Parse(number_2)));
        }

        UpdateOutput();
    }

    private void Percent(object sender, RoutedEventArgs e)
    {
        //number 1 - number 2 % z number 1
        //number 1 - (number 1 / 100) * number 2
        
        double output = 0;
        
        if (operace == "+")
        {
            output += double.Parse(number_1) + ((double.Parse(number_1) / 100) * double.Parse(number_2));
        }
        
        if (operace == "-")
        {
            output += double.Parse(number_1) - ((double.Parse(number_1) / 100) * double.Parse(number_2));
        }
        
        if (operace == "*")
        {
            output += double.Parse(number_1) * ((double.Parse(number_1) / 100) * double.Parse(number_2));
        }
        
        if (operace == "/")
        {
            output += double.Parse(number_1) / ((double.Parse(number_1) / 100) * double.Parse(number_2));
        }

        OutputTextBox.Text = output.ToString();

        
        number_1 = output.ToString();
        number_2 = "";
        zadanaOperace = false;
        
    }
}