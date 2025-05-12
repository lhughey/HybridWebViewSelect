#if ANDROID
	using HybridWebViewSelect.Platforms.Android.Handlers;
#endif
using Microsoft.Extensions.Logging;

namespace HybridWebViewSelect;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		// Register custom renderers and handlers
		builder.ConfigureMauiHandlers(handlers =>
		{

#if ANDROID

			handlers.AddHandler(typeof(HybridWebView), typeof(HybridWebViewHandler));

#endif
		});


		var app = builder.Build();
		var services = app.Services;
		return app;
	}
}
	

