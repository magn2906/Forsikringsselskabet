using System;
using System.Collections.Generic;
using System.Text;
using FsModel;
using FsDataLayer;
using System.Collections.ObjectModel;

namespace FsDataLayer
{
    public class FsData
    {
        SqlAccess sqlAccess = new SqlAccess();
        TableToObjectConverter converter;

        public FsData()
        {
            converter = new TableToObjectConverter(sqlAccess);
        }

        public ObservableCollection<Kunde> KundeListe
        {
            get
            {
                return converter.GetKundeListe(sqlAccess.ExecuteSql("select * from Kunde"));
            }
        }

        public void OpretKunde(string fornavn, string efternavn, string adresse, string postnummer, string telefon)
        {
            sqlAccess.ExecuteSql($"INSERT INTO [dbo].[Kunde] ([Fornavn], [Efternavn], [Adresse], [Postnummer], [Telefon]) VALUES ('{fornavn}', '{efternavn}', '{adresse}', '{postnummer}', '{telefon}')");
        }

        public void OpdaterKunde(string fornavn, string efternavn, string adresse, string postnummer, string telefon)
        {
            sqlAccess.ExecuteSql($"UPDATE [dbo].[Kunde] SET Fornavn = '{fornavn}', Efternavn = '{efternavn}', Adresse = '{adresse}', Postnummer = '{postnummer}' WHERE Telefon = '{telefon}'");
        }

        public void SletKunde(Kunde kunde)
        {
            sqlAccess.ExecuteSql($"DELETE FROM [dbo].[Kunde] WHERE Id = " + kunde.KundeId);
        }
    }
}
