using HearthstoneGameModel.Cards.CardTypes;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Utils;

namespace HearthstoneGameModel.Effects.OneTimeEffects
{
    public class SummonMinionLikeShamanHP : OneTimeEffect
    {
        List<MinionCard> _minionOptions;
        HashSet<string> _cardIdSet = new HashSet<string>();

        public SummonMinionLikeShamanHP(List<MinionCard> minionOptions) {
            _minionOptions = minionOptions;
            foreach (MinionCard card in minionOptions)
            {
                _cardIdSet.Add(card.CardId);
            }
        }

        public override EffectManagerNodePlan Execute(
            HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots
        )
        {
            int player = affectedCardSlot.Player;
            if (game.Battleboard.HasRoom(player))
            {
                HashSet<string> unavailableCardIds = new HashSet<string>();
                foreach (CardSlot cardSlot in game.Battleboard.GetAllSlots(player))
                {
                    if (_cardIdSet.Contains(cardSlot.Card.CardId))
                    {
                        unavailableCardIds.Add(cardSlot.Card.CardId);
                    }
                }
                int selectedIndex = -1;
                if (unavailableCardIds.Count == _cardIdSet.Count)
                {
                    selectedIndex = RandomGenerator.GetRandomInt(0, _minionOptions.Count - 1);
                }
                else
                {
                    int selectedRandomInt = RandomGenerator.GetRandomInt(
                        0, _minionOptions.Count - unavailableCardIds.Count - 1
                    );
                    for (int i = 0; i < _minionOptions.Count; i++)
                    {
                        MinionCard minionCard = _minionOptions[i];
                        if (unavailableCardIds.Contains(minionCard.CardId))
                        {
                            continue;
                        }
                        if (selectedRandomInt == 0)
                        {
                            selectedIndex = i;
                            break;
                        }
                        selectedRandomInt -= 1;
                    }
                }
                MinionCard selectedMinion = _minionOptions[selectedIndex];
                MinionCardSlot newMinionCardSlot = (MinionCardSlot)selectedMinion.CreateCardSlot(player, game);
                game.CardMover.SummonMinion(newMinionCardSlot);
            }
            return null;
        }

        public override OneTimeEffect Copy()
        {
            List<MinionCard> minionOptions = new List<MinionCard>();
            foreach (MinionCard card in _minionOptions)
            {
                minionOptions.Add((MinionCard)card.Copy());
            }
            return new SummonMinionLikeShamanHP(minionOptions);
        }
    }
}
