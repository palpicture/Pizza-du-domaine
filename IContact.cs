using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_du_domaine
{
    interface IContact
    {
        string Nom
        {
            get;
        }

        string Adresse
        {
            get;
        }

        string Tel
        {
            get;
        }
    }
}
