del /s /q ..\public
md ..\public
xcopy *.* ..\public /EXCLUDE:publicExclude.txt /e
copy GameData\GameParametersPublic.xml ..\public\GameData\GameParameters.xml
copy GameData\GlobalVariablesPublic.xml ..\public\GameData\GlobalVariables.xml
copy GameData\Common\CommonDataPublic.mdb ..\public\GameData\Common\CommonData.mdb
xcopy GameComponents\tupianwenzi\Data\meinvtupian\Public ..\public\GameComponents\tupianwenzi\Data\meinvtupian
xcopy Resources\CreateChildrenTextFile\Public ..\public\Resources\CreateChildrenTextFile
md ..\public\GameComponents\PersonPortrait\PlayerImage
copy GameComponents\PersonPortrait\PlayerImage\9999.jpg ..\public\GameComponents\PersonPortrait\PlayerImage\9999.jpg
copy GameComponents\PersonPortrait\PlayerImage\9999s.jpg ..\public\GameComponents\PersonPortrait\PlayerImage\9999s.jpg
copy GameComponents\PersonPortrait\PlayerImage\ReadMe.txt ..\public\GameComponents\PersonPortrait\PlayerImage\ReadMe.txt
md ..\public\GameData\Save
