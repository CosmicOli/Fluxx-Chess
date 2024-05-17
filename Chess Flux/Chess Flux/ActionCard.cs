using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Flux_Chess
{
    internal class ActionCard : Card
    {
        protected override string name { get; }

        protected override string description { get; }

        protected Action<methodParameters> code;

        // Not sure how I feel about using this to make a general Action input.
        public record methodParameters
        {
            public Player playingPlayer { get; set; }
            public Player nonPlayingPlayer { get; set; }
            public Deck drawDeck { get; set; }
            public Deck discardDeck { get; set; }
            public int additionalIntInput { get; set; }
        }

        public ActionCard(string name, string description, Action<methodParameters> code)
        {
            this.name = name;
            this.description = description;
            this.code = code;
        }

        public Action<methodParameters> Code
        {
            get { return code; }
        }
    }
}
