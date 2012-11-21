namespace Nancy.Facebook.Channel
{
    public static class FacebookChannelResponseExtensions
    {
        public static Response AsFacebookChannel(this IResponseFormatter responseFormatter, int cacheExpires = FacebookChannelResponse.DefaultCacheExpires)
        {
            return new FacebookChannelResponse(cacheExpires);
        }
    }
}