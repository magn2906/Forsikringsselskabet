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

        public void OpretKunde(string fornavn, string efternavn, string adresse, string postnummer, string telefon)
        {
            bool Existing = false;
            foreach (Kunde kunde in KundeListe)
            {
                if (kunde.Telefon == telefon)
                {
                    data.OpdaterKunde(fornavn, efternavn, adresse, postnummer, telefon);
                    Existing = true;
                }
                if (Existing)
                {
                    break;
                }
            }
            if (!Existing)
            {
                data.OpretKunde(fornavn, efternavn, adresse, postnummer, telefon);
            }
            
            RaisePropertyChanged("KundeListe");
        }

        public void SletKunde(Kunde kunde)
        {
            data.SletKunde(kunde);
            RaisePropertyChanged("KundeListe");
        }
    }
}
