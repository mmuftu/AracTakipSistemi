using System;

namespace AracTakipSistemi.DB
{
    [Serializable]
    public class Kullanici
    {
        public static int ID;
        public static string Isim;
        public static string Telefon;
        public static string Eposta;
        public static string Sifre;
        public static string Kullanici_Tipi_ID;
        public static bool Aktif;

        public Kullanici(int id, string isim, string telefon, string eposta, string sifre, string kullanici_Tipi_ID, bool aktif)
        {
            ID = id;
            Isim = isim;
            Telefon = telefon;
            Eposta = eposta;
            Sifre = sifre;
            Kullanici_Tipi_ID = kullanici_Tipi_ID;
            Aktif = aktif;
        }
        public Kullanici()
        {
        }
        public int id
        {
            get { return ID; }
            set { ID = value; }
        }
        public string isim
        {
            get { return Isim; }
            set { Isim = value; }
        }
        public string telefon
        {
            get { return Telefon; }
            set { Telefon = value; }
        }

        public string eposta
        {
            get { return Eposta; }
            set { Eposta = value; }
        }
        public string sifre
        {
            get { return Sifre; }
            set { Sifre = value; }
        }
        public string kullanici_Tipi_ID
        {
            get { return Kullanici_Tipi_ID; }
            set { Kullanici_Tipi_ID = value; }
        }
        public bool aktif
        {
            get { return Aktif; }
            set { Aktif = value; }
        }
    }
}