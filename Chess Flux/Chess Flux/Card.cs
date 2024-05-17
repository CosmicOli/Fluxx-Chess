using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Flux_Chess
{
    internal abstract class Card
    {
        protected abstract string name { get; }
        protected abstract string description { get; }

        public string Name
        {
            get { return name; }
        }

        public string Description
        {
            get { return description; }
        }
    }
}
