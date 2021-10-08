using DatabaseAccess.Entiteti;
using System;


namespace DatabaseAccess.DTOs
{
    public class UciNaView
    {
        public int UciNaId { get; set; }

        public PredmetView Uci { get; set; }
        public SmerView UceNa { get; set; }

        public UciNaView()
        {
        }

        public UciNaView(UciNa u)
        {
            UciNaId =u.UciNaId;
            Uci = new PredmetView(u.Uci);
            UceNa = new SmerView(u.UceNa);
        }


    }
}
