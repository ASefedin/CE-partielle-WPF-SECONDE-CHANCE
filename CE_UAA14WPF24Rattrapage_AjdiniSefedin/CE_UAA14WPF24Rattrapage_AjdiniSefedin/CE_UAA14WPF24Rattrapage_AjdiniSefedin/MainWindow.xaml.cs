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
using Image = System.Windows.Controls.Image;

namespace CE_UAA14WPF24Rattrapage_AjdiniSefedin
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
            Button[,] button = new Button[8, 8];
            RowDefinition[] rowdef = new RowDefinition[8];
            ColumnDefinition[] coldef = new ColumnDefinition[8];
            int compteur = 1;
        public MainWindow()
        {
            InitializeComponent();
            NbLigne.PreviewTextInput += NbLigneColonne_VerifInt;
            NbColonne.PreviewTextInput += NbLigneColonne_VerifInt;

            Solitaire.Checked += CheckedBox;
            Marelle.Checked += CheckedBox;
            BandeLaterale.Checked += CheckedBox;

            Valider.Click += ClickValid;
            Reset.Click += ClickReset;

            NbLC.Visibility = Visibility.Hidden;
        }

        public void NbLigneColonne_VerifInt(object sender, TextCompositionEventArgs e)
        {

            double entier;
            if (!double.TryParse(e.Text, out entier))
            {
                if (entier >= 9 || entier <= 0)
                {
                    NbLigne.Text = string.Empty;
                    NbColonne.Text = string.Empty;
                    MessageBox.Show("Veuillez encodez une valeur juste");
                    NbLigne.Text = string.Empty;
                    NbColonne.Text = string.Empty;
                }
            }
        }

        private void CheckedBox(object sender, RoutedEventArgs e)
        {
            if (Solitaire.IsChecked == true)
            {
                NbLC.Visibility = Visibility.Hidden;
            }
            else if (Marelle.IsChecked == true)
            {
                NbLC.Visibility = Visibility.Visible;
            }
            else if (BandeLaterale.IsChecked == true)
            {
                NbLC.Visibility = Visibility.Visible;
            }
        }

        private void ClickValid(object sender, RoutedEventArgs e)
        {
            if (Solitaire.IsChecked == true)
            {
                CreerDamier(9, 9, "solitaire");
            }
            else if (Marelle.IsChecked == true)
            {
                CreerDamier(8, 8, "Marelle");
            }
            else if (BandeLaterale.IsChecked == true)
            {
                CreerDamier(8, 8, "BandeLaterale");
            }
        }

        private void ClickReset(object sender, RoutedEventArgs e)
        {

            Solitaire.IsChecked = false;
            Marelle.IsChecked = false;
            BandeLaterale.IsChecked = false;

            NbLigne.Text = string.Empty;
            NbColonne.Text = string.Empty;

            NbLC.Visibility = Visibility.Hidden;
        }

        private void CreerDamier(int i, int y, string Nom)
        {
            for (i = 0; i < 8; i++)
            {
                coldef[i] = new ColumnDefinition();
                grdMain.ColumnDefinitions.Add(coldef[i]);

                rowdef[i] = new RowDefinition();
                grdMain.RowDefinitions.Add(rowdef[i]);

                for (i = 0; i < 8; i++)
                {
                    for (y = 0; y < 8; y++)
                    {
                        button[i, y] = new Button();
                        switch (compteur)
                        {
                            case 1:
                                button[i, y].Background = Brushes.Black;
                                Console.WriteLine("assets/petitCercleRouge.png", UriKind.Relative);
                                break;
                            case 3:
                                button[i, y].Background = Brushes.Black;
                                Console.WriteLine("assets/petitCercleRouge.png", UriKind.Relative);
                                break;
                            case 5:
                                button[i, y].Background = Brushes.Black;
                                Console.WriteLine("assets/petitCercleRouge.png", UriKind.Relative);
                                break;
                        }
                    }
                }
            }
        }

        private void Image()
        {
            BitmapImage imageBouton = new BitmapImage();
            imageBouton.BeginInit();
            imageBouton.UriSource = new Uri("assets/petitCercleRouge.png", UriKind.Relative);
            imageBouton.UriSource = new Uri("assets/volvik.png", UriKind.Relative);
            imageBouton.EndInit();
            Image imBouton = new Image();
            imBouton.Source = imageBouton;
            imBouton.Stretch = Stretch.Fill;
        }
    }
}
