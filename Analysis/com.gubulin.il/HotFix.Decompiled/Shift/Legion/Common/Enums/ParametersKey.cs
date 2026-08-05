using Shift.Legion.CodeGeneration.Attributes;

namespace Shift.Legion.Common.Enums;

[ParametersKeyEnum]
public enum ParametersKey : uint
{
	[ParametersKeyDesc("int", "目标单位Id", "", "", false, false)]
	TargetUnitId,
	[ParametersKeyDesc("int", "子目标单位Id", "", "", false, false)]
	SubTargetUnitId,
	[ParametersKeyDesc("int", "触发单位Id", "", "", false, false)]
	TriggerUnitId,
	[ParametersKeyDesc("int", "触发技能Id", "", "", false, false)]
	TriggerAbilityId,
	[ParametersKeyDesc("int", "触发子弹Id", "", "", false, false)]
	TriggerProjectileId,
	[ParametersKeyDesc("HitInfo", "攻击信息", "", "", true, true)]
	HitInfo,
	[ParametersKeyDesc("int", "次数", "", "0", false, false)]
	ActivateTimes,
	[ParametersKeyDesc("float", "伤害倍率", "", "0", false, false)]
	P_DamageMultiplier,
	[ParametersKeyDesc("float", "额外伤害倍率", "", "0", false, false)]
	P_ExtraDamageMultiplier,
	[ParametersKeyDesc("bool", "无视护甲", "", "0", false, false)]
	P_IgnoreArmor,
	[ParametersKeyDesc("string", "子弹名称", "", "P_empty", false, false)]
	P_ProjectileId,
	[ParametersKeyDesc("string", "子弹发射骨骼名称", "", "", false, false)]
	P_ProjectileLaunchBone,
	[ParametersKeyDesc("string", "子弹打击骨骼名称", "", "", false, false)]
	P_ProjectileLandingBone,
	[ParametersKeyDesc("float", "子弹弧度", "", "", false, false)]
	P_ProjectileRatio,
	[ParametersKeyDesc("string", "子弹1名称", "", "P_empty", false, false)]
	P_ProjectileId1,
	[ParametersKeyDesc("string", "子弹1发射骨骼名称", "", "", false, false)]
	P_ProjectileLaunchBone1,
	[ParametersKeyDesc("string", "子弹1打击骨骼名称", "", "", false, false)]
	P_ProjectileLandingBone1,
	[ParametersKeyDesc("float", "子弹1弧度", "", "", false, false)]
	P_ProjectileRatio1,
	[ParametersKeyDesc("string", "粒子0名称", "", "", false, false)]
	P_ParticleId,
	[ParametersKeyDesc("string", "粒子0附着的骨骼名称", "", "", false, false)]
	P_ParticleBone,
	[ParametersKeyDesc("int", "粒子0持续特效时间", "单位：毫秒", "", false, false)]
	P_ParticleDuration,
	[ParametersKeyDesc("int", "粒子0大小", "", "", false, false)]
	P_ParticleSize,
	[ParametersKeyDesc("bool", "粒子0随目标大小变化", "", "", false, false)]
	P_ParticleSizeAuto,
	[ParametersKeyDesc("string", "粒子0音效", "", "", false, false)]
	P_ParticleAudioFx,
	[ParametersKeyDesc("int", "粒子0音效音量", "", "", false, false)]
	P_ParticleAudioFxVolume,
	[ParametersKeyDesc("bool", "粒子0音效循环", "", "", false, false)]
	P_ParticleAudioFxLoop,
	[ParametersKeyDesc("string", "粒子1名称", "", "", false, false)]
	P_ParticleId1,
	[ParametersKeyDesc("string", "粒子1附着的骨骼名称", "", "", false, false)]
	P_ParticleBone1,
	[ParametersKeyDesc("int", "粒子1持续特效时间", "单位：毫秒", "", false, false)]
	P_ParticleDuration1,
	[ParametersKeyDesc("int", "粒子1大小", "", "", false, false)]
	P_ParticleSize1,
	[ParametersKeyDesc("bool", "粒子1随目标大小变化", "", "", false, false)]
	P_ParticleSizeAuto1,
	[ParametersKeyDesc("string", "粒子1音效", "", "", false, false)]
	P_ParticleAudioFx1,
	[ParametersKeyDesc("int", "粒子1音效音量", "", "", false, false)]
	P_ParticleAudioFxVolume1,
	[ParametersKeyDesc("bool", "粒子1音效循环", "", "", false, false)]
	P_ParticleAudioFxLoop1,
	[ParametersKeyDesc("string", "粒子2名称", "", "", false, false)]
	P_ParticleId2,
	[ParametersKeyDesc("string", "粒子2附着的骨骼名称", "", "", false, false)]
	P_ParticleBone2,
	[ParametersKeyDesc("int", "粒子2持续特效时间", "单位：毫秒", "", false, false)]
	P_ParticleDuration2,
	[ParametersKeyDesc("int", "粒子2大小", "", "", false, false)]
	P_ParticleSize2,
	[ParametersKeyDesc("bool", "粒子2随目标大小变化", "", "", false, false)]
	P_ParticleSizeAuto2,
	[ParametersKeyDesc("string", "粒子2音效", "", "", false, false)]
	P_ParticleAudioFx2,
	[ParametersKeyDesc("int", "粒子2音效音量", "", "", false, false)]
	P_ParticleAudioFxVolume2,
	[ParametersKeyDesc("bool", "粒子2音效循环", "", "", false, false)]
	P_ParticleAudioFxLoop2,
	[ParametersKeyDesc("string", "Buff Id", "", "", false, false)]
	P_BuffId,
	[ParametersKeyDesc("string", "Buff Id1", "", "", false, false)]
	P_BuffId1,
	[ParametersKeyDesc("string", "Buff Id2", "", "", false, false)]
	P_BuffId2,
	[ParametersKeyDesc("string", "Buff Id3", "", "", false, false)]
	P_BuffId3,
	[ParametersKeyDesc("string", "Buff Id4", "", "", false, false)]
	P_BuffId4,
	[ParametersKeyDesc("string", "Buff Id5", "", "", false, false)]
	P_BuffId5,
	[ParametersKeyDesc("string", "Buff Id6", "", "", false, false)]
	P_BuffId6,
	[ParametersKeyDesc("string", "技能Id0", "", "", false, false)]
	P_AbilityId,
	[ParametersKeyDesc("string", "技能Id1", "", "", false, false)]
	P_AbilityId1,
	[ParametersKeyDesc("string", "技能Id2", "", "", false, false)]
	P_AbilityId2,
	[ParametersKeyDesc("Shift.Legion.Common.Enums.AnimationName", "动画名称0", "", "", false, false)]
	P_AnimationName,
	[ParametersKeyDesc("int", "动画播放轨道0", "", "", false, false)]
	P_AnimationTrackIndex,
	[ParametersKeyDesc("Shift.Legion.Common.Enums.AnimationName", "动画名称1", "", "", false, false)]
	P_AnimationName1,
	[ParametersKeyDesc("int", "动画播放轨道1", "", "", false, false)]
	P_AnimationTrackIndex1,
	[ParametersKeyDesc("Shift.Legion.Common.Enums.AnimationName", "动画名称2", "", "", false, false)]
	P_AnimationName2,
	[ParametersKeyDesc("int", "动画播放轨道2", "", "", false, false)]
	P_AnimationTrackIndex2,
	[ParametersKeyDesc("int", "概率0", "", "", false, false)]
	P_Probability,
	[ParametersKeyDesc("int", "概率1", "", "", false, false)]
	P_Probability1,
	[ParametersKeyDesc("int", "概率2", "", "", false, false)]
	P_Probability2,
	[ParametersKeyDesc("int", "范围", "单位：1= 0.01游戏单位", "", false, false)]
	P_Range,
	[ParametersKeyDesc("int", "范围1", "单位：1= 0.01游戏单位", "", false, false)]
	P_Range1,
	[ParametersKeyDesc("float", "冲锋速度", "", "", false, false)]
	P_DashSpeed,
	[ParametersKeyDesc("int", "冲锋距离", "", "", false, false)]
	P_DashDistance,
	[ParametersKeyDesc("float", "击飞速度", "", "", false, false)]
	P_KnockupSpeed,
	[ParametersKeyDesc("float", "击退移动速度", "", "", false, false)]
	P_KnockbackSpeed,
	[ParametersKeyDesc("int", "击退距离", "", "", false, false)]
	P_KnockbackDistance,
	[ParametersKeyDesc("float", "跳跃移动速度", "", "", false, false)]
	P_JumpSpeed,
	[ParametersKeyDesc("int", "跳跃距离", "", "", false, false)]
	P_JumpDistance,
	[ParametersKeyDesc("float", "跳跃高度", "", "", false, false)]
	P_JumpHeightRatio,
	[ParametersKeyDesc("int", "数量", "", "", false, false)]
	P_Num,
	[ParametersKeyDesc("int", "最大次数", "", "", false, false)]
	P_MaxTimes,
	[ParametersKeyDesc("int", "持续时间", "单位：毫秒", "", false, false)]
	P_Duration,
	[ParametersKeyDesc("int", "Tick间隔", "单位：毫秒", "", false, false)]
	P_TickInterval,
	[ParametersKeyDesc("string", "控制效果Id", "", "", false, false)]
	P_CrowdControl,
	[ParametersKeyDesc("int", "控制效果持续时间", "单位：毫秒", "", false, false)]
	P_CrowdControlDuration,
	[ParametersKeyDesc("StatModifier", "技能持续时间倍率", "", "", true, true)]
	P_AbilityDurationMultiplier,
	[ParametersKeyDesc("StatModifier", "技能效果倍率", "", "", true, true)]
	P_AbilityEffectMultiplier,
	[ParametersKeyDesc("Shift.Legion.Common.Enums.ShieldType", "护盾类型", "", "", false, false)]
	P_ShieldType,
	[ParametersKeyDesc("float", "护盾值", "", "", false, false)]
	P_ShieldValue,
	[ParametersKeyDesc("string", "创建的单位Id", "", "", false, false)]
	P_CreateUnitId,
	[ParametersKeyDesc("float", "创建的单位继承属性百分比", "", "", false, false)]
	P_CreateUnitInheritPercentage,
	[ParametersKeyDesc("Shift.Legion.Common.Enums.DamageType", "伤害类型", "", "DamageType.Normal", false, false)]
	P_DamageType,
	[ParametersKeyDesc("Shift.Legion.Common.Enums.AttackFlags", "攻击标记", "", "", false, false)]
	P_AttackFlags,
	[ParametersKeyDesc("string", "Buff标记", "", "", false, false)]
	B_Flags,
	[ParametersKeyDesc("int", "Buff层数", "", "1", false, false)]
	B_Stacks,
	[ParametersKeyDesc("int", "Buff最大层数", "", "1", false, false)]
	B_MaxStacks,
	[ParametersKeyDesc("int", "Buff持续时间", "", "1", false, false)]
	B_Duration,
	[ParametersKeyDesc("int", "Buff最大个数", "", "", false, false)]
	B_MaxNum,
	[ParametersKeyDesc("int", "变更前的层数", "", "", false, false)]
	OldStacks,
	[ParametersKeyDesc("float", "变更前的效果倍率", "", "", false, false)]
	OldEffectMultiplier,
	[ParametersKeyDesc("int", "变更后的层数", "", "", false, false)]
	NewStacks,
	[ParametersKeyDesc("float", "变更后的效果倍率", "", "", false, false)]
	NewEffectMultiplier,
	[ParametersKeyDesc("float", "Buff层数效果倍率", "", "", false, false)]
	B_StackEffectMultiplier,
	B_ObsoleteType,
	B_MergeStrategy,
	B_MergeStacksRefreshDuration,
	[ParametersKeyDesc("bool", "叠层时需要刷新特效", "", "", false, false)]
	B_MergeStacksRefreshParticle,
	B_MergeType,
	[ParametersKeyDesc("StatModifier", "Buff攻击力加成", "", "", true, true)]
	B_AttackPower,
	[ParametersKeyDesc("StatModifier", "Buff攻击速度加成", "", "", true, true)]
	B_AttackSpeed,
	[ParametersKeyDesc("StatModifier", "Buff移动速度加成", "", "", true, true)]
	B_MoveSpeed,
	[ParametersKeyDesc("StatModifier", "Buff防御力加成", "", "", true, true)]
	B_DefensePower,
	[ParametersKeyDesc("StatModifier", "Buff最大生命值加成", "", "", true, true)]
	B_HealthPoints,
	[ParametersKeyDesc("StatModifier", "Buff暴击率加成", "", "", true, true)]
	B_CriticalChance,
	[ParametersKeyDesc("StatModifier", "Buff暴击伤害加成", "", "", true, true)]
	B_CriticalDamage,
	[ParametersKeyDesc("StatModifier", "Buff闪避率加成", "", "", true, true)]
	B_EvasionRate,
	[ParametersKeyDesc("StatModifier", "Buff命中率加成", "", "", true, true)]
	B_AccuracyRate,
	[ParametersKeyDesc("StatModifier", "Buff体积大小加成", "", "", true, true)]
	B_Size,
	[ParametersKeyDesc("StatModifier", "Buff冷却缩减加成", "", "", true, true)]
	B_CooldownReduction,
	[ParametersKeyDesc("StatModifier", "Buff物理吸血加成", "", "", true, true)]
	B_LifeSteal,
	[ParametersKeyDesc("StatModifier", "Buff魔法吸血加成", "", "", true, true)]
	B_MagicVamp,
	[ParametersKeyDesc("StatModifier", "Buff攻击距离加成", "", "", true, true)]
	B_AttackRange,
	[ParametersKeyDesc("StatModifier", "造成的伤害增加", "", "", true, true)]
	B_DamageSettlement,
	[ParametersKeyDesc("StatModifier", "受到的伤害增加", "", "", true, true)]
	B_HurtSettlement,
	[ParametersKeyDesc("StatModifier", "造成的火焰伤害增加", "", "", true, true)]
	B_FireDamage,
	[ParametersKeyDesc("StatModifier", "受到的火焰伤害增加", "", "", true, true)]
	B_FireHurt,
	[ParametersKeyDesc("StatModifier", "造成的冰霜伤害增加", "", "", true, true)]
	B_IceDamage,
	[ParametersKeyDesc("StatModifier", "受到的冰霜伤害增加", "", "", true, true)]
	B_IceHurt,
	[ParametersKeyDesc("StatModifier", "造成的自然伤害增加", "", "", true, true)]
	B_NatureDamage,
	[ParametersKeyDesc("StatModifier", "受到的自然伤害增加", "", "", true, true)]
	B_NatureHurt,
	[ParametersKeyDesc("StatModifier", "造成的神圣伤害增加", "", "", true, true)]
	B_HolyDamage,
	[ParametersKeyDesc("StatModifier", "受到的神圣伤害增加", "", "", true, true)]
	B_HolyHurt,
	[ParametersKeyDesc("StatModifier", "造成的暗影伤害增加", "", "", true, true)]
	B_ShadowDamage,
	[ParametersKeyDesc("StatModifier", "受到的暗影伤害增加", "", "", true, true)]
	B_ShadowHurt,
	[ParametersKeyDesc("StatModifier", "造成的心灵伤害增加", "", "", true, true)]
	B_SpiritDamage,
	[ParametersKeyDesc("StatModifier", "受到的心灵伤害增加", "", "", true, true)]
	B_SpiritHurt,
	[ParametersKeyDesc("StatModifier", "治疗量加成", "", "", true, true)]
	B_CureSettlement,
	[ParametersKeyDesc("StatModifier", "受到的治疗量增加", "", "", true, true)]
	B_RecoverSettlement,
	[ParametersKeyDesc("StatModifier", "反伤加成", "", "", true, true)]
	B_DamageReflect
}
