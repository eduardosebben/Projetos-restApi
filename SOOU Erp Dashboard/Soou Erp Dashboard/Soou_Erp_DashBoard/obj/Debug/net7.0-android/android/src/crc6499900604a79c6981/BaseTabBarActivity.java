package crc6499900604a79c6981;


public abstract class BaseTabBarActivity
	extends crc6499900604a79c6981.BaseActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onStart:()V:GetOnStartHandler\n" +
			"n_onStop:()V:GetOnStopHandler\n" +
			"n_onBackPressed:()V:GetOnBackPressedHandler\n" +
			"";
		mono.android.Runtime.register ("Yang.Maui.Helper.Platforms.Android.Controllers.BaseTabBarActivity, Yang.Maui.Helper", BaseTabBarActivity.class, __md_methods);
	}


	public BaseTabBarActivity ()
	{
		super ();
		if (getClass () == BaseTabBarActivity.class) {
			mono.android.TypeManager.Activate ("Yang.Maui.Helper.Platforms.Android.Controllers.BaseTabBarActivity, Yang.Maui.Helper", "", this, new java.lang.Object[] {  });
		}
	}


	public BaseTabBarActivity (int p0)
	{
		super (p0);
		if (getClass () == BaseTabBarActivity.class) {
			mono.android.TypeManager.Activate ("Yang.Maui.Helper.Platforms.Android.Controllers.BaseTabBarActivity, Yang.Maui.Helper", "System.Int32, System.Private.CoreLib", this, new java.lang.Object[] { p0 });
		}
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onStart ()
	{
		n_onStart ();
	}

	private native void n_onStart ();


	public void onStop ()
	{
		n_onStop ();
	}

	private native void n_onStop ();


	public void onBackPressed ()
	{
		n_onBackPressed ();
	}

	private native void n_onBackPressed ();

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
