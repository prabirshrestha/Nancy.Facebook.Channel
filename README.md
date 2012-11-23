# Facebook Channel file library for Nancy Web Framework

Channel file for Facebook to address issues with cross domain communication in certain browsers.

# Installing Nancy.Facebook.Channel

```
Install-Package Nancy.Facebook.Channel
```

# Usage

```c#
using Nancy.Facebook.Channel;

Get["/facebook/channel"] = _ => Response.AsFacebookChannel();
```

```c#
using Nancy.Facebook.Channel;

Get["/facebook/channel"] = _ => new FacebookChannelResponse();
```

```html
<div id="fb-root"></div>
<script>
  window.fbAsyncInit = function() {
    FB.init({
      appId      : 'YOUR_APP_ID', // App ID
      channelUrl : '//WWW.YOUR_DOMAIN.COM/facebook/channel', // Channel File for x-domain communication
      status     : true, // check login status
      cookie     : true, // enable cookies to allow the server to access the session
      xfbml      : true  // parse XFBML
    });

    // Additional initialization code here
  };

  // Load the SDK Asynchronously
  (function(d){
     var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
     if (d.getElementById(id)) {return;}
     js = d.createElement('script'); js.id = id; js.async = true;
     js.src = "//connect.facebook.net/en_US/all.js";
     ref.parentNode.insertBefore(js, ref);
   }(document));
</script>
```
*Source: http://developers.facebook.com/docs/reference/javascript/*

The channel file addresses some issues with cross domain communication in certain browsers. The contents of the channel.html file can be just a single line:

```javascript
 <script src="//connect.facebook.net/en_US/all.js"></script>
 ```

It is important for the channel file to be cached for as long as possible. When serving this file, you must send valid Expires headers with a long expiration period. This will ensure the channel file is cached by the browser which is important for a smooth user experience. Without proper caching, cross domain communication will become very slow and users will suffer a severely degraded experience.
