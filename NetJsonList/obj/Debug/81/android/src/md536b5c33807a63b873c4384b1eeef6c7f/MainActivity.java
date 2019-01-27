package md536b5c33807a63b873c4384b1eeef6c7f;


public class MainActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onRetainNonConfigurationInstance:()Ljava/lang/Object;:GetOnRetainNonConfigurationInstanceHandler\n" +
			"";
		mono.android.Runtime.register ("NetJsonList.MainActivity, NetJsonList", MainActivity.class, __md_methods);
	}


	public MainActivity ()
	{
		super ();
		if (getClass () == MainActivity.class)
			mono.android.TypeManager.Activate ("NetJsonList.MainActivity, NetJsonList", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public java.lang.Object onRetainNonConfigurationInstance ()
	{
		return n_onRetainNonConfigurationInstance ();
	}

	private native java.lang.Object n_onRetainNonConfigurationInstance ();

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
