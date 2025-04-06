package crc64bef061cc69c51c86;


public class KeyboardHelper_GlobalLayoutListenerForKeyboard
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.view.ViewTreeObserver.OnGlobalLayoutListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onGlobalLayout:()V:GetOnGlobalLayoutHandler:Android.Views.ViewTreeObserver/IOnGlobalLayoutListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Yang.Maui.Helper.Platforms.Android.Views.KeyboardHelper+GlobalLayoutListenerForKeyboard, Yang.Maui.Helper", KeyboardHelper_GlobalLayoutListenerForKeyboard.class, __md_methods);
	}


	public KeyboardHelper_GlobalLayoutListenerForKeyboard ()
	{
		super ();
		if (getClass () == KeyboardHelper_GlobalLayoutListenerForKeyboard.class) {
			mono.android.TypeManager.Activate ("Yang.Maui.Helper.Platforms.Android.Views.KeyboardHelper+GlobalLayoutListenerForKeyboard, Yang.Maui.Helper", "", this, new java.lang.Object[] {  });
		}
	}


	public void onGlobalLayout ()
	{
		n_onGlobalLayout ();
	}

	private native void n_onGlobalLayout ();

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
