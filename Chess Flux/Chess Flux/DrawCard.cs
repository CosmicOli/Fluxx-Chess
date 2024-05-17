using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flux_Chess
{
    internal class DrawCard : RuleCard
    {
        protected override string name { get; }
        
        protected override string description { get; }

        protected int drawAmount;

        public DrawCard(string name, string description, int drawAmount)
        {
            this.name = name;
            this.description = description;
            this.drawAmount = drawAmount;
        }

        public int DrawAmount
        {
            get { return drawAmount; }
        }
    }
}
