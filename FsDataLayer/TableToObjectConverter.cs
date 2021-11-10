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

        private DataRow GetKundeRow(string id)
        {
            return sqlAccess.ExecuteSql("select * from Kunde where Id = " + id).Rows[0];
        }

        public int GetId(DataRow row)
        {
            return (int)row["Id"];
        }
    }
}
