using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.CardSlots;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game.Utils;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.CardGeneration;
using HearthstoneGameModel.Cards;

namespace HearthstoneGameModel.Effects.OneTimeEffects
{
    public class AddCardToHand : OneTimeEffect
    {
        ICardGenerator _cardGenerator;
        PlayerChoice _toPlayer;
        int _numCopies;

        public AddCardToHand(ICardGenerator cardGenerator, PlayerChoice toPlayer)
        {
            _cardGenerator = cardGenerator;
            _toPlayer = toPlayer;
            _numCopies = 1;
        }

        public AddCardToHand(ICardGenerator cardGenerator, PlayerChoice toPlayer, int numCopies)
        {
            _cardGenerator = cardGenerator;
            _toPlayer = toPlayer;
            _numCopies = numCopies;
        }

        public override EffectManagerNodePlan Execute(HearthstoneGame game, CardSlot affectedCardSlot, CardSlot originCardSlot, List<CardSlot> eventSlots)
        {
            for (int i = 0; i < _numCopies; i++)
            {
                Card card = _cardGenerator.Generate(game, affectedCardSlot, originCardSlot, eventSlots);
                int player = affectedCardSlot.Player;
                int receivingPlayer = HSGameUtils.ComputePlayer(player, _toPlayer);
                game.CreateCardAndAddToHand(receivingPlayer, card);
            }
            return null;
        }

        public override OneTimeEffect Copy()
        {
            return new AddCardToHand(_cardGenerator, _toPlayer, _numCopies);
        }
    }
}
