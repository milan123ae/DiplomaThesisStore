using System;
using System.Collections.Generic;


namespace DatabaseAccess.Entiteti
{
    public class UciNa
    {
        public virtual int UciNaId { get; set; }

        public virtual Predmet Uci { get; set; }
        public virtual Smer UceNa { get; set; }


    }
}
