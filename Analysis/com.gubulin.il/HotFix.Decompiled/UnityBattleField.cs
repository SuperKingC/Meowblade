using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using DG.Tweening.Core;
using Entitas;
using GameDataEditor;
using GameMaths;
using HotFix;
using HotFix.Base.Scripts.Chapter;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Scripts.UI;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class UnityBattleField : MonoBehaviour, IPooled, IBattleField, IEventListener, IAnyBattleStartedListener, IAnyBattleStartedRemovedListener, IAnyCurrentLevelBattleStartedListener, IAnyCurrentLevelBattleStartedRemovedListener, IAnyBattleFieldLevelListener, IAnyBattleFieldMapIdentifierListener, IPositionListener, IVisibleListener, IVisibleRemovedListener, IGameDestroyedListener, IAnyBattleConfigListener, IAssetRemovedListener
{
	private const string MAP_NAME = "序章1";

	private static bool _firstFlag;

	private IMapBackgroundController background;

	[SerializeField]
	private GameObject redCamp;

	private GameObject redCamp2;

	private const string RedCamp2Name = "camp2";

	[SerializeField]
	private GameObject blueCamp;

	private GameObject blueCamp2;

	private GameObject Rank_Deco1;

	private const string BlueCamp2Name = "enemyCamp2";

	private const float CampRepeatWidth = 6.34f;

	private GameObject redCampPrefab;

	private GameObject blueCampPrefab;

	[SerializeField]
	private GameObject container;

	private Dictionary<int, GameObject> _stagingAreas;

	private GameStateEntity _gameStateEntity;

	private ConfigEntity _configEntity;

	private AsyncOperationHandle<GameObject> _handleCrystal;

	private Sprite _campIcon;

	private Sprite _enemyCampIcon;

	private string _mapIdentifier;

	private string _levelId;

	[SerializeField]
	private GameObject crystal;

	[SerializeField]
	private GameObject character1;

	[SerializeField]
	private GameObject character2;

	[SerializeField]
	private GameObject character3;

	private GameEntity _entity;

	private Tween _tween;

	private float ratio;

	private Contexts _contexts;

	private List<string> loaded_asset;

	private List<GameObject> FXWhenBattleFirstFrame;

	private string[] _oldSoldiers = new string[12];

	public IMapBackgroundController BackgroundController => background;

	public int opUniqueId { get; set; }

	public bool Active { get; set; }

	private void Awake()
	{
		FXWhenBattleFirstFrame = new List<GameObject>();
		loaded_asset = new List<string>();
		float num = 1.7777778f;
		float num2 = (float)Screen.width / (float)Screen.height;
		ratio = num2 / num;
		redCamp = ((Component)((Component)this).transform.Find("Container/RedCamp")).gameObject;
		blueCamp = ((Component)((Component)this).transform.Find("Container/BlueCamp")).gameObject;
		Transform obj = ((Component)this).transform.Find("Container/Rank_Deco1");
		Rank_Deco1 = ((obj != null) ? ((Component)obj).gameObject : null);
		if ((Object)(object)Rank_Deco1 != (Object)null)
		{
			Rank_Deco1.SetActive(false);
		}
		container = ((Component)((Component)this).transform.Find("Container")).gameObject;
		crystal = ((Component)((Component)this).transform.Find("Container/_Crystal")).gameObject;
		character1 = ((Component)((Component)this).transform.Find("Container/_Character1")).gameObject;
		character2 = ((Component)((Component)this).transform.Find("Container/_Character2")).gameObject;
		character3 = ((Component)((Component)this).transform.Find("Container/_Character3")).gameObject;
	}

	private void LoadRedCamp2()
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		if (!((Object)(object)redCamp2 != (Object)null) && !((Object)(object)redCamp == (Object)null) && redCamp.activeSelf && !(ratio <= 1f))
		{
			redCamp2 = new GameObject();
			SpriteRenderer _renderer = redCamp2.AddComponent<SpriteRenderer>();
			_renderer.drawMode = (SpriteDrawMode)2;
			SpriteRenderer _redCampSprite = redCamp.GetComponent<SpriteRenderer>();
			((Renderer)_renderer).sortingLayerName = "Entities";
			((Renderer)_renderer).sortingOrder = ((Renderer)_redCampSprite).sortingOrder;
			AssetsManager.Instance.LoadAsset<Sprite>("camp2").Then((Action<Sprite>)delegate(Sprite asset)
			{
				//IL_0035: Unknown result type (might be due to invalid IL or missing references)
				//IL_003f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0050: Unknown result type (might be due to invalid IL or missing references)
				//IL_0060: Unknown result type (might be due to invalid IL or missing references)
				//IL_0081: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
				//IL_0103: Unknown result type (might be due to invalid IL or missing references)
				//IL_012e: Unknown result type (might be due to invalid IL or missing references)
				//IL_014a: Unknown result type (might be due to invalid IL or missing references)
				//IL_0164: Unknown result type (might be due to invalid IL or missing references)
				//IL_016e: Unknown result type (might be due to invalid IL or missing references)
				loaded_asset.Add("camp2");
				_renderer.sprite = asset;
				_renderer.size = new Vector2(19.02f, _renderer.size.y);
				float num = (_renderer.size.x + _redCampSprite.size.x) / 2f * redCamp.transform.localScale.x;
				redCamp2.transform.parent = redCamp.transform.parent;
				redCamp2.transform.localEulerAngles = redCamp.transform.localEulerAngles;
				redCamp2.transform.localScale = redCamp.transform.localScale;
				redCamp2.transform.localPosition = new Vector3(redCamp.transform.localPosition.x - num, redCamp.transform.localPosition.y, redCamp.transform.localPosition.z);
				redCamp2.transform.parent = redCamp.transform;
				((Object)redCamp2).name = "RedCamp2";
			});
		}
	}

	private void LoadBlueCamp2()
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		if (!((Object)(object)blueCamp2 != (Object)null) && !((Object)(object)blueCamp == (Object)null) && blueCamp.activeSelf && !(ratio <= 1f))
		{
			blueCamp2 = new GameObject();
			SpriteRenderer _renderer = blueCamp2.AddComponent<SpriteRenderer>();
			_renderer.drawMode = (SpriteDrawMode)2;
			SpriteRenderer _blueCampSprite = blueCamp.GetComponent<SpriteRenderer>();
			((Renderer)_renderer).sortingLayerName = "Entities";
			((Renderer)_renderer).sortingOrder = ((Renderer)_blueCampSprite).sortingOrder;
			AssetsManager.Instance.LoadAsset<Sprite>("enemyCamp2").Then((Action<Sprite>)delegate(Sprite asset)
			{
				//IL_0035: Unknown result type (might be due to invalid IL or missing references)
				//IL_003f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0050: Unknown result type (might be due to invalid IL or missing references)
				//IL_0060: Unknown result type (might be due to invalid IL or missing references)
				//IL_0081: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
				//IL_0103: Unknown result type (might be due to invalid IL or missing references)
				//IL_012e: Unknown result type (might be due to invalid IL or missing references)
				//IL_014a: Unknown result type (might be due to invalid IL or missing references)
				//IL_0164: Unknown result type (might be due to invalid IL or missing references)
				//IL_016e: Unknown result type (might be due to invalid IL or missing references)
				loaded_asset.Add("enemyCamp2");
				_renderer.sprite = asset;
				_renderer.size = new Vector2(19.02f, _renderer.size.y);
				float num = (_renderer.size.x + _blueCampSprite.size.x) / 2f * blueCamp.transform.localScale.x;
				blueCamp2.transform.parent = blueCamp.transform.parent;
				blueCamp2.transform.localEulerAngles = blueCamp.transform.localEulerAngles;
				blueCamp2.transform.localScale = blueCamp.transform.localScale;
				blueCamp2.transform.localPosition = new Vector3(blueCamp.transform.localPosition.x + num, blueCamp.transform.localPosition.y, blueCamp.transform.localPosition.z);
				blueCamp2.transform.parent = blueCamp.transform;
				((Object)blueCamp2).name = "BlueCamp2";
			});
		}
	}

	public void Initialize(Contexts contexts, GameEntity entity)
	{
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		_contexts = contexts;
		_entity = entity;
		_oldSoldiers = new string[12];
		Level levelInstance = GameManagers.Instance.ChapterManager.GetLevelInstance(entity.levelId.value);
		if (_stagingAreas == null)
		{
			_stagingAreas = new Dictionary<int, GameObject>();
		}
		FGUIManager.Instance.formationMarks = _stagingAreas;
		if (contexts.gameState.isBattleStarted)
		{
			OnAnyBattleStarted(null);
		}
		else
		{
			OnAnyBattleStartedRemoved(null);
		}
		OnAnyBattleFieldMapIdentifier(null, levelInstance.Data.MapIdentifier);
		OnAnyRedTeamCampPosition(null, ClientBattleFieldLogic.GetCampPosition(Team.Red, levelInstance.Data.Length));
		OnAnyBlueTeamCampPosition(null, ClientBattleFieldLogic.GetCampPosition(Team.Blue, levelInstance.Data.Length));
		if (entity.isVisible)
		{
			OnVisible(entity);
		}
		else
		{
			OnVisibleRemoved(entity);
		}
	}

	public void UnSpawn()
	{
	}

	public void OnInstantiate()
	{
	}

	public void OnUnSpawn()
	{
		UnregisterListeners();
		_entity = null;
		ClearTween();
		if (_stagingAreas == null)
		{
			return;
		}
		foreach (GameObject value in _stagingAreas.Values)
		{
			Object.Destroy((Object)(object)value);
		}
		_stagingAreas.Clear();
		_stagingAreas = null;
	}

	private void ClearTween()
	{
		if (_tween != null && TweenExtensions.IsPlaying(_tween))
		{
			TweenExtensions.Pause<Tween>(_tween);
			TweenExtensions.Kill(_tween, false);
		}
		_tween = null;
	}

	public void RegisterListeners()
	{
		_entity.AddGameDestroyedListener(this);
		_entity.AddPositionListener(this);
		_entity.AddVisibleListener(this);
		_entity.AddAssetRemovedListener(this);
		_gameStateEntity = ((Context<GameStateEntity>)_contexts.gameState).CreateEntity();
		_gameStateEntity.AddAnyBattleFieldMapIdentifierListener(this);
		_gameStateEntity.AddAnyBattleStartedListener(this);
		_gameStateEntity.AddAnyBattleStartedRemovedListener(this);
		_gameStateEntity.AddAnyCurrentLevelBattleStartedListener(this);
		_gameStateEntity.AddAnyCurrentLevelBattleStartedRemovedListener(this);
		_configEntity = ((Context<ConfigEntity>)_contexts.config).CreateEntity();
		_configEntity.AddAnyBattleConfigListener(this);
		SharedMessenger.AddListener<Team>("STAGING_AREA_POSITIONS_CHANGED", OnStagingAreaPositionsChanged);
	}

	public void UnregisterListeners()
	{
		_entity.RemoveGameDestroyedListener(this);
		_entity.RemovePositionListener(this);
		_entity.RemoveVisibleListener(this);
		_entity.RemoveAssetRemovedListener(this);
		_gameStateEntity.RemoveAnyBattleFieldMapIdentifierListener(this);
		_gameStateEntity.RemoveAnyBattleStartedListener(this);
		_gameStateEntity.RemoveAnyBattleStartedRemovedListener(this);
		_gameStateEntity.RemoveAnyCurrentLevelBattleStartedListener(this);
		_gameStateEntity.RemoveAnyCurrentLevelBattleStartedRemovedListener(this);
		((Entity)_gameStateEntity).Destroy();
		_configEntity.RemoveAnyBattleConfigListener(this);
		((Entity)_configEntity).Destroy();
		SharedMessenger.RemoveListener<Team>("STAGING_AREA_POSITIONS_CHANGED", OnStagingAreaPositionsChanged);
	}

	public void PlayAnimationWhenBattleStart()
	{
		foreach (GameObject item in FXWhenBattleFirstFrame)
		{
			item.SetActive(true);
		}
		ScriptApi.CreateTimer(1.5f, delegate
		{
			foreach (GameObject item2 in FXWhenBattleFirstFrame)
			{
				SpawnManager.Instance.Destroy(item2);
			}
			FXWhenBattleFirstFrame.Clear();
		});
	}

	public void PlaySpawnUnitsAnimation()
	{
		foreach (KeyValuePair<int, GameObject> stagingArea in _stagingAreas)
		{
			StagingArea component = stagingArea.Value.GetComponent<StagingArea>();
			component.PlayPortalAnimation();
		}
	}

	public void OnAnyBattleFieldMapIdentifier(GameStateEntity entity, string value)
	{
		//IL_0312: Unknown result type (might be due to invalid IL or missing references)
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_0450: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bf: Unknown result type (might be due to invalid IL or missing references)
		if (GameManagers.Instance == null || _entity == null || _contexts == null)
		{
			return;
		}
		Level level = GameManagers.Instance.ChapterManager.GetLevelInstance(_entity.levelId.value);
		if (level == null)
		{
			ILRuntimeDebug.LogError("OnAnyBattleFieldMapIdentifier level is null, levelId =", _entity.levelId.value);
		}
		else
		{
			if (level?.Data == null)
			{
				return;
			}
			if (RankDataHelper.IsPvPLevel(level.LevelId) && (Object)(object)Rank_Deco1 != (Object)null)
			{
				Rank_Deco1.SetActive(true);
			}
			bool flag = level.Data.RedTeamBattleMode == 1 || level.Data.BlueTeamBattleMode == 1;
			bool flag2 = RankDataHelper.IsPvPLevel(level.LevelId);
			if (level.HasSubLevels() && _contexts.gameState.hasBattleFieldSubLevelIndex)
			{
				int value2 = _contexts.gameState.battleFieldSubLevelIndex.value;
				Level subLevel = level.GetSubLevel(value2);
				if (subLevel != null)
				{
					level = subLevel;
				}
			}
			InitMapBackground(value, level);
			if (MapBackgroundController.AllMapFxData.TryGetValue(value, out var value3))
			{
				_mapIdentifier = value;
				_levelId = level.LevelId;
				if (!string.IsNullOrEmpty(value3.BackgroundMusic) && UiAudioManager.Instance.bgmSwitch)
				{
					PlayBattleFieldBgm(value3.BackgroundMusic, level.LevelId);
				}
			}
			string opStory = NewGuideModeManager.OpStory;
			if (value == "序章1" && GameManagers.Instance.UserArchiveManager.GetPlayingStories().Contains(opStory) && GameController.Contexts.gameState.hasReplayBattleId && GameController.Contexts.gameState.replayBattleId.value == "STORY0011" && GameController.Contexts.gameState.hasReplayState && GameController.Contexts.gameState.replayState.value != 3)
			{
				character1.SetActive(false);
				character2.SetActive(false);
				character3.SetActive(false);
				crystal.SetActive(false);
				redCamp.SetActive(false);
				blueCamp.SetActive(false);
				return;
			}
			if (value == "序章1")
			{
				redCamp.SetActive(false);
				crystal.SetActive(true);
				character1.SetActive(true);
				character2.SetActive(true);
				character3.SetActive(false);
				blueCamp.SetActive(true);
				if (!_handleCrystal.IsValid())
				{
					_handleCrystal = Addressables.LoadAssetAsync<GameObject>((object)"RedCrystal");
					_handleCrystal.Task.GetAwaiter().OnCompleted(delegate
					{
						Object.Instantiate<GameObject>(_handleCrystal.Result, crystal.transform);
					});
				}
			}
			else if (value == "新手2")
			{
				redCamp.SetActive(false);
				crystal.SetActive(true);
				character1.SetActive(true);
				character2.SetActive(true);
				character3.SetActive(true);
				if (!_handleCrystal.IsValid())
				{
					_handleCrystal = Addressables.LoadAssetAsync<GameObject>((object)"RedCrystal");
					_handleCrystal.Task.GetAwaiter().OnCompleted(delegate
					{
						Object.Instantiate<GameObject>(_handleCrystal.Result, crystal.transform);
					});
				}
			}
			else
			{
				redCamp.SetActive(true);
				crystal.SetActive(false);
				character1.SetActive(false);
				character2.SetActive(false);
				character3.SetActive(false);
				blueCamp.SetActive(true);
				if (_handleCrystal.IsValid())
				{
					Addressables.Release<GameObject>(_handleCrystal);
				}
			}
			if (level != null && level.Data != null && !string.IsNullOrEmpty(level.Data.RedTeamCampImage))
			{
				redCampPrefab = LoadTeamCampPrefab(level.Data.RedTeamCampImage, in redCampPrefab);
			}
			else
			{
				GameObject obj = redCampPrefab;
				if (obj != null)
				{
					obj.SetActive(false);
				}
				redCamp.SetActive(false);
			}
			if (level != null && level.Data != null && !string.IsNullOrEmpty(level.Data.BlueTeamCampImage))
			{
				blueCampPrefab = LoadTeamCampPrefab(level.Data.BlueTeamCampImage, in blueCampPrefab);
			}
			else
			{
				GameObject obj2 = blueCampPrefab;
				if (obj2 != null)
				{
					obj2.SetActive(false);
				}
				blueCamp.SetActive(false);
			}
			if (flag)
			{
				redCamp.SetActive(true);
				GameObject obj3 = redCampPrefab;
				if (obj3 != null)
				{
					obj3.SetActive(true);
				}
				blueCamp.SetActive(false);
				GameObject obj4 = blueCampPrefab;
				if (obj4 != null)
				{
					obj4.SetActive(false);
				}
			}
			if (flag2)
			{
				redCamp.SetActive(false);
				GameObject obj5 = redCampPrefab;
				if (obj5 != null)
				{
					obj5.SetActive(false);
				}
				blueCamp.SetActive(false);
				GameObject obj6 = blueCampPrefab;
				if (obj6 != null)
				{
					obj6.SetActive(false);
				}
			}
		}
	}

	private void InitMapBackground(string value, Level level)
	{
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		MapBackgroundController.RefreshRatio();
		if (background != null && background.Identifier != value)
		{
			background.ClearBackgrounds();
			background = null;
		}
		if (background == null)
		{
			GameObject gameObject = ((Component)((Component)this).transform.Find("Container/Background")).gameObject;
			Transform transform = gameObject.transform;
			if (PrefabMapController.MapCampConfigs.Keys.Contains(value))
			{
				background = gameObject.AddComponent<PrefabMapController>();
				transform.rotation = Quaternion.identity;
			}
			else
			{
				MapBackgroundController mapBackgroundController = gameObject.AddComponent<MapBackgroundController>();
				mapBackgroundController.StartX = (0f - level.Data.Length) / 2f;
				background = mapBackgroundController;
				transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
			}
			background.SetMapIdentifier(value);
		}
	}

	private void PlayBattleFieldBgm(string backgroundMusic, string levelId)
	{
		if (levelId == "P1120" || levelId == "P1130")
		{
			return;
		}
		List<string> list = backgroundMusic.Split(',').ToList();
		for (int num = list.Count - 1; num >= 0; num--)
		{
			if (list[num].Contains("P1120") || list[num].Contains("P1130"))
			{
				list.RemoveAt(num);
			}
		}
		string text = ((list.Count > 1) ? list[Random.Range(0, list.Count)] : list[0]);
		_entity.ReplaceAudioClipName(text);
		int newValue = (text.Contains("新增") ? 40 : 20);
		_entity.ReplaceAudioVolume(newValue);
	}

	private void PlayBattleFieldBgmOnBattleStart(string backgroundMusic, string levelId)
	{
		if (!(levelId == "P1120") && !(levelId == "P1130"))
		{
			return;
		}
		string[] array = backgroundMusic.Split(',');
		string text = "新增战场BGM";
		for (int num = array.Length - 1; num >= 0; num--)
		{
			if (array[num].Contains(levelId))
			{
				text = array[num];
				break;
			}
		}
		_entity.ReplaceAudioClipName(text);
		int newValue = (text.Contains("新增") ? 40 : 20);
		_entity.ReplaceAudioVolume(newValue);
	}

	private GameObject LoadTeamCampPrefab(string name, in GameObject oldGO)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)oldGO != (Object)null)
		{
			if (name == ((Object)oldGO).name)
			{
				return oldGO;
			}
			Object.Destroy((Object)(object)oldGO);
		}
		AsyncOperationHandle<GameObject> val = Addressables.InstantiateAsync((object)HotFix.Sources.Base.Scripts.Helper.StringExtensions.Format("Prefabs/BattleField/{0}", name), (Transform)null, false, true);
		GameObject val2 = val.WaitForCompletion();
		((Object)val2).name = name;
		val2.transform.SetParent(container.transform, false);
		val2.gameObject.AddComponent<HotFix_AddressablesAutoRelease>().AddHandle(AsyncOperationHandle<GameObject>.op_Implicit(val));
		return val2;
	}

	private void LoadRedTeamCampImage(string image)
	{
		if ((Object)(object)_campIcon == (Object)null)
		{
			AssetsManager.Instance.LoadAsset<Sprite>(image).Then((Action<Sprite>)delegate(Sprite asset)
			{
				loaded_asset.Add(image);
				redCamp.GetComponent<SpriteRenderer>().sprite = asset;
				_campIcon = asset;
				LoadRedCamp2();
			});
		}
		else
		{
			redCamp.GetComponent<SpriteRenderer>().sprite = _campIcon;
		}
	}

	private void LoadBlueTeamCampImage(string image)
	{
		if ((Object)(object)_enemyCampIcon == (Object)null)
		{
			AssetsManager.Instance.LoadAsset<Sprite>(image).Then((Action<Sprite>)delegate(Sprite asset)
			{
				loaded_asset.Add(image);
				blueCamp.GetComponent<SpriteRenderer>().sprite = asset;
				_enemyCampIcon = asset;
				LoadBlueCamp2();
			});
		}
		else
		{
			blueCamp.GetComponent<SpriteRenderer>().sprite = _enemyCampIcon;
		}
	}

	public UnityBattleField(GameObject character3)
	{
		this.character3 = character3;
	}

	public void OnAnyBattleStarted(GameStateEntity entity)
	{
		if (!string.IsNullOrEmpty(_mapIdentifier) && !string.IsNullOrEmpty(_levelId) && MapBackgroundController.AllMapFxData.TryGetValue(_mapIdentifier, out var value) && !string.IsNullOrEmpty(value.BackgroundMusic) && UiAudioManager.Instance.bgmSwitch)
		{
			PlayBattleFieldBgmOnBattleStart(value.BackgroundMusic, _levelId);
		}
		_entity.ReplaceAudioVolume(50);
		Level levelInstance = GameManagers.Instance.ChapterManager.GetLevelInstance(_entity.levelId.value);
		if (levelInstance.Data.RedTeamBattleMode == 2)
		{
			return;
		}
		FXWhenBattleFirstFrame.Clear();
		foreach (KeyValuePair<int, GameObject> stagingArea in _stagingAreas)
		{
			SpawnManager.Instance.DestroyPool(stagingArea.Value);
			int key = stagingArea.Key;
			if (_contexts.config.battleConfig.Red.Units(0, key) != null)
			{
				FXWhenBattleFirstFrame.Add(stagingArea.Value.GetComponent<StagingArea>().CreatePortalAnimation());
			}
		}
		_stagingAreas.Clear();
	}

	public void OnAnyBattleStartedRemoved(GameStateEntity entity)
	{
		_entity.ReplaceAudioVolume(20);
	}

	public void OnAnyCurrentLevelBattleStarted(GameStateEntity entity)
	{
		_entity.ReplaceAudioVolume(50);
	}

	public void OnAnyCurrentLevelBattleStartedRemoved(GameStateEntity entity)
	{
		_entity.ReplaceAudioVolume(20);
	}

	public void OnAnyBattleFieldLevel(GameStateEntity entity, Level value)
	{
	}

	public void OnAnyRedTeamCampPosition(GameStateEntity entity, Vector3 value)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		Vector3 localPosition = redCamp.transform.localPosition;
		redCamp.transform.localPosition = new Vector3(value.x, localPosition.y, localPosition.z);
	}

	public void OnAnyBlueTeamCampPosition(GameStateEntity entity, Vector3 value)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		Vector3 localPosition = blueCamp.transform.localPosition;
		blueCamp.transform.localPosition = new Vector3(value.x, localPosition.y, localPosition.z);
	}

	private void OnDestroy()
	{
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		blueCamp.GetComponent<SpriteRenderer>().sprite = null;
		redCamp.GetComponent<SpriteRenderer>().sprite = null;
		if ((Object)(object)redCamp2 != (Object)null)
		{
			redCamp2.GetComponent<SpriteRenderer>().sprite = null;
		}
		if ((Object)(object)blueCamp2 != (Object)null)
		{
			blueCamp2.GetComponent<SpriteRenderer>().sprite = null;
		}
		background.ClearBackgrounds();
		foreach (string item in loaded_asset)
		{
			AssetsManager.Instance.UnloadAsset<Sprite>(item);
		}
		if (_handleCrystal.IsValid())
		{
			Addressables.Release<GameObject>(_handleCrystal);
		}
	}

	public void OnDestroyed(GameEntity entity)
	{
		SpawnManager.Instance.DestroyPool(((Component)this).gameObject);
	}

	public void OnAssetRemoved(GameEntity entity)
	{
		SpawnManager.Instance.DestroyPool(((Component)this).gameObject);
	}

	public void OnRedTeamStagingAreaPosition()
	{
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0343: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0388: Unknown result type (might be due to invalid IL or missing references)
		//IL_0493: Unknown result type (might be due to invalid IL or missing references)
		Level levelInstance = GameManagers.Instance.ChapterManager.GetLevelInstance(_entity.levelId.value);
		GDELevelAssistanceData gDELevelAssistanceData = null;
		string key = "LevelAssistance_" + levelInstance.LevelId;
		if (GDMgr.Has<GDELevelAssistanceData>(key))
		{
			gDELevelAssistanceData = GDMgr.Get<GDELevelAssistanceData>(key);
		}
		Vector3 localPosition = default(Vector3);
		for (int i = 0; i < 12; i++)
		{
			Vector3 stagingAreaPosition = GameController.Contexts.Service<IStagingService>().GetStagingAreaPosition(Team.Red, i);
			Vector2 stagingAreaSize = ClientBattleFieldLogic.GetStagingAreaSize(Team.Red, i, _contexts.config.battleConfig.Red.FormationId[0]);
			if (!(stagingAreaSize == Vector2.zero))
			{
				if (!_stagingAreas.TryGetValue(i, out var value))
				{
					value = SpawnManager.Instance.InstantiatePool("StagingArea", Vector3.zero, 12);
					value.transform.SetParent(container.transform);
					_stagingAreas.Add(i, value);
				}
				((Vector3)(ref localPosition))._002Ector(stagingAreaPosition.x, stagingAreaPosition.y / 1.414f, stagingAreaPosition.z / 1.414f);
				value.transform.localPosition = localPosition;
				StagingArea stagingArea = value.GetComponent<StagingArea>();
				if ((Object)(object)stagingArea == (Object)null)
				{
					stagingArea = value.AddComponent<StagingArea>();
				}
				stagingArea.HideEffect();
				bool isIsAssistanceSlot = gDELevelAssistanceData != null && gDELevelAssistanceData.EnableAssistance && gDELevelAssistanceData.AssistancePosition.Contains(i + 1) && GameManagers.Instance.UserArchiveManager.IsNewGuideMode();
				stagingArea.SetMode((BattleMode)levelInstance.Data.RedTeamBattleMode, levelInstance.LevelId, isIsAssistanceSlot);
				stagingArea.SetFrameSize(Vector2.op_Implicit(stagingAreaSize));
			}
		}
		Activity levelActivity = GameManagers.Instance.ActivityManager.GetLevelActivity(levelInstance);
		string key2 = ((levelActivity == null) ? levelInstance.FormationContext : levelActivity.FormationTag);
		Dictionary<string, Dictionary<string, List<string>>> value2 = _contexts.config.formationUnits.value;
		if (!value2.TryGetValue(key2, out var value3))
		{
			value3 = new Dictionary<string, List<string>>();
			value2.Add(key2, value3);
		}
		string key3 = levelInstance.BattleMode.ToString();
		if (!value3.TryGetValue(key3, out var value4))
		{
			value4 = new List<string>();
			for (int j = 0; j < 12; j++)
			{
				value4.Add("Unlock");
			}
			value3.Add(key3, value4);
		}
		_contexts.config.ReplaceFormationUnits(value2);
		foreach (KeyValuePair<int, GameObject> stagingArea2 in _stagingAreas)
		{
			bool flag = gDELevelAssistanceData != null && gDELevelAssistanceData.EnableAssistance && gDELevelAssistanceData.LockPosition.Contains(stagingArea2.Key + 1) && GameManagers.Instance.UserArchiveManager.IsNewGuideMode();
			string text = value4[stagingArea2.Key];
			if (flag)
			{
				StagingArea component = stagingArea2.Value.GetComponent<StagingArea>();
				component.SetFrameColor(new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, (byte)160));
			}
			else if (text == "Lock")
			{
				StagingArea component2 = stagingArea2.Value.GetComponent<StagingArea>();
				component2.SetFrameColor(new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, (byte)160));
			}
			else
			{
				StagingArea component3 = stagingArea2.Value.GetComponent<StagingArea>();
				component3.SetFrameColor(new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue));
			}
		}
		if (!(levelInstance.ChapterId == "C1000") && !(levelInstance.ChapterId == "C10000") && !(levelInstance.ChapterId == "C10001") && !(levelInstance.ChapterId == "C1000") && !(levelInstance.ChapterId == "C10002") && !(levelInstance.LevelId == "Live001"))
		{
			return;
		}
		foreach (KeyValuePair<int, GameObject> stagingArea3 in _stagingAreas)
		{
			StagingArea component4 = stagingArea3.Value.GetComponent<StagingArea>();
			component4.SetFrameColor(new Color32((byte)191, (byte)191, (byte)191, (byte)0));
		}
	}

	public void OnPosition(GameEntity entity, Vector3 value)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		ClearTween();
		if (!(((Component)this).transform.position == Vector3.op_Implicit(value)))
		{
			_tween = (Tween)(object)DOTween.To((DOGetter<Vector3>)(() => ((Component)this).transform.position), (DOSetter<Vector3>)delegate(Vector3 x)
			{
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				((Component)this).transform.position = x;
			}, Vector3.op_Implicit(value), 1f);
		}
	}

	public void OnVisible(GameEntity entity)
	{
		container.SetActive(true);
	}

	public void OnVisibleRemoved(GameEntity entity)
	{
		container.SetActive(false);
	}

	public void OnStagingAreaPositionsChanged(Team team)
	{
		if (team == Team.Red)
		{
			OnRedTeamStagingAreaPosition();
		}
	}

	public void OnAnyBattleConfig(ConfigEntity entity, BattleConfig red, BattleConfig blue, float battleFieldLength)
	{
		List<List<string>> unitsId = red.UnitsId;
		for (int i = 0; i < 12; i++)
		{
			if (_oldSoldiers[i] != unitsId[0][i] && unitsId[0][i] != null && unitsId[0][i].StartsWith("S") && _stagingAreas.TryGetValue(i, out var value))
			{
				value.GetComponent<StagingArea>().PlayPortalAnimation(onChangeSoldier: true);
			}
			_oldSoldiers[i] = unitsId[0][i];
		}
	}
}
