namespace Nancy.Facebook.Channel
{
    /// <summary>
    /// Represents extension methods for Facebook Channel file.
    /// </summary>
    public static class FacebookChannelResponseExtensions
    {
        /// <summary>
        /// Returns a response as a facebook channel file.
        /// </summary>
        /// <param name="responseFormatter">The response formatter.</param>
        /// <param name="beta">Indicates whether to use the beta channel file.</param>
        /// <param name="cacheExpires">The cache expiry time in seconds. (defaults to 1 year)</param>
        /// <returns>Returns a <see cref="FacebookChannelResponse"/>.</returns>
        public static FacebookChannelResponse AsFacebookChannel(this IResponseFormatter responseFormatter, bool beta = false, int cacheExpires = FacebookChannelResponse.DefaultCacheExpires)
        {
            return new FacebookChannelResponse(beta, cacheExpires);
        }
    }
}