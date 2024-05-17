using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flux_Chess
{
    internal class PlayCard : RuleCard
    {

        protected override string name { get; }

        protected override string description { get; }

        protected int playAmount;

        public PlayCard(string name, string description, int playAmount)
        {
            this.name = name;
            this.description = description;
            this.playAmount = playAmount;
        }

        public int PlayAmount
        {
            get { return playAmount; }
        }
    }
}

