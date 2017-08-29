package md53636a44826a05b16f9ddc9e6522d2986;


public class MyGestureListener
	extends android.view.GestureDetector.SimpleOnGestureListener
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onDoubleTap:(Landroid/view/MotionEvent;)Z:GetOnDoubleTap_Landroid_view_MotionEvent_Handler\n" +
			"";
		mono.android.Runtime.register ("Flashcards.MyGestureListener, Flashcards, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MyGestureListener.class, __md_methods);
	}


	public MyGestureListener () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MyGestureListener.class)
			mono.android.TypeManager.Activate ("Flashcards.MyGestureListener, Flashcards, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public MyGestureListener (md53636a44826a05b16f9ddc9e6522d2986.MainActivity p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == MyGestureListener.class)
			mono.android.TypeManager.Activate ("Flashcards.MyGestureListener, Flashcards, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Flashcards.MainActivity, Flashcards, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}


	public boolean onDoubleTap (android.view.MotionEvent p0)
	{
		return n_onDoubleTap (p0);
	}

	private native boolean n_onDoubleTap (android.view.MotionEvent p0);

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
