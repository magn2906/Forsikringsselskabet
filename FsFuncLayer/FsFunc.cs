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
                    throw new Exception("En kunde med dette telefonnummer eksisterer allerede.\n\n\n");
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
            #region Fejlhåndtering
            if (kunde == null)
            {
                throw new Exception("Ingen kunde valgt");
            }

            foreach (Forsikring forsikring in ForsikringListe)
            {
                if (forsikring.KundeId == kunde.KundeId)
                {
                    throw new Exception("Kunden er tilknyttet en eksisterende forsikring, og kan derfor ikke slettes");
                }
            }
            #endregion

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

            if (kunde == null)
            {
                throw new Exception("Ingen kunde valgt");
            }

            if (bilmodel == null)
            {
                throw new Exception("Ingen bilmodel valgt");
            }

            foreach (Forsikring forsikring in ForsikringListe)
            {
                if (forsikring.Registreringsnummer == registreringsnummer)
                {
                    throw new Exception("Registreringsnummer er allerede knyttet til en eksisterende forsikring");
                }
            }
            #endregion

            data.OpretForsikring(kunde, bilmodel, registreringsnummer, præmieDecimal, sumDecimal, bemærkning, startdato);
            RaisePropertyChanged("ForsikringListe");
        }

        public void OpdaterForsikring(Forsikring forsikring, Kunde kunde, Bilmodel bilmodel, string registreringsnummer, string præmie, string sum, string bemærkning)
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
            if (forsikring == null)
            {
                throw new Exception("Ingen forsikring valgt");
            }
            if (kunde == null)
            {
                throw new Exception("Ingen kunde valgt");
            }
            if (bilmodel == null)
            {
                throw new Exception("Ingen bilmodel valgt");
            }
            if (forsikring.Kunde.KundeId != kunde.KundeId)
            {
                throw new Exception("Man kan ikke ændre kunde til en forsikring. Slet og lav en ny en i stedet for.");
            }
            if (forsikring.Bilmodel.BilmodelId != bilmodel.BilmodelId)
            {
                throw new Exception("Man kan ikke ændre bilmodel til en forsikring. Slet og lav en ny en i stedet for.");
            }
            #endregion

            data.OpdaterForsikring(forsikring, registreringsnummer, præmieDecimal, sumDecimal, bemærkning);
        }

        public void SletForsikring(Forsikring forsikring)
        {
            #region Fejlhåndtering
            if (forsikring == null)
            {
                throw new Exception("Ingen forsikring valgt");
            }
            #endregion

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

            foreach (Bilmodel bilmodel in BilmodelListe)
            {
                if (bilmodel.Mærke == mærke && bilmodel.Model == model && bilmodel.Startår == startårInt && bilmodel.Slutår == slutårInt)
                {
                    throw new Exception("Denne model eksisterer allerede med samme start/slutår.");
                }

            }
            #endregion

            data.OpretBilmodel(mærke, model, startårInt, slutårInt, vejledendePræmieDecimal, vejledendeSumDecimal);
            RaisePropertyChanged("BilmodelListe");
        }

        public void SletBilmodel(Bilmodel bilmodel)
        {
            #region Fejlhåndtering
            if (bilmodel == null)
            {
                throw new Exception("Ingen bilmodel valgt");
            }
            #endregion

            data.SletBilmodel(bilmodel);
            RaisePropertyChanged("BilmodelListe");
        }
    }
}
