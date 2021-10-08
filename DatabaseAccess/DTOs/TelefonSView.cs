using DatabaseAccess.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class TelefonSView
    {
        public int IdTelefona { get; set; }
        public int Telefon { get; set; }
        public StudentView Studentfon { get; set; }

        public string Email;

        public TelefonSView()
        {

        }

        public TelefonSView(TelefonS s)
        {
            IdTelefona = s.IdTelefona;
            Telefon = s.Telefon;
            Email = s.Studentfon.Email;

        }
    }
}
