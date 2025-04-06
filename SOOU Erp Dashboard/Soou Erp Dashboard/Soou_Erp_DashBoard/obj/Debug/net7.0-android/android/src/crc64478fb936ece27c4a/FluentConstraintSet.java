package crc64478fb936ece27c4a;


public class FluentConstraintSet
	extends androidx.constraintlayout.widget.ConstraintSet
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Yang.Maui.Helper.Layouts.FluentConstraintSet, Yang.Maui.Helper", FluentConstraintSet.class, __md_methods);
	}


	public FluentConstraintSet ()
	{
		super ();
		if (getClass () == FluentConstraintSet.class) {
			mono.android.TypeManager.Activate ("Yang.Maui.Helper.Layouts.FluentConstraintSet, Yang.Maui.Helper", "", this, new java.lang.Object[] {  });
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
