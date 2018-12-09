using Sds.Domain;
using System;
using System.Collections.Generic;

namespace Sds.Chemistry.Domain
{
    public class InChI : ValueObject<InChI>
    {
        public InChI(string inchi, string inchiKey)
        {
            Inchi = inchi;
            InChIKey = inchiKey;
        }

        public string Inchi { get; private set; }
        public string InChIKey { get; private set; }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new List<Object>() { Inchi, InChIKey };
        }
    }
}
