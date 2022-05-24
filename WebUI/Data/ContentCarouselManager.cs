using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebUI.Models;
using WebUI.Services;

namespace WebUI.Data
{
    public class ContentCarouselManager : BaseManager<ContentCarouselsViewModel>
    {
        public ContentCarouselManager(HttpClient client) : base(client)
        {
            controller = "ContentCarousels";
        }

        public async Task<NotificationViewModelGeneric<ContentCarouselsViewModel>> CreateAsync(ContentCarouselCreate entity)
        {
            try
            {
                NotificationViewModelGeneric<ContentCarouselsViewModel> response = null;
                foreach (var file in entity.ContentFile)
                {

                    using (var content = new MultipartFormDataContent())
                    {
                        var fileContent =
                            new StreamContent(file.OpenReadStream(15120000));


                        fileContent.Headers.ContentType =
                            new MediaTypeHeaderValue(file.ContentType);

                        content.Add(
                            content: fileContent,
                            name: "\"files\"",
                            fileName: file.Name);

                        var idParameter = new StringContent(entity.PageContainerId.ToString());
                        idParameter.Headers.Add("Content-Disposition", "form-data; name=\"id\"");
                        content.Add(idParameter, "id");

                        var result = await client.PostAsync($"/api/v1/{controller}/Create?id={entity.PageContainerId}", content);
                        response = await ExtendFunction<ContentCarouselsViewModel>.HandlingResponse(result);
                    }
                }

                return response;
            }
            catch (Exception e)
            {
                if (e.Message.Contains("Supplied file with size 1437403 bytes exceeds the maximum of 512000 bytes."))
                    return new NotificationViewModelGeneric<ContentCarouselsViewModel>()
                    { Type = NotificationType.Warn, Text = "Произошла ошибка, файл превышает допустимый размер" };

                return new NotificationViewModelGeneric<ContentCarouselsViewModel>()
                { Type = NotificationType.Warn, Text = "Произошла ошибка, сервер не отвечает" };
            }

            //var content = new FormUrlEncodedContent(new[]
            //{
            //    new KeyValuePair<string,string>("Name", entity.Name)
            //});
            //return await CreateAsync(content);
        }

        public async Task<NotificationViewModelGeneric<ContentCarouselsViewModel>> UpdateContentCarousel (ContentCarouselCreate entity)
        {

            try
            {
                NotificationViewModelGeneric<ContentCarouselsViewModel> response = null;
                foreach (var file in entity.ContentFile)
                {

                    using (var content = new MultipartFormDataContent())
                    {
                        var fileContent =
                            new StreamContent(file.OpenReadStream(15120000));


                        fileContent.Headers.ContentType =
                            new MediaTypeHeaderValue(file.ContentType);

                        content.Add(
                            content: fileContent,
                            name: "\"files\"",
                            fileName: file.Name);

                        var idParameter = new StringContent(entity.PageContainerId.ToString());
                        idParameter.Headers.Add("Content-Disposition", "form-data; name=\"id\"");
                        content.Add(idParameter, "id");

                        var result = await client.PostAsync($"/api/v1/{controller}/Create?id={entity.PageContainerId}", content);
                        response = await ExtendFunction<ContentCarouselsViewModel>.HandlingResponse(result);
                    }
                }

                return response;
            }
            catch (Exception e)
            {
                if (e.Message.Contains("Supplied file with size 1437403 bytes exceeds the maximum of 512000 bytes."))
                    return new NotificationViewModelGeneric<ContentCarouselsViewModel>()
                    { Type = NotificationType.Warn, Text = "Произошла ошибка, файл превышает допустимый размер" };

                return new NotificationViewModelGeneric<ContentCarouselsViewModel>()
                { Type = NotificationType.Warn, Text = "Произошла ошибка, сервер не отвечает" };
            }
        }

        //public async Task<NotificationViewModelGeneric<ContentCarouselsViewModel>> UpdateAsync(ContentCarouselsViewModel entity)
        //{
        //    var content = new FormUrlEncodedContent(new[]
        //    {
        //        new KeyValuePair<string,string>("Id", entity.Id.ToString()),
        //        new KeyValuePair<string,string>("Name", entity.Name)
        //    });
        //    return await UpdateAsync(content);
        //}
    }
}
