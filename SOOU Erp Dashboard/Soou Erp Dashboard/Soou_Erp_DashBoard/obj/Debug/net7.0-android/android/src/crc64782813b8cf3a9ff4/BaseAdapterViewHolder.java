package crc64782813b8cf3a9ff4;


public class BaseAdapterViewHolder
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Yang.Maui.Helper.Platforms.Android.Adapters.BaseAdapterViewHolder, Yang.Maui.Helper", BaseAdapterViewHolder.class, __md_methods);
	}


	public BaseAdapterViewHolder ()
	{
		super ();
		if (getClass () == BaseAdapterViewHolder.class) {
			mono.android.TypeManager.Activate ("Yang.Maui.Helper.Platforms.Android.Adapters.BaseAdapterViewHolder, Yang.Maui.Helper", "", this, new java.lang.Object[] {  });
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
