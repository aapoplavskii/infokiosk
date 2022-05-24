using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebUI.Models;
using WebUI.Services;

namespace WebUI.Data
{
    public abstract class BaseManager<T> where T : BaseViewModel
    {
        protected HttpClient client;
        protected string controller;


        public BaseManager(HttpClient client)
        {
            this.client = client;
        }

        public async Task<NotificationViewModelGeneric<List<T>>> GetListViewModelsAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"/api/v1/{controller}/list");
                var result = await ExtendFunction<List<T>>.HandlingResponse(response);
                if (result.Type == NotificationType.Success)
                {
                    result.Data = result.Data.OrderBy(t => t.Id).ToList();
                }
                return result;
            }
            catch (Exception)
            {
                return new NotificationViewModelGeneric<List<T>>()
                { Type = NotificationType.Warn, Text = "Произошла ошибка, сервер не отвечает" };
            }
        }

        public NotificationViewModelGeneric<List<T>> GetListViewModels()
        {
            try
            {
                HttpResponseMessage response = client.GetAsync($"/api/v1/{controller}/list").Result;
                var result = ExtendFunction<List<T>>.HandlingResponse(response).Result;
                result.Data = result.Data.OrderBy(t => t.Id).ToList();
                return result;
            }
            catch (Exception)
            {
                return new NotificationViewModelGeneric<List<T>>()
                { Type = NotificationType.Warn, Text = "Произошла ошибка, сервер не отвечает" };
            }
        }
        
        public NotificationViewModelGeneric<T> GetViewModelsById(int id)
        {
            try
            {
                HttpResponseMessage response = client.GetAsync($"/api/v1/{controller}/GetById?id={id}").Result;
                var result = ExtendFunction<T>.HandlingResponse(response).Result;
                return result;
            }
            catch (Exception)
            {
                return new NotificationViewModelGeneric<T>()
                { Type = NotificationType.Warn, Text = "Произошла ошибка, сервер не отвечает" };
            }
        }

        public async Task<NotificationViewModelGeneric<T>> CreateAsync(FormUrlEncodedContent content)
        {
            try
            {
                var response = await client.PostAsync($"/api/v1/{controller}/Create", content);
                return await ExtendFunction<T>.HandlingResponse(response);
            }
            catch (Exception)
            {
                return new NotificationViewModelGeneric<T>()
                { Type = NotificationType.Warn, Text = "Произошла ошибка, сервер не отвечает" };
            }
        }

        public async Task<NotificationViewModelGeneric<T>> UpdateAsync(FormUrlEncodedContent content)
        {
            try
            {
                var response = await client.PutAsync($"/api/v1/{controller}/update", content);
                return await ExtendFunction<T>.HandlingResponse(response);
            }
            catch (Exception)
            {
                return new NotificationViewModelGeneric<T>()
                { Type = NotificationType.Warn, Text = "Произошла ошибка, сервер не отвечает" };
            }
        }

        public async Task<NotificationViewModelGeneric<T>> DeleteAsync(int id)
        {
            try
            {
                var response = await client.DeleteAsync($"/api/v1/{controller}/delete?id={id}");
                return await ExtendFunction<T>.HandlingResponse(response);
            }
            catch (Exception)
            {
                return new NotificationViewModelGeneric<T>()
                { Type = NotificationType.Warn, Text = "Произошла ошибка, сервер не отвечает" };
            }
        }
    }
}
