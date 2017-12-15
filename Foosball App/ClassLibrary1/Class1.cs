using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1

    {
        public void Mainxd()
        {
            using (TurnyrasEntities context = new TurnyrasEntities())
            {
                TurnyrasXd naujas = new TurnyrasXd();
                naujas.IvarciuSantykis = 10;
                naujas.IvarciuSkaicius = 15;
                naujas.PraleistiIvarciai = 5;
                naujas.Komanda = "Chelsea";
                context.TurnyrasXd.Add(naujas);
                context.SaveChanges();
            }
        }
    }
}
