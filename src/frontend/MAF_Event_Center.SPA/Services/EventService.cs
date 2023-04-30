﻿using MAF_Event_Center.SPA.Models;
using MAF_Event_Center.SPA.Models.Events;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;
using System.Security.Claims;

namespace MAF_Event_Center.SPA.Services
{
    public class EventService : IEventService
    {
        private readonly HttpClient _httpClient;

        public EventService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Event> GetEvent(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<Event>($"/Event/GetEventById?id={id}");

            return result;
        }

        public async Task<List<Event>> GetEvents()
        { 
            var result = await _httpClient.GetFromJsonAsync<Event[]>("/Event/GetAll");

            return result.ToList();
        }

        public async Task<System.Net.HttpStatusCode> JoinUserToEvent(UserEvent userEvent)
        {
            var result =  await _httpClient.PostAsJsonAsync("/Event/JoinToEvent", userEvent);

            return result.StatusCode;
        }

    }
}
