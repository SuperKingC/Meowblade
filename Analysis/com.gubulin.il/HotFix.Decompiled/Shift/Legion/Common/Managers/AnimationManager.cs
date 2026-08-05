using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;

namespace Shift.Legion.Common.Managers;

public class AnimationManager : Singleton<AnimationManager>
{
	private static Dictionary<int, string> _stateDict;

	private Dictionary<string, Dictionary<AnimationName, GDEAnimationData>> _modelAnimations;

	public override void InitInstance()
	{
		LoadData();
	}

	private void LoadData()
	{
		_modelAnimations = new Dictionary<string, Dictionary<AnimationName, GDEAnimationData>>();
		IEnumerable<GDEAnimationData> allItems = GDMgr.GetAllItems<GDEAnimationData>();
		foreach (GDEAnimationData item in allItems)
		{
			GDEAnimationData gDEAnimationData = item;
			if (!_modelAnimations.ContainsKey(gDEAnimationData.ModelName))
			{
				_modelAnimations.Add(gDEAnimationData.ModelName, new Dictionary<AnimationName, GDEAnimationData>());
			}
			_modelAnimations[gDEAnimationData.ModelName].Add((AnimationName)gDEAnimationData.Animation, item);
		}
	}

	public Dictionary<AnimationName, GDEAnimationData> GetAnimationsForModel(string modelName)
	{
		return _modelAnimations.ContainsKey(modelName) ? _modelAnimations[modelName] : null;
	}

	public static Dictionary<int, string> get_StateDict()
	{
		if (_stateDict == null)
		{
			Init_stateDict();
		}
		return _stateDict;
	}

	private static void Init_stateDict()
	{
		if (_stateDict == null)
		{
			_stateDict = new Dictionary<int, string>
			{
				{ 1, "idle" },
				{ 10002, "idle2" },
				{ 2, "run" },
				{ 3, "dead" },
				{ 4, "cheer" },
				{ 5, "stun" },
				{ 6, "freeze" },
				{ 11, "attack" },
				{ 21, "skill1" },
				{ 21001, "skill1_1" },
				{ 21002, "skill1_2" },
				{ 21003, "skill1_3" },
				{ 22, "skill2" },
				{ 22001, "skill2_1" },
				{ 22002, "skill2_2" },
				{ 22003, "skill2_3" },
				{ 23, "skill3" },
				{ 23001, "skill3_1" },
				{ 23002, "skill3_2" },
				{ 23003, "skill3_3" },
				{ 24, "skill4" },
				{ 24001, "skill4_1" },
				{ 24002, "skill4_2" },
				{ 24003, "skill4_3" },
				{ 31, "casting1" },
				{ 32, "casting2" },
				{ 33, "casting3" },
				{ 34, "casting4" },
				{ 41, "custom1" },
				{ 42, "custom2" },
				{ 61, "gvg_boss_attack1" },
				{ 62, "gvg_boss_attack2" },
				{ 63, "gvg_boss_attack3" },
				{ 64, "gvg_boss_attack4" },
				{ 65, "gvg_boss_attack5" },
				{ 121, "run1" },
				{ 122, "fx1" },
				{ 123, "fx2" },
				{ 200, "emoji" },
				{ 201, "emoji1" },
				{ 202, "fadeout" },
				{ 203, "work" },
				{ 204, "carry" },
				{ 205, "sleep" },
				{ 206, "work1_1" },
				{ 207, "work2_1" },
				{ 208, "work3_1" },
				{ 209, "work4_1" },
				{ 210, "work5_1" },
				{ 1211, "fx1_dead" },
				{ 1212, "fx1_ice" },
				{ 1213, "fx1_fire" },
				{ 1214, "fx1_thunder" },
				{ 1221, "fx2_0" },
				{ 1222, "fx2_1" },
				{ 1223, "fx2_2" },
				{ 24004, "skill4_4" }
			};
		}
	}

	public static string StateToString(AnimationName state)
	{
		if (_stateDict == null)
		{
			Init_stateDict();
		}
		return _stateDict[(int)state];
	}
}
