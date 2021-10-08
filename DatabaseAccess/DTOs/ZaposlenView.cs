using DatabaseAccess.Entiteti;
using System.Collections.Generic;
using System;

namespace DatabaseAccess.DTOs
{
    public class ZaposlenView
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Jmbg { get; set; }
        public string Lime { get; set; }
        public string ImeRoditelja { get; set; }
        public string Prezime { get; set; }
        public string DatumRodjenja { get; set; }
        public string Ulica { get; set; }
        public string Broj { get; set; }
        public IList<TelefonZView> TelefoniZ { get; set; }

        public ZaposlenView()
        {
            TelefoniZ = new List<TelefonZView>();
        }

        public ZaposlenView(Zaposlen z)
        {
            Email = z.Email;
            Password = z.Password;
            Jmbg = z.Jmbg.ToString();
            Lime = z.Lime;
            ImeRoditelja = z.ImeRoditelja;
            Prezime = z.Prezime;
            DatumRodjenja = z.DatumRodjenja.ToShortDateString();
            Ulica = z.Ulica;
            Broj = z.Broj.ToString();
        }
    }
}
