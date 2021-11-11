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
        Vejr vejr = new Vejr();
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
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSletKunde_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Funktioner.SletKunde(dgKunder.SelectedItem as Kunde);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgKunder_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
                MessageBox.Show(ex.Message);
            }
        }

        private void dgForsikringer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Forsikring selectedForsikring = dgForsikringer.SelectedItem as Forsikring;
                cbxKundeForsikring.SelectedItem = selectedForsikring.Kunde;
                cbxBilmodelForsikring.SelectedItem = selectedForsikring.Bilmodel;
                tbxRegistreringsnummerForsikring.Text = selectedForsikring.Registreringsnummer.ToString();
                tbxPræmieForsikring.Text = selectedForsikring.Præmie.ToString();
                tbxSumForsikring.Text = selectedForsikring.ForsikringsSum.ToString();
                tbxBemærkningForsikring.Text = selectedForsikring.Bemærkning;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOpdaterForsikring_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Funktioner.OpdaterForsikring(dgForsikringer.SelectedItem as Forsikring, cbxKundeForsikring.SelectedItem as Kunde, cbxBilmodelForsikring.SelectedItem as Bilmodel, tbxRegistreringsnummerForsikring.Text, tbxPræmieForsikring.Text, tbxSumForsikring.Text, tbxBemærkningForsikring.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSletForsikring_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgForsikringer.SelectedItem != null)
                {
                    Funktioner.SletForsikring(dgForsikringer.SelectedItem as Forsikring);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGemBilmodel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Funktioner.OpretBilmodel(tbxMærkeBilmodeller.Text, tbxModelBilmodeller.Text, tbxStartårBilmodeller.Text, tbxSlutårBilmodeller.Text, tbxVejledendePræmieBilmodeller.Text, tbxVejledendeSumBilmodeller.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSletBilmodel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Funktioner.SletBilmodel(dgBilmodeller.SelectedItem as Bilmodel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vejr.location = tbxCity.Text;
            vejr.CurrentURL = "http://api.openweathermap.org/data/2.5/weather?q=" + vejr.location + "&mode=xml&units=metric&APPID=" + vejr.APIKEY;

            try
            {
                tblTempMin.Text = vejr.TemperatureMin();
                tblTempMax.Text = vejr.TemperatureMax();
                tblTempAvg.Text = vejr.Temperature();

                tblWindSpeed.Text = vejr.WindSpeed;
                tblWindSpeedName.Text = vejr.WindSpeedName();
                tblWindDirection.Text = vejr.WindDirection();
                tblWindDirectionName.Text = vejr.WindDirectionName();

                tblCountry.Text = vejr.Country();
                tblCity.Text = vejr.City();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kunne ikke finde byen \n\n\n" + ex.ToString(), "Kunne ikke finde byen");
            }
        }
    }
}
