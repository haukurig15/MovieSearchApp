package md5af3c8b20092685c2f4f6a25bd04abd93;


public class MovieListActivity
	extends android.app.ListActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("MovieSearch.Droid.MovieListActivity, MovieSearch.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MovieListActivity.class, __md_methods);
	}


	public MovieListActivity ()
	{
		super ();
		if (getClass () == MovieListActivity.class)
			mono.android.TypeManager.Activate ("MovieSearch.Droid.MovieListActivity, MovieSearch.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
