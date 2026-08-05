using Entitas;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UnityEngine;

public class PostProcessingCamera : MonoBehaviour, IAnyBattleFieldMapIdentifierListener, IAnyLoadingProgressListener
{
	private Contexts _contexts;

	private GameStateEntity _gameStateEntity;

	private Camera Camera;

	private RenderTexture RenderTexture;

	private GameObject CamGo;

	private GameObject CanvasGO;

	private bool IsPostProcessingActive;

	private RenderTexture MainCamLastTargetTexture;

	public void Initialize(Contexts contexts)
	{
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		_contexts = contexts;
		CamGo = ((Component)((Component)this).transform.Find("Camera")).gameObject;
		CanvasGO = ((Component)((Component)this).transform.Find("Canvas")).gameObject;
		CamGo.SetActive(false);
		CanvasGO.SetActive(false);
		Camera = CamGo.GetComponent<Camera>();
		MeshRenderer component = CanvasGO.GetComponent<MeshRenderer>();
		RenderTexture = (RenderTexture)((Renderer)component).material.mainTexture;
		RegisterListeners();
	}

	public void OnDestroy()
	{
		UnregisterListeners();
	}

	public void RegisterListeners()
	{
		_gameStateEntity = ((Context<GameStateEntity>)_contexts.gameState).CreateEntity();
		_gameStateEntity.AddAnyBattleFieldMapIdentifierListener(this);
		_gameStateEntity.AddAnyLoadingProgressListener(this);
	}

	public void UnregisterListeners()
	{
		_gameStateEntity.RemoveAnyBattleFieldMapIdentifierListener(this);
		_gameStateEntity.RemoveAnyLoadingProgressListener(this);
		((Entity)_gameStateEntity).Destroy();
	}

	public void OnAnyBattleFieldMapIdentifier(GameStateEntity entity, string value)
	{
		if (GameManagers.Instance == null || _contexts == null)
		{
			return;
		}
		GameEntity[] entities = ((Context<GameEntity>)_contexts.game).GetGroup(GameMatcher.BattleField).GetEntities();
		if (entities.Length == 0)
		{
			return;
		}
		GameEntity gameEntity = entities[0];
		Level levelInstance = GameManagers.Instance.ChapterManager.GetLevelInstance(gameEntity.levelId.value);
		if (levelInstance == null)
		{
			ILRuntimeDebug.LogError("OnAnyBattleFieldMapIdentifier level is null, levelId =", gameEntity.levelId.value);
		}
		else if (levelInstance?.Data != null)
		{
			if (levelInstance.IsPerspective())
			{
				EnablePostProcessing_开场透视();
			}
			else
			{
				DisablePostProcessing();
			}
		}
	}

	public void OnAnyLoadingProgress(GameStateEntity entity, int value)
	{
		switch (value)
		{
		case 0:
		{
			string currentScene2 = GameController.Contexts.Service<BaseSceneService>().CurrentScene;
			if (currentScene2 == "BattleField")
			{
				DisablePostProcessing();
			}
			break;
		}
		case 100:
		{
			string currentScene = GameController.Contexts.Service<BaseSceneService>().CurrentScene;
			break;
		}
		}
	}

	private void EnablePostProcessing_移轴()
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		IsPostProcessingActive = true;
		SentrySdk.AddBreadcrumb("[PostProcessingCamera] EnablePostProcessing_移轴");
		MainCamLastTargetTexture = Camera.main.targetTexture;
		Camera.main.targetTexture = RenderTexture;
		Camera.main.fieldOfView = 10f;
		Camera.main.orthographic = false;
		Singleton<CameraService>.Instance.CamDist = Const.PostProcessCamDist_移轴;
		_contexts.gameState.ReplaceCameraPosition(Singleton<CameraService>.Instance.GetCameraPositionForScene("BattleField"));
		ClientBattleFieldLogic.SetBattleFieldCameraMoveLimit(_contexts);
		UnityBattleField unityBattleField = (UnityBattleField)((Context<GameEntity>)_contexts.game).GetGroup(GameMatcher.BattleField).GetEntities()[0].battleField.value;
		unityBattleField.BackgroundController.SetScale(new Vector3(1.32f, 1.32f, 1f));
		CamGo.SetActive(true);
		CanvasGO.SetActive(true);
	}

	private void EnablePostProcessing_开场透视()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		IsPostProcessingActive = true;
		SentrySdk.AddBreadcrumb("[PostProcessingCamera] EnablePostProcessing_开场透视");
		MainCamLastTargetTexture = Camera.main.targetTexture;
		Camera.main.fieldOfView = 20f;
		Camera.main.orthographic = false;
		Singleton<CameraService>.Instance.CamDist = Const.PostProcessCamDist_开场透视;
		_contexts.gameState.ReplaceCameraPosition(Singleton<CameraService>.Instance.GetCameraPositionForScene("BattleField"));
		ClientBattleFieldLogic.SetBattleFieldCameraMoveLimit(_contexts);
		GameEntity[] entities = ((Context<GameEntity>)_contexts.game).GetGroup(GameMatcher.BattleField).GetEntities();
		if (entities.Length != 0)
		{
			UnityBattleField unityBattleField = (UnityBattleField)entities[0].battleField.value;
			unityBattleField.BackgroundController.SetScale(new Vector3(1f, 1f, 1f));
		}
	}

	private void EnablePostProcessing_常规透视()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		IsPostProcessingActive = true;
		SentrySdk.AddBreadcrumb("[PostProcessingCamera] EnablePostProcessing_常规透视");
		MainCamLastTargetTexture = Camera.main.targetTexture;
		Camera.main.fieldOfView = 10f;
		Camera.main.orthographic = false;
		Singleton<CameraService>.Instance.CamDist = Const.PostProcessCamDist_常规透视;
		_contexts.gameState.ReplaceCameraPosition(Singleton<CameraService>.Instance.GetCameraPositionForScene("BattleField"));
		ClientBattleFieldLogic.SetBattleFieldCameraMoveLimit(_contexts);
		GameEntity[] entities = ((Context<GameEntity>)_contexts.game).GetGroup(GameMatcher.BattleField).GetEntities();
		if (entities.Length != 0)
		{
			UnityBattleField unityBattleField = (UnityBattleField)entities[0].battleField.value;
			unityBattleField.BackgroundController.SetScale(new Vector3(1f, 1f, 1f));
		}
	}

	private void DisablePostProcessing()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		if (IsPostProcessingActive)
		{
			IsPostProcessingActive = false;
			SentrySdk.AddBreadcrumb("[PostProcessingCamera] DisablePostProcessing");
			Camera.main.targetTexture = MainCamLastTargetTexture;
			Camera.main.orthographic = true;
			Singleton<CameraService>.Instance.CamDist = Const.NormalCamDist;
			_contexts.gameState.ReplaceCameraPosition(Singleton<CameraService>.Instance.GetCameraPositionForScene("BattleField"));
			ClientBattleFieldLogic.SetBattleFieldCameraMoveLimit(_contexts);
			GameEntity[] entities = ((Context<GameEntity>)_contexts.game).GetGroup(GameMatcher.BattleField).GetEntities();
			if (entities.Length != 0)
			{
				UnityBattleField unityBattleField = (UnityBattleField)entities[0].battleField.value;
				unityBattleField.BackgroundController.SetScale(new Vector3(1f, 1f, 1f));
			}
			CamGo.SetActive(false);
			CanvasGO.SetActive(false);
		}
	}
}
