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
using FsModel;
using FsFuncLayer;

namespace Forsikringsselskabet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FsFunc Funktioner = new FsFunc();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = Funktioner;
        }

        private void btnGemKunde_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Funktioner.OpretKunde(tbxFornavnKunde.Text, tbxEfternavnKunde.Text, tbxAdresseKunde.Text, tbxPostnummerKunde.Text, tbxTelefonKunde.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnOpdaterKunde_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Funktioner.OpdaterKunde(dgKunder.SelectedItem as Kunde, tbxFornavnKunde.Text, tbxEfternavnKunde.Text, tbxAdresseKunde.Text, tbxPostnummerKunde.Text, tbxTelefonKunde.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSletKunde_Click(object sender, RoutedEventArgs e)
        {
            Funktioner.SletKunde(dgKunder.SelectedItem as Kunde);
        }

        private void btnRedigerKunde_Click(object sender, RoutedEventArgs e)
        {
            Kunde selectedKunde = dgKunder.SelectedItem as Kunde;
            tbxFornavnKunde.Text = selectedKunde.Fornavn;
            tbxEfternavnKunde.Text = selectedKunde.Efternavn;
            tbxAdresseKunde.Text = selectedKunde.Adresse;
            tbxPostnummerKunde.Text = selectedKunde.Postnummer;
            tbxTelefonKunde.Text = selectedKunde.Telefon;
        }

        private void btnGemForsikring_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Funktioner.OpretForsikring(cbxKundeForsikring.SelectedItem as Kunde, cbxBilmodelForsikring.SelectedItem as Bilmodel, tbxRegistreringsnummerForsikring.Text, tbxPræmieForsikring.Text, tbxSumForsikring.Text, tbxBemærkningForsikring.Text, dpStartdatoForsikring.SelectedDate.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSletForsikring_Click(object sender, RoutedEventArgs e)
        {
            Funktioner.SletForsikring(dgForsikringer.SelectedItem as Forsikring);
        }

        private void btnGemBilmodel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Funktioner.OpretBilmodel(tbxMærkeBilmodeller.Text, tbxModelBilmodeller.Text, tbxStartårBilmodeller.Text, tbxSlutårBilmodeller.Text, tbxVejledendePræmieBilmodeller.Text, tbxVejledendeSumBilmodeller.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSletBilmodel_Click(object sender, RoutedEventArgs e)
        {
            Funktioner.SletBilmodel(dgBilmodeller.SelectedItem as Bilmodel);
        }

    }
}
