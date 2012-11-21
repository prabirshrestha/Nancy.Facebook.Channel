
namespace Nancy.Facebook.Channel
{
    using System;
    using System.Text;

    public class FacebookChannelResponse : Response
    {
        internal const int DefaultCacheExpires = 60 * 60 * 24 * 365;

        private static readonly byte[] ContentByteArray = Encoding.UTF8.GetBytes("<script src=\"//connect.facebook.net/en_US/all.js\"></script>");

        public FacebookChannelResponse(int cacheExpires = DefaultCacheExpires)
        {
            Headers["Pragma"] = "public";
            Headers["Cache-Control"] = "maxage=" + cacheExpires;
            Headers["Expires"] = DateTime.Now.ToUniversalTime().AddSeconds(cacheExpires).ToString("r");

            ContentType = "text/html";

            Contents = stream => stream.Write(ContentByteArray, 0, ContentByteArray.Length);
        }
    }
}
