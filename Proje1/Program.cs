using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1_1_0521
{
    internal class Program
    {
        public class Mesafe_hesap
        {
            int[][] il_mesafeleri = null;
            String[] il_adlari = null;


            public Mesafe_hesap(int[][] il_mesafeleri, String[] il_adlari)
            {
                this.il_mesafeleri = il_mesafeleri;
                this.il_adlari = il_adlari;
            }


            //Verilen ilden belli bir uzaklığa kadar olan illerin ve uzaklıklarının listelenmesi
            public void istenen_iller_arasi_uzaklik(int uzaklik, String il_ad = null, int plaka = -1)
            {
                //Verilen plaka numarası ya da girilen şehir ismiyle belirlenen şehirin il_mesafeleri listesindeki index değeri.
                int index = -1;
                if (il_ad == null)
                {
                    index = plaka - 1;
                }
                else
                {
                    index = plaka_noya_cevir(il_ad) - 1;
                }
                // İstenilen ilin kendisine kadar olan illerin o ile uzaklığının listesi. 
                //Örneğin index değeri 5 ise, bu listede Amasya iline kadar olan illerin uzaklıkları yazılır. Çünkü listemiz jagged array biçiminde.
                int[] o_ile_kadar = il_mesafeleri[index];
                int il_adet = 0;

                for (int i = 0; i < 81; i++)
                {
                    if ((i < index) && (uzaklik >= o_ile_kadar[i]))
                    {
                        il_adet++;
                        Console.WriteLine($"{il_adet}.il: {il_adlari[i]}. Bu ilin {il_adlari[index]} iline olan uzaklığı {o_ile_kadar[i]}km.");
                    }
                    else if (i > index)
                    {
                        if (uzaklik >= il_mesafeleri[i][index])//Burda verilen index istenilen ilin bulunduğu sütun değeridir. Yani sanki yukarıdan aşağıya bakılıyor gibi.
                        {
                            il_adet++;
                            Console.WriteLine($"{il_adet}.il: {il_adlari[i]}. Bu ilin {il_adlari[index]} iline olan uzaklığı {il_mesafeleri[i][index]}km.");


                        }
                    }
                }

                Console.WriteLine($"{il_adlari[index]} iline en fazla {uzaklik} kilometre uzaklıkta bulunan illerin sayisi :{il_adet} ");


            }


            //Verilen şehir adını plaka numarasına çevirir.
            public int plaka_noya_cevir(String il_ad)
            {
                return Array.IndexOf(il_adlari, il_ad) + 1;
            }


            //Bir birine en uzak olan iki il, uzaklık ve isim bilgileriyle ekrana yazdırılır.
            public void en_uzak_iki_il()
            {
                int satir_index = 0; //il_mesafeleri jagged arrayinde yer alan en uzak mesafe değerinin satir numarası.
                int max_uzaklik = 0; // En uzak mesafe değeri

                for (int row = 1; row < 81; row++)
                {  //row değerinin 1 den başlama nedeni jagged arrayin ilk değeri satiri null. (Çünkü ADANA'NIN ADANA'YA uzaklığı yok.)
                    for (int col = 0; col < il_mesafeleri[row].Length; col++)
                    {
                        if (il_mesafeleri[row][col] > max_uzaklik)
                        {
                            satir_index = row;
                            max_uzaklik = il_mesafeleri[row][col];
                        }

                    }

                }
                String il_1 = il_adlari[satir_index];
                String il_2 = il_adlari[Array.IndexOf(il_mesafeleri[satir_index], max_uzaklik)];//Bu kısımda ulaşılan satır değerinde, max_uzaklik değerinin kolon numarasından ismine ulaşılıyor.

                Console.WriteLine($"{il_1} ili ile {il_2} ili bir birine en uzak olan iki ildir. Uzaklık değeri : {max_uzaklik}km");



            }


            //Bir birine en uzak olan iki il, uzaklık ve isim bilgileriyle ekrana yazdırılır.
            public void en_yakin_iki_il()
            {
                int satir_index = 0; //il_mesafeleri jagged arrayinde yer alan en yakin mesafe değerinin satir numarası.
                int min_uzaklik = 10000; // En yaki mesafe değeri. Başlangıç olarak , mümkün olmayan bir değer atandı.

                for (int row = 1; row < 81; row++)
                {  //row değerinin 1 den başlama nedeni jagged arrayin ilk değeri satiri null. (Çünkü ADANA'NIN ADANA'YA uzaklığı yok.)
                    for (int col = 0; col < il_mesafeleri[row].Length; col++)
                    {
                        if (il_mesafeleri[row][col] < min_uzaklik)
                        {
                            satir_index = row;
                            min_uzaklik = il_mesafeleri[row][col];
                        }

                    }

                }
                String il_1 = il_adlari[satir_index];
                String il_2 = il_adlari[Array.IndexOf(il_mesafeleri[satir_index], min_uzaklik)];//Bu kısımda ulaşılan satır değerinde, min_uzaklik değerinin kolon numarasından ismine ulaşılıyor.

                Console.WriteLine($"{il_1} ili ile {il_2} ili bir birine en yakın olan iki ildir. Uzaklık değeri : {min_uzaklik}km");



            }

            //5 farklı illerin bir birine olan uzaklıklarının yer aldığı matris ekrana yazdırılır.
            public void farkli_5_il_matrisi()
            {
                int[][] matris = new int[5][];

                //Random plaka elde etme kısmı...
                int[] random_plakalar = new int[5];
                String[] random_plaka_isimler = new string[5];
                int index = 0;
                Random r = new Random();
                while (index < 5)
                {
                    int random_num = r.Next(1, 82);
                    if (!random_plakalar.Contains(random_num))
                    {
                        random_plakalar[index] = random_num;

                        index++;
                    }
                }
                Array.Sort(random_plakalar);
                for (int i = 0; i < 5; i++)
                {
                    random_plaka_isimler[i] = il_adlari[random_plakalar[i] - 1];
                }
                //....

                // Matrise değerlerin eklenmesi...
                for (int row = 0; row < 5; row++)
                {
                    int[] uzakliklar = new int[5];
                    int rowdaki_sehir_plaka = random_plakalar[row] - 1;
                    for (int col = 0; col < 5; col++)
                    {
                        int coldaki_sehir_plaka = random_plakalar[col] - 1;
                        if (row == col)// Eğer matrisin köşegeni ise 
                        {
                            uzakliklar[col] = 0;
                            continue;

                        }
                        else if (row > col)
                        /* il_mesafeleri bir jagged array dolayısıyla kendisinden küçük plakalı olanlarda onların mesafelerini araştırmak için
                        plaka numarası büyük olan ilin bulunduğu satırdan mesafeye bakılıyor.*/
                        {
                            uzakliklar[col] = il_mesafeleri[rowdaki_sehir_plaka][coldaki_sehir_plaka];
                            continue;
                        }

                        // bu durumda da eğer row değeri col değerinden küçük kaldığı durumlara baklıyor. Eğer bölye durum olursa 
                        // bu durumda da col değeri satır değeri olarak veriliyor. Yani üstteki durumun tam tersi.
                        uzakliklar[col] = il_mesafeleri[coldaki_sehir_plaka][rowdaki_sehir_plaka];


                    }
                    matris[row] = uzakliklar;

                }


                //....


                // Matrisin yazdırılması....

                Console.Write(" ".PadRight(15));
                foreach (string city in random_plaka_isimler)
                {
                    Console.Write($"{city}".PadLeft(15));
                }

                Console.WriteLine();


                for (int i = 0; i < random_plaka_isimler.Length; i++)
                {

                    Console.Write($"{random_plaka_isimler[i]}".PadRight(15));
                    for (int j = 0; j < random_plaka_isimler.Length; j++)
                    {
                        Console.Write($"{matris[i][j],15}");
                    }
                    Console.WriteLine();
                }
            }

            //Jagged arraydeki illerin bir birine olan uzaklığı matris haline getiriliyor.
            public int[,] jagged_array_to_matris()
            {
                int[,] matris = new int[81, 81];
                int[][] jg_array = il_mesafeleri;

                for (int i = 0; i < 81; i++)
                {
                    for (int j = 0; j < 81; j++)
                    {
                        if (i == j) { matris[i, j] = 0; }
                        else if (j > i) { matris[i, j] = jg_array[j][i]; }
                        else
                        {
                            matris[i, j] = jg_array[i][j];
                        }
                    }
                }
                return matris;
            }

            //Verilen ilden verilen mesafe kullanılarak en fazla kaç il dolaşabileceğini listeler. 
            public void en_cok_il_yolu(string il_ad, int max_mesafe, List<string> gezilen_iller, List<string> enfazlailyolu)
            {
                if (max_mesafe <= 0 || gezilen_iller.Contains(il_ad))
                {
                    return;
                }
                gezilen_iller.Add(il_ad);


                int komsu_il_katsayisi = 7;
                int il_index = Array.IndexOf(il_adlari, il_ad);
                int[,] iller_matrisi = jagged_array_to_matris();
                int[] komsu_iller = new int[komsu_il_katsayisi];
                int[] ile_olan_uzakliklar = new int[81]; //Bu liste sıralanma amacıyla oluşturuluyor.
                int[] ile_olan_uzakliklar2 = new int[81];
                for (int i = 0; i < 81; i++)
                {
                    ile_olan_uzakliklar[i] = iller_matrisi[il_index, i];
                    ile_olan_uzakliklar2[i] = iller_matrisi[il_index, i];
                }
                Array.Sort(ile_olan_uzakliklar);
                for (int i = 0; i < komsu_il_katsayisi; i++)
                {
                    komsu_iller[i] = Array.IndexOf(ile_olan_uzakliklar2, ile_olan_uzakliklar[i]);

                }
                if (gezilen_iller.Count > enfazlailyolu.Count)
                {
                    enfazlailyolu.Clear();
                    enfazlailyolu.AddRange(gezilen_iller);
                }


                for (int i = 0; i < komsu_iller.Length; i++)
                {
                    if (ile_olan_uzakliklar2[komsu_iller[i]] <= max_mesafe)
                    {
                        if ((!gezilen_iller.Contains(il_adlari[komsu_iller[i]])))
                        {
                            en_cok_il_yolu(il_adlari[komsu_iller[i]], max_mesafe - ile_olan_uzakliklar2[komsu_iller[i]], gezilen_iller, enfazlailyolu);
                        }
                    }
                }
                gezilen_iller.Remove(il_ad);


            }

            //en_cok_il_yolu metodundan elde edilen liste ekrana yazdırma işlemini yapar.
            public void en_cok_il_yolu_yazdir(string il_ad, int max_mesafe)
            {
                List<string> enfazlailyolu = new List<string>();
                List<String> gezilen_iller = new List<String>();
                int[,] matris = jagged_array_to_matris();
                int sayac = 0;
                en_cok_il_yolu(il_ad, max_mesafe, gezilen_iller, enfazlailyolu);
                int gezilen_mesafe = 0;

                foreach (String s in enfazlailyolu)
                {
                    Console.WriteLine(s);
                    Console.WriteLine("|".PadLeft(3));
                    Console.WriteLine("V".PadLeft(3));
                    if (sayac + 1 < enfazlailyolu.Count)
                    {
                        int iki_il_arasi_mesafe = matris[Array.IndexOf(il_adlari, s), Array.IndexOf(il_adlari, enfazlailyolu[sayac + 1])];
                        Console.Write((iki_il_arasi_mesafe + "km"));
                        Console.WriteLine();
                        gezilen_mesafe += iki_il_arasi_mesafe;
                    }
                    sayac++;
                }
                Console.WriteLine($"Gezilen toplam mesafe {gezilen_mesafe}km.\nGezilen toplam il adedi (başlangıç ili dahil) {enfazlailyolu.Count}.");
            }
        }
        static void Main(string[] args)
        {
            String[] iller_adlari = {
                                "ADANA", "ADIYAMAN", "AFYONKARAHİSAR", "AĞRI", "AMASYA",
                                "ANKARA", "ANTALYA", "ARTVİN", "AYDIN", "BALIKESİR",
                                "BİLECİK", "BİNGÖL", "BİTLİS", "BOLU", "BURDUR",
                                "BURSA", "ÇANAKKALE", "ÇANKIRI", "ÇORUM", "DENİZLİ",
                                "DİYARBAKIR", "EDİRNE", "ELAZIĞ", "ERZİNCAN", "ERZURUM",
                                "ESKİŞEHİR", "GAZİANTEP", "GİRESUN", "GÜMÜŞHANE", "HAKKARİ",
                                "HATAY", "ISPARTA", "MERSİN", "İSTANBUL", "İZMİR",
                                "KARS", "KASTAMONU", "KAYSERİ", "KIRKLARELİ", "KIRŞEHİR",
                                "KOCAELİ (İZMİT)", "KONYA", "KÜTAHYA", "MALATYA", "MANİSA",
                                "KAHRAMANMARAŞ", "MARDİN", "MUĞLA", "MUŞ", "NEVŞEHİR",
                                "NİĞDE", "ORDU", "RİZE", "SAKARYA (ADAPAZARI)", "SAMSUN",
                                "SİİRT", "SİNOP", "SİVAS", "TEKİRDAĞ", "TOKAT",
                                "TRABZON", "TUNCELİ", "ŞANLIURFA", "UŞAK", "VAN",
                                "YOZGAT", "ZONGULDAK", "AKSARAY", "BAYBURT", "KARAMAN",
                                "KIRIKKALE", "BATMAN", "ŞIRNAK", "BARTIN", "ARDAHAN",
                                "IĞDIR", "YALOVA", "KARABÜK", "KİLİS", "OSMANİYE", "DÜZCE"};

            int[][] jagged_array = dosyak_oku();
            Mesafe_hesap mh = new Mesafe_hesap(jagged_array, iller_adlari);
            jagged_Array_yazdir(jagged_array, iller_adlari);


        }

        //Dosya okuma işlemini gerçekleştirir.
        static int[][] dosyak_oku()
        {
            int[][] jagged_array = new int[81][];
            int sayac = 0;
            string dosyaYolu = @"C:\Users\melih\OneDrive\Masaüstü\ilmesafe.txt";
            using (StreamReader sr = new StreamReader(dosyaYolu))
            {
                string satir;

                while ((satir = sr.ReadLine()) != null)
                {
                    string[] bilgiler = satir.Split('	');
                    int[] il_bilgisi = new int[sayac];

                    for (int index = 2; index < bilgiler.Length; index++)
                    {
                        if ((bilgiler[index] == ""))
                        {
                            break;

                        }
                        il_bilgisi[index - 2] = Convert.ToInt16(bilgiler[index]);


                    }
                    jagged_array[sayac] = il_bilgisi;
                    sayac++;
                }
            }
            return jagged_array;
        }

        // Jagged arrayin yazdırma işlemini yapar fakat sadece ilk 20 il için. Nedeni konsolda 20 den sonrasınının gösterimi daha karışık gözükmesidir.
        static void jagged_Array_yazdir(int[][] jagged_array, string[] il_adlari)
        {
            Console.Write(" ".PadLeft(17));
            for (int i = 0; i < 21; i++)
            {
                Console.Write($"{i}".PadRight(5));
            }
            Console.WriteLine();
            for (int i = 0; i < jagged_array.Length; i++)
            {
                Console.Write(il_adlari[i].PadRight(17));
                for (int j = 0; j < jagged_array[i].Length; j++)
                {
                    Console.Write($"{jagged_array[i][j]}".PadRight(5));

                }
                Console.WriteLine();
                if (i == 21) { break; }
            }

        }
    }
}

