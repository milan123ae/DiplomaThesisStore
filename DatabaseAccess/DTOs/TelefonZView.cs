using DatabaseAccess.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class TelefonZView
    {
        public int IdTelefona { get; set; }
        public int Telefon { get; set; }
        public ZaposlenView Zaposlenfon { get; set; }

        public string Email;

        public TelefonZView()
        {

        }

        public TelefonZView(TelefonZ z)
        {
            IdTelefona = z.IdTelefona;
            Telefon = z.Telefon;
            Email = z.Zaposlenfon.Email;

        }
    }
}
