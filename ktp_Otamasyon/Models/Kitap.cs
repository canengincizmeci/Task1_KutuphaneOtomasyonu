using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ktp_Otamasyon.Models
{
    public class Kitap
    {
        public int id { get; set; }
        public int? kategoriID { get; set; }
        public string kitapAd { get; set; }
        public string yazar { get; set; }
        public string sayfaSayisi { get; set; }
        public bool? aktiflik { get; set; }
        public string kategori_ad { get; set; }
    }
}