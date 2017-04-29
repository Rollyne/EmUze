using System;
using System.Net;

namespace EmUzerWeb.Tools
{
    public static class GetFacebookInformation
    {
        public static string GetPictureUrl(string faceBookId)
        {
            WebResponse response = null;
            string pictureUrl = string.Empty;
            try
            {
                WebRequest request = WebRequest.Create($"https://graph.facebook.com/{faceBookId}/picture?type=large");
                response = request.GetResponse();
                pictureUrl = response.ResponseUri.ToString();
            }
            catch (Exception ex)
            {
                //? handle
            }
            finally
            {
                response?.Close();
            }
            return pictureUrl;
        }
    }
}