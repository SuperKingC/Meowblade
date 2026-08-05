using System;
using System.Threading.Tasks;
using Entitas;
using HotFix;
using ObjectPool;

public class InitObjectPoolSystem : IInitializeSystem, ISystem
{
	private readonly Contexts _contexts;

	public InitObjectPoolSystem(Contexts contexts)
	{
		_contexts = contexts;
	}

	public void Initialize()
	{
		InitGameEntityPool(1000);
	}

	private async void InitGameEntityPool(int length)
	{
		int assetLength = 600;
		GameEntity[] buffer = new GameEntity[length];
		for (int i = 0; i < length; i++)
		{
			buffer[i] = ((Context<GameEntity>)_contexts.game).CreateEntity();
			if (i < assetLength)
			{
				buffer[i].ReplaceAsset((i % 2 == 0) ? "RedStandardUnitModel" : "BlueStandardUnitModel");
			}
		}
		for (int j = 0; j < assetLength; j++)
		{
			while (!buffer[j].hasCharacter)
			{
				await Task.Delay(100);
			}
			buffer[j].RemoveAsset();
		}
		await Task.Delay(100);
		for (int k = 0; k < length; k++)
		{
			((Entity)buffer[k]).Destroy();
			buffer[k] = null;
		}
	}

	private void InitPool<T>(int length) where T : IPooled, new()
	{
		T[] array = new T[length];
		for (int i = 0; i < length; i++)
		{
			array[i] = ObjectPool<T>.Spawn((Func<T>)(() => new T()));
		}
		for (int num = 0; num < length; num++)
		{
			array[num].UnSpawn();
		}
	}
}
