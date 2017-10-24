using LittleBrotherEye.Code.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LittleBrotherEye.Controllers.API
{
    [APIKeyRequired]
    public class EventController : ApiController
    {

        public IEnumerable<Models.API.EventDTO> Get(int? pastDays = null)
        {
            var result = new List<Models.API.EventDTO>();


            using (var daEvents = new DataAccess.DataAccessObjects.Events())
            {
                IQueryable<DataAccess.Event> eventList;
                if (!pastDays.HasValue)
                    eventList = daEvents.ListActiveEvents();
                else
                    eventList = daEvents.ListPastEvents(pastDays.Value);

                foreach (var oEvent in eventList)
                {
                    result.Add(SetDTO(oEvent));
                }

                return result;

            }
        }

        public Models.API.EventDTO Get(int id)
        {
            using (var daEvent = new DataAccess.DataAccessObjects.Events())
            {
                var result = daEvent.LoadEvent(id);
                if (result != null)
                    return SetDTO(result);
                else
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "This item does not exist."));
            }
        }

        private Models.API.EventDTO SetDTO(DataAccess.Event oEvent)
        {
            return new Models.API.EventDTO()
            {
                EventId = oEvent.EventId,
                Name = oEvent.Name,
                EndTime = oEvent.EndTime.GetValueOrDefault(),

                Character_CD = !oEvent.Character_Cd.HasValue ? null :
                            new Models.API.CodeValueDTO()
                            {
                                CodeValue = oEvent.Character_Cd.Value,
                                Description = oEvent.Character.Description,
                                CodeTableId = oEvent.Character.CodeTableId
                            },
                RewardType_CD = new Models.API.CodeValueDTO()
                {
                    CodeValue = oEvent.RewardType_Cd,
                    Description = oEvent.RewardType.Description,
                    CodeTableId = oEvent.RewardType.CodeTableId
                }
            };
        }

    }
}
