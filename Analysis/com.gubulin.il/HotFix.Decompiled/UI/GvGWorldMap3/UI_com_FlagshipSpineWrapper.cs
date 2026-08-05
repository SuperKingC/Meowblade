using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Spine.Unity;

namespace UI.GvGWorldMap3;

public class UI_com_FlagshipSpineWrapper : GComponent
{
	public Controller Camp;

	public GGraph mask;

	public GGraph FlagshipSpineWrapper;

	public const string URL = "ui://4eq8fgd2wp0gs86";

	public static string Name = "UI_com_FlagshipSpineWrapper";

	public static string GetURL()
	{
		return "ui://4eq8fgd2wp0gs86";
	}

	public static UI_com_FlagshipSpineWrapper CreateInstance()
	{
		return (UI_com_FlagshipSpineWrapper)(object)UIPackage.CreateObject("GvGWorldMap3", "com_FlagshipSpineWrapper");
	}

	public static UI_com_FlagshipSpineWrapper CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FlagshipSpineWrapper).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2wp0gs86", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Camp = ((GComponent)this).GetController("Camp");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		FlagshipSpineWrapper = (GGraph)((GComponent)this).GetChild("FlagshipSpineWrapper");
	}

	public void OnClose()
	{
		((GObject)FlagshipSpineWrapper).displayObject.Dispose();
	}

	public void OnRender(int campId)
	{
		UiHelper.LoadSpine_Addressable(FlagshipSpineWrapper, "GvG/ShipM_flag", 100f, delegate(SkeletonAnimation animation)
		{
			if (!((GObject)this).isDisposed)
			{
				SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, $"Camp{campId}");
				animation.AnimationState.SetAnimation(0, "Idle", true);
			}
		});
	}
}
