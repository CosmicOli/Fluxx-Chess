using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flux_Chess
{
    internal class GoalLimitCard : RuleCard
    { 
        protected override string name { get; }

        protected override string description { get; }

        protected int goalLimit;

        public GoalLimitCard(string name, string description, int goalLimit)
        {
            this.name = name;
            this.description = description;
            this.goalLimit = goalLimit;
        }

        public int GoalLimit
        {
            get { return goalLimit; }
        }
    }
}
