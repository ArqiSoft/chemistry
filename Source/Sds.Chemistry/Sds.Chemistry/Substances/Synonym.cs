using Sds.Domain;
using System;
using System.Collections.Generic;

namespace Sds.Chemistry.Domain
{
    public enum SynonymState
    {
        /// <summary>
        /// Logically removed
        /// </summary>
        eDeleted = 1,
        /// <summary>
        /// Disproved by curator
        /// </summary>
        eDisproved,
        /// <summary>
        /// Negative opinion expressed
        /// </summary>
        eUnconfirmed,
        /// <summary>
        /// Positive opinion expressed
        /// </summary>
        eConfirmed,
        /// <summary>
        /// Approved by curator
        /// </summary>
        eApproved,
    }

    public enum SynonymFlagType
    {
        /// <summary>
        /// The flag will automatically be assigned to all instances of the Synonym on every Compound.
        /// </summary>
        SynonymType,

        /// <summary>
        /// The flag will only be assigned to one instance of the Synonym on a Compound.
        /// </summary>
        SynonymAssertion
    }

    public class Synonym : ValueObject<Synonym>
    {
        public string Name { get; private set; }
        public string LanguageId { get; private set; }
        public SynonymState State { get; private set; }
        public bool IsTitle { get; private set; }
        public DateTime DateCreated { get; private set; }
        public IReadOnlyCollection<SynonymFlag> Flags { get; private set; } = new List<SynonymFlag>(); //Should include both types of flags, those at Synonym level and those at CompoundSynonym level.

        public Synonym(string name, string langId, SynonymState state, bool isTitle = false, IReadOnlyCollection<SynonymFlag> flags = null, DateTime created = default(DateTime))
        {
            Name = name;
            LanguageId = langId;
            State = state;
            IsTitle = isTitle;
            Flags = flags;
            DateCreated = created;
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new List<Object>() { Name };
        }
    }

    public class SynonymFlag
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int Rank { get; set; }
        public bool ExcludeFromTitle { get; set; }
        public SynonymFlagType Type { get; set; }
        public bool IsUniquePerLanguage { get; set; }
        public string RegEx { get; set; }
        public bool IsRestricted { get; set; }
    }
}
