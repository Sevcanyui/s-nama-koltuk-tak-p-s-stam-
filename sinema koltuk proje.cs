//using System;
//using System.Collections.Generic;

//class Program
//{
//    static void Main()
//    {
//        // Film listesi ve salon bilgileri
//        Dictionary<string, (string salon, bool[,] koltuklar)> filmler = new Dictionary<string, (string, bool[,])>()
//        {
//            { "Film 1", ("Salon 1", new bool[3, 30]) },
//            { "Film 2", ("Salon 2", new bool[3, 30]) },
//            { "Film 3", ("Salon 3", new bool[3, 30]) },
//            { "Film 4", ("Salon 4", null) }, // Bilet kalmamış film
//            { "Film 5", ("Salon 5", null) }  // Bilet kalmamış film
//        };

//        Console.WriteLine("neko sinama salonu");

//        while (true)
//        {
//            Console.WriteLine("\n1. Filmleri Görüntüle\n2. Koltuk Rezervasyonu\n3. Rezervasyon İptali\n4. Çıkış");
//            Console.Write("Seçiminizi yapın: ");
//            string secim = Console.ReadLine();

//            switch (secim)
//            {
//                case "1":
//                    FilmleriGoruntule(filmler);
//                    break;
//                case "2":
//                    KoltukRezervasyonu(filmler);
//                    break;
//                case "3":
//                    RezervasyonIptali(filmler);
//                    break;
//                case "4":
//                    Console.WriteLine("Çıkış yapılıyor...");
//                    return;
//                default:
//                    Console.WriteLine("Geçersiz seçim, lütfen tekrar deneyin.");
//                    break;
//            }
//        }
//    }

//    static void FilmleriGoruntule(Dictionary<string, (string salon, bool[,] koltuklar)> filmler)
//    {
//        Console.WriteLine("\nVizyondaki Filmler:");
//        foreach (var film in filmler)
//        {
//            string durum = film.Value.koltuklar == null ? "TÜM BİLETLER SATILDI" : "Biletler Mevcut";
//            Console.WriteLine($"- {film.Key} ({film.Value.salon}) - {durum}");
//        }
//    }

//    static void KoltukRezervasyonu(Dictionary<string, (string salon, bool[,] koltuklar)> filmler)
//    {
//        Console.Write("\nRezervasyon yapmak istediğiniz filmi seçin: ");
//        string filmAdi = Console.ReadLine();

//        if (!filmler.ContainsKey(filmAdi) || filmler[filmAdi].koltuklar == null)
//        {
//            Console.WriteLine("Bu film için rezervasyon yapılamıyor.");
//            return;
//        }

//        bool[,] koltuklar = filmler[filmAdi].koltuklar;
//        Console.WriteLine("\nKoltuk Durumu (B: Boş, D: Dolu):");
//        KoltukDurumunuYazdir(koltuklar);

//        Console.Write("Rezervasyon yapmak istediğiniz sırayı girin (1-3): ");
//        int sira = int.Parse(Console.ReadLine()) - 1;
//        Console.Write("Rezervasyon yapmak istediğiniz koltuğu girin (1-30): ");
//        int koltuk = int.Parse(Console.ReadLine()) - 1;

//        if (koltuklar[sira, koltuk])
//        {
//            Console.WriteLine("Bu koltuk zaten dolu!");
//        }
//        else
//        {
//            koltuklar[sira, koltuk] = true;
//            Console.WriteLine("Rezervasyon başarıyla tamamlandı.");
//        }
//    }

//    static void RezervasyonIptali(Dictionary<string, (string salon, bool[,] koltuklar)> filmler)
//    {
//        Console.Write("\nRezervasyon iptali yapmak istediğiniz filmi seçin: ");
//        string filmAdi = Console.ReadLine();

//        if (!filmler.ContainsKey(filmAdi) || filmler[filmAdi].koltuklar == null)
//        {
//            Console.WriteLine("Bu film için işlem yapılamıyor.");
//            return;
//        }

//        bool[,] koltuklar = filmler[filmAdi].koltuklar;
//        Console.WriteLine("\nKoltuk Durumu (B: Boş, D: Dolu):");
//        KoltukDurumunuYazdir(koltuklar);

//        Console.Write("İptal etmek istediğiniz sırayı girin (1-3): ");
//        int sira = int.Parse(Console.ReadLine()) - 1;
//        Console.Write("İptal etmek istediğiniz koltuğu girin (1-30): ");
//        int koltuk = int.Parse(Console.ReadLine()) - 1;

//        if (!koltuklar[sira, koltuk])
//        {
//            Console.WriteLine("Bu koltuk zaten boş!");
//        }
//        else
//        {
//            koltuklar[sira, koltuk] = false;
//            Console.WriteLine("Rezervasyon iptali başarıyla tamamlandı.");
//        }
//    }

//    static void KoltukDurumunuYazdir(bool[,] koltuklar)
//    {
//        for (int i = 0; i < koltuklar.GetLength(0); i++)
//        {
//            for (int j = 0; j < koltuklar.GetLength(1); j++)
//            {
//                Console.Write(koltuklar[i, j] ? "D " : "B ");
//            }
//            Console.WriteLine();
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace SinemaKoltukYonetimi
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            // Film ve salon bilgileri
//            var filmler = new List<Film>
//            {
//                new Film
//                {
//                    FilmId = 1,
//                    FilmAdi = "Avengers: Endgame",
//                    Salonlar = new List<Salon>
//                    {
//                        new Salon
//                        {
//                            SalonId = 1,
//                            SalonAdi = "Salon 1",
//                            Koltuklar = GenerateKoltuklar(3, 10)
//                        }
//                    }
//                },
//                new Film
//                {
//                    FilmId = 2,
//                    FilmAdi = "Inception",
//                    Salonlar = new List<Salon>
//                    {
//                        new Salon
//                        {
//                            SalonId = 2,
//                            SalonAdi = "Salon 2",
//                            Koltuklar = GenerateKoltuklar(3, 8)
//                        }
//                    }
//                },
//                new Film
//                {
//                    FilmId = 3,
//                    FilmAdi = "Titanic",
//                    Salonlar = new List<Salon>
//                    {
//                        new Salon
//                        {
//                            SalonId = 3,
//                            SalonAdi = "Salon 3",
//                            Koltuklar = GenerateKoltuklar(3, 12, full: true)
//                        }
//                    }
//                },
//                new Film
//                {
//                    FilmId = 4,
//                    FilmAdi = "Joker",
//                    Salonlar = new List<Salon>
//                    {
//                        new Salon
//                        {
//                            SalonId = 4,
//                            SalonAdi = "Salon 4",
//                            Koltuklar = GenerateKoltuklar(3, 15, full: true)
//                        }
//                    }
//                },
//                new Film
//                {
//                    FilmId = 5,
//                    FilmAdi = "Interstellar",
//                    Salonlar = new List<Salon>
//                    {
//                        new Salon
//                        {
//                            SalonId = 5,
//                            SalonAdi = "Salon 5",
//                            Koltuklar = GenerateKoltuklar(3, 20)
//                        }
//                    }
//                }
//            };

//            while (true)
//            {
//                Console.Clear();
//                Console.WriteLine("=== Sinema Koltuk Yönetim Sistemi ===\n");
//                FilmTablosuGoster(filmler);

//                Console.Write("Hangi filmi izlemek istersiniz? (Film ID girin): ");
//                if (!int.TryParse(Console.ReadLine(), out int filmId))
//                {
//                    Console.WriteLine("Geçersiz giriş. Devam etmek için bir tuşa basın...");
//                    Console.ReadKey();
//                    continue;
//                }

//                var secilenFilm = filmler.FirstOrDefault(f => f.FilmId == filmId);
//                if (secilenFilm == null)
//                {
//                    Console.WriteLine("Film bulunamadı. Devam etmek için bir tuşa basın...");
//                    Console.ReadKey();
//                    continue;
//                }

//                Console.WriteLine($"Seçtiğiniz film: {secilenFilm.FilmAdi}\nSalonlar:");
//                foreach (var salon in secilenFilm.Salonlar)
//                {
//                    Console.WriteLine($"Salon ID: {salon.SalonId}, Adı: {salon.SalonAdi}");
//                }

//                Console.Write("Hangi salonu seçmek istersiniz? (Salon ID girin): ");
//                if (!int.TryParse(Console.ReadLine(), out int salonId))
//                {
//                    Console.WriteLine("Geçersiz giriş. Devam etmek için bir tuşa basın...");
//                    Console.ReadKey();
//                    continue;
//                }

//                var secilenSalon = secilenFilm.Salonlar.FirstOrDefault(s => s.SalonId == salonId);
//                if (secilenSalon == null)
//                {
//                    Console.WriteLine("Salon bulunamadı. Devam etmek için bir tuşa basın...");
//                    Console.ReadKey();
//                    continue;
//                }

//                Console.WriteLine($"Seçtiğiniz salon: {secilenSalon.SalonAdi}\n");
//                KoltukDurumunuGoster(secilenSalon);

//                Console.Write("Bir koltuk numarası seçin (ör: 1-3:5 sırasındaki 5. koltuk): ");
//                var koltukBilgi = Console.ReadLine()?.Split(':');
//                if (koltukBilgi == null || koltukBilgi.Length != 2 || !int.TryParse(koltukBilgi[0], out int sira) || !int.TryParse(koltukBilgi[1], out int koltuk))
//                {
//                    Console.WriteLine("Geçersiz giriş. Devam etmek için bir tuşa basın...");
//                    Console.ReadKey();
//                    continue;
//                }

//                if (sira <= 0 || sira > secilenSalon.Koltuklar.Count || koltuk <= 0 || koltuk > secilenSalon.Koltuklar[sira - 1].Count)
//                {
//                    Console.WriteLine("Geçersiz koltuk numarası. Devam etmek için bir tuşa basın...");
//                    Console.ReadKey();
//                    continue;
//                }

//                var secilenKoltuk = secilenSalon.Koltuklar[sira - 1][koltuk - 1];
//                if (secilenKoltuk.Dolu)
//                {
//                    Console.WriteLine("Seçtiğiniz koltuk zaten dolu. Devam etmek için bir tuşa basın...");
//                }
//                else
//                {
//                    secilenKoltuk.Dolu = true;
//                    Console.WriteLine($"{sira}:{koltuk} numaralı koltuk başarıyla rezerve edildi!");
//                }
//                Console.ReadKey();
//            }
//        }

//        static void FilmTablosuGoster(List<Film> filmler)
//        {
//            Console.WriteLine("Mevcut Filmler:");
//            foreach (var film in filmler)
//            {
//                Console.WriteLine($"Film ID: {film.FilmId}, Adı: {film.FilmAdi}");
//            }
//        }

//        static void KoltukDurumunuGoster(Salon salon)
//        {
//            Console.WriteLine("Koltuk Durumu (X: Dolu, O: Boş):");
//            for (int i = 0; i < salon.Koltuklar.Count; i++)
//            {
//                Console.Write($"Sıra {i + 1}: ");
//                foreach (var koltuk in salon.Koltuklar[i])
//                {
//                    Console.Write(koltuk.Dolu ? "[X] " : "[O] ");
//                }
//                Console.WriteLine();
//            }
//        }

//        static List<List<Koltuk>> GenerateKoltuklar(int siraSayisi, int koltukSayisi, bool full = false)
//        {
//            var koltuklar = new List<List<Koltuk>>();
//            for (int i = 0; i < siraSayisi; i++)
//            {
//                var sira = new List<Koltuk>();
//                for (int j = 0; j < koltukSayisi; j++)
//                {
//                    sira.Add(new Koltuk { KoltukNo = j + 1, Dolu = full });
//                }
//                koltuklar.Add(sira);
//            }
//            return koltuklar;
//        }
//    }

//    class Film
//    {
//        public int FilmId { get; set; }
//        public string FilmAdi { get; set; }
//        public List<Salon> Salonlar { get; set; }
//    }

//    class Salon
//    {
//        public int SalonId { get; set; }
//        public string SalonAdi { get; set; }
//        public List<List<Koltuk>> Koltuklar { get; set; }
//    }

//    class Koltuk
//    {
//        public int KoltukNo { get; set; }
//        public bool Dolu { get; set; }
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;

namespace SinemaKoltukYonetimi
{
    class Program
    {
        static void Main(string[] args)
        {
            var filmler = new List<Film>
            {
                new Film
                {
                    FilmId = 1,
                    FilmAdi = "Piyanist",
                    Salonlar = new List<Salon>
                    {
                        new Salon
                        {
                            SalonId = 1,
                            SalonAdi = "Salon 1",
                            Koltuklar = GenerateKoltuklar(3, 10)
                        }
                    }
                },
                new Film
                {
                    FilmId = 2,
                    FilmAdi = "SEV7N",
                    Salonlar = new List<Salon>
                    {
                        new Salon
                        {
                            SalonId = 2,
                            SalonAdi = "Salon 2",
                            Koltuklar = GenerateKoltuklar(3, 8)
                        }
                    }
                },
                new Film
                {
                    FilmId = 3,
                    FilmAdi = "Parazit",
                    Salonlar = new List<Salon>
                    {
                        new Salon
                        {
                            SalonId = 3,
                            SalonAdi = "Salon 3",
                            Koltuklar = GenerateKoltuklar(3, 12, full: true)
                        }
                    }
                },
                 new Film
                {
                    FilmId = 1,
                    FilmAdi = "mucize",
                    Salonlar = new List<Salon>
                    {
                        new Salon
                        {
                            SalonId = 1,
                            SalonAdi = "Salon 1",
                            Koltuklar = GenerateKoltuklar(3, 10)
                        }
                    }
                },
            };
            filmler.First(f => f.FilmId == 3).Salonlar.First(s => s.SalonId == 3).Koltuklar[1][3].Dolu = false;
            filmler.First(f => f.FilmId == 3).Salonlar.First(s => s.SalonId == 3).Koltuklar[1][5].Dolu = false;


            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Sinema Koltuk Yönetim Sistemi ===\n");
                FilmTablosuGoster(filmler);

                Console.Write("Hangi filmi izlemek istersiniz? (Film ID girin): ");
                if (!int.TryParse(Console.ReadLine(), out int filmId))
                {
                    Console.WriteLine("Geçersiz giriş. Devam etmek için bir tuşa basın...");
                    Console.ReadKey();
                    continue;
                }

                var secilenFilm = filmler.FirstOrDefault(f => f.FilmId == filmId);
                if (secilenFilm == null)
                {
                    Console.WriteLine("Film bulunamadı. Devam etmek için bir tuşa basın...");
                    Console.ReadKey();
                    continue;
                }

                Console.WriteLine($"Seçtiğiniz film: {secilenFilm.FilmAdi}\nSalonlar:");
                foreach (var salon in secilenFilm.Salonlar)
                {
                    Console.WriteLine($"Salon ID: {salon.SalonId}, Adı: {salon.SalonAdi}");
                }

                Console.Write("Hangi salonu seçmek istersiniz? (Salon ID girin): ");
                if (!int.TryParse(Console.ReadLine(), out int salonId))
                {
                    Console.WriteLine("Geçersiz giriş. Devam etmek için bir tuşa basın...");
                    Console.ReadKey();
                    continue;
                }

                var secilenSalon = secilenFilm.Salonlar.FirstOrDefault(s => s.SalonId == salonId);
                if (secilenSalon == null)
                {
                    Console.WriteLine("Salon bulunamadı. Devam etmek için bir tuşa basın...");
                    Console.ReadKey();
                    continue;
                }

                Console.WriteLine($"Seçtiğiniz salon: {secilenSalon.SalonAdi}\n");
                KoltukDurumunuGoster(secilenSalon);

                Console.Write("Bir koltuk seçin (ör. Sıra: 2, Koltuk: 5):\nSıra numarası: ");
                if (!int.TryParse(Console.ReadLine(), out int sira) || sira <= 0 || sira > secilenSalon.Koltuklar.Count)
                {
                    Console.WriteLine("Geçersiz sıra numarası. Devam etmek için bir tuşa basın...");
                    Console.ReadKey();
                    continue;
                }

                Console.Write("Koltuk numarası: ");
                if (!int.TryParse(Console.ReadLine(), out int koltuk) || koltuk <= 0 || koltuk > secilenSalon.Koltuklar[sira - 1].Count)
                {
                    Console.WriteLine("Geçersiz koltuk numarası. Devam etmek için bir tuşa basın...");
                    Console.ReadKey();
                    continue;
                }

                var secilenKoltuk = secilenSalon.Koltuklar[sira - 1][koltuk - 1];
                if (secilenKoltuk.Dolu)
                {
                    Console.WriteLine("Seçtiğiniz koltuk zaten dolu. Devam etmek için bir tuşa basın...");
                }
                else
                {
                    secilenKoltuk.Dolu = true;
                    Console.WriteLine($"Sıra {sira}, Koltuk {koltuk} başarıyla rezerve edildi!");
                }
                Console.ReadKey();
            }
        }

        static void FilmTablosuGoster(List<Film> filmler)
        {
            Console.WriteLine("Mevcut Filmler:");
            foreach (var film in filmler)
            {
                Console.WriteLine($"Film ID: {film.FilmId}, Adı: {film.FilmAdi}");
            }
        }

        static void KoltukDurumunuGoster(Salon salon)
        {
            Console.WriteLine("Koltuk Durumu (X: Dolu, O: Boş):");
            for (int i = 0; i < salon.Koltuklar.Count; i++)
            {
                Console.Write($"Sıra {i + 1}: ");
                foreach (var koltuk in salon.Koltuklar[i])
                {
                    Console.Write(koltuk.Dolu ? "[X] " : "[O] ");
                }
                Console.WriteLine();
            }
        }

        static List<List<Koltuk>> GenerateKoltuklar(int siraSayisi, int koltukSayisi, bool full = false)
        {
            var koltuklar = new List<List<Koltuk>>();
            for (int i = 0; i < siraSayisi; i++)
            {
                var sira = new List<Koltuk>();
                for (int j = 0; j < koltukSayisi; j++)
                {
                    sira.Add(new Koltuk { KoltukNo = j + 1, Dolu = full });
                }
                koltuklar.Add(sira);
            }
            return koltuklar;
        }
    }

    class Film
    {
        public int FilmId { get; set; }
        public string FilmAdi { get; set; }
        public List<Salon> Salonlar { get; set; }
    }

    class Salon
    {
        public int SalonId { get; set; }
        public string SalonAdi { get; set; }
        public List<List<Koltuk>> Koltuklar { get; set; }
    }

    class Koltuk
    {
        public int KoltukNo { get; set; }
        public bool Dolu { get; set; }
    }
}
