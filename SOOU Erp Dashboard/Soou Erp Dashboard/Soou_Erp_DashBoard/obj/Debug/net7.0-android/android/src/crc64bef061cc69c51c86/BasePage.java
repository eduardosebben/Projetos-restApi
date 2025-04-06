package crc64bef061cc69c51c86;


public class BasePage
	extends crc64bef061cc69c51c86.BaseView
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Yang.Maui.Helper.Platforms.Android.Views.BasePage, Yang.Maui.Helper", BasePage.class, __md_methods);
	}


	public BasePage (android.content.Context p0)
	{
		super (p0);
		if (getClass () == BasePage.class) {
			mono.android.TypeManager.Activate ("Yang.Maui.Helper.Platforms.Android.Views.BasePage, Yang.Maui.Helper", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}


	public BasePage (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == BasePage.class) {
			mono.android.TypeManager.Activate ("Yang.Maui.Helper.Platforms.Android.Views.BasePage, Yang.Maui.Helper", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
		}
	}


	public BasePage (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == BasePage.class) {
			mono.android.TypeManager.Activate ("Yang.Maui.Helper.Platforms.Android.Views.BasePage, Yang.Maui.Helper", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1, p2 });
		}
	}


	public BasePage (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == BasePage.class) {
			mono.android.TypeManager.Activate ("Yang.Maui.Helper.Platforms.Android.Views.BasePage, Yang.Maui.Helper", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1, p2, p3 });
		}
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
