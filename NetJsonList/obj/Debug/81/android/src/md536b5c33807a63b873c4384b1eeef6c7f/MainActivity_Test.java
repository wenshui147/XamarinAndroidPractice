package md536b5c33807a63b873c4384b1eeef6c7f;


public class MainActivity_Test
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("NetJsonList.MainActivity+Test, NetJsonList", MainActivity_Test.class, __md_methods);
	}


	public MainActivity_Test ()
	{
		super ();
		if (getClass () == MainActivity_Test.class)
			mono.android.TypeManager.Activate ("NetJsonList.MainActivity+Test, NetJsonList", "", this, new java.lang.Object[] {  });
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
