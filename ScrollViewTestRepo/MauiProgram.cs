using Microsoft.Extensions.Logging;

namespace ScrollViewTestRepo
{
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
				})
				.ConfigureMauiHandlers(handlers =>
				{
#if IOS
					Microsoft.Maui.Handlers.ScrollViewHandler.Mapper.AppendToMapping(nameof(ScrollViewTestRepo), (handler, view) =>
					{
						handler.PlatformView.MinimumZoomScale = 1;
						handler.PlatformView.MaximumZoomScale = 5;
						handler.PlatformView.ViewForZoomingInScrollView += (UIKit.UIScrollView sv) =>
						{
							return handler.PlatformView.Subviews[0];
						};
					});
#endif
				});

#if DEBUG
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}
