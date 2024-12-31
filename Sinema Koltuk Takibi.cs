using System;
using System.Collections.Generic;
using System.Linq;



//sinama takip sistemi consol uygulamam
namespace SinemaKoltukYonetimi
{
    class Program //burada kendi izlediğim filimler vizyonda olmasını  tercih ettim
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
                    FilmId = 4,
                    FilmAdi = "mucize",
                    Salonlar = new List<Salon>
                    {
                        new Salon
                        {
                            SalonId = 4,
                            SalonAdi = "Salon 4",
                            Koltuklar = GenerateKoltuklar(3, 10)
                        }
                    }
                },
            };
            filmler.First(f => f.FilmId == 3).Salonlar.First(s => s.SalonId == 3).Koltuklar[1][3].Dolu = false;
            filmler.First(f => f.FilmId == 3).Salonlar.First(s => s.SalonId == 3).Koltuklar[1][5].Dolu = false; //bu kısımda dolu olan bi filme boş koltuklar ekledim


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

    //burada da film ,salon, koltuk sınıflarını girdim
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
