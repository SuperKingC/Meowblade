using FairyGUI;
using FairyGUI.Utils;
using UnityEngine;

namespace UI.Guide;

public class UI_arrow : GButton, IGuidePrompt
{
	public Controller button;

	public GImage n4;

	public Transition t0;

	public Transition t1;

	public Transition t2;

	public Transition t3;

	public const string URL = "ui://5vxjvcrbqy8oa";

	public static string Name = "UI_arrow";

	public static string GetURL()
	{
		return "ui://5vxjvcrbqy8oa";
	}

	public static UI_arrow CreateInstance()
	{
		return (UI_arrow)(object)UIPackage.CreateObject("Guide", "arrow");
	}

	public static UI_arrow CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_arrow).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://5vxjvcrbqy8oa", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
		t2 = ((GComponent)this).GetTransition("t2");
		t3 = ((GComponent)this).GetTransition("t3");
	}

	public bool IsDispose()
	{
		return ((GObject)this).isDisposed;
	}

	public void SetVisible(bool changedVisible)
	{
		((GObject)this).visible = changedVisible;
	}

	public void SetAlpha(float changedAlpha)
	{
		((GObject)this).alpha = changedAlpha;
	}

	public Transition PlayTransition(GGraph graph)
	{
		((GObject)this).alpha = 1f;
		float num;
		Transition val;
		if (((GObject)graph).y > (float)Screen.height - (((GObject)graph).y + ((GObject)graph).height))
		{
			num = (((GObject)graph).height + ((GObject)this).height) / -2f;
			val = t0;
		}
		else
		{
			num = (((GObject)graph).height + ((GObject)this).height) / 2f;
			val = t1;
		}
		((GObject)this).SetXY(((GObject)graph).x, ((GObject)graph).y + num);
		val.Play(-1, 0f, (PlayCompleteCallback)null);
		return val;
	}

	public void RemoveSelf()
	{
		((GComponent)GRoot.inst).RemoveChild((GObject)(object)this, true);
	}
}
