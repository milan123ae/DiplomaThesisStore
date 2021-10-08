

namespace DatabaseAccess.Entiteti
{
    public class TelefonZ
    {
        public virtual int IdTelefona { get; set; }
        public virtual int Telefon { get; set; }
        public virtual Zaposlen Zaposlenfon { get; set; }
    }
}
