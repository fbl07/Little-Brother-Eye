using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LittleBrotherEye.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Index()
        {
            var model = new Models.EventIndexModel();
            return View(model);
        }

        public ActionResult GetCurrentEvents()
        {
            var model = new Models.EventList();

            using (var daEvents = new DataAccess.DataAccessObjects.Events())
            {
                var currentEvents = daEvents.ListActiveEvents();
                PopulateEventList(model, currentEvents);
            }

            PopulateLists(model);

            return PartialView("~/Views/Event/Partials/EventGrid.cshtml", model);
        }

        public ActionResult GetPastEvents(int pastDays)
        {
            var model = new Models.EventList();

            using (var daEvents = new DataAccess.DataAccessObjects.Events())
            {
                var currentEvents = daEvents.ListPastEvents(pastDays);
                PopulateEventList(model, currentEvents);
            }

            PopulateLists(model);

            return PartialView("~/Views/Event/Partials/EventGrid.cshtml", model);
        }

        [HttpGet]
        public ActionResult Edit(int? eventId)
        {
            var model = new Models.EventModel();

            if (eventId.HasValue)
            {
                DataAccess.Event oEvent;
                using (var daEvents = new DataAccess.DataAccessObjects.Events())
                    oEvent = daEvents.LoadEvent(eventId.Value);

                if (oEvent != null)
                    PopulateEventModel(model, oEvent);
            }

            PopulateLists(model);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Models.EventModel model)
        {
            if (ModelState.IsValid)
            {
                using (var daEvent = new DataAccess.DataAccessObjects.Events())
                {
                    DataAccess.Event oEvent;
                    if (model.Id.HasValue)
                        oEvent = daEvent.LoadEvent(model.Id.Value);
                    else
                        oEvent = new DataAccess.Event();

                    oEvent.Name = model.Name;
                    oEvent.Character_Cd = model.Character_Cd;
                    oEvent.RewardType_Cd = model.RewardType_Cd;

                    DateTime? EndTime = null;

                    if (model.TimeToEndHours > 0 || model.TimeToEndMinutes > 0)
                    {
                        EndTime = DateTime.Now;

                        EndTime = EndTime.Value.AddHours(model.TimeToEndHours);
                        EndTime = EndTime.Value.AddMinutes(model.TimeToEndMinutes);
                    }

                    oEvent.EndTime = EndTime;

                    daEvent.SaveEvent(oEvent, Request.UserHostAddress);

                    return RedirectToAction("Index");
                }
            }
            else
            {
                PopulateLists(model);
                return View(model);
            }

        }

        public ActionResult Delete(int eventId)
        {
            using (var daEvents = new DataAccess.DataAccessObjects.Events())
                return Json(daEvents.Delete(eventId));
        }

        protected void PopulateEventList(Models.EventList model, IEnumerable<DataAccess.Event> data)
        {
            model.Events.AddRange(
                data.Select(x => new Models.EventModel()
                {
                    Id = x.EventId,
                    Name = x.Name,
                    Character_Cd = x.Character_Cd,
                    EndTime = x.EndTime,
                    RewardType_Cd = x.RewardType_Cd
                })
            );

            model.Events.ForEach(x =>
            {
                x.TimeToEnd = x.EndTime - DateTime.Now;
                SetDisplayForTimeToEnd(x);
            });
        }

        protected void PopulateLists(Models.BaseWithCodeTables model)
        {
            using (var daCodeTables = new DataAccess.DataAccessObjects.CodeTables())
            {
                model.RewardTypes = daCodeTables.DropDownForCodeTable(Constants.CodeTables.RewardType);
                model.Characters = daCodeTables.DropDownForCodeTable(Constants.CodeTables.Characters, true);
            }
        }

        protected void PopulateEventModel(Models.EventModel model, DataAccess.Event data)
        {
            model.Id = data.EventId;
            model.Name = data.Name;
            model.Character_Cd = data.Character_Cd;
            model.EndTime = data.EndTime;
            model.TimeToEnd = data.EndTime - DateTime.Now;
            model.TimeToEndHours = model.TimeToEnd.HasValue ? (model.TimeToEnd.Value.Hours + model.TimeToEnd.Value.Days * 24) : 0;
            model.TimeToEndMinutes = model.TimeToEnd.HasValue ? (model.TimeToEnd.Value.Minutes) : 0;
            model.RewardType_Cd = data.RewardType_Cd;
        }

        protected void SetDisplayForTimeToEnd(Models.EventModel model)
        {
            if (model.TimeToEnd.HasValue)
            {
                var newSpan = model.TimeToEnd.Value;

                bool bNegative = model.TimeToEnd.Value.TotalMilliseconds < 0;
                if (bNegative)
                    newSpan = model.TimeToEnd.Value.Duration();

                if (newSpan.Days > 0)
                    model.DisplayForTimeToEnd = string.Format("{0}d {1:00}:{2:00}", newSpan.Days, newSpan.Hours, newSpan.Minutes);
                else
                    model.DisplayForTimeToEnd = newSpan.ToString("hh\\:mm");

                if (bNegative)
                    model.DisplayForTimeToEnd = "- " + model.DisplayForTimeToEnd;
            }
        }
    }
}