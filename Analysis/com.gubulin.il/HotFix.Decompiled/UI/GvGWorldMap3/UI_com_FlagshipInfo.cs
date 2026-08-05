using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

namespace UI.GvGWorldMap3;

public class UI_com_FlagshipInfo : GComponent
{
	public Controller Camp;

	public GImage n3;

	public GLoader n4;

	public GTextField n1;

	public GList Infos;

	public const string URL = "ui://4eq8fgd2h4tpex";

	public static string Name = "UI_com_FlagshipInfo";

	public static string GetURL()
	{
		return "ui://4eq8fgd2h4tpex";
	}

	public static UI_com_FlagshipInfo CreateInstance()
	{
		return (UI_com_FlagshipInfo)(object)UIPackage.CreateObject("GvGWorldMap3", "com_FlagshipInfo");
	}

	public static UI_com_FlagshipInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FlagshipInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2h4tpex", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Camp = ((GComponent)this).GetController("Camp");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GLoader)((GComponent)this).GetChild("n4");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://4eq8fgd2h4tpex".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
		Infos = (GList)((GComponent)this).GetChild("Infos");
	}

	public void OnRender(int campId = 0)
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		if (campId != 0)
		{
			Camp.SetSelectedIndex(campId);
		}
		List<FlagshipInfoType> curFlagshipInfo = Singleton<WorldStateManager>.Instance.Data.PlayerFlagshipInfo.GetCurFlagshipInfo();
		Infos.SetVirtual();
		Infos.itemProvider = new ListItemProvider(GetItemUrl);
		Infos.itemRenderer = new ListItemRenderer(ItemRender);
		Infos.numItems = curFlagshipInfo.Count;
		string GetItemUrl(int index)
		{
			return curFlagshipInfo[index] switch
			{
				FlagshipInfoType.代工任务 => "ui://4eq8fgd2h4tpf1", 
				FlagshipInfoType.旗舰需求 => "ui://4eq8fgd2h4tpf2", 
				FlagshipInfoType.每日补给 => "ui://4eq8fgd2h4tpf0", 
				FlagshipInfoType.污染净化 => "ui://4eq8fgd2h4tpf3", 
				FlagshipInfoType.旗舰食物 => "ui://4eq8fgd2h4tpey", 
				FlagshipInfoType.贡献宝箱 => "ui://4eq8fgd2h4tpez", 
				_ => string.Empty, 
			};
		}
		void ItemRender(int index, GObject obj)
		{
			PlayerFlagshipInfo playerFlagshipInfo = Singleton<WorldStateManager>.Instance.Data.PlayerFlagshipInfo;
			if (curFlagshipInfo[index] == FlagshipInfoType.旗舰食物)
			{
				obj.asCom.GetChild("Food").text = $"{playerFlagshipInfo.FlagShipCurFood}/{playerFlagshipInfo.FlagShipMaxFood}";
			}
			else if (curFlagshipInfo[index] == FlagshipInfoType.代工任务)
			{
				if (playerFlagshipInfo.OEMAmplifiersCanBeReceived)
				{
					obj.asCom.GetController("Status").selectedIndex = 0;
				}
				else if (playerFlagshipInfo.OEMAmplifiersHasFailed)
				{
					obj.asCom.GetController("Status").selectedIndex = 1;
				}
			}
		}
	}
}
