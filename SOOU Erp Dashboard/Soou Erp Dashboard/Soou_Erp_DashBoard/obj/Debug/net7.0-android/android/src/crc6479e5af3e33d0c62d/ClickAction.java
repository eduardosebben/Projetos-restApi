package crc6479e5af3e33d0c62d;


public class ClickAction
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.view.View.OnClickListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onClick:(Landroid/view/View;)V:GetOnClick_Landroid_view_View_Handler:Android.Views.View/IOnClickListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Yang.Maui.Helper.Platforms.Android.Actions.ClickAction, Yang.Maui.Helper", ClickAction.class, __md_methods);
	}


	public ClickAction ()
	{
		super ();
		if (getClass () == ClickAction.class) {
			mono.android.TypeManager.Activate ("Yang.Maui.Helper.Platforms.Android.Actions.ClickAction, Yang.Maui.Helper", "", this, new java.lang.Object[] {  });
		}
	}


	public void onClick (android.view.View p0)
	{
		n_onClick (p0);
	}

	private native void n_onClick (android.view.View p0);

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
