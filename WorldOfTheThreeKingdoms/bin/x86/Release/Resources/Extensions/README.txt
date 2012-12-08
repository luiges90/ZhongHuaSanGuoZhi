使用方法：把*.cs放在游戏文件中的Resources/Extensions中。如果不想要该项设定，不把其*.cs档案放进去即可。
另外可以直接修改*.cs档案，把设定改成你的喜好。注意备份。

各档案所对应的设定：

- AI强化系
AIPersonUpgrading.cs - AI将领每天也有一定机会提高一项能力一点，机率与玩家的城池数相关。
AIResourceGathering.cs - AI城池每天钱粮额外增长，数量与玩家的城池数相关。
AITroopGathering.cs - AI城池每天也有一定机率得到部队，机率与玩家的城池数相关。

- 内政系
ReduceInternalOnAttack.cs - 城池被攻击时，内政下降。
ReduceInteralDaily.cs - 城池内政每天下降。