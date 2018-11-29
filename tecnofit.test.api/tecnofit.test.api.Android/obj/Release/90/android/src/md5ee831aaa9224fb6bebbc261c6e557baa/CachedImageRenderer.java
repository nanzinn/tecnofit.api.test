package md5ee831aaa9224fb6bebbc261c6e557baa;


public class CachedImageRenderer
	extends md5fe8996628db2722b2645843f91097c26.CachedImageRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("FFImageLoading.Forms.Droid.CachedImageRenderer, FFImageLoading.Forms.Platform", CachedImageRenderer.class, __md_methods);
	}


	public CachedImageRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == CachedImageRenderer.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Forms.Droid.CachedImageRenderer, FFImageLoading.Forms.Platform", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public CachedImageRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == CachedImageRenderer.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Forms.Droid.CachedImageRenderer, FFImageLoading.Forms.Platform", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public CachedImageRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == CachedImageRenderer.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Forms.Droid.CachedImageRenderer, FFImageLoading.Forms.Platform", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
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
