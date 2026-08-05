using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Spine.Unity;
using UnityEngine;

namespace UI.Restart;

public class UI_RestartPanel : GComponent, IUiController
{
	public GGraph Mask;

	public UI_ConfirmDialog Dialog;

	public Transition ShowDialog;

	public const string URL = "ui://5mgjx17ngb510";

	public static string Name = "UI_RestartPanel";

	private List<string> textureList = new List<string>();

	private int freeCount;

	private string costKey;

	private int costValue;

	private Action action;

	private string battleId;

	private Level curLevel;

	private bool toUnloadAni = false;

	public static string GetURL()
	{
		return "ui://5mgjx17ngb510";
	}

	public static UI_RestartPanel CreateInstance()
	{
		return (UI_RestartPanel)(object)UIPackage.CreateObject("Restart", "RestartPanel");
	}

	public static UI_RestartPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RestartPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://5mgjx17ngb510", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_ConfirmDialog)(object)((GComponent)this).GetChild("Dialog");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters.TryGetValue("FreeCount", out var value))
		{
			freeCount = (int)value;
		}
		if (parameters.TryGetValue("Cost", out var value2))
		{
			Dictionary<string, int> dictionary = (Dictionary<string, int>)value2;
			if (dictionary != null)
			{
				KeyValuePair<string, int> keyValuePair = dictionary.First();
				costKey = keyValuePair.Key;
				costValue = keyValuePair.Value;
			}
		}
		if (parameters.TryGetValue("Action", out var value3))
		{
			action = (Action)value3;
		}
		if (parameters.TryGetValue("BattleId", out var value4))
		{
			battleId = (string)value4;
		}
		if (parameters.TryGetValue("CurLevel", out var value5))
		{
			curLevel = (Level)value5;
		}
		DialogRender();
	}

	private void DialogRender()
	{
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Expected O, but got Unknown
		if (freeCount >= 1)
		{
			Dialog.Type.selectedIndex = 1;
			((GObject)Dialog.freeText).text = string.Format("{0} {1}/1", LanguagesManager.GetDesc("CsharpCodeZhTcText534"), freeCount);
		}
		else
		{
			Dialog.Type.selectedIndex = 0;
			FGUIManager.Instance.SetItemIconAndFrame(((GComponent)Dialog.DialogMiddleContent.ConsumptionItem).GetChild("icon").asLoader, costKey, textureList);
			GComponent asCom = ((GComponent)Dialog.DialogMiddleContent.ConsumptionItem).GetChild("reqDesc").asCom;
			int stock = GameManagers.Instance.StockController.GetStock(costKey);
			string text = ((stock < costValue) ? "#DC143C" : "#F6E2B2");
			string text2 = "#F6E2B2";
			GComponent asCom2 = asCom.GetChild("originPrice").asCom;
			((GObject)asCom2).SetSize(0f, 0f);
			((GObject)asCom2).visible = false;
			if (stock < costValue)
			{
				((GObject)Dialog.RefreshCardBtn).enabled = false;
			}
			else
			{
				((GObject)Dialog.RefreshCardBtn).enabled = true;
			}
			int number = stock;
			GTextField asTextField = asCom.GetChild("curPrice").asTextField;
			((GObject)asTextField).text = $"[color={text}]{number.ShortNumberFormat()}[/color][color={text2}]/{costValue}[/color]";
			((GObject)Dialog.DialogMiddleContent).onClick.Set((EventCallback0)delegate
			{
				FGUIManager.Instance.ItemTip(costKey, ((GObject)this).sortingOrder, noCheckBtn: true);
			});
		}
		SpineInit();
	}

	private void SpineInit()
	{
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		GameObject canvasObject = default(GameObject);
		ref GameObject reference = ref canvasObject;
		Object obj = Object.Instantiate(Resources.Load("SpineTest", typeof(GameObject)));
		reference = (GameObject)(object)((obj is GameObject) ? obj : null);
		SpawnManager.Instance.LoadAnimation("Goblinworker_UI_001").Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
		{
			if (!((GObject)this).isDisposed)
			{
				toUnloadAni = true;
				GameObject obj2 = canvasObject;
				SkeletonAnimation val2 = ((obj2 != null) ? obj2.GetComponent<SkeletonAnimation>() : null);
				if ((Object)(object)val2 != (Object)null && (Object)(object)asset != (Object)null)
				{
					((SkeletonRenderer)val2).skeletonDataAsset = asset;
					((SkeletonRenderer)val2).Initialize(true);
					SpineHelper.SetSkin((ISkeletonAnimation)(object)val2, "skin_fuben");
					val2.AnimationState.AddAnimation(0, "idle", true, 0f);
				}
			}
		});
		if ((Object)(object)canvasObject != (Object)null)
		{
			canvasObject.transform.localScale = new Vector3(130f, 130f, 130f);
			canvasObject.transform.localPosition = -new Vector3(0f, 0f, 0f);
			canvasObject.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
			GoWrapper val = new GoWrapper(canvasObject);
			((DisplayObject)val).SetXY(0f, 0f);
			((DisplayObject)val).pivot = new Vector2(0.5f, 0.5f);
			((DisplayObject)val).scaleX = 1f;
			Dialog.SpineBack.SetNativeObject((DisplayObject)(object)val);
		}
	}

	public void OnShow()
	{
		ShowDialog.Play();
	}

	private void RestartLevel()
	{
		ILRequestHelper<RevokeBattleResponse>.Request((EventContext)null, (Func<Task<RevokeBattleResponse>>)(() => GameController.Contexts.Service<INetworkService>().RevokeBattle(battleId)), (Action<RevokeBattleResponse>)delegate(RevokeBattleResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				End();
				if (freeCount < 1)
				{
					StockChangeRecord[] stockChangeRecords = new StockChangeRecord[1]
					{
						new StockChangeRecord
						{
							ItemId = costKey,
							Offset = -costValue,
							Context = 35,
							ContextValue = curLevel.LevelId,
							Type = 1
						}
					};
					GameManagers.Instance.StockController.ReadStockChangeRecords(stockChangeRecords);
				}
				List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText533") };
				SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)this).sortingOrder + 1, arg3: false);
				if (response.RedTeamRevivedSoldiers != null && response.RedTeamRevivedSoldiers.Count > 0)
				{
					List<string> tipList2 = new List<string>();
					foreach (KeyValuePair<string, int> redTeamRevivedSoldier in response.RedTeamRevivedSoldiers)
					{
						Soldier soldier = GameManagers.Instance.SoldierManager.Get(redTeamRevivedSoldier.Key);
						tipList2.Add(string.Format("{0}{1}X{2}", LanguagesManager.GetDesc("CsharpCodeZhTcText535"), soldier.Name, redTeamRevivedSoldier.Value));
					}
					ScriptApi.CreateTimer(0.5f, delegate
					{
						SharedMessenger.Broadcast("SHOW_TIPS", tipList2, ((GObject)this).sortingOrder + 1, arg3: false);
					});
				}
				GameManagers.Instance.UserArchiveManager.SaveLevelEnemiesHp(curLevel, Team.Blue, response.BlueTeamHp);
				action?.Invoke();
			}
		});
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		((GObject)Mask).onClick.Add(new EventCallback0(End));
		((GObject)Dialog.RefreshCardBtn).onClick.Add(new EventCallback0(RestartLevel));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		((GObject)Mask).onClick.Remove(new EventCallback0(End));
		((GObject)Dialog.RefreshCardBtn).onClick.Remove(new EventCallback0(RestartLevel));
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
		if (toUnloadAni)
		{
			SpawnManager.Instance.UnloadAnimation("Goblinworker_UI_001");
		}
	}
}
