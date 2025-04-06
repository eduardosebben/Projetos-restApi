package mono.android.app;

public class ApplicationRegistration {

	public static void registerApplications ()
	{
				// Application and Instrumentation ACWs must be registered first.
		mono.android.Runtime.register ("Soou_Erp_DashBoard.MainApplication, Soou_Erp_DashBoard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", crc64ff0e045bb6d9d119.MainApplication.class, crc64ff0e045bb6d9d119.MainApplication.__md_methods);
		mono.android.Runtime.register ("Microsoft.Maui.MauiApplication, Microsoft.Maui, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", crc6488302ad6e9e4df1a.MauiApplication.class, crc6488302ad6e9e4df1a.MauiApplication.__md_methods);
		mono.android.Runtime.register ("Yang.Maui.Helper.Platforms.Android.Controllers.BaseApplication, Yang.Maui.Helper, Version=1.0.3.7, Culture=neutral, PublicKeyToken=null", crc6499900604a79c6981.BaseApplication.class, crc6499900604a79c6981.BaseApplication.__md_methods);
		
	}
}
