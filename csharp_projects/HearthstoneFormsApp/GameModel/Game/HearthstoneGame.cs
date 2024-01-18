using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameModel.Game.CardSlots;
using GameModel.Game.Metadata;

namespace GameModel.Game
{
    public class HearthstoneGame
    {
        public Decklist[] Decklists;
        public DecisionMaker[] DecisionMakers;
        public Pile[] Decks;
        public Pile[] Hands;
        public HeroCardSlot[] Players;
        public WeaponCardSlot[] Weapons;
        public Battleboard Battleboard;

        public EffectManager EffectManager;
        public GameMetadata GameMetadata;
        public PlayerMetadata[] PlayerMetadata;
        public CardMover CardMover;


        public HearthstoneGame(HearthstoneGameArgs args)
        {
            Decklists = args.Decklists;
            DecisionMakers = args.DecisionMakers;
            foreach (DecisionMaker decisionMaker in DecisionMakers)
            {
                decisionMaker.SetGame(this);
            }

            Decks = null;
            Hands = null;
            Players = null;
            Weapons = null;
            Battleboard = null;

            EffectManager = null;
            GameMetadata = null;
            PlayerMetadata = null;
            CardMover = new CardMover(this);
        }

        public void SetupGame(bool shuffleDecks)
        {
            EffectManager = new EffectManager(this);
            Decks = new Pile[HearthstoneConstants.NumberOfPlayers]
            {
                new Pile(), // TODO
                new Pile()
            };
            if (shuffleDecks)
            {
                for (int i = 0; i < HearthstoneConstants.NumberOfPlayers; i++)
                {
                    Decks[i].Shuffle();
                }
            }
            GameMetadata = new GameMetadata();
            PlayerMetadata = new PlayerMetadata[HearthstoneConstants.NumberOfPlayers]
            {
                new PlayerMetadata(),
                new PlayerMetadata()
            };

        }
    }
}
