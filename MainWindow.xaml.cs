using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Fuvar> fuvarok = new List<Fuvar>();
        public MainWindow()
        {
            InitializeComponent();
            var fajl = new OpenFileDialog();
            if (fajl.ShowDialog() == true) { 
            StreamReader streamReader = new StreamReader(fajl.FileName);
                streamReader.ReadLine();
                while (streamReader.EndOfStream) { 
                string sor = streamReader.ReadLine();
                string[] mezo = sor.Split(";");
                    Fuvar fuvar = new Fuvar(Convert.ToInt32(Convert.ToInt32(mezo[0])), mezo[1], Convert.ToInt32(mezo[2]), Convert.ToDouble(mezo[4]), Convert.ToDouble(mezo[5]), Convert.ToDouble(mezo[6]), mezo[7]);
                    fuvarok.Add(fuvar);
                }
                streamReader.Close();


                int osszesAdatSzama = 0;
                double bizonyosTaxisViteldija = 0;
                double osszesFuvarHossza = 0;

                int bankkártyaSzama = 0, keszpenzSzama = 0, vitatottSzama = 0, ingyenesSzama = 0, ismeretlenSzama = 0;

                double leghosszabbUt = 0;
                int leghosszabbAzonositoja = 0;
                double leghosszabbUtja = 0;
                double leghosszabbVitelDija = 0;

                foreach (var item in fuvarok)
                {
                    //3
                    osszesAdatSzama++;
                    //4
                    if (item.TaxiAzonositoja == 6185) {
                        bizonyosTaxisViteldija += item.VitelDij;
                    }
                    //5
                    switch (item.FizetesModja)
                    {
                        case "bankkártya":
                            bankkártyaSzama++;
                            break;
                        case "készpénz":
                            keszpenzSzama++; ;
                            break;
                        case "vitatott":
                            vitatottSzama++;
                            break;
                        case "ingyenes":
                            ingyenesSzama++;
                            break;
                        case "ismeretlen":
                            ismeretlenSzama++;
                            break;
                        default:
                            break;
                    }
                    //6
                    osszesFuvarHossza += item.MegtettTav*1.6;
                    //7
                    if (leghosszabbUt < item.MegtettTav) { 
                        leghosszabbUt = item.UtazasIdotartama;
                        leghosszabbAzonositoja = item.TaxiAzonositoja;
                        leghosszabbUtja = item.MegtettTav * 1.6;
                        leghosszabbVitelDija = item.VitelDij;
                    }
                }

                //8
                using (StreamWriter sw = File.CreateText("hibak.txt")) {
                    sw.WriteLine("taxi_id;indulas;idotartam;tavolsag;viteldij;borravalo;fizetes_modja");
                    for (int i = 0; i < fuvarok.Count; i++)
                    {
                        foreach (var item in fuvarok)
                        {
                            if (item.UtazasIdotartama > 0 && item.VitelDij > 0 && item.MegtettTav == 0) {
                                sw.WriteLine(item.TaxiAzonositoja + ";" +item.IndultasIdopontja+";"+item.UtazasIdotartama+";"+item.MegtettTav+";"+item.VitelDij+";"+item.Borravalo+";"+item.FizetesModja);
                            }
                        }
                    }
                    sw.Close();
                }
                lbosszesfuvar.Content = "3. feladat: " + osszesAdatSzama + "fuvar";

                lbbizonyosTaxisDija.Content = "4. feladat: " + bizonyosTaxisViteldija + "$";

                lbfizetesiModok.Content = "5. feladat:\n\tbankkártya: " + bankkártyaSzama + " fuvar\n\tkészpénz: " + keszpenzSzama + " fuvar\n\tvitatott: "
                    + vitatottSzama + " fuvar\n\tingyenes: " + ingyenesSzama + " fuvar\n\tismeretlen: " + ismeretlenSzama + " fuvar";

                lbosszesTavKMBen.Content = "6. feladat: " + Math.Round(osszesFuvarHossza, 2);

                lbleghosszabbUtAdatai.Content = "7. feladat: Leghosszabb fuvar:\n\tFuvar hossza:" + leghosszabbUtja + "másodperc\n\tTaxi azonosító: "
                    + leghosszabbAzonositoja + "\n\tMegtett távolság: " + leghosszabbUt + "km\n\tViteldíj:"+leghosszabbVitelDija+"$";

                lbfaljbairas.Content = "8. feladat: hibak.txt";
            }
        }
    }
}
