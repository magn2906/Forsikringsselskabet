using System;
using System.Collections.Generic;
using System.Text;

namespace FsModel
{
    public class Forsikring
    {
        public int KundeId { get; set; }
        public int BilmodelId { get; set; }
        public string Registreringsnummer { get; set; }
        public decimal Præmie { get; set; }
        public decimal ForsikringsSum { get; set; }
        public string Bemærkning { get; set; }
        public DateTime Startdato { get; set; }
        public Kunde Kunde { get; set; }
        public Bilmodel Bilmodel { get; set; }

        public Forsikring(Kunde kunde, Bilmodel bilmodel, string registreringsnummer, decimal præmie, decimal forsikringsSum, string bemærkning, DateTime startdato)
        {
            Kunde = kunde;
            KundeId = kunde.KundeId;
            Bilmodel = bilmodel;
            BilmodelId = bilmodel.BilmodelId;
            Registreringsnummer = registreringsnummer;
            Præmie = præmie;
            ForsikringsSum = forsikringsSum;
            Bemærkning = bemærkning;
            Startdato = startdato;
        }
    }
}
