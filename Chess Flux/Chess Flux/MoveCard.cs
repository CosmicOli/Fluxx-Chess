using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flux_Chess
{
    internal class MoveCard : RuleCard
    {
        protected override string name { get; }

        protected override string description { get; }

        protected int moveAmount;

        public MoveCard(string name, string description, int moveAmount)
        {
            this.name = name;
            this.description = description;
            this.moveAmount = moveAmount;
        }

        public int MoveAmount
        {
            get { return moveAmount; }
        }
    }
}
