namespace VideoOyunStokYonetimi
{
    class Program
    {
        public static void Main(string[] args)
        {
            OyunYonetimi oyunYonetimi = new OyunYonetimi();

            Oyuncu oyuncu = null;

            Oyuncu enesErci = new Oyuncu("Enes Erci", "12345");
            Oyuncu beratDogan = new Oyuncu("Berat Doğan", "12345");


            List<Oyuncu> kullanicilar = new List<Oyuncu>();

            kullanicilar.Add(enesErci);
            kullanicilar.Add(beratDogan);


            string secim = "0";
            while (!secim.Equals("5"))
            {
                Console.WriteLine("1. Giriş Yap");
                Console.WriteLine("2. Oyun Ekle");
                Console.WriteLine("3. Oyunları Listele");
                Console.WriteLine("4. Oyun Sil");
                Console.WriteLine("5. Çıkış");
                Console.Write("Seçiminizi yapınız: ");

                secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        oyuncu = oyunYonetimi.GirisYap(kullanicilar, oyuncu);
                        break;
                    case "2":
                        if(oyuncu != null) // oyuncu var mı? yok mu?
                        {
                            Console.WriteLine("Oyun Adını Girin: ");
                            string oyunAdi = Console.ReadLine();

                            Console.WriteLine("Stok Adedini Girin: ");
                            string stokAdedi = Console.ReadLine();
                            if (int.TryParse(stokAdedi, out int StokAdedi))
                            {
                            }
                            else
                            {
                                Console.WriteLine("Hatalı giriş, bir sayı girin.");
                                StokAdedi = 0;
                            }

                            Console.WriteLine("Oyunun Çıkış Yılını Girin: ");
                            string cikisYili = Console.ReadLine();

                            Console.WriteLine("Oyunun Türünü Girin: ");
                            string oyunTuru = Console.ReadLine();

                            Console.WriteLine("Oyun Çok Oyunculu Mu, Tek Oyunculu Mu? : ");
                            string cokOyunculuMuTekOyunculuMu = Console.ReadLine();

                            Oyun yeniOyun = new Oyun(oyunAdi, StokAdedi, cikisYili, oyunTuru, cokOyunculuMuTekOyunculuMu);

                            oyunYonetimi.OyunEkle(yeniOyun);
                        }
                        else
                        {
                            Console.WriteLine("Oyun Eklemek İçin Giriş Yapın.");
                        }
                        break;
                    case "3":
                        if(oyuncu != null) // oyuncu var mı? yok mu?
                        {
                            oyunYonetimi.OyunlariListele();
                        }
                        else
                        {
                            Console.WriteLine("Oyunları Görmek İçin Giriş Yapın.");
                        }
                        break;
                    case "4":
                        if (oyuncu != null) // oyuncu var mı? yok mu?
                        {
                            Console.WriteLine("Silinecek Oyunun Adını Girin: ");
                            string oyunAdi = Console.ReadLine();    
                            oyunYonetimi.OyunSil(oyunAdi);
                        }
                        else
                        {
                            Console.WriteLine("Oyunları Görmek İçin Giriş Yapın.");
                        }
                        break;
                    case "5":
                        break;
                    default:
                        Console.WriteLine("Hatalı seçim, tekrar deneyin");
                        break;
                }
            }
        }
    }

    // Kullanacağımız metotları IOyunYonetimi interface ile tutuyoruz.
    interface IOyunYonetimi
    {
        void OyunEkle(Oyun oyun);
        void OyunlariListele();
        void OyunSil(string oyunAdi);
        Oyuncu GirisYap(List<Oyuncu> kullanicilar, Oyuncu oyuncu);
    }

    // OyunYonetimi sınıfında IOyunYonetimi interface ten metotlarını alır
    class OyunYonetimi : IOyunYonetimi
    {
        private List<Oyun> oyunlar = new List<Oyun>();

        public void OyunEkle(Oyun oyun)
        {
            oyunlar.Add(oyun);
            Console.WriteLine("Oyun başarıyla eklendi : "+oyun.Ad);
        }

        public void OyunlariListele()
        {
            Console.WriteLine("Oyunlar:");
            if(oyunlar.Count > 0)
            {
                // listedeki oyunları yazdır.
                foreach (Oyun oyun in oyunlar)
                {
                    Console.WriteLine($"Ad: {oyun.Ad}, Stok Adedi: {oyun.StokAdedi}, Türü: {oyun.OyunTuru}, Çıkış Yılı: {oyun.CikisYili}");
                }
            }
            else
            {
                Console.WriteLine("Stokta Oyun Bulunamadı.");
            }
        }

        public void OyunSil(string oyunAdi)
        {
            // oyunlar listesinde oyun varsa, listedeki oyun sayısı 0'dan büyükse
            if(oyunlar.Count > 0)
            {
                // kullanıcının girdiği isimle listeki oyunları karşılaştır. Aynı isimde olan oyunu al.
                Oyun silinecekOyun = oyunlar.Find(oyun => oyun.Ad.Equals(oyunAdi));

                if (silinecekOyun != null) // eğer aynı isimde bir oyun varsa
                {
                    oyunlar.Remove(silinecekOyun); // oyunlar listesinden kaldır
                    Console.WriteLine("Oyun Silindi : " + silinecekOyun.Ad);
                }
                else // eğer aynı isimde oyun yoksa
                {
                    Console.WriteLine("Stoklarda Bu İsimde Bir Oyun Yok.");
                }
            }
            else // listenin uzunluğu 0'dan büyük değilse yani boşsa
            {
                Console.WriteLine("Stoklar Boş, Herhangibir Oyun Eklenmemiş");
            }
        }

        // GirisYap fonksiyonu return bir metot. Oyuncu nesnesi döndürür.
        public Oyuncu GirisYap(List<Oyuncu> kullanicilar, Oyuncu oyuncu)
        {
            Console.Write("Kullanıcı Adı: ");
            string kullaniciAdi = Console.ReadLine();

            Console.Write("Şifre: ");
            string sifre = Console.ReadLine();

            // kullanıcılar listesinin içerisinde dışarıdan girilen kullanıcı adıyla aynı adda kullanıcı var mı karşılaştır varsa al.
            Oyuncu girisYapan = kullanicilar.Find(kullanici => kullanici.KullaniciAdi == kullaniciAdi && kullanici.Sifre == sifre);

            if (girisYapan != null)
            {
                Console.WriteLine("Giriş Başarılı.");
                oyuncu = girisYapan;
                return oyuncu;
            }
            else
            {
                Console.WriteLine("Hatalı bilgi girildi, tekrar giriş yapmayı deneyin");
            }
            return null;
        }
    }

    class Oyuncu
    {
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }

        public Oyuncu(string KullaniciAdi, string Sifre)
        {
            this.KullaniciAdi = KullaniciAdi;
            this.Sifre = Sifre;
        }

    }

    class Oyun
    {
        public string Ad { get; set; }
        public string OyunTuru { get; set; }
        public string CikisYili {get; set;}
        public int StokAdedi { get; set; }
        public string CokOyunculuMuTekOyunculuMu { get; set; }

        public Oyun(string Ad, int StokAdedi, string CikisYili, string OyunTuru, string CokOyunculuMuTekOyunculuMu)
        {
            this.Ad = Ad;
            this.StokAdedi = StokAdedi;
            this.CikisYili = CikisYili;
            this.OyunTuru = OyunTuru;
            this.CokOyunculuMuTekOyunculuMu = CokOyunculuMuTekOyunculuMu;
        }
    }

}
