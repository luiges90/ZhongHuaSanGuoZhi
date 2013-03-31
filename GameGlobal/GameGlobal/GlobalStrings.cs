﻿namespace GameGlobal
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Size=1)]
    public struct GlobalStrings
    {
        public const string MainGameTitle = "中华三国志";
        public const string Blank = " ";
        public const string Separater = "_";
        public const string Slash = "/";
        public const string LeftBracket = "(";
        public const string RightBracket = ")";
        public const string DataProviderString = "Microsoft.Jet.OLEDB.4.0";
        public const string GameComponents_Path = "GameComponents";
        public const string GamePlugins_Path = "GamePlugins";
        public const string ConmentTextPluginName = "ConmentTextPlugin";
        public const string ArchitectureSurveyPluginName = "ArchitectureSurveyPlugin";
        public const string TroopSurveyPluginName = "TroopSurveyPlugin";
        public const string ArchitectureRightClickMenuPluginName = "ArchitectureRightClickMenuPlugin";
        public const string ContextMenuPluginName = "ContextMenuPlugin";
        public const string MapViewSelectorPluginName = "MapViewSelectorPlugin";
        public const string GameFramePluginName = "GameFramePlugin";
        public const string TabListPluginName = "TabListPlugin";
        public const string TransportDialogPluginName = "TransportDialogPlugin";
        public const string OptionDialogPluginName = "OptionDialogPlugin";
        public const string ConfirmationDialogPluginName = "ConfirmationDialogPlugin";
        public const string SimpleTextDialogPluginName = "SimpleTextDialogPlugin";
        public const string PersonTextDialogPluginName = "PersonTextDialogPlugin";
        public const string ToolBarPluginName = "ToolBarPlugin";
        public const string DateRunnerPluginName = "DateRunnerPlugin";
        public const string MapLayerPluginName = "MapLayerPlugin";
        public const string GameSystemPluginName = "GameSystemPlugin";
        public const string GameRecordPluginName = "GameRecordPlugin";
        public const string AirViewPluginName = "AirViewPlugin";
        public const string PersonPortraitPluginName = "PersonPortraitPlugin";
        public const string HelpPluginName = "HelpPlugin";
        public const string PersonBubblePluginName = "PersonBubblePlugin";
        public const string ScreenBlindPluginName = "ScreenBlindPlugin";
        public const string TroopTitlePluginName = "TroopTitlePlugin";
        public const string PersonDetailPluginName = "PersonDetailPlugin";
        public const string TroopDetailPluginName = "TroopDetailPlugin";
        public const string ArchitectureDetailPluginName = "ArchitectureDetailPlugin";
        public const string FactionTechniquesPluginName = "FactionTechniquesPlugin";
        public const string TreasureDetailPluginName = "TreasureDetailPlugin";
        public const string RoutewayEditorPluginName = "RoutewayEditorPlugin";
        public const string NumberInputerPluginName = "NumberInputerPlugin";
        public const string CreateTroopPluginName = "CreateTroopPlugin";
        public const string MarshalSectionDialogPluginName = "MarshalSectionDialogPlugin";
        public const string Content_Path = "Content";
        public const string GameData_Path = "GameData/";
        public const string Common_Path = "Common/";
        public const string CommonData_FileName = "CommonData.mdb";
        public const string GameData_GlobalVariables_FileName = "GlobalVariables.xml";
        public const string GameData_Parameters_FileName = "GameParameters.xml";
        public const string GameData_MainMapData_FileName = "MainMapData.xml";
        public const string Scenario_FileExt = ".mdb";
        public const string Scenario_Path = "Scenario/";
        public const string Scenario01_FileName = "Scenario01.mdb";
        public const string Scenario02_FileName = "Scenario02.mdb";
        public const string Scenario03_FileName = "Scenario03.mdb";
        public const string Scenario04_FileName = "Scenario04.mdb";
        public const string Scenario05_FileName = "Scenario05.mdb";
        public const string Scenario06_FileName = "Scenario06.mdb";
        public const string Scenario07_FileName = "Scenario07.mdb";
        public const string Scenario08_FileName = "Scenario08.mdb";
        public const string Scenario09_FileName = "Scenario09.mdb";
        public const string Scenario10_FileName = "Scenario10.mdb";
        public const string Save_Path = "Save/";
        public const string Save01_FileName = "Save01.mdb";
        public const string Save02_FileName = "Save02.mdb";
        public const string Save03_FileName = "Save03.mdb";
        public const string Save04_FileName = "Save04.mdb";
        public const string Save05_FileName = "Save05.mdb";
        public const string Save06_FileName = "Save06.mdb";
        public const string Save07_FileName = "Save07.mdb";
        public const string Save08_FileName = "Save08.mdb";
        public const string Save09_FileName = "Save09.mdb";
        public const string Save10_FileName = "Save10.mdb";
        public const string SaveTemplate_FileName = "SaveTemplate.mdb";
        public const string EmptySaveFileText = "空 白 存 档";
        public const string GameData_Message_FileName = "Message.txt";
        public const string Resources_Path = "Resources/";
        public const string Terrain_Path = "Terrain/";
        public const string Terrain_None_AssetName = "None";
        public const string Terrain_Plain_AssetName = "Plain";
        public const string Terrain_Grassland_AssetName = "Grassland";
        public const string Terrain_Forest_AssetName = "Forest";
        public const string Terrain_Marsh_AssetName = "Marsh";
        public const string Terrain_Mountain_AssetName = "Mountain";
        public const string Terrain_River_AssetName = "River";
        public const string Terrain_Ridge_AssetName = "Ridge";
        public const string Terrain_Wasteland_AssetName = "Wasteland";
        public const string Terrain_Desert_AssetName = "Desert";
        public const string Terrain_Cliff_AssetName = "Cliff";
        public const string Terrain_FileExt = ".bmp";
        public const string Terrain_EffectExt = ".png";
        public const string Terrain_BasicName = "Basic";
        public const string Terrain_LeftName = "Left";
        public const string Terrain_TopName = "Top";
        public const string Terrain_RightName = "Right";
        public const string Terrain_BottomName = "Bottom";
        public const string Terrain_TopLeftName = "TopLeft";
        public const string Terrain_TopRightName = "TopRight";
        public const string Terrain_BottomLeftName = "BottomLeft";
        public const string Terrain_BottomRightName = "BottomRight";
        public const string Terrain_LeftEdgeName = "LeftEdge";
        public const string Terrain_TopEdgeName = "TopEdge";
        public const string Terrain_RightEdgeName = "RightEdge";
        public const string Terrain_BottomEdgeName = "BottomEdge";
        public const string Terrain_TopLeftCornerName = "TopLeftCorner";
        public const string Terrain_TopRightCornerName = "TopRightCorner";
        public const string Terrain_BottomLeftCornerName = "BottomLeftCorner";
        public const string Terrain_BottomRightCornerName = "BottomRightCorner";
        public const string Terrain_CentreName = "Centre";
        public const string Architecture_Path = "Architecture/";
        public const string Architecture_None_AssetName = "None";
        public const string Architecture_City_AssetName = "City";
        public const string Architecture_Block_AssetName = "Block";
        public const string Architecture_Port_AssetName = "Port";
        public const string Architecture_Barrack_AssetName = "Barrack";
        public const string Architecture_FileExt = ".png";
        public const string Treasure_Path = "Treasure/";
        public const string Treasure_FileExt = ".png";
        public const string Troop_Path = "Troop/";
        public const string Troop_Move_AssetName = "Move";
        public const string Troop_Attack_AssetName = "Attack";
        public const string Troop_BeAttacked_AssetName = "BeAttacked";
        public const string Troop_Cast_AssetName = "Cast";
        public const string Troop_BeCasted_AssetName = "BeCasted";
        public const string Troop_FileExt = ".png";
        public const string Troop_Moving_AssetName = "Moving";
        public const string Troop_NormalAttack_AssetName = "NormalAttack";
        public const string Troop_CriticalAttack_AssetName = "CriticalAttack";
        public const string MouseArrow_Path = "MouseArrow/";
        public const string MouseArrow_Normal_AssetName = "Normal";
        public const string MouseArrow_Left_AssetName = "Left";
        public const string MouseArrow_Right_AssetName = "Right";
        public const string MouseArrow_Top_AssetName = "Top";
        public const string MouseArrow_Bottom_AssetName = "Bottom";
        public const string MouseArrow_TopLeft_AssetName = "TopLeft";
        public const string MouseArrow_TopRight_AssetName = "TopRight";
        public const string MouseArrow_BottomLeft_AssetName = "BottomLeft";
        public const string MouseArrow_BottomRight_AssetName = "BottomRight";
        public const string MouseArrow_Selecting_AssetName = "Selecting";
        public const string MouseArrow_FileExt = ".png";
        public const string MapVeil_Path = "MapVeil/";
        public const string MapVeil_Gray_AssetName = "Gray";
        public const string MapVeil_FileExt = ".bmp";
        public const string TileFrame_Path = "TileFrame/";
        public const string TileFrame_White_AssetName = "White";
        public const string TileFrame_Black_AssetName = "Black";
        public const string TileFrame_Red_AssetName = "Red";
        public const string TileFrame_Blue_AssetName = "Blue";
        public const string TileFrame_Green_AssetName = "Green";
        public const string TileFrame_Purple_AssetName = "Purple";
        public const string TileFrame_Yellow_AssetName = "Yellow";
        public const string TileFrame_FileExt = ".png";
        public const string Routeway_Path = "Routeway/";
        public const string Routeway_Planning_AssetName = "Planning";
        public const string Routeway_Active_AssetName = "Active";
        public const string Routeway_Inefficiency_AssetName = "Inefficiency";
        public const string Routeway_Building_AssetName = "Building";
        public const string Routeway_NoFood_AssetName = "NoFood";
        public const string Routeway_Hostile_AssetName = "Hostile";
        public const string Routeway_DirectionArrowNone_AssetName = "DirectionArrowNone";
        public const string Routeway_DirectionArrowLeft_AssetName = "DirectionArrowLeft";
        public const string Routeway_DirectionArrowUp_AssetName = "DirectionArrowUp";
        public const string Routeway_DirectionArrowRight_AssetName = "DirectionArrowRight";
        public const string Routeway_DirectionArrowDown_AssetName = "DirectionArrowDown";
        public const string Routeway_DirectionTailNone_AssetName = "DirectionTailNone";
        public const string Routeway_DirectionTailLeft_AssetName = "DirectionTailLeft";
        public const string Routeway_DirectionTailUp_AssetName = "DirectionTailUp";
        public const string Routeway_DirectionTailRight_AssetName = "DirectionTailRight";
        public const string Routeway_DirectionTailDown_AssetName = "DirectionTailDown";
        public const string Routeway_FileExt = ".png";
        public const string Effects_Path = "Effects/";
        public const string TileEffect_Path = "TileEffect/";
        public const string TileEffect_CriticalStrike_AssetName = "CriticalStrike";
        public const string TileEffect_FileExt = ".png";
        public const string CombatNumber_Path = "CombatNumber/";
        public const string CombatNumber_FileName = "CombatNumber.png";
        public const string Selector_Path = "Selector/";
        public const string Selector_FileName = "Selector.png";
        public const string BackGroundMap_Path = "BackGroundMap/";
        public const string BackGroundMap_FileName = "BackGroundMap.jpg";
        public const string Music_Path = "GameMusic/";
        public const string Music_Title_FileName = "Title.mp3";
        public const string Music_Spring_FileName = "Spring.wma";
        public const string Music_Summer_FileName = "Summer.wma";
        public const string Music_Autumn_FileName = "Autumn.wma";
        public const string Music_Winter_FileName = "Winter.wma";
        public const string Music_Victory_FileName = "Victory.wma";
        public const string Music_Fight_FileName = "Fight.wma";
        public const string Music_Dead_FileName = "Dead.wma";
        public const string Sound_Path = "GameSound/";
        public const string Sound_Animation = "Animation/";
        public const string Sound_Control = "Control/";
        public const string Sound_Tactics = "Tactics/";
        public const string Sound_ControlFileName = "Control";
        public const string Sound_OutsideFileName = "Outside";
        public const string Sound_FileExt = ".wav";
        public const string SmallSuffix = "s";
        public const string TempImageFileName = "~tmp.image";
        public const string FrameTitle_Default = "";
        public const string Tab_Default = "";
        public const string Jump = "跳转";
        public const string FrameTitle_ChangeControl = "变更控制";
        public const string FrameTitle_NoFactionPersons = "在野人物";
        public const string FrameTitle_SelectCampaignPerson = "出征人物";
        public const string FrameTitle_SelectOnePerson = "选择队长";
        public const string FrameTitle_SelectOneMilitary = "选择编队";
        public const string FrameTitle_SelectDisband = "解散编队";
        public const string FrameTitle_SelectOneMilitaryKind = "选择兵种";
        public const string FrameTitle_FacilityKind = "设施种类";
        public const string FrameTitle_SelectOneFacility = "选择设施";
        public const string FrameTitle_SelfCaptive = "被俘虏列表";
        public const string FrameTitle_RedeemCaptive = "赎回俘虏";
        public const string FrameTitle_ReleaseCaptive = "释放俘虏";
        public const string Title_TransferFund = "运送资金";
        public const string Title_TransferFood = "运输粮草";
        public const string Comma = ",";
        public const string Bullet = "•";
        public const string None = "----";
        public const string Male = "男";
        public const string Female = "女";
        public const string IsTrue = "○";
        public const string IsFalse = "×";
        public const string Undefined = "未知";
        public const string Rash = "鲁莽";
        public const string Timid = "怯懦";
        public const string Lofty = "高傲";
        public const string Tough = "坚韧";
        public const string Patient = "耐心";
        public const string Calm = "冷静";
        public const string Strength = "武勇";
        public const string Command = "统率";
        public const string Intelligence = "智谋";
        public const string Politics = "政治";
        public const string Glamour = "魅力";
        public const string Braveness = "勇猛度";
        public const string Calmness = "冷静度";
        public const string Captive = "俘虏";
        public const string StopWork = "停止工作";
        public const string Agriculture = "农业";
        public const string Commerce = "商业";
        public const string Technology = "技术";
        public const string Domination = "统治";
        public const string Morale = "民心";
        public const string Endurance = "耐久";
        public const string Transfer = "调动";
        public const string Target = "目标";
        public const string Convene = "召集";
        public const string Hire = "录用";
        public const string Convince = "说服";
        public const string Reward = "褒奖";
        public const string Study = "研习";
        public const string Training = "训练";
        public const string Recruitment = "补充";
        public const string Return = "返回";
        public const string Merge = "合并";
        public const string Information = "情报";
        public const string Spy = "间谍";
        public const string Destroy = "破坏";
        public const string Instigate = "煽动";
        public const string Gossip = "流言";
        public const string Search = "搜索";
        public const string ChangeCapital = "迁都";
        public const string EnhaneceDiplomaticRelation = "亲善";
        public const string AllyDiplomaticRelation = "结盟";
        public const string ResetDiplomaticRelation = "解盟";
        public const string TruceDiplomaticRelation = "停战";
        public const string DenounceDiplomaticRelation = "声讨";
        public const string InformationKind = "情报种类";
        public const string AttackDefault = "攻击默认";
        public const string AttackTarget = "攻击目标";
        public const string CastDefault = "施展默认";
        public const string CastTarget = "施展目标";
        public const string City = "城池";
        public const string Block = "关隘";
        public const string Port = "港口";
        public const string Plain = "平原";
        public const string Grassland = "草地";
        public const string Forest = "森林";
        public const string Marsh = "湿地";
        public const string Mountain = "山地";
        public const string River = "河流";
        public const string Ridge = "峻岭";
        public const string Wasteland = "荒原";
        public const string Desert = "沙漠";
        public const string Cliff = "雪地";
        public const string etc = "等";
        public const string Computer = "电脑";
        public const string System = "系统选项";
        public const string Save = "存储进度";
        public const string Load = "读取进度";
        public const string Options = "环境设置";
        public const string StartMenu = "初始界面";
        public const string ExitGame = "退出游戏";
        public const string ResumeGame = "继续游戏";
        public const string Year = "年";
        public const string Month = "月";
        public const string Day = "日";
        public const string Days = "天";
        public const string Troop = "队";
        public const string Routeway = "粮道";
        public const string Section = "军区";
        public const string More = "↑";
        public const string Less = "↓";
        public const string EffectPossitive = "正面";
        public const string EffectNegative = "负面";
        public const string NotClear = "不明";
    }
}

