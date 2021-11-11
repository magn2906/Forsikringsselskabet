using Microsoft.VisualStudio.TestTools.UnitTesting;
using FsModel;
using FsFuncLayer;
using System;

namespace FsUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        FsFunc Funktioner = new FsFunc();

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void OpretKundeTest()
        {
            Funktioner.OpretKunde("Magnus", "Mortensen", "Uldumvej 22", "2770", "42758030");
            Funktioner.OpretKunde("Magnus", "Mortensen", "Uldumvej 22", "2770", "42758030");
        }

        [TestMethod]
        public void OpretForsikring()
        {
            Funktioner.OpretForsikring(new Kunde(42, "Magnus", "Mortensen", "Uldumvej 22", "2770", "42758030"), new Bilmodel(42, "mærke", "model", 2021, 2023, 4200, 42000), "registreringsnummer", "100", "200", "bemærkning", DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void OpretBilmodel()
        {
            Funktioner.OpretBilmodel("sammeMærke", "sammeModel", "2042", "3042", "1000", "2000");
            Funktioner.OpretBilmodel("sammeMærke", "sammeModel", "2042", "3042", "1000", "2000");
        }
    }
}
