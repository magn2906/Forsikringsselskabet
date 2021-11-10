using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using FsDataLayer;
using FsModel;

namespace FsFuncLayer
{
    public class FsFunc : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        FsData data = new FsData();

        private void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new
                PropertyChangedEventArgs(propName));
            }
        }

        public ObservableCollection<Kunde> KundeListe
        {
            get
            {
                return data.KundeListe;
            }
        }

        public ObservableCollection<Forsikring> ForsikringListe
        {
            get
            {
                return data.ForsikringListe;
            }
        }

        public ObservableCollection<Bilmodel> BilmodelListe
        {
            get
            {
                return data.BilmodelListe;
            }
        }

        public void OpretKunde(string fornavn, string efternavn, string adresse, string postnummer, string telefon)
        {
            #region Fejlhåndtering
            foreach (Kunde kunde in KundeListe)
            {
                if (kunde.Telefon == telefon)
                {
                    throw new Exception("En kunde med dette telefonnummer eksisterer allerede.");
                }
            }
            #endregion

            data.OpretKunde(fornavn, efternavn, adresse, postnummer, telefon);
            
            RaisePropertyChanged("KundeListe");
        }

        public void OpdaterKunde(Kunde kunde, string fornavn, string efternavn, string adresse, string postnummer, string telefon)
        {
            #region Fejlhåndtering
            if(kunde == null)
            {
                throw new Exception("Ingen kunde valgt");
            }
            #endregion

            data.OpdaterKunde(kunde, fornavn, efternavn, adresse, postnummer, telefon);
        }

        public void SletKunde(Kunde kunde)
        {
            data.SletKunde(kunde);
            RaisePropertyChanged("KundeListe");
        }

        public void OpretForsikring(Kunde kunde, Bilmodel bilmodel, string registreringsnummer, string præmie, string sum, string bemærkning, DateTime startdato)
        {
            #region Fejlhåndtering
            if (!decimal.TryParse(præmie, out decimal præmieDecimal))
            {
                throw new Exception("Kunne ikke læse præmie");
            }

            if (!decimal.TryParse(sum, out decimal sumDecimal))
            {
                throw new Exception("Kunne ikke læse sum");
            }
            #endregion

            data.OpretForsikring(kunde, bilmodel, registreringsnummer, præmieDecimal, sumDecimal, bemærkning, startdato);
            RaisePropertyChanged("ForsikringListe");
        }

        public void SletForsikring(Forsikring forsikring)
        {
            data.SletForsikring(forsikring);
            RaisePropertyChanged("ForsikringListe");
        }

        public void OpretBilmodel(string mærke, string model, string startår, string slutår, string vejledendePræmie, string vejledendeSum)
        {
            #region Fejlhåndtering
            if (!int.TryParse(startår, out int startårInt))
            {
                throw new Exception("Kunne ikke læse startår");
            }

            if (!int.TryParse(slutår, out int slutårInt))
            {
                throw new Exception("Kunne ikke læse slutår");
            }

            if (!decimal.TryParse(vejledendePræmie, out decimal vejledendePræmieDecimal))
            {
                throw new Exception("Kunne ikke læse VejledendePræmie");
            }

            if (!decimal.TryParse(vejledendeSum, out decimal vejledendeSumDecimal))
            {
                throw new Exception("Kunne ikke læse VejledendeSum");
            }
            #endregion

            data.OpretBilmodel(mærke, model, startårInt, slutårInt, vejledendePræmieDecimal, vejledendeSumDecimal);
            RaisePropertyChanged("BilmodelListe");
        }

        public void SletBilmodel(Bilmodel bilmodel)
        {
            data.SletBilmodel(bilmodel);
            RaisePropertyChanged("BilmodelListe");
        }
    }
}
