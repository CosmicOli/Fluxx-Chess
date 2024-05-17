using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flux_Chess
{
    internal class CardFunctions
    {
        static public void StealCard(ref ActionCard.methodParameters methodParameters)
        {
            methodParameters.playingPlayer.Draw(methodParameters.nonPlayingPlayer.Discard(methodParameters.additionalIntInput));
        }
    }
}
