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

namespace PR_22._107К_Chayka_3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void NumericInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
            }
        }
        private void btnResult_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tbMassiv.Clear();
                int min = int.Parse(tbMin.Text);
                int max = int.Parse(tbMax.Text);
                int[] mass = new int[int.Parse(tbSize.Text)];
                Random random = new Random();

                for (int i = 0; i < int.Parse(tbSize.Text); i++)
                {
                    mass[i] = random.Next(min, max+1);
                }

                for (int i = 0; i < mass.Length - 1; i++)
                {
                    for (int j = i + 1; j < mass.Length; j++)
                    {
                        bool isEvenI = mass[i] % 2 == 0;
                        bool isEvenJ = mass[j] % 2 == 0;

                        if (isEvenJ && !isEvenI) 
                        {
                            int temp = mass[i];
                            mass[i] = mass[j];
                            mass[j] = temp;
                        }
                        else if ((isEvenI && isEvenJ) || (!isEvenI && !isEvenJ)) 
                        {
                            if (mass[i] > mass[j])
                            { 
                                int temp = mass[i];
                                mass[i] = mass[j];
                                mass[j] = temp;
                            }
                        }
                    }
                }
                for (int i = 0; i < mass.Length - 1; i++)
                {
                    if (i < mass.Length - 2)
                        tbMassiv.Text += mass[i] + ",";
                    else
                        tbMassiv.Text += mass[i];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }

        }

    private void tbSize_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void tbMin_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void tbMax_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
