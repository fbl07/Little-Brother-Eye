using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LittleBrotherEye.DataAccess.DataAccessObjects
{
    public class Events : BaseDataAccess
    {

        public IQueryable<Event> ListActiveEvents()
        {
            return Context.Events
                .Include(x => x.Character)
                .Include(x => x.RewardType)
                .Where(x => x.EndTime > DateTime.Now)
                .OrderBy(x => x.EndTime);
        }

        public IQueryable<Event> ListPastEvents(int pastDays)
        {
            var cutoffDate = DateTime.Today.AddDays(-pastDays);
            return Context.Events
                .Include(x => x.Character)
                .Include(x => x.RewardType)
                .Where(x => x.EndTime < DateTime.Now && x.EndTime > cutoffDate)
                .OrderByDescending(x => x.EndTime);
        }

        public Event LoadEvent(int eventId)
        {
            return Context.Events
                .Include(x => x.Character)
                .Include(x => x.RewardType)
                .FirstOrDefault(x => x.EventId == eventId);
        }

        public int SaveEvent(Event data, string IpAddress)
        {
            if (data.EventId > 0)
            {
                Context.Events.Attach(data);
                Context.Entry(data).State = System.Data.Entity.EntityState.Modified;
            }
            else
                Context.Events.Add(data);

            Context.SaveChanges();

            data.EditHistories.Add(new EditHistory()
            {
                EditDate = DateTime.Now,
                NewName = data.Name,
                IpAdress = IpAddress
            });

            Context.SaveChanges();

            return data.EventId;
        }

        public bool Delete(int eventId)
        {
            var oEvent = LoadEvent(eventId);

            if (oEvent != null)
            {
                var history = Context.EditHistories.Where(x => x.EventId == eventId);
                Context.EditHistories.RemoveRange(history);

                Context.Events.Remove(oEvent);
                Context.SaveChanges();
                return true;
            }

            return false;
        }

    }
}