using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public static class CreateViewModels
    {
        public static NotificationViewModel CreateErrorNotificationViewModel(string message)
        {
            var model = new NotificationViewModel()
            {
                Error = TypeOfErrors.InternalError,
                Type = NotificationType.Error,
                Title = message,
                Text = message,                
            };

            return model;
        }
    }
}
