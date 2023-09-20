using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4
{
    internal class Fuvar
    {
        int taxiAzonositoja;
        string indultasIdopontja;
        int utazasIdotartama;
        double megtettTav;
        double vitelDij;
        double borravalo;
        string fizetesModja;

        public Fuvar(int taxiAzonositoja, string indultasIdopontja, int utazasIdotartama, double megtettTav, double vitelDij, double borravalo, string fizetesModja)
        {
            this.taxiAzonositoja = taxiAzonositoja;
            this.indultasIdopontja = indultasIdopontja;
            this.utazasIdotartama = utazasIdotartama;
            this.megtettTav = megtettTav;
            this.vitelDij = vitelDij;
            this.borravalo = borravalo;
            this.fizetesModja = fizetesModja;
        }

        public int TaxiAzonositoja { get => taxiAzonositoja; set => taxiAzonositoja = value; }
        public string IndultasIdopontja { get => indultasIdopontja; set => indultasIdopontja = value; }
        public int UtazasIdotartama { get => utazasIdotartama; set => utazasIdotartama = value; }
        public double MegtettTav { get => megtettTav; set => megtettTav = value; }
        public double VitelDij { get => vitelDij; set => vitelDij = value; }
        public double Borravalo { get => borravalo; set => borravalo = value; }
        public string FizetesModja { get => fizetesModja; set => fizetesModja = value; }
    }
}
