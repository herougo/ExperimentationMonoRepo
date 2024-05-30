using HearthstoneGameModel.Game.EffectManagement;
using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Conditions
{
    public class OrCondition : ICondition
    {
        ICondition _condition1;
        ICondition _condition2;

        public OrCondition(ICondition condition1, ICondition condition2)
        {
            _condition1 = condition1;
            _condition2 = condition2;
        }

        public List<string> EventsReceived
        {
            get
            {
                List<string> result = _condition1.EventsReceived.ToList();
                result.AddRange(_condition2.EventsReceived);
                return result;
            }
        }

        public bool Evaluate(HearthstoneGame game, EffectManagerNode emNode)
        {
            return _condition1.Evaluate(game, emNode) || _condition2.Evaluate(game, emNode);
        }

        public ICondition Copy()
        {
            return new OrCondition(_condition1.Copy(), _condition2.Copy());
        }
    }
}
