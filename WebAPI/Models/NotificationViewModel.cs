using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class NotificationViewModel
    {
        public const string TempDataKey = "NotificationData";

        public string Title { get; set; }
        public string Text { get; set; }
        public string Typestr { get { return Type.ToString().ToLower(); } }
        public NotificationType Type { get; set; }
        public TypeOfErrors Error { get; set; }
        public NotificationViewModel() { }

        public NotificationViewModel(NotificationViewModel notificationViewModel)
        {
            Title = notificationViewModel.Title;
            Text = notificationViewModel.Text;
            Type = notificationViewModel.Type;
            Error = notificationViewModel.Error;
        }

        protected static string ErrorHelper(TypeOfErrors error)
        {
            string result = error switch
            {
                TypeOfErrors.AccessDenied => $"Недостаточно прав!",
                TypeOfErrors.NotFound => $"Данные не существуют или не найдены!",
                TypeOfErrors.DataNotValid => $"Данные не валидны, проверьте правильность ввода!",
                TypeOfErrors.InternalError => $"Произошла внутренняя ошибка!",
                TypeOfErrors.EntityNotFound => $"Сущность не найдена!",
                TypeOfErrors.MappingError => $"Произошла ошибка при преобразовании модели!",
                TypeOfErrors.AddingEntityError => $"Ошибка при создании!",
                TypeOfErrors.DeletionEntityError => $"Ошибка при удалении!",
                TypeOfErrors.UpdateEntityError => $"Ошибка при изменении!",
                TypeOfErrors.ExistNameEntity => $"Это название занято!",
                TypeOfErrors.ErrorAddingPhoto => $"Ошибка при добавлении фотографии!",
                TypeOfErrors.PhotoDeletionError => $"Ошибка при удалении фотографии!",
                TypeOfErrors.ErrorFileExtension => $"Неверный формат файла!",
                TypeOfErrors.NotExistPriority => $"Нет ниодного приоритета!",
                TypeOfErrors.NotExistDepartament => $"Нет ниодного департамента!",
                TypeOfErrors.NotExistRoom => $"Невозможно выполнить запрос, нет ниодной комнаты!",
                TypeOfErrors.NotExistType => $"Нет ниодного типа!",
                TypeOfErrors.NotExistEmployee => $"Нет ниодного сотрудника!",
                TypeOfErrors.NotExistState => $"Нет ниодного состояния!",
                TypeOfErrors.NotExistSubdivision => $"Нет ниодного подразделения!",
                TypeOfErrors.NotExistRole => $"Нет ниодной роли!",
                TypeOfErrors.NotExistPosition => $"Нет ниодной позиции!",
                TypeOfErrors.NotExistBuilding => $"Нет ниодного здания!",
                TypeOfErrors.NotActiveApplication => $"Активных заявок нет!",
                TypeOfErrors.OnDelete => $"Заявка удалена!",
                TypeOfErrors.NotExistFile => $"Файл пуст!",
                TypeOfErrors.ErrorUpdatePhoto => $"Ошибка изменения фотографии!",
                TypeOfErrors.IdentityServerError => $"Сервер авторизации не отвечает!",
                TypeOfErrors.NotExistPhotoInEmployee => $"У сотрудника нет привязанной фотографии!",
                TypeOfErrors.NoContent => $"Список пуст",
                TypeOfErrors.Conflict => $"Произошёл конфликт, ",
                _ => $"Неизвестная ошибка!",
            };
            return result;
        }
    }


    public enum NotificationType
    {
        Success = 1,
        Info,
        Warn,
        Error
    }

    public enum TypeOfErrors
    {
        AccessDenied = 1,
        NotFound,
        InternalError,
        DataNotValid,
        EntityNotFound,
        MappingError,
        AddingEntityError,
        DeletionEntityError,
        UpdateEntityError,
        ExistNameEntity,
        ErrorAddingPhoto,
        PhotoDeletionError,
        ErrorFileExtension,
        NotExistPriority,
        NotExistDepartament,
        NotExistRoom,
        NotExistType,
        NotExistEmployee,
        NotExistState,
        NotExistSubdivision,
        NotExistRole,
        NotExistPosition,
        NotExistBuilding,
        NotActiveApplication,
        OnDelete,
        NotExistFile,
        ErrorUpdatePhoto,
        IdentityServerError,
        NotExistPhotoInEmployee,

        NoContent,
        Conflict
    }

    public class NotificationViewModelGeneric<T>: NotificationViewModel
    {
        public T Data { get; set; }

        public NotificationViewModelGeneric() : base()
        {
        }

        public NotificationViewModelGeneric(NotificationViewModel notificationViewModel) : base(notificationViewModel)
        {
        }
    }

}
