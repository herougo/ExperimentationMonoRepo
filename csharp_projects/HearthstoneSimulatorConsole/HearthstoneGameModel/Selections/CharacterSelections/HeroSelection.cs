using HearthstoneGameModel.Game;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Selections.CharacterSelections
{
    public class HeroSelection : CharacterSelection
    {
        bool _opposing;

        public HeroSelection(bool opposing) { _opposing = opposing; }

        public override List<CardSlot> GetSelectedCardSlots(HearthstoneGame game, EffectManagerNode emNode)
        {
            CardSlot cardSlot = emNode.AffectedSlot;
            int player = cardSlot.Player;
            if (_opposing)
            {
                player = 1 - player;
            }
            return new List<CardSlot> { game.Players[player] };
        }

        public override CharacterSelection Copy()
        {
            return new HeroSelection(_opposing);
        }
    }
}
