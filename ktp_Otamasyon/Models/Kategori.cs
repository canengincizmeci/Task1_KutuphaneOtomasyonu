using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ktp_Otamasyon.Models
{
    public class Kategori
    {
        public int id { get; set; }
        public string kategoriAd { get; set; }
        public bool? aktiflik { get; set; }
    }
}