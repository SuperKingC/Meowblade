using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using FairyGUI;
using FairyGUI.Utils;
using UnityEngine;

namespace UI.Contract;

public class UI_RookiePoolBackground : GComponent
{
	public GGraph ComponentMask;

	public UI_RookieCannon RookieCannon0;

	public UI_RookieCannon RookieCannon1;

	public UI_RookieCannon RookieCannon2;

	public const string URL = "ui://avplaivdnle7tkj";

	public static string Name = "UI_RookiePoolBackground";

	private bool IsPlaying { get; set; }

	private UI_ContractPanel parentPanel { get; set; }

	private List<UI_RookieCannon> allCannons { get; set; }

	public static string GetURL()
	{
		return "ui://avplaivdnle7tkj";
	}

	public static UI_RookiePoolBackground CreateInstance()
	{
		return (UI_RookiePoolBackground)(object)UIPackage.CreateObject("Contract", "RookiePoolBackground");
	}

	public static UI_RookiePoolBackground CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RookiePoolBackground).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdnle7tkj", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ComponentMask = (GGraph)((GComponent)this).GetChild("ComponentMask");
		RookieCannon0 = (UI_RookieCannon)(object)((GComponent)this).GetChild("RookieCannon0");
		RookieCannon1 = (UI_RookieCannon)(object)((GComponent)this).GetChild("RookieCannon1");
		RookieCannon2 = (UI_RookieCannon)(object)((GComponent)this).GetChild("RookieCannon2");
	}

	private void GetAllCannon()
	{
		if (!((GObject)this).isDisposed)
		{
			allCannons?.Clear();
			allCannons = new List<UI_RookieCannon>();
			for (int i = 0; i < 3; i++)
			{
				UI_RookieCannon item = ((GComponent)this).GetChild($"RookieCannon{i}") as UI_RookieCannon;
				allCannons.Add(item);
			}
		}
	}

	private void SkipAllCannonWork()
	{
		if (!((GObject)this).isDisposed && allCannons != null)
		{
			for (int i = 0; i < allCannons.Count; i++)
			{
				allCannons[i]?.CardCannonSkip();
			}
		}
	}

	public async void Fire(Action action, UI_ContractPanel panel, List<int> bulletsCount)
	{
		if (panel != null && !((GObject)panel).isDisposed && !((GObject)this).isDisposed)
		{
			parentPanel = panel;
			GetAllCannon();
			action?.Invoke();
			IsPlaying = true;
			((GObject)this).visible = true;
			float fireTotalTime = PlayFire(bulletsCount);
			await Task.Delay(Convert.ToInt32(fireTotalTime * 1000f));
			IsPlaying = false;
			End();
			panel.RookiePoolContent.Init(panel.NewbieGACHADrawResult, panel);
		}
	}

	private void End()
	{
		IsPlaying = false;
		((GObject)this).visible = false;
	}

	private float PlayFire(List<int> bulletsCount)
	{
		if (!((GObject)parentPanel.InterruptBack).touchable || ((GObject)parentPanel).isDisposed || ((GObject)this).isDisposed)
		{
			return 0f;
		}
		parentPanel.GetAllTarget();
		float num = 0f;
		for (int i = 0; i < bulletsCount.Count; i++)
		{
			float num2 = 0.45f + 0.15f * (float)i;
			UI_RookieCannon uI_RookieCannon = allCannons?[i];
			uI_RookieCannon?.CardCannonOpen();
			for (int j = 0; j < bulletsCount[i]; j++)
			{
				int num3 = j;
				UI_bullet bullet = null;
				parentPanel.CreatBullet.Add(((MonoBehaviour)FGUIManager.Instance).StartCoroutine(parentPanel.GetABullet(bullet, num3, 0.125f * (float)j, playReload: false)));
				parentPanel.SetBulletPath.Add(((MonoBehaviour)FGUIManager.Instance).StartCoroutine(SetABulletPath(num3 + i * 10, 0.25f + num2, uI_RookieCannon)));
				num2 += ((j % 2 == 0) ? 0.75f : 0.5f);
			}
			num = num2;
			parentPanel.CannonMoveCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(CannonMove(num2 + 2f, uI_RookieCannon));
		}
		parentPanel.mainCurtainMoveCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(MainCurtainMove(num + 3f));
		return num + 3f;
	}

	private IEnumerator CannonMove(float delay, UI_RookieCannon cannon)
	{
		yield return (object)new WaitForSeconds(delay);
		if (((GObject)parentPanel).isDisposed || ((GObject)this).isDisposed || cannon == null || ((GObject)cannon).isDisposed)
		{
			yield break;
		}
		parentPanel.pageController.selectedIndex = 2;
		((GObject)parentPanel.diamondAddBtn).visible = false;
		((GObject)parentPanel.addTicketBtn).visible = false;
		((GObject)parentPanel.addCouponBtn).visible = false;
		parentPanel.cannonMoveY = ((GObject)RookieCannon1).TweenMoveY(((GObject)this).height, 0.5f).OnComplete((GTweenCallback)delegate
		{
			if (!((GObject)parentPanel).isDisposed)
			{
				parentPanel.cannonMoveY = null;
			}
		});
		parentPanel.CannonMoveCoroutine = null;
	}

	private IEnumerator MainCurtainMove(float delay)
	{
		yield return (object)new WaitForSeconds(delay);
		if (!((GObject)parentPanel).isDisposed && !((GObject)this).isDisposed)
		{
			parentPanel.CardStageClose();
			parentPanel.CardHornOpen();
			parentPanel.mainCurtainMoveCoroutine = null;
		}
	}

	private IEnumerator SetABulletPath(int num, float delay, UI_RookieCannon cannon)
	{
		yield return (object)new WaitForSeconds(delay);
		if (((GObject)parentPanel).isDisposed || cannon == null || ((GObject)cannon).isDisposed || ((GObject)this).isDisposed)
		{
			yield break;
		}
		UI_bullet bullet = parentPanel.bullets[num];
		((GObject)cannon.graph).displayObject.Dispose();
		string explosionSfxName = "cannon_smoke_explosion";
		FGUIManager.Instance.AddTextSpecialEffects(cannon.graph, explosionSfxName, new Vector3(110f, 110f, 110f), "Default", 0.5f, delegate(GameObject cannonSmokeExplosion)
		{
			cannonSmokeExplosion.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
		});
		cannon.CardCannonWork();
		int index = Random.Range(0, parentPanel.targetList.Count);
		GButton button = parentPanel.targetList[index];
		parentPanel.targetList.RemoveAt(index);
		Vector2 startPos = ((GObject)cannon).TransformPoint(((GObject)cannon.graph).xy, (GObject)(object)parentPanel.batteryLucency);
		((GObject)bullet).SetXY(startPos.x, startPos.y);
		Vector2 pos = ((GObject)parentPanel.mapLoader.component).TransformPoint(((GObject)button).xy, (GObject)(object)parentPanel.batteryLucency);
		((GObject)bullet).alpha = 1f;
		bullet.right_handed.Play(-1, 0f, (PlayCompleteCallback)null);
		((GObject)bullet).TweenMove(pos, 1.5f).SetEase((EaseType)5);
		string fallingSfxName = "cannonball_falling";
		GTweenCallback val = default(GTweenCallback);
		GTweenCallback val4 = default(GTweenCallback);
		((GObject)bullet).TweenFade(1f, 0.2f).OnComplete((GTweenCallback)delegate
		{
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Expected O, but got Unknown
			//IL_0044: Expected O, but got Unknown
			GTweener obj = ((GObject)bullet).TweenScale(new Vector2(0.1f, 0.1f), 1.8f).SetEase((EaseType)5);
			GTweenCallback obj2 = val;
			if (obj2 == null)
			{
				GTweenCallback val2 = delegate
				{
					//IL_004d: Unknown result type (might be due to invalid IL or missing references)
					//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
					//IL_00be: Unknown result type (might be due to invalid IL or missing references)
					//IL_00c0: Expected O, but got Unknown
					//IL_00c5: Expected O, but got Unknown
					bullet.right_handed.Stop();
					((GObject)bullet.carrier).displayObject.Dispose();
					FGUIManager.Instance.AddTextSpecialEffects(bullet.carrier, fallingSfxName, new Vector3(500f, 500f, 500f), "Default", 0.5f, delegate(GameObject cannonballFalling)
					{
						cannonballFalling.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
						UiAudioManager.Instance.LoadSoundsForSfx(cannonballFalling, "BulletBlast", playLoop: false, 0.25f);
					});
					((GObject)bullet).alpha = 0f;
					GTweener obj3 = ((GObject)bullet).TweenFade(0f, 1f);
					GTweenCallback obj4 = val4;
					if (obj4 == null)
					{
						GTweenCallback val5 = delegate
						{
							((GObject)bullet).Dispose();
						};
						GTweenCallback val6 = val5;
						val4 = val5;
						obj4 = val6;
					}
					obj3.OnComplete(obj4);
				};
				GTweenCallback val3 = val2;
				val = val2;
				obj2 = val3;
			}
			obj.OnComplete(obj2);
		});
	}

	public void Stop()
	{
		SkipAllCannonWork();
		End();
	}
}
