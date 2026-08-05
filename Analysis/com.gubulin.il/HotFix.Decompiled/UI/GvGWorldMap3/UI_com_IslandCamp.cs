using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using UnityEngine;

namespace UI.GvGWorldMap3;

public class UI_com_IslandCamp : GComponent
{
	public Controller Camp;

	public Controller IslandType;

	public Controller Type;

	public GLoader n11;

	public UI_com_IslandIconContainer IslandIconContainer;

	public GImage n12;

	public GLoader n1;

	public GTextField n3;

	public GTextField IslandName;

	public GTextField n5;

	public GTextField n18;

	public GTextField n19;

	public GTextField n20;

	public GTextField n21;

	public GGroup n22;

	public const string URL = "ui://4eq8fgd2jxsodo";

	public static string Name = "UI_com_IslandCamp";

	private List<GLoader> gLoaders = new List<GLoader>();

	public static string GetURL()
	{
		return "ui://4eq8fgd2jxsodo";
	}

	public static UI_com_IslandCamp CreateInstance()
	{
		return (UI_com_IslandCamp)(object)UIPackage.CreateObject("GvGWorldMap3", "com_IslandCamp");
	}

	public static UI_com_IslandCamp CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_IslandCamp).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2jxsodo", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Expected O, but got Unknown
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Camp = ((GComponent)this).GetController("Camp");
		IslandType = ((GComponent)this).GetController("IslandType");
		Type = ((GComponent)this).GetController("Type");
		n11 = (GLoader)((GComponent)this).GetChild("n11");
		IslandIconContainer = (UI_com_IslandIconContainer)(object)((GComponent)this).GetChild("IslandIconContainer");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n1 = (GLoader)((GComponent)this).GetChild("n1");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://4eq8fgd2jxsodo".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		IslandName = (GTextField)((GComponent)this).GetChild("IslandName");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id2 = "ui://4eq8fgd2jxsodo".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id2);
		n18 = (GTextField)((GComponent)this).GetChild("n18");
		string id3 = "ui://4eq8fgd2jxsodo".Replace("ui://", "") + "-" + ((GObject)n18).id;
		((GObject)n18).text = LanguagesManager.GetDesc(id3);
		n19 = (GTextField)((GComponent)this).GetChild("n19");
		string id4 = "ui://4eq8fgd2jxsodo".Replace("ui://", "") + "-" + ((GObject)n19).id;
		((GObject)n19).text = LanguagesManager.GetDesc(id4);
		n20 = (GTextField)((GComponent)this).GetChild("n20");
		string id5 = "ui://4eq8fgd2jxsodo".Replace("ui://", "") + "-" + ((GObject)n20).id;
		((GObject)n20).text = LanguagesManager.GetDesc(id5);
		n21 = (GTextField)((GComponent)this).GetChild("n21");
		string id6 = "ui://4eq8fgd2jxsodo".Replace("ui://", "") + "-" + ((GObject)n21).id;
		((GObject)n21).text = LanguagesManager.GetDesc(id6);
		n22 = (GGroup)((GComponent)this).GetChild("n22");
	}

	public void OnRender(IslandStateModel islandState)
	{
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		IslandConfigData islandConfigData = WorldMapConfigHelper.Configs.TryGetIsland(islandState.IslandId);
		((GObject)IslandName).text = islandConfigData.Name;
		if (Define.GvGMode3UnderTesting)
		{
			GTextField islandName = IslandName;
			((GObject)islandName).text = ((GObject)islandName).text + $"({islandState.IslandId})";
		}
		Camp.selectedIndex = islandState.CampId;
		eIslandType type = islandConfigData.Props.Type;
		IslandType.SetSelectedIndex((int)type);
		IslandController islandController = GvGWorldMapController.Instance.LoaderManager.GetIslandController(islandState.IslandId);
		if ((Object)(object)islandController == (Object)null)
		{
			return;
		}
		Vector2 scale = default(Vector2);
		if (islandConfigData.Props.Type == eIslandType.MainMoon || islandConfigData.Props.Type == eIslandType.Moon)
		{
			((Vector2)(ref scale))._002Ector(0.5f, 0.5f);
		}
		else if (islandConfigData.Props.SpriteGroup.Contains("small"))
		{
			((Vector2)(ref scale))._002Ector(0.92f, 0.92f);
		}
		else
		{
			((Vector2)(ref scale))._002Ector(0.58f, 0.58f);
		}
		Transform val = ((Component)islandController).transform.Find("Root/IslandPlane/plane/sprite");
		Transform val2 = ((Component)islandController).transform.Find("Root/IslandPlane/IslandDeco/sprite");
		if (!((Object)(object)val != (Object)null))
		{
			return;
		}
		SpriteRenderer[] componentsInChildren = ((Component)val).GetComponentsInChildren<SpriteRenderer>();
		SpriteRenderer[] array = componentsInChildren;
		foreach (SpriteRenderer val3 in array)
		{
			if (Object.op_Implicit((Object)(object)val3.sprite))
			{
				GLoader item = MakeGLoaderFromSpriteRenderer(val3, val, scale);
				gLoaders.Add(item);
			}
		}
		if (!((Object)(object)val2 != (Object)null))
		{
			return;
		}
		SpriteRenderer[] componentsInChildren2 = ((Component)val2).GetComponentsInChildren<SpriteRenderer>();
		SpriteRenderer[] array2 = componentsInChildren2;
		foreach (SpriteRenderer val4 in array2)
		{
			if (Object.op_Implicit((Object)(object)val4.sprite))
			{
				GLoader item2 = MakeGLoaderFromSpriteRenderer(val4, val, scale);
				gLoaders.Add(item2);
			}
		}
	}

	public void OnClose()
	{
		foreach (GLoader gLoader in gLoaders)
		{
			((GObject)gLoader).Dispose();
		}
	}

	private GLoader MakeGLoaderFromSpriteRenderer(SpriteRenderer sr, Transform source, Vector2 scale)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = EffectHelper.WorldToFguiPos(((Component)sr).transform.position) - EffectHelper.WorldToFguiPos(source.position);
		float num = Camera.main.orthographicSize / 6f;
		val *= num;
		GLoader val2 = new GLoader();
		((GComponent)IslandIconContainer).AddChild((GObject)(object)val2);
		val2.texture = new NTexture(sr.sprite);
		val2.autoSize = true;
		((GObject)val2).SetPivot(0.5f, 0.5f, true);
		((GObject)val2).SetXY(((GObject)IslandIconContainer).width / 2f + val.x * 1.414f, ((GObject)IslandIconContainer).height / 2f + val.y * 1.414f);
		((GObject)IslandIconContainer).SetScale(scale.x, scale.y);
		return val2;
	}
}
