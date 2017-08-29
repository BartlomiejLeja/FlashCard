package md563bea3c702c447820d22fa51c22a25fd;


public class CardBackFragment
	extends android.app.Fragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreateView:(Landroid/view/LayoutInflater;Landroid/view/ViewGroup;Landroid/os/Bundle;)Landroid/view/View;:GetOnCreateView_Landroid_view_LayoutInflater_Landroid_view_ViewGroup_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Flashcards.Fragments.CardBackFragment, Flashcards, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CardBackFragment.class, __md_methods);
	}


	public CardBackFragment () throws java.lang.Throwable
	{
		super ();
		if (getClass () == CardBackFragment.class)
			mono.android.TypeManager.Activate ("Flashcards.Fragments.CardBackFragment, Flashcards, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public CardBackFragment (md53636a44826a05b16f9ddc9e6522d2986.MainActivity p0, java.lang.String p1, java.lang.String p2) throws java.lang.Throwable
	{
		super ();
		if (getClass () == CardBackFragment.class)
			mono.android.TypeManager.Activate ("Flashcards.Fragments.CardBackFragment, Flashcards, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Flashcards.MainActivity, Flashcards, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public android.view.View onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2)
	{
		return n_onCreateView (p0, p1, p2);
	}

	private native android.view.View n_onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2);

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
