using System.Collections.Generic;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Models;
using Spine.Unity;
using UnityEngine;

namespace Shift.Legion.Common.Services;

public abstract class BaseSceneService : IService, IAnyLoadingPanelStatusListener, IAnyLoadingProgressListener
{
	public string CurrentScene;

	public bool IsSceneBattleField;

	public abstract GameObject MainCityObj { get; }

	public abstract GameEntity OpenScene(string sceneName, SceneArguments arguments);

	public abstract void Load();

	public abstract void OnSceneLoaded(GameEntity entity);

	public abstract void EnableMainCity(Dictionary<MainCityEnableCommand, bool> b);

	public abstract List<SkeletonAnimation> Get_All_SkeletonAnimation();

	public abstract List<MoltenCoreWorkerController> Get_All_MoltenCoreWorkerController();

	public abstract List<WorkerController> Get_All_WorkerController();

	public abstract Dictionary<string, Dictionary<int, Workbench>> Get_All_All_Workbench();

	public abstract void AddMoltenCoreWorker(MoltenCoreWorkerController w);

	public abstract void AddWorkerController(WorkerController w);

	public abstract void AddWorkbench(string buildingtype, int index, Workbench b);

	public abstract void AddSkeletonAnimation(SkeletonAnimation s);

	public abstract void AddMonoBehaviour(MonoBehaviour m);

	public abstract bool get_EnableMaincity_Monobehaviour();

	public abstract bool GetEnableMainCityProduce();

	public abstract bool get_FirstSyncAfterEnteredMainCity();

	public abstract void SyncedAfterEnteredMainCity();

	public abstract void Destroy(GameEntity entity);

	public abstract void InitMainCity();

	public abstract void MainCityLoaded();

	public abstract void OnAnyLoadingPanelStatus(GameStateEntity entity, LoadingPanelStatus value);

	public abstract void OnAnyLoadingProgress(GameStateEntity entity, int value);

	public abstract void Init();

	public abstract void Destroy();

	public abstract void AddEventsListener();

	public abstract void RemoveEventsListener();
}
