
namespace Nancy.Facebook.Channel
{
    using System;
    using System.Text;

    public class FacebookChannelResponse : Response
    {
        internal const int DefaultCacheExpires = 60 * 60 * 24 * 365;

        private static readonly byte[] ContentByteArray = Encoding.UTF8.GetBytes("<script src=\"//connect.facebook.net/en_US/all.js\"></script>");
        private static readonly byte[] ContentBetaByteArray = Encoding.UTF8.GetBytes("<script src=\"//connect.beta.facebook.net/en_US/all.js\"></script>");

        public FacebookChannelResponse(bool beta = false, int cacheExpires = DefaultCacheExpires)
        {
            Headers["Pragma"] = "public";
            Headers["Cache-Control"] = "maxage=" + cacheExpires;
            Headers["Expires"] = DateTime.Now.ToUniversalTime().AddSeconds(cacheExpires).ToString("r");

            ContentType = "text/html";

            if (beta)
            {
                Contents = stream => stream.Write(ContentBetaByteArray, 0, ContentBetaByteArray.Length);
            }
            else
            {
                Contents = stream => stream.Write(ContentByteArray, 0, ContentByteArray.Length);
            }
        }
    }
}
