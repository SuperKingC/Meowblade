using System;
using Entitas;
using Shift.Legion.Common.Models;

public sealed class GameContext : Context<GameEntity>
{
	public GameEntity dungeonEntity => base.GetGroup(GameMatcher.Dungeon).GetSingleEntity();

	public DungeonComponent dungeon => dungeonEntity.dungeon;

	public bool hasDungeon => dungeonEntity != null;

	public GameEntity playerEntity => base.GetGroup(GameMatcher.Player).GetSingleEntity();

	public bool isPlayer
	{
		get
		{
			return playerEntity != null;
		}
		set
		{
			GameEntity gameEntity = playerEntity;
			if (value != (gameEntity != null))
			{
				if (value)
				{
					base.CreateEntity().isPlayer = true;
				}
				else
				{
					((Entity)gameEntity).Destroy();
				}
			}
		}
	}

	public GameEntity SetDungeon(Dungeon newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasDungeon)
		{
			throw new EntitasException("Could not set Dungeon!\n" + ((object)this)?.ToString() + " already has an entity with DungeonComponent!", "You should check if the context already has a dungeonEntity before setting it or use context.ReplaceDungeon().");
		}
		GameEntity gameEntity = base.CreateEntity();
		gameEntity.AddDungeon(newValue);
		return gameEntity;
	}

	public void ReplaceDungeon(Dungeon newValue)
	{
		GameEntity gameEntity = dungeonEntity;
		if (gameEntity == null)
		{
			gameEntity = SetDungeon(newValue);
		}
		else
		{
			gameEntity.ReplaceDungeon(newValue);
		}
	}

	public void RemoveDungeon()
	{
		((Entity)dungeonEntity).Destroy();
	}

	public GameContext()
		: base(161, 0, new ContextInfo("Game", GameComponentsLookup.componentNames, GameComponentsLookup.componentTypes), (Func<IEntity, IAERC>)((IEntity entity) => (IAERC)new UnsafeAERC()), (Func<GameEntity>)(() => new GameEntity()))
	{
	}//IL_0016: Unknown result type (might be due to invalid IL or missing references)
	//IL_005e: Expected O, but got Unknown

}
