
namespace Nancy.Facebook.Channel
{
    using System;
    using System.Text;

    public class FacebookChannelResponse : Response
    {
        private static readonly byte[] ContentByteArray = Encoding.UTF8.GetBytes("<script src=\"//connect.facebook.net/en_US/all.js\"></script>");

        public FacebookChannelResponse(int cacheExpires = 60 * 60 * 24 * 365)
        {
            Headers["Pragma"] = "public";
            Headers["Cache-Control"] = "maxage=" + cacheExpires;
            Headers["Expires"] = DateTime.Now.ToUniversalTime().AddSeconds(cacheExpires).ToString("r");

            ContentType = "text/html";

            Contents = stream => stream.Write(ContentByteArray, 0, ContentByteArray.Length);
        }
    }
}
