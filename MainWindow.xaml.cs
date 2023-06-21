using System;
using System.Collections.Generic;
using System.IO.Packaging;
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

namespace Calculadora_top
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void ButtonClick(Object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = (Button)sender;//Instanciado 
                string value = (string)button.Content;
                if(IsNumber(value))//es numero?
                {
                    HandleNumbers(value);
                }                
                else if(IsOperator(value))//es una operacion?
                {
                    HandleOperators(value);
                }
                else if(value == "C")
                {
                    Screen.Clear();
                }
                else if(value == "=")
                {
                    HandleEquals(Screen.Text);
                }
                else if(value == "CE")
                {
                    Screen.Text = Screen.Text.Remove(Screen.Text.Length - 1);


                }
            }
            catch (Exception ex)
            {

                throw new Exception("Sucedio un errro: "+ex.Message);
            }
        }
        //Todo llega en string 
        //Metodo auxiliar
        public bool IsNumber(string num)
        {
            //if (double.TryParse(num, out _))
            //{
             //   return true;
            //}
            return double.TryParse(num, out _);

        }
        private void HandleNumbers(string value)
        {
            if(String.IsNullOrEmpty(Screen.Text))//revisar si esta vacio o no el 
            {
                Screen.Text = value;
            }
            else
            {
                Screen.Text += value;//Para concatenar el valor que ya esta dentro
            }
        }
        private bool IsOperator(string possibleOperator)
        {
            //if(possibleOperator =="+" ||  possibleOperator =="-"
            //    || possibleOperator == "*" || possibleOperator == "/")
            //{
            //    return true;
            //}
            //return false;
            return possibleOperator == "+" || possibleOperator == "-" || possibleOperator == "*" || possibleOperator == "/";
        }
        private void HandleOperators(string value)
        {
            if(!String.IsNullOrEmpty(Screen.Text)&& !ContainsOtherOperators(Screen.Text))//no puede estar vacio 
            {
                Screen.Text += value;//Para concatenar a mas numeros

            }
        }        

        private bool ContainsOtherOperators(string screenContent)//No permite escribir 2 veces el mismo operador
        {
            return screenContent.Contains("+")|| screenContent.Contains("-")|| screenContent.Contains("*")|| screenContent.Contains("/");
        }
        private void Handledoble(string value)
        {
            if (!String.IsNullOrEmpty(Screen.Text))//no puede estar vacio 
            {
                Screen.Text += value;//Para concatenar a mas numeros

            }
        }
        private void HandleEquals(string screenContent)
        {
            string op = FindOperator(screenContent);

            if (!String.IsNullOrEmpty(op))
                switch (op)
                {
                    case "+":
                        Screen.Text = Sum();
                        break;
                        case "-":
                        Screen.Text = Res();    
                        break;
                        case "*":
                        Screen.Text = Mul();
                        break;
                        case "/":
                        Screen.Text = Div();
                        break;
                }
        }
        private string FindOperator(string screenContent)
        {
            foreach (char c in screenContent)
            {
                if (IsOperator(c.ToString()))
                {
                    return c.ToString();
                }
            }
            return screenContent;
        }
        private string Sum()
        {
            string[] numbers = Screen.Text.Split('+');
            double.TryParse(numbers[0], out double n1);
            double.TryParse(numbers[1], out double n2);
            return Math.Round(n1 + n2,12).ToString();
        }
        private string Res()
        {
            string[] numbers = Screen.Text.Split('-');
            double.TryParse(numbers[0], out double n1);
            double.TryParse(numbers[1], out double n2);
            return Math.Round(n1- n2, 12).ToString();
        }
        private string Mul()
        {
            string[] numbers = Screen.Text.Split('*');
            double.TryParse(numbers[0], out double n1);
            double.TryParse(numbers[1], out double n2);
            return Math.Round(n1 * n2, 12).ToString();
        }
        private string Div()
        {
            string[] numbers = Screen.Text.Split('/');
            double.TryParse(numbers[0], out double n1);
            double.TryParse(numbers[1], out double n2);
            return Math.Round(n1 / n2, 12).ToString();
        }        
    }
}
