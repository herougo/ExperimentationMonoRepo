using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.EffectManagement;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Conditions
{
    public interface ICondition
    {
        List<string> EventsReceived { get; }

        bool Evaluate(HearthstoneGame game, EffectManagerNode emNode);
    }
}
