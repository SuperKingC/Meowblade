using FairyGUI;
using FairyGUI.Utils;
using UnityEngine;

namespace UI.MaskCover;

public class UI_GuideFinger : GComponent
{
	public GMovieClip finger;

	public const string URL = "ui://nhaflg3971lc8";

	public static string Name = "UI_GuideFinger";

	private GObject _targetObj;

	public static string GetURL()
	{
		return "ui://nhaflg3971lc8";
	}

	public static UI_GuideFinger CreateInstance()
	{
		return (UI_GuideFinger)(object)UIPackage.CreateObject("MaskCover", "GuideFinger");
	}

	public static UI_GuideFinger CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GuideFinger).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://nhaflg3971lc8", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		finger = (GMovieClip)((GComponent)this).GetChild("finger");
	}

	public void SoftGuideClick(GObject obj)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		_targetObj = obj;
		obj.parent.AddChild((GObject)(object)this);
		Vector3 val = Vector3.zero;
		if (!obj.pivotAsAnchor)
		{
			val = Vector2.op_Implicit(obj.size * obj.pivot);
		}
		((GObject)this).position = obj.position + val;
		((GObject)this).onClick.Set(new EventCallback1(OnClickFinger));
	}

	private void OnClickFinger(EventContext context)
	{
		_targetObj.onClick.Call((object)context);
		CloseGuide();
	}

	public void CloseGuide()
	{
		if (!((GObject)this).isDisposed && ((GObject)this).parent != null)
		{
			((GObject)this).parent.RemoveChild((GObject)(object)this, true);
		}
	}
}
