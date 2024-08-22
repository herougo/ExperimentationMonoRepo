using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneGameModel.Game.CardSlots;

namespace HearthstoneGameModel.Conditions
{
    public class AndCondition : Condition
    {
        Condition _condition1;
        Condition _condition2;

        public AndCondition(Condition condition1, Condition condition2)
        {
            _condition1 = condition1;
            _condition2 = condition2;
            _eventsReceived = _condition1.EventsReceived.ToList();
            _eventsReceived.AddRange(_condition2.EventsReceived.ToList());
        }

        public override bool Evaluate(
            string effectEvent, HearthstoneGame game, EffectManagerNode emNode, List<CardSlot> eventSlots
        )
        {
            return (
                _condition1.Evaluate(effectEvent, game, emNode, eventSlots)
                && _condition2.Evaluate(effectEvent, game, emNode, eventSlots)
            );
        }

        public override Condition Copy()
        {
            return new AndCondition(_condition1.Copy(), _condition2.Copy());
        }
    }
}
