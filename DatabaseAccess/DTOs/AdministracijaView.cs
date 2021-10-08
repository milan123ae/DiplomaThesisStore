using DatabaseAccess.Entiteti;
using System.Collections.Generic;

namespace DatabaseAccess.DTOs
{
    public class AdministracijaView : ZaposlenView
    {

        public string StrucnaSprema { get; set; }
        public AdministracijaView()
        {

        }

        public AdministracijaView(Administracija z) : base(z)
        {
            StrucnaSprema = z.StrucnaSprema;
        }
    }
}
