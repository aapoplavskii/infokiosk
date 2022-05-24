using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Services
{
    public static class ExtendFunction<T>
    {
        public static async Task<NotificationViewModelGeneric<T>> HandlingResponse(HttpResponseMessage responseMessage)
        {
            JsonSerializerOptions jsonSerializerOptions = new() { PropertyNameCaseInsensitive = true };

            var _content = await responseMessage.Content.ReadAsStringAsync();
            NotificationViewModel result;
            try
            {
                result = JsonSerializer.Deserialize<NotificationViewModel>(_content, jsonSerializerOptions);
                if (result.Type == NotificationType.Success)
                {
                    return JsonSerializer.Deserialize<NotificationViewModelGeneric<T>>(_content, jsonSerializerOptions);
                }
            }
            catch(Exception e)
            {
                result = CreateViewModels.CreateErrorNotificationViewModel(e.Message);
            }
            return new NotificationViewModelGeneric<T>(result);
        }
    }
}
