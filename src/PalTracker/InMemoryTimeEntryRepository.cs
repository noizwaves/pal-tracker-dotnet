using System.Collections.Generic;
using System.Linq;

namespace PalTracker
{
    public class InMemoryTimeEntryRepository : ITimeEntryRepository
    {
        private readonly Dictionary<long, TimeEntry> _items;

        public InMemoryTimeEntryRepository()
        {
            _items = new Dictionary<long, TimeEntry>();
        }

        public TimeEntry Create(TimeEntry timeEntry)
        {
            var newId = _items.Count + 1;
            var result = new TimeEntry(newId, timeEntry.ProjectId, timeEntry.UserId, timeEntry.Date, timeEntry.Hours);
            _items.Add(newId, result);
            return result;
        }

        public TimeEntry Find(long id)
        {
            return _items[id];
        }

        public bool Contains(long id)
        {
            return _items.Keys.Contains(id);
        }

        public IEnumerable<TimeEntry> List()
        {
            return _items.Values.ToList().AsEnumerable();
        }

        public TimeEntry Update(long id, TimeEntry timeEntry)
        {
            if (_items.ContainsKey(id))
            {
                _items.Remove(id);
            }

            var result = new TimeEntry(id, timeEntry.ProjectId, timeEntry.UserId, timeEntry.Date, timeEntry.Hours);
            _items.Add(id, result);
            return result;
        }

        public void Delete(long id)
        {
            _items.Remove(id);
        }
    }
}