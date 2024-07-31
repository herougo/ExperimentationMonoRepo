using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneGameModel.Game
{
    public class GraveyardTracker
    {
        private List<GraveyardTrackerEntry> _entries = new List<GraveyardTrackerEntry>();

        public void Add(GraveyardTrackerEntry entry)
        {
            _entries.Add(entry);
        }

        public GraveyardTrackerEntry this[int index]
        {
            get { return _entries[index]; }
        }

        public Tuple<int, int> GetTurnIndicesRange(int turnIndex)
        {
            // TODO: improve performance
            int end = _entries.Count - 1;
            while (end > 0 && _entries[end].TurnDied > turnIndex)
            {
                end -= 1;
            }
            int start = end;
            while (start >= 0 && _entries[start].TurnDied == turnIndex)
            {
                start -= 1;
            }
            return new Tuple<int, int>(start + 1, end);
        }
    }
}
