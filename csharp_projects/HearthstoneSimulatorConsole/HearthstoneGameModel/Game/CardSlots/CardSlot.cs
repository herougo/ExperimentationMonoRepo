using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Utils;
using HearthstoneGameModel.Cards;
using HearthstoneGameModel.Cards.CardFactories;
using HearthstoneGameModel.Core.Enums;
using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Effects;
using HearthstoneGameModel.Effects.ContinuousEffects;

namespace HearthstoneGameModel.Game.CardSlots
{
    public class CardSlot
    {
        protected int _hash;
        public Card Card;
        public int Player;
        public HearthstoneGame Game;
        public int Mana;

        public bool Silenced = false;

        public CardSlot(string cardId, int player, HearthstoneGame game) {
            _hash = HashGenerator.GetNextHash();
            Card = CardFactory.CreateCard(cardId);
            Player = player;
            Game = game;
            Mana = Card.Mana;
        }

        public int Hash { get { return _hash; } }

        public override int GetHashCode() { return Hash; }

        public CardType CardType { get { return Card.CardType; } }

        public void SwitchPlayers()
        {
            Player = 1 - Player;
        }

        public virtual void UpdateStats()
        {
            // TODO: implement
        }

        public override string ToString()
        {
            return $"CardSlot('{Card.Name}', Mana={Card.Mana})";
        }

        public List<EffectManagerNode> GetEMNodes()
        {
            return Game.EffectManager.GetRelevantEMNodes(this);
        }
    }
}
