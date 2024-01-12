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
            while (!secim.Equals("7"))
            {
                Console.WriteLine("1. Giriş Yap");
                Console.WriteLine("2. Oyun Ekle");
                Console.WriteLine("3. Oyunları Listele");
                Console.WriteLine("4. Oyun Sil");
                Console.WriteLine("5. Oyunun Yorumlarını Göster");
                Console.WriteLine("6. Oyuna Yorum Yap");
                Console.WriteLine("7. Çıkış");
                Console.Write("Seçiminizi yapınız: ");

                secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        oyuncu = oyunYonetimi.GirisYap(kullanicilar, oyuncu);
                        break;
                    case "2":
                        if (oyuncu != null) // oyuncu var mı? yok mu?
                        {
                            Console.Write("Oyun Adını Girin: ");
                            string oyunAdi = Console.ReadLine();

                            Console.Write("Stok Adedini Girin: ");
                            string stokAdedi = Console.ReadLine();
                            if (int.TryParse(stokAdedi, out int StokAdedi))
                            {
                            }
                            else
                            {
                                Console.WriteLine("Stok adedi bir sayı olmalıdır. Yanlış girildiği için 0 a eşitlendi.");
                                StokAdedi = 0;
                            }

                            Console.Write("Oyunun Çıkış Yılını Girin: ");
                            string yil = Console.ReadLine();

                            if (int.TryParse(yil, out int cikisYili))
                            {

                            }

                            Console.Write("Oyunun Türünü Girin: ");
                            string oyunTuru = Console.ReadLine();

                            Console.Write("Oyun Çok Oyunculu Mu, Tek Oyunculu Mu? (Tek Oyunculu => 0 / Çok Oyunculu => 1): ");

                            string cokOyunculuMuTekOyunculuMu = "";
                            string girdi = Console.ReadLine();

                            while (!girdi.Equals("0") && !girdi.Equals("1"))
                            {

                                switch (girdi)
                                {
                                    case "0":
                                        cokOyunculuMuTekOyunculuMu = "Tek Oyunculu";
                                        break;
                                    case "1":
                                        cokOyunculuMuTekOyunculuMu = "Çok Oyunculu";
                                        break;
                                    default:
                                        Console.WriteLine("Yalnızca 0 ya da 1 verebilirsiniz.");
                                        break;
                                }
                            }

                            Oyun yeniOyun = new Oyun(oyunAdi, StokAdedi, cikisYili, oyunTuru, cokOyunculuMuTekOyunculuMu);

                            oyunYonetimi.OyunEkle(yeniOyun);
                        }
                        else
                        {
                            Console.WriteLine("Oyun Eklemek İçin Giriş Yapın.");
                        }
                        break;
                    case "3":
                        if (oyuncu != null) // oyuncu var mı? yok mu?
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
                        if (oyuncu != null) // oyuncu var mı? yok mu?
                        {
                            Console.Write("Yorumlarını Görmek İstediğiniz Oyunun Adını Girin: ");
                            string oyunAdi = Console.ReadLine();
                            oyunYonetimi.OyunYorumlarınıGoruntule(oyunAdi);
                        }
                        else
                        {
                            Console.WriteLine("Oyun Yorumlarını Görmek İçin Giriş Yapın.");
                        }
                        break;
                    case "6":
                        if (oyuncu != null) // oyuncu var mı? yok mu?
                        {
                            Console.Write("Yorum Yapmak İstediğiniz Oyunun Adını Girin: ");
                            string oyunAdi = Console.ReadLine();

                            Console.Write("Oyuna Verdiğiniz Puan (0 - 10) : ");
                            string puan = Console.ReadLine(); 
                            if(int.TryParse(puan, out int verilenPuan))
                            {

                            }
                            else
                            {
                                Console.WriteLine("Puan için bir sayı girmelisiniz.");
                            }

                            Console.Write("Oyun Hakkındaki Yorumunuzu Girin: ");
                            string yorum = Console.ReadLine();

                            oyunYonetimi.YorumEkle(oyuncu.KullaniciAdi, oyunAdi, yorum, verilenPuan);
                        }
                        else
                        {
                            Console.WriteLine("Yorum Yapabilmek İçin Giriş Yapın.");
                        }
                        break;
                    case "7":
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
        void YorumEkle(string oyuncuAdi, string oyunAdi, string yorumMetni, int verilenPuan);
        void OyunYorumlarınıGoruntule(string oyunAdi);
    }

    // OyunYonetimi sınıfında IOyunYonetimi interface ten metotlarını alır
    class OyunYonetimi : IOyunYonetimi
    {
        private List<Oyun> oyunlar = new List<Oyun>();

        public void OyunEkle(Oyun oyun)
        {
            oyunlar.Add(oyun);
            Console.WriteLine("Oyun başarıyla eklendi : " + oyun.Ad);
        }

        public void OyunlariListele()
        {
            Console.WriteLine("Oyunlar:");
            if (oyunlar.Count > 0)
            {
                // listedeki oyunları yazdır.
                foreach (Oyun oyun in oyunlar)
                {
                    Console.WriteLine($"Ad: {oyun.Ad}, Stok Adedi: {oyun.StokAdedi}, Türü: {oyun.OyunTuru}, Çıkış Yılı: {oyun.CikisYili}, Çok Oyunculu/Tek Oyunculu: {oyun.CokOyunculuMuTekOyunculuMu}");
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
            if (oyunlar.Count > 0)
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

        public void YorumEkle(string oyuncuAdi, string oyunAdi, string yorumMetni, int verilenPuan)
        {
            if (oyunlar.Count > 0)
            {
                // kullanıcının girdiği isimle listeki oyunları karşılaştır. Aynı isimde olan oyunu al.
                Oyun yorumlanacakOyun = oyunlar.Find(oyun => oyun.Ad.Equals(oyunAdi));

                if (yorumlanacakOyun != null) // eğer aynı isimde bir oyun varsa
                {
                    OyunDegerlendirmesi yeniYorum = new OyunDegerlendirmesi(oyuncuAdi, yorumMetni, verilenPuan);
                    yorumlanacakOyun.oyunDegerlendirmeleri.Add(yeniYorum);
                    Console.WriteLine("Yorum Eklendi.");
                }
                else // eğer aynı isimde oyun yoksa
                {
                    Console.WriteLine("Stoklarda Bu İsimde Bir Oyun Yok.");
                }
            }
            else // listenin uzunluğu 0'dan büyük değilse yani boşsa
            {
                Console.WriteLine("Oyun Bulunamadı.");
            }

        }

        public void OyunYorumlarınıGoruntule(string oyunAdi)
        {
            if (oyunlar.Count > 0)
            {
                // kullanıcının girdiği isimle listeki oyunları karşılaştır. Aynı isimde olan oyunu al.
                Oyun oyun = oyunlar.Find(oyun => oyun.Ad.Equals(oyunAdi));

                if (oyun != null) // eğer aynı isimde bir oyun varsa
                {
                    if (oyun.oyunDegerlendirmeleri.Count > 0)
                    {
                        foreach (var o in oyun.oyunDegerlendirmeleri)
                        {
                            Console.WriteLine(o.OyuncuAdi + " : " + o.Yorum.ToUpper() + " ( değerlendirme : " + o.VerilenPuan + " )");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Oyuna ait değerlendirme bulunamadı.");
                    }
                }
                else // eğer aynı isimde oyun yoksa
                {
                    Console.WriteLine("Stoklarda Bu İsimde Bir Oyun Yok.");
                }
            }
            else // listenin uzunluğu 0'dan büyük değilse yani boşsa
            {
                Console.WriteLine("Oyun Bulunamadı.");
            }
        }
    }

    class Oyuncu
    {
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public List<OyunDegerlendirmesi> OyuncuYorumlari { get; set; }

        public Oyuncu(string KullaniciAdi, string Sifre)
        {
            this.KullaniciAdi = KullaniciAdi;
            this.Sifre = Sifre;
            OyuncuYorumlari = new List<OyunDegerlendirmesi>(); // oyuncu ile beraber yorumlarının listesi de oluşturulur.
        }

    }

    class Oyun
    {
        public string Ad { get; set; }
        public string OyunTuru { get; set; }

        private int cikisYili;

        public int CikisYili
        {
            get
            {
                return cikisYili;
            }
            set
            {
                if (value >= 2000 && value <= DateTime.Now.Year)
                {
                    cikisYili = value;
                }
                else
                {
                    Console.WriteLine("Geçersiz çıkış yılı girildi!");
                    cikisYili = DateTime.Now.Year;
                }
            }

        }

        public int StokAdedi { get; set; }
        public string CokOyunculuMuTekOyunculuMu { get; set; }
        public List<OyunDegerlendirmesi> oyunDegerlendirmeleri { get; set; }

        public Oyun(string Ad, int StokAdedi, int CikisYili, string OyunTuru, string CokOyunculuMuTekOyunculuMu)
        {
            this.Ad = Ad;
            this.StokAdedi = StokAdedi;
            this.CikisYili = CikisYili;
            this.OyunTuru = OyunTuru;
            this.CokOyunculuMuTekOyunculuMu = CokOyunculuMuTekOyunculuMu;
            oyunDegerlendirmeleri = new List<OyunDegerlendirmesi>(); // oyunu oluştururken değerlendirmelerin listesini de oluştur.
        }
    }

    class OyunDegerlendirmesi
    {
        public string OyuncuAdi { get; set; }
        public string Yorum { get; set; }

        private int verilenPuan;

        public int VerilenPuan
        {
            get
            {
                return verilenPuan;
            }

            set
            {
                if(value <= 10 && value >= 0)
                {
                    verilenPuan = value;
                }
                else
                {
                    Console.WriteLine("Puan 0 ile 10 arasında girilmelidir.");
                }
            }
        }

        public OyunDegerlendirmesi(string OyuncuAdi, string Yorum, int VerilenPuan) 
        {
            this.OyuncuAdi = OyuncuAdi;
            this.Yorum = Yorum;
            this.VerilenPuan = VerilenPuan;
        }
    }

}
