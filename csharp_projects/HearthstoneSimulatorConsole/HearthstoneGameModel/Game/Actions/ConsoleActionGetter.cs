using System;

namespace HearthstoneGameModel.Game.Actions
{
    public class ConsoleActionGetter : IActionGetter
    {
        public string GetAction()
        {
            return Console.ReadLine();
        }
    }
}
