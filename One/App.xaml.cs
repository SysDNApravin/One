﻿using Microsoft.Maui.Platform;
using One.Handlers;

namespace One;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        //Code For Border Less Entry

        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handler, view) =>
        {
            if (view is BorderlessEntry)
            {
#if __ANDROID__
                handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#elif __IOS__
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS
            handler.PlatformView.FontWeight = Microsoft.UI.Text.FontWeights.Thin;
#endif
            }
        });


        




        //Code Fro Border Less Entry 
        MainPage = new AppShell();
	}
}