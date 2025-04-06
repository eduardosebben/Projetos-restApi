package crc6408ffe87f0dbae65c;


public class DownloadImageTaskHelper
	extends android.os.AsyncTask
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onPostExecute:(Ljava/lang/Object;)V:GetOnPostExecute_Ljava_lang_Object_Handler\n" +
			"n_doInBackground:([Ljava/lang/Object;)Ljava/lang/Object;:GetDoInBackground_arrayLjava_lang_Object_Handler\n" +
			"";
		mono.android.Runtime.register ("Yang.Maui.Helper.Image.DownloadImageTaskHelper, Yang.Maui.Helper", DownloadImageTaskHelper.class, __md_methods);
	}


	public DownloadImageTaskHelper ()
	{
		super ();
		if (getClass () == DownloadImageTaskHelper.class) {
			mono.android.TypeManager.Activate ("Yang.Maui.Helper.Image.DownloadImageTaskHelper, Yang.Maui.Helper", "", this, new java.lang.Object[] {  });
		}
	}

	public DownloadImageTaskHelper (android.widget.ImageView p0, android.widget.ProgressBar p1)
	{
		super ();
		if (getClass () == DownloadImageTaskHelper.class) {
			mono.android.TypeManager.Activate ("Yang.Maui.Helper.Image.DownloadImageTaskHelper, Yang.Maui.Helper", "Android.Widget.ImageView, Mono.Android:Android.Widget.ProgressBar, Mono.Android", this, new java.lang.Object[] { p0, p1 });
		}
	}


	public void onPostExecute (java.lang.Object p0)
	{
		n_onPostExecute (p0);
	}

	private native void n_onPostExecute (java.lang.Object p0);


	public java.lang.Object doInBackground (java.lang.Object[] p0)
	{
		return n_doInBackground (p0);
	}

	private native java.lang.Object n_doInBackground (java.lang.Object[] p0);

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
