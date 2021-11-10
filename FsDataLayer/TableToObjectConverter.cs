using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using FsModel;

namespace FsDataLayer
{
    public class TableToObjectConverter
    {
        SqlAccess sqlAccess;

        public TableToObjectConverter(SqlAccess sqlAccess)
        {
            this.sqlAccess = sqlAccess;
        }

        public ObservableCollection<Kunde> GetKundeListe(DataTable table)
        {
            ObservableCollection<Kunde> liste = new ObservableCollection<Kunde>();
            foreach (DataRow row in table.Rows)
            {
                Kunde kunde = GetKunde(row);
                liste.Add(kunde);
            }
            return liste;
        }

        public ObservableCollection<Forsikring> GetForsikringListe(DataTable table)
        {
            ObservableCollection<Forsikring> liste = new ObservableCollection<Forsikring>();
            foreach (DataRow row in table.Rows)
            {
                Forsikring forsikring = GetForsikring(row);
                liste.Add(forsikring);
            }
            return liste;
        }

        public ObservableCollection<Bilmodel> GetBilmodelListe(DataTable table)
        {
            ObservableCollection<Bilmodel> liste = new ObservableCollection<Bilmodel>();
            foreach (DataRow row in table.Rows)
            {
                Bilmodel bilmodel = GetBilmodel(row);
                liste.Add(bilmodel);
            }
            return liste;
        }

        private Kunde GetKunde(DataRow row)
        {
            Kunde kunde = new Kunde(
                (int)row["Id"],
                (string)row["Fornavn"],
                (string)row["Efternavn"],
                (string)row["Adresse"],
                (string)row["Postnummer"],
                (string)row["Telefon"]);
            return kunde;
        }

        private Forsikring GetForsikring(DataRow row)
        {
            Forsikring forsikring = new Forsikring(
                (int)row["Id"],
                GetKunde(GetKundeRow(row["KundeId"].ToString())), // Opretter en kunde vha. ID
                GetBilmodel(GetBilmodelRow(row["BilmodelId"].ToString())), // Opretter en Bilmodel vha. ID
                (string)row["Registreringsnummer"],
                (decimal)row["Præmie"],
                (decimal)row["ForsikringsSum"],
                (string)row["Bemærkning"],
                (DateTime)row["Startdato"]);
            return forsikring;
        }

        private Bilmodel GetBilmodel(DataRow row)
        {
            Bilmodel bilmodel = new Bilmodel(
                (int)row["Id"],
                (string)row["Mærke"],
                (string)row["Model"],
                (int)row["Startår"],
                (int)row["Slutår"],
                (decimal)row["VejledendePræmie"],
                (decimal)row["VejledendeSum"]);
            return bilmodel;
        }

        private DataRow GetKundeRow(string id)
        {
            return sqlAccess.ExecuteSql("select * from Kunde where Id = " + id).Rows[0];
        }

        private DataRow GetForsikringRow(string id)
        {
            return sqlAccess.ExecuteSql("select * from Forsikring where Id = " + id).Rows[0];
        }

        private DataRow GetBilmodelRow(string id)
        {
            return sqlAccess.ExecuteSql("select * from Bilmodel where Id = " + id).Rows[0];
        }
    }
}
