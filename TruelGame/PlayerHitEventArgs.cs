using System;
using System.Collections.Generic;
using System.Text;

namespace TruelGame
{
    public class PlayerHitEventArgs : EventArgs
    {
        public IPlayer Target { get; }
        public PlayerHitEventArgs(IPlayer target)
        {
            Target = target;
        }
    }
}
