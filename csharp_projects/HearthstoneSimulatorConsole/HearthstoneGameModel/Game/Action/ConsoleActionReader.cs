using System;

namespace HearthstoneGameModel.Game.Action
{
    public class ConsoleActionReader : IStringActionReader
    {
        public string GetAction()
        {
            return Console.ReadLine();
        }
    }
}
