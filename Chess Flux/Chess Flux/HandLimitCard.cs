using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flux_Chess
{
    internal class HandLimitCard : RuleCard
    {
        protected override string name { get; }

        protected override string description { get; }

        protected int handLimit;

        public HandLimitCard(string name, string description, int handLimit)
        {
            this.name = name;
            this.description = description;
            this.handLimit = handLimit;
        }

        public int HandLimit
        {
            get { return handLimit; }
        }
    }
}
