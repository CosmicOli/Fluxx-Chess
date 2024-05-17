using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flux_Chess
{
    internal class Rules
    {
        static public int drawAmount = 1;
        static public int playAmount = 1;
        static public int moveAmount = 1;

        // These are nullable integers as limits do not always exist.
        static public int? handLimit = null;
        static public int? goalLimit = null;
    }
}
