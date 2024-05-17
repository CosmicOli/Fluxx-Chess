using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flux_Chess
{
    internal abstract class RuleCard : Card
    {
        protected abstract override string name { get; }

        protected abstract override string description { get; }
    }
}
