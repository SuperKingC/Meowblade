using FairyGUI;
using FairyGUI.Utils;

namespace UI.Guide;

public class UI_com_MaincityEntrance : GComponent, IGuidePrompt
{
	public GImage n0;

	public Transition Prompt;

	public const string URL = "ui://5vxjvcrbtiupy";

	public static string Name = "UI_com_MaincityEntrance";

	public static string GetURL()
	{
		return "ui://5vxjvcrbtiupy";
	}

	public static UI_com_MaincityEntrance CreateInstance()
	{
		return (UI_com_MaincityEntrance)(object)UIPackage.CreateObject("Guide", "com_MaincityEntrance");
	}

	public static UI_com_MaincityEntrance CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MaincityEntrance).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://5vxjvcrbtiupy", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		Prompt = ((GComponent)this).GetTransition("Prompt");
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
		((GObject)this).SetXY(((GObject)graph).x, ((GObject)graph).y);
		Prompt.Play();
		return Prompt;
	}

	public void RemoveSelf()
	{
		((GComponent)GRoot.inst).RemoveChild((GObject)(object)this, true);
	}
}
