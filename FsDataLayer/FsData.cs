using System;
using System.Collections.Generic;
using System.Text;
using FsModel;
using FsDataLayer;
using System.Collections.ObjectModel;
using System.Globalization;

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

        public ObservableCollection<Forsikring> ForsikringListe
        {
            get
            {
                return converter.GetForsikringListe(sqlAccess.ExecuteSql("select * from Forsikring"));
            }
        }

        public ObservableCollection<Bilmodel> BilmodelListe
        {
            get
            {
                return converter.GetBilmodelListe(sqlAccess.ExecuteSql("select * from Bilmodel"));
            }
        }

        public void OpretKunde(string fornavn, string efternavn, string adresse, string postnummer, string telefon)
        {
            sqlAccess.ExecuteSql($"INSERT INTO [dbo].[Kunde] ([Fornavn], [Efternavn], [Adresse], [Postnummer], [Telefon]) VALUES ('{fornavn}', '{efternavn}', '{adresse}', '{postnummer}', '{telefon}')");
        }

        public void OpdaterKunde(Kunde kunde, string fornavn, string efternavn, string adresse, string postnummer, string telefon)
        {
            sqlAccess.ExecuteSql($"UPDATE [dbo].[Kunde] SET Fornavn = '{fornavn}', Efternavn = '{efternavn}', Adresse = '{adresse}', Postnummer = '{postnummer}' Telefon = {telefon} WHERE Id = {kunde.KundeId}");
        }

        public void SletKunde(Kunde kunde)
        {
            sqlAccess.ExecuteSql($"DELETE FROM [dbo].[Kunde] WHERE Id = " + kunde.KundeId);
        }

        public void OpretForsikring(Kunde kunde, Bilmodel bilmodel, string registreringsnummer, decimal præmie, decimal sum, string bemærkning, DateTime startdato)
        {
            sqlAccess.ExecuteSql($"INSERT INTO [dbo].[Forsikring] ([KundeId], [BilmodelId], [Registreringsnummer], [Præmie], [ForsikringsSum], [Bemærkning], [Startdato]) VALUES ('{kunde.KundeId}', '{bilmodel.BilmodelId}', '{registreringsnummer}', '{præmie}', '{sum}', '{bemærkning}', '{startdato.ToString(CultureInfo.InvariantCulture)}')");
        }

        public void SletForsikring(Forsikring forsikring)
        {
            sqlAccess.ExecuteSql($"DELETE FROM [dbo].[Forsikring] WHERE Id = " + forsikring.ForsikringId);
        }

        public void OpretBilmodel(string mærke, string model, int startår, int slutår, decimal vejledendePræmie, decimal vejledendeSum)
        {
            sqlAccess.ExecuteSql($"INSERT INTO [dbo].[Bilmodel] ([Mærke], [Model], [Startår], [Slutår], [VejledendePræmie], [VejledendeSum]) VALUES ('{mærke}', '{model}', '{startår}', '{slutår}', '{vejledendePræmie}', '{vejledendeSum}')");
        }

        public void SletBilmodel(Bilmodel bilmodel)
        {
            sqlAccess.ExecuteSql($"DELETE FROM [dbo].[Bilmodel] WHERE Id = " + bilmodel.BilmodelId);
        }
    }
}
