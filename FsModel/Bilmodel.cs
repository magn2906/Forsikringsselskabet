using System;
using System.Collections.Generic;
using System.Text;

namespace FsModel
{
    public class Bilmodel
    {
        public int BilmodelId { get; set; }
        public string Mærke { get; set; }
        public string Model { get; set; }
        public string BilmodelNavn { get { return Mærke + " " + Model; } }
        public int Startår { get; set; }
        public int Slutår { get; set; }
        public decimal VejledendePræmie { get; set; }
        public decimal VejledendeSum { get; set; }

        public Bilmodel(int bilmodelId, string mærke, string model, int startår, int slutår, decimal vejledendePræmie, decimal vejledendeSum)
        {
            BilmodelId = bilmodelId;
            Mærke = mærke;
            Model = model;
            Startår = startår;
            Slutår = slutår;
            VejledendePræmie = vejledendePræmie;
            VejledendeSum = vejledendeSum;
        }
    }
}
