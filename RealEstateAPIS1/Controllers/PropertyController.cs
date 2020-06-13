using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using RealEstateAPIS1.Models;
using RealEstateAPIS1.Processors;

namespace RealEstateAPIS1.Controllers
{
    public class PropertyController : ApiController
    {
        public List<Property> GetAllProperties()
        {

            // return PropetyProcessor.ProcessProperty(prop);
            return PropertyProcessor.ProcessGetProperty();
        }

        public List<Property> GetPropertiesByRoom(int rooms)
        {
            return PropertyProcessor.ProcessGetPropertyByRooms(rooms);
        }
        public List<Property> GetPropertiesByRent(string rent)
        {
            return PropertyProcessor.ProcessGetPropertyByRent(rent);
        }
        public List<Property> GetPropertiesByArea(string area)
        {
            return PropertyProcessor.ProcessGetPropertyByArea(area);
        }

        public List<Property> GetPropertiesByFilter(int rooms, string area, string type)
        {
            return PropertyProcessor.ProcessGetPropertyByFilter(rooms, area, type);
        }

        public async Task<HttpResponseMessage> AddProperty(Property property)
        {
            // Check if the request contains multipart/form-data.
            /*if (!Request.Content.IsMimeMultipartContent())
             {
                 throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
             }*/
            if (property == null)
            {
                //return false;
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }
            property.PropetyId = string.Format("{0:HH:mm:ss tt}", DateTime.Now);
            property.OwnerId = "3";
            // return PropetyProcessor.ProcessProperty(prop);
            PropertyProcessor.ProcessProperty(property);
            return new HttpResponseMessage(HttpStatusCode.OK);
            //string root = HttpContext.Current.Server.MapPath("~/App_Data");
            //var provider = new MultipartFormDataStreamProvider(root);
            //try
            //{
            //    StringBuilder sb = new StringBuilder(); // Holds the response body
            //                                            // Read the form data and return an async task.
            //    await Request.Content.ReadAsMultipartAsync(provider);
            //    // This illustrates how to get the form data.
            //    foreach (var key in provider.FormData.AllKeys)
            //    {
            //        foreach (var val in provider.FormData.GetValues(key))
            //        {
            //            sb.Append(string.Format("{0}: {1}\n", key, val));
            //        }
            //    }
            //    // This illustrates how to get the file names for uploaded files.
            //    foreach (var file in provider.FileData)
            //    {
            //        FileInfo fileInfo = new FileInfo(file.LocalFileName);
            //        sb.Append(string.Format("Uploaded file: {0} ({1} bytes)\n", fileInfo.Name, fileInfo.Length));
            //    }
            //    return new HttpResponseMessage()
            //    {
            //        Content = new StringContent(sb.ToString())
            //    };
            //}
            //catch (System.Exception e)
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            //}
        }

        //public Property GetProperty(string id)
        //{

        //    // return PropetyProcessor.ProcessProperty(prop);
        //    return PropertyProcessor.ProcessGetProperty(id);
        //}

        /* 
         

         [HttpPost]
         public bool AddProperty(Property prop)
         {
             if(prop == null)
             {
                 return false;
             }
             prop.PropetyId ="109";
            // return PropetyProcessor.ProcessProperty(prop);
             return PropertyProcessor.ProcessProperty(prop);
         }*/
        //  [HttpPost]

        //[Route("AddProperty1")]
        //public async Task<HttpResponseMessage> AddProperty(Property property)
        //{
        //    // Check if the request contains multipart/form-data. 
        //    /*if (!Request.Content.IsMimeMultipartContent())
        //     {
        //         throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
        //     }*/

        //    if (property == null)
        //    {
        //        //return false;
        //        throw new HttpResponseException(HttpStatusCode.NoContent);
        //    }
        //    property.PropetyId = "109";
        //    property.OwnerId = "3";
        //    // return PropetyProcessor.ProcessProperty(prop);
        //    PropertyProcessor.ProcessProperty(property);
        //    string root = HttpContext.Current.Server.MapPath("~/App_Data");
        //    var provider = new MultipartFormDataStreamProvider(root);

        //    try
        //    {
        //        StringBuilder sb = new StringBuilder(); // Holds the response body 

        //        // Read the form data and return an async task. 
        //        await Request.Content.ReadAsMultipartAsync(provider);

        //        // This illustrates how to get the form data. 
        //        foreach (var key in provider.FormData.AllKeys)
        //        {
        //            foreach (var val in provider.FormData.GetValues(key))
        //            {
        //                sb.Append(string.Format("{0}: {1}\n", key, val));
        //            }
        //        }

        //        // This illustrates how to get the file names for uploaded files. 
        //        foreach (var file in provider.FileData)
        //        {
        //            FileInfo fileInfo = new FileInfo(file.LocalFileName);
        //            sb.Append(string.Format("Uploaded file: {0} ({1} bytes)\n", fileInfo.Name, fileInfo.Length));
        //        }
        //        return new HttpResponseMessage()
        //        {
        //            Content = new StringContent(sb.ToString())
        //        };
        //    }
        //    catch (System.Exception e)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
        //    }
        //}
        [HttpPost]
        [Route("AddToFav")]
        [BasicAuthentication]
        public void AddToFav(string propertyid)
        {
            string uname = Thread.CurrentPrincipal.Identity.Name;
            string x = Usersecurity.getIdByName(uname);

            PropertyProcessor.AddToFav(propertyid, x);
        }

        //[HttpPost]
        ////[Route("AddProperty2")]
        //public async Task<string> UploadFile(Property property)
        //{
        //    if (property == null)
        //    {
        //        //return false;
        //        throw new HttpResponseException(HttpStatusCode.NoContent);
        //    }
        //    property.PropetyId = "109";
        //    property.OwnerId = "3";
        //    // return PropetyProcessor.ProcessProperty(prop);
        //    PropertyProcessor.ProcessProperty(property);
        //    var ctx = HttpContext.Current;
        //    var root = ctx.Server.MapPath("~/App_Data");
        //    var provider =
        //        new MultipartFormDataStreamProvider(root);

        //    try
        //    {
        //        await Request.Content
        //            .ReadAsMultipartAsync(provider);

        //        foreach (var file in provider.FileData)
        //        {
        //            var name = file.Headers
        //                .ContentDisposition
        //                .FileName;

        //            // remove double quotes from string.
        //            name = name.Trim('"');

        //            var localFileName = file.LocalFileName;
        //            var filePath = Path.Combine(root, name);

        //            File.Move(localFileName, filePath);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return $"Error: {e.Message}";
        //    }

        //    return "File uploaded!";
        //}
    }
}
