using System;
using System.Collections.Generic;
using System.Text;

namespace FsModel
{
    public class Kunde
    {
        public int KundeId { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public string Fuldenavn { get { return Fornavn + " " + Efternavn; } }
        public string Adresse { get; set; }
        public string Postnummer { get; set; }
        public string Telefon { get; set; }

        public Kunde(int id, string fornavn, string efternavn, string adresse, string postnummer, string telefon)
        {
            KundeId = id;
            Fornavn = fornavn;
            Efternavn = efternavn;
            Adresse = adresse;
            Postnummer = postnummer;
            Telefon = telefon;
        }
    }
}
