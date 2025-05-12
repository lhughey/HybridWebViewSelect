using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace HybridWebViewSelect
{
public class SimpleHybridWebView : HybridWebView
{

    // Default constructor
    public SimpleHybridWebView()
    {
    }
    
    public SimpleHybridWebView(string uri)
    {
        //this.RegisterAction(InvokeAction);
        Uri = uri;
    
    }
    Action<string> action
    {
        get;
        set;
    }
    public static readonly BindableProperty UriProperty = BindableProperty.Create(
        "Uri", typeof(string), typeof(HybridWebView), default(string));

    public string Uri
    {
        get { return (string)GetValue(UriProperty); }
        set { SetValue(UriProperty, value); }
    }
    
    public async Task InjectJavaScriptAsync(string script)
    {
        await this.EvaluateJavaScriptAsync(script);
    }
}
}