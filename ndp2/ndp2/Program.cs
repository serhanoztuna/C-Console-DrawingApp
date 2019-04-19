/****************************************************************************
**					SAKARYA UNIVERSITY
**				    BILGISAYAR MUHENDISLIGI BOLUMU
**				      NESNEYE DAYALI PROGRAMLAMA 
**				
**				OGRENCI ISMI.....:SERHAN 
**				OGRENCI SOYISMI..:ÖZTUNA
**
**				
****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndp2
{// Kullanmak icin tek yapmaniz gereken asagidaki gibi cagri yapmaktri
 //RastgeleSayi.SayiUret(1,100);
 //yukaridaki cagri 1 ile 100 arasinda rastgele bir sayi uretecektir
    class RastgeleSayi
    {
        public static int SayiUret(int min, int max)
        {
            if (rastgele == null)
                rastgele = new Random();

            return rastgele.Next(min, max);
        }

        private static Random rastgele;
    }
    ///Sinif uyeleri statik oldugu icin asagidaki gibi erisim yapilabilir

    ///KarakterSeti.SolUstKose

    ///Ekrana Cikartmak icin

    ///Console.Write(KarakterSeti.SolUstKose);
    class KarakterSeti//karakter sınıfı
    {

        public static char SolUstKose = '╔';
        public static char SagUstKose = '╗';
        public static char Duz = '═';
        public static char Dikey = '║';
        public static char SolAltKose = '╚';
        public static char SagAltKose = '╝';

    }
    class Dortgen
    {
        
        public Dortgen() { }

        public Dortgen(int xSinir, int ySinir)//rastgele renk genislik ve yukseklik uretiliyor
        {
            renk = (ConsoleColor)RastgeleSayi.SayiUret(1, 15);
            genislik = RastgeleSayi.SayiUret(2, 20);
            yukseklik = RastgeleSayi.SayiUret(2, 20);
            x = RastgeleSayi.SayiUret(2, 20);
            y = RastgeleSayi.SayiUret(2, 20);
            
        }
        public void Ciz()//rastgele değerler ile e tuşuna basildiğinda dikdörtgen yaziliyor
        {
            ConsoleColor eski = Console.ForegroundColor;
            Console.ForegroundColor = renk;
            TepeCiz(genislik, x, y);
            DikeyCiz(genislik, yukseklik, x, y);
            TabanCiz(genislik, yukseklik, x, y);
            Console.ForegroundColor = eski;
            

            
        }
        public void DikeyCiz(int genislik,int yukseklik,int baslangicx,int baslangicy)
        {
            for (int j =baslangicy+1; j < yukseklik+baslangicy; j++)//dikdörtgenin sağ ve sol  kısmı sinir değerlerine göre yazdırılıyor.
            {
                Console.SetCursorPosition(baslangicx, j);
                Console.Write(KarakterSeti.Dikey);
                for (int i = baslangicx+1; i < genislik+baslangicx; i++)
                {
                    Console.SetCursorPosition(i, j+baslangicy);
                    Console.Write(" ");
                }
                Console.SetCursorPosition(baslangicx+genislik, j );
                Console.Write(KarakterSeti.Dikey);
                
                
                Console.WriteLine();

            }

            
        }
        public void TepeCiz(int genislik,int baslangicx,int baslangicy)//dikdörtgenin üst kısmı sinir değerlerine göre yazdırılıyor.
        {
            Console.SetCursorPosition(baslangicx, baslangicy);
            Console.Write(KarakterSeti.SolUstKose);
            for(int i=(baslangicx+1);i<genislik+baslangicx;i++)
            {
                Console.SetCursorPosition(i,baslangicy);
                Console.Write(KarakterSeti.Duz);
            }
            Console.SetCursorPosition(genislik+baslangicx, baslangicy);
            Console.Write(KarakterSeti.SagUstKose);
            Console.WriteLine();
           
        }
        public void TabanCiz(int genislik,int yukseklik, int baslangicx,int baslangicy)//dikdörtgenin alt  kısmı sinir değerlerine göre yazdırılıyor.
        {
            Console.SetCursorPosition(baslangicx, yukseklik+baslangicy);
            Console.Write(KarakterSeti.SolAltKose);
            for (int i=baslangicx+1;i<genislik+baslangicx;i++)
            {
                Console.SetCursorPosition(i,yukseklik+baslangicy);
                Console.Write(KarakterSeti.Duz);
            }
            Console.SetCursorPosition(genislik+baslangicx,yukseklik+baslangicy);
            Console.Write(KarakterSeti.SagAltKose);
            Console.WriteLine();
        }
        public void KonumAta(int x, int y)
        {
            
        }
        public void BoyutAta(int genislik, int yukseklik) { }
        public void RenkAta(ConsoleColor renk) { }
        public void SolaOtele()
        {
            if(x>1)
            x = x - 1;
        }//a tuşuna basildiğinda dikdörtgen bir sola öteleniyor 
        public void SagaOtele()
        {
            if(x+genislik<49)
            x = x + 1;

        }//d tuşuna basildiğinda dikdörtgen bir sağaöteleniyor 
        public void YukariOtele()
        {
            if(y>1)
            y = y - 1;
        }//w tuşuna basildiğinda dikdörtgen bir yukarı öteleniyor 
        public void AsagiOtele()
        {
            if (y+yukseklik < 35 )
                y = y + 1;
        }//s tuşuna basildiğinda dikdörtgen bir aşağı öteleniyor 
        public int genislik;
        public int yukseklik;
        public ConsoleColor renk;
        public int x;
        public int y;
        private int xSinir;
        private int ySinir;

    }
    class SahnePaneli
    {
        public SahnePaneli(int genislik, int yukseklik)//sahne paneli çizdiriliyor.
        {
            renk = ConsoleColor.Green;
            ConsoleColor eski = Console.ForegroundColor;
            Console.ForegroundColor = renk;
            Dortgen drtgn = new Dortgen();
            drtgn.TepeCiz(50, 0, 0);//sahne paneline değerler veriliyor.
            drtgn.DikeyCiz(50, 35, 0, 0);
            drtgn.TabanCiz(50, 35, 0, 0);
            Console.ForegroundColor = eski;
            sekilSayisi = 0;
            sekiller = new Dortgen[100];
            
        }
        public  void KonumAta(int x, int y)//console temizlendikten sonra tekrar sahne paneli çizdiriliyor
        {
            renk = ConsoleColor.Green;
            ConsoleColor eski = Console.ForegroundColor;
            Console.ForegroundColor = renk;
            Dortgen drtgn = new Dortgen();
            drtgn.TepeCiz(50, 0, 0);
            drtgn.DikeyCiz(50, 35, 0, 0);
            drtgn.TabanCiz(50, 35, 0, 0);
            Console.ForegroundColor = eski;
        }
        public void Ciz()
        {
            
            Dortgen sa = new Dortgen();
            sa.TepeCiz(genislik, x, y);
            sa.DikeyCiz(genislik, yukseklik, x, y);
            sa.TabanCiz(genislik, yukseklik, x, y);
            if (sekilSayisi  < 100)//sekil sayisi 100 olana kadar yeni dikdörtgen çizdirilme kontrolü yapılıyor.
            {
                sekiller[sekilSayisi] = new Dortgen(10, 10);
                sekilSayisi++;
            }
            for(int i=0;i<sekilSayisi;i++)//yeni dikdörtgen diziye ekleniyor ve şekil sayisi arttırılıyor.
            {
                sekiller[i].Ciz();
                aktifSekil = sekiller[i];
                
                   
            }
        }
        public void AktifSekilAta(Dortgen yeniSekil)
        {
           
        }
        public void SekilSolaOtele()
        {
            aktifSekil.SolaOtele();
            aktifSekil.Ciz();
            for (int i = 0; i < sekilSayisi; i++)
            {

                sekiller[i].Ciz();
                aktifSekil = sekiller[i];
            }
        }//sekil sola ötele fonksiyonu 
        public void SekilSagaOtele()
        {
            aktifSekil.SagaOtele();
            aktifSekil.Ciz();
            for (int i = 0; i < sekilSayisi; i++)
            {

                sekiller[i].Ciz();
                aktifSekil = sekiller[i];
            }
        }//sekil sağa ötele fonksiyonu 
        public void SekilYukariOtele()
        {
            aktifSekil.YukariOtele();
            aktifSekil.Ciz();
            for (int i = 0; i < sekilSayisi; i++)
            {

                sekiller[i].Ciz();
                aktifSekil = sekiller[i];
            }
        }//sekil yukarı ötele fonksiyonu 
        public void SekilAsagiOtele()
        {
            aktifSekil.AsagiOtele();
            aktifSekil.Ciz();
            for (int i = 0; i < sekilSayisi; i++)
            {

                sekiller[i].Ciz();
                aktifSekil = sekiller[i];
            }
        }//sekil asağı ötele fonksiyonu 
         // public bool SekillerCarpisiyormu() { }
        private int genislik;
        private int yukseklik;
        private int x;
        private int y;
        private Dortgen cizimAlani;
        public Dortgen aktifSekil;
        private int sekilSayisi;
        private int maksimumSekilSayisi;
        private Dortgen[] sekiller;
        private ConsoleColor renk;
    }
    class KontrolPaneli
    {
    public KontrolPaneli(int genislik, int yukseklik) { }
    public void Ciz() {//kontrol paneli çizdiriliyor
           
            renk = ConsoleColor.Cyan;
            ConsoleColor eski = Console.ForegroundColor;
            Console.ForegroundColor = renk;
            Dortgen sa = new Dortgen();
             sa.TepeCiz(25,51,0);
             sa.DikeyCiz(25,20,51,0);
             sa.TabanCiz(25,20,51,0);
            Console.ForegroundColor = eski;
        }
    public void KonumAta(int x, int y) {}
    public void MenuCiz()//menü bilgileri yazdırılıyor.
        {
            Console.SetCursorPosition(55, 5);
            Console.WriteLine("KONTROL PANELİ:");
            Console.SetCursorPosition(55, 7);
            Console.WriteLine("Şekil Ekle ( E )");
            Console.SetCursorPosition(55, 9);
            Console.WriteLine("Sola Ötele ( A ) ");
            Console.SetCursorPosition(55, 11);
            Console.WriteLine("Sağa Ötele ( D ) ");
            Console.SetCursorPosition(55, 13);
            Console.WriteLine("Yukarı Ötele ( W ) ");
            Console.SetCursorPosition(55, 15);
            Console.WriteLine("Aşağı Ötele ( S ) ");
        }
    private int genislik;
    private int yukseklik;
    private int x;
    private int y;
        private ConsoleColor renk;
    private Dortgen cizimAlani;
    }
    class BilgiPaneli
    {
        public BilgiPaneli(int genislik, int yukseklik) { }

    public void KonumAta(int x, int y) { }
    public void Ciz() {//bilgi paneli çizdiriliyor.
            Dortgen sa = new Dortgen();
            renk = ConsoleColor.Cyan;
            ConsoleColor eski = Console.ForegroundColor;
            Console.ForegroundColor = renk;
            sa.TepeCiz(25, 51, 21);
            sa.DikeyCiz(25, 15, 51, 21);
            sa.TabanCiz(25, 15, 51,21);
            Console.ForegroundColor = eski;
        }
        public void BilgiCiz()//yazılan dikdörtgen hakkında bilgiler yazdırılıyor.
        {
            Dortgen sa = new Dortgen(10,10);
            
            
            Console.SetCursorPosition(55, 25);
            Console.WriteLine("X........:"+sa.x);
            Console.SetCursorPosition(55, 26);
            Console.WriteLine("Y........:"+sa.y);
            Console.SetCursorPosition(55, 27);
            Console.WriteLine("Genişlik.:"+sa.genislik);
            Console.SetCursorPosition(55, 28);
            Console.WriteLine("Yukseklik:"+sa.yukseklik);
            Console.SetCursorPosition(55, 29);
            Console.WriteLine("Renk.....:"+sa.renk);
        }
        public void SekilAta(Dortgen sekil) { }

        private Dortgen aktifSekil;
        private Dortgen cizimAlani;

        private int genislik;
        private int yukseklik;
        private int x;
        private int y;
        private ConsoleColor renk;
    }
    class Program
    {
        static void Main(string[] args)
        {

            Dortgen drtgn = new Dortgen();//sınıflar tanımlanıyor.
            KontrolPaneli kntrl = new KontrolPaneli(10, 10);
            BilgiPaneli bilgi = new BilgiPaneli(10, 10);
            SahnePaneli shne = new SahnePaneli(10, 10);
            ConsoleKeyInfo ef;
            while(true)//bir while döngüsüne sokarak her tuşa basıldığında algılanmasını sağladım.
            {
                
                drtgn.Ciz();     //ve döngü her döndükten sonra paneller tekrar çizdiriliyor.          
                kntrl.Ciz();
                bilgi.Ciz();
                kntrl.MenuCiz();

                ef = Console.ReadKey(true);//kullanıcıdan girdi alınıyor
                if (ef.KeyChar=='e')// kullanıcı e tuşuna basarsa yapılacaklar
                {
                    shne.KonumAta(10, 10);
                    shne.Ciz();
                    bilgi.BilgiCiz();
                    
                }
                if(ef.KeyChar=='a')// kullanıcı a tuşuna basarsa yapılacaklar
                {
                    
                    Console.Clear();//console temizleniyor ve yeni dikdörtgenin konumuna göre tekrar çizdiriliyor
                    shne.KonumAta(10, 10);
                    shne.SekilSolaOtele();
                    bilgi.BilgiCiz();

                }
                if (ef.KeyChar == 'w')// kullanıcı w tuşuna basarsa yapılacaklar
                {
                    Console.Clear();
                    shne.KonumAta(10, 10);//console temizleniyor ve yeni dikdörtgenin konumuna göre tekrar çizdiriliyor
                    shne.SekilYukariOtele();
                    bilgi.BilgiCiz();

                }
                if (ef.KeyChar == 's')// kullanıcı s tuşuna basarsa yapılacaklar
                {
                    Console.Clear();
                    shne.KonumAta(10, 10);//console temizleniyor ve yeni dikdörtgenin konumuna göre tekrar çizdiriliyor
                    shne.SekilAsagiOtele();
                    bilgi.BilgiCiz();

                }
                if (ef.KeyChar == 'd')// kullanıcı d tuşuna basarsa yapılacaklar
                {
                    Console.Clear();
                    shne.KonumAta(10, 10);//console temizleniyor ve yeni dikdörtgenin konumuna göre tekrar çizdiriliyor
                    shne.SekilSagaOtele();
                    bilgi.BilgiCiz();

                }
                
            }
            Console.ReadKey();
        }

    }
}
