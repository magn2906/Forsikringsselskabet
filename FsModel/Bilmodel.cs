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
        public string Startår { get; set; }
        public string Slutår { get; set; }
        public decimal VejledendePræmie { get; set; }
        public decimal VejledendeSum { get; set; }
    }
}
