using HearthstoneGameModel.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextView
{
    public class TextUIManager : UIManager
    {
        public override void LogError(string message)
        {
            Console.WriteLine("ERROR: " + message);
        }

        public override void ReceiveUIEvent(string uiEvent)
        {
            // TODO: implement
            
            throw new NotImplementedException();
        }
    }
}
