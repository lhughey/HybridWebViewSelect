using System;
using Android.Webkit;
using HybridWebViewSelect;
using Microsoft.Maui;
using Microsoft.Maui.Handlers;
using WebView = Android.Webkit.WebView;

namespace HybridWebViewSelect.Platforms.Android.Handlers
{
    public class HybridWebViewHandler : ViewHandler<SimpleHybridWebView, WebView>
    {
        public static IPropertyMapper<SimpleHybridWebView, HybridWebViewHandler> Mapper = new PropertyMapper<SimpleHybridWebView, HybridWebViewHandler>(ViewHandler.ViewMapper)
        {
            // property mappings
        };

        // This is required!
        public HybridWebViewHandler() : base(Mapper)
        {
        }

        protected override WebView CreatePlatformView()
        {
            var context = MauiApplication.Current.ApplicationContext;
            var webView = new WebView(context);
            webView.Focusable = true;
            webView.FocusableInTouchMode = true;
            return webView;
        }
        
        protected override void ConnectHandler(WebView platformView)
        {
            base.ConnectHandler(platformView);
        
            var virtualView = VirtualView;
            if (virtualView == null)
                return;
        
            string javaScriptFunction = string.Empty;
        
            platformView.LoadData(virtualView.Uri, "text/html", "UTF-8");
            //platformView.SetWebViewClient(new WebViewClient());
            //platformView.SetWebChromeClient(new CustomWebChromeClient());
            platformView.Settings.JavaScriptEnabled = true;
        }

        public HybridWebViewHandler(IPropertyMapper mapper, CommandMapper? commandMapper = null) : base(mapper, commandMapper)
        {
        }



        protected override void DisconnectHandler(WebView platformView)
        {
            base.DisconnectHandler(platformView);
            //platformView?.RemoveJavascriptInterface("CSharp");
        }
    }
    
    public class CustomWebChromeClient : WebChromeClient
    {
        public CustomWebChromeClient()
        {
            System.Diagnostics.Debug.WriteLine("CustomWebChromeClient", "CustomWebChromeClient instantiated");
        }

        public override bool OnConsoleMessage(ConsoleMessage consoleMessage)
        {
            System.Diagnostics.Debug.WriteLine($"JS: {consoleMessage.Message()}");
            return base.OnConsoleMessage(consoleMessage);
        }
    }
}