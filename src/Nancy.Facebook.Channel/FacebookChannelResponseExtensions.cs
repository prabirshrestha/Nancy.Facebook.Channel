namespace Nancy.Facebook.Channel
{
    public static class FacebookChannelResponseExtensions
    {
        public static Response AsFacebookChannel(this IResponseFormatter responseFormatter, bool beta = false, int cacheExpires = FacebookChannelResponse.DefaultCacheExpires)
        {
            return new FacebookChannelResponse(beta, cacheExpires);
        }
    }
}