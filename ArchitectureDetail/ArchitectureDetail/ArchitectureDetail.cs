namespace ArchitectureDetail
{
    using GameFreeText;
    using GameGlobal;
    using GameObjects;
    using GameObjects.ArchitectureDetail;
    using GameObjects.Influences;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Collections.Generic;

    public class ArchitectureDetail
    {
        internal Point BackgroundSize;
        internal Texture2D BackgroundTexture;
        internal Rectangle CharacteristicClient;
        internal FreeRichText CharacteristicText = new FreeRichText();
        private Point DisplayOffset;
        internal Rectangle FacilityClient;
        internal FreeRichText FacilityText = new FreeRichText();
        private bool isShowing;
        internal List<LabelText> LabelTexts = new List<LabelText>();
        internal Screen screen;
        internal Architecture ShowingArchitecture;
        //↓功能开关定义
        internal string Switch1;//建筑图片
        internal string Switch2;//新建筑种类图片
        internal string Switch3;//按键联动
        internal string Switch4;//A区
        internal string Switch5;//B区
        internal string Switch6;//C区
        internal string Switch7;//D区
        internal string Switch8;//E区
        internal string Switch9;//建筑种类图片
        internal string Switch10;//建筑ID图片
        internal string Switch11;//建筑特色
        internal string Switch12;//进度条
        internal string Switch13;//辅助页
        internal string Switch14;//辅助页设施说明

        //↓文字说明
        internal FreeRichText FacilityAText = new FreeRichText();
        internal FreeRichText FacilityBText = new FreeRichText();
        internal FreeRichText FacilityCText = new FreeRichText();
        internal FreeRichText FacilityDText = new FreeRichText();
        internal FreeRichText FacilityEText = new FreeRichText();
        internal FreeRichText FacilityZText = new FreeRichText();
        internal FreeRichText FacilitySText = new FreeRichText();
        internal Rectangle FacilityATextClient;
        internal Rectangle FacilityBTextClient;
        internal Rectangle FacilityCTextClient;
        internal Rectangle FacilityDTextClient;
        internal Rectangle FacilityETextClient;
        internal Rectangle FacilityZTextClient;
        internal Rectangle FacilitySTextClient;
        //↓文字说明背景图片
        internal Texture2D TextBackgroundTexture;
        internal Rectangle TextBackgroundClient;        
        //↓建筑特色背景图片      
        internal Texture2D ACBackgroundTexture;
        internal Rectangle ACBackgroundClient;
        //↓辅助页色背景图片
        internal Texture2D AuxiliaryBackgroundTexture;
        internal Rectangle AuxiliaryBackgroundClient;
        //↓建筑图片相关定义
        internal Texture2D BackgroundforArchitectureTexture;
        internal Texture2D BackgroundforArchitecture1Texture;
        internal Texture2D BackgroundforArchitecture2Texture;
        internal Texture2D BackgroundforArchitecture3Texture;
        internal Texture2D BackgroundforArchitecture4Texture;
        internal Texture2D BackgroundforArchitecture5Texture;
        internal Texture2D BackgroundforArchitecture6Texture;
        internal Texture2D BackgroundforArchitecture7Texture;
        internal Texture2D BackgroundforArchitecture8Texture;
        internal Texture2D BackgroundforArchitecture9Texture;
        internal Texture2D BackgroundforArchitecture10Texture;
        internal Texture2D BackgroundforArchitecture11Texture;
        internal Texture2D BackgroundforArchitecture12Texture;
        internal Texture2D BackgroundforArchitecture13Texture;
        internal Texture2D BackgroundforArchitecture14Texture;
        internal Texture2D BackgroundforArchitecture15Texture;
        internal Texture2D BackgroundforArchitecture16Texture;
        internal Texture2D BackgroundforArchitecture17Texture;
        internal Texture2D BackgroundforArchitecture18Texture;
        internal Texture2D BackgroundforArchitecture19Texture;
        internal Texture2D BackgroundforArchitecture20Texture;
        internal Texture2D BackgroundforArchitecture21Texture;
        internal Texture2D BackgroundforArchitecture22Texture;
        internal Texture2D BackgroundforArchitecture23Texture;
        internal Texture2D BackgroundforArchitecture24Texture;
        internal Texture2D BackgroundforArchitecture25Texture;
        internal Texture2D BackgroundforArchitecture26Texture;
        internal Texture2D BackgroundforArchitecture27Texture;
        internal Texture2D BackgroundforArchitecture28Texture;
        internal Rectangle BackgroundforArchitectureClient;
        //↓建筑种类相关定义
        internal string AKinds;
        internal string AKindfor1;
        internal string AKindfor2;
        internal string AKindfor3;
        internal string AKindfor4;
        internal string AKindfor5;
        internal string AKindfor6;
        internal string AKindfor7;
        internal string AKindfor8;
        internal string AKindfor9;
        internal string AKindfor10;
        internal string AKindfor11;
        internal string AKindfor12;
        internal string AKindfor13;
        internal string AKindfor14;
        internal string AKindfor15;
        internal string AKindfor16;
        internal string AKindfor17;
        internal string AKindfor18;
        internal string AKindfor19;
        internal string AKindfor20;
        internal string AKindfor21;
        internal string AKindfor22;
        internal string AKindfor23;
        internal string AKindfor24;
        internal string AKindfor25;
        internal string AKindfor26;
        internal string AKindfor27;
        internal string AKindfor28;
        //↓设施空间相关定义
        internal int PositionCounts;
        internal int PositionCount1;
        internal int PositionCount2;
        internal int PositionCount3;
        internal int PositionCount4;
        internal int PositionCount5;
        internal int PositionCount6;
        internal int PositionCount7;
        internal int PositionCount8;
        internal int PositionCount9;
        internal int PositionCount10;
        internal int PositionCount11;
        internal int PositionCount12;
        internal int PositionCount13;
        internal int PositionCount14;
        internal int PositionCount15;
        internal int PositionCount16;
        internal int PositionCount17;
        internal int PositionCount18;
        internal int PositionCount19;
        internal int PositionCount20;
        internal int PositionCount21;
        internal int PositionCount22;
        internal int PositionCount23;
        internal int PositionCount24;
        internal int PositionCount25;
        internal int PositionCount26;
        internal int PositionCount27;
        internal int PositionCount28;      
        //↓设施种类相关定义
        internal string Facilitys;
        internal string FacilityforA1;
        internal string FacilityforA2;
        internal string FacilityforA3;
        internal string FacilityforA4;
        internal string FacilityforA5;
        internal string FacilityforA6;
        internal string FacilityforA7;
        internal string FacilityforA8;
        internal string FacilityforA9;
        internal string FacilityforA10;
        internal string FacilityforA11;
        internal string FacilityforA12;
        internal string FacilityforA13;
        internal string FacilityforA14;
        internal string FacilityforA15;
        internal string FacilityforA16;
        internal string FacilityforA17;
        internal string FacilityforA18;
        internal string FacilityforA19;
        internal string FacilityforA20;
        internal string FacilityforA21;
        internal string FacilityforA22;
        internal string FacilityforA23;
        internal string FacilityforA24;
        internal string FacilityforA25;
        internal string FacilityforA26;
        internal string FacilityforA27;
        internal string FacilityforA28;
        internal string FacilityforB1;
        internal string FacilityforB2;
        internal string FacilityforB3;
        internal string FacilityforB4;
        internal string FacilityforB5;
        internal string FacilityforB6;
        internal string FacilityforB7;
        internal string FacilityforB8;
        internal string FacilityforB9;
        internal string FacilityforB10;
        internal string FacilityforB11;
        internal string FacilityforB12;
        internal string FacilityforB13;
        internal string FacilityforB14;
        internal string FacilityforB15;
        internal string FacilityforB16;
        internal string FacilityforB17;
        internal string FacilityforB18;
        internal string FacilityforB19;
        internal string FacilityforB20;
        internal string FacilityforB21;
        internal string FacilityforB22;
        internal string FacilityforB23;
        internal string FacilityforB24;
        internal string FacilityforB25;
        internal string FacilityforB26;
        internal string FacilityforB27;
        internal string FacilityforB28;
        internal string FacilityforC1;
        internal string FacilityforC2;
        internal string FacilityforC3;
        internal string FacilityforC4;
        internal string FacilityforC5;
        internal string FacilityforC6;
        internal string FacilityforC7;
        internal string FacilityforC8;
        internal string FacilityforC9;
        internal string FacilityforC10;
        internal string FacilityforC11;
        internal string FacilityforC12;
        internal string FacilityforC13;
        internal string FacilityforC14;
        internal string FacilityforC15;
        internal string FacilityforC16;
        internal string FacilityforC17;
        internal string FacilityforC18;
        internal string FacilityforC19;
        internal string FacilityforC20;
        internal string FacilityforC21;
        internal string FacilityforC22;
        internal string FacilityforC23;
        internal string FacilityforC24;
        internal string FacilityforC25;
        internal string FacilityforC26;
        internal string FacilityforC27;
        internal string FacilityforC28;
        internal string FacilityforD1;
        internal string FacilityforD2;
        internal string FacilityforD3;
        internal string FacilityforD4;
        internal string FacilityforD5;
        internal string FacilityforD6;
        internal string FacilityforD7;
        internal string FacilityforD8;
        internal string FacilityforD9;
        internal string FacilityforD10;
        internal string FacilityforD11;
        internal string FacilityforD12;
        internal string FacilityforD13;
        internal string FacilityforD14;
        internal string FacilityforD15;
        internal string FacilityforD16;
        internal string FacilityforD17;
        internal string FacilityforD18;
        internal string FacilityforD19;
        internal string FacilityforD20;
        internal string FacilityforD21;
        internal string FacilityforD22;
        internal string FacilityforD23;
        internal string FacilityforD24;
        internal string FacilityforD25;
        internal string FacilityforD26;
        internal string FacilityforD27;
        internal string FacilityforD28;
        internal string FacilityforE1;
        internal string FacilityforE2;
        internal string FacilityforE3;
        internal string FacilityforE4;
        internal string FacilityforE5;
        internal string FacilityforE6;
        internal string FacilityforE7;
        internal string FacilityforE8;
        internal string FacilityforE9;
        internal string FacilityforE10;
        internal string FacilityforE11;
        internal string FacilityforE12;
        internal string FacilityforE13;
        internal string FacilityforE14;
        internal string FacilityforE15;
        internal string FacilityforE16;
        internal string FacilityforE17;
        internal string FacilityforE18;
        internal string FacilityforE19;
        internal string FacilityforE20;
        internal string FacilityforE21;
        internal string FacilityforE22;
        internal string FacilityforE23;
        internal string FacilityforE24;
        internal string FacilityforE25;
        internal string FacilityforE26;
        internal string FacilityforE27;
        internal string FacilityforE28;
        //↓设施介绍相关定义
        //internal string FacilitysText;
        internal string FacilityforA1Text;
        internal string FacilityforA2Text;
        internal string FacilityforA3Text;
        internal string FacilityforA4Text;
        internal string FacilityforA5Text;
        internal string FacilityforA6Text;
        internal string FacilityforA7Text;
        internal string FacilityforA8Text;
        internal string FacilityforA9Text;
        internal string FacilityforA10Text;
        internal string FacilityforA11Text;
        internal string FacilityforA12Text;
        internal string FacilityforA13Text;
        internal string FacilityforA14Text;
        internal string FacilityforA15Text;
        internal string FacilityforA16Text;
        internal string FacilityforA17Text;
        internal string FacilityforA18Text;
        internal string FacilityforA19Text;
        internal string FacilityforA20Text;
        internal string FacilityforA21Text;
        internal string FacilityforA22Text;
        internal string FacilityforA23Text;
        internal string FacilityforA24Text;
        internal string FacilityforA25Text;
        internal string FacilityforA26Text;
        internal string FacilityforA27Text;
        internal string FacilityforA28Text;
        internal string FacilityforB1Text;
        internal string FacilityforB2Text;
        internal string FacilityforB3Text;
        internal string FacilityforB4Text;
        internal string FacilityforB5Text;
        internal string FacilityforB6Text;
        internal string FacilityforB7Text;
        internal string FacilityforB8Text;
        internal string FacilityforB9Text;
        internal string FacilityforB10Text;
        internal string FacilityforB11Text;
        internal string FacilityforB12Text;
        internal string FacilityforB13Text;
        internal string FacilityforB14Text;
        internal string FacilityforB15Text;
        internal string FacilityforB16Text;
        internal string FacilityforB17Text;
        internal string FacilityforB18Text;
        internal string FacilityforB19Text;
        internal string FacilityforB20Text;
        internal string FacilityforB21Text;
        internal string FacilityforB22Text;
        internal string FacilityforB23Text;
        internal string FacilityforB24Text;
        internal string FacilityforB25Text;
        internal string FacilityforB26Text;
        internal string FacilityforB27Text;
        internal string FacilityforB28Text;
        internal string FacilityforC1Text;
        internal string FacilityforC2Text;
        internal string FacilityforC3Text;
        internal string FacilityforC4Text;
        internal string FacilityforC5Text;
        internal string FacilityforC6Text;
        internal string FacilityforC7Text;
        internal string FacilityforC8Text;
        internal string FacilityforC9Text;
        internal string FacilityforC10Text;
        internal string FacilityforC11Text;
        internal string FacilityforC12Text;
        internal string FacilityforC13Text;
        internal string FacilityforC14Text;
        internal string FacilityforC15Text;
        internal string FacilityforC16Text;
        internal string FacilityforC17Text;
        internal string FacilityforC18Text;
        internal string FacilityforC19Text;
        internal string FacilityforC20Text;
        internal string FacilityforC21Text;
        internal string FacilityforC22Text;
        internal string FacilityforC23Text;
        internal string FacilityforC24Text;
        internal string FacilityforC25Text;
        internal string FacilityforC26Text;
        internal string FacilityforC27Text;
        internal string FacilityforC28Text;
        internal string FacilityforD1Text;
        internal string FacilityforD2Text;
        internal string FacilityforD3Text;
        internal string FacilityforD4Text;
        internal string FacilityforD5Text;
        internal string FacilityforD6Text;
        internal string FacilityforD7Text;
        internal string FacilityforD8Text;
        internal string FacilityforD9Text;
        internal string FacilityforD10Text;
        internal string FacilityforD11Text;
        internal string FacilityforD12Text;
        internal string FacilityforD13Text;
        internal string FacilityforD14Text;
        internal string FacilityforD15Text;
        internal string FacilityforD16Text;
        internal string FacilityforD17Text;
        internal string FacilityforD18Text;
        internal string FacilityforD19Text;
        internal string FacilityforD20Text;
        internal string FacilityforD21Text;
        internal string FacilityforD22Text;
        internal string FacilityforD23Text;
        internal string FacilityforD24Text;
        internal string FacilityforD25Text;
        internal string FacilityforD26Text;
        internal string FacilityforD27Text;
        internal string FacilityforD28Text;
        internal string FacilityforE1Text;
        internal string FacilityforE2Text;
        internal string FacilityforE3Text;
        internal string FacilityforE4Text;
        internal string FacilityforE5Text;
        internal string FacilityforE6Text;
        internal string FacilityforE7Text;
        internal string FacilityforE8Text;
        internal string FacilityforE9Text;
        internal string FacilityforE10Text;
        internal string FacilityforE11Text;
        internal string FacilityforE12Text;
        internal string FacilityforE13Text;
        internal string FacilityforE14Text;
        internal string FacilityforE15Text;
        internal string FacilityforE16Text;
        internal string FacilityforE17Text;
        internal string FacilityforE18Text;
        internal string FacilityforE19Text;
        internal string FacilityforE20Text;
        internal string FacilityforE21Text;
        internal string FacilityforE22Text;
        internal string FacilityforE23Text;
        internal string FacilityforE24Text;
        internal string FacilityforE25Text;
        internal string FacilityforE26Text;
        internal string FacilityforE27Text;
        internal string FacilityforE28Text;
        internal string FacilityforZ1Text;
        internal string FacilityforZ2Text;
        internal string FacilityforZ3Text;
        internal string FacilityforZ4Text;
        internal string FacilityforZ5Text;
        internal string FacilityforZ6Text;
        internal string FacilityforZ7Text;
        internal string FacilityforZ8Text;
        internal string FacilityforZ9Text;
        internal string FacilityforZ10Text;
        internal string FacilityforZ11Text;
        internal string FacilityforZ12Text;
        internal string FacilityforZ13Text;
        internal string FacilityforZ14Text;
        internal string FacilityforZ15Text;
        internal string FacilityforZ16Text;
        internal string FacilityforZ17Text;
        internal string FacilityforZ18Text;
        internal string FacilityforZ19Text;
        internal string FacilityforZ20Text;
        internal string FacilityforZ21Text;
        internal string FacilityforZ22Text;
        internal string FacilityforZ23Text;
        internal string FacilityforZ24Text;
        internal string FacilityforZ25Text;
        internal string FacilityforZ26Text;
        internal string FacilityforZ27Text;
        internal string FacilityforZ28Text;


        //↓建筑种类文理及尺寸相关定义
        internal Texture2D AKBackgroundTexture;
        internal Texture2D AKBackground0Texture;
        internal Texture2D AKBackground1Texture;
        internal Texture2D AKBackground2Texture;
        internal Texture2D AKBackground3Texture;
        internal Texture2D AKBackground4Texture;
        internal Texture2D AKBackground5Texture;
        internal Texture2D AKBackground6Texture;
        internal Texture2D AKBackground7Texture;
        internal Texture2D AKBackground8Texture;
        internal Texture2D AKBackground9Texture;
        internal Texture2D AKBackground10Texture;
        internal Texture2D AKBackground11Texture;
        internal Texture2D AKBackground12Texture;
        internal Texture2D AKBackground13Texture;
        internal Texture2D AKBackground14Texture;
        internal Texture2D AKBackground15Texture;
        internal Texture2D AKBackground16Texture;
        internal Texture2D AKBackground17Texture;
        internal Texture2D AKBackground18Texture;
        internal Texture2D AKBackground19Texture;
        internal Texture2D AKBackground20Texture;
        internal Texture2D AKBackground21Texture;
        internal Texture2D AKBackground22Texture;
        internal Texture2D AKBackground23Texture;
        internal Texture2D AKBackground24Texture;
        internal Texture2D AKBackground25Texture;
        internal Texture2D AKBackground26Texture;
        internal Texture2D AKBackground27Texture;
        internal Texture2D AKBackground28Texture;
        internal Rectangle AKBackground0Client; 

        //↓设施界面相关定义(A区)
        internal Texture2D FABackgroundTexture;
        internal Texture2D FABackground1Texture;
        internal Texture2D FABackground2Texture;
        internal Texture2D FABackground3Texture;
        internal Texture2D FABackground4Texture;
        internal Texture2D FABackground5Texture;
        internal Texture2D FABackground6Texture;
        internal Texture2D FABackground7Texture;
        internal Texture2D FABackground8Texture;
        internal Texture2D FABackground9Texture;
        internal Texture2D FABackground10Texture;
        internal Texture2D FABackground11Texture;
        internal Texture2D FABackground12Texture;
        internal Texture2D FABackground13Texture;
        internal Texture2D FABackground14Texture;
        internal Texture2D FABackground15Texture;
        internal Texture2D FABackground16Texture;
        internal Texture2D FABackground17Texture;
        internal Texture2D FABackground18Texture;
        internal Texture2D FABackground19Texture;
        internal Texture2D FABackground20Texture;
        internal Texture2D FABackground21Texture;
        internal Texture2D FABackground22Texture;
        internal Texture2D FABackground23Texture;
        internal Texture2D FABackground24Texture;
        internal Texture2D FABackground25Texture;
        internal Texture2D FABackground26Texture;
        internal Texture2D FABackground27Texture;
        internal Texture2D FABackground28Texture;
        internal Rectangle FABackground0Client;
        //↓设施界面相关定义(B区)
        internal Texture2D FBBackgroundTexture;
        internal Texture2D FBBackground1Texture;
        internal Texture2D FBBackground2Texture;
        internal Texture2D FBBackground3Texture;
        internal Texture2D FBBackground4Texture;
        internal Texture2D FBBackground5Texture;
        internal Texture2D FBBackground6Texture;
        internal Texture2D FBBackground7Texture;
        internal Texture2D FBBackground8Texture;
        internal Texture2D FBBackground9Texture;
        internal Texture2D FBBackground10Texture;
        internal Texture2D FBBackground11Texture;
        internal Texture2D FBBackground12Texture;
        internal Texture2D FBBackground13Texture;
        internal Texture2D FBBackground14Texture;
        internal Texture2D FBBackground15Texture;
        internal Texture2D FBBackground16Texture;
        internal Texture2D FBBackground17Texture;
        internal Texture2D FBBackground18Texture;
        internal Texture2D FBBackground19Texture;
        internal Texture2D FBBackground20Texture;
        internal Texture2D FBBackground21Texture;
        internal Texture2D FBBackground22Texture;
        internal Texture2D FBBackground23Texture;
        internal Texture2D FBBackground24Texture;
        internal Texture2D FBBackground25Texture;
        internal Texture2D FBBackground26Texture;
        internal Texture2D FBBackground27Texture;
        internal Texture2D FBBackground28Texture;
        internal Rectangle FBBackground0Client;
        //↓设施界面相关定义(C区)
        internal Texture2D FCBackgroundTexture;
        internal Texture2D FCBackground1Texture;
        internal Texture2D FCBackground2Texture;
        internal Texture2D FCBackground3Texture;
        internal Texture2D FCBackground4Texture;
        internal Texture2D FCBackground5Texture;
        internal Texture2D FCBackground6Texture;
        internal Texture2D FCBackground7Texture;
        internal Texture2D FCBackground8Texture;
        internal Texture2D FCBackground9Texture;
        internal Texture2D FCBackground10Texture;
        internal Texture2D FCBackground11Texture;
        internal Texture2D FCBackground12Texture;
        internal Texture2D FCBackground13Texture;
        internal Texture2D FCBackground14Texture;
        internal Texture2D FCBackground15Texture;
        internal Texture2D FCBackground16Texture;
        internal Texture2D FCBackground17Texture;
        internal Texture2D FCBackground18Texture;
        internal Texture2D FCBackground19Texture;
        internal Texture2D FCBackground20Texture;
        internal Texture2D FCBackground21Texture;
        internal Texture2D FCBackground22Texture;
        internal Texture2D FCBackground23Texture;
        internal Texture2D FCBackground24Texture;
        internal Texture2D FCBackground25Texture;
        internal Texture2D FCBackground26Texture;
        internal Texture2D FCBackground27Texture;
        internal Texture2D FCBackground28Texture;
        internal Rectangle FCBackground0Client;
        //↓设施界面相关定义(D区)
        internal Texture2D FDBackgroundTexture;
        internal Texture2D FDBackground1Texture;
        internal Texture2D FDBackground2Texture;
        internal Texture2D FDBackground3Texture;
        internal Texture2D FDBackground4Texture;
        internal Texture2D FDBackground5Texture;
        internal Texture2D FDBackground6Texture;
        internal Texture2D FDBackground7Texture;
        internal Texture2D FDBackground8Texture;
        internal Texture2D FDBackground9Texture;
        internal Texture2D FDBackground10Texture;
        internal Texture2D FDBackground11Texture;
        internal Texture2D FDBackground12Texture;
        internal Texture2D FDBackground13Texture;
        internal Texture2D FDBackground14Texture;
        internal Texture2D FDBackground15Texture;
        internal Texture2D FDBackground16Texture;
        internal Texture2D FDBackground17Texture;
        internal Texture2D FDBackground18Texture;
        internal Texture2D FDBackground19Texture;
        internal Texture2D FDBackground20Texture;
        internal Texture2D FDBackground21Texture;
        internal Texture2D FDBackground22Texture;
        internal Texture2D FDBackground23Texture;
        internal Texture2D FDBackground24Texture;
        internal Texture2D FDBackground25Texture;
        internal Texture2D FDBackground26Texture;
        internal Texture2D FDBackground27Texture;
        internal Texture2D FDBackground28Texture;
        internal Rectangle FDBackground0Client;
        //↓设施界面相关定义(E区)
        internal Texture2D FEBackgroundTexture;
        internal Texture2D FEBackground1Texture;
        internal Texture2D FEBackground2Texture;
        internal Texture2D FEBackground3Texture;
        internal Texture2D FEBackground4Texture;
        internal Texture2D FEBackground5Texture;
        internal Texture2D FEBackground6Texture;
        internal Texture2D FEBackground7Texture;
        internal Texture2D FEBackground8Texture;
        internal Texture2D FEBackground9Texture;
        internal Texture2D FEBackground10Texture;
        internal Texture2D FEBackground11Texture;
        internal Texture2D FEBackground12Texture;
        internal Texture2D FEBackground13Texture;
        internal Texture2D FEBackground14Texture;
        internal Texture2D FEBackground15Texture;
        internal Texture2D FEBackground16Texture;
        internal Texture2D FEBackground17Texture;
        internal Texture2D FEBackground18Texture;
        internal Texture2D FEBackground19Texture;
        internal Texture2D FEBackground20Texture;
        internal Texture2D FEBackground21Texture;
        internal Texture2D FEBackground22Texture;
        internal Texture2D FEBackground23Texture;
        internal Texture2D FEBackground24Texture;
        internal Texture2D FEBackground25Texture;
        internal Texture2D FEBackground26Texture;
        internal Texture2D FEBackground27Texture;
        internal Texture2D FEBackground28Texture;
        internal Rectangle FEBackground0Client;

        ////↓在设施相关定义
        internal string FacilityforIng;
        internal string FacilityforIngDay;
        internal Texture2D FacilityforIngTexture;
        internal Rectangle FacilityforIngClient; 
        //↓设施种类文理及尺寸相关定义（A区）
        internal Texture2D FacilityforA1Texture;
        internal Texture2D FacilityforA2Texture;
        internal Texture2D FacilityforA3Texture;
        internal Texture2D FacilityforA4Texture;
        internal Texture2D FacilityforA5Texture;
        internal Texture2D FacilityforA6Texture;
        internal Texture2D FacilityforA7Texture;
        internal Texture2D FacilityforA8Texture;
        internal Texture2D FacilityforA9Texture;
        internal Texture2D FacilityforA10Texture;
        internal Texture2D FacilityforA11Texture;
        internal Texture2D FacilityforA12Texture;
        internal Texture2D FacilityforA13Texture;
        internal Texture2D FacilityforA14Texture;
        internal Texture2D FacilityforA15Texture;
        internal Texture2D FacilityforA16Texture;
        internal Texture2D FacilityforA17Texture;
        internal Texture2D FacilityforA18Texture;
        internal Texture2D FacilityforA19Texture;
        internal Texture2D FacilityforA20Texture;
        internal Texture2D FacilityforA21Texture;
        internal Texture2D FacilityforA22Texture;
        internal Texture2D FacilityforA23Texture;
        internal Texture2D FacilityforA24Texture;
        internal Texture2D FacilityforA25Texture;
        internal Texture2D FacilityforA26Texture;
        internal Texture2D FacilityforA27Texture;
        internal Texture2D FacilityforA28Texture;
        internal Rectangle FacilityforA1Client;
        internal Rectangle FacilityforA2Client;
        internal Rectangle FacilityforA3Client;
        internal Rectangle FacilityforA4Client;
        internal Rectangle FacilityforA5Client;
        internal Rectangle FacilityforA6Client;
        internal Rectangle FacilityforA7Client;
        internal Rectangle FacilityforA8Client;
        internal Rectangle FacilityforA9Client;
        internal Rectangle FacilityforA10Client;
        internal Rectangle FacilityforA11Client;
        internal Rectangle FacilityforA12Client;
        internal Rectangle FacilityforA13Client;
        internal Rectangle FacilityforA14Client;
        internal Rectangle FacilityforA15Client;
        internal Rectangle FacilityforA16Client;
        internal Rectangle FacilityforA17Client;
        internal Rectangle FacilityforA18Client;
        internal Rectangle FacilityforA19Client;
        internal Rectangle FacilityforA20Client;
        internal Rectangle FacilityforA21Client;
        internal Rectangle FacilityforA22Client;
        internal Rectangle FacilityforA23Client;
        internal Rectangle FacilityforA24Client;
        internal Rectangle FacilityforA25Client;
        internal Rectangle FacilityforA26Client;
        internal Rectangle FacilityforA27Client;
        internal Rectangle FacilityforA28Client;
        //↓设施种类文理及尺寸相关定义（B区）
        internal Texture2D FacilityforB1Texture;
        internal Texture2D FacilityforB2Texture;
        internal Texture2D FacilityforB3Texture;
        internal Texture2D FacilityforB4Texture;
        internal Texture2D FacilityforB5Texture;
        internal Texture2D FacilityforB6Texture;
        internal Texture2D FacilityforB7Texture;
        internal Texture2D FacilityforB8Texture;
        internal Texture2D FacilityforB9Texture;
        internal Texture2D FacilityforB10Texture;
        internal Texture2D FacilityforB11Texture;
        internal Texture2D FacilityforB12Texture;
        internal Texture2D FacilityforB13Texture;
        internal Texture2D FacilityforB14Texture;
        internal Texture2D FacilityforB15Texture;
        internal Texture2D FacilityforB16Texture;
        internal Texture2D FacilityforB17Texture;
        internal Texture2D FacilityforB18Texture;
        internal Texture2D FacilityforB19Texture;
        internal Texture2D FacilityforB20Texture;
        internal Texture2D FacilityforB21Texture;
        internal Texture2D FacilityforB22Texture;
        internal Texture2D FacilityforB23Texture;
        internal Texture2D FacilityforB24Texture;
        internal Texture2D FacilityforB25Texture;
        internal Texture2D FacilityforB26Texture;
        internal Texture2D FacilityforB27Texture;
        internal Texture2D FacilityforB28Texture;
        internal Rectangle FacilityforB1Client;
        internal Rectangle FacilityforB2Client;
        internal Rectangle FacilityforB3Client;
        internal Rectangle FacilityforB4Client;
        internal Rectangle FacilityforB5Client;
        internal Rectangle FacilityforB6Client;
        internal Rectangle FacilityforB7Client;
        internal Rectangle FacilityforB8Client;
        internal Rectangle FacilityforB9Client;
        internal Rectangle FacilityforB10Client;
        internal Rectangle FacilityforB11Client;
        internal Rectangle FacilityforB12Client;
        internal Rectangle FacilityforB13Client;
        internal Rectangle FacilityforB14Client;
        internal Rectangle FacilityforB15Client;
        internal Rectangle FacilityforB16Client;
        internal Rectangle FacilityforB17Client;
        internal Rectangle FacilityforB18Client;
        internal Rectangle FacilityforB19Client;
        internal Rectangle FacilityforB20Client;
        internal Rectangle FacilityforB21Client;
        internal Rectangle FacilityforB22Client;
        internal Rectangle FacilityforB23Client;
        internal Rectangle FacilityforB24Client;
        internal Rectangle FacilityforB25Client;
        internal Rectangle FacilityforB26Client;
        internal Rectangle FacilityforB27Client;
        internal Rectangle FacilityforB28Client;
        //↓设施种类文理及尺寸相关定义（C区）
        internal Texture2D FacilityforC1Texture;
        internal Texture2D FacilityforC2Texture;
        internal Texture2D FacilityforC3Texture;
        internal Texture2D FacilityforC4Texture;
        internal Texture2D FacilityforC5Texture;
        internal Texture2D FacilityforC6Texture;
        internal Texture2D FacilityforC7Texture;
        internal Texture2D FacilityforC8Texture;
        internal Texture2D FacilityforC9Texture;
        internal Texture2D FacilityforC10Texture;
        internal Texture2D FacilityforC11Texture;
        internal Texture2D FacilityforC12Texture;
        internal Texture2D FacilityforC13Texture;
        internal Texture2D FacilityforC14Texture;
        internal Texture2D FacilityforC15Texture;
        internal Texture2D FacilityforC16Texture;
        internal Texture2D FacilityforC17Texture;
        internal Texture2D FacilityforC18Texture;
        internal Texture2D FacilityforC19Texture;
        internal Texture2D FacilityforC20Texture;
        internal Texture2D FacilityforC21Texture;
        internal Texture2D FacilityforC22Texture;
        internal Texture2D FacilityforC23Texture;
        internal Texture2D FacilityforC24Texture;
        internal Texture2D FacilityforC25Texture;
        internal Texture2D FacilityforC26Texture;
        internal Texture2D FacilityforC27Texture;
        internal Texture2D FacilityforC28Texture;
        internal Rectangle FacilityforC1Client;
        internal Rectangle FacilityforC2Client;
        internal Rectangle FacilityforC3Client;
        internal Rectangle FacilityforC4Client;
        internal Rectangle FacilityforC5Client;
        internal Rectangle FacilityforC6Client;
        internal Rectangle FacilityforC7Client;
        internal Rectangle FacilityforC8Client;
        internal Rectangle FacilityforC9Client;
        internal Rectangle FacilityforC10Client;
        internal Rectangle FacilityforC11Client;
        internal Rectangle FacilityforC12Client;
        internal Rectangle FacilityforC13Client;
        internal Rectangle FacilityforC14Client;
        internal Rectangle FacilityforC15Client;
        internal Rectangle FacilityforC16Client;
        internal Rectangle FacilityforC17Client;
        internal Rectangle FacilityforC18Client;
        internal Rectangle FacilityforC19Client;
        internal Rectangle FacilityforC20Client;
        internal Rectangle FacilityforC21Client;
        internal Rectangle FacilityforC22Client;
        internal Rectangle FacilityforC23Client;
        internal Rectangle FacilityforC24Client;
        internal Rectangle FacilityforC25Client;
        internal Rectangle FacilityforC26Client;
        internal Rectangle FacilityforC27Client;
        internal Rectangle FacilityforC28Client;
        //↓设施种类文理及尺寸相关定义（D区）
        internal Texture2D FacilityforD1Texture;
        internal Texture2D FacilityforD2Texture;
        internal Texture2D FacilityforD3Texture;
        internal Texture2D FacilityforD4Texture;
        internal Texture2D FacilityforD5Texture;
        internal Texture2D FacilityforD6Texture;
        internal Texture2D FacilityforD7Texture;
        internal Texture2D FacilityforD8Texture;
        internal Texture2D FacilityforD9Texture;
        internal Texture2D FacilityforD10Texture;
        internal Texture2D FacilityforD11Texture;
        internal Texture2D FacilityforD12Texture;
        internal Texture2D FacilityforD13Texture;
        internal Texture2D FacilityforD14Texture;
        internal Texture2D FacilityforD15Texture;
        internal Texture2D FacilityforD16Texture;
        internal Texture2D FacilityforD17Texture;
        internal Texture2D FacilityforD18Texture;
        internal Texture2D FacilityforD19Texture;
        internal Texture2D FacilityforD20Texture;
        internal Texture2D FacilityforD21Texture;
        internal Texture2D FacilityforD22Texture;
        internal Texture2D FacilityforD23Texture;
        internal Texture2D FacilityforD24Texture;
        internal Texture2D FacilityforD25Texture;
        internal Texture2D FacilityforD26Texture;
        internal Texture2D FacilityforD27Texture;
        internal Texture2D FacilityforD28Texture;
        internal Rectangle FacilityforD1Client;
        internal Rectangle FacilityforD2Client;
        internal Rectangle FacilityforD3Client;
        internal Rectangle FacilityforD4Client;
        internal Rectangle FacilityforD5Client;
        internal Rectangle FacilityforD6Client;
        internal Rectangle FacilityforD7Client;
        internal Rectangle FacilityforD8Client;
        internal Rectangle FacilityforD9Client;
        internal Rectangle FacilityforD10Client;
        internal Rectangle FacilityforD11Client;
        internal Rectangle FacilityforD12Client;
        internal Rectangle FacilityforD13Client;
        internal Rectangle FacilityforD14Client;
        internal Rectangle FacilityforD15Client;
        internal Rectangle FacilityforD16Client;
        internal Rectangle FacilityforD17Client;
        internal Rectangle FacilityforD18Client;
        internal Rectangle FacilityforD19Client;
        internal Rectangle FacilityforD20Client;
        internal Rectangle FacilityforD21Client;
        internal Rectangle FacilityforD22Client;
        internal Rectangle FacilityforD23Client;
        internal Rectangle FacilityforD24Client;
        internal Rectangle FacilityforD25Client;
        internal Rectangle FacilityforD26Client;
        internal Rectangle FacilityforD27Client;
        internal Rectangle FacilityforD28Client;
        //↓设施种类文理及尺寸相关定义（E区）
        internal Texture2D FacilityforE1Texture;
        internal Texture2D FacilityforE2Texture;
        internal Texture2D FacilityforE3Texture;
        internal Texture2D FacilityforE4Texture;
        internal Texture2D FacilityforE5Texture;
        internal Texture2D FacilityforE6Texture;
        internal Texture2D FacilityforE7Texture;
        internal Texture2D FacilityforE8Texture;
        internal Texture2D FacilityforE9Texture;
        internal Texture2D FacilityforE10Texture;
        internal Texture2D FacilityforE11Texture;
        internal Texture2D FacilityforE12Texture;
        internal Texture2D FacilityforE13Texture;
        internal Texture2D FacilityforE14Texture;
        internal Texture2D FacilityforE15Texture;
        internal Texture2D FacilityforE16Texture;
        internal Texture2D FacilityforE17Texture;
        internal Texture2D FacilityforE18Texture;
        internal Texture2D FacilityforE19Texture;
        internal Texture2D FacilityforE20Texture;
        internal Texture2D FacilityforE21Texture;
        internal Texture2D FacilityforE22Texture;
        internal Texture2D FacilityforE23Texture;
        internal Texture2D FacilityforE24Texture;
        internal Texture2D FacilityforE25Texture;
        internal Texture2D FacilityforE26Texture;
        internal Texture2D FacilityforE27Texture;
        internal Texture2D FacilityforE28Texture;
        internal Rectangle FacilityforE1Client;
        internal Rectangle FacilityforE2Client;
        internal Rectangle FacilityforE3Client;
        internal Rectangle FacilityforE4Client;
        internal Rectangle FacilityforE5Client;
        internal Rectangle FacilityforE6Client;
        internal Rectangle FacilityforE7Client;
        internal Rectangle FacilityforE8Client;
        internal Rectangle FacilityforE9Client;
        internal Rectangle FacilityforE10Client;
        internal Rectangle FacilityforE11Client;
        internal Rectangle FacilityforE12Client;
        internal Rectangle FacilityforE13Client;
        internal Rectangle FacilityforE14Client;
        internal Rectangle FacilityforE15Client;
        internal Rectangle FacilityforE16Client;
        internal Rectangle FacilityforE17Client;
        internal Rectangle FacilityforE18Client;
        internal Rectangle FacilityforE19Client;
        internal Rectangle FacilityforE20Client;
        internal Rectangle FacilityforE21Client;
        internal Rectangle FacilityforE22Client;
        internal Rectangle FacilityforE23Client;
        internal Rectangle FacilityforE24Client;
        internal Rectangle FacilityforE25Client;
        internal Rectangle FacilityforE26Client;
        internal Rectangle FacilityforE27Client;
        internal Rectangle FacilityforE28Client;
        //↓设施个区按钮定义
        internal Texture2D ArchitectureButtonTexture;
        internal Texture2D ArchitectureKindButtonTexture;
        internal Texture2D FacilityforAButtonTexture;
        internal Texture2D FacilityforBButtonTexture;
        internal Texture2D FacilityforCButtonTexture;
        internal Texture2D FacilityforDButtonTexture;
        internal Texture2D FacilityforEButtonTexture;
        internal Texture2D FacilityforSButtonTexture;
        internal Texture2D ArchitecturePressedTexture;
        internal Texture2D ArchitectureKindPressedTexture;
        internal Texture2D FacilityforAPressedTexture;
        internal Texture2D FacilityforBPressedTexture;
        internal Texture2D FacilityforCPressedTexture;
        internal Texture2D FacilityforDPressedTexture;
        internal Texture2D FacilityforEPressedTexture;
        internal Texture2D FacilityforSPressedTexture;
        internal Rectangle ArchitectureButtonClient;
        internal Rectangle ArchitectureKindButtonClient;
        internal Rectangle FacilityforAButtonClient;
        internal Rectangle FacilityforBButtonClient;
        internal Rectangle FacilityforCButtonClient;
        internal Rectangle FacilityforDButtonClient;
        internal Rectangle FacilityforEButtonClient;
        internal Rectangle FacilityforSButtonClient;
        /*internal Rectangle ArchitecturePressedClient;
        internal Rectangle ArchitectureKindPressedClient;
        internal Rectangle FacilityforAPressedClient;
        internal Rectangle FacilityforBPressedClient;
        internal Rectangle FacilityforCPressedClient;
        internal Rectangle FacilityforDPressedClient;
        internal Rectangle FacilityforEPressedClient;
        */
        //↓按钮定义
        bool ArchitectureButton = true;
        bool NewArchitectureButton = false;
        bool FacilityforAButton = false;
        bool FacilityforBButton = false;
        bool FacilityforCButton = false;
        bool FacilityforDButton = false;
        bool FacilityforEButton = false;
        bool FacilityforSButton = false;

        //↓建筑编号定义
        internal int ArchitectureID;
        internal int AID1;
        internal int AID2;
        internal int AID3;
        internal int AID4;
        internal int AID5;
        internal int AID6;
        internal int AID7;
        internal int AID8;
        internal int AID9;
        internal int AID10;
        internal int AID11;
        internal int AID12;
        internal int AID13;
        internal int AID14;
        internal int AID15;
        internal int AID16;
        internal int AID17;
        internal int AID18;
        internal int AID19;
        internal int AID20;
        internal int AID21;
        internal int AID22;
        internal int AID23;
        internal int AID24;
        internal int AID25;
        internal int AID26;
        internal int AID27;
        internal int AID28;
        internal int AID29;
        internal int AID30;
        internal int AID31;
        internal int AID32;
        internal int AID33;
        internal int AID34;
        internal int AID35;
        internal int AID36;
        internal int AID37;
        internal int AID38;
        internal int AID39;
        internal int AID40;
        internal int AID41;
        internal int AID42;
        internal int AID43;
        internal int AID44;
        internal int AID45;
        internal int AID46;
        internal int AID47;
        internal int AID48;
        internal int AID49;
        internal int AID50;
        internal int AID51;
        internal int AID52;
        internal int AID53;
        internal int AID54;
        internal int AID55;
        internal int AID56;
        internal int AID57;
        internal int AID58;
        internal int AID59;
        internal int AID60;
        internal int AID61;
        internal int AID62;
        internal int AID63;
        internal int AID64;
        internal int AID65;
        internal int AID66;
        internal int AID67;
        internal int AID68;
        internal int AID69;
        internal int AID70;
        internal int AID71;
        internal int AID72;
        internal int AID73;
        internal int AID74;
        internal int AID75;
        internal int AID76;
        internal int AID77;
        internal int AID78;
        internal int AID79;
        internal int AID80;
        internal int AID81;
        internal int AID82;
        internal int AID83;
        internal int AID84;
        internal int AID85;
        internal int AID86;
        internal int AID87;
        internal int AID88;
        internal int AID89;
        internal int AID90;
        internal int AID91;
        internal int AID92;
        internal int AID93;
        internal int AID94;
        internal int AID95;
        internal int AID96;
        internal int AID97;
        internal int AID98;
        internal int AID99;
        //↓建筑对应图片定义
        internal Rectangle AIDClient;
        internal Texture2D AIDTexture;
        internal Texture2D AID0Texture;
        internal Texture2D AID1Texture;
        internal Texture2D AID2Texture;
        internal Texture2D AID3Texture;
        internal Texture2D AID4Texture;
        internal Texture2D AID5Texture;
        internal Texture2D AID6Texture;
        internal Texture2D AID7Texture;
        internal Texture2D AID8Texture;
        internal Texture2D AID9Texture;
        internal Texture2D AID10Texture;
        internal Texture2D AID11Texture;
        internal Texture2D AID12Texture;
        internal Texture2D AID13Texture;
        internal Texture2D AID14Texture;
        internal Texture2D AID15Texture;
        internal Texture2D AID16Texture;
        internal Texture2D AID17Texture;
        internal Texture2D AID18Texture;
        internal Texture2D AID19Texture;
        internal Texture2D AID20Texture;
        internal Texture2D AID21Texture;
        internal Texture2D AID22Texture;
        internal Texture2D AID23Texture;
        internal Texture2D AID24Texture;
        internal Texture2D AID25Texture;
        internal Texture2D AID26Texture;
        internal Texture2D AID27Texture;
        internal Texture2D AID28Texture;
        internal Texture2D AID29Texture;
        internal Texture2D AID30Texture;
        internal Texture2D AID31Texture;
        internal Texture2D AID32Texture;
        internal Texture2D AID33Texture;
        internal Texture2D AID34Texture;
        internal Texture2D AID35Texture;
        internal Texture2D AID36Texture;
        internal Texture2D AID37Texture;
        internal Texture2D AID38Texture;
        internal Texture2D AID39Texture;
        internal Texture2D AID40Texture;
        internal Texture2D AID41Texture;
        internal Texture2D AID42Texture;
        internal Texture2D AID43Texture;
        internal Texture2D AID44Texture;
        internal Texture2D AID45Texture;
        internal Texture2D AID46Texture;
        internal Texture2D AID47Texture;
        internal Texture2D AID48Texture;
        internal Texture2D AID49Texture;
        internal Texture2D AID50Texture;
        internal Texture2D AID51Texture;
        internal Texture2D AID52Texture;
        internal Texture2D AID53Texture;
        internal Texture2D AID54Texture;
        internal Texture2D AID55Texture;
        internal Texture2D AID56Texture;
        internal Texture2D AID57Texture;
        internal Texture2D AID58Texture;
        internal Texture2D AID59Texture;
        internal Texture2D AID60Texture;
        internal Texture2D AID61Texture;
        internal Texture2D AID62Texture;
        internal Texture2D AID63Texture;
        internal Texture2D AID64Texture;
        internal Texture2D AID65Texture;
        internal Texture2D AID66Texture;
        internal Texture2D AID67Texture;
        internal Texture2D AID68Texture;
        internal Texture2D AID69Texture;
        internal Texture2D AID70Texture;
        internal Texture2D AID71Texture;
        internal Texture2D AID72Texture;
        internal Texture2D AID73Texture;
        internal Texture2D AID74Texture;
        internal Texture2D AID75Texture;
        internal Texture2D AID76Texture;
        internal Texture2D AID77Texture;
        internal Texture2D AID78Texture;
        internal Texture2D AID79Texture;
        internal Texture2D AID80Texture;
        internal Texture2D AID81Texture;
        internal Texture2D AID82Texture;
        internal Texture2D AID83Texture;
        internal Texture2D AID84Texture;
        internal Texture2D AID85Texture;
        internal Texture2D AID86Texture;
        internal Texture2D AID87Texture;
        internal Texture2D AID88Texture;
        internal Texture2D AID89Texture;
        internal Texture2D AID90Texture;
        internal Texture2D AID91Texture;
        internal Texture2D AID92Texture;
        internal Texture2D AID93Texture;
        internal Texture2D AID94Texture;
        internal Texture2D AID95Texture;
        internal Texture2D AID96Texture;
        internal Texture2D AID97Texture;
        internal Texture2D AID98Texture;
        internal Texture2D AID99Texture;
        //↓建筑特色名称定义
        
        internal string Characteristics;
        internal string ACC1;
        internal string ACC2;
        internal string ACC3;
        internal string ACC4;
        internal string ACC5;
        internal string ACC6;
        internal string ACC7;
        internal string ACC8;
        internal string ACC9;
        internal string ACC10;
        internal string ACC11;
        internal string ACC12;
        internal string ACC13;
        internal string ACC14;
        internal string ACC15;
        internal string ACC16;
        internal string ACC17;
        internal string ACC18;
        internal string ACC19;
        internal string ACC20;
        internal string ACC21;
        internal string ACC22;
        internal string ACC23;
        internal string ACC24;
        internal string ACC25;
        internal string ACC26;
        internal string ACC27;
        internal string ACC28;
        internal string ACC29;
        internal string ACC30;
        internal string ACC31;
        internal string ACC32;
        internal string ACC33;
        internal string ACC34;
        internal string ACC35;
        internal string ACC36;
        internal string ACC37;
        internal string ACC38;
        internal string ACC39;
        internal string ACC40;
        internal string ACC41;
        internal string ACC42;
        internal string ACC43;
        internal string ACC44;
        internal string ACC45;
        internal string ACC46;
        internal string ACC47;
        internal string ACC48;
        internal string ACC49;
        internal string ACC50;
        internal string ACC51;
        internal string ACC52;
        internal string ACC53;
        internal string ACC54;
        internal string ACC55;
        internal string ACC56;
        internal string ACC57;
        internal string ACC58;
        internal string ACC59;
        internal string ACC60;
        internal string ACC61;
        internal string ACC62;
        internal string ACC63;
        internal string ACC64;
        internal string ACC65;
        internal string ACC66;
        internal string ACC67;
        internal string ACC68;
        internal string ACC69;
        internal string ACC70;
        internal string ACC71;
        internal string ACC72;
        internal string ACC73;
        internal string ACC74;
        internal string ACC75;
        internal string ACC76;
        internal string ACC77;
        internal string ACC78;
        internal string ACC79;
        internal string ACC80;
        internal string ACC81;
        internal string ACC82;
        internal string ACC83;
        internal string ACC84;
        internal string ACC85;
        internal string ACC86;
        internal string ACC87;
        internal string ACC88;
        internal string ACC89;
        internal string ACC90;
        internal string ACC91;
        internal string ACC92;
        internal string ACC93;
        internal string ACC94;
        internal string ACC95;
        internal string ACC96;
        internal string ACC97;
        internal string ACC98;
        internal string ACC99;
        internal string ACC100;
        internal string ACC101;
        internal string ACC102;
        internal string ACC103;
        internal string ACC104;
        internal string ACC105;
        internal string ACC106;
        internal string ACC107;
        internal string ACC108;
        internal string ACC109;
        internal string ACC110;
        internal string ACC111;
        internal string ACC112;
        internal string ACC113;
        internal string ACC114;
        internal string ACC115;
        internal string ACC116;
        internal string ACC117;
        internal string ACC118;
        internal string ACC119;
        internal string ACC120;
        internal string ACC121;
        internal string ACC122;
        internal string ACC123;
        internal string ACC124;
        internal string ACC125;
        internal string ACC126;
        internal string ACC127;
        internal string ACC128;
        internal string ACC129;
        internal string ACC130;
        internal string ACC131;
        internal string ACC132;
        internal string ACC133;
        internal string ACC134;
        internal string ACC135;
        internal string ACC136;
        internal string ACC137;
        internal string ACC138;
        internal string ACC139;
        internal string ACC140;
        internal string ACC141;
        internal string ACC142;
        internal string ACC143;
        internal string ACC144;
        internal string ACC145;
        internal string ACC146;
        internal string ACC147;
        internal string ACC148;
        internal string ACC149;
        internal string ACC150;
        internal string ACC151;
        internal string ACC152;
        internal string ACC153;
        internal string ACC154;
        internal string ACC155;
        internal string ACC156;
        internal string ACC157;
        internal string ACC158;
        internal string ACC159;
        internal string ACC160;
        internal string ACC161;
        internal string ACC162;
        internal string ACC163;
        internal string ACC164;
        internal string ACC165;
        internal string ACC166;
        internal string ACC167;
        internal string ACC168;
        internal string ACC169;
        internal string ACC170;
        internal string ACC171;
        internal string ACC172;
        internal string ACC173;
        internal string ACC174;
        internal string ACC175;
        internal string ACC176;
        internal string ACC177;
        internal string ACC178;
        internal string ACC179;
        internal string ACC180;
        internal string ACC181;
        internal string ACC182;
        internal string ACC183;
        internal string ACC184;
        internal string ACC185;
        internal string ACC186;
        internal string ACC187;
        internal string ACC188;
        internal string ACC189;
        internal string ACC190;
        internal string ACC191;
        internal string ACC192;
        internal string ACC193;
        internal string ACC194;
        internal string ACC195;
        internal string ACC196;
        internal string ACC197;
        internal string ACC198;
        internal string ACC199;
        internal string ACC200;
        internal string ACC201;
        internal string ACC202;
        internal string ACC203;
        internal string ACC204;
        internal string ACC205;
        internal string ACC206;
        internal string ACC207;
        internal string ACC208;
        internal string ACC209;
        internal string ACC210;
        internal string ACC211;
        internal string ACC212;
        internal string ACC213;
        internal string ACC214;
        internal string ACC215;
        internal string ACC216;
        internal string ACC217;
        internal string ACC218;
        internal string ACC219;
        internal string ACC220;
        internal string ACC221;
        internal string ACC222;
        internal string ACC223;
        internal string ACC224;
        internal string ACC225;
        internal string ACC226;
        internal string ACC227;
        internal string ACC228;
        internal string ACC229;
        internal string ACC230;
        internal string ACC231;
        internal string ACC232;
        internal string ACC233;
        internal string ACC234;
        internal string ACC235;
        internal string ACC236;
        internal string ACC237;
        internal string ACC238;
        internal string ACC239;
        internal string ACC240;
        internal string ACC241;
        internal string ACC242;
        internal string ACC243;
        internal string ACC244;
        internal string ACC245;
        internal string ACC246;
        internal string ACC247;
        internal string ACC248;
        internal string ACC249;
        internal string ACC250;
        internal string ACC251;
        internal string ACC252;
        internal string ACC253;
        internal string ACC254;
        internal string ACC255;
        internal string ACC256;
        internal string ACC257;
        internal string ACC258;
        internal string ACC259;
        internal string ACC260;
        internal string ACC261;
        internal string ACC262;
        internal string ACC263;
        internal string ACC264;
        internal string ACC265;
        internal string ACC266;
        internal string ACC267;
        internal string ACC268;
        internal string ACC269;
        internal string ACC270;
        internal string ACC271;
        internal string ACC272;
        internal string ACC273;
        internal string ACC274;
        internal string ACC275;
        internal string ACC276;
        internal string ACC277;
        internal string ACC278;
        internal string ACC279;
        internal string ACC280;
        internal string ACC281;
        internal string ACC282;
        internal string ACC283;
        internal string ACC284;
        internal string ACC285;
        internal string ACC286;
        internal string ACC287;
        internal string ACC288;
        internal string ACC289;
        internal string ACC290;
        internal string ACC291;
        internal string ACC292;
        internal string ACC293;
        internal string ACC294;
        internal string ACC295;
        internal string ACC296;
        internal string ACC297;
        internal string ACC298;
        internal string ACC299;
        internal string ACC300;
     
        //↓建筑特色对应图片定义
        internal Rectangle AC1Client;
        internal Rectangle AC2Client;
        internal Rectangle AC3Client;
        internal Rectangle AC4Client;
        internal Rectangle AC5Client;
        internal Rectangle AC6Client;
        internal Rectangle AC7Client;
        internal Rectangle AC8Client;
        internal Rectangle AC9Client;
        internal Rectangle AC10Client;
        internal Rectangle AC11Client;
        internal Rectangle AC12Client;
        internal Rectangle AC13Client;
        internal Rectangle AC14Client;
        internal Rectangle AC15Client;
        internal Rectangle AC16Client;
        internal Rectangle AC17Client;
        internal Rectangle AC18Client;
        internal Rectangle AC19Client;
        internal Rectangle AC20Client;
        internal Rectangle AC21Client;
        internal Rectangle AC22Client;
        internal Rectangle AC23Client;
        internal Rectangle AC24Client;
        internal Rectangle AC25Client;
        internal Rectangle AC26Client;

        internal Texture2D C1Texture;
        internal Texture2D C2Texture;
        internal Texture2D C3Texture;
        internal Texture2D C4Texture;
        internal Texture2D C5Texture;
        internal Texture2D C6Texture;
        internal Texture2D C7Texture;
        internal Texture2D C8Texture;
        internal Texture2D C9Texture;
        internal Texture2D C10Texture;
        internal Texture2D C11Texture;
        internal Texture2D C12Texture;
        internal Texture2D C13Texture;
        internal Texture2D C14Texture;
        internal Texture2D C15Texture;
        internal Texture2D C16Texture;
        internal Texture2D C17Texture;
        internal Texture2D C18Texture;
        internal Texture2D C19Texture;
        internal Texture2D C20Texture;
        internal Texture2D C21Texture;
        internal Texture2D C22Texture;
        internal Texture2D C23Texture;
        internal Texture2D C24Texture;
        internal Texture2D C25Texture;
        internal Texture2D C26Texture;


        internal Texture2D AC1Texture;
        internal Texture2D AC2Texture;
        internal Texture2D AC3Texture;
        internal Texture2D AC4Texture;
        internal Texture2D AC5Texture;
        internal Texture2D AC6Texture;
        internal Texture2D AC7Texture;
        internal Texture2D AC8Texture;
        internal Texture2D AC9Texture;
        internal Texture2D AC10Texture;
        internal Texture2D AC11Texture;
        internal Texture2D AC12Texture;
        internal Texture2D AC13Texture;
        internal Texture2D AC14Texture;
        internal Texture2D AC15Texture;
        internal Texture2D AC16Texture;
        internal Texture2D AC17Texture;
        internal Texture2D AC18Texture;
        internal Texture2D AC19Texture;
        internal Texture2D AC20Texture;
        internal Texture2D AC21Texture;
        internal Texture2D AC22Texture;
        internal Texture2D AC23Texture;
        internal Texture2D AC24Texture;
        internal Texture2D AC25Texture;
        internal Texture2D AC26Texture;

        internal Texture2D ACC1Texture;
        internal Texture2D ACC2Texture;
        internal Texture2D ACC3Texture;
        internal Texture2D ACC4Texture;
        internal Texture2D ACC5Texture;
        internal Texture2D ACC6Texture;
        internal Texture2D ACC7Texture;
        internal Texture2D ACC8Texture;
        internal Texture2D ACC9Texture;
        internal Texture2D ACC10Texture;
        internal Texture2D ACC11Texture;
        internal Texture2D ACC12Texture;
        internal Texture2D ACC13Texture;
        internal Texture2D ACC14Texture;
        internal Texture2D ACC15Texture;
        internal Texture2D ACC16Texture;
        internal Texture2D ACC17Texture;
        internal Texture2D ACC18Texture;
        internal Texture2D ACC19Texture;
        internal Texture2D ACC20Texture;
        internal Texture2D ACC21Texture;
        internal Texture2D ACC22Texture;
        internal Texture2D ACC23Texture;
        internal Texture2D ACC24Texture;
        internal Texture2D ACC25Texture;
        internal Texture2D ACC26Texture;
        internal Texture2D ACC27Texture;
        internal Texture2D ACC28Texture;
        internal Texture2D ACC29Texture;
        internal Texture2D ACC30Texture;
        internal Texture2D ACC31Texture;
        internal Texture2D ACC32Texture;
        internal Texture2D ACC33Texture;
        internal Texture2D ACC34Texture;
        internal Texture2D ACC35Texture;
        internal Texture2D ACC36Texture;
        internal Texture2D ACC37Texture;
        internal Texture2D ACC38Texture;
        internal Texture2D ACC39Texture;
        internal Texture2D ACC40Texture;
        internal Texture2D ACC41Texture;
        internal Texture2D ACC42Texture;
        internal Texture2D ACC43Texture;
        internal Texture2D ACC44Texture;
        internal Texture2D ACC45Texture;
        internal Texture2D ACC46Texture;
        internal Texture2D ACC47Texture;
        internal Texture2D ACC48Texture;
        internal Texture2D ACC49Texture;
        internal Texture2D ACC50Texture;
        internal Texture2D ACC51Texture;
        internal Texture2D ACC52Texture;
        internal Texture2D ACC53Texture;
        internal Texture2D ACC54Texture;
        internal Texture2D ACC55Texture;
        internal Texture2D ACC56Texture;
        internal Texture2D ACC57Texture;
        internal Texture2D ACC58Texture;
        internal Texture2D ACC59Texture;
        internal Texture2D ACC60Texture;
        internal Texture2D ACC61Texture;
        internal Texture2D ACC62Texture;
        internal Texture2D ACC63Texture;
        internal Texture2D ACC64Texture;
        internal Texture2D ACC65Texture;
        internal Texture2D ACC66Texture;
        internal Texture2D ACC67Texture;
        internal Texture2D ACC68Texture;
        internal Texture2D ACC69Texture;
        internal Texture2D ACC70Texture;
        internal Texture2D ACC71Texture;
        internal Texture2D ACC72Texture;
        internal Texture2D ACC73Texture;
        internal Texture2D ACC74Texture;
        internal Texture2D ACC75Texture;
        internal Texture2D ACC76Texture;
        internal Texture2D ACC77Texture;
        internal Texture2D ACC78Texture;
        internal Texture2D ACC79Texture;
        internal Texture2D ACC80Texture;
        internal Texture2D ACC81Texture;
        internal Texture2D ACC82Texture;
        internal Texture2D ACC83Texture;
        internal Texture2D ACC84Texture;
        internal Texture2D ACC85Texture;
        internal Texture2D ACC86Texture;
        internal Texture2D ACC87Texture;
        internal Texture2D ACC88Texture;
        internal Texture2D ACC89Texture;
        internal Texture2D ACC90Texture;
        internal Texture2D ACC91Texture;
        internal Texture2D ACC92Texture;
        internal Texture2D ACC93Texture;
        internal Texture2D ACC94Texture;
        internal Texture2D ACC95Texture;
        internal Texture2D ACC96Texture;
        internal Texture2D ACC97Texture;
        internal Texture2D ACC98Texture;
        internal Texture2D ACC99Texture;
        internal Texture2D ACC100Texture;
        internal Texture2D ACC101Texture;
        internal Texture2D ACC102Texture;
        internal Texture2D ACC103Texture;
        internal Texture2D ACC104Texture;
        internal Texture2D ACC105Texture;
        internal Texture2D ACC106Texture;
        internal Texture2D ACC107Texture;
        internal Texture2D ACC108Texture;
        internal Texture2D ACC109Texture;
        internal Texture2D ACC110Texture;
        internal Texture2D ACC111Texture;
        internal Texture2D ACC112Texture;
        internal Texture2D ACC113Texture;
        internal Texture2D ACC114Texture;
        internal Texture2D ACC115Texture;
        internal Texture2D ACC116Texture;
        internal Texture2D ACC117Texture;
        internal Texture2D ACC118Texture;
        internal Texture2D ACC119Texture;
        internal Texture2D ACC120Texture;
        internal Texture2D ACC121Texture;
        internal Texture2D ACC122Texture;
        internal Texture2D ACC123Texture;
        internal Texture2D ACC124Texture;
        internal Texture2D ACC125Texture;
        internal Texture2D ACC126Texture;
        internal Texture2D ACC127Texture;
        internal Texture2D ACC128Texture;
        internal Texture2D ACC129Texture;
        internal Texture2D ACC130Texture;
        internal Texture2D ACC131Texture;
        internal Texture2D ACC132Texture;
        internal Texture2D ACC133Texture;
        internal Texture2D ACC134Texture;
        internal Texture2D ACC135Texture;
        internal Texture2D ACC136Texture;
        internal Texture2D ACC137Texture;
        internal Texture2D ACC138Texture;
        internal Texture2D ACC139Texture;
        internal Texture2D ACC140Texture;
        internal Texture2D ACC141Texture;
        internal Texture2D ACC142Texture;
        internal Texture2D ACC143Texture;
        internal Texture2D ACC144Texture;
        internal Texture2D ACC145Texture;
        internal Texture2D ACC146Texture;
        internal Texture2D ACC147Texture;
        internal Texture2D ACC148Texture;
        internal Texture2D ACC149Texture;
        internal Texture2D ACC150Texture;
        internal Texture2D ACC151Texture;
        internal Texture2D ACC152Texture;
        internal Texture2D ACC153Texture;
        internal Texture2D ACC154Texture;
        internal Texture2D ACC155Texture;
        internal Texture2D ACC156Texture;
        internal Texture2D ACC157Texture;
        internal Texture2D ACC158Texture;
        internal Texture2D ACC159Texture;
        internal Texture2D ACC160Texture;
        internal Texture2D ACC161Texture;
        internal Texture2D ACC162Texture;
        internal Texture2D ACC163Texture;
        internal Texture2D ACC164Texture;
        internal Texture2D ACC165Texture;
        internal Texture2D ACC166Texture;
        internal Texture2D ACC167Texture;
        internal Texture2D ACC168Texture;
        internal Texture2D ACC169Texture;
        internal Texture2D ACC170Texture;
        internal Texture2D ACC171Texture;
        internal Texture2D ACC172Texture;
        internal Texture2D ACC173Texture;
        internal Texture2D ACC174Texture;
        internal Texture2D ACC175Texture;
        internal Texture2D ACC176Texture;
        internal Texture2D ACC177Texture;
        internal Texture2D ACC178Texture;
        internal Texture2D ACC179Texture;
        internal Texture2D ACC180Texture;
        internal Texture2D ACC181Texture;
        internal Texture2D ACC182Texture;
        internal Texture2D ACC183Texture;
        internal Texture2D ACC184Texture;
        internal Texture2D ACC185Texture;
        internal Texture2D ACC186Texture;
        internal Texture2D ACC187Texture;
        internal Texture2D ACC188Texture;
        internal Texture2D ACC189Texture;
        internal Texture2D ACC190Texture;
        internal Texture2D ACC191Texture;
        internal Texture2D ACC192Texture;
        internal Texture2D ACC193Texture;
        internal Texture2D ACC194Texture;
        internal Texture2D ACC195Texture;
        internal Texture2D ACC196Texture;
        internal Texture2D ACC197Texture;
        internal Texture2D ACC198Texture;
        internal Texture2D ACC199Texture;
        internal Texture2D ACC200Texture;
        internal Texture2D ACC201Texture;
        internal Texture2D ACC202Texture;
        internal Texture2D ACC203Texture;
        internal Texture2D ACC204Texture;
        internal Texture2D ACC205Texture;
        internal Texture2D ACC206Texture;
        internal Texture2D ACC207Texture;
        internal Texture2D ACC208Texture;
        internal Texture2D ACC209Texture;
        internal Texture2D ACC210Texture;
        internal Texture2D ACC211Texture;
        internal Texture2D ACC212Texture;
        internal Texture2D ACC213Texture;
        internal Texture2D ACC214Texture;
        internal Texture2D ACC215Texture;
        internal Texture2D ACC216Texture;
        internal Texture2D ACC217Texture;
        internal Texture2D ACC218Texture;
        internal Texture2D ACC219Texture;
        internal Texture2D ACC220Texture;
        internal Texture2D ACC221Texture;
        internal Texture2D ACC222Texture;
        internal Texture2D ACC223Texture;
        internal Texture2D ACC224Texture;
        internal Texture2D ACC225Texture;
        internal Texture2D ACC226Texture;
        internal Texture2D ACC227Texture;
        internal Texture2D ACC228Texture;
        internal Texture2D ACC229Texture;
        internal Texture2D ACC230Texture;
        internal Texture2D ACC231Texture;
        internal Texture2D ACC232Texture;
        internal Texture2D ACC233Texture;
        internal Texture2D ACC234Texture;
        internal Texture2D ACC235Texture;
        internal Texture2D ACC236Texture;
        internal Texture2D ACC237Texture;
        internal Texture2D ACC238Texture;
        internal Texture2D ACC239Texture;
        internal Texture2D ACC240Texture;
        internal Texture2D ACC241Texture;
        internal Texture2D ACC242Texture;
        internal Texture2D ACC243Texture;
        internal Texture2D ACC244Texture;
        internal Texture2D ACC245Texture;
        internal Texture2D ACC246Texture;
        internal Texture2D ACC247Texture;
        internal Texture2D ACC248Texture;
        internal Texture2D ACC249Texture;
        internal Texture2D ACC250Texture;
        internal Texture2D ACC251Texture;
        internal Texture2D ACC252Texture;
        internal Texture2D ACC253Texture;
        internal Texture2D ACC254Texture;
        internal Texture2D ACC255Texture;
        internal Texture2D ACC256Texture;
        internal Texture2D ACC257Texture;
        internal Texture2D ACC258Texture;
        internal Texture2D ACC259Texture;
        internal Texture2D ACC260Texture;
        internal Texture2D ACC261Texture;
        internal Texture2D ACC262Texture;
        internal Texture2D ACC263Texture;
        internal Texture2D ACC264Texture;
        internal Texture2D ACC265Texture;
        internal Texture2D ACC266Texture;
        internal Texture2D ACC267Texture;
        internal Texture2D ACC268Texture;
        internal Texture2D ACC269Texture;
        internal Texture2D ACC270Texture;
        internal Texture2D ACC271Texture;
        internal Texture2D ACC272Texture;
        internal Texture2D ACC273Texture;
        internal Texture2D ACC274Texture;
        internal Texture2D ACC275Texture;
        internal Texture2D ACC276Texture;
        internal Texture2D ACC277Texture;
        internal Texture2D ACC278Texture;
        internal Texture2D ACC279Texture;
        internal Texture2D ACC280Texture;
        internal Texture2D ACC281Texture;
        internal Texture2D ACC282Texture;
        internal Texture2D ACC283Texture;
        internal Texture2D ACC284Texture;
        internal Texture2D ACC285Texture;
        internal Texture2D ACC286Texture;
        internal Texture2D ACC287Texture;
        internal Texture2D ACC288Texture;
        internal Texture2D ACC289Texture;
        internal Texture2D ACC290Texture;
        internal Texture2D ACC291Texture;
        internal Texture2D ACC292Texture;
        internal Texture2D ACC293Texture;
        internal Texture2D ACC294Texture;
        internal Texture2D ACC295Texture;
        internal Texture2D ACC296Texture;
        internal Texture2D ACC297Texture;
        internal Texture2D ACC298Texture;
        internal Texture2D ACC299Texture;
        internal Texture2D ACC300Texture;


        //↓进度条相关定义
        internal Texture2D ArmyBarTexture;
        internal Texture2D Army1BarTexture;
        internal Texture2D Army2BarTexture;
        internal Texture2D Army3BarTexture;
        internal Texture2D Army4BarTexture;
        internal Texture2D Army5BarTexture;
        internal Texture2D Army6BarTexture;
        internal Rectangle ArmyBarClient;

        internal Texture2D DominationBarTexture;
        internal Texture2D Domination1BarTexture;
        internal Texture2D Domination2BarTexture;
        internal Texture2D Domination3BarTexture;
        internal Texture2D Domination4BarTexture;
        internal Texture2D Domination5BarTexture;
        internal Texture2D Domination6BarTexture;
        internal Rectangle DominationBarClient;

        internal Texture2D EnduranceBarTexture;
        internal Texture2D Endurance1BarTexture;
        internal Texture2D Endurance2BarTexture;
        internal Texture2D Endurance3BarTexture;
        internal Texture2D Endurance4BarTexture;
        internal Texture2D Endurance5BarTexture;
        internal Texture2D Endurance6BarTexture;
        internal Rectangle EnduranceBarClient;

        internal Texture2D AgricultureBarTexture;
        internal Texture2D Agriculture1BarTexture;
        internal Texture2D Agriculture2BarTexture;
        internal Texture2D Agriculture3BarTexture;
        internal Texture2D Agriculture4BarTexture;
        internal Texture2D Agriculture5BarTexture;
        internal Texture2D Agriculture6BarTexture;
        internal Rectangle AgricultureBarClient;

        internal Texture2D CommerceBarTexture;
        internal Texture2D Commerce1BarTexture;
        internal Texture2D Commerce2BarTexture;
        internal Texture2D Commerce3BarTexture;
        internal Texture2D Commerce4BarTexture;
        internal Texture2D Commerce5BarTexture;
        internal Texture2D Commerce6BarTexture;
        internal Rectangle CommerceBarClient;

        internal Texture2D TechnologyBarTexture;
        internal Texture2D Technology1BarTexture;
        internal Texture2D Technology2BarTexture;
        internal Texture2D Technology3BarTexture;
        internal Texture2D Technology4BarTexture;
        internal Texture2D Technology5BarTexture;
        internal Texture2D Technology6BarTexture;
        internal Rectangle TechnologyBarClient;

        internal Texture2D MoraleBarTexture;
        internal Texture2D Morale1BarTexture;
        internal Texture2D Morale2BarTexture;
        internal Texture2D Morale3BarTexture;
        internal Texture2D Morale4BarTexture;
        internal Texture2D Morale5BarTexture;
        internal Texture2D Morale6BarTexture;
        internal Rectangle MoraleBarClient;

        internal Texture2D FacilityCountBarTexture;
        internal Texture2D FacilityCount1BarTexture;
        internal Texture2D FacilityCount2BarTexture;
        internal Texture2D FacilityCount3BarTexture;
        internal Texture2D FacilityCount4BarTexture;
        internal Texture2D FacilityCount5BarTexture;
        internal Texture2D FacilityCount6BarTexture;
        internal Rectangle FacilityCountBarClient;

  
        //
        bool ACC1OK = false;
        bool ACC2OK = false;
        bool ACC3OK = false;
        bool ACC4OK = false;
        bool ACC5OK = false;
        bool ACC6OK = false;
        bool ACC7OK = false;
        bool ACC8OK = false;
        bool ACC9OK = false;
        bool ACC10OK = false;
        bool ACC11OK = false;
        bool ACC12OK = false;
        bool ACC13OK = false;
        bool ACC14OK = false;
        bool ACC15OK = false;
        bool ACC16OK = false;
        bool ACC17OK = false;
        bool ACC18OK = false;
        bool ACC19OK = false;
        bool ACC20OK = false;
        bool ACC21OK = false;
        bool ACC22OK = false;
        bool ACC23OK = false;
        bool ACC24OK = false;
        bool ACC25OK = false;
        bool ACC26OK = false;
        bool ACC27OK = false;
        bool ACC28OK = false;
        bool ACC29OK = false;
        bool ACC30OK = false;
        bool ACC31OK = false;
        bool ACC32OK = false;
        bool ACC33OK = false;
        bool ACC34OK = false;
        bool ACC35OK = false;
        bool ACC36OK = false;
        bool ACC37OK = false;
        bool ACC38OK = false;
        bool ACC39OK = false;
        bool ACC40OK = false;
        bool ACC41OK = false;
        bool ACC42OK = false;
        bool ACC43OK = false;
        bool ACC44OK = false;
        bool ACC45OK = false;
        bool ACC46OK = false;
        bool ACC47OK = false;
        bool ACC48OK = false;
        bool ACC49OK = false;
        bool ACC50OK = false;
        bool ACC51OK = false;
        bool ACC52OK = false;
        bool ACC53OK = false;
        bool ACC54OK = false;
        bool ACC55OK = false;
        bool ACC56OK = false;
        bool ACC57OK = false;
        bool ACC58OK = false;
        bool ACC59OK = false;
        bool ACC60OK = false;
        bool ACC61OK = false;
        bool ACC62OK = false;
        bool ACC63OK = false;
        bool ACC64OK = false;
        bool ACC65OK = false;
        bool ACC66OK = false;
        bool ACC67OK = false;
        bool ACC68OK = false;
        bool ACC69OK = false;
        bool ACC70OK = false;
        bool ACC71OK = false;
        bool ACC72OK = false;
        bool ACC73OK = false;
        bool ACC74OK = false;
        bool ACC75OK = false;
        bool ACC76OK = false;
        bool ACC77OK = false;
        bool ACC78OK = false;
        bool ACC79OK = false;
        bool ACC80OK = false;
        bool ACC81OK = false;
        bool ACC82OK = false;
        bool ACC83OK = false;
        bool ACC84OK = false;
        bool ACC85OK = false;
        bool ACC86OK = false;
        bool ACC87OK = false;
        bool ACC88OK = false;
        bool ACC89OK = false;
        bool ACC90OK = false;
        bool ACC91OK = false;
        bool ACC92OK = false;
        bool ACC93OK = false;
        bool ACC94OK = false;
        bool ACC95OK = false;
        bool ACC96OK = false;
        bool ACC97OK = false;
        bool ACC98OK = false;
        bool ACC99OK = false;
        bool ACC100OK = false;
        bool ACC101OK = false;
        bool ACC102OK = false;
        bool ACC103OK = false;
        bool ACC104OK = false;
        bool ACC105OK = false;
        bool ACC106OK = false;
        bool ACC107OK = false;
        bool ACC108OK = false;
        bool ACC109OK = false;
        bool ACC110OK = false;
        bool ACC111OK = false;
        bool ACC112OK = false;
        bool ACC113OK = false;
        bool ACC114OK = false;
        bool ACC115OK = false;
        bool ACC116OK = false;
        bool ACC117OK = false;
        bool ACC118OK = false;
        bool ACC119OK = false;
        bool ACC120OK = false;
        bool ACC121OK = false;
        bool ACC122OK = false;
        bool ACC123OK = false;
        bool ACC124OK = false;
        bool ACC125OK = false;
        bool ACC126OK = false;
        bool ACC127OK = false;
        bool ACC128OK = false;
        bool ACC129OK = false;
        bool ACC130OK = false;
        bool ACC131OK = false;
        bool ACC132OK = false;
        bool ACC133OK = false;
        bool ACC134OK = false;
        bool ACC135OK = false;
        bool ACC136OK = false;
        bool ACC137OK = false;
        bool ACC138OK = false;
        bool ACC139OK = false;
        bool ACC140OK = false;
        bool ACC141OK = false;
        bool ACC142OK = false;
        bool ACC143OK = false;
        bool ACC144OK = false;
        bool ACC145OK = false;
        bool ACC146OK = false;
        bool ACC147OK = false;
        bool ACC148OK = false;
        bool ACC149OK = false;
        bool ACC150OK = false;
        bool ACC151OK = false;
        bool ACC152OK = false;
        bool ACC153OK = false;
        bool ACC154OK = false;
        bool ACC155OK = false;
        bool ACC156OK = false;
        bool ACC157OK = false;
        bool ACC158OK = false;
        bool ACC159OK = false;
        bool ACC160OK = false;
        bool ACC161OK = false;
        bool ACC162OK = false;
        bool ACC163OK = false;
        bool ACC164OK = false;
        bool ACC165OK = false;
        bool ACC166OK = false;
        bool ACC167OK = false;
        bool ACC168OK = false;
        bool ACC169OK = false;
        bool ACC170OK = false;
        bool ACC171OK = false;
        bool ACC172OK = false;
        bool ACC173OK = false;
        bool ACC174OK = false;
        bool ACC175OK = false;
        bool ACC176OK = false;
        bool ACC177OK = false;
        bool ACC178OK = false;
        bool ACC179OK = false;
        bool ACC180OK = false;
        bool ACC181OK = false;
        bool ACC182OK = false;
        bool ACC183OK = false;
        bool ACC184OK = false;
        bool ACC185OK = false;
        bool ACC186OK = false;
        bool ACC187OK = false;
        bool ACC188OK = false;
        bool ACC189OK = false;
        bool ACC190OK = false;
        bool ACC191OK = false;
        bool ACC192OK = false;
        bool ACC193OK = false;
        bool ACC194OK = false;
        bool ACC195OK = false;
        bool ACC196OK = false;
        bool ACC197OK = false;
        bool ACC198OK = false;
        bool ACC199OK = false;
        bool ACC200OK = false;
        bool ACC201OK = false;
        bool ACC202OK = false;
        bool ACC203OK = false;
        bool ACC204OK = false;
        bool ACC205OK = false;
        bool ACC206OK = false;
        bool ACC207OK = false;
        bool ACC208OK = false;
        bool ACC209OK = false;
        bool ACC210OK = false;
        bool ACC211OK = false;
        bool ACC212OK = false;
        bool ACC213OK = false;
        bool ACC214OK = false;
        bool ACC215OK = false;
        bool ACC216OK = false;
        bool ACC217OK = false;
        bool ACC218OK = false;
        bool ACC219OK = false;
        bool ACC220OK = false;
        bool ACC221OK = false;
        bool ACC222OK = false;
        bool ACC223OK = false;
        bool ACC224OK = false;
        bool ACC225OK = false;
        bool ACC226OK = false;
        bool ACC227OK = false;
        bool ACC228OK = false;
        bool ACC229OK = false;
        bool ACC230OK = false;
        bool ACC231OK = false;
        bool ACC232OK = false;
        bool ACC233OK = false;
        bool ACC234OK = false;
        bool ACC235OK = false;
        bool ACC236OK = false;
        bool ACC237OK = false;
        bool ACC238OK = false;
        bool ACC239OK = false;
        bool ACC240OK = false;
        bool ACC241OK = false;
        bool ACC242OK = false;
        bool ACC243OK = false;
        bool ACC244OK = false;
        bool ACC245OK = false;
        bool ACC246OK = false;
        bool ACC247OK = false;
        bool ACC248OK = false;
        bool ACC249OK = false;
        bool ACC250OK = false;
        bool ACC251OK = false;
        bool ACC252OK = false;
        bool ACC253OK = false;
        bool ACC254OK = false;
        bool ACC255OK = false;
        bool ACC256OK = false;
        bool ACC257OK = false;
        bool ACC258OK = false;
        bool ACC259OK = false;
        bool ACC260OK = false;
        bool ACC261OK = false;
        bool ACC262OK = false;
        bool ACC263OK = false;
        bool ACC264OK = false;
        bool ACC265OK = false;
        bool ACC266OK = false;
        bool ACC267OK = false;
        bool ACC268OK = false;
        bool ACC269OK = false;
        bool ACC270OK = false;
        bool ACC271OK = false;
        bool ACC272OK = false;
        bool ACC273OK = false;
        bool ACC274OK = false;
        bool ACC275OK = false;
        bool ACC276OK = false;
        bool ACC277OK = false;
        bool ACC278OK = false;
        bool ACC279OK = false;
        bool ACC280OK = false;
        bool ACC281OK = false;
        bool ACC282OK = false;
        bool ACC283OK = false;
        bool ACC284OK = false;
        bool ACC285OK = false;
        bool ACC286OK = false;
        bool ACC287OK = false;
        bool ACC288OK = false;
        bool ACC289OK = false;
        bool ACC290OK = false;
        bool ACC291OK = false;
        bool ACC292OK = false;
        bool ACC293OK = false;
        bool ACC294OK = false;
        bool ACC295OK = false;
        bool ACC296OK = false;
        bool ACC297OK = false;
        bool ACC298OK = false;
        bool ACC299OK = false;
        bool ACC300OK = false;




        //↓设施空间是否建成相关定义
        bool FA1 = false;
        bool FA2 = false;
        bool FA3 = false;
        bool FA4 = false;
        bool FA5 = false;
        bool FA6 = false;
        bool FA7 = false;
        bool FA8 = false;
        bool FA9 = false;
        bool FA10 = false;
        bool FA11 = false;
        bool FA12 = false;
        bool FA13 = false;
        bool FA14 = false;
        bool FA15 = false;
        bool FA16 = false;
        bool FA17 = false;
        bool FA18 = false;
        bool FA19 = false;
        bool FA20 = false;
        bool FA21 = false;
        bool FA22 = false;
        bool FA23 = false;
        bool FA24 = false;
        bool FA25 = false;
        bool FA26 = false;
        bool FA27 = false;
        bool FA28 = false;
        bool FB1 = false;
        bool FB2 = false;
        bool FB3 = false;
        bool FB4 = false;
        bool FB5 = false;
        bool FB6 = false;
        bool FB7 = false;
        bool FB8 = false;
        bool FB9 = false;
        bool FB10 = false;
        bool FB11 = false;
        bool FB12 = false;
        bool FB13 = false;
        bool FB14 = false;
        bool FB15 = false;
        bool FB16 = false;
        bool FB17 = false;
        bool FB18 = false;
        bool FB19 = false;
        bool FB20 = false;
        bool FB21 = false;
        bool FB22 = false;
        bool FB23 = false;
        bool FB24 = false;
        bool FB25 = false;
        bool FB26 = false;
        bool FB27 = false;
        bool FB28 = false;
        bool FC1 = false;
        bool FC2 = false;
        bool FC3 = false;
        bool FC4 = false;
        bool FC5 = false;
        bool FC6 = false;
        bool FC7 = false;
        bool FC8 = false;
        bool FC9 = false;
        bool FC10 = false;
        bool FC11 = false;
        bool FC12 = false;
        bool FC13 = false;
        bool FC14 = false;
        bool FC15 = false;
        bool FC16 = false;
        bool FC17 = false;
        bool FC18 = false;
        bool FC19 = false;
        bool FC20 = false;
        bool FC21 = false;
        bool FC22 = false;
        bool FC23 = false;
        bool FC24 = false;
        bool FC25 = false;
        bool FC26 = false;
        bool FC27 = false;
        bool FC28 = false;
        bool FD1 = false;
        bool FD2 = false;
        bool FD3 = false;
        bool FD4 = false;
        bool FD5 = false;
        bool FD6 = false;
        bool FD7 = false;
        bool FD8 = false;
        bool FD9 = false;
        bool FD10 = false;
        bool FD11 = false;
        bool FD12 = false;
        bool FD13 = false;
        bool FD14 = false;
        bool FD15 = false;
        bool FD16 = false;
        bool FD17 = false;
        bool FD18 = false;
        bool FD19 = false;
        bool FD20 = false;
        bool FD21 = false;
        bool FD22 = false;
        bool FD23 = false;
        bool FD24 = false;
        bool FD25 = false;
        bool FD26 = false;
        bool FD27 = false;
        bool FD28 = false;
        bool FE1 = false;
        bool FE2 = false;
        bool FE3 = false;
        bool FE4 = false;
        bool FE5 = false;
        bool FE6 = false;
        bool FE7 = false;
        bool FE8 = false;
        bool FE9 = false;
        bool FE10 = false;
        bool FE11 = false;
        bool FE12 = false;
        bool FE13 = false;
        bool FE14 = false;
        bool FE15 = false;
        bool FE16 = false;
        bool FE17 = false;
        bool FE18 = false;
        bool FE19 = false;
        bool FE20 = false;
        bool FE21 = false;
        bool FE22 = false;
        bool FE23 = false;
        bool FE24 = false;
        bool FE25 = false;
        bool FE26 = false;
        bool FE27 = false;
        bool FE28 = false;
        //设施数量
        int FAN1 = 0;
        int FAN2 = 0;
        int FAN3 = 0;
        int FAN4 = 0;
        int FAN5 = 0;
        int FAN6 = 0;
        int FAN7 = 0;
        int FAN8 = 0;
        int FAN9 = 0;
        int FAN10 = 0;
        int FAN11 = 0;
        int FAN12 = 0;
        int FAN13 = 0;
        int FAN14 = 0;
        int FAN15 = 0;
        int FAN16 = 0;
        int FAN17 = 0;
        int FAN18 = 0;
        int FAN19 = 0;
        int FAN20 = 0;
        int FAN21 = 0;
        int FAN22 = 0;
        int FAN23 = 0;
        int FAN24 = 0;
        int FAN25 = 0;
        int FAN26 = 0;
        int FAN27 = 0;
        int FAN28 = 0;
        int FBN1 = 0;
        int FBN2 = 0;
        int FBN3 = 0;
        int FBN4 = 0;
        int FBN5 = 0;
        int FBN6 = 0;
        int FBN7 = 0;
        int FBN8 = 0;
        int FBN9 = 0;
        int FBN10 = 0;
        int FBN11 = 0;
        int FBN12 = 0;
        int FBN13 = 0;
        int FBN14 = 0;
        int FBN15 = 0;
        int FBN16 = 0;
        int FBN17 = 0;
        int FBN18 = 0;
        int FBN19 = 0;
        int FBN20 = 0;
        int FBN21 = 0;
        int FBN22 = 0;
        int FBN23 = 0;
        int FBN24 = 0;
        int FBN25 = 0;
        int FBN26 = 0;
        int FBN27 = 0;
        int FBN28 = 0;
        int FCN1 = 0;
        int FCN2 = 0;
        int FCN3 = 0;
        int FCN4 = 0;
        int FCN5 = 0;
        int FCN6 = 0;
        int FCN7 = 0;
        int FCN8 = 0;
        int FCN9 = 0;
        int FCN10 = 0;
        int FCN11 = 0;
        int FCN12 = 0;
        int FCN13 = 0;
        int FCN14 = 0;
        int FCN15 = 0;
        int FCN16 = 0;
        int FCN17 = 0;
        int FCN18 = 0;
        int FCN19 = 0;
        int FCN20 = 0;
        int FCN21 = 0;
        int FCN22 = 0;
        int FCN23 = 0;
        int FCN24 = 0;
        int FCN25 = 0;
        int FCN26 = 0;
        int FCN27 = 0;
        int FCN28 = 0;
        int FDN1 = 0;
        int FDN2 = 0;
        int FDN3 = 0;
        int FDN4 = 0;
        int FDN5 = 0;
        int FDN6 = 0;
        int FDN7 = 0;
        int FDN8 = 0;
        int FDN9 = 0;
        int FDN10 = 0;
        int FDN11 = 0;
        int FDN12 = 0;
        int FDN13 = 0;
        int FDN14 = 0;
        int FDN15 = 0;
        int FDN16 = 0;
        int FDN17 = 0;
        int FDN18 = 0;
        int FDN19 = 0;
        int FDN20 = 0;
        int FDN21 = 0;
        int FDN22 = 0;
        int FDN23 = 0;
        int FDN24 = 0;
        int FDN25 = 0;
        int FDN26 = 0;
        int FDN27 = 0;
        int FDN28 = 0;
        int FEN1 = 0;
        int FEN2 = 0;
        int FEN3 = 0;
        int FEN4 = 0;
        int FEN5 = 0;
        int FEN6 = 0;
        int FEN7 = 0;
        int FEN8 = 0;
        int FEN9 = 0;
        int FEN10 = 0;
        int FEN11 = 0;
        int FEN12 = 0;
        int FEN13 = 0;
        int FEN14 = 0;
        int FEN15 = 0;
        int FEN16 = 0;
        int FEN17 = 0;
        int FEN18 = 0;
        int FEN19 = 0;
        int FEN20 = 0;
        int FEN21 = 0;
        int FEN22 = 0;
        int FEN23 = 0;
        int FEN24 = 0;
        int FEN25 = 0;
        int FEN26 = 0;
        int FEN27 = 0;
        int FEN28 = 0;

        float Bar1 = 0;
        float Bar2 = 0;
        float Bar3 = 0;
        float Bar4 = 0;
        float Bar5 = 0;
        float Bar6 = 0;
        float Bar7 = 0;
        float Bar8 = 0;

        bool FacilityIng = false;
        bool FacilityTexton = false;
        bool FacilityIngTexton = false;

        
        
        
        internal void Draw(SpriteBatch spriteBatch)
        {
            if (this.ShowingArchitecture != null)
            {
                spriteBatch.Draw(this.BackgroundTexture, this.BackgroundDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.2f);
                try
                {
                       if (Switch1 == "1")
                        {
                            spriteBatch.Draw(this.ArchitectureButtonTexture, this.ArchitectureButtonDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.18f);
                            spriteBatch.Draw(this.ArchitecturePressedTexture, this.ArchitecturePressedDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.18f);
                        }
                        if (Switch4 == "1" || Switch5 == "1" || Switch6 == "1" || Switch7 == "1" || Switch8 == "1")
                        {
                            spriteBatch.Draw(this.TextBackgroundTexture, this.TextBackgroundDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.189f);
                            spriteBatch.Draw(this.FacilityforIngTexture, this.FacilityforIngDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.189f);
                           
                         }
                        if (Switch2 == "1")
                        {
                            spriteBatch.Draw(this.ArchitectureKindButtonTexture, this.ArchitectureKindButtonDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.18f);
                            spriteBatch.Draw(this.ArchitectureKindPressedTexture, this.ArchitectureKindPressedDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.18f);
                            spriteBatch.Draw(this.BackgroundforArchitectureTexture, this.BackgroundforArchitectureDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.ACBackgroundTexture, this.ACBackgroundDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.191f);
                            if (Switch9 == "1")
                            {
                                spriteBatch.Draw(this.AKBackgroundTexture, this.AKBackgroundDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            }
                            if (Switch10 == "1")
                            {
                                spriteBatch.Draw(this.AIDTexture, this.AIDDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.189f);
                            }
                            if (Switch12 == "1")
                            {
                                spriteBatch.Draw(this.ArmyBarTexture, this.ArmyBarDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                                spriteBatch.Draw(this.DominationBarTexture, this.DominationBarDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                                spriteBatch.Draw(this.EnduranceBarTexture, this.EnduranceBarDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                                spriteBatch.Draw(this.AgricultureBarTexture, this.AgricultureBarDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                                spriteBatch.Draw(this.CommerceBarTexture, this.CommerceBarDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                                spriteBatch.Draw(this.TechnologyBarTexture, this.TechnologyBarDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                                spriteBatch.Draw(this.MoraleBarTexture, this.MoraleBarDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.051f);
                                spriteBatch.Draw(this.FacilityCountBarTexture, this.FacilityCountBarDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            }
                            if (Switch11 == "1")
                            {
                                spriteBatch.Draw(this.C1Texture, this.AC1DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                                spriteBatch.Draw(this.C2Texture, this.AC2DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                                spriteBatch.Draw(this.C3Texture, this.AC3DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                                spriteBatch.Draw(this.C4Texture, this.AC4DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                                spriteBatch.Draw(this.C5Texture, this.AC5DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                                spriteBatch.Draw(this.C6Texture, this.AC6DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                                spriteBatch.Draw(this.C7Texture, this.AC7DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                                spriteBatch.Draw(this.C8Texture, this.AC8DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                                spriteBatch.Draw(this.C9Texture, this.AC9DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                                spriteBatch.Draw(this.C10Texture, this.AC10DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                                spriteBatch.Draw(this.C11Texture, this.AC11DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                                spriteBatch.Draw(this.C12Texture, this.AC12DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                                spriteBatch.Draw(this.C13Texture, this.AC13DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                                spriteBatch.Draw(this.C14Texture, this.AC14DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                                spriteBatch.Draw(this.C15Texture, this.AC15DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                                spriteBatch.Draw(this.C16Texture, this.AC16DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                                spriteBatch.Draw(this.C17Texture, this.AC17DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                                spriteBatch.Draw(this.C18Texture, this.AC18DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                                spriteBatch.Draw(this.C19Texture, this.AC19DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                                spriteBatch.Draw(this.C20Texture, this.AC20DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                                spriteBatch.Draw(this.C21Texture, this.AC21DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                                spriteBatch.Draw(this.C22Texture, this.AC22DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                                spriteBatch.Draw(this.C23Texture, this.AC23DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                                spriteBatch.Draw(this.C24Texture, this.AC24DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                                spriteBatch.Draw(this.C25Texture, this.AC25DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                                spriteBatch.Draw(this.C26Texture, this.AC26DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                                
                            }
                        }
                        if (Switch4 == "1")
                        {

                            spriteBatch.Draw(this.FacilityforAButtonTexture, this.FacilityforAButtonDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.18f);
                            spriteBatch.Draw(this.FacilityforAPressedTexture, this.FacilityforAPressedDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.18f);
                            spriteBatch.Draw(this.FABackgroundTexture, this.FABackgroundDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.191f);
                            spriteBatch.Draw(this.FacilityforA1Texture, this.FacilityforA1DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforA2Texture, this.FacilityforA2DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforA3Texture, this.FacilityforA3DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforA4Texture, this.FacilityforA4DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforA5Texture, this.FacilityforA5DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforA6Texture, this.FacilityforA6DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforA7Texture, this.FacilityforA7DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforA8Texture, this.FacilityforA8DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforA9Texture, this.FacilityforA9DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforA10Texture, this.FacilityforA10DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforA11Texture, this.FacilityforA11DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforA12Texture, this.FacilityforA12DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforA13Texture, this.FacilityforA13DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforA14Texture, this.FacilityforA14DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforA15Texture, this.FacilityforA15DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforA16Texture, this.FacilityforA16DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforA17Texture, this.FacilityforA17DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforA18Texture, this.FacilityforA18DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforA19Texture, this.FacilityforA19DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforA20Texture, this.FacilityforA20DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforA21Texture, this.FacilityforA21DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforA22Texture, this.FacilityforA22DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforA23Texture, this.FacilityforA23DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforA24Texture, this.FacilityforA24DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforA25Texture, this.FacilityforA25DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforA26Texture, this.FacilityforA26DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforA27Texture, this.FacilityforA27DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforA28Texture, this.FacilityforA28DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                        }
                        if (Switch5 == "1")
                        {
                            spriteBatch.Draw(this.FacilityforBButtonTexture, this.FacilityforBButtonDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.18f);
                            spriteBatch.Draw(this.FacilityforBPressedTexture, this.FacilityforBPressedDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.18f);
                            spriteBatch.Draw(this.FBBackgroundTexture, this.FBBackgroundDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.191f);
                            spriteBatch.Draw(this.FacilityforB1Texture, this.FacilityforB1DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforB2Texture, this.FacilityforB2DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforB3Texture, this.FacilityforB3DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforB4Texture, this.FacilityforB4DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforB5Texture, this.FacilityforB5DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforB6Texture, this.FacilityforB6DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforB7Texture, this.FacilityforB7DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforB8Texture, this.FacilityforB8DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforB9Texture, this.FacilityforB9DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforB10Texture, this.FacilityforB10DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforB11Texture, this.FacilityforB11DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforB12Texture, this.FacilityforB12DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforB13Texture, this.FacilityforB13DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforB14Texture, this.FacilityforB14DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforB15Texture, this.FacilityforB15DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforB16Texture, this.FacilityforB16DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforB17Texture, this.FacilityforB17DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforB18Texture, this.FacilityforB18DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforB19Texture, this.FacilityforB19DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforB20Texture, this.FacilityforB20DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforB21Texture, this.FacilityforB21DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforB22Texture, this.FacilityforB22DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforB23Texture, this.FacilityforB23DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforB24Texture, this.FacilityforB24DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforB25Texture, this.FacilityforB25DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforB26Texture, this.FacilityforB26DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforB27Texture, this.FacilityforB27DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforB28Texture, this.FacilityforB28DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                        }
                        if (Switch6 == "1")
                        {
                            spriteBatch.Draw(this.FacilityforCButtonTexture, this.FacilityforCButtonDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.18f);
                            spriteBatch.Draw(this.FacilityforCPressedTexture, this.FacilityforCPressedDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.18f);
                            spriteBatch.Draw(this.FCBackgroundTexture, this.FCBackgroundDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.191f);
                            spriteBatch.Draw(this.FacilityforC1Texture, this.FacilityforC1DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforC2Texture, this.FacilityforC2DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforC3Texture, this.FacilityforC3DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforC4Texture, this.FacilityforC4DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforC5Texture, this.FacilityforC5DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforC6Texture, this.FacilityforC6DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforC7Texture, this.FacilityforC7DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforC8Texture, this.FacilityforC8DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforC9Texture, this.FacilityforC9DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforC10Texture, this.FacilityforC10DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforC11Texture, this.FacilityforC11DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforC12Texture, this.FacilityforC12DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforC13Texture, this.FacilityforC13DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforC14Texture, this.FacilityforC14DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforC15Texture, this.FacilityforC15DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforC16Texture, this.FacilityforC16DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforC17Texture, this.FacilityforC17DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforC18Texture, this.FacilityforC18DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforC19Texture, this.FacilityforC19DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforC20Texture, this.FacilityforC20DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforC21Texture, this.FacilityforC21DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforC22Texture, this.FacilityforC22DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforC23Texture, this.FacilityforC23DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforC24Texture, this.FacilityforC24DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforC25Texture, this.FacilityforC25DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforC26Texture, this.FacilityforC26DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforC27Texture, this.FacilityforC27DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforC28Texture, this.FacilityforC28DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                        }
                        if (Switch7 == "1")
                        {
                            spriteBatch.Draw(this.FacilityforDButtonTexture, this.FacilityforDButtonDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.18f);
                            spriteBatch.Draw(this.FacilityforDPressedTexture, this.FacilityforDPressedDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.18f);
                            spriteBatch.Draw(this.FDBackgroundTexture, this.FDBackgroundDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.191f);
                            spriteBatch.Draw(this.FacilityforD1Texture, this.FacilityforD1DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforD2Texture, this.FacilityforD2DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforD3Texture, this.FacilityforD3DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforD4Texture, this.FacilityforD4DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforD5Texture, this.FacilityforD5DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforD6Texture, this.FacilityforD6DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforD7Texture, this.FacilityforD7DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforD8Texture, this.FacilityforD8DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforD9Texture, this.FacilityforD9DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforD10Texture, this.FacilityforD10DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforD11Texture, this.FacilityforD11DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforD12Texture, this.FacilityforD12DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforD13Texture, this.FacilityforD13DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforD14Texture, this.FacilityforD14DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforD15Texture, this.FacilityforD15DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforD16Texture, this.FacilityforD16DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforD17Texture, this.FacilityforD17DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforD18Texture, this.FacilityforD18DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforD19Texture, this.FacilityforD19DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforD20Texture, this.FacilityforD20DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforD21Texture, this.FacilityforD21DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforD22Texture, this.FacilityforD22DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforD23Texture, this.FacilityforD23DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforD24Texture, this.FacilityforD24DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforD25Texture, this.FacilityforD25DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforD26Texture, this.FacilityforD26DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforD27Texture, this.FacilityforD27DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforD28Texture, this.FacilityforD28DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                        }
                        if (Switch8 == "1")
                        {
                            spriteBatch.Draw(this.FacilityforEButtonTexture, this.FacilityforEButtonDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.18f);
                            spriteBatch.Draw(this.FacilityforEPressedTexture, this.FacilityforEPressedDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.18f);
                            spriteBatch.Draw(this.FEBackgroundTexture, this.FEBackgroundDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.191f);
                            spriteBatch.Draw(this.FacilityforE1Texture, this.FacilityforE1DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforE2Texture, this.FacilityforE2DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforE3Texture, this.FacilityforE3DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforE4Texture, this.FacilityforE4DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforE5Texture, this.FacilityforE5DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforE6Texture, this.FacilityforE6DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforE7Texture, this.FacilityforE7DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforE8Texture, this.FacilityforE8DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforE9Texture, this.FacilityforE9DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforE10Texture, this.FacilityforE10DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforE11Texture, this.FacilityforE11DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforE12Texture, this.FacilityforE12DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforE13Texture, this.FacilityforE13DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforE14Texture, this.FacilityforE14DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforE15Texture, this.FacilityforE15DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforE16Texture, this.FacilityforE16DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforE17Texture, this.FacilityforE17DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforE18Texture, this.FacilityforE18DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforE19Texture, this.FacilityforE19DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforE20Texture, this.FacilityforE20DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforE21Texture, this.FacilityforE21DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforE22Texture, this.FacilityforE22DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforE23Texture, this.FacilityforE23DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforE24Texture, this.FacilityforE24DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforE25Texture, this.FacilityforE25DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforE26Texture, this.FacilityforE26DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforE27Texture, this.FacilityforE27DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                            spriteBatch.Draw(this.FacilityforE28Texture, this.FacilityforE28DisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);

                        }

                        if (Switch13 == "1")
                        {
                            spriteBatch.Draw(this.FacilityforSButtonTexture, this.FacilityforSButtonDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.18f);
                            spriteBatch.Draw(this.FacilityforSPressedTexture, this.FacilityforSPressedDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.18f);
                            spriteBatch.Draw(this.AuxiliaryBackgroundTexture, this.AuxiliaryBackgroundDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.191f);
                        }

                }
                  catch
                {
                }

                foreach (LabelText text in this.LabelTexts)
                {
                    text.Label.Draw(spriteBatch, 0.192f);
                    text.Text.Draw(spriteBatch, 0.192f);
                }
                this.CharacteristicText.Draw(spriteBatch, 0.192f);
                this.FacilityText.Draw(spriteBatch, 0.192f);
                this.FacilityAText.Draw(spriteBatch, 0.188f);
                this.FacilityBText.Draw(spriteBatch, 0.188f);
                this.FacilityCText.Draw(spriteBatch, 0.188f);
                this.FacilityDText.Draw(spriteBatch, 0.188f);
                this.FacilityEText.Draw(spriteBatch, 0.188f);
                this.FacilityZText.Draw(spriteBatch, 0.188f);
                this.FacilitySText.Draw(spriteBatch, 0.188f);
            }

        }

        internal void Initialize(Screen screen)
        {
            this.screen = screen;
        }

        private void screen_OnMouseLeftDown(Point position)
        {
            if (StaticMethods.PointInRectangle(position, this.CharacteristicDisplayPosition))
            {
                if (this.CharacteristicText.CurrentPageIndex < (this.CharacteristicText.PageCount - 1))
                {
                    this.CharacteristicText.NextPage();
                }
                else if (this.CharacteristicText.CurrentPageIndex == (this.CharacteristicText.PageCount - 1))
                {
                    this.CharacteristicText.FirstPage();
                }
            }
            else if (StaticMethods.PointInRectangle(position, this.FacilityDisplayPosition))
            {
                if (this.FacilityText.CurrentPageIndex < (this.FacilityText.PageCount - 1))
                {
                    this.FacilityText.NextPage();
                }
                else if (this.FacilityText.CurrentPageIndex == (this.FacilityText.PageCount - 1))
                {
                    this.FacilityText.FirstPage();
                }
            }
            /*
            //↓设施介绍翻页判定没啥意义，暂时取消           
            if (FacilityforAButton == true)
            {
                if (StaticMethods.PointInRectangle(position, this.FacilityATextDisplayPosition))
                {
                    if (this.FacilityAText.CurrentPageIndex < (this.FacilityAText.PageCount - 1))
                    {
                        this.FacilityAText.NextPage();
                    }
                    else if (this.FacilityAText.CurrentPageIndex == (this.FacilityAText.PageCount - 1))
                    {
                        this.FacilityAText.FirstPage();
                    }
                }
            }
            if (FacilityforBButton == true)
            {
                if (StaticMethods.PointInRectangle(position, this.FacilityBTextDisplayPosition))
                {
                    if (this.FacilityBText.CurrentPageIndex < (this.FacilityBText.PageCount - 1))
                    {
                        this.FacilityBText.NextPage();
                    }
                    else if (this.FacilityBText.CurrentPageIndex == (this.FacilityBText.PageCount - 1))
                    {
                        this.FacilityBText.FirstPage();
                    }
                }
            }
            if (FacilityforCButton == true)
            {
                if (StaticMethods.PointInRectangle(position, this.FacilityCTextDisplayPosition))
                {
                    if (this.FacilityCText.CurrentPageIndex < (this.FacilityCText.PageCount - 1))
                    {
                        this.FacilityCText.NextPage();
                    }
                    else if (this.FacilityCText.CurrentPageIndex == (this.FacilityCText.PageCount - 1))
                    {
                        this.FacilityCText.FirstPage();
                    }
                }
            }
            if (FacilityforDButton == true)
            {
                if (StaticMethods.PointInRectangle(position, this.FacilityDTextDisplayPosition))
                {
                    if (this.FacilityDText.CurrentPageIndex < (this.FacilityDText.PageCount - 1))
                    {
                        this.FacilityDText.NextPage();
                    }
                    else if (this.FacilityDText.CurrentPageIndex == (this.FacilityDText.PageCount - 1))
                    {
                        this.FacilityDText.FirstPage();
                    }
                }
            }
            if (FacilityforEButton == true)
            {
                if (StaticMethods.PointInRectangle(position, this.FacilityETextDisplayPosition))
                {
                    if (this.FacilityEText.CurrentPageIndex < (this.FacilityEText.PageCount - 1))
                    {
                        this.FacilityEText.NextPage();
                    }
                    else if (this.FacilityDText.CurrentPageIndex == (this.FacilityEText.PageCount - 1))
                    {
                        this.FacilityEText.FirstPage();
                    }
                }
            }
           if (FacilityIng == true)
            {
                if (StaticMethods.PointInRectangle(position, this.FacilityZTextDisplayPosition))
                {
                    if (this.FacilityZText.CurrentPageIndex < (this.FacilityZText.PageCount - 1))
                    {
                        this.FacilityZText.NextPage();
                    }
                    else if (this.FacilityZText.CurrentPageIndex == (this.FacilityZText.PageCount - 1))
                    {
                        this.FacilityZText.FirstPage();
                    }
                }
            }
            */
            if (FacilityforSButton == true)
            {
                if (StaticMethods.PointInRectangle(position, this.FacilitySTextDisplayPosition))
                {
                    if (this.FacilitySText.CurrentPageIndex < (this.FacilitySText.PageCount - 1))
                    {
                        this.FacilitySText.NextPage();
                    }
                    else if (this.FacilitySText.CurrentPageIndex == (this.FacilitySText.PageCount - 1))
                    {
                        this.FacilitySText.FirstPage();
                    }
                }
            }

            //↓按键Pressed判定
            if (Switch3 == "1")//按键联动打开
            {
                if (ArchitectureButton == false && StaticMethods.PointInRectangle(position, this.ArchitectureButtonDisplayPosition))
                {
                    ArchitectureButton = true;
                    NewArchitectureButton = false;
                    FacilityforAButton = false;
                    FacilityforBButton = false;
                    FacilityforCButton = false;
                    FacilityforDButton = false;
                    FacilityforEButton = false;
                    FacilityforSButton = false;
                    this.FacilitySText.Clear();
                }
                else if (NewArchitectureButton == false && StaticMethods.PointInRectangle(position, this.ArchitectureKindButtonDisplayPosition))
                {
                    ArchitectureButton = false;
                    NewArchitectureButton = true;
                    FacilityforAButton = false;
                    FacilityforBButton = false;
                    FacilityforCButton = false;
                    FacilityforDButton = false;
                    FacilityforEButton = false;
                    FacilityforSButton = false;
                    this.FacilitySText.Clear();
                }
                else if (FacilityforAButton == false && StaticMethods.PointInRectangle(position, this.FacilityforAButtonDisplayPosition))
                {
                    ArchitectureButton = false;
                    NewArchitectureButton = false;
                    FacilityforAButton = true;
                    FacilityforBButton = false;
                    FacilityforCButton = false;
                    FacilityforDButton = false;
                    FacilityforEButton = false;
                    FacilityforSButton = false;
                    this.FacilitySText.Clear();
                }
                else if (FacilityforBButton == false && StaticMethods.PointInRectangle(position, this.FacilityforBButtonDisplayPosition))
                {
                    ArchitectureButton = false;
                    NewArchitectureButton = false;
                    FacilityforAButton = false;
                    FacilityforBButton = true;
                    FacilityforCButton = false;
                    FacilityforDButton = false;
                    FacilityforEButton = false;
                    FacilityforSButton = false;
                    this.FacilitySText.Clear();
                }
                else if (FacilityforCButton == false && StaticMethods.PointInRectangle(position, this.FacilityforCButtonDisplayPosition))
                {
                    ArchitectureButton = false;
                    NewArchitectureButton = false;
                    FacilityforAButton = false;
                    FacilityforBButton = false;
                    FacilityforCButton = true;
                    FacilityforDButton = false;
                    FacilityforEButton = false;
                    FacilityforSButton = false;
                    this.FacilitySText.Clear();
                }
                else if (FacilityforDButton == false && StaticMethods.PointInRectangle(position, this.FacilityforDButtonDisplayPosition))
                {
                    ArchitectureButton = false;
                    NewArchitectureButton = false;
                    FacilityforAButton = false;
                    FacilityforBButton = false;
                    FacilityforCButton = false;
                    FacilityforDButton = true;
                    FacilityforEButton = false;
                    FacilityforSButton = false;
                    this.FacilitySText.Clear();
                }
                else if (FacilityforEButton == false && StaticMethods.PointInRectangle(position, this.FacilityforEButtonDisplayPosition))
                {
                    ArchitectureButton = false;
                    NewArchitectureButton = false;
                    FacilityforAButton = false;
                    FacilityforBButton = false;
                    FacilityforCButton = false;
                    FacilityforDButton = false;
                    FacilityforEButton = true;
                    FacilityforSButton = false;
                    this.FacilitySText.Clear();
                }
                else if (FacilityforSButton == false && StaticMethods.PointInRectangle(position, this.FacilityforSButtonDisplayPosition))
                {
                    ArchitectureButton = false;
                    NewArchitectureButton = false;
                    FacilityforAButton = false;
                    FacilityforBButton = false;
                    FacilityforCButton = false;
                    FacilityforDButton = false;
                    FacilityforEButton = false;
                    FacilityforSButton = true;
                    if (Switch14 == "1")
                    {
                        this.FacilitySText.Clear();
                        this.FacilitySText.AddText(FacilityforZ7Text, this.FacilitySText.TitleColor);
                        this.FacilitySText.AddNewLine();
                        this.FacilitySText.AddText(AKinds, this.FacilitySText.SubTitleColor);
                        this.FacilitySText.AddNewLine();
                        if (FacilityIng == true)
                        {

                            this.FacilitySText.AddText(FacilityforZ8Text, this.FacilitySText.TitleColor);
                            this.FacilitySText.AddNewLine();
                            this.FacilitySText.AddText(FacilityforIng, this.FacilitySText.SubTitleColor3);
                            this.FacilitySText.AddNewLine();
                        }

                        this.FacilitySText.AddText(FacilityforZ9Text, this.FacilitySText.TitleColor);
                        this.FacilitySText.AddNewLine();
                        foreach (Facility facility in this.ShowingArchitecture.Facilities)
                        {
                            this.FacilitySText.AddText(facility.Name, this.FacilitySText.SubTitleColor2);
                            this.FacilitySText.AddNewLine();


                        }
                        this.FacilitySText.ResortTexts();
                    }
                }
            }
           
            else if (Switch3 == "0")//按键联动关闭
            {
                if ( StaticMethods.PointInRectangle(position, this.ArchitectureButtonDisplayPosition))
                {
                    if (ArchitectureButton == false)
                    {
                        ArchitectureButton = true;
                    }
                    else if (ArchitectureButton == true)
                    {
                        ArchitectureButton = false;
                    }
                }
                if (StaticMethods.PointInRectangle(position, this.ArchitectureKindButtonDisplayPosition))
                {
                    if (NewArchitectureButton == false)
                    {
                        NewArchitectureButton = true;
                    }
                    else if (NewArchitectureButton == true)
                    {
                        NewArchitectureButton = false;
                    }
                }
               if (StaticMethods.PointInRectangle(position, this.FacilityforAButtonDisplayPosition))
                {
                    if (FacilityforAButton == false)
                    {
                        FacilityforAButton = true;
                    }
                    else if (FacilityforAButton == true)
                    {
                        FacilityforAButton = false;
                    }               
                }
               if (StaticMethods.PointInRectangle(position, this.FacilityforBButtonDisplayPosition))
                {
                    if (FacilityforBButton == false)
                    {
                        FacilityforBButton = true;
                    }
                    else if (FacilityforBButton == true)
                    {
                        FacilityforBButton = false;
                    }                 
                }
                if (StaticMethods.PointInRectangle(position, this.FacilityforCButtonDisplayPosition))
                {
                    if (FacilityforCButton == false)
                    {
                        FacilityforCButton = true;
                    }
                    else if (FacilityforCButton == true)
                    {
                        FacilityforCButton = false;
                    }  
                }
               if (StaticMethods.PointInRectangle(position, this.FacilityforDButtonDisplayPosition))
                {
                    if (FacilityforDButton == false)
                    {
                        FacilityforDButton = true;
                    }
                    else if (FacilityforDButton == true)
                    {
                        FacilityforDButton = false;
                    }
                }
                if (StaticMethods.PointInRectangle(position, this.FacilityforEButtonDisplayPosition))
                {
                    if (FacilityforEButton == false)
                    {
                        FacilityforEButton = true;
                    }
                    else if (FacilityforEButton == true)
                    {
                        FacilityforEButton = false;
                    }
                }
                if (StaticMethods.PointInRectangle(position, this.FacilityforSButtonDisplayPosition))
                {
                    if (FacilityforSButton == false)
                    {
                        FacilityforSButton = true;
                        if (Switch14 == "1")
                        {
                            this.FacilitySText.Clear();
                            this.FacilitySText.AddText(FacilityforZ7Text, this.FacilitySText.TitleColor);
                            this.FacilitySText.AddNewLine();
                            this.FacilitySText.AddText(AKinds, this.FacilitySText.SubTitleColor);
                            this.FacilitySText.AddNewLine();
                            if (FacilityIng == true)
                            {

                                this.FacilitySText.AddText(FacilityforZ8Text, this.FacilitySText.TitleColor);
                                this.FacilitySText.AddNewLine();
                                this.FacilitySText.AddText(FacilityforIng, this.FacilitySText.SubTitleColor3);
                                this.FacilitySText.AddNewLine();
                            }

                            this.FacilitySText.AddText(FacilityforZ9Text, this.FacilitySText.TitleColor);
                            this.FacilitySText.AddNewLine();
                            foreach (Facility facility in this.ShowingArchitecture.Facilities)
                            {
                                this.FacilitySText.AddText(facility.Name, this.FacilitySText.SubTitleColor2);
                                this.FacilitySText.AddNewLine();


                            }
                            this.FacilitySText.ResortTexts();
                        }
                    }
                    else if (FacilityforSButton == true)
                    {
                        FacilityforSButton = false;
                        this.FacilitySText.Clear();
                    }
                }
            }
            //↑按键Pressd判定
        }

        private void screen_OnMouseMove(Point position, bool leftDown)
        {
           //↓A区设施介绍
            if (FacilityforAButton == true)
            {
                bool flag = false;
                if (!flag)
                {
                    if (FacilityTexton == false)
                    {
                        if (FA1 == true && StaticMethods.PointInRectangle(position, this.FacilityforA1DisplayPosition))
                        {
                            this.FacilityAText.Clear();
                            this.FacilityAText.AddText(FacilityforZ1Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA1, this.FacilityAText.SubTitleColor);
                            if (FAN1 > 1)
                            {
                                this.FacilityAText.AddNewLine();
                                this.FacilityAText.AddText(FacilityforZ3Text, this.FacilityAText.TitleColor);
                                this.FacilityAText.AddText(FAN1.ToString(), this.FacilityAText.SubTitleColor3);
                            }
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforZ2Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA1Text, this.FacilityAText.SubTitleColor2);
                            this.FacilityAText.ResortTexts();
                            FacilityTexton = true;

                        }
                        if (FA2 == true && StaticMethods.PointInRectangle(position, this.FacilityforA2DisplayPosition))
                        {
                            this.FacilityAText.Clear();
                            this.FacilityAText.AddText(FacilityforZ1Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA2, this.FacilityAText.SubTitleColor);
                            if (FAN2 > 1)
                            {
                                this.FacilityAText.AddNewLine();
                                this.FacilityAText.AddText(FacilityforZ3Text, this.FacilityAText.TitleColor);
                                this.FacilityAText.AddText(FAN2.ToString(), this.FacilityAText.SubTitleColor3);
                            }
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforZ2Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA2Text, this.FacilityAText.SubTitleColor2);
                            this.FacilityAText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FA3 == true && StaticMethods.PointInRectangle(position, this.FacilityforA3DisplayPosition))
                        {
                            this.FacilityAText.Clear();
                            this.FacilityAText.AddText(FacilityforZ1Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA3, this.FacilityAText.SubTitleColor);
                            if (FAN3 > 1)
                            {
                                this.FacilityAText.AddNewLine();
                                this.FacilityAText.AddText(FacilityforZ3Text, this.FacilityAText.TitleColor);
                                this.FacilityAText.AddText(FAN3.ToString(), this.FacilityAText.SubTitleColor3);
                            }
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforZ2Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA3Text, this.FacilityAText.SubTitleColor2);
                            this.FacilityAText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FA4 == true && StaticMethods.PointInRectangle(position, this.FacilityforA4DisplayPosition))
                        {
                            this.FacilityAText.Clear();
                            this.FacilityAText.AddText(FacilityforZ1Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA4, this.FacilityAText.SubTitleColor);
                            if (FAN4 > 1)
                            {
                                this.FacilityAText.AddNewLine();
                                this.FacilityAText.AddText(FacilityforZ3Text, this.FacilityAText.TitleColor);
                                this.FacilityAText.AddText(FAN4.ToString(), this.FacilityAText.SubTitleColor3);
                            }
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforZ2Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA4Text, this.FacilityAText.SubTitleColor2);
                            this.FacilityAText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FA5 = true && StaticMethods.PointInRectangle(position, this.FacilityforA5DisplayPosition))
                        {
                            this.FacilityAText.Clear();
                            this.FacilityAText.AddText(FacilityforZ1Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA5, this.FacilityAText.SubTitleColor);
                            if (FAN5 > 1)
                            {
                                this.FacilityAText.AddNewLine();
                                this.FacilityAText.AddText(FacilityforZ3Text, this.FacilityAText.TitleColor);
                                this.FacilityAText.AddText(FAN5.ToString(), this.FacilityAText.SubTitleColor3);
                            }
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforZ2Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA5Text, this.FacilityAText.SubTitleColor2);
                            this.FacilityAText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FA6 == true && StaticMethods.PointInRectangle(position, this.FacilityforA6DisplayPosition))
                        {
                            this.FacilityAText.Clear();
                            this.FacilityAText.AddText(FacilityforZ1Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA6, this.FacilityAText.SubTitleColor);
                            if (FAN6 > 1)
                            {
                                this.FacilityAText.AddNewLine();
                                this.FacilityAText.AddText(FacilityforZ3Text, this.FacilityAText.TitleColor);
                                this.FacilityAText.AddText(FAN6.ToString(), this.FacilityAText.SubTitleColor3);
                            }
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforZ2Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA6Text, this.FacilityAText.SubTitleColor2);
                            this.FacilityAText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FA7 == true && StaticMethods.PointInRectangle(position, this.FacilityforA7DisplayPosition))
                        {
                            this.FacilityAText.Clear();
                            this.FacilityAText.AddText(FacilityforZ1Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA7, this.FacilityAText.SubTitleColor);
                            if (FAN7 > 1)
                            {
                                this.FacilityAText.AddNewLine();
                                this.FacilityAText.AddText(FacilityforZ3Text, this.FacilityAText.TitleColor);
                                this.FacilityAText.AddText(FAN7.ToString(), this.FacilityAText.SubTitleColor3);
                            }
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforZ2Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA7Text, this.FacilityAText.SubTitleColor2);
                            this.FacilityAText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FA8 == true && StaticMethods.PointInRectangle(position, this.FacilityforA8DisplayPosition))
                        {
                            this.FacilityAText.Clear();
                            this.FacilityAText.AddText(FacilityforZ1Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA8, this.FacilityAText.SubTitleColor);
                            if (FAN8 > 1)
                            {
                                this.FacilityAText.AddNewLine();
                                this.FacilityAText.AddText(FacilityforZ3Text, this.FacilityAText.TitleColor);
                                this.FacilityAText.AddText(FAN8.ToString(), this.FacilityAText.SubTitleColor3);
                            }
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforZ2Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA8Text, this.FacilityAText.SubTitleColor2);
                            this.FacilityAText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FA9 == true && StaticMethods.PointInRectangle(position, this.FacilityforA9DisplayPosition))
                        {
                            this.FacilityAText.Clear();
                            this.FacilityAText.AddText(FacilityforZ1Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA9, this.FacilityAText.SubTitleColor);
                            if (FAN9 > 1)
                            {
                                this.FacilityAText.AddNewLine();
                                this.FacilityAText.AddText(FacilityforZ3Text, this.FacilityAText.TitleColor);
                                this.FacilityAText.AddText(FAN9.ToString(), this.FacilityAText.SubTitleColor3);
                            }
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforZ2Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA9Text, this.FacilityAText.SubTitleColor2);
                            this.FacilityAText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FA10 == true && StaticMethods.PointInRectangle(position, this.FacilityforA10DisplayPosition))
                        {
                            this.FacilityAText.Clear();
                            this.FacilityAText.AddText(FacilityforZ1Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA10, this.FacilityAText.SubTitleColor);
                            if (FAN10 > 1)
                            {
                                this.FacilityAText.AddNewLine();
                                this.FacilityAText.AddText(FacilityforZ3Text, this.FacilityAText.TitleColor);
                                this.FacilityAText.AddText(FAN10.ToString(), this.FacilityAText.SubTitleColor3);
                            }
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforZ2Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA10Text, this.FacilityAText.SubTitleColor2);
                            this.FacilityAText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FA11 == true && StaticMethods.PointInRectangle(position, this.FacilityforA11DisplayPosition))
                        {
                            this.FacilityAText.Clear();
                            this.FacilityAText.AddText(FacilityforZ1Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA11, this.FacilityAText.SubTitleColor);
                            if (FAN11 > 1)
                            {
                                this.FacilityAText.AddNewLine();
                                this.FacilityAText.AddText(FacilityforZ3Text, this.FacilityAText.TitleColor);
                                this.FacilityAText.AddText(FAN11.ToString(), this.FacilityAText.SubTitleColor3);
                            }
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforZ2Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA11Text, this.FacilityAText.SubTitleColor2);
                            this.FacilityAText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FA12 == true && StaticMethods.PointInRectangle(position, this.FacilityforA12DisplayPosition))
                        {
                            this.FacilityAText.Clear();
                            this.FacilityAText.AddText(FacilityforZ1Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA12, this.FacilityAText.SubTitleColor);
                            if (FAN12 > 1)
                            {
                                this.FacilityAText.AddNewLine();
                                this.FacilityAText.AddText(FacilityforZ3Text, this.FacilityAText.TitleColor);
                                this.FacilityAText.AddText(FAN12.ToString(), this.FacilityAText.SubTitleColor3);
                            }
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforZ2Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA12Text, this.FacilityAText.SubTitleColor2);
                            this.FacilityAText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FA13 == true && StaticMethods.PointInRectangle(position, this.FacilityforA13DisplayPosition))
                        {
                            this.FacilityAText.Clear();
                            this.FacilityAText.AddText(FacilityforZ1Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA13, this.FacilityAText.SubTitleColor);
                            if (FAN13 > 1)
                            {
                                this.FacilityAText.AddNewLine();
                                this.FacilityAText.AddText(FacilityforZ3Text, this.FacilityAText.TitleColor);
                                this.FacilityAText.AddText(FAN13.ToString(), this.FacilityAText.SubTitleColor3);
                            }
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforZ2Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA13Text, this.FacilityAText.SubTitleColor2);
                            this.FacilityAText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FA14 == true && StaticMethods.PointInRectangle(position, this.FacilityforA14DisplayPosition))
                        {
                            this.FacilityAText.Clear();
                            this.FacilityAText.AddText(FacilityforZ1Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA14, this.FacilityAText.SubTitleColor);
                            if (FAN14 > 1)
                            {
                                this.FacilityAText.AddNewLine();
                                this.FacilityAText.AddText(FacilityforZ3Text, this.FacilityAText.TitleColor);
                                this.FacilityAText.AddText(FAN14.ToString(), this.FacilityAText.SubTitleColor3);
                            }
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforZ2Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA14Text, this.FacilityAText.SubTitleColor2);
                            this.FacilityAText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FA15 == true && StaticMethods.PointInRectangle(position, this.FacilityforA15DisplayPosition))
                        {
                            this.FacilityAText.Clear();
                            this.FacilityAText.AddText(FacilityforZ1Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA15, this.FacilityAText.SubTitleColor);
                            if (FAN15 > 1)
                            {
                                this.FacilityAText.AddNewLine();
                                this.FacilityAText.AddText(FacilityforZ3Text, this.FacilityAText.TitleColor);
                                this.FacilityAText.AddText(FAN15.ToString(), this.FacilityAText.SubTitleColor3);
                            }
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforZ2Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA15Text, this.FacilityAText.SubTitleColor2);
                            this.FacilityAText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FA16 == true && StaticMethods.PointInRectangle(position, this.FacilityforA16DisplayPosition))
                        {
                            this.FacilityAText.Clear();
                            this.FacilityAText.AddText(FacilityforZ1Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA16, this.FacilityAText.SubTitleColor);
                            if (FAN16 > 1)
                            {
                                this.FacilityAText.AddNewLine();
                                this.FacilityAText.AddText(FacilityforZ3Text, this.FacilityAText.TitleColor);
                                this.FacilityAText.AddText(FAN16.ToString(), this.FacilityAText.SubTitleColor3);
                            }
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforZ2Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA16Text, this.FacilityAText.SubTitleColor2);
                            this.FacilityAText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FA17 == true && StaticMethods.PointInRectangle(position, this.FacilityforA17DisplayPosition))
                        {
                            this.FacilityAText.Clear();
                            this.FacilityAText.AddText(FacilityforZ1Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA17, this.FacilityAText.SubTitleColor);
                            if (FAN17 > 1)
                            {
                                this.FacilityAText.AddNewLine();
                                this.FacilityAText.AddText(FacilityforZ3Text, this.FacilityAText.TitleColor);
                                this.FacilityAText.AddText(FAN17.ToString(), this.FacilityAText.SubTitleColor3);
                            }
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforZ2Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA17Text, this.FacilityAText.SubTitleColor2);
                            this.FacilityAText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FA18 == true && StaticMethods.PointInRectangle(position, this.FacilityforA18DisplayPosition))
                        {
                            this.FacilityAText.Clear();
                            this.FacilityAText.AddText(FacilityforZ1Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA18, this.FacilityAText.SubTitleColor);
                            if (FAN18 > 1)
                            {
                                this.FacilityAText.AddNewLine();
                                this.FacilityAText.AddText(FacilityforZ3Text, this.FacilityAText.TitleColor);
                                this.FacilityAText.AddText(FAN18.ToString(), this.FacilityAText.SubTitleColor3);
                            }
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforZ2Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA18Text, this.FacilityAText.SubTitleColor2);
                            this.FacilityAText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FA19 == true && StaticMethods.PointInRectangle(position, this.FacilityforA19DisplayPosition))
                        {
                            this.FacilityAText.Clear();
                            this.FacilityAText.AddText(FacilityforZ1Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA19, this.FacilityAText.SubTitleColor);
                            if (FAN19 > 1)
                            {
                                this.FacilityAText.AddNewLine();
                                this.FacilityAText.AddText(FacilityforZ3Text, this.FacilityAText.TitleColor);
                                this.FacilityAText.AddText(FAN19.ToString(), this.FacilityAText.SubTitleColor3);
                            }
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforZ2Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA19Text, this.FacilityAText.SubTitleColor2);
                            this.FacilityAText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FA20 == true && StaticMethods.PointInRectangle(position, this.FacilityforA20DisplayPosition))
                        {
                            this.FacilityAText.Clear();
                            this.FacilityAText.AddText(FacilityforZ1Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA20, this.FacilityAText.SubTitleColor);
                            if (FAN20 > 1)
                            {
                                this.FacilityAText.AddNewLine();
                                this.FacilityAText.AddText(FacilityforZ3Text, this.FacilityAText.TitleColor);
                                this.FacilityAText.AddText(FAN20.ToString(), this.FacilityAText.SubTitleColor3);
                            }
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforZ2Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA20Text, this.FacilityAText.SubTitleColor2);
                            this.FacilityAText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FA21 == true && StaticMethods.PointInRectangle(position, this.FacilityforA21DisplayPosition))
                        {
                            this.FacilityAText.Clear();
                            this.FacilityAText.AddText(FacilityforZ1Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA21, this.FacilityAText.SubTitleColor);
                            if (FAN21 > 1)
                            {
                                this.FacilityAText.AddNewLine();
                                this.FacilityAText.AddText(FacilityforZ3Text, this.FacilityAText.TitleColor);
                                this.FacilityAText.AddText(FAN21.ToString(), this.FacilityAText.SubTitleColor3);
                            }
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforZ2Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA21Text, this.FacilityAText.SubTitleColor2);
                            this.FacilityAText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FA22 == true && StaticMethods.PointInRectangle(position, this.FacilityforA22DisplayPosition))
                        {
                            this.FacilityAText.Clear();
                            this.FacilityAText.AddText(FacilityforZ1Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA22, this.FacilityAText.SubTitleColor);
                            if (FAN22 > 1)
                            {
                                this.FacilityAText.AddNewLine();
                                this.FacilityAText.AddText(FacilityforZ3Text, this.FacilityAText.TitleColor);
                                this.FacilityAText.AddText(FAN22.ToString(), this.FacilityAText.SubTitleColor3);
                            }
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforZ2Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA22Text, this.FacilityAText.SubTitleColor2);
                            this.FacilityAText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FA23 == true && StaticMethods.PointInRectangle(position, this.FacilityforA23DisplayPosition))
                        {
                            this.FacilityAText.Clear();
                            this.FacilityAText.AddText(FacilityforZ1Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA23, this.FacilityAText.SubTitleColor);
                            if (FAN23 > 1)
                            {
                                this.FacilityAText.AddNewLine();
                                this.FacilityAText.AddText(FacilityforZ3Text, this.FacilityAText.TitleColor);
                                this.FacilityAText.AddText(FAN23.ToString(), this.FacilityAText.SubTitleColor3);
                            }
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforZ2Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA23Text, this.FacilityAText.SubTitleColor2);
                            this.FacilityAText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FA24 == true && StaticMethods.PointInRectangle(position, this.FacilityforA24DisplayPosition))
                        {
                            this.FacilityAText.Clear();
                            this.FacilityAText.AddText(FacilityforZ1Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA24, this.FacilityAText.SubTitleColor);
                            if (FAN24 > 1)
                            {
                                this.FacilityAText.AddNewLine();
                                this.FacilityAText.AddText(FacilityforZ3Text, this.FacilityAText.TitleColor);
                                this.FacilityAText.AddText(FAN24.ToString(), this.FacilityAText.SubTitleColor3);
                            }
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforZ2Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA24Text, this.FacilityAText.SubTitleColor2);
                            this.FacilityAText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FA25 == true && StaticMethods.PointInRectangle(position, this.FacilityforA25DisplayPosition))
                        {
                            this.FacilityAText.Clear();
                            this.FacilityAText.AddText(FacilityforZ1Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA25, this.FacilityAText.SubTitleColor);
                            if (FAN25 > 1)
                            {
                                this.FacilityAText.AddNewLine();
                                this.FacilityAText.AddText(FacilityforZ3Text, this.FacilityAText.TitleColor);
                                this.FacilityAText.AddText(FAN25.ToString(), this.FacilityAText.SubTitleColor3);
                            }
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforZ2Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA25Text, this.FacilityAText.SubTitleColor2);
                            this.FacilityAText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FA26 == true && StaticMethods.PointInRectangle(position, this.FacilityforA26DisplayPosition))
                        {
                            this.FacilityAText.Clear();
                            this.FacilityAText.AddText(FacilityforZ1Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA26, this.FacilityAText.SubTitleColor);
                            if (FAN26 > 1)
                            {
                                this.FacilityAText.AddNewLine();
                                this.FacilityAText.AddText(FacilityforZ3Text, this.FacilityAText.TitleColor);
                                this.FacilityAText.AddText(FAN26.ToString(), this.FacilityAText.SubTitleColor3);
                            }
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforZ2Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA26Text, this.FacilityAText.SubTitleColor2);
                            this.FacilityAText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FA27 == true && StaticMethods.PointInRectangle(position, this.FacilityforA27DisplayPosition))
                        {
                            this.FacilityAText.Clear();
                            this.FacilityAText.AddText(FacilityforZ1Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA27, this.FacilityAText.SubTitleColor);
                            if (FAN27 > 1)
                            {
                                this.FacilityAText.AddNewLine();
                                this.FacilityAText.AddText(FacilityforZ3Text, this.FacilityAText.TitleColor);
                                this.FacilityAText.AddText(FAN27.ToString(), this.FacilityAText.SubTitleColor3);
                            }
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforZ2Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA27Text, this.FacilityAText.SubTitleColor2);
                            this.FacilityAText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FA28 == true && StaticMethods.PointInRectangle(position, this.FacilityforA28DisplayPosition))
                        {
                            this.FacilityAText.Clear();
                            this.FacilityAText.AddText(FacilityforZ1Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA28, this.FacilityAText.SubTitleColor);
                            if (FAN28 > 1)
                            {
                                this.FacilityAText.AddNewLine();
                                this.FacilityAText.AddText(FacilityforZ3Text, this.FacilityAText.TitleColor);
                                this.FacilityAText.AddText(FAN28.ToString(), this.FacilityAText.SubTitleColor3);
                            }
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforZ2Text, this.FacilityAText.TitleColor);
                            this.FacilityAText.AddNewLine();
                            this.FacilityAText.AddText(FacilityforA28Text, this.FacilityAText.SubTitleColor2);
                            this.FacilityAText.ResortTexts();
                            FacilityTexton = true;
                        }

                        flag = true;
                    }
                }
                if (!flag)
                {
                    if (FacilityTexton == true)
                    {
                        FacilityTexton = false;
                        FacilityAText.Clear();
                    }
                }

            }

            //↓B区设施介绍
            if (FacilityforBButton == true)
            {
                bool flag2 = false;
                if (!flag2)
                {
                    if (FacilityTexton == false)
                    {
                        if (FB1 == true && StaticMethods.PointInRectangle(position, this.FacilityforB1DisplayPosition))
                        {
                            this.FacilityBText.Clear();
                            this.FacilityBText.AddText(FacilityforZ1Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB1, this.FacilityBText.SubTitleColor);
                            if (FBN1 > 1)
                            {
                                this.FacilityBText.AddNewLine();
                                this.FacilityBText.AddText(FacilityforZ3Text, this.FacilityBText.TitleColor);
                                this.FacilityBText.AddText(FBN1.ToString(), this.FacilityBText.SubTitleColor3);
                            }
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforZ2Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB1Text, this.FacilityBText.SubTitleColor2);
                            this.FacilityBText.ResortTexts();
                            FacilityTexton = true;

                        }
                        if (FB2 == true && StaticMethods.PointInRectangle(position, this.FacilityforB2DisplayPosition))
                        {
                            this.FacilityBText.Clear();
                            this.FacilityBText.AddText(FacilityforZ1Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB2, this.FacilityBText.SubTitleColor);
                            if (FBN2 > 1)
                            {
                                this.FacilityBText.AddNewLine();
                                this.FacilityBText.AddText(FacilityforZ3Text, this.FacilityBText.TitleColor);
                                this.FacilityBText.AddText(FBN2.ToString(), this.FacilityBText.SubTitleColor3);
                            }
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforZ2Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB2Text, this.FacilityBText.SubTitleColor2);
                            this.FacilityBText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FB3 == true && StaticMethods.PointInRectangle(position, this.FacilityforB3DisplayPosition))
                        {
                            this.FacilityBText.Clear();
                            this.FacilityBText.AddText(FacilityforZ1Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB3, this.FacilityBText.SubTitleColor);
                            if (FBN3 > 1)
                            {
                                this.FacilityBText.AddNewLine();
                                this.FacilityBText.AddText(FacilityforZ3Text, this.FacilityBText.TitleColor);
                                this.FacilityBText.AddText(FBN3.ToString(), this.FacilityBText.SubTitleColor3);
                            }
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforZ2Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB3Text, this.FacilityBText.SubTitleColor2);
                            this.FacilityBText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FB4 == true && StaticMethods.PointInRectangle(position, this.FacilityforB4DisplayPosition))
                        {
                            this.FacilityBText.Clear();
                            this.FacilityBText.AddText(FacilityforZ1Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB4, this.FacilityBText.SubTitleColor);
                            if (FBN4 > 1)
                            {
                                this.FacilityBText.AddNewLine();
                                this.FacilityBText.AddText(FacilityforZ3Text, this.FacilityBText.TitleColor);
                                this.FacilityBText.AddText(FBN4.ToString(), this.FacilityBText.SubTitleColor3);
                            }
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforZ2Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB4Text, this.FacilityBText.SubTitleColor2);
                            this.FacilityBText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FB5 = true && StaticMethods.PointInRectangle(position, this.FacilityforB5DisplayPosition))
                        {
                            this.FacilityBText.Clear();
                            this.FacilityBText.AddText(FacilityforZ1Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB5, this.FacilityBText.SubTitleColor);
                            if (FBN5 > 1)
                            {
                                this.FacilityBText.AddNewLine();
                                this.FacilityBText.AddText(FacilityforZ3Text, this.FacilityBText.TitleColor);
                                this.FacilityBText.AddText(FBN5.ToString(), this.FacilityBText.SubTitleColor3);
                            }
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforZ2Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB5Text, this.FacilityBText.SubTitleColor2);
                            this.FacilityBText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FB6 == true && StaticMethods.PointInRectangle(position, this.FacilityforB6DisplayPosition))
                        {
                            this.FacilityBText.Clear();
                            this.FacilityBText.AddText(FacilityforZ1Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB6, this.FacilityBText.SubTitleColor);
                            if (FBN6 > 1)
                            {
                                this.FacilityBText.AddNewLine();
                                this.FacilityBText.AddText(FacilityforZ3Text, this.FacilityBText.TitleColor);
                                this.FacilityBText.AddText(FBN6.ToString(), this.FacilityBText.SubTitleColor3);
                            }
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforZ2Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB6Text, this.FacilityBText.SubTitleColor2);
                            this.FacilityBText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FB7 == true && StaticMethods.PointInRectangle(position, this.FacilityforB7DisplayPosition))
                        {
                            this.FacilityBText.Clear();
                            this.FacilityBText.AddText(FacilityforZ1Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB7, this.FacilityBText.SubTitleColor);
                            if (FBN7 > 1)
                            {
                                this.FacilityBText.AddNewLine();
                                this.FacilityBText.AddText(FacilityforZ3Text, this.FacilityBText.TitleColor);
                                this.FacilityBText.AddText(FBN7.ToString(), this.FacilityBText.SubTitleColor3);
                            }
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforZ2Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB7Text, this.FacilityBText.SubTitleColor2);
                            this.FacilityBText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FB8 == true && StaticMethods.PointInRectangle(position, this.FacilityforB8DisplayPosition))
                        {
                            this.FacilityBText.Clear();
                            this.FacilityBText.AddText(FacilityforZ1Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB8, this.FacilityBText.SubTitleColor);
                            if (FBN8 > 1)
                            {
                                this.FacilityBText.AddNewLine();
                                this.FacilityBText.AddText(FacilityforZ3Text, this.FacilityBText.TitleColor);
                                this.FacilityBText.AddText(FBN8.ToString(), this.FacilityBText.SubTitleColor3);
                            }
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforZ2Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB8Text, this.FacilityBText.SubTitleColor2);
                            this.FacilityBText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FB9 == true && StaticMethods.PointInRectangle(position, this.FacilityforB9DisplayPosition))
                        {
                            this.FacilityBText.Clear();
                            this.FacilityBText.AddText(FacilityforZ1Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB9, this.FacilityBText.SubTitleColor);
                            if (FBN9 > 1)
                            {
                                this.FacilityBText.AddNewLine();
                                this.FacilityBText.AddText(FacilityforZ3Text, this.FacilityBText.TitleColor);
                                this.FacilityBText.AddText(FBN9.ToString(), this.FacilityBText.SubTitleColor3);
                            }
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforZ2Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB9Text, this.FacilityBText.SubTitleColor2);
                            this.FacilityBText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FB10 == true && StaticMethods.PointInRectangle(position, this.FacilityforB10DisplayPosition))
                        {
                            this.FacilityBText.Clear();
                            this.FacilityBText.AddText(FacilityforZ1Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB10, this.FacilityBText.SubTitleColor);
                            if (FBN10 > 1)
                            {
                                this.FacilityBText.AddNewLine();
                                this.FacilityBText.AddText(FacilityforZ3Text, this.FacilityBText.TitleColor);
                                this.FacilityBText.AddText(FBN10.ToString(), this.FacilityBText.SubTitleColor3);
                            }
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforZ2Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB10Text, this.FacilityBText.SubTitleColor2);
                            this.FacilityBText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FB11 == true && StaticMethods.PointInRectangle(position, this.FacilityforB11DisplayPosition))
                        {
                            this.FacilityBText.Clear();
                            this.FacilityBText.AddText(FacilityforZ1Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB11, this.FacilityBText.SubTitleColor);
                            if (FBN11 > 1)
                            {
                                this.FacilityBText.AddNewLine();
                                this.FacilityBText.AddText(FacilityforZ3Text, this.FacilityBText.TitleColor);
                                this.FacilityBText.AddText(FBN11.ToString(), this.FacilityBText.SubTitleColor3);
                            }
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforZ2Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB11Text, this.FacilityBText.SubTitleColor2);
                            this.FacilityBText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FB12 == true && StaticMethods.PointInRectangle(position, this.FacilityforB12DisplayPosition))
                        {
                            this.FacilityBText.Clear();
                            this.FacilityBText.AddText(FacilityforZ1Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB12, this.FacilityBText.SubTitleColor);
                            if (FBN12 > 1)
                            {
                                this.FacilityBText.AddNewLine();
                                this.FacilityBText.AddText(FacilityforZ3Text, this.FacilityBText.TitleColor);
                                this.FacilityBText.AddText(FBN12.ToString(), this.FacilityBText.SubTitleColor3);
                            }
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforZ2Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB12Text, this.FacilityBText.SubTitleColor2);
                            this.FacilityBText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FB13 == true && StaticMethods.PointInRectangle(position, this.FacilityforB13DisplayPosition))
                        {
                            this.FacilityBText.Clear();
                            this.FacilityBText.AddText(FacilityforZ1Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB13, this.FacilityBText.SubTitleColor);
                            if (FBN13 > 1)
                            {
                                this.FacilityBText.AddNewLine();
                                this.FacilityBText.AddText(FacilityforZ3Text, this.FacilityBText.TitleColor);
                                this.FacilityBText.AddText(FBN13.ToString(), this.FacilityBText.SubTitleColor3);
                            }
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforZ2Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB13Text, this.FacilityBText.SubTitleColor2);
                            this.FacilityBText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FB14 == true && StaticMethods.PointInRectangle(position, this.FacilityforB14DisplayPosition))
                        {
                            this.FacilityBText.Clear();
                            this.FacilityBText.AddText(FacilityforZ1Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB14, this.FacilityBText.SubTitleColor);
                            if (FBN14 > 1)
                            {
                                this.FacilityBText.AddNewLine();
                                this.FacilityBText.AddText(FacilityforZ3Text, this.FacilityBText.TitleColor);
                                this.FacilityBText.AddText(FBN14.ToString(), this.FacilityBText.SubTitleColor3);
                            }
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforZ2Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB14Text, this.FacilityBText.SubTitleColor2);
                            this.FacilityBText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FB15 == true && StaticMethods.PointInRectangle(position, this.FacilityforB15DisplayPosition))
                        {
                            this.FacilityBText.Clear();
                            this.FacilityBText.AddText(FacilityforZ1Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB15, this.FacilityBText.SubTitleColor);
                            if (FBN15 > 1)
                            {
                                this.FacilityBText.AddNewLine();
                                this.FacilityBText.AddText(FacilityforZ3Text, this.FacilityBText.TitleColor);
                                this.FacilityBText.AddText(FBN15.ToString(), this.FacilityBText.SubTitleColor3);
                            }
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforZ2Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB15Text, this.FacilityBText.SubTitleColor2);
                            this.FacilityBText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FB16 == true && StaticMethods.PointInRectangle(position, this.FacilityforB16DisplayPosition))
                        {
                            this.FacilityBText.Clear();
                            this.FacilityBText.AddText(FacilityforZ1Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB16, this.FacilityBText.SubTitleColor);
                            if (FBN16 > 1)
                            {
                                this.FacilityBText.AddNewLine();
                                this.FacilityBText.AddText(FacilityforZ3Text, this.FacilityBText.TitleColor);
                                this.FacilityBText.AddText(FBN16.ToString(), this.FacilityBText.SubTitleColor3);
                            }
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforZ2Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB16Text, this.FacilityBText.SubTitleColor2);
                            this.FacilityBText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FB17 == true && StaticMethods.PointInRectangle(position, this.FacilityforB17DisplayPosition))
                        {
                            this.FacilityBText.Clear();
                            this.FacilityBText.AddText(FacilityforZ1Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB17, this.FacilityBText.SubTitleColor);
                            if (FBN17 > 1)
                            {
                                this.FacilityBText.AddNewLine();
                                this.FacilityBText.AddText(FacilityforZ3Text, this.FacilityBText.TitleColor);
                                this.FacilityBText.AddText(FBN17.ToString(), this.FacilityBText.SubTitleColor3);
                            }
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforZ2Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB17Text, this.FacilityBText.SubTitleColor2);
                            this.FacilityBText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FB18 == true && StaticMethods.PointInRectangle(position, this.FacilityforB18DisplayPosition))
                        {
                            this.FacilityBText.Clear();
                            this.FacilityBText.AddText(FacilityforZ1Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB18, this.FacilityBText.SubTitleColor);
                            if (FBN18 > 1)
                            {
                                this.FacilityBText.AddNewLine();
                                this.FacilityBText.AddText(FacilityforZ3Text, this.FacilityBText.TitleColor);
                                this.FacilityBText.AddText(FBN18.ToString(), this.FacilityBText.SubTitleColor3);
                            }
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforZ2Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB18Text, this.FacilityBText.SubTitleColor2);
                            this.FacilityBText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FB19 == true && StaticMethods.PointInRectangle(position, this.FacilityforB19DisplayPosition))
                        {
                            this.FacilityBText.Clear();
                            this.FacilityBText.AddText(FacilityforZ1Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB19, this.FacilityBText.SubTitleColor);
                            if (FBN19 > 1)
                            {
                                this.FacilityBText.AddNewLine();
                                this.FacilityBText.AddText(FacilityforZ3Text, this.FacilityBText.TitleColor);
                                this.FacilityBText.AddText(FBN19.ToString(), this.FacilityBText.SubTitleColor3);
                            }
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforZ2Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB19Text, this.FacilityBText.SubTitleColor2);
                            this.FacilityBText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FB20 == true && StaticMethods.PointInRectangle(position, this.FacilityforB20DisplayPosition))
                        {
                            this.FacilityBText.Clear();
                            this.FacilityBText.AddText(FacilityforZ1Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB20, this.FacilityBText.SubTitleColor);
                            if (FBN20 > 1)
                            {
                                this.FacilityBText.AddNewLine();
                                this.FacilityBText.AddText(FacilityforZ3Text, this.FacilityBText.TitleColor);
                                this.FacilityBText.AddText(FBN20.ToString(), this.FacilityBText.SubTitleColor3);
                            }
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforZ2Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB20Text, this.FacilityBText.SubTitleColor2);
                            this.FacilityBText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FB21 == true && StaticMethods.PointInRectangle(position, this.FacilityforB21DisplayPosition))
                        {
                            this.FacilityBText.Clear();
                            this.FacilityBText.AddText(FacilityforZ1Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB21, this.FacilityBText.SubTitleColor);
                            if (FBN21 > 1)
                            {
                                this.FacilityBText.AddNewLine();
                                this.FacilityBText.AddText(FacilityforZ3Text, this.FacilityBText.TitleColor);
                                this.FacilityBText.AddText(FBN21.ToString(), this.FacilityBText.SubTitleColor3);
                            }
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforZ2Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB21Text, this.FacilityBText.SubTitleColor2);
                            this.FacilityBText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FB22 == true && StaticMethods.PointInRectangle(position, this.FacilityforB22DisplayPosition))
                        {
                            this.FacilityBText.Clear();
                            this.FacilityBText.AddText(FacilityforZ1Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB22, this.FacilityBText.SubTitleColor);
                            if (FBN22 > 1)
                            {
                                this.FacilityBText.AddNewLine();
                                this.FacilityBText.AddText(FacilityforZ3Text, this.FacilityBText.TitleColor);
                                this.FacilityBText.AddText(FBN22.ToString(), this.FacilityBText.SubTitleColor3);
                            }
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforZ2Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB22Text, this.FacilityBText.SubTitleColor2);
                            this.FacilityBText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FB23 == true && StaticMethods.PointInRectangle(position, this.FacilityforB23DisplayPosition))
                        {
                            this.FacilityBText.Clear();
                            this.FacilityBText.AddText(FacilityforZ1Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB23, this.FacilityBText.SubTitleColor);
                            if (FBN23 > 1)
                            {
                                this.FacilityBText.AddNewLine();
                                this.FacilityBText.AddText(FacilityforZ3Text, this.FacilityBText.TitleColor);
                                this.FacilityBText.AddText(FBN23.ToString(), this.FacilityBText.SubTitleColor3);
                            }
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforZ2Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB23Text, this.FacilityBText.SubTitleColor2);
                            this.FacilityBText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FB24 == true && StaticMethods.PointInRectangle(position, this.FacilityforB24DisplayPosition))
                        {
                            this.FacilityBText.Clear();
                            this.FacilityBText.AddText(FacilityforZ1Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB24, this.FacilityBText.SubTitleColor);
                            if (FBN24 > 1)
                            {
                                this.FacilityBText.AddNewLine();
                                this.FacilityBText.AddText(FacilityforZ3Text, this.FacilityBText.TitleColor);
                                this.FacilityBText.AddText(FBN24.ToString(), this.FacilityBText.SubTitleColor3);
                            }
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforZ2Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB24Text, this.FacilityBText.SubTitleColor2);
                            this.FacilityBText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FB25 == true && StaticMethods.PointInRectangle(position, this.FacilityforB25DisplayPosition))
                        {
                            this.FacilityBText.Clear();
                            this.FacilityBText.AddText(FacilityforZ1Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB25, this.FacilityBText.SubTitleColor);
                            if (FBN25 > 1)
                            {
                                this.FacilityBText.AddNewLine();
                                this.FacilityBText.AddText(FacilityforZ3Text, this.FacilityBText.TitleColor);
                                this.FacilityBText.AddText(FBN25.ToString(), this.FacilityBText.SubTitleColor3);
                            }
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforZ2Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB25Text, this.FacilityBText.SubTitleColor2);
                            this.FacilityBText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FB26 == true && StaticMethods.PointInRectangle(position, this.FacilityforB26DisplayPosition))
                        {
                            this.FacilityBText.Clear();
                            this.FacilityBText.AddText(FacilityforZ1Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB26, this.FacilityBText.SubTitleColor);
                            if (FBN26 > 1)
                            {
                                this.FacilityBText.AddNewLine();
                                this.FacilityBText.AddText(FacilityforZ3Text, this.FacilityBText.TitleColor);
                                this.FacilityBText.AddText(FBN26.ToString(), this.FacilityBText.SubTitleColor3);
                            }
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforZ2Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB26Text, this.FacilityBText.SubTitleColor2);
                            this.FacilityBText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FB27 == true && StaticMethods.PointInRectangle(position, this.FacilityforB27DisplayPosition))
                        {
                            this.FacilityBText.Clear();
                            this.FacilityBText.AddText(FacilityforZ1Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB27, this.FacilityBText.SubTitleColor);
                            if (FBN27 > 1)
                            {
                                this.FacilityBText.AddNewLine();
                                this.FacilityBText.AddText(FacilityforZ3Text, this.FacilityBText.TitleColor);
                                this.FacilityBText.AddText(FBN27.ToString(), this.FacilityBText.SubTitleColor3);
                            }
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforZ2Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB27Text, this.FacilityBText.SubTitleColor2);
                            this.FacilityBText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FB28 == true && StaticMethods.PointInRectangle(position, this.FacilityforB28DisplayPosition))
                        {
                            this.FacilityBText.Clear();
                            this.FacilityBText.AddText(FacilityforZ1Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB28, this.FacilityBText.SubTitleColor);
                            if (FBN28 > 1)
                            {
                                this.FacilityBText.AddNewLine();
                                this.FacilityBText.AddText(FacilityforZ3Text, this.FacilityBText.TitleColor);
                                this.FacilityBText.AddText(FBN28.ToString(), this.FacilityBText.SubTitleColor3);
                            }
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforZ2Text, this.FacilityBText.TitleColor);
                            this.FacilityBText.AddNewLine();
                            this.FacilityBText.AddText(FacilityforB28Text, this.FacilityBText.SubTitleColor2);
                            this.FacilityBText.ResortTexts();
                            FacilityTexton = true;
                        }


                        flag2 = true;
                    }
                }
                if (!flag2)
                {
                    if (FacilityTexton == true)
                    {
                        FacilityTexton = false;
                        FacilityBText.Clear();
                    }
                }

            }


            //↓C区设施介绍
            if (FacilityforCButton == true)
            {
                bool flag3 = false;
                if (!flag3)
                {
                    if (FacilityTexton == false)
                    {
                        if (FC1 == true && StaticMethods.PointInRectangle(position, this.FacilityforC1DisplayPosition))
                        {
                            this.FacilityCText.Clear();
                            this.FacilityCText.AddText(FacilityforZ1Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC1, this.FacilityCText.SubTitleColor);
                            if (FCN1 > 1)
                            {
                                this.FacilityCText.AddNewLine();
                                this.FacilityCText.AddText(FacilityforZ3Text, this.FacilityCText.TitleColor);
                                this.FacilityCText.AddText(FCN1.ToString(), this.FacilityCText.SubTitleColor3);
                            }
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforZ2Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC1Text, this.FacilityCText.SubTitleColor2);
                            this.FacilityCText.ResortTexts();
                            FacilityTexton = true;

                        }
                        if (FC2 == true && StaticMethods.PointInRectangle(position, this.FacilityforC2DisplayPosition))
                        {
                            this.FacilityCText.Clear();
                            this.FacilityCText.AddText(FacilityforZ1Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC2, this.FacilityCText.SubTitleColor);
                            if (FCN2 > 1)
                            {
                                this.FacilityCText.AddNewLine();
                                this.FacilityCText.AddText(FacilityforZ3Text, this.FacilityCText.TitleColor);
                                this.FacilityCText.AddText(FCN2.ToString(), this.FacilityCText.SubTitleColor3);
                            }
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforZ2Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC2Text, this.FacilityCText.SubTitleColor2);
                            this.FacilityCText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FC3 == true && StaticMethods.PointInRectangle(position, this.FacilityforC3DisplayPosition))
                        {
                            this.FacilityCText.Clear();
                            this.FacilityCText.AddText(FacilityforZ1Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC3, this.FacilityCText.SubTitleColor);
                            if (FCN3 > 1)
                            {
                                this.FacilityCText.AddNewLine();
                                this.FacilityCText.AddText(FacilityforZ3Text, this.FacilityCText.TitleColor);
                                this.FacilityCText.AddText(FCN3.ToString(), this.FacilityCText.SubTitleColor3);
                            }
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforZ2Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC3Text, this.FacilityCText.SubTitleColor2);
                            this.FacilityCText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FC4 == true && StaticMethods.PointInRectangle(position, this.FacilityforC4DisplayPosition))
                        {
                            this.FacilityCText.Clear();
                            this.FacilityCText.AddText(FacilityforZ1Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC4, this.FacilityCText.SubTitleColor);
                            if (FCN4 > 1)
                            {
                                this.FacilityCText.AddNewLine();
                                this.FacilityCText.AddText(FacilityforZ3Text, this.FacilityCText.TitleColor);
                                this.FacilityCText.AddText(FCN4.ToString(), this.FacilityCText.SubTitleColor3);
                            }
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforZ2Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC4Text, this.FacilityCText.SubTitleColor2);
                            this.FacilityCText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FC5 = true && StaticMethods.PointInRectangle(position, this.FacilityforC5DisplayPosition))
                        {
                            this.FacilityCText.Clear();
                            this.FacilityCText.AddText(FacilityforZ1Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC5, this.FacilityCText.SubTitleColor);
                            if (FCN5 > 1)
                            {
                                this.FacilityCText.AddNewLine();
                                this.FacilityCText.AddText(FacilityforZ3Text, this.FacilityCText.TitleColor);
                                this.FacilityCText.AddText(FCN5.ToString(), this.FacilityCText.SubTitleColor3);
                            }
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforZ2Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC5Text, this.FacilityCText.SubTitleColor2);
                            this.FacilityCText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FC6 == true && StaticMethods.PointInRectangle(position, this.FacilityforC6DisplayPosition))
                        {
                            this.FacilityCText.Clear();
                            this.FacilityCText.AddText(FacilityforZ1Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC6, this.FacilityCText.SubTitleColor);
                            if (FCN6 > 1)
                            {
                                this.FacilityCText.AddNewLine();
                                this.FacilityCText.AddText(FacilityforZ3Text, this.FacilityCText.TitleColor);
                                this.FacilityCText.AddText(FCN6.ToString(), this.FacilityCText.SubTitleColor3);
                            }
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforZ2Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC6Text, this.FacilityCText.SubTitleColor2);
                            this.FacilityCText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FC7 == true && StaticMethods.PointInRectangle(position, this.FacilityforC7DisplayPosition))
                        {
                            this.FacilityCText.Clear();
                            this.FacilityCText.AddText(FacilityforZ1Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC7, this.FacilityCText.SubTitleColor);
                            if (FCN7 > 1)
                            {
                                this.FacilityCText.AddNewLine();
                                this.FacilityCText.AddText(FacilityforZ3Text, this.FacilityCText.TitleColor);
                                this.FacilityCText.AddText(FCN7.ToString(), this.FacilityCText.SubTitleColor3);
                            }
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforZ2Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC7Text, this.FacilityCText.SubTitleColor2);
                            this.FacilityCText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FC8 == true && StaticMethods.PointInRectangle(position, this.FacilityforC8DisplayPosition))
                        {
                            this.FacilityCText.Clear();
                            this.FacilityCText.AddText(FacilityforZ1Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC8, this.FacilityCText.SubTitleColor);
                            if (FCN8 > 1)
                            {
                                this.FacilityCText.AddNewLine();
                                this.FacilityCText.AddText(FacilityforZ3Text, this.FacilityCText.TitleColor);
                                this.FacilityCText.AddText(FCN8.ToString(), this.FacilityCText.SubTitleColor3);
                            }
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforZ2Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC8Text, this.FacilityCText.SubTitleColor2);
                            this.FacilityCText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FC9 == true && StaticMethods.PointInRectangle(position, this.FacilityforC9DisplayPosition))
                        {
                            this.FacilityCText.Clear();
                            this.FacilityCText.AddText(FacilityforZ1Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC9, this.FacilityCText.SubTitleColor);
                            if (FCN9 > 1)
                            {
                                this.FacilityCText.AddNewLine();
                                this.FacilityCText.AddText(FacilityforZ3Text, this.FacilityCText.TitleColor);
                                this.FacilityCText.AddText(FCN9.ToString(), this.FacilityCText.SubTitleColor3);
                            }
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforZ2Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC9Text, this.FacilityCText.SubTitleColor2);
                            this.FacilityCText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FC10 == true && StaticMethods.PointInRectangle(position, this.FacilityforC10DisplayPosition))
                        {
                            this.FacilityCText.Clear();
                            this.FacilityCText.AddText(FacilityforZ1Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC10, this.FacilityCText.SubTitleColor);
                            if (FCN10 > 1)
                            {
                                this.FacilityCText.AddNewLine();
                                this.FacilityCText.AddText(FacilityforZ3Text, this.FacilityCText.TitleColor);
                                this.FacilityCText.AddText(FCN10.ToString(), this.FacilityCText.SubTitleColor3);
                            }
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforZ2Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC10Text, this.FacilityCText.SubTitleColor2);
                            this.FacilityCText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FC11 == true && StaticMethods.PointInRectangle(position, this.FacilityforC11DisplayPosition))
                        {
                            this.FacilityCText.Clear();
                            this.FacilityCText.AddText(FacilityforZ1Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC11, this.FacilityCText.SubTitleColor);
                            if (FCN11 > 1)
                            {
                                this.FacilityCText.AddNewLine();
                                this.FacilityCText.AddText(FacilityforZ3Text, this.FacilityCText.TitleColor);
                                this.FacilityCText.AddText(FCN11.ToString(), this.FacilityCText.SubTitleColor3);
                            }
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforZ2Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC11Text, this.FacilityCText.SubTitleColor2);
                            this.FacilityCText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FC12 == true && StaticMethods.PointInRectangle(position, this.FacilityforC12DisplayPosition))
                        {
                            this.FacilityCText.Clear();
                            this.FacilityCText.AddText(FacilityforZ1Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC12, this.FacilityCText.SubTitleColor);
                            if (FCN12 > 1)
                            {
                                this.FacilityCText.AddNewLine();
                                this.FacilityCText.AddText(FacilityforZ3Text, this.FacilityCText.TitleColor);
                                this.FacilityCText.AddText(FCN12.ToString(), this.FacilityCText.SubTitleColor3);
                            }
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforZ2Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC12Text, this.FacilityCText.SubTitleColor2);
                            this.FacilityCText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FC13 == true && StaticMethods.PointInRectangle(position, this.FacilityforC13DisplayPosition))
                        {
                            this.FacilityCText.Clear();
                            this.FacilityCText.AddText(FacilityforZ1Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC13, this.FacilityCText.SubTitleColor);
                            if (FCN13 > 1)
                            {
                                this.FacilityCText.AddNewLine();
                                this.FacilityCText.AddText(FacilityforZ3Text, this.FacilityCText.TitleColor);
                                this.FacilityCText.AddText(FCN13.ToString(), this.FacilityCText.SubTitleColor3);
                            }
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforZ2Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC13Text, this.FacilityCText.SubTitleColor2);
                            this.FacilityCText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FC14 == true && StaticMethods.PointInRectangle(position, this.FacilityforC14DisplayPosition))
                        {
                            this.FacilityCText.Clear();
                            this.FacilityCText.AddText(FacilityforZ1Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC14, this.FacilityCText.SubTitleColor);
                            if (FCN14 > 1)
                            {
                                this.FacilityCText.AddNewLine();
                                this.FacilityCText.AddText(FacilityforZ3Text, this.FacilityCText.TitleColor);
                                this.FacilityCText.AddText(FCN14.ToString(), this.FacilityCText.SubTitleColor3);
                            }
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforZ2Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC14Text, this.FacilityCText.SubTitleColor2);
                            this.FacilityCText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FC15 == true && StaticMethods.PointInRectangle(position, this.FacilityforC15DisplayPosition))
                        {
                            this.FacilityCText.Clear();
                            this.FacilityCText.AddText(FacilityforZ1Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC15, this.FacilityCText.SubTitleColor);
                            if (FCN15 > 1)
                            {
                                this.FacilityCText.AddNewLine();
                                this.FacilityCText.AddText(FacilityforZ3Text, this.FacilityCText.TitleColor);
                                this.FacilityCText.AddText(FCN15.ToString(), this.FacilityCText.SubTitleColor3);
                            }
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforZ2Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC15Text, this.FacilityCText.SubTitleColor2);
                            this.FacilityCText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FC16 == true && StaticMethods.PointInRectangle(position, this.FacilityforC16DisplayPosition))
                        {
                            this.FacilityCText.Clear();
                            this.FacilityCText.AddText(FacilityforZ1Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC16, this.FacilityCText.SubTitleColor);
                            if (FCN16 > 1)
                            {
                                this.FacilityCText.AddNewLine();
                                this.FacilityCText.AddText(FacilityforZ3Text, this.FacilityCText.TitleColor);
                                this.FacilityCText.AddText(FCN16.ToString(), this.FacilityCText.SubTitleColor3);
                            }
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforZ2Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC16Text, this.FacilityCText.SubTitleColor2);
                            this.FacilityCText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FC17 == true && StaticMethods.PointInRectangle(position, this.FacilityforC17DisplayPosition))
                        {
                            this.FacilityCText.Clear();
                            this.FacilityCText.AddText(FacilityforZ1Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC17, this.FacilityCText.SubTitleColor);
                            if (FCN17 > 1)
                            {
                                this.FacilityCText.AddNewLine();
                                this.FacilityCText.AddText(FacilityforZ3Text, this.FacilityCText.TitleColor);
                                this.FacilityCText.AddText(FCN17.ToString(), this.FacilityCText.SubTitleColor3);
                            }
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforZ2Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC17Text, this.FacilityCText.SubTitleColor2);
                            this.FacilityCText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FC18 == true && StaticMethods.PointInRectangle(position, this.FacilityforC18DisplayPosition))
                        {
                            this.FacilityCText.Clear();
                            this.FacilityCText.AddText(FacilityforZ1Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC18, this.FacilityCText.SubTitleColor);
                            if (FCN18 > 1)
                            {
                                this.FacilityCText.AddNewLine();
                                this.FacilityCText.AddText(FacilityforZ3Text, this.FacilityCText.TitleColor);
                                this.FacilityCText.AddText(FCN18.ToString(), this.FacilityCText.SubTitleColor3);
                            }
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforZ2Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC18Text, this.FacilityCText.SubTitleColor2);
                            this.FacilityCText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FC19 == true && StaticMethods.PointInRectangle(position, this.FacilityforC19DisplayPosition))
                        {
                            this.FacilityCText.Clear();
                            this.FacilityCText.AddText(FacilityforZ1Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC19, this.FacilityCText.SubTitleColor);
                            if (FCN19 > 1)
                            {
                                this.FacilityCText.AddNewLine();
                                this.FacilityCText.AddText(FacilityforZ3Text, this.FacilityCText.TitleColor);
                                this.FacilityCText.AddText(FCN19.ToString(), this.FacilityCText.SubTitleColor3);
                            }
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforZ2Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC19Text, this.FacilityCText.SubTitleColor2);
                            this.FacilityCText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FC20 == true && StaticMethods.PointInRectangle(position, this.FacilityforC20DisplayPosition))
                        {
                            this.FacilityCText.Clear();
                            this.FacilityCText.AddText(FacilityforZ1Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC20, this.FacilityCText.SubTitleColor);
                            if (FCN20 > 1)
                            {
                                this.FacilityCText.AddNewLine();
                                this.FacilityCText.AddText(FacilityforZ3Text, this.FacilityCText.TitleColor);
                                this.FacilityCText.AddText(FCN20.ToString(), this.FacilityCText.SubTitleColor3);
                            }
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforZ2Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC20Text, this.FacilityCText.SubTitleColor2);
                            this.FacilityCText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FC21 == true && StaticMethods.PointInRectangle(position, this.FacilityforC21DisplayPosition))
                        {
                            this.FacilityCText.Clear();
                            this.FacilityCText.AddText(FacilityforZ1Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC21, this.FacilityCText.SubTitleColor);
                            if (FCN21 > 1)
                            {
                                this.FacilityCText.AddNewLine();
                                this.FacilityCText.AddText(FacilityforZ3Text, this.FacilityCText.TitleColor);
                                this.FacilityCText.AddText(FCN21.ToString(), this.FacilityCText.SubTitleColor3);
                            }
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforZ2Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC21Text, this.FacilityCText.SubTitleColor2);
                            this.FacilityCText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FC22 == true && StaticMethods.PointInRectangle(position, this.FacilityforC22DisplayPosition))
                        {
                            this.FacilityCText.Clear();
                            this.FacilityCText.AddText(FacilityforZ1Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC22, this.FacilityCText.SubTitleColor);
                            if (FCN22 > 1)
                            {
                                this.FacilityCText.AddNewLine();
                                this.FacilityCText.AddText(FacilityforZ3Text, this.FacilityCText.TitleColor);
                                this.FacilityCText.AddText(FCN22.ToString(), this.FacilityCText.SubTitleColor3);
                            }
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforZ2Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC22Text, this.FacilityCText.SubTitleColor2);
                            this.FacilityCText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FC23 == true && StaticMethods.PointInRectangle(position, this.FacilityforC23DisplayPosition))
                        {
                            this.FacilityCText.Clear();
                            this.FacilityCText.AddText(FacilityforZ1Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC23, this.FacilityCText.SubTitleColor);
                            if (FCN23 > 1)
                            {
                                this.FacilityCText.AddNewLine();
                                this.FacilityCText.AddText(FacilityforZ3Text, this.FacilityCText.TitleColor);
                                this.FacilityCText.AddText(FCN23.ToString(), this.FacilityCText.SubTitleColor3);
                            }
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforZ2Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC23Text, this.FacilityCText.SubTitleColor2);
                            this.FacilityCText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FC24 == true && StaticMethods.PointInRectangle(position, this.FacilityforC24DisplayPosition))
                        {
                            this.FacilityCText.Clear();
                            this.FacilityCText.AddText(FacilityforZ1Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC24, this.FacilityCText.SubTitleColor);
                            if (FCN24 > 1)
                            {
                                this.FacilityCText.AddNewLine();
                                this.FacilityCText.AddText(FacilityforZ3Text, this.FacilityCText.TitleColor);
                                this.FacilityCText.AddText(FCN24.ToString(), this.FacilityCText.SubTitleColor3);
                            }
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforZ2Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC24Text, this.FacilityCText.SubTitleColor2);
                            this.FacilityCText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FC25 == true && StaticMethods.PointInRectangle(position, this.FacilityforC25DisplayPosition))
                        {
                            this.FacilityCText.Clear();
                            this.FacilityCText.AddText(FacilityforZ1Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC25, this.FacilityCText.SubTitleColor);
                            if (FCN25 > 1)
                            {
                                this.FacilityCText.AddNewLine();
                                this.FacilityCText.AddText(FacilityforZ3Text, this.FacilityCText.TitleColor);
                                this.FacilityCText.AddText(FCN25.ToString(), this.FacilityCText.SubTitleColor3);
                            }
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforZ2Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC25Text, this.FacilityCText.SubTitleColor2);
                            this.FacilityCText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FC26 == true && StaticMethods.PointInRectangle(position, this.FacilityforC26DisplayPosition))
                        {
                            this.FacilityCText.Clear();
                            this.FacilityCText.AddText(FacilityforZ1Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC26, this.FacilityCText.SubTitleColor);
                            if (FCN26 > 1)
                            {
                                this.FacilityCText.AddNewLine();
                                this.FacilityCText.AddText(FacilityforZ3Text, this.FacilityCText.TitleColor);
                                this.FacilityCText.AddText(FCN26.ToString(), this.FacilityCText.SubTitleColor3);
                            }
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforZ2Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC26Text, this.FacilityCText.SubTitleColor2);
                            this.FacilityCText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FC27 == true && StaticMethods.PointInRectangle(position, this.FacilityforC27DisplayPosition))
                        {
                            this.FacilityCText.Clear();
                            this.FacilityCText.AddText(FacilityforZ1Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC27, this.FacilityCText.SubTitleColor);
                            if (FCN27 > 1)
                            {
                                this.FacilityCText.AddNewLine();
                                this.FacilityCText.AddText(FacilityforZ3Text, this.FacilityCText.TitleColor);
                                this.FacilityCText.AddText(FCN27.ToString(), this.FacilityCText.SubTitleColor3);
                            }
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforZ2Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC27Text, this.FacilityCText.SubTitleColor2);
                            this.FacilityCText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FC28 == true && StaticMethods.PointInRectangle(position, this.FacilityforC28DisplayPosition))
                        {
                            this.FacilityCText.Clear();
                            this.FacilityCText.AddText(FacilityforZ1Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC28, this.FacilityCText.SubTitleColor);
                            if (FCN28 > 1)
                            {
                                this.FacilityCText.AddNewLine();
                                this.FacilityCText.AddText(FacilityforZ3Text, this.FacilityCText.TitleColor);
                                this.FacilityCText.AddText(FCN28.ToString(), this.FacilityCText.SubTitleColor3);
                            }
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforZ2Text, this.FacilityCText.TitleColor);
                            this.FacilityCText.AddNewLine();
                            this.FacilityCText.AddText(FacilityforC28Text, this.FacilityCText.SubTitleColor2);
                            this.FacilityCText.ResortTexts();
                            FacilityTexton = true;
                        }
                        flag3 = true;
                    }
                }
                if (!flag3)
                {
                    if (FacilityTexton == true)
                    {
                        FacilityTexton = false;
                        FacilityCText.Clear();
                    }
                }

            }

            //↓D区设施介绍
            if (FacilityforDButton == true)
            {
                bool flag4 = false;
                if (!flag4)
                {
                    if (FacilityTexton == false)
                    {
                        if (FD1 == true && StaticMethods.PointInRectangle(position, this.FacilityforD1DisplayPosition))
                        {
                            this.FacilityDText.Clear();
                            this.FacilityDText.AddText(FacilityforZ1Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD1, this.FacilityDText.SubTitleColor);
                            if (FDN1 > 1)
                            {
                                this.FacilityDText.AddNewLine();
                                this.FacilityDText.AddText(FacilityforZ3Text, this.FacilityDText.TitleColor);
                                this.FacilityDText.AddText(FDN1.ToString(), this.FacilityDText.SubTitleColor3);
                            }
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforZ2Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD1Text, this.FacilityDText.SubTitleColor2);
                            this.FacilityDText.ResortTexts();
                            FacilityTexton = true;

                        }
                        if (FD2 == true && StaticMethods.PointInRectangle(position, this.FacilityforD2DisplayPosition))
                        {
                            this.FacilityDText.Clear();
                            this.FacilityDText.AddText(FacilityforZ1Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD2, this.FacilityDText.SubTitleColor);
                            if (FDN2 > 1)
                            {
                                this.FacilityDText.AddNewLine();
                                this.FacilityDText.AddText(FacilityforZ3Text, this.FacilityDText.TitleColor);
                                this.FacilityDText.AddText(FDN2.ToString(), this.FacilityDText.SubTitleColor3);
                            }
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforZ2Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD2Text, this.FacilityDText.SubTitleColor2);
                            this.FacilityDText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FD3 == true && StaticMethods.PointInRectangle(position, this.FacilityforD3DisplayPosition))
                        {
                            this.FacilityDText.Clear();
                            this.FacilityDText.AddText(FacilityforZ1Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD3, this.FacilityDText.SubTitleColor);
                            if (FDN3 > 1)
                            {
                                this.FacilityDText.AddNewLine();
                                this.FacilityDText.AddText(FacilityforZ3Text, this.FacilityDText.TitleColor);
                                this.FacilityDText.AddText(FDN3.ToString(), this.FacilityDText.SubTitleColor3);
                            }
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforZ2Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD3Text, this.FacilityDText.SubTitleColor2);
                            this.FacilityDText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FD4 == true && StaticMethods.PointInRectangle(position, this.FacilityforD4DisplayPosition))
                        {
                            this.FacilityDText.Clear();
                            this.FacilityDText.AddText(FacilityforZ1Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD4, this.FacilityDText.SubTitleColor);
                            if (FDN4 > 1)
                            {
                                this.FacilityDText.AddNewLine();
                                this.FacilityDText.AddText(FacilityforZ3Text, this.FacilityDText.TitleColor);
                                this.FacilityDText.AddText(FDN4.ToString(), this.FacilityDText.SubTitleColor3);
                            }
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforZ2Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD4Text, this.FacilityDText.SubTitleColor2);
                            this.FacilityDText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FD5 = true && StaticMethods.PointInRectangle(position, this.FacilityforD5DisplayPosition))
                        {
                            this.FacilityDText.Clear();
                            this.FacilityDText.AddText(FacilityforZ1Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD5, this.FacilityDText.SubTitleColor);
                            if (FDN5 > 1)
                            {
                                this.FacilityDText.AddNewLine();
                                this.FacilityDText.AddText(FacilityforZ3Text, this.FacilityDText.TitleColor);
                                this.FacilityDText.AddText(FDN5.ToString(), this.FacilityDText.SubTitleColor3);
                            }
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforZ2Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD5Text, this.FacilityDText.SubTitleColor2);
                            this.FacilityDText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FD6 == true && StaticMethods.PointInRectangle(position, this.FacilityforD6DisplayPosition))
                        {
                            this.FacilityDText.Clear();
                            this.FacilityDText.AddText(FacilityforZ1Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD6, this.FacilityDText.SubTitleColor);
                            if (FDN6 > 1)
                            {
                                this.FacilityDText.AddNewLine();
                                this.FacilityDText.AddText(FacilityforZ3Text, this.FacilityDText.TitleColor);
                                this.FacilityDText.AddText(FDN6.ToString(), this.FacilityDText.SubTitleColor3);
                            }
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforZ2Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD6Text, this.FacilityDText.SubTitleColor2);
                            this.FacilityDText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FD7 == true && StaticMethods.PointInRectangle(position, this.FacilityforD7DisplayPosition))
                        {
                            this.FacilityDText.Clear();
                            this.FacilityDText.AddText(FacilityforZ1Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD7, this.FacilityDText.SubTitleColor);
                            if (FDN7 > 1)
                            {
                                this.FacilityDText.AddNewLine();
                                this.FacilityDText.AddText(FacilityforZ3Text, this.FacilityDText.TitleColor);
                                this.FacilityDText.AddText(FDN7.ToString(), this.FacilityDText.SubTitleColor3);
                            }
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforZ2Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD7Text, this.FacilityDText.SubTitleColor2);
                            this.FacilityDText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FD8 == true && StaticMethods.PointInRectangle(position, this.FacilityforD8DisplayPosition))
                        {
                            this.FacilityDText.Clear();
                            this.FacilityDText.AddText(FacilityforZ1Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD8, this.FacilityDText.SubTitleColor);
                            if (FDN8 > 1)
                            {
                                this.FacilityDText.AddNewLine();
                                this.FacilityDText.AddText(FacilityforZ3Text, this.FacilityDText.TitleColor);
                                this.FacilityDText.AddText(FDN8.ToString(), this.FacilityDText.SubTitleColor3);
                            }
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforZ2Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD8Text, this.FacilityDText.SubTitleColor2);
                            this.FacilityDText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FD9 == true && StaticMethods.PointInRectangle(position, this.FacilityforD9DisplayPosition))
                        {
                            this.FacilityDText.Clear();
                            this.FacilityDText.AddText(FacilityforZ1Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD9, this.FacilityDText.SubTitleColor);
                            if (FDN9 > 1)
                            {
                                this.FacilityDText.AddNewLine();
                                this.FacilityDText.AddText(FacilityforZ3Text, this.FacilityDText.TitleColor);
                                this.FacilityDText.AddText(FDN9.ToString(), this.FacilityDText.SubTitleColor3);
                            }
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforZ2Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD9Text, this.FacilityDText.SubTitleColor2);
                            this.FacilityDText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FD10 == true && StaticMethods.PointInRectangle(position, this.FacilityforD10DisplayPosition))
                        {
                            this.FacilityDText.Clear();
                            this.FacilityDText.AddText(FacilityforZ1Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD10, this.FacilityDText.SubTitleColor);
                            if (FDN10 > 1)
                            {
                                this.FacilityDText.AddNewLine();
                                this.FacilityDText.AddText(FacilityforZ3Text, this.FacilityDText.TitleColor);
                                this.FacilityDText.AddText(FDN10.ToString(), this.FacilityDText.SubTitleColor3);
                            }
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforZ2Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD10Text, this.FacilityDText.SubTitleColor2);
                            this.FacilityDText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FD11 == true && StaticMethods.PointInRectangle(position, this.FacilityforD11DisplayPosition))
                        {
                            this.FacilityDText.Clear();
                            this.FacilityDText.AddText(FacilityforZ1Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD11, this.FacilityDText.SubTitleColor);
                            if (FDN11 > 1)
                            {
                                this.FacilityDText.AddNewLine();
                                this.FacilityDText.AddText(FacilityforZ3Text, this.FacilityDText.TitleColor);
                                this.FacilityDText.AddText(FDN11.ToString(), this.FacilityDText.SubTitleColor3);
                            }
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforZ2Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD11Text, this.FacilityDText.SubTitleColor2);
                            this.FacilityDText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FD12 == true && StaticMethods.PointInRectangle(position, this.FacilityforD12DisplayPosition))
                        {
                            this.FacilityDText.Clear();
                            this.FacilityDText.AddText(FacilityforZ1Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD12, this.FacilityDText.SubTitleColor);
                            if (FDN12 > 1)
                            {
                                this.FacilityDText.AddNewLine();
                                this.FacilityDText.AddText(FacilityforZ3Text, this.FacilityDText.TitleColor);
                                this.FacilityDText.AddText(FDN12.ToString(), this.FacilityDText.SubTitleColor3);
                            }
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforZ2Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD12Text, this.FacilityDText.SubTitleColor2);
                            this.FacilityDText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FD13 == true && StaticMethods.PointInRectangle(position, this.FacilityforD13DisplayPosition))
                        {
                            this.FacilityDText.Clear();
                            this.FacilityDText.AddText(FacilityforZ1Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD13, this.FacilityDText.SubTitleColor);
                            if (FDN13 > 1)
                            {
                                this.FacilityDText.AddNewLine();
                                this.FacilityDText.AddText(FacilityforZ3Text, this.FacilityDText.TitleColor);
                                this.FacilityDText.AddText(FDN13.ToString(), this.FacilityDText.SubTitleColor3);
                            }
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforZ2Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD13Text, this.FacilityDText.SubTitleColor2);
                            this.FacilityDText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FD14 == true && StaticMethods.PointInRectangle(position, this.FacilityforD14DisplayPosition))
                        {
                            this.FacilityDText.Clear();
                            this.FacilityDText.AddText(FacilityforZ1Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD14, this.FacilityDText.SubTitleColor);
                            if (FDN14 > 1)
                            {
                                this.FacilityDText.AddNewLine();
                                this.FacilityDText.AddText(FacilityforZ3Text, this.FacilityDText.TitleColor);
                                this.FacilityDText.AddText(FDN14.ToString(), this.FacilityDText.SubTitleColor3);
                            }
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforZ2Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD14Text, this.FacilityDText.SubTitleColor2);
                            this.FacilityDText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FD15 == true && StaticMethods.PointInRectangle(position, this.FacilityforD15DisplayPosition))
                        {
                            this.FacilityDText.Clear();
                            this.FacilityDText.AddText(FacilityforZ1Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD15, this.FacilityDText.SubTitleColor);
                            if (FDN15 > 1)
                            {
                                this.FacilityDText.AddNewLine();
                                this.FacilityDText.AddText(FacilityforZ3Text, this.FacilityDText.TitleColor);
                                this.FacilityDText.AddText(FDN15.ToString(), this.FacilityDText.SubTitleColor3);
                            }
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforZ2Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD15Text, this.FacilityDText.SubTitleColor2);
                            this.FacilityDText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FD16 == true && StaticMethods.PointInRectangle(position, this.FacilityforD16DisplayPosition))
                        {
                            this.FacilityDText.Clear();
                            this.FacilityDText.AddText(FacilityforZ1Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD16, this.FacilityDText.SubTitleColor);
                            if (FDN16 > 1)
                            {
                                this.FacilityDText.AddNewLine();
                                this.FacilityDText.AddText(FacilityforZ3Text, this.FacilityDText.TitleColor);
                                this.FacilityDText.AddText(FDN16.ToString(), this.FacilityDText.SubTitleColor3);
                            }
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforZ2Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD16Text, this.FacilityDText.SubTitleColor2);
                            this.FacilityDText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FD17 == true && StaticMethods.PointInRectangle(position, this.FacilityforD17DisplayPosition))
                        {
                            this.FacilityDText.Clear();
                            this.FacilityDText.AddText(FacilityforZ1Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD17, this.FacilityDText.SubTitleColor);
                            if (FDN17 > 1)
                            {
                                this.FacilityDText.AddNewLine();
                                this.FacilityDText.AddText(FacilityforZ3Text, this.FacilityDText.TitleColor);
                                this.FacilityDText.AddText(FDN17.ToString(), this.FacilityDText.SubTitleColor3);
                            }
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforZ2Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD17Text, this.FacilityDText.SubTitleColor2);
                            this.FacilityDText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FD18 == true && StaticMethods.PointInRectangle(position, this.FacilityforD18DisplayPosition))
                        {
                            this.FacilityDText.Clear();
                            this.FacilityDText.AddText(FacilityforZ1Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD18, this.FacilityDText.SubTitleColor);
                            if (FDN18 > 1)
                            {
                                this.FacilityDText.AddNewLine();
                                this.FacilityDText.AddText(FacilityforZ3Text, this.FacilityDText.TitleColor);
                                this.FacilityDText.AddText(FDN18.ToString(), this.FacilityDText.SubTitleColor3);
                            }
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforZ2Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD18Text, this.FacilityDText.SubTitleColor2);
                            this.FacilityDText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FD19 == true && StaticMethods.PointInRectangle(position, this.FacilityforD19DisplayPosition))
                        {
                            this.FacilityDText.Clear();
                            this.FacilityDText.AddText(FacilityforZ1Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD19, this.FacilityDText.SubTitleColor);
                            if (FDN19 > 1)
                            {
                                this.FacilityDText.AddNewLine();
                                this.FacilityDText.AddText(FacilityforZ3Text, this.FacilityDText.TitleColor);
                                this.FacilityDText.AddText(FDN19.ToString(), this.FacilityDText.SubTitleColor3);
                            }
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforZ2Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD19Text, this.FacilityDText.SubTitleColor2);
                            this.FacilityDText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FD20 == true && StaticMethods.PointInRectangle(position, this.FacilityforD20DisplayPosition))
                        {
                            this.FacilityDText.Clear();
                            this.FacilityDText.AddText(FacilityforZ1Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD20, this.FacilityDText.SubTitleColor);
                            if (FDN20 > 1)
                            {
                                this.FacilityDText.AddNewLine();
                                this.FacilityDText.AddText(FacilityforZ3Text, this.FacilityDText.TitleColor);
                                this.FacilityDText.AddText(FDN20.ToString(), this.FacilityDText.SubTitleColor3);
                            }
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforZ2Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD20Text, this.FacilityDText.SubTitleColor2);
                            this.FacilityDText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FD21 == true && StaticMethods.PointInRectangle(position, this.FacilityforD21DisplayPosition))
                        {
                            this.FacilityDText.Clear();
                            this.FacilityDText.AddText(FacilityforZ1Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD21, this.FacilityDText.SubTitleColor);
                            if (FDN21 > 1)
                            {
                                this.FacilityDText.AddNewLine();
                                this.FacilityDText.AddText(FacilityforZ3Text, this.FacilityDText.TitleColor);
                                this.FacilityDText.AddText(FDN21.ToString(), this.FacilityDText.SubTitleColor3);
                            }
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforZ2Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD21Text, this.FacilityDText.SubTitleColor2);
                            this.FacilityDText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FD22 == true && StaticMethods.PointInRectangle(position, this.FacilityforD22DisplayPosition))
                        {
                            this.FacilityDText.Clear();
                            this.FacilityDText.AddText(FacilityforZ1Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD22, this.FacilityDText.SubTitleColor);
                            if (FDN22 > 1)
                            {
                                this.FacilityDText.AddNewLine();
                                this.FacilityDText.AddText(FacilityforZ3Text, this.FacilityDText.TitleColor);
                                this.FacilityDText.AddText(FDN22.ToString(), this.FacilityDText.SubTitleColor3);
                            }
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforZ2Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD22Text, this.FacilityDText.SubTitleColor2);
                            this.FacilityDText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FD23 == true && StaticMethods.PointInRectangle(position, this.FacilityforD23DisplayPosition))
                        {
                            this.FacilityDText.Clear();
                            this.FacilityDText.AddText(FacilityforZ1Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD23, this.FacilityDText.SubTitleColor);
                            if (FDN23 > 1)
                            {
                                this.FacilityDText.AddNewLine();
                                this.FacilityDText.AddText(FacilityforZ3Text, this.FacilityDText.TitleColor);
                                this.FacilityDText.AddText(FDN23.ToString(), this.FacilityDText.SubTitleColor3);
                            }
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforZ2Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD23Text, this.FacilityDText.SubTitleColor2);
                            this.FacilityDText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FD24 == true && StaticMethods.PointInRectangle(position, this.FacilityforD24DisplayPosition))
                        {
                            this.FacilityDText.Clear();
                            this.FacilityDText.AddText(FacilityforZ1Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD24, this.FacilityDText.SubTitleColor);
                            if (FDN24 > 1)
                            {
                                this.FacilityDText.AddNewLine();
                                this.FacilityDText.AddText(FacilityforZ3Text, this.FacilityDText.TitleColor);
                                this.FacilityDText.AddText(FDN24.ToString(), this.FacilityDText.SubTitleColor3);
                            }
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforZ2Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD24Text, this.FacilityDText.SubTitleColor2);
                            this.FacilityDText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FD25 == true && StaticMethods.PointInRectangle(position, this.FacilityforD25DisplayPosition))
                        {
                            this.FacilityDText.Clear();
                            this.FacilityDText.AddText(FacilityforZ1Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD25, this.FacilityDText.SubTitleColor);
                            if (FDN25 > 1)
                            {
                                this.FacilityDText.AddNewLine();
                                this.FacilityDText.AddText(FacilityforZ3Text, this.FacilityDText.TitleColor);
                                this.FacilityDText.AddText(FDN25.ToString(), this.FacilityDText.SubTitleColor3);
                            }
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforZ2Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD25Text, this.FacilityDText.SubTitleColor2);
                            this.FacilityDText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FD26 == true && StaticMethods.PointInRectangle(position, this.FacilityforD26DisplayPosition))
                        {
                            this.FacilityDText.Clear();
                            this.FacilityDText.AddText(FacilityforZ1Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD26, this.FacilityDText.SubTitleColor);
                            if (FDN26 > 1)
                            {
                                this.FacilityDText.AddNewLine();
                                this.FacilityDText.AddText(FacilityforZ3Text, this.FacilityDText.TitleColor);
                                this.FacilityDText.AddText(FDN26.ToString(), this.FacilityDText.SubTitleColor3);
                            }
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforZ2Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD26Text, this.FacilityDText.SubTitleColor2);
                            this.FacilityDText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FD27 == true && StaticMethods.PointInRectangle(position, this.FacilityforD27DisplayPosition))
                        {
                            this.FacilityDText.Clear();
                            this.FacilityDText.AddText(FacilityforZ1Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD27, this.FacilityDText.SubTitleColor);
                            if (FDN27 > 1)
                            {
                                this.FacilityDText.AddNewLine();
                                this.FacilityDText.AddText(FacilityforZ3Text, this.FacilityDText.TitleColor);
                                this.FacilityDText.AddText(FDN27.ToString(), this.FacilityDText.SubTitleColor3);
                            }
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforZ2Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD27Text, this.FacilityDText.SubTitleColor2);
                            this.FacilityDText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FD28 == true && StaticMethods.PointInRectangle(position, this.FacilityforD28DisplayPosition))
                        {
                            this.FacilityDText.Clear();
                            this.FacilityDText.AddText(FacilityforZ1Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD28, this.FacilityDText.SubTitleColor);
                            if (FDN28 > 1)
                            {
                                this.FacilityDText.AddNewLine();
                                this.FacilityDText.AddText(FacilityforZ3Text, this.FacilityDText.TitleColor);
                                this.FacilityDText.AddText(FDN28.ToString(), this.FacilityDText.SubTitleColor3);
                            }
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforZ2Text, this.FacilityDText.TitleColor);
                            this.FacilityDText.AddNewLine();
                            this.FacilityDText.AddText(FacilityforD28Text, this.FacilityDText.SubTitleColor2);
                            this.FacilityDText.ResortTexts();
                            FacilityTexton = true;
                        }
                        flag4 = true;
                    }
                }
                if (!flag4)
                {
                    if (FacilityTexton == true)
                    {
                        FacilityTexton = false;
                        FacilityDText.Clear();
                    }
                }

            }

            //↓E区设施介绍
            if (FacilityforEButton == true)
            {
                bool flag5 = false;
                if (!flag5)
                {
                    if (FacilityTexton == false)
                    {
                        if (FE1 == true && StaticMethods.PointInRectangle(position, this.FacilityforE1DisplayPosition))
                        {
                            this.FacilityEText.Clear();
                            this.FacilityEText.AddText(FacilityforZ1Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE1, this.FacilityEText.SubTitleColor);
                            if (FEN1 > 1)
                            {
                                this.FacilityEText.AddNewLine();
                                this.FacilityEText.AddText(FacilityforZ3Text, this.FacilityEText.TitleColor);
                                this.FacilityEText.AddText(FEN1.ToString(), this.FacilityEText.SubTitleColor3);
                            }
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforZ2Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE1Text, this.FacilityEText.SubTitleColor2);
                            this.FacilityEText.ResortTexts();
                            FacilityTexton = true;

                        }
                        if (FE2 == true && StaticMethods.PointInRectangle(position, this.FacilityforE2DisplayPosition))
                        {
                            this.FacilityEText.Clear();
                            this.FacilityEText.AddText(FacilityforZ1Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE2, this.FacilityEText.SubTitleColor);
                            if (FEN2 > 1)
                            {
                                this.FacilityEText.AddNewLine();
                                this.FacilityEText.AddText(FacilityforZ3Text, this.FacilityEText.TitleColor);
                                this.FacilityEText.AddText(FEN2.ToString(), this.FacilityEText.SubTitleColor3);
                            }
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforZ2Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE2Text, this.FacilityEText.SubTitleColor2);
                            this.FacilityEText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FE3 == true && StaticMethods.PointInRectangle(position, this.FacilityforE3DisplayPosition))
                        {
                            this.FacilityEText.Clear();
                            this.FacilityEText.AddText(FacilityforZ1Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE3, this.FacilityEText.SubTitleColor);
                            if (FEN3 > 1)
                            {
                                this.FacilityEText.AddNewLine();
                                this.FacilityEText.AddText(FacilityforZ3Text, this.FacilityEText.TitleColor);
                                this.FacilityEText.AddText(FEN3.ToString(), this.FacilityEText.SubTitleColor3);
                            }
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforZ2Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE3Text, this.FacilityEText.SubTitleColor2);
                            this.FacilityEText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FE4 == true && StaticMethods.PointInRectangle(position, this.FacilityforE4DisplayPosition))
                        {
                            this.FacilityEText.Clear();
                            this.FacilityEText.AddText(FacilityforZ1Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE4, this.FacilityEText.SubTitleColor);
                            if (FEN4 > 1)
                            {
                                this.FacilityEText.AddNewLine();
                                this.FacilityEText.AddText(FacilityforZ3Text, this.FacilityEText.TitleColor);
                                this.FacilityEText.AddText(FEN4.ToString(), this.FacilityEText.SubTitleColor3);
                            }
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforZ2Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE4Text, this.FacilityEText.SubTitleColor2);
                            this.FacilityEText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FE5 = true && StaticMethods.PointInRectangle(position, this.FacilityforE5DisplayPosition))
                        {
                            this.FacilityEText.Clear();
                            this.FacilityEText.AddText(FacilityforZ1Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE5, this.FacilityEText.SubTitleColor);
                            if (FEN5 > 1)
                            {
                                this.FacilityEText.AddNewLine();
                                this.FacilityEText.AddText(FacilityforZ3Text, this.FacilityEText.TitleColor);
                                this.FacilityEText.AddText(FEN5.ToString(), this.FacilityEText.SubTitleColor3);
                            }
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforZ2Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE5Text, this.FacilityEText.SubTitleColor2);
                            this.FacilityEText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FE6 == true && StaticMethods.PointInRectangle(position, this.FacilityforE6DisplayPosition))
                        {
                            this.FacilityEText.Clear();
                            this.FacilityEText.AddText(FacilityforZ1Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE6, this.FacilityEText.SubTitleColor);
                            if (FEN6 > 1)
                            {
                                this.FacilityEText.AddNewLine();
                                this.FacilityEText.AddText(FacilityforZ3Text, this.FacilityEText.TitleColor);
                                this.FacilityEText.AddText(FEN6.ToString(), this.FacilityEText.SubTitleColor3);
                            }
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforZ2Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE6Text, this.FacilityEText.SubTitleColor2);
                            this.FacilityEText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FE7 == true && StaticMethods.PointInRectangle(position, this.FacilityforE7DisplayPosition))
                        {
                            this.FacilityEText.Clear();
                            this.FacilityEText.AddText(FacilityforZ1Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE7, this.FacilityEText.SubTitleColor);
                            if (FEN7 > 1)
                            {
                                this.FacilityEText.AddNewLine();
                                this.FacilityEText.AddText(FacilityforZ3Text, this.FacilityEText.TitleColor);
                                this.FacilityEText.AddText(FEN7.ToString(), this.FacilityEText.SubTitleColor3);
                            }
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforZ2Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE7Text, this.FacilityEText.SubTitleColor2);
                            this.FacilityEText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FE8 == true && StaticMethods.PointInRectangle(position, this.FacilityforE8DisplayPosition))
                        {
                            this.FacilityEText.Clear();
                            this.FacilityEText.AddText(FacilityforZ1Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE8, this.FacilityEText.SubTitleColor);
                            if (FEN8 > 1)
                            {
                                this.FacilityEText.AddNewLine();
                                this.FacilityEText.AddText(FacilityforZ3Text, this.FacilityEText.TitleColor);
                                this.FacilityEText.AddText(FEN8.ToString(), this.FacilityEText.SubTitleColor3);
                            }
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforZ2Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE8Text, this.FacilityEText.SubTitleColor2);
                            this.FacilityEText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FE9 == true && StaticMethods.PointInRectangle(position, this.FacilityforE9DisplayPosition))
                        {
                            this.FacilityEText.Clear();
                            this.FacilityEText.AddText(FacilityforZ1Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE9, this.FacilityEText.SubTitleColor);
                            if (FEN9 > 1)
                            {
                                this.FacilityEText.AddNewLine();
                                this.FacilityEText.AddText(FacilityforZ3Text, this.FacilityEText.TitleColor);
                                this.FacilityEText.AddText(FEN9.ToString(), this.FacilityEText.SubTitleColor3);
                            }
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforZ2Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE9Text, this.FacilityEText.SubTitleColor2);
                            this.FacilityEText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FE10 == true && StaticMethods.PointInRectangle(position, this.FacilityforE10DisplayPosition))
                        {
                            this.FacilityEText.Clear();
                            this.FacilityEText.AddText(FacilityforZ1Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE10, this.FacilityEText.SubTitleColor);
                            if (FEN10 > 1)
                            {
                                this.FacilityEText.AddNewLine();
                                this.FacilityEText.AddText(FacilityforZ3Text, this.FacilityEText.TitleColor);
                                this.FacilityEText.AddText(FEN10.ToString(), this.FacilityEText.SubTitleColor3);
                            }
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforZ2Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE10Text, this.FacilityEText.SubTitleColor2);
                            this.FacilityEText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FE11 == true && StaticMethods.PointInRectangle(position, this.FacilityforE11DisplayPosition))
                        {
                            this.FacilityEText.Clear();
                            this.FacilityEText.AddText(FacilityforZ1Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE11, this.FacilityEText.SubTitleColor);
                            if (FEN11 > 1)
                            {
                                this.FacilityEText.AddNewLine();
                                this.FacilityEText.AddText(FacilityforZ3Text, this.FacilityEText.TitleColor);
                                this.FacilityEText.AddText(FEN11.ToString(), this.FacilityEText.SubTitleColor3);
                            }
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforZ2Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE11Text, this.FacilityEText.SubTitleColor2);
                            this.FacilityEText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FE12 == true && StaticMethods.PointInRectangle(position, this.FacilityforE12DisplayPosition))
                        {
                            this.FacilityEText.Clear();
                            this.FacilityEText.AddText(FacilityforZ1Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE12, this.FacilityEText.SubTitleColor);
                            if (FEN12 > 1)
                            {
                                this.FacilityEText.AddNewLine();
                                this.FacilityEText.AddText(FacilityforZ3Text, this.FacilityEText.TitleColor);
                                this.FacilityEText.AddText(FEN12.ToString(), this.FacilityEText.SubTitleColor3);
                            }
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforZ2Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE12Text, this.FacilityEText.SubTitleColor2);
                            this.FacilityEText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FE13 == true && StaticMethods.PointInRectangle(position, this.FacilityforE13DisplayPosition))
                        {
                            this.FacilityEText.Clear();
                            this.FacilityEText.AddText(FacilityforZ1Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE13, this.FacilityEText.SubTitleColor);
                            if (FEN13 > 1)
                            {
                                this.FacilityEText.AddNewLine();
                                this.FacilityEText.AddText(FacilityforZ3Text, this.FacilityEText.TitleColor);
                                this.FacilityEText.AddText(FEN13.ToString(), this.FacilityEText.SubTitleColor3);
                            }
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforZ2Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE13Text, this.FacilityEText.SubTitleColor2);
                            this.FacilityEText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FE14 == true && StaticMethods.PointInRectangle(position, this.FacilityforE14DisplayPosition))
                        {
                            this.FacilityEText.Clear();
                            this.FacilityEText.AddText(FacilityforZ1Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE14, this.FacilityEText.SubTitleColor);
                            if (FEN14 > 1)
                            {
                                this.FacilityEText.AddNewLine();
                                this.FacilityEText.AddText(FacilityforZ3Text, this.FacilityEText.TitleColor);
                                this.FacilityEText.AddText(FEN14.ToString(), this.FacilityEText.SubTitleColor3);
                            }
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforZ2Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE14Text, this.FacilityEText.SubTitleColor2);
                            this.FacilityEText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FE15 == true && StaticMethods.PointInRectangle(position, this.FacilityforE15DisplayPosition))
                        {
                            this.FacilityEText.Clear();
                            this.FacilityEText.AddText(FacilityforZ1Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE15, this.FacilityEText.SubTitleColor);
                            if (FEN15 > 1)
                            {
                                this.FacilityEText.AddNewLine();
                                this.FacilityEText.AddText(FacilityforZ3Text, this.FacilityEText.TitleColor);
                                this.FacilityEText.AddText(FEN15.ToString(), this.FacilityEText.SubTitleColor3);
                            }
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforZ2Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE15Text, this.FacilityEText.SubTitleColor2);
                            this.FacilityEText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FE16 == true && StaticMethods.PointInRectangle(position, this.FacilityforE16DisplayPosition))
                        {
                            this.FacilityEText.Clear();
                            this.FacilityEText.AddText(FacilityforZ1Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE16, this.FacilityEText.SubTitleColor);
                            if (FEN16 > 1)
                            {
                                this.FacilityEText.AddNewLine();
                                this.FacilityEText.AddText(FacilityforZ3Text, this.FacilityEText.TitleColor);
                                this.FacilityEText.AddText(FEN16.ToString(), this.FacilityEText.SubTitleColor3);
                            }
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforZ2Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE16Text, this.FacilityEText.SubTitleColor2);
                            this.FacilityEText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FE17 == true && StaticMethods.PointInRectangle(position, this.FacilityforE17DisplayPosition))
                        {
                            this.FacilityEText.Clear();
                            this.FacilityEText.AddText(FacilityforZ1Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE17, this.FacilityEText.SubTitleColor);
                            if (FEN17 > 1)
                            {
                                this.FacilityEText.AddNewLine();
                                this.FacilityEText.AddText(FacilityforZ3Text, this.FacilityEText.TitleColor);
                                this.FacilityEText.AddText(FEN17.ToString(), this.FacilityEText.SubTitleColor3);
                            }
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforZ2Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE17Text, this.FacilityEText.SubTitleColor2);
                            this.FacilityEText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FE18 == true && StaticMethods.PointInRectangle(position, this.FacilityforE18DisplayPosition))
                        {
                            this.FacilityEText.Clear();
                            this.FacilityEText.AddText(FacilityforZ1Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE18, this.FacilityEText.SubTitleColor);
                            if (FEN18 > 1)
                            {
                                this.FacilityEText.AddNewLine();
                                this.FacilityEText.AddText(FacilityforZ3Text, this.FacilityEText.TitleColor);
                                this.FacilityEText.AddText(FEN18.ToString(), this.FacilityEText.SubTitleColor3);
                            }
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforZ2Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE18Text, this.FacilityEText.SubTitleColor2);
                            this.FacilityEText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FE19 == true && StaticMethods.PointInRectangle(position, this.FacilityforE19DisplayPosition))
                        {
                            this.FacilityEText.Clear();
                            this.FacilityEText.AddText(FacilityforZ1Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE19, this.FacilityEText.SubTitleColor);
                            if (FEN19 > 1)
                            {
                                this.FacilityEText.AddNewLine();
                                this.FacilityEText.AddText(FacilityforZ3Text, this.FacilityEText.TitleColor);
                                this.FacilityEText.AddText(FEN19.ToString(), this.FacilityEText.SubTitleColor3);
                            }
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforZ2Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE19Text, this.FacilityEText.SubTitleColor2);
                            this.FacilityEText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FE20 == true && StaticMethods.PointInRectangle(position, this.FacilityforE20DisplayPosition))
                        {
                            this.FacilityEText.Clear();
                            this.FacilityEText.AddText(FacilityforZ1Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE20, this.FacilityEText.SubTitleColor);
                            if (FEN20 > 1)
                            {
                                this.FacilityEText.AddNewLine();
                                this.FacilityEText.AddText(FacilityforZ3Text, this.FacilityEText.TitleColor);
                                this.FacilityEText.AddText(FEN20.ToString(), this.FacilityEText.SubTitleColor3);
                            }
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforZ2Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE20Text, this.FacilityEText.SubTitleColor2);
                            this.FacilityEText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FE21 == true && StaticMethods.PointInRectangle(position, this.FacilityforE21DisplayPosition))
                        {
                            this.FacilityEText.Clear();
                            this.FacilityEText.AddText(FacilityforZ1Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE21, this.FacilityEText.SubTitleColor);
                            if (FEN21 > 1)
                            {
                                this.FacilityEText.AddNewLine();
                                this.FacilityEText.AddText(FacilityforZ3Text, this.FacilityEText.TitleColor);
                                this.FacilityEText.AddText(FEN21.ToString(), this.FacilityEText.SubTitleColor3);
                            }
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforZ2Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE21Text, this.FacilityEText.SubTitleColor2);
                            this.FacilityEText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FE22 == true && StaticMethods.PointInRectangle(position, this.FacilityforE22DisplayPosition))
                        {
                            this.FacilityEText.Clear();
                            this.FacilityEText.AddText(FacilityforZ1Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE22, this.FacilityEText.SubTitleColor);
                            if (FEN22 > 1)
                            {
                                this.FacilityEText.AddNewLine();
                                this.FacilityEText.AddText(FacilityforZ3Text, this.FacilityEText.TitleColor);
                                this.FacilityEText.AddText(FEN22.ToString(), this.FacilityEText.SubTitleColor3);
                            }
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforZ2Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE22Text, this.FacilityEText.SubTitleColor2);
                            this.FacilityEText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FE23 == true && StaticMethods.PointInRectangle(position, this.FacilityforE23DisplayPosition))
                        {
                            this.FacilityEText.Clear();
                            this.FacilityEText.AddText(FacilityforZ1Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE23, this.FacilityEText.SubTitleColor);
                            if (FEN23 > 1)
                            {
                                this.FacilityEText.AddNewLine();
                                this.FacilityEText.AddText(FacilityforZ3Text, this.FacilityEText.TitleColor);
                                this.FacilityEText.AddText(FEN23.ToString(), this.FacilityEText.SubTitleColor3);
                            }
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforZ2Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE23Text, this.FacilityEText.SubTitleColor2);
                            this.FacilityEText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FE24 == true && StaticMethods.PointInRectangle(position, this.FacilityforE24DisplayPosition))
                        {
                            this.FacilityEText.Clear();
                            this.FacilityEText.AddText(FacilityforZ1Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE24, this.FacilityEText.SubTitleColor);
                            if (FEN24 > 1)
                            {
                                this.FacilityEText.AddNewLine();
                                this.FacilityEText.AddText(FacilityforZ3Text, this.FacilityEText.TitleColor);
                                this.FacilityEText.AddText(FEN24.ToString(), this.FacilityEText.SubTitleColor3);
                            }
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforZ2Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE24Text, this.FacilityEText.SubTitleColor2);
                            this.FacilityEText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FE25 == true && StaticMethods.PointInRectangle(position, this.FacilityforE25DisplayPosition))
                        {
                            this.FacilityEText.Clear();
                            this.FacilityEText.AddText(FacilityforZ1Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE25, this.FacilityEText.SubTitleColor);
                            if (FEN25 > 1)
                            {
                                this.FacilityEText.AddNewLine();
                                this.FacilityEText.AddText(FacilityforZ3Text, this.FacilityEText.TitleColor);
                                this.FacilityEText.AddText(FEN25.ToString(), this.FacilityEText.SubTitleColor3);
                            }
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforZ2Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE25Text, this.FacilityEText.SubTitleColor2);
                            this.FacilityEText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FE26 == true && StaticMethods.PointInRectangle(position, this.FacilityforE26DisplayPosition))
                        {
                            this.FacilityEText.Clear();
                            this.FacilityEText.AddText(FacilityforZ1Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE26, this.FacilityEText.SubTitleColor);
                            if (FEN26 > 1)
                            {
                                this.FacilityEText.AddNewLine();
                                this.FacilityEText.AddText(FacilityforZ3Text, this.FacilityEText.TitleColor);
                                this.FacilityEText.AddText(FEN26.ToString(), this.FacilityEText.SubTitleColor3);
                            }
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforZ2Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE26Text, this.FacilityEText.SubTitleColor2);
                            this.FacilityEText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FE27 == true && StaticMethods.PointInRectangle(position, this.FacilityforE27DisplayPosition))
                        {
                            this.FacilityEText.Clear();
                            this.FacilityEText.AddText(FacilityforZ1Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE27, this.FacilityEText.SubTitleColor);
                            if (FEN27 > 1)
                            {
                                this.FacilityEText.AddNewLine();
                                this.FacilityEText.AddText(FacilityforZ3Text, this.FacilityEText.TitleColor);
                                this.FacilityEText.AddText(FEN27.ToString(), this.FacilityEText.SubTitleColor3);
                            }
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforZ2Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE27Text, this.FacilityEText.SubTitleColor2);
                            this.FacilityEText.ResortTexts();
                            FacilityTexton = true;
                        }
                        if (FE28 == true && StaticMethods.PointInRectangle(position, this.FacilityforE28DisplayPosition))
                        {
                            this.FacilityEText.Clear();
                            this.FacilityEText.AddText(FacilityforZ1Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE28, this.FacilityEText.SubTitleColor);
                            if (FEN28 > 1)
                            {
                                this.FacilityEText.AddNewLine();
                                this.FacilityEText.AddText(FacilityforZ3Text, this.FacilityEText.TitleColor);
                                this.FacilityEText.AddText(FEN28.ToString(), this.FacilityEText.SubTitleColor3);
                            }
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforZ2Text, this.FacilityEText.TitleColor);
                            this.FacilityEText.AddNewLine();
                            this.FacilityEText.AddText(FacilityforE28Text, this.FacilityEText.SubTitleColor2);
                            this.FacilityEText.ResortTexts();
                            FacilityTexton = true;
                        }



                        flag5 = true;
                    }
                }
                if (!flag5)
                {
                    if (FacilityTexton == true)
                    {
                        FacilityTexton = false;
                        FacilityEText.Clear();
                    }
                }

            }


            //↓在建设施介绍
       

            if (FacilityIng == true)
            {
                bool flag6 = false;
                if (!flag6)
                {
                    if (FacilityIngTexton == false)
                    {

                        if (StaticMethods.PointInRectangle(position, this.FacilityforIngDisplayPosition))
                        {
                            FacilityZText.Clear();
                            this.FacilityZText.AddText(FacilityforZ1Text, this.FacilityZText.TitleColor);
                            this.FacilityZText.AddNewLine();
                            this.FacilityZText.AddText(FacilityforIng, this.FacilityZText.SubTitleColor);
                            this.FacilityZText.AddNewLine();
                            this.FacilityZText.AddNewLine();
                            this.FacilityZText.AddText(FacilityforZ4Text, this.FacilityZText.SubTitleColor2);
                            this.FacilityZText.AddNewLine();
                            this.FacilityZText.AddNewLine();
                            this.FacilityZText.AddText(FacilityforZ5Text, this.FacilityZText.SubTitleColor2);
                            this.FacilityZText.AddText(FacilityforIngDay, this.FacilityZText.SubTitleColor3);
                            this.FacilityZText.AddText(FacilityforZ6Text, this.FacilityZText.SubTitleColor2);
                            this.FacilityZText.ResortTexts();
                            FacilityTexton = true;
                            FacilityIngTexton = true;
                        }
                        flag6 = true;
                    }
                   
                }
                if (!flag6)
                {
                    if (FacilityIngTexton == true)
                    {
                        
                        FacilityTexton = false;
                        FacilityIngTexton = false;
                        FacilityZText.Clear();

                    }
                }

            }


        }

        private void screen_OnMouseRightUp(Point position)
        {
            //↓相关数据重置
            ArchitectureButton = true;
            NewArchitectureButton = false;
            FacilityforAButton = false;
            FacilityforBButton = false;
            FacilityforCButton = false;
            FacilityforDButton = false;
            FacilityforEButton = false;
            FacilityforSButton = false;
            FacilityforIng = "0";
            FacilityforIngDay = "0";
            Characteristics = "0";
            PositionCounts = 0;
            ArchitectureID = 0;
            Bar1 = 0;
            Bar2 = 0;
            Bar3 = 0;
            Bar4 = 0;
            Bar5 = 0;
            Bar6 = 0;
            Bar7 = 0;
            Bar8 = 0;
            FA1 = false;
            FA2 = false;
            FA3 = false;
            FA4 = false;
            FA5 = false;
            FA6 = false;
            FA7 = false;
            FA8 = false;
            FA9 = false;
            FA10 = false;
            FA11 = false;
            FA12 = false;
            FA13 = false;
            FA14 = false;
            FA15 = false;
            FA16 = false;
            FA17 = false;
            FA18 = false;
            FA19 = false;
            FA20 = false;
            FA21 = false;
            FA22 = false;
            FA23 = false;
            FA24 = false;
            FA25 = false;
            FA26 = false;
            FA27 = false;
            FA28 = false;
            FB1 = false;
            FB2 = false;
            FB3 = false;
            FB4 = false;
            FB5 = false;
            FB6 = false;
            FB7 = false;
            FB8 = false;
            FB9 = false;
            FB10 = false;
            FB11 = false;
            FB12 = false;
            FB13 = false;
            FB14 = false;
            FB15 = false;
            FB16 = false;
            FB17 = false;
            FB18 = false;
            FB19 = false;
            FB20 = false;
            FB21 = false;
            FB22 = false;
            FB23 = false;
            FB24 = false;
            FB25 = false;
            FB26 = false;
            FB27 = false;
            FB28 = false;
            FC1 = false;
            FC2 = false;
            FC3 = false;
            FC4 = false;
            FC5 = false;
            FC6 = false;
            FC7 = false;
            FC8 = false;
            FC9 = false;
            FC10 = false;
            FC11 = false;
            FC12 = false;
            FC13 = false;
            FC14 = false;
            FC15 = false;
            FC16 = false;
            FC17 = false;
            FC18 = false;
            FC19 = false;
            FC20 = false;
            FC21 = false;
            FC22 = false;
            FC23 = false;
            FC24 = false;
            FC25 = false;
            FC26 = false;
            FC27 = false;
            FC28 = false;
            FD1 = false;
            FD2 = false;
            FD3 = false;
            FD4 = false;
            FD5 = false;
            FD6 = false;
            FD7 = false;
            FD8 = false;
            FD9 = false;
            FD10 = false;
            FD11 = false;
            FD12 = false;
            FD13 = false;
            FD14 = false;
            FD15 = false;
            FD16 = false;
            FD17 = false;
            FD18 = false;
            FD19 = false;
            FD20 = false;
            FD21 = false;
            FD22 = false;
            FD23 = false;
            FD24 = false;
            FD25 = false;
            FD26 = false;
            FD27 = false;
            FD28 = false;
            FE1 = false;
            FE2 = false;
            FE3 = false;
            FE4 = false;
            FE5 = false;
            FE6 = false;
            FE7 = false;
            FE8 = false;
            FE9 = false;
            FE10 = false;
            FE11 = false;
            FE12 = false;
            FE13 = false;
            FE14 = false;
            FE15 = false;
            FE16 = false;
            FE17 = false;
            FE18 = false;
            FE19 = false;
            FE20 = false;
            FE21 = false;
            FE22 = false;
            FE23 = false;
            FE24 = false;
            FE25 = false;
            FE26 = false;
            FE27 = false;
            FE28 = false;
            FAN1 = 0;
            FAN2 = 0;
            FAN3 = 0;
            FAN4 = 0;
            FAN5 = 0;
            FAN6 = 0;
            FAN7 = 0;
            FAN8 = 0;
            FAN9 = 0;
            FAN10 = 0;
            FAN11 = 0;
            FAN12 = 0;
            FAN13 = 0;
            FAN14 = 0;
            FAN15 = 0;
            FAN16 = 0;
            FAN17 = 0;
            FAN18 = 0;
            FAN19 = 0;
            FAN20 = 0;
            FAN21 = 0;
            FAN22 = 0;
            FAN23 = 0;
            FAN24 = 0;
            FAN25 = 0;
            FAN26 = 0;
            FAN27 = 0;
            FAN28 = 0;
            FBN1 = 0;
            FBN2 = 0;
            FBN3 = 0;
            FBN4 = 0;
            FBN5 = 0;
            FBN6 = 0;
            FBN7 = 0;
            FBN8 = 0;
            FBN9 = 0;
            FBN10 = 0;
            FBN11 = 0;
            FBN12 = 0;
            FBN13 = 0;
            FBN14 = 0;
            FBN15 = 0;
            FBN16 = 0;
            FBN17 = 0;
            FBN18 = 0;
            FBN19 = 0;
            FBN20 = 0;
            FBN21 = 0;
            FBN22 = 0;
            FBN23 = 0;
            FBN24 = 0;
            FBN25 = 0;
            FBN26 = 0;
            FBN27 = 0;
            FBN28 = 0;
            FCN1 = 0;
            FCN2 = 0;
            FCN3 = 0;
            FCN4 = 0;
            FCN5 = 0;
            FCN6 = 0;
            FCN7 = 0;
            FCN8 = 0;
            FCN9 = 0;
            FCN10 = 0;
            FCN11 = 0;
            FCN12 = 0;
            FCN13 = 0;
            FCN14 = 0;
            FCN15 = 0;
            FCN16 = 0;
            FCN17 = 0;
            FCN18 = 0;
            FCN19 = 0;
            FCN20 = 0;
            FCN21 = 0;
            FCN22 = 0;
            FCN23 = 0;
            FCN24 = 0;
            FCN25 = 0;
            FCN26 = 0;
            FCN27 = 0;
            FCN28 = 0;
            FDN1 = 0;
            FDN2 = 0;
            FDN3 = 0;
            FDN4 = 0;
            FDN5 = 0;
            FDN6 = 0;
            FDN7 = 0;
            FDN8 = 0;
            FDN9 = 0;
            FDN10 = 0;
            FDN11 = 0;
            FDN12 = 0;
            FDN13 = 0;
            FDN14 = 0;
            FDN15 = 0;
            FDN16 = 0;
            FDN17 = 0;
            FDN18 = 0;
            FDN19 = 0;
            FDN20 = 0;
            FDN21 = 0;
            FDN22 = 0;
            FDN23 = 0;
            FDN24 = 0;
            FDN25 = 0;
            FDN26 = 0;
            FDN27 = 0;
            FDN28 = 0;
            FEN1 = 0;
            FEN2 = 0;
            FEN3 = 0;
            FEN4 = 0;
            FEN5 = 0;
            FEN6 = 0;
            FEN7 = 0;
            FEN8 = 0;
            FEN9 = 0;
            FEN10 = 0;
            FEN11 = 0;
            FEN12 = 0;
            FEN13 = 0;
            FEN14 = 0;
            FEN15 = 0;
            FEN16 = 0;
            FEN17 = 0;
            FEN18 = 0;
            FEN19 = 0;
            FEN20 = 0;
            FEN21 = 0;
            FEN22 = 0;
            FEN23 = 0;
            FEN24 = 0;
            FEN25 = 0;
            FEN26 = 0;
            FEN27 = 0;
            FEN28 = 0;
            //
            //
            ACC1OK = false;
            ACC2OK = false;
            ACC3OK = false;
            ACC4OK = false;
            ACC5OK = false;
            ACC6OK = false;
            ACC7OK = false;
            ACC8OK = false;
            ACC9OK = false;
            ACC10OK = false;
            ACC11OK = false;
            ACC12OK = false;
            ACC13OK = false;
            ACC14OK = false;
            ACC15OK = false;
            ACC16OK = false;
            ACC17OK = false;
            ACC18OK = false;
            ACC19OK = false;
            ACC20OK = false;
            ACC21OK = false;
            ACC22OK = false;
            ACC23OK = false;
            ACC24OK = false;
            ACC25OK = false;
            ACC26OK = false;
            ACC27OK = false;
            ACC28OK = false;
            ACC29OK = false;
            ACC30OK = false;
            ACC31OK = false;
            ACC32OK = false;
            ACC33OK = false;
            ACC34OK = false;
            ACC35OK = false;
            ACC36OK = false;
            ACC37OK = false;
            ACC38OK = false;
            ACC39OK = false;
            ACC40OK = false;
            ACC41OK = false;
            ACC42OK = false;
            ACC43OK = false;
            ACC44OK = false;
            ACC45OK = false;
            ACC46OK = false;
            ACC47OK = false;
            ACC48OK = false;
            ACC49OK = false;
            ACC50OK = false;
            ACC51OK = false;
            ACC52OK = false;
            ACC53OK = false;
            ACC54OK = false;
            ACC55OK = false;
            ACC56OK = false;
            ACC57OK = false;
            ACC58OK = false;
            ACC59OK = false;
            ACC60OK = false;
            ACC61OK = false;
            ACC62OK = false;
            ACC63OK = false;
            ACC64OK = false;
            ACC65OK = false;
            ACC66OK = false;
            ACC67OK = false;
            ACC68OK = false;
            ACC69OK = false;
            ACC70OK = false;
            ACC71OK = false;
            ACC72OK = false;
            ACC73OK = false;
            ACC74OK = false;
            ACC75OK = false;
            ACC76OK = false;
            ACC77OK = false;
            ACC78OK = false;
            ACC79OK = false;
            ACC80OK = false;
            ACC81OK = false;
            ACC82OK = false;
            ACC83OK = false;
            ACC84OK = false;
            ACC85OK = false;
            ACC86OK = false;
            ACC87OK = false;
            ACC88OK = false;
            ACC89OK = false;
            ACC90OK = false;
            ACC91OK = false;
            ACC92OK = false;
            ACC93OK = false;
            ACC94OK = false;
            ACC95OK = false;
            ACC96OK = false;
            ACC97OK = false;
            ACC98OK = false;
            ACC99OK = false;
            ACC100OK = false;
            ACC101OK = false;
            ACC102OK = false;
            ACC103OK = false;
            ACC104OK = false;
            ACC105OK = false;
            ACC106OK = false;
            ACC107OK = false;
            ACC108OK = false;
            ACC109OK = false;
            ACC110OK = false;
            ACC111OK = false;
            ACC112OK = false;
            ACC113OK = false;
            ACC114OK = false;
            ACC115OK = false;
            ACC116OK = false;
            ACC117OK = false;
            ACC118OK = false;
            ACC119OK = false;
            ACC120OK = false;
            ACC121OK = false;
            ACC122OK = false;
            ACC123OK = false;
            ACC124OK = false;
            ACC125OK = false;
            ACC126OK = false;
            ACC127OK = false;
            ACC128OK = false;
            ACC129OK = false;
            ACC130OK = false;
            ACC131OK = false;
            ACC132OK = false;
            ACC133OK = false;
            ACC134OK = false;
            ACC135OK = false;
            ACC136OK = false;
            ACC137OK = false;
            ACC138OK = false;
            ACC139OK = false;
            ACC140OK = false;
            ACC141OK = false;
            ACC142OK = false;
            ACC143OK = false;
            ACC144OK = false;
            ACC145OK = false;
            ACC146OK = false;
            ACC147OK = false;
            ACC148OK = false;
            ACC149OK = false;
            ACC150OK = false;
            ACC151OK = false;
            ACC152OK = false;
            ACC153OK = false;
            ACC154OK = false;
            ACC155OK = false;
            ACC156OK = false;
            ACC157OK = false;
            ACC158OK = false;
            ACC159OK = false;
            ACC160OK = false;
            ACC161OK = false;
            ACC162OK = false;
            ACC163OK = false;
            ACC164OK = false;
            ACC165OK = false;
            ACC166OK = false;
            ACC167OK = false;
            ACC168OK = false;
            ACC169OK = false;
            ACC170OK = false;
            ACC171OK = false;
            ACC172OK = false;
            ACC173OK = false;
            ACC174OK = false;
            ACC175OK = false;
            ACC176OK = false;
            ACC177OK = false;
            ACC178OK = false;
            ACC179OK = false;
            ACC180OK = false;
            ACC181OK = false;
            ACC182OK = false;
            ACC183OK = false;
            ACC184OK = false;
            ACC185OK = false;
            ACC186OK = false;
            ACC187OK = false;
            ACC188OK = false;
            ACC189OK = false;
            ACC190OK = false;
            ACC191OK = false;
            ACC192OK = false;
            ACC193OK = false;
            ACC194OK = false;
            ACC195OK = false;
            ACC196OK = false;
            ACC197OK = false;
            ACC198OK = false;
            ACC199OK = false;
            ACC200OK = false;
            ACC201OK = false;
            ACC202OK = false;
            ACC203OK = false;
            ACC204OK = false;
            ACC205OK = false;
            ACC206OK = false;
            ACC207OK = false;
            ACC208OK = false;
            ACC209OK = false;
            ACC210OK = false;
            ACC211OK = false;
            ACC212OK = false;
            ACC213OK = false;
            ACC214OK = false;
            ACC215OK = false;
            ACC216OK = false;
            ACC217OK = false;
            ACC218OK = false;
            ACC219OK = false;
            ACC220OK = false;
            ACC221OK = false;
            ACC222OK = false;
            ACC223OK = false;
            ACC224OK = false;
            ACC225OK = false;
            ACC226OK = false;
            ACC227OK = false;
            ACC228OK = false;
            ACC229OK = false;
            ACC230OK = false;
            ACC231OK = false;
            ACC232OK = false;
            ACC233OK = false;
            ACC234OK = false;
            ACC235OK = false;
            ACC236OK = false;
            ACC237OK = false;
            ACC238OK = false;
            ACC239OK = false;
            ACC240OK = false;
            ACC241OK = false;
            ACC242OK = false;
            ACC243OK = false;
            ACC244OK = false;
            ACC245OK = false;
            ACC246OK = false;
            ACC247OK = false;
            ACC248OK = false;
            ACC249OK = false;
            ACC250OK = false;
            ACC251OK = false;
            ACC252OK = false;
            ACC253OK = false;
            ACC254OK = false;
            ACC255OK = false;
            ACC256OK = false;
            ACC257OK = false;
            ACC258OK = false;
            ACC259OK = false;
            ACC260OK = false;
            ACC261OK = false;
            ACC262OK = false;
            ACC263OK = false;
            ACC264OK = false;
            ACC265OK = false;
            ACC266OK = false;
            ACC267OK = false;
            ACC268OK = false;
            ACC269OK = false;
            ACC270OK = false;
            ACC271OK = false;
            ACC272OK = false;
            ACC273OK = false;
            ACC274OK = false;
            ACC275OK = false;
            ACC276OK = false;
            ACC277OK = false;
            ACC278OK = false;
            ACC279OK = false;
            ACC280OK = false;
            ACC281OK = false;
            ACC282OK = false;
            ACC283OK = false;
            ACC284OK = false;
            ACC285OK = false;
            ACC286OK = false;
            ACC287OK = false;
            ACC288OK = false;
            ACC289OK = false;
            ACC290OK = false;
            ACC291OK = false;
            ACC292OK = false;
            ACC293OK = false;
            ACC294OK = false;
            ACC295OK = false;
            ACC296OK = false;
            ACC297OK = false;
            ACC298OK = false;
            ACC299OK = false;
            ACC300OK = false;

            FacilityIng = false;
            FacilityTexton = false;
            FacilityIngTexton = false;
            //好多地方可以优化，但懒得优化了，先将就用着
            this.IsShowing = false;
        }

        internal void SetArchitecture(Architecture architecture)
        {

            
            this.ShowingArchitecture = architecture;

            //↓提取建筑ID、建筑种类、设施空间数据
            ArchitectureID = this.ShowingArchitecture.ID;
            AKinds = this.ShowingArchitecture.KindString;
            PositionCounts = this.ShowingArchitecture.FacilityPositionCount;

            //↓判定建筑ID图片
            if(Switch10 == "1")
            {
                if (ArchitectureID == AID1)
                {
                    AIDTexture = AID1Texture;
                }
                else if (ArchitectureID == AID2)
                {
                    AIDTexture = AID2Texture;
                }
                else if (ArchitectureID == AID3)
                {
                    AIDTexture = AID3Texture;
                }
                else if (ArchitectureID == AID4)
                {
                    AIDTexture = AID4Texture;
                }
                else if (ArchitectureID == AID5)
                {
                    AIDTexture = AID5Texture;
                }
                else if (ArchitectureID == AID6)
                {
                    AIDTexture = AID6Texture;
                }
                else if (ArchitectureID == AID7)
                {
                    AIDTexture = AID7Texture;
                }
                else if (ArchitectureID == AID8)
                {
                    AIDTexture = AID8Texture;
                }
                else if (ArchitectureID == AID9)
                {
                    AIDTexture = AID9Texture;
                }
                else if (ArchitectureID == AID10)
                {
                    AIDTexture = AID10Texture;
                }
                else if (ArchitectureID == AID11)
                {
                    AIDTexture = AID11Texture;
                }
                else if (ArchitectureID == AID12)
                {
                    AIDTexture = AID12Texture;
                }
                else if (ArchitectureID == AID13)
                {
                    AIDTexture = AID13Texture;
                }
                else if (ArchitectureID == AID14)
                {
                    AIDTexture = AID14Texture;
                }
                else if (ArchitectureID == AID15)
                {
                    AIDTexture = AID15Texture;
                }
                else if (ArchitectureID == AID16)
                {
                    AIDTexture = AID16Texture;
                }
                else if (ArchitectureID == AID17)
                {
                    AIDTexture = AID17Texture;
                }
                else if (ArchitectureID == AID18)
                {
                    AIDTexture = AID18Texture;
                }
                else if (ArchitectureID == AID19)
                {
                    AIDTexture = AID19Texture;
                }
                else if (ArchitectureID == AID20)
                {
                    AIDTexture = AID20Texture;
                }
                else if (ArchitectureID == AID21)
                {
                    AIDTexture = AID21Texture;
                }
                else if (ArchitectureID == AID22)
                {
                    AIDTexture = AID22Texture;
                }
                else if (ArchitectureID == AID23)
                {
                    AIDTexture = AID23Texture;
                }
                else if (ArchitectureID == AID24)
                {
                    AIDTexture = AID24Texture;
                }
                else if (ArchitectureID == AID25)
                {
                    AIDTexture = AID25Texture;
                }
                else if (ArchitectureID == AID26)
                {
                    AIDTexture = AID26Texture;
                }
                else if (ArchitectureID == AID27)
                {
                    AIDTexture = AID27Texture;
                }
                else if (ArchitectureID == AID28)
                {
                    AIDTexture = AID28Texture;
                }
                else if (ArchitectureID == AID29)
                {
                    AIDTexture = AID29Texture;
                }
                else if (ArchitectureID == AID30)
                {
                    AIDTexture = AID30Texture;
                }
                else if (ArchitectureID == AID31)
                {
                    AIDTexture = AID31Texture;
                }
                else if (ArchitectureID == AID32)
                {
                    AIDTexture = AID32Texture;
                }
                else if (ArchitectureID == AID33)
                {
                    AIDTexture = AID33Texture;
                }
                else if (ArchitectureID == AID34)
                {
                    AIDTexture = AID34Texture;
                }
                else if (ArchitectureID == AID35)
                {
                    AIDTexture = AID35Texture;
                }
                else if (ArchitectureID == AID36)
                {
                    AIDTexture = AID36Texture;
                }
                else if (ArchitectureID == AID37)
                {
                    AIDTexture = AID37Texture;
                }
                else if (ArchitectureID == AID38)
                {
                    AIDTexture = AID38Texture;
                }
                else if (ArchitectureID == AID39)
                {
                    AIDTexture = AID39Texture;
                }
                else if (ArchitectureID == AID40)
                {
                    AIDTexture = AID40Texture;
                }
                else if (ArchitectureID == AID41)
                {
                    AIDTexture = AID41Texture;
                }
                else if (ArchitectureID == AID42)
                {
                    AIDTexture = AID42Texture;
                }
                else if (ArchitectureID == AID43)
                {
                    AIDTexture = AID43Texture;
                }
                else if (ArchitectureID == AID44)
                {
                    AIDTexture = AID44Texture;
                }
                else if (ArchitectureID == AID45)
                {
                    AIDTexture = AID45Texture;
                }
                else if (ArchitectureID == AID46)
                {
                    AIDTexture = AID46Texture;
                }
                else if (ArchitectureID == AID47)
                {
                    AIDTexture = AID47Texture;
                }
                else if (ArchitectureID == AID48)
                {
                    AIDTexture = AID48Texture;
                }
                else if (ArchitectureID == AID49)
                {
                    AIDTexture = AID49Texture;
                }
                else if (ArchitectureID == AID50)
                {
                    AIDTexture = AID50Texture;
                }
                else if (ArchitectureID == AID51)
                {
                    AIDTexture = AID51Texture;
                }
                else if (ArchitectureID == AID52)
                {
                    AIDTexture = AID52Texture;
                }
                else if (ArchitectureID == AID53)
                {
                    AIDTexture = AID53Texture;
                }
                else if (ArchitectureID == AID54)
                {
                    AIDTexture = AID54Texture;
                }
                else if (ArchitectureID == AID55)
                {
                    AIDTexture = AID55Texture;
                }
                else if (ArchitectureID == AID56)
                {
                    AIDTexture = AID56Texture;
                }
                else if (ArchitectureID == AID57)
                {
                    AIDTexture = AID57Texture;
                }
                else if (ArchitectureID == AID58)
                {
                    AIDTexture = AID58Texture;
                }
                else if (ArchitectureID == AID59)
                {
                    AIDTexture = AID59Texture;
                }
                else if (ArchitectureID == AID60)
                {
                    AIDTexture = AID60Texture;
                }
                else if (ArchitectureID == AID61)
                {
                    AIDTexture = AID61Texture;
                }
                else if (ArchitectureID == AID62)
                {
                    AIDTexture = AID62Texture;
                }
                else if (ArchitectureID == AID63)
                {
                    AIDTexture = AID63Texture;
                }
                else if (ArchitectureID == AID64)
                {
                    AIDTexture = AID64Texture;
                }
                else if (ArchitectureID == AID65)
                {
                    AIDTexture = AID65Texture;
                }
                else if (ArchitectureID == AID66)
                {
                    AIDTexture = AID66Texture;
                }
                else if (ArchitectureID == AID67)
                {
                    AIDTexture = AID67Texture;
                }
                else if (ArchitectureID == AID68)
                {
                    AIDTexture = AID68Texture;
                }
                else if (ArchitectureID == AID69)
                {
                    AIDTexture = AID69Texture;
                }
                else if (ArchitectureID == AID70)
                {
                    AIDTexture = AID70Texture;
                }
                else if (ArchitectureID == AID71)
                {
                    AIDTexture = AID71Texture;
                }
                else if (ArchitectureID == AID72)
                {
                    AIDTexture = AID72Texture;
                }
                else if (ArchitectureID == AID73)
                {
                    AIDTexture = AID73Texture;
                }
                else if (ArchitectureID == AID74)
                {
                    AIDTexture = AID74Texture;
                }
                else if (ArchitectureID == AID75)
                {
                    AIDTexture = AID75Texture;
                }
                else if (ArchitectureID == AID76)
                {
                    AIDTexture = AID76Texture;
                }
                else if (ArchitectureID == AID77)
                {
                    AIDTexture = AID77Texture;
                }
                else if (ArchitectureID == AID78)
                {
                    AIDTexture = AID78Texture;
                }
                else if (ArchitectureID == AID79)
                {
                    AIDTexture = AID79Texture;
                }
                else if (ArchitectureID == AID80)
                {
                    AIDTexture = AID80Texture;
                }
                else if (ArchitectureID == AID81)
                {
                    AIDTexture = AID81Texture;
                }
                else if (ArchitectureID == AID82)
                {
                    AIDTexture = AID82Texture;
                }
                else if (ArchitectureID == AID83)
                {
                    AIDTexture = AID83Texture;
                }
                else if (ArchitectureID == AID84)
                {
                    AIDTexture = AID84Texture;
                }
                else if (ArchitectureID == AID85)
                {
                    AIDTexture = AID85Texture;
                }
                else if (ArchitectureID == AID86)
                {
                    AIDTexture = AID86Texture;
                }
                else if (ArchitectureID == AID87)
                {
                    AIDTexture = AID87Texture;
                }
                else if (ArchitectureID == AID88)
                {
                    AIDTexture = AID88Texture;
                }
                else if (ArchitectureID == AID89)
                {
                    AIDTexture = AID89Texture;
                }
                else if (ArchitectureID == AID90)
                {
                    AIDTexture = AID90Texture;
                }
                else if (ArchitectureID == AID91)
                {
                    AIDTexture = AID91Texture;
                }
                else if (ArchitectureID == AID92)
                {
                    AIDTexture = AID92Texture;
                }
                else if (ArchitectureID == AID93)
                {
                    AIDTexture = AID93Texture;
                }
                else if (ArchitectureID == AID94)
                {
                    AIDTexture = AID94Texture;
                }
                else if (ArchitectureID == AID95)
                {
                    AIDTexture = AID95Texture;
                }
                else if (ArchitectureID == AID96)
                {
                    AIDTexture = AID96Texture;
                }
                else if (ArchitectureID == AID97)
                {
                    AIDTexture = AID97Texture;
                }
                else if (ArchitectureID == AID98)
                {
                    AIDTexture = AID98Texture;
                }
                else if (ArchitectureID == AID99)
                {
                    AIDTexture = AID99Texture;
                }
                else
                {
                    AIDTexture = AID0Texture;
                }

            }
            //↓判定设施区图片
            if (Switch4 == "1" || Switch5 == "1" || Switch6 == "1" || Switch7 == "1" || Switch8 == "1")
            {
                if (PositionCounts < PositionCount1)
                {
                    BackgroundforArchitectureTexture = BackgroundforArchitecture1Texture;
                    FABackgroundTexture = FABackground1Texture;
                    FBBackgroundTexture = FBBackground1Texture;
                    FCBackgroundTexture = FCBackground1Texture;
                    FDBackgroundTexture = FDBackground1Texture;
                    FEBackgroundTexture = FEBackground1Texture;

                }
               else if (PositionCounts < PositionCount2)
                {
                    BackgroundforArchitectureTexture = BackgroundforArchitecture2Texture;
                    FABackgroundTexture = FABackground2Texture;
                    FBBackgroundTexture = FBBackground2Texture;
                    FCBackgroundTexture = FCBackground2Texture;
                    FDBackgroundTexture = FDBackground2Texture;
                    FEBackgroundTexture = FEBackground2Texture;
                }
                else if (PositionCounts < PositionCount3)
                {
                    BackgroundforArchitectureTexture = BackgroundforArchitecture3Texture;
                    FABackgroundTexture = FABackground3Texture;
                    FBBackgroundTexture = FBBackground3Texture;
                    FCBackgroundTexture = FCBackground3Texture;
                    FDBackgroundTexture = FDBackground3Texture;
                    FEBackgroundTexture = FEBackground3Texture;
                }
                else if (PositionCounts < PositionCount4)
                {
                    BackgroundforArchitectureTexture = BackgroundforArchitecture4Texture;
                    FABackgroundTexture = FABackground4Texture;
                    FBBackgroundTexture = FBBackground4Texture;
                    FCBackgroundTexture = FCBackground4Texture;
                    FDBackgroundTexture = FDBackground4Texture;
                    FEBackgroundTexture = FEBackground4Texture;
                }
                else if (PositionCounts < PositionCount5)
                {
                    BackgroundforArchitectureTexture = BackgroundforArchitecture5Texture;
                    FABackgroundTexture = FABackground5Texture;
                    FBBackgroundTexture = FBBackground5Texture;
                    FCBackgroundTexture = FCBackground5Texture;
                    FDBackgroundTexture = FDBackground5Texture;
                    FEBackgroundTexture = FEBackground5Texture;
                }
                else if (PositionCounts < PositionCount6)
                {
                    BackgroundforArchitectureTexture = BackgroundforArchitecture6Texture;
                    FABackgroundTexture = FABackground6Texture;
                    FBBackgroundTexture = FBBackground6Texture;
                    FCBackgroundTexture = FCBackground6Texture;
                    FDBackgroundTexture = FDBackground6Texture;
                    FEBackgroundTexture = FEBackground6Texture;
                }
                else if (PositionCounts < PositionCount7)
                {
                    BackgroundforArchitectureTexture = BackgroundforArchitecture7Texture;
                    FABackgroundTexture = FABackground7Texture;
                    FBBackgroundTexture = FBBackground7Texture;
                    FCBackgroundTexture = FCBackground7Texture;
                    FDBackgroundTexture = FDBackground7Texture;
                    FEBackgroundTexture = FEBackground7Texture;
                }
                else if (PositionCounts < PositionCount8)
                {
                    BackgroundforArchitectureTexture = BackgroundforArchitecture8Texture;
                    FABackgroundTexture = FABackground8Texture;
                    FBBackgroundTexture = FBBackground8Texture;
                    FCBackgroundTexture = FCBackground8Texture;
                    FDBackgroundTexture = FDBackground8Texture;
                    FEBackgroundTexture = FEBackground8Texture;
                }
                else if (PositionCounts < PositionCount9)
                {
                    BackgroundforArchitectureTexture = BackgroundforArchitecture9Texture;
                    FABackgroundTexture = FABackground9Texture;
                    FBBackgroundTexture = FBBackground9Texture;
                    FCBackgroundTexture = FCBackground9Texture;
                    FDBackgroundTexture = FDBackground9Texture;
                    FEBackgroundTexture = FEBackground9Texture;
                }
                else if (PositionCounts < PositionCount10)
                {
                    BackgroundforArchitectureTexture = BackgroundforArchitecture10Texture;
                    FABackgroundTexture = FABackground10Texture;
                    FBBackgroundTexture = FBBackground10Texture;
                    FCBackgroundTexture = FCBackground10Texture;
                    FDBackgroundTexture = FDBackground10Texture;
                    FEBackgroundTexture = FEBackground10Texture;
                }
                else if (PositionCounts < PositionCount11)
                {
                    BackgroundforArchitectureTexture = BackgroundforArchitecture11Texture;
                    FABackgroundTexture = FABackground11Texture;
                    FBBackgroundTexture = FBBackground11Texture;
                    FCBackgroundTexture = FCBackground11Texture;
                    FDBackgroundTexture = FDBackground11Texture;
                    FEBackgroundTexture = FEBackground11Texture;
                }
                else if (PositionCounts < PositionCount12)
                {
                    BackgroundforArchitectureTexture = BackgroundforArchitecture12Texture;
                    FABackgroundTexture = FABackground12Texture;
                    FBBackgroundTexture = FBBackground12Texture;
                    FCBackgroundTexture = FCBackground12Texture;
                    FDBackgroundTexture = FDBackground12Texture;
                    FEBackgroundTexture = FEBackground12Texture;
                }
                else if (PositionCounts < PositionCount13)
                {
                    BackgroundforArchitectureTexture = BackgroundforArchitecture13Texture;
                    FABackgroundTexture = FABackground13Texture;
                    FBBackgroundTexture = FBBackground13Texture;
                    FCBackgroundTexture = FCBackground13Texture;
                    FDBackgroundTexture = FDBackground13Texture;
                    FEBackgroundTexture = FEBackground13Texture;
                }
                else if (PositionCounts < PositionCount14)
                {
                    BackgroundforArchitectureTexture = BackgroundforArchitecture14Texture;
                    FABackgroundTexture = FABackground14Texture;
                    FBBackgroundTexture = FBBackground14Texture;
                    FCBackgroundTexture = FCBackground14Texture;
                    FDBackgroundTexture = FDBackground14Texture;
                    FEBackgroundTexture = FEBackground14Texture;
                }
                else if (PositionCounts < PositionCount15)
                {
                    BackgroundforArchitectureTexture = BackgroundforArchitecture15Texture; 
                    FABackgroundTexture = FABackground15Texture;
                    FBBackgroundTexture = FBBackground15Texture;
                    FCBackgroundTexture = FCBackground15Texture;
                    FDBackgroundTexture = FDBackground15Texture;
                    FEBackgroundTexture = FEBackground15Texture;
                }
                else if (PositionCounts < PositionCount16)
                {
                    BackgroundforArchitectureTexture = BackgroundforArchitecture16Texture;
                    FABackgroundTexture = FABackground16Texture;
                    FBBackgroundTexture = FBBackground16Texture;
                    FCBackgroundTexture = FCBackground16Texture;
                    FDBackgroundTexture = FDBackground16Texture;
                    FEBackgroundTexture = FEBackground16Texture;
                }
                else if (PositionCounts < PositionCount17)
                {
                    BackgroundforArchitectureTexture = BackgroundforArchitecture17Texture;
                    FABackgroundTexture = FABackground17Texture;
                    FBBackgroundTexture = FBBackground17Texture;
                    FCBackgroundTexture = FCBackground17Texture;
                    FDBackgroundTexture = FDBackground17Texture;
                    FEBackgroundTexture = FEBackground17Texture;
                }
                else if (PositionCounts < PositionCount18)
                {
                    BackgroundforArchitectureTexture = BackgroundforArchitecture18Texture;
                    FABackgroundTexture = FABackground18Texture;
                    FBBackgroundTexture = FBBackground18Texture;
                    FCBackgroundTexture = FCBackground18Texture;
                    FDBackgroundTexture = FDBackground18Texture;
                    FEBackgroundTexture = FEBackground18Texture;
                }
                else if (PositionCounts < PositionCount19)
                {
                    BackgroundforArchitectureTexture = BackgroundforArchitecture19Texture;
                    FABackgroundTexture = FABackground19Texture;
                    FBBackgroundTexture = FBBackground19Texture;
                    FCBackgroundTexture = FCBackground19Texture;
                    FDBackgroundTexture = FDBackground19Texture;
                    FEBackgroundTexture = FEBackground19Texture;
                }
                else if (PositionCounts < PositionCount20)
                {
                    BackgroundforArchitectureTexture = BackgroundforArchitecture20Texture;
                    FABackgroundTexture = FABackground20Texture;
                    FBBackgroundTexture = FBBackground20Texture;
                    FCBackgroundTexture = FCBackground20Texture;
                    FDBackgroundTexture = FDBackground20Texture;
                    FEBackgroundTexture = FEBackground20Texture;
                }
                else if (PositionCounts < PositionCount21)
                {
                    BackgroundforArchitectureTexture = BackgroundforArchitecture21Texture;
                    FABackgroundTexture = FABackground21Texture;
                    FBBackgroundTexture = FBBackground21Texture;
                    FCBackgroundTexture = FCBackground21Texture;
                    FDBackgroundTexture = FDBackground21Texture;
                    FEBackgroundTexture = FEBackground21Texture;
                }
                else if (PositionCounts < PositionCount22)
                {

                    BackgroundforArchitectureTexture = BackgroundforArchitecture22Texture;
                    FABackgroundTexture = FABackground22Texture;
                    FBBackgroundTexture = FBBackground22Texture;
                    FCBackgroundTexture = FCBackground22Texture;
                    FDBackgroundTexture = FDBackground22Texture;
                    FEBackgroundTexture = FEBackground22Texture;
                }
                else if (PositionCounts < PositionCount23)
                {
                    BackgroundforArchitectureTexture = BackgroundforArchitecture23Texture;
                    FABackgroundTexture = FABackground23Texture;
                    FBBackgroundTexture = FBBackground23Texture;
                    FCBackgroundTexture = FCBackground23Texture;
                    FDBackgroundTexture = FDBackground23Texture;
                    FEBackgroundTexture = FEBackground23Texture;
                }
                else if (PositionCounts < PositionCount24)
                {
                    BackgroundforArchitectureTexture = BackgroundforArchitecture24Texture;
                    FABackgroundTexture = FABackground24Texture;
                    FBBackgroundTexture = FBBackground24Texture;
                    FCBackgroundTexture = FCBackground24Texture;
                    FDBackgroundTexture = FDBackground24Texture;
                    FEBackgroundTexture = FEBackground24Texture;
                }
                else if (PositionCounts < PositionCount25)
                {
                    BackgroundforArchitectureTexture = BackgroundforArchitecture25Texture;
                    FABackgroundTexture = FABackground25Texture;
                    FBBackgroundTexture = FBBackground25Texture;
                    FCBackgroundTexture = FCBackground25Texture;
                    FDBackgroundTexture = FDBackground25Texture;
                    FEBackgroundTexture = FEBackground25Texture;
                }
                else if (PositionCounts < PositionCount26)
                {
                    BackgroundforArchitectureTexture = BackgroundforArchitecture26Texture;
                    FABackgroundTexture = FABackground26Texture;
                    FBBackgroundTexture = FBBackground26Texture;
                    FCBackgroundTexture = FCBackground26Texture;
                    FDBackgroundTexture = FDBackground26Texture;
                    FEBackgroundTexture = FEBackground26Texture;
                }
                else if (PositionCounts < PositionCount27)
                {
                    BackgroundforArchitectureTexture = BackgroundforArchitecture27Texture;
                    FABackgroundTexture = FABackground27Texture;
                    FBBackgroundTexture = FBBackground27Texture;
                    FCBackgroundTexture = FCBackground27Texture;
                    FDBackgroundTexture = FDBackground27Texture;
                    FEBackgroundTexture = FEBackground27Texture;
                }
                else if (PositionCounts < PositionCount28)
                {
                    BackgroundforArchitectureTexture = BackgroundforArchitecture28Texture;
                    FABackgroundTexture = FABackground28Texture;
                    FBBackgroundTexture = FBBackground28Texture;
                    FCBackgroundTexture = FCBackground28Texture;
                    FDBackgroundTexture = FDBackground28Texture;
                    FEBackgroundTexture = FEBackground28Texture;
                }


            }
             //↓判定是否存在该特色

            if (Switch11 == "1")
            {
                 foreach (Influence influence in this.ShowingArchitecture.Characteristics.Influences.Values)
                {               
                   Characteristics = influence.ID.ToString();

                   if (Characteristics == ACC1)
                   {
                       ACC1OK = true;
                   }
                   else if (Characteristics == ACC2)
                   { 
                       ACC2OK = true; 
                   }
                   else if (Characteristics == ACC2) 
                   { 
                       ACC2OK = true;
                   }
                   else if (Characteristics == ACC3)
                   { 
                       ACC3OK = true; 
                   }
                   else if (Characteristics == ACC4) 
                   {
                       ACC4OK = true;
                   }
                   else if (Characteristics == ACC5) 
                   { 
                       ACC5OK = true;
                   }
                   else if (Characteristics == ACC6) 
                   { 
                       ACC6OK = true;
                   }
                   else if (Characteristics == ACC7)
                   {
                       ACC7OK = true;
                   }
                   else if (Characteristics == ACC8)
                   { 
                       ACC8OK = true;
                   }
                   else if (Characteristics == ACC9) 
                   {
                       ACC9OK = true;
                   }
                   else if (Characteristics == ACC10) 
                   { 
                       ACC10OK = true;
                   }
                   else if (Characteristics == ACC11)
                   { 
                       ACC11OK = true;
                   }
                   else if (Characteristics == ACC12) 
                   { 
                       ACC12OK = true;
                   }
                   else if (Characteristics == ACC13) 
                   { 
                       ACC13OK = true;
                   }
                   else if (Characteristics == ACC14)
                   { 
                       ACC14OK = true;
                   }
                   else if (Characteristics == ACC15) 
                   { 
                       ACC15OK = true; 
                   }
                   else if (Characteristics == ACC16) 
                   { 
                       ACC16OK = true; 
                   }
                   else if (Characteristics == ACC17)
                   {
                       ACC17OK = true; 
                   }
                   else if (Characteristics == ACC18)
                   { 
                       ACC18OK = true;
                   }
                   else if (Characteristics == ACC19) 
                   { 
                       ACC19OK = true;
                   }
                   else if (Characteristics == ACC20) 
                   { 
                       ACC20OK = true;
                   }
                   else if (Characteristics == ACC21) 
                   { 
                       ACC21OK = true; 
                   }
                   else if (Characteristics == ACC22) 
                   { 
                       ACC22OK = true; 
                   }
                   else if (Characteristics == ACC23)
                   {
                       ACC23OK = true;
                   }
                   else if (Characteristics == ACC24)
                   { 
                       ACC24OK = true; 
                   }
                   else if (Characteristics == ACC25) 
                   {
                       ACC25OK = true; 
                   }
                   else if (Characteristics == ACC26) 
                   { 
                       ACC26OK = true;
                   }
                   else if (Characteristics == ACC27) 
                   { 
                       ACC27OK = true;
                   }
                   else if (Characteristics == ACC28)
                   {
                       ACC28OK = true;
                   }
                   else if (Characteristics == ACC29)
                   {
                       ACC29OK = true; 
                   }
                   else if (Characteristics == ACC30)
                   { 
                       ACC30OK = true; 
                   }
                   else if (Characteristics == ACC31)
                   {
                       ACC31OK = true; 
                   }
                   else if (Characteristics == ACC32)
                   {
                       ACC32OK = true;
                   }
                   else if (Characteristics == ACC33)
                   {
                       ACC33OK = true;
                   }
                   else if (Characteristics == ACC34)
                   {
                       ACC34OK = true;
                   }
                   else if (Characteristics == ACC35)
                   {
                       ACC35OK = true; 
                   }
                   else if (Characteristics == ACC36) 
                   {
                       ACC36OK = true;
                   }
                   else if (Characteristics == ACC37)
                   {
                       ACC37OK = true; 
                   }
                   else if (Characteristics == ACC38)
                   { 
                       ACC38OK = true;
                   }
                   else if (Characteristics == ACC39) 
                   { 
                       ACC39OK = true; 
                   }
                   else if (Characteristics == ACC40)
                   { 
                       ACC40OK = true;
                   }
                   else if (Characteristics == ACC41)
                   { 
                       ACC41OK = true;
                   }
                   else if (Characteristics == ACC42)
                   { 
                       ACC42OK = true; 
                   }
                   else if (Characteristics == ACC43)
                   { 
                       ACC43OK = true; 
                   }
                   else if (Characteristics == ACC44)
                   { 
                       ACC44OK = true;
                   }
                   else if (Characteristics == ACC45)
                   { 
                       ACC45OK = true; 
                   }
                   else if (Characteristics == ACC46) 
                   {
                       ACC46OK = true; 
                   }
                   else if (Characteristics == ACC47) 
                   { 
                       ACC47OK = true; 
                   }
                   else if (Characteristics == ACC48) 
                   {
                       ACC48OK = true;
                   }
                   else if (Characteristics == ACC49) { ACC49OK = true; }
                   else if (Characteristics == ACC50) { ACC50OK = true; }
                   else if (Characteristics == ACC51) { ACC51OK = true; }
                   else if (Characteristics == ACC52) { ACC52OK = true; }
                   else if (Characteristics == ACC53) { ACC53OK = true; }
                   else if (Characteristics == ACC54) { ACC54OK = true; }
                   else if (Characteristics == ACC55) { ACC55OK = true; }
                   else if (Characteristics == ACC56) { ACC56OK = true; }
                   else if (Characteristics == ACC57) { ACC57OK = true; }
                   else if (Characteristics == ACC58) { ACC58OK = true; }
                   else if (Characteristics == ACC59) { ACC59OK = true; }
                   else if (Characteristics == ACC60) { ACC60OK = true; }
                   else if (Characteristics == ACC61) { ACC61OK = true; }
                   else if (Characteristics == ACC62) { ACC62OK = true; }
                   else if (Characteristics == ACC63) { ACC63OK = true; }
                   else if (Characteristics == ACC64) { ACC64OK = true; }
                   else if (Characteristics == ACC65) { ACC65OK = true; }
                   else if (Characteristics == ACC66) { ACC66OK = true; }
                   else if (Characteristics == ACC67) { ACC67OK = true; }
                   else if (Characteristics == ACC68) { ACC68OK = true; }
                   else if (Characteristics == ACC69) { ACC69OK = true; }
                   else if (Characteristics == ACC70) { ACC70OK = true; }
                   else if (Characteristics == ACC71) { ACC71OK = true; }
                   else if (Characteristics == ACC72) { ACC72OK = true; }
                   else if (Characteristics == ACC73) { ACC73OK = true; }
                   else if (Characteristics == ACC74) { ACC74OK = true; }
                   else if (Characteristics == ACC75) { ACC75OK = true; }
                   else if (Characteristics == ACC76) { ACC76OK = true; }
                   else if (Characteristics == ACC77) { ACC77OK = true; }
                   else if (Characteristics == ACC78) { ACC78OK = true; }
                   else if (Characteristics == ACC79) { ACC79OK = true; }
                   else if (Characteristics == ACC80) { ACC80OK = true; }
                   else if (Characteristics == ACC81) { ACC81OK = true; }
                   else if (Characteristics == ACC82) { ACC82OK = true; }
                   else if (Characteristics == ACC83) { ACC83OK = true; }
                   else if (Characteristics == ACC84) { ACC84OK = true; }
                   else if (Characteristics == ACC85) { ACC85OK = true; }
                   else if (Characteristics == ACC86) { ACC86OK = true; }
                   else if (Characteristics == ACC87) { ACC87OK = true; }
                   else if (Characteristics == ACC88) { ACC88OK = true; }
                   else if (Characteristics == ACC89) { ACC89OK = true; }
                   else if (Characteristics == ACC90) { ACC90OK = true; }
                   else if (Characteristics == ACC91) { ACC91OK = true; }
                   else if (Characteristics == ACC92) { ACC92OK = true; }
                   else if (Characteristics == ACC93) { ACC93OK = true; }
                   else if (Characteristics == ACC94) { ACC94OK = true; }
                   else if (Characteristics == ACC95) { ACC95OK = true; }
                   else if (Characteristics == ACC96) { ACC96OK = true; }
                   else if (Characteristics == ACC97) { ACC97OK = true; }
                   else if (Characteristics == ACC98) { ACC98OK = true; }
                   else if (Characteristics == ACC99) { ACC99OK = true; }
                   else if (Characteristics == ACC100) { ACC100OK = true; }
                   else if (Characteristics == ACC101) { ACC101OK = true; }
                   else if (Characteristics == ACC102) { ACC102OK = true; }
                   else if (Characteristics == ACC103) { ACC103OK = true; }
                   else if (Characteristics == ACC104) { ACC104OK = true; }
                   else if (Characteristics == ACC105) { ACC105OK = true; }
                   else if (Characteristics == ACC106) { ACC106OK = true; }
                   else if (Characteristics == ACC107) { ACC107OK = true; }
                   else if (Characteristics == ACC108) { ACC108OK = true; }
                   else if (Characteristics == ACC109) { ACC109OK = true; }
                   else if (Characteristics == ACC110) { ACC110OK = true; }
                   else if (Characteristics == ACC111) { ACC111OK = true; }
                   else if (Characteristics == ACC112) { ACC112OK = true; }
                   else if (Characteristics == ACC113) { ACC113OK = true; }
                   else if (Characteristics == ACC114) { ACC114OK = true; }
                   else if (Characteristics == ACC115) { ACC115OK = true; }
                   else if (Characteristics == ACC116) { ACC116OK = true; }
                   else if (Characteristics == ACC117) { ACC117OK = true; }
                   else if (Characteristics == ACC118) { ACC118OK = true; }
                   else if (Characteristics == ACC119) { ACC119OK = true; }
                   else if (Characteristics == ACC120) { ACC120OK = true; }
                   else if (Characteristics == ACC121) { ACC121OK = true; }
                   else if (Characteristics == ACC122) { ACC122OK = true; }
                   else if (Characteristics == ACC123) { ACC123OK = true; }
                   else if (Characteristics == ACC124) { ACC124OK = true; }
                   else if (Characteristics == ACC125) { ACC125OK = true; }
                   else if (Characteristics == ACC126) { ACC126OK = true; }
                   else if (Characteristics == ACC127) { ACC127OK = true; }
                   else if (Characteristics == ACC128) { ACC128OK = true; }
                   else if (Characteristics == ACC129) { ACC129OK = true; }
                   else if (Characteristics == ACC130) { ACC130OK = true; }
                   else if (Characteristics == ACC131) { ACC131OK = true; }
                   else if (Characteristics == ACC132) { ACC132OK = true; }
                   else if (Characteristics == ACC133) { ACC133OK = true; }
                   else if (Characteristics == ACC134) { ACC134OK = true; }
                   else if (Characteristics == ACC135) { ACC135OK = true; }
                   else if (Characteristics == ACC136) { ACC136OK = true; }
                   else if (Characteristics == ACC137) { ACC137OK = true; }
                   else if (Characteristics == ACC138) { ACC138OK = true; }
                   else if (Characteristics == ACC139) { ACC139OK = true; }
                   else if (Characteristics == ACC140) { ACC140OK = true; }
                   else if (Characteristics == ACC141) { ACC141OK = true; }
                   else if (Characteristics == ACC142) { ACC142OK = true; }
                   else if (Characteristics == ACC143) { ACC143OK = true; }
                   else if (Characteristics == ACC144) { ACC144OK = true; }
                   else if (Characteristics == ACC145) { ACC145OK = true; }
                   else if (Characteristics == ACC146) { ACC146OK = true; }
                   else if (Characteristics == ACC147) { ACC147OK = true; }
                   else if (Characteristics == ACC148) { ACC148OK = true; }
                   else if (Characteristics == ACC149) { ACC149OK = true; }
                   else if (Characteristics == ACC150) { ACC150OK = true; }
                   else if (Characteristics == ACC151) { ACC151OK = true; }
                   else if (Characteristics == ACC152) { ACC152OK = true; }
                   else if (Characteristics == ACC153) { ACC153OK = true; }
                   else if (Characteristics == ACC154) { ACC154OK = true; }
                   else if (Characteristics == ACC155) { ACC155OK = true; }
                   else if (Characteristics == ACC156) { ACC156OK = true; }
                   else if (Characteristics == ACC157) { ACC157OK = true; }
                   else if (Characteristics == ACC158) { ACC158OK = true; }
                   else if (Characteristics == ACC159) { ACC159OK = true; }
                   else if (Characteristics == ACC160) { ACC160OK = true; }
                   else if (Characteristics == ACC161) { ACC161OK = true; }
                   else if (Characteristics == ACC162) { ACC162OK = true; }
                   else if (Characteristics == ACC163) { ACC163OK = true; }
                   else if (Characteristics == ACC164) { ACC164OK = true; }
                   else if (Characteristics == ACC165) { ACC165OK = true; }
                   else if (Characteristics == ACC166) { ACC166OK = true; }
                   else if (Characteristics == ACC167) { ACC167OK = true; }
                   else if (Characteristics == ACC168) { ACC168OK = true; }
                   else if (Characteristics == ACC169) { ACC169OK = true; }
                   else if (Characteristics == ACC170) { ACC170OK = true; }
                   else if (Characteristics == ACC171) { ACC171OK = true; }
                   else if (Characteristics == ACC172) { ACC172OK = true; }
                   else if (Characteristics == ACC173) { ACC173OK = true; }
                   else if (Characteristics == ACC174) { ACC174OK = true; }
                   else if (Characteristics == ACC175) { ACC175OK = true; }
                   else if (Characteristics == ACC176) { ACC176OK = true; }
                   else if (Characteristics == ACC177) { ACC177OK = true; }
                   else if (Characteristics == ACC178) { ACC178OK = true; }
                   else if (Characteristics == ACC179) { ACC179OK = true; }
                   else if (Characteristics == ACC180) { ACC180OK = true; }
                   else if (Characteristics == ACC181) { ACC181OK = true; }
                   else if (Characteristics == ACC182) { ACC182OK = true; }
                   else if (Characteristics == ACC183) { ACC183OK = true; }
                   else if (Characteristics == ACC184) { ACC184OK = true; }
                   else if (Characteristics == ACC185) { ACC185OK = true; }
                   else if (Characteristics == ACC186) { ACC186OK = true; }
                   else if (Characteristics == ACC187) { ACC187OK = true; }
                   else if (Characteristics == ACC188) { ACC188OK = true; }
                   else if (Characteristics == ACC189) { ACC189OK = true; }
                   else if (Characteristics == ACC190) { ACC190OK = true; }
                   else if (Characteristics == ACC191) { ACC191OK = true; }
                   else if (Characteristics == ACC192) { ACC192OK = true; }
                   else if (Characteristics == ACC193) { ACC193OK = true; }
                   else if (Characteristics == ACC194) { ACC194OK = true; }
                   else if (Characteristics == ACC195) { ACC195OK = true; }
                   else if (Characteristics == ACC196) { ACC196OK = true; }
                   else if (Characteristics == ACC197) { ACC197OK = true; }
                   else if (Characteristics == ACC198) { ACC198OK = true; }
                   else if (Characteristics == ACC199) { ACC199OK = true; }
                   else if (Characteristics == ACC200) { ACC200OK = true; }
                   else if (Characteristics == ACC201) { ACC201OK = true; }
                   else if (Characteristics == ACC202) { ACC202OK = true; }
                   else if (Characteristics == ACC203) { ACC203OK = true; }
                   else if (Characteristics == ACC204) { ACC204OK = true; }
                   else if (Characteristics == ACC205) { ACC205OK = true; }
                   else if (Characteristics == ACC206) { ACC206OK = true; }
                   else if (Characteristics == ACC207) { ACC207OK = true; }
                   else if (Characteristics == ACC208) { ACC208OK = true; }
                   else if (Characteristics == ACC209) { ACC209OK = true; }
                   else if (Characteristics == ACC210) { ACC210OK = true; }
                   else if (Characteristics == ACC211) { ACC211OK = true; }
                   else if (Characteristics == ACC212) { ACC212OK = true; }
                   else if (Characteristics == ACC213) { ACC213OK = true; }
                   else if (Characteristics == ACC214) { ACC214OK = true; }
                   else if (Characteristics == ACC215) { ACC215OK = true; }
                   else if (Characteristics == ACC216) { ACC216OK = true; }
                   else if (Characteristics == ACC217) { ACC217OK = true; }
                   else if (Characteristics == ACC218) { ACC218OK = true; }
                   else if (Characteristics == ACC219) { ACC219OK = true; }
                   else if (Characteristics == ACC220) { ACC220OK = true; }
                   else if (Characteristics == ACC221) { ACC221OK = true; }
                   else if (Characteristics == ACC222) { ACC222OK = true; }
                   else if (Characteristics == ACC223) { ACC223OK = true; }
                   else if (Characteristics == ACC224) { ACC224OK = true; }
                   else if (Characteristics == ACC225) { ACC225OK = true; }
                   else if (Characteristics == ACC226) { ACC226OK = true; }
                   else if (Characteristics == ACC227) { ACC227OK = true; }
                   else if (Characteristics == ACC228) { ACC228OK = true; }
                   else if (Characteristics == ACC229) { ACC229OK = true; }
                   else if (Characteristics == ACC230) { ACC230OK = true; }
                   else if (Characteristics == ACC231) { ACC231OK = true; }
                   else if (Characteristics == ACC232) { ACC232OK = true; }
                   else if (Characteristics == ACC233) { ACC233OK = true; }
                   else if (Characteristics == ACC234) { ACC234OK = true; }
                   else if (Characteristics == ACC235) { ACC235OK = true; }
                   else if (Characteristics == ACC236) { ACC236OK = true; }
                   else if (Characteristics == ACC237) { ACC237OK = true; }
                   else if (Characteristics == ACC238) { ACC238OK = true; }
                   else if (Characteristics == ACC239) { ACC239OK = true; }
                   else if (Characteristics == ACC240) { ACC240OK = true; }
                   else if (Characteristics == ACC241) { ACC241OK = true; }
                   else if (Characteristics == ACC242) { ACC242OK = true; }
                   else if (Characteristics == ACC243) { ACC243OK = true; }
                   else if (Characteristics == ACC244) { ACC244OK = true; }
                   else if (Characteristics == ACC245) { ACC245OK = true; }
                   else if (Characteristics == ACC246) { ACC246OK = true; }
                   else if (Characteristics == ACC247) { ACC247OK = true; }
                   else if (Characteristics == ACC248) { ACC248OK = true; }
                   else if (Characteristics == ACC249) { ACC249OK = true; }
                   else if (Characteristics == ACC250) { ACC250OK = true; }
                   else if (Characteristics == ACC251) { ACC251OK = true; }
                   else if (Characteristics == ACC252) { ACC252OK = true; }
                   else if (Characteristics == ACC253) { ACC253OK = true; }
                   else if (Characteristics == ACC254) { ACC254OK = true; }
                   else if (Characteristics == ACC255) { ACC255OK = true; }
                   else if (Characteristics == ACC256) { ACC256OK = true; }
                   else if (Characteristics == ACC257) { ACC257OK = true; }
                   else if (Characteristics == ACC258) { ACC258OK = true; }
                   else if (Characteristics == ACC259) { ACC259OK = true; }
                   else if (Characteristics == ACC260) { ACC260OK = true; }
                   else if (Characteristics == ACC261) { ACC261OK = true; }
                   else if (Characteristics == ACC262) { ACC262OK = true; }
                   else if (Characteristics == ACC263) { ACC263OK = true; }
                   else if (Characteristics == ACC264) { ACC264OK = true; }
                   else if (Characteristics == ACC265) { ACC265OK = true; }
                   else if (Characteristics == ACC266) { ACC266OK = true; }
                   else if (Characteristics == ACC267) { ACC267OK = true; }
                   else if (Characteristics == ACC268) { ACC268OK = true; }
                   else if (Characteristics == ACC269) { ACC269OK = true; }
                   else if (Characteristics == ACC270) { ACC270OK = true; }
                   else if (Characteristics == ACC271) { ACC271OK = true; }
                   else if (Characteristics == ACC272) { ACC272OK = true; }
                   else if (Characteristics == ACC273) { ACC273OK = true; }
                   else if (Characteristics == ACC274) { ACC274OK = true; }
                   else if (Characteristics == ACC275) { ACC275OK = true; }
                   else if (Characteristics == ACC276) { ACC276OK = true; }
                   else if (Characteristics == ACC277) { ACC277OK = true; }
                   else if (Characteristics == ACC278) { ACC278OK = true; }
                   else if (Characteristics == ACC279) { ACC279OK = true; }
                   else if (Characteristics == ACC280) { ACC280OK = true; }
                   else if (Characteristics == ACC281) { ACC281OK = true; }
                   else if (Characteristics == ACC282) { ACC282OK = true; }
                   else if (Characteristics == ACC283) { ACC283OK = true; }
                   else if (Characteristics == ACC284) { ACC284OK = true; }
                   else if (Characteristics == ACC285) { ACC285OK = true; }
                   else if (Characteristics == ACC286) { ACC286OK = true; }
                   else if (Characteristics == ACC287) { ACC287OK = true; }
                   else if (Characteristics == ACC288) { ACC288OK = true; }
                   else if (Characteristics == ACC289) { ACC289OK = true; }
                   else if (Characteristics == ACC290) { ACC290OK = true; }
                   else if (Characteristics == ACC291) { ACC291OK = true; }
                   else if (Characteristics == ACC292) { ACC292OK = true; }
                   else if (Characteristics == ACC293) { ACC293OK = true; }
                   else if (Characteristics == ACC294) { ACC294OK = true; }
                   else if (Characteristics == ACC295) { ACC295OK = true; }
                   else if (Characteristics == ACC296) { ACC296OK = true; }
                   else if (Characteristics == ACC297) { ACC297OK = true; }
                   else if (Characteristics == ACC298) { ACC298OK = true; }
                   else if (Characteristics == ACC299) { ACC299OK = true; }
                   else if (Characteristics == ACC300) { ACC300OK = true; }
                }

                 C1Texture = AC1Texture;                
                 if (ACC1OK == true) { C1Texture = ACC1Texture; }
                 else if (ACC2OK == true) { C1Texture = ACC2Texture; }
                 else if (ACC3OK == true) { C1Texture = ACC3Texture; }
                 else if (ACC4OK == true) { C1Texture = ACC4Texture; }
                 else if (ACC5OK == true) { C1Texture = ACC5Texture; }
                 else if (ACC6OK == true) { C1Texture = ACC6Texture; }
                 else if (ACC7OK == true) { C1Texture = ACC7Texture; }
                 else if (ACC8OK == true) { C1Texture = ACC8Texture; }
                 else if (ACC9OK == true) { C1Texture = ACC9Texture; }
                 else if (ACC10OK == true) { C1Texture = ACC10Texture; }
                 else if (ACC11OK == true) { C1Texture = ACC11Texture; }
                 else if (ACC12OK == true) { C1Texture = ACC12Texture; }
                 else if (ACC13OK == true) { C1Texture = ACC13Texture; }
                 else if (ACC14OK == true) { C1Texture = ACC14Texture; }
                 else if (ACC15OK == true) { C1Texture = ACC15Texture; }
                 else if (ACC16OK == true) { C1Texture = ACC16Texture; }
                 else if (ACC17OK == true) { C1Texture = ACC17Texture; }
                 else if (ACC18OK == true) { C1Texture = ACC18Texture; }
                 else if (ACC19OK == true) { C1Texture = ACC19Texture; }
                 else if (ACC20OK == true) { C1Texture = ACC20Texture; }
                 else if (ACC21OK == true) { C1Texture = ACC21Texture; }
                 else if (ACC22OK == true) { C1Texture = ACC22Texture; }
                 else if (ACC23OK == true) { C1Texture = ACC23Texture; }
                 else if (ACC24OK == true) { C1Texture = ACC24Texture; }
                 else if (ACC25OK == true) { C1Texture = ACC25Texture; }
                 else if (ACC26OK == true) { C1Texture = ACC26Texture; }
                 else if (ACC27OK == true) { C1Texture = ACC27Texture; }
                 else if (ACC28OK == true) { C1Texture = ACC28Texture; }
                 else if (ACC29OK == true) { C1Texture = ACC29Texture; }
                 else if (ACC30OK == true) { C1Texture = ACC30Texture; }
                 else if (ACC31OK == true) { C1Texture = ACC31Texture; }
                 else if (ACC32OK == true) { C1Texture = ACC32Texture; }
                 else if (ACC33OK == true) { C1Texture = ACC33Texture; }
                 else if (ACC34OK == true) { C1Texture = ACC34Texture; }
                 else if (ACC35OK == true) { C1Texture = ACC35Texture; }
                 else if (ACC36OK == true) { C1Texture = ACC36Texture; }
                 else if (ACC37OK == true) { C1Texture = ACC37Texture; }
                 else if (ACC38OK == true) { C1Texture = ACC38Texture; }
                 else if (ACC39OK == true) { C1Texture = ACC39Texture; }
                 else if (ACC40OK == true) { C1Texture = ACC40Texture; }
                 else if (ACC41OK == true) { C1Texture = ACC41Texture; }
                 else if (ACC42OK == true) { C1Texture = ACC42Texture; }
                 else if (ACC43OK == true) { C1Texture = ACC43Texture; }
                 else if (ACC44OK == true) { C1Texture = ACC44Texture; }
                 else if (ACC45OK == true) { C1Texture = ACC45Texture; }
                 else if (ACC46OK == true) { C1Texture = ACC46Texture; }
                 else if (ACC47OK == true) { C1Texture = ACC47Texture; }
                 else if (ACC48OK == true) { C1Texture = ACC48Texture; }
                 else if (ACC49OK == true) { C1Texture = ACC49Texture; }
                 else if (ACC50OK == true) { C1Texture = ACC50Texture; }
                 else if (ACC51OK == true) { C1Texture = ACC51Texture; }
                 else if (ACC52OK == true) { C1Texture = ACC52Texture; }
                 else if (ACC53OK == true) { C1Texture = ACC53Texture; }
                 else if (ACC54OK == true) { C1Texture = ACC54Texture; }
                 else if (ACC55OK == true) { C1Texture = ACC55Texture; }
                 C2Texture = AC2Texture;                 
                 if (ACC56OK == true) { C2Texture = ACC56Texture; }
                 else if (ACC57OK == true) { C2Texture = ACC57Texture; }
                 else if (ACC58OK == true) { C2Texture = ACC58Texture; }
                 else if (ACC59OK == true) { C2Texture = ACC59Texture; }
                 else if (ACC60OK == true) { C2Texture = ACC60Texture; }
                 else if (ACC61OK == true) { C2Texture = ACC61Texture; }
                 else if (ACC62OK == true) { C2Texture = ACC62Texture; }
                 else if (ACC63OK == true) { C2Texture = ACC63Texture; }
                 else if (ACC64OK == true) { C2Texture = ACC64Texture; }
                 else if (ACC65OK == true) { C2Texture = ACC65Texture; }
                 else if (ACC66OK == true) { C2Texture = ACC66Texture; }
                 else if (ACC67OK == true) { C2Texture = ACC67Texture; }
                 else if (ACC68OK == true) { C2Texture = ACC68Texture; }
                 else if (ACC69OK == true) { C2Texture = ACC69Texture; }
                 else if (ACC70OK == true) { C2Texture = ACC70Texture; }
                 C3Texture = AC3Texture;                
                 if (ACC71OK == true) { C3Texture = ACC71Texture; }
                 else if (ACC72OK == true) { C3Texture = ACC72Texture; }
                 else if (ACC73OK == true) { C3Texture = ACC73Texture; }
                 else if (ACC74OK == true) { C3Texture = ACC74Texture; }
                 else if (ACC75OK == true) { C3Texture = ACC75Texture; }
                 C4Texture = AC4Texture;
                 if (ACC76OK == true) { C4Texture = ACC76Texture; }
                 else if (ACC77OK == true) { C4Texture = ACC77Texture; }
                 else if (ACC78OK == true) { C4Texture = ACC78Texture; }
                 else if (ACC79OK == true) { C4Texture = ACC79Texture; }
                 else if (ACC80OK == true) { C4Texture = ACC80Texture; }
                 C5Texture = AC5Texture;
                 if (ACC81OK == true) { C5Texture = ACC81Texture; }
                 else if (ACC82OK == true) { C5Texture = ACC82Texture; }
                 else if (ACC83OK == true) { C5Texture = ACC83Texture; }
                 else if (ACC84OK == true) { C5Texture = ACC84Texture; }
                 else if (ACC85OK == true) { C5Texture = ACC85Texture; }
                 C6Texture = AC6Texture;
                 if (ACC86OK == true) { C6Texture = ACC86Texture; }
                 else if (ACC87OK == true) { C6Texture = ACC87Texture; }
                 else if (ACC88OK == true) { C6Texture = ACC88Texture; }
                 else if (ACC89OK == true) { C6Texture = ACC89Texture; }
                 else if (ACC90OK == true) { C6Texture = ACC90Texture; }
                 C7Texture = AC7Texture;
                 if (ACC91OK == true) { C7Texture = ACC91Texture; }
                 else if (ACC92OK == true) { C7Texture = ACC92Texture; }
                 else if (ACC93OK == true) { C7Texture = ACC93Texture; }
                 else if (ACC94OK == true) { C7Texture = ACC94Texture; }
                 else if (ACC95OK == true) { C7Texture = ACC95Texture; }
                 C8Texture = AC8Texture;
                 if (ACC96OK == true) { C8Texture = ACC96Texture; }
                 else if (ACC97OK == true) { C8Texture = ACC97Texture; }
                 else if (ACC98OK == true) { C8Texture = ACC98Texture; }
                 else if (ACC99OK == true) { C8Texture = ACC99Texture; }
                 else if (ACC100OK == true) { C8Texture = ACC100Texture; }
                 C9Texture = AC9Texture;
                 if (ACC101OK == true) { C9Texture = ACC101Texture; }
                 else if (ACC102OK == true) { C9Texture = ACC102Texture; }
                 else if (ACC103OK == true) { C9Texture = ACC103Texture; }
                 else if (ACC104OK == true) { C9Texture = ACC104Texture; }
                 else if (ACC105OK == true) { C9Texture = ACC105Texture; }
                 C10Texture = AC10Texture;
                 if (ACC106OK == true) { C10Texture = ACC106Texture; }
                 else if (ACC107OK == true) { C10Texture = ACC107Texture; }
                 else if (ACC108OK == true) { C10Texture = ACC108Texture; }
                 else if (ACC109OK == true) { C10Texture = ACC109Texture; }
                 else if (ACC110OK == true) { C10Texture = ACC110Texture; }
                 C11Texture = AC11Texture;
                 if (ACC111OK == true) { C11Texture = ACC111Texture; }
                 else if (ACC112OK == true) { C11Texture = ACC112Texture; }
                 else if (ACC113OK == true) { C11Texture = ACC113Texture; }
                 else if (ACC114OK == true) { C11Texture = ACC114Texture; }
                 else if (ACC115OK == true) { C11Texture = ACC115Texture; }
                 C12Texture = AC12Texture;
                 if (ACC116OK == true) { C12Texture = ACC116Texture; }
                 else if (ACC117OK == true) { C12Texture = ACC117Texture; }
                 else if (ACC118OK == true) { C12Texture = ACC118Texture; }
                 else if (ACC119OK == true) { C12Texture = ACC119Texture; }
                 else if (ACC120OK == true) { C12Texture = ACC120Texture; }
                 C13Texture = AC13Texture;
                 if (ACC121OK == true) { C13Texture = ACC121Texture; }
                 else if (ACC122OK == true) { C13Texture = ACC122Texture; }
                 else if (ACC123OK == true) { C13Texture = ACC123Texture; }
                 else if (ACC124OK == true) { C13Texture = ACC124Texture; }
                 else if (ACC125OK == true) { C13Texture = ACC125Texture; }
                 else if (ACC126OK == true) { C13Texture = ACC126Texture; }
                 else if (ACC127OK == true) { C13Texture = ACC127Texture; }
                 else if (ACC128OK == true) { C13Texture = ACC128Texture; }
                 else if (ACC129OK == true) { C13Texture = ACC129Texture; }
                 else if (ACC130OK == true) { C13Texture = ACC130Texture; }
                 C14Texture = AC14Texture;
                 if (ACC131OK == true) { C14Texture = ACC131Texture; }
                 else if (ACC132OK == true) { C14Texture = ACC132Texture; }
                 else if (ACC133OK == true) { C14Texture = ACC133Texture; }
                 else if (ACC134OK == true) { C14Texture = ACC134Texture; }
                 else if (ACC135OK == true) { C14Texture = ACC135Texture; }
                 else if (ACC136OK == true) { C14Texture = ACC136Texture; }
                 else if (ACC137OK == true) { C14Texture = ACC137Texture; }
                 else if (ACC138OK == true) { C14Texture = ACC138Texture; }
                 else if (ACC139OK == true) { C14Texture = ACC139Texture; }
                 else if (ACC140OK == true) { C14Texture = ACC140Texture; }
                 C15Texture = AC15Texture;
                 if (ACC141OK == true) { C15Texture = ACC141Texture; }
                 else if (ACC142OK == true) { C15Texture = ACC142Texture; }
                 else if (ACC143OK == true) { C15Texture = ACC143Texture; }
                 else if (ACC144OK == true) { C15Texture = ACC144Texture; }
                 else if (ACC145OK == true) { C15Texture = ACC145Texture; }
                 else if (ACC146OK == true) { C15Texture = ACC146Texture; }
                 else if (ACC147OK == true) { C15Texture = ACC147Texture; }
                 else if (ACC148OK == true) { C15Texture = ACC148Texture; }
                 else if (ACC149OK == true) { C15Texture = ACC149Texture; }
                 else if (ACC150OK == true) { C15Texture = ACC150Texture; }
                 C16Texture = AC16Texture;
                 if (ACC151OK == true) { C16Texture = ACC151Texture; }
                 else if (ACC152OK == true) { C16Texture = ACC152Texture; }
                 else if (ACC153OK == true) { C16Texture = ACC153Texture; }
                 else if (ACC154OK == true) { C16Texture = ACC154Texture; }
                 else if (ACC155OK == true) { C16Texture = ACC155Texture; }
                 else if (ACC156OK == true) { C16Texture = ACC156Texture; }
                 else if (ACC157OK == true) { C16Texture = ACC157Texture; }
                 else if (ACC158OK == true) { C16Texture = ACC158Texture; }
                 else if (ACC159OK == true) { C16Texture = ACC159Texture; }
                 else if (ACC160OK == true) { C16Texture = ACC160Texture; }
                 C17Texture = AC17Texture;
                 if (ACC161OK == true) { C17Texture = ACC161Texture; }
                 else if (ACC162OK == true) { C17Texture = ACC162Texture; }
                 else if (ACC163OK == true) { C17Texture = ACC163Texture; }
                 else if (ACC164OK == true) { C17Texture = ACC164Texture; }
                 else if (ACC165OK == true) { C17Texture = ACC165Texture; }
                 else if (ACC166OK == true) { C17Texture = ACC166Texture; }
                 else if (ACC167OK == true) { C17Texture = ACC167Texture; }
                 else if (ACC168OK == true) { C17Texture = ACC168Texture; }
                 else if (ACC169OK == true) { C17Texture = ACC169Texture; }
                 else if (ACC170OK == true) { C17Texture = ACC170Texture; }
                 C18Texture = AC18Texture;
                 if (ACC171OK == true) { C18Texture = ACC171Texture; }
                 else if (ACC172OK == true) { C18Texture = ACC172Texture; }
                 else if (ACC173OK == true) { C18Texture = ACC173Texture; }
                 else if (ACC174OK == true) { C18Texture = ACC174Texture; }
                 else if (ACC175OK == true) { C18Texture = ACC175Texture; }
                 else if (ACC176OK == true) { C18Texture = ACC176Texture; }
                 else if (ACC177OK == true) { C18Texture = ACC177Texture; }
                 else if (ACC178OK == true) { C18Texture = ACC178Texture; }
                 else if (ACC179OK == true) { C18Texture = ACC179Texture; }
                 else if (ACC180OK == true) { C18Texture = ACC180Texture; }
                 C19Texture = AC19Texture;
                 if (ACC181OK == true) { C19Texture = ACC181Texture; }
                 else if (ACC182OK == true) { C19Texture = ACC182Texture; }
                 else if (ACC183OK == true) { C19Texture = ACC183Texture; }
                 else if (ACC184OK == true) { C19Texture = ACC184Texture; }
                 else if (ACC185OK == true) { C19Texture = ACC185Texture; }
                 else if (ACC186OK == true) { C19Texture = ACC186Texture; }
                 else if (ACC187OK == true) { C19Texture = ACC187Texture; }
                 else if (ACC188OK == true) { C19Texture = ACC188Texture; }
                 else if (ACC189OK == true) { C19Texture = ACC189Texture; }
                 else if (ACC190OK == true) { C19Texture = ACC190Texture; }
                 C20Texture = AC20Texture;
                 if (ACC191OK == true) { C20Texture = ACC191Texture; }
                 else if (ACC192OK == true) { C20Texture = ACC192Texture; }
                 else if (ACC193OK == true) { C20Texture = ACC193Texture; }
                 else if (ACC194OK == true) { C20Texture = ACC194Texture; }
                 else if (ACC195OK == true) { C20Texture = ACC195Texture; }
                 else if (ACC196OK == true) { C20Texture = ACC196Texture; }
                 else if (ACC197OK == true) { C20Texture = ACC197Texture; }
                 else if (ACC198OK == true) { C20Texture = ACC198Texture; }
                 else if (ACC199OK == true) { C20Texture = ACC199Texture; }
                 else if (ACC200OK == true) { C20Texture = ACC200Texture; }
                 C21Texture = AC21Texture;
                 if (ACC201OK == true) { C21Texture = ACC201Texture; }
                 else if (ACC202OK == true) { C21Texture = ACC202Texture; }
                 else if (ACC203OK == true) { C21Texture = ACC203Texture; }
                 else if (ACC204OK == true) { C21Texture = ACC204Texture; }
                 else if (ACC205OK == true) { C21Texture = ACC205Texture; }
                 else if (ACC206OK == true) { C21Texture = ACC206Texture; }
                 else if (ACC207OK == true) { C21Texture = ACC207Texture; }
                 else if (ACC208OK == true) { C21Texture = ACC208Texture; }
                 else if (ACC209OK == true) { C21Texture = ACC209Texture; }
                 else if (ACC210OK == true) { C21Texture = ACC210Texture; }
                 C22Texture = AC22Texture;
                 if (ACC211OK == true) { C22Texture = ACC211Texture; }
                 else if (ACC212OK == true) { C22Texture = ACC212Texture; }
                 else if (ACC213OK == true) { C22Texture = ACC213Texture; }
                 else if (ACC214OK == true) { C22Texture = ACC214Texture; }
                 else if (ACC215OK == true) { C22Texture = ACC215Texture; }
                 else if (ACC216OK == true) { C22Texture = ACC216Texture; }
                 else if (ACC217OK == true) { C22Texture = ACC217Texture; }
                 else if (ACC218OK == true) { C22Texture = ACC218Texture; }
                 else if (ACC219OK == true) { C22Texture = ACC219Texture; }
                 else if (ACC220OK == true) { C22Texture = ACC220Texture; }
                 C23Texture = AC23Texture;
                 if (ACC221OK == true) { C23Texture = ACC221Texture; }
                 else if (ACC222OK == true) { C23Texture = ACC222Texture; }
                 else if (ACC223OK == true) { C23Texture = ACC223Texture; }
                 else if (ACC224OK == true) { C23Texture = ACC224Texture; }
                 else if (ACC225OK == true) { C23Texture = ACC225Texture; }
                 else if (ACC226OK == true) { C23Texture = ACC226Texture; }
                 else if (ACC227OK == true) { C23Texture = ACC227Texture; }
                 else if (ACC228OK == true) { C23Texture = ACC228Texture; }
                 else if (ACC229OK == true) { C23Texture = ACC229Texture; }
                 else if (ACC230OK == true) { C23Texture = ACC230Texture; }
                 else if (ACC231OK == true) { C23Texture = ACC231Texture; }
                 else if (ACC232OK == true) { C23Texture = ACC232Texture; }
                 else if (ACC233OK == true) { C23Texture = ACC233Texture; }
                 else if (ACC234OK == true) { C23Texture = ACC234Texture; }
                 else if (ACC235OK == true) { C23Texture = ACC235Texture; }
                 else if (ACC236OK == true) { C23Texture = ACC236Texture; }
                 else if (ACC237OK == true) { C23Texture = ACC237Texture; }
                 else if (ACC238OK == true) { C23Texture = ACC238Texture; }
                 else if (ACC239OK == true) { C23Texture = ACC239Texture; }
                 else if (ACC240OK == true) { C23Texture = ACC240Texture; }
                 C24Texture = AC24Texture;
                 if (ACC241OK == true) { C24Texture = ACC241Texture; }
                 else if (ACC242OK == true) { C24Texture = ACC242Texture; }
                 else if (ACC243OK == true) { C24Texture = ACC243Texture; }
                 else if (ACC244OK == true) { C24Texture = ACC244Texture; }
                 else if (ACC245OK == true) { C24Texture = ACC245Texture; }
                 else if (ACC246OK == true) { C24Texture = ACC246Texture; }
                 else if (ACC247OK == true) { C24Texture = ACC247Texture; }
                 else if (ACC248OK == true) { C24Texture = ACC248Texture; }
                 else if (ACC249OK == true) { C24Texture = ACC249Texture; }
                 else if (ACC250OK == true) { C24Texture = ACC250Texture; }
                 else if (ACC251OK == true) { C24Texture = ACC251Texture; }
                 else if (ACC252OK == true) { C24Texture = ACC252Texture; }
                 else if (ACC253OK == true) { C24Texture = ACC253Texture; }
                 else if (ACC254OK == true) { C24Texture = ACC254Texture; }
                 else if (ACC255OK == true) { C24Texture = ACC255Texture; }
                 else if (ACC256OK == true) { C24Texture = ACC256Texture; }
                 else if (ACC257OK == true) { C24Texture = ACC257Texture; }
                 else if (ACC258OK == true) { C24Texture = ACC258Texture; }
                 else if (ACC259OK == true) { C24Texture = ACC259Texture; }
                 else if (ACC260OK == true) { C24Texture = ACC260Texture; }
                 C25Texture = AC25Texture;
                 if (ACC261OK == true) { C25Texture = ACC261Texture; }
                 else if (ACC262OK == true) { C25Texture = ACC262Texture; }
                 else if (ACC263OK == true) { C25Texture = ACC263Texture; }
                 else if (ACC264OK == true) { C25Texture = ACC264Texture; }
                 else if (ACC265OK == true) { C25Texture = ACC265Texture; }
                 else if (ACC266OK == true) { C25Texture = ACC266Texture; }
                 else if (ACC267OK == true) { C25Texture = ACC267Texture; }
                 else if (ACC268OK == true) { C25Texture = ACC268Texture; }
                 else if (ACC269OK == true) { C25Texture = ACC269Texture; }
                 else if (ACC270OK == true) { C25Texture = ACC270Texture; }
                 else if (ACC271OK == true) { C25Texture = ACC271Texture; }
                 else if (ACC272OK == true) { C25Texture = ACC272Texture; }
                 else if (ACC273OK == true) { C25Texture = ACC273Texture; }
                 else if (ACC274OK == true) { C25Texture = ACC274Texture; }
                 else if (ACC275OK == true) { C25Texture = ACC275Texture; }
                 else if (ACC276OK == true) { C25Texture = ACC276Texture; }
                 else if (ACC277OK == true) { C25Texture = ACC277Texture; }
                 else if (ACC278OK == true) { C25Texture = ACC278Texture; }
                 else if (ACC279OK == true) { C25Texture = ACC279Texture; }
                 else if (ACC280OK == true) { C25Texture = ACC280Texture; }
                 C26Texture = AC26Texture;
                 if (ACC281OK == true) { C26Texture = ACC281Texture; }
                 else if (ACC282OK == true) { C26Texture = ACC282Texture; }
                 else if (ACC283OK == true) { C26Texture = ACC283Texture; }
                 else if (ACC284OK == true) { C26Texture = ACC284Texture; }
                 else if (ACC285OK == true) { C26Texture = ACC285Texture; }
                 else if (ACC286OK == true) { C26Texture = ACC286Texture; }
                 else if (ACC287OK == true) { C26Texture = ACC287Texture; }
                 else if (ACC288OK == true) { C26Texture = ACC288Texture; }
                 else if (ACC289OK == true) { C26Texture = ACC289Texture; }
                 else if (ACC290OK == true) { C26Texture = ACC290Texture; }
                 else if (ACC291OK == true) { C26Texture = ACC291Texture; }
                 else if (ACC292OK == true) { C26Texture = ACC292Texture; }
                 else if (ACC293OK == true) { C26Texture = ACC293Texture; }
                 else if (ACC294OK == true) { C26Texture = ACC294Texture; }
                 else if (ACC295OK == true) { C26Texture = ACC295Texture; }
                 else if (ACC296OK == true) { C26Texture = ACC296Texture; }
                 else if (ACC297OK == true) { C26Texture = ACC297Texture; }
                 else if (ACC298OK == true) { C26Texture = ACC298Texture; }
                 else if (ACC299OK == true) { C26Texture = ACC299Texture; }
                 else if (ACC300OK == true) { C26Texture = ACC300Texture; }
            }
            //↓判定设施是否已建成
            foreach (Facility facility in this.ShowingArchitecture.Facilities)
            {
                if (Switch4 == "1")//设施A区开关打开,判定是否存在A区建筑
                {
                    Facilitys = facility.Name;
                    if (Facilitys == FacilityforA1)
                    {
                        FA1 = true;
                        FAN1 = FAN1 + 1;
                    }
                    else if (Facilitys == FacilityforA2)
                    {
                        FA2 = true;
                        FAN2 = FAN2 + 1;
                    }
                    else if (Facilitys == FacilityforA3)
                    {
                        FA3 = true;
                        FAN3 = FAN3 + 1;
                    }
                    else if (Facilitys == FacilityforA4)
                    {
                        FA4 = true;
                        FAN4 = FAN4 + 1;
                    }
                    else if (Facilitys == FacilityforA5)
                    {
                        FA5 = true;
                        FAN5 = FAN5 + 1;
                    }
                    else if (Facilitys == FacilityforA6)
                    {
                        FA6 = true;
                        FAN6 = FAN6 + 1;
                    }
                    else if (Facilitys == FacilityforA7)
                    {
                        FA7 = true;
                        FAN7 = FAN7 + 1;
                    }
                    else if (Facilitys == FacilityforA8)
                    {
                        FA8 = true;
                        FAN8 = FAN8 + 1;
                    }
                    else if (Facilitys == FacilityforA9)
                    {
                        FA9 = true;
                        FAN9 = FAN9 + 1;
                    }
                    else if (Facilitys == FacilityforA10)
                    {
                        FA10 = true;
                        FAN10 = FAN10 + 1;
                    }
                    else if (Facilitys == FacilityforA11)
                    {
                        FA11 = true;
                        FAN11 = FAN11 + 1;
                    }
                    else if (Facilitys == FacilityforA12)
                    {
                        FA12 = true;
                        FAN12 = FAN12 + 1;
                    }
                    else if (Facilitys == FacilityforA13)
                    {
                        FA13 = true;
                        FAN13 = FAN13 + 1;
                    }
                    else if (Facilitys == FacilityforA14)
                    {
                        FA14 = true;
                        FAN14 = FAN14 + 1;
                    }
                    else if (Facilitys == FacilityforA15)
                    {
                        FA15 = true;
                        FAN15 = FAN15 + 1;
                    }
                    else if (Facilitys == FacilityforA16)
                    {
                        FA16 = true;
                        FAN16 = FAN16 + 1;
                    }
                    else if (Facilitys == FacilityforA17)
                    {
                        FA17 = true;
                        FAN17 = FAN17 + 1;
                    }
                    else if (Facilitys == FacilityforA18)
                    {
                        FA18 = true;
                        FAN18 = FAN18 + 1;
                    }
                    else if (Facilitys == FacilityforA19)
                    {
                        FA19 = true;
                        FAN19 = FAN19 + 1;
                    }
                    else if (Facilitys == FacilityforA20)
                    {
                        FA20 = true;
                        FAN20 = FAN20 + 1;
                    }
                    else if (Facilitys == FacilityforA21)
                    {
                        FA21 = true;
                        FAN21 = FAN21 + 1;
                    }
                    else if (Facilitys == FacilityforA22)
                    {
                        FA22 = true;
                        FAN22 = FAN22 + 1;
                    }
                    else if (Facilitys == FacilityforA23)
                    {
                        FA23 = true;
                        FAN23 = FAN23 + 1;
                    }
                    else if (Facilitys == FacilityforA24)
                    {
                        FA24 = true;
                        FAN24 = FAN24 + 1;
                    }
                    else if (Facilitys == FacilityforA25)
                    {
                        FA25 = true;
                        FAN25 = FAN25 + 1;
                    }
                    else if (Facilitys == FacilityforA26)
                    {
                        FA26 = true;
                        FAN26 = FAN26 + 1;
                    }
                    else if (Facilitys == FacilityforA27)
                    {
                        FA27 = true;
                        FAN27 = FAN27 + 1;
                    }
                    else if (Facilitys == FacilityforA28)
                    {
                        FA28 = true;
                        FAN28 = FAN28 + 1;
                    }
                }

                if (Switch5 == "1")//设施B区开关打开,判定是否存在B区建筑
                {
                    Facilitys = facility.Name;
                    if (Facilitys == FacilityforB1)
                    {
                        FB1 = true;
                        FBN1 = FBN1 + 1;
                    }
                    else if (Facilitys == FacilityforB2)
                    {
                        FB2 = true;
                        FBN2 = FBN2 + 1;
                    }
                    else if (Facilitys == FacilityforB3)
                    {
                        FB3 = true;
                        FBN3 = FBN3 + 1;
                    }
                    else if (Facilitys == FacilityforB4)
                    {
                        FB4 = true;
                        FBN4 = FBN4 + 1;
                    }
                    else if (Facilitys == FacilityforB5)
                    {
                        FB5 = true;
                        FBN5 = FBN5 + 1;
                    }
                    else if (Facilitys == FacilityforB6)
                    {
                        FB6 = true;
                        FBN6 = FBN6 + 1;
                    }
                    else if (Facilitys == FacilityforB7)
                    {
                        FB7 = true;
                        FBN7 = FBN7 + 1;
                    }
                    else if (Facilitys == FacilityforB8)
                    {
                        FB8 = true;
                        FBN8 = FBN8 + 1;
                    }
                    else if (Facilitys == FacilityforB9)
                    {
                        FB9 = true;
                        FBN9 = FBN9 + 1;
                    }
                    else if (Facilitys == FacilityforB10)
                    {
                        FB10 = true;
                        FBN10 = FBN10 + 1;
                    }
                    else if (Facilitys == FacilityforB11)
                    {
                        FB11 = true;
                        FBN11 = FBN11 + 1;
                    }
                    else if (Facilitys == FacilityforB12)
                    {
                        FB12 = true;
                        FBN12 = FBN12 + 1;
                    }
                    else if (Facilitys == FacilityforB13)
                    {
                        FB13 = true;
                        FBN13 = FBN13 + 1;
                    }
                    else if (Facilitys == FacilityforB14)
                    {
                        FB14 = true;
                        FBN14 = FBN14 + 1;
                    }
                    else if (Facilitys == FacilityforB15)
                    {
                        FB15 = true;
                        FBN15 = FBN15 + 1;
                    }
                    else if (Facilitys == FacilityforB16)
                    {
                        FB16 = true;
                        FBN16 = FBN16 + 1;
                    }
                    else if (Facilitys == FacilityforB17)
                    {
                        FB17 = true;
                        FBN17 = FBN17 + 1;
                    }
                    else if (Facilitys == FacilityforB18)
                    {
                        FB18 = true;
                        FBN18 = FBN18 + 1;
                    }
                    else if (Facilitys == FacilityforB19)
                    {
                        FB19 = true;
                        FBN19 = FBN19 + 1;
                    }
                    else if (Facilitys == FacilityforB20)
                    {
                        FB20 = true;
                        FBN20 = FBN20 + 1;
                    }
                    else if (Facilitys == FacilityforB21)
                    {
                        FB21 = true;
                        FBN21 = FBN21 + 1;
                    }
                    else if (Facilitys == FacilityforB22)
                    {
                        FB22 = true;
                        FBN22 = FBN22 + 1;
                    }
                    else if (Facilitys == FacilityforB23)
                    {
                        FB23 = true;
                        FBN23 = FBN23 + 1;
                    }
                    else if (Facilitys == FacilityforB24)
                    {
                        FB24 = true;
                        FBN24 = FBN24 + 1;
                    }
                    else if (Facilitys == FacilityforB25)
                    {
                        FB25 = true;
                        FBN25 = FBN25 + 1;
                    }
                    else if (Facilitys == FacilityforB26)
                    {
                        FB26 = true;
                        FBN26 = FBN26 + 1;
                    }
                    else if (Facilitys == FacilityforB27)
                    {
                        FB27 = true;
                        FBN27 = FBN27 + 1;
                    }
                    else if (Facilitys == FacilityforB28)
                    {
                        FB28 = true;
                        FBN28 = FBN28 + 1;
                    }

                }

                if (Switch6 == "1")//设施C区开关打开,判定是否存在C区建筑
                {
                    Facilitys = facility.Name;
                    if (Facilitys == FacilityforC1)
                    {
                        FC1 = true;
                        FCN1 = FCN1 + 1;
                    }
                    else if (Facilitys == FacilityforC2)
                    {
                        FC2 = true;
                        FCN2 = FCN2 + 1;
                    }
                    else if (Facilitys == FacilityforC3)
                    {
                        FC3 = true;
                        FCN3 = FCN3 + 1;
                    }
                    else if (Facilitys == FacilityforC4)
                    {
                        FC4 = true;
                        FCN4 = FCN4 + 1;
                    }
                    else if (Facilitys == FacilityforC5)
                    {
                        FC5 = true;
                        FCN5 = FCN5 + 1;
                    }
                    else if (Facilitys == FacilityforC6)
                    {
                        FC6 = true;
                        FCN6 = FCN6 + 1;
                    }
                    else if (Facilitys == FacilityforC7)
                    {
                        FC7 = true;
                        FCN7 = FCN7 + 1;
                    }
                    else if (Facilitys == FacilityforC8)
                    {
                        FC8 = true;
                        FCN8 = FCN8 + 1;
                    }
                    else if (Facilitys == FacilityforC9)
                    {
                        FC9 = true;
                        FCN9 = FCN9 + 1;
                    }
                    else if (Facilitys == FacilityforC10)
                    {
                        FC10 = true;
                        FCN10 = FCN10 + 1;
                    }
                    else if (Facilitys == FacilityforC11)
                    {
                        FC11 = true;
                        FCN11 = FCN11 + 1;
                    }
                    else if (Facilitys == FacilityforC12)
                    {
                        FC12 = true;
                        FCN12 = FCN12 + 1;
                    }
                    else if (Facilitys == FacilityforC13)
                    {
                        FC13 = true;
                        FCN13 = FCN13 + 1;
                    }
                    else if (Facilitys == FacilityforC14)
                    {
                        FC14 = true;
                        FCN14 = FCN14 + 1;
                    }
                    else if (Facilitys == FacilityforC15)
                    {
                        FC15 = true;
                        FCN15 = FCN15 + 1;
                    }
                    else if (Facilitys == FacilityforC16)
                    {
                        FC16 = true;
                        FCN16 = FCN16 + 1;
                    }
                    else if (Facilitys == FacilityforC17)
                    {
                        FC17 = true;
                        FCN17 = FCN17 + 1;
                    }
                    else if (Facilitys == FacilityforC18)
                    {
                        FC18 = true;
                        FCN18 = FCN18 + 1;
                    }
                    else if (Facilitys == FacilityforC19)
                    {
                        FC19 = true;
                        FCN19 = FCN19 + 1;
                    }
                    else if (Facilitys == FacilityforC20)
                    {
                        FC20 = true;
                        FCN20 = FCN20 + 1;
                    }
                    else if (Facilitys == FacilityforC21)
                    {
                        FC21 = true;
                        FCN21 = FCN21 + 1;
                    }
                    else if (Facilitys == FacilityforC22)
                    {
                        FC22 = true;
                        FCN22 = FCN22 + 1;
                    }
                    else if (Facilitys == FacilityforC23)
                    {
                        FC23 = true;
                        FCN23 = FCN23 + 1;
                    }
                    else if (Facilitys == FacilityforC24)
                    {
                        FC24 = true;
                        FCN24 = FCN24 + 1;
                    }
                    else if (Facilitys == FacilityforC25)
                    {
                        FC25 = true;
                        FCN25 = FCN25 + 1;
                    }
                    else if (Facilitys == FacilityforC26)
                    {
                        FC26 = true;
                        FCN26 = FCN26 + 1;
                    }
                    else if (Facilitys == FacilityforC27)
                    {
                        FC27 = true;
                        FCN27 = FCN27 + 1;
                    }
                    else if (Facilitys == FacilityforC28)
                    {
                        FC28 = true;
                        FCN28 = FCN28 + 1;
                    }

                }
                if (Switch7 == "1")//设施D区开关打开,判定是否存在D区建筑
                {
                    Facilitys = facility.Name;
                    if (Facilitys == FacilityforD1)
                    {
                        FD1 = true;
                        FDN1 = FDN1 + 1;
                    }
                    else if (Facilitys == FacilityforD2)
                    {
                        FD2 = true;
                        FDN2 = FDN2 + 1;
                    }
                    else if (Facilitys == FacilityforD3)
                    {
                        FD3 = true;
                        FDN3 = FDN3 + 1;
                    }
                    else if (Facilitys == FacilityforD4)
                    {
                        FD4 = true;
                        FDN4 = FDN4 + 1;
                    }
                    else if (Facilitys == FacilityforD5)
                    {
                        FD5 = true;
                        FDN5 = FDN5 + 1;
                    }
                    else if (Facilitys == FacilityforD6)
                    {
                        FD6 = true;
                        FDN6 = FDN6 + 1;
                    }
                    else if (Facilitys == FacilityforD7)
                    {
                        FD7 = true;
                        FDN7 = FDN7 + 1;
                    }
                    else if (Facilitys == FacilityforD8)
                    {
                        FD8 = true;
                        FDN8 = FDN8 + 1;
                    }
                    else if (Facilitys == FacilityforD9)
                    {
                        FD9 = true;
                        FDN9 = FDN9 + 1;
                    }
                    else if (Facilitys == FacilityforD10)
                    {
                        FD10 = true;
                        FDN10 = FDN10 + 1;
                    }
                    else if (Facilitys == FacilityforD11)
                    {
                        FD11 = true;
                        FDN11 = FDN11 + 1;
                    }
                    else if (Facilitys == FacilityforD12)
                    {
                        FD12 = true;
                        FDN12 = FDN12 + 1;
                    }
                    else if (Facilitys == FacilityforD13)
                    {
                        FD13 = true;
                        FDN13 = FDN13 + 1;
                    }
                    else if (Facilitys == FacilityforD14)
                    {
                        FD14 = true;
                        FDN14 = FDN14 + 1;
                    }
                    else if (Facilitys == FacilityforD15)
                    {
                        FD15 = true;
                        FDN15 = FDN15 + 1;
                    }
                    else if (Facilitys == FacilityforD16)
                    {
                        FD16 = true;
                        FDN16 = FDN16 + 1;
                    }
                    else if (Facilitys == FacilityforD17)
                    {
                        FD17 = true;
                        FDN17 = FDN17 + 1;
                    }
                    else if (Facilitys == FacilityforD18)
                    {
                        FD18 = true;
                        FDN18 = FDN18 + 1;
                    }
                    else if (Facilitys == FacilityforD19)
                    {
                        FD19 = true;
                        FDN19 = FDN19 + 1;
                    }
                    else if (Facilitys == FacilityforD20)
                    {
                        FD20 = true;
                        FDN20 = FDN20 + 1;
                    }
                    else if (Facilitys == FacilityforD21)
                    {
                        FD21 = true;
                        FDN21 = FDN21 + 1;
                    }
                    else if (Facilitys == FacilityforD22)
                    {
                        FD22 = true;
                        FDN22 = FDN22 + 1;
                    }
                    else if (Facilitys == FacilityforD23)
                    {
                        FD23 = true;
                        FDN23 = FDN23 + 1;
                    }
                    else if (Facilitys == FacilityforD24)
                    {
                        FD24 = true;
                        FDN24 = FDN24 + 1;
                    }
                    else if (Facilitys == FacilityforD25)
                    {
                        FD25 = true;
                        FDN25 = FDN25 + 1;
                    }
                    else if (Facilitys == FacilityforD26)
                    {
                        FD26 = true;
                        FDN26 = FDN26 + 1;
                    }
                    else if (Facilitys == FacilityforD27)
                    {
                        FD27 = true;
                        FDN27 = FDN27 + 1;
                    }
                    else if (Facilitys == FacilityforD28)
                    {
                        FD28 = true;
                        FDN28 = FDN28 + 1;
                    }

                }

                if (Switch8 == "1")//设施E区开关打开,判定是否存在E区建筑
                {
                    Facilitys = facility.Name;
                    if (Facilitys == FacilityforE1)
                    {
                        FE1 = true;
                        FEN1 = FEN1 + 1;
                    }
                    else if (Facilitys == FacilityforE2)
                    {
                        FE2 = true;
                        FEN2 = FEN2 + 1;
                    }
                    else if (Facilitys == FacilityforE3)
                    {
                        FE3 = true;
                        FEN3 = FEN3 + 1;
                    }
                    else if (Facilitys == FacilityforE4)
                    {
                        FE4 = true;
                        FEN4 = FEN4 + 1;
                    }
                    else if (Facilitys == FacilityforE5)
                    {
                        FE5 = true;
                        FEN5 = FEN5 + 1;
                    }
                    else if (Facilitys == FacilityforE6)
                    {
                        FE6 = true;
                        FEN6 = FEN6 + 1;
                    }
                    else if (Facilitys == FacilityforE7)
                    {
                        FE7 = true;
                        FEN7 = FEN7 + 1;
                    }
                    else if (Facilitys == FacilityforE8)
                    {
                        FE8 = true;
                        FEN8 = FEN8 + 1;
                    }
                    else if (Facilitys == FacilityforE9)
                    {
                        FE9 = true;
                        FEN9 = FEN9 + 1;
                    }
                    else if (Facilitys == FacilityforE10)
                    {
                        FE10 = true;
                        FEN10 = FEN10 + 1;
                    }
                    else if (Facilitys == FacilityforE11)
                    {
                        FE11 = true;
                        FEN11 = FEN11 + 1;
                    }
                    else if (Facilitys == FacilityforE12)
                    {
                        FE12 = true;
                        FEN12 = FEN12 + 1;
                    }
                    else if (Facilitys == FacilityforE13)
                    {
                        FE13 = true;
                        FEN13 = FEN13 + 1;
                    }
                    else if (Facilitys == FacilityforE14)
                    {
                        FE14 = true;
                        FEN14 = FEN14 + 1;
                    }
                    else if (Facilitys == FacilityforE15)
                    {
                        FE15 = true;
                        FEN15 = FEN15 + 1;
                    }
                    else if (Facilitys == FacilityforE16)
                    {
                        FE16 = true;
                        FEN16 = FEN16 + 1;
                    }
                    else if (Facilitys == FacilityforE17)
                    {
                        FE17 = true;
                        FEN17 = FEN17 + 1;
                    }
                    else if (Facilitys == FacilityforE18)
                    {
                        FE18 = true;
                        FEN18 = FEN18 + 1;
                    }
                    else if (Facilitys == FacilityforE19)
                    {
                        FE19 = true;
                        FEN19 = FEN19 + 1;
                    }
                    else if (Facilitys == FacilityforE20)
                    {
                        FE20 = true;
                        FEN20 = FEN20 + 1;
                    }
                    else if (Facilitys == FacilityforE21)
                    {
                        FE21 = true;
                        FEN21 = FEN21 + 1;
                    }
                    else if (Facilitys == FacilityforE22)
                    {
                        FE22 = true;
                        FEN22 = FEN22 + 1;
                    }
                    else if (Facilitys == FacilityforE23)
                    {
                        FE23 = true;
                        FEN23 = FEN23 + 1;
                    }
                    else if (Facilitys == FacilityforE24)
                    {
                        FE24 = true;
                        FEN24 = FEN24 + 1;
                    }
                    else if (Facilitys == FacilityforE25)
                    {
                        FE25 = true;
                        FEN25 = FEN25 + 1;
                    }
                    else if (Facilitys == FacilityforE26)
                    {
                        FE26 = true;
                        FEN26 = FEN26 + 1;
                    }
                    else if (Facilitys == FacilityforE27)
                    {
                        FE27 = true;
                        FEN27 = FEN27 + 1;
                    }
                    else if (Facilitys == FacilityforE28)
                    {
                        FE28 = true;
                        FEN28 = FEN28 + 1;
                    }

                }

            }

            foreach (LabelText text in this.LabelTexts)
            {
                text.Text.Text = StaticMethods.GetPropertyValue(architecture, text.PropertyName).ToString();
            }
            this.CharacteristicText.AddText("特色", this.CharacteristicText.TitleColor);
            this.CharacteristicText.AddNewLine();

            foreach (Influence influence in this.ShowingArchitecture.Characteristics.Influences.Values)
            {

                this.CharacteristicText.AddText(influence.Description, this.CharacteristicText.SubTitleColor);
                this.CharacteristicText.AddNewLine();
            }
            this.CharacteristicText.ResortTexts();
            this.FacilityText.AddText("设施", this.FacilityText.TitleColor);
            this.FacilityText.AddNewLine();
            if (this.ShowingArchitecture.BuildingFacility >= 0)
            {
                FacilityKind facilityKind = this.ShowingArchitecture.Scenario.GameCommonData.AllFacilityKinds.GetFacilityKind(this.ShowingArchitecture.BuildingFacility);
                if (facilityKind != null)
                {
                    this.FacilityText.AddText("建造中：");
                    this.FacilityText.AddText(facilityKind.Name, this.FacilityText.SubTitleColor);
                    this.FacilityText.AddText("，剩余时间：");
                    this.FacilityText.AddText(this.ShowingArchitecture.BuildingDaysLeft.ToString(), this.FacilityText.SubTitleColor2);
                    this.FacilityText.AddText("天");
                    this.FacilityText.AddNewLine();
                    FacilityforIng = facilityKind.Name;  
                    FacilityforIngDay = this.ShowingArchitecture.BuildingDaysLeft.ToString();
                    FacilityIng = true;
             
                }

            }
            this.FacilityText.AddText("已有设施" + this.ShowingArchitecture.Facilities.Count + "个", this.FacilityText.SubTitleColor3);
            this.FacilityText.AddNewLine();
            foreach (Facility facility in this.ShowingArchitecture.Facilities)
            {
                this.FacilityText.AddText(facility.Name, this.FacilityText.SubTitleColor);
                this.FacilityText.AddText("，占用空间：");
                this.FacilityText.AddText(facility.PositionOccupied.ToString(), this.FacilityText.SubTitleColor2);
                this.FacilityText.AddText("，维持费用：");                            
                this.FacilityText.AddText(facility.MaintenanceCost.ToString(), this.FacilityText.SubTitleColor2);
                this.FacilityText.AddNewLine();
                

            }
            this.FacilityText.ResortTexts();
            //↓进度条对应文理
            if (Switch12 == "1")
            {

                if (this.ShowingArchitecture.MilitaryCount == 0 || this.ShowingArchitecture.ArmyQuantity == 0)
                {
                    Bar1 = 0;
                }
                    else
                {
                    Bar1 = 100 * this.ShowingArchitecture.MilitaryCount / this.ShowingArchitecture.ArmyQuantity;
                }
                if (this.ShowingArchitecture.Domination == 0 || this.ShowingArchitecture.DominationCeiling == 0)
                {
                    Bar2 = 0;
                }
                    else
                {
                    Bar2 = 100 * this.ShowingArchitecture.Domination / this.ShowingArchitecture.DominationCeiling;
                }
                if (this.ShowingArchitecture.Endurance == 0 || this.ShowingArchitecture.EnduranceCeiling == 0)
                {
                    Bar3 = 0;
                }
                    else
                {
                    Bar3 = 100 * this.ShowingArchitecture.Endurance / this.ShowingArchitecture.EnduranceCeiling;
                }
                      if (this.ShowingArchitecture.Agriculture == 0 || this.ShowingArchitecture.AgricultureCeiling == 0)
                {
                    Bar4 = 0;
                }
                    else
                {
                    Bar4 = 100 * this.ShowingArchitecture.Agriculture / this.ShowingArchitecture.AgricultureCeiling;
                }
                if (this.ShowingArchitecture.Commerce == 0 || this.ShowingArchitecture.CommerceCeiling == 0)
                {
                    Bar5 = 0;
                }
                    else
                {
                    Bar5 = 100 * this.ShowingArchitecture.Commerce / this.ShowingArchitecture.CommerceCeiling;
                }
                if (this.ShowingArchitecture.Technology == 0 || this.ShowingArchitecture.TechnologyCeiling == 0)
                {
                    Bar6 = 0;
                }
                    else
                {
                    Bar6 = 100 * this.ShowingArchitecture.Technology / this.ShowingArchitecture.TechnologyCeiling;
                }
                if (this.ShowingArchitecture.Morale == 0 || this.ShowingArchitecture.MoraleCeiling == 0)
                {
                    Bar7 = 0;
                }
                    else
                {
                    Bar7 = 100 * this.ShowingArchitecture.Morale / this.ShowingArchitecture.MoraleCeiling;
                }
                if (this.ShowingArchitecture.FacilityPositionCount - this.ShowingArchitecture.FacilityPositionLeft == 0 || this.ShowingArchitecture.FacilityPositionCount == 0)
                {
                    Bar8 = 0;
                }
                    else
                {
                    Bar8 = 100 * (this.ShowingArchitecture.FacilityPositionCount - this.ShowingArchitecture.FacilityPositionLeft) / this.ShowingArchitecture.FacilityPositionCount;
                }
                ArmyBarTexture = Army6BarTexture;
                if (Bar1 < 10)
                {
                    ArmyBarTexture = Army1BarTexture;
                }
                else if (Bar1 < 20)
                {
                    ArmyBarTexture = Army2BarTexture;
                }
                else if (Bar1 < 50)
                {
                    ArmyBarTexture = Army3BarTexture;
                }
                else if (Bar1 < 80)
                {
                    ArmyBarTexture = Army4BarTexture;
                }
                else if (Bar1 < 100)
                {
                    ArmyBarTexture = Army5BarTexture;
                }
                DominationBarTexture = Domination6BarTexture;
                if (Bar2 < 10)
                {
                    DominationBarTexture = Domination1BarTexture;
                }
                else if (Bar2 < 20)
                {
                    DominationBarTexture = Domination2BarTexture;
                }
                else if (Bar2 < 50)
                {
                    DominationBarTexture = Domination3BarTexture;
                }
                else if (Bar2 < 80)
                {
                    DominationBarTexture = Domination4BarTexture;
                }
                else if (Bar2 < 100)
                {
                    DominationBarTexture = Domination5BarTexture;
                }
                EnduranceBarTexture = Endurance6BarTexture;
                if (Bar3 < 10)
                {
                    EnduranceBarTexture = Endurance1BarTexture;
                }
                else if (Bar3 < 20)
                {
                    EnduranceBarTexture = Endurance2BarTexture;
                }
                else if (Bar3 < 50)
                {
                    EnduranceBarTexture = Endurance3BarTexture;
                }
                else if (Bar3 < 80)
                {
                    EnduranceBarTexture = Endurance4BarTexture;
                }
                else if (Bar3 < 100)
                {
                    EnduranceBarTexture = Endurance5BarTexture;
                }
                AgricultureBarTexture = Agriculture6BarTexture;
                if (Bar4 < 10)
                {
                    AgricultureBarTexture = Agriculture1BarTexture;
                }
                else if (Bar4 < 20)
                {
                    AgricultureBarTexture = Agriculture2BarTexture;
                }
                else if (Bar4 < 50)
                {
                    AgricultureBarTexture = Agriculture3BarTexture;
                }
                else if (Bar4 < 80)
                {
                    AgricultureBarTexture = Agriculture4BarTexture;
                }
                else if (Bar4 < 100)
                {
                    AgricultureBarTexture = Agriculture5BarTexture;
                }
                CommerceBarTexture = Commerce6BarTexture;
                if (Bar5 < 10)
                {
                    CommerceBarTexture = Commerce1BarTexture;
                }
                else if (Bar5 < 20)
                {
                    CommerceBarTexture = Commerce2BarTexture;
                }
                else if (Bar5 < 50)
                {
                    CommerceBarTexture = Commerce3BarTexture;
                }
                else if (Bar5 < 80)
                {
                    CommerceBarTexture = Commerce4BarTexture;
                }
                else if (Bar5 < 100)
                {
                    CommerceBarTexture = Commerce5BarTexture;
                }
                TechnologyBarTexture = Technology6BarTexture;
                if (Bar6 < 10)
                {
                    TechnologyBarTexture = Technology1BarTexture;
                }
                else if (Bar6 < 20)
                {
                    TechnologyBarTexture = Technology2BarTexture;
                }
                else if (Bar6 < 50)
                {
                    TechnologyBarTexture = Technology3BarTexture;
                }
                else if (Bar6 < 80)
                {
                    TechnologyBarTexture = Technology4BarTexture;
                }
                else if (Bar6 < 100)
                {
                    TechnologyBarTexture = Technology5BarTexture;
                }
                MoraleBarTexture = Morale6BarTexture;
                if (Bar7 < 10)
                {
                    MoraleBarTexture = Morale1BarTexture;
                }
                else if (Bar7 < 20)
                {
                    MoraleBarTexture = Morale2BarTexture;
                }
                else if (Bar7 < 50)
                {
                    MoraleBarTexture = Morale3BarTexture;
                }
                else if (Bar7 < 80)
                {
                    MoraleBarTexture = Morale4BarTexture;
                }
                else if (Bar7 < 100)
                {
                    MoraleBarTexture = Morale5BarTexture;
                }
                FacilityCountBarTexture = FacilityCount6BarTexture;
                if (Bar8 < 10)
                {
                    FacilityCountBarTexture = FacilityCount1BarTexture;
                }
                else if (Bar8 < 20)
                {
                    FacilityCountBarTexture = FacilityCount2BarTexture;
                }
                else if (Bar8 < 50)
                {
                    FacilityCountBarTexture = FacilityCount3BarTexture;
                }
                else if (Bar8 < 80)
                {
                    FacilityCountBarTexture = FacilityCount4BarTexture;
                }
                else if (Bar8 < 100)
                {
                    FacilityCountBarTexture = FacilityCount5BarTexture;
                }
  
               

            }
            
            //↓判断建筑种类对应文理
            if (Switch9 == "1")
            {
                if (AKinds == AKindfor1)
                {
                    AKBackgroundTexture = AKBackground1Texture;
                }

                else if (AKinds == AKindfor2)
                {
                    AKBackgroundTexture = AKBackground2Texture;
                }
                else if (AKinds == AKindfor3)
                {
                    AKBackgroundTexture = AKBackground3Texture;
                }
                else if (AKinds == AKindfor4)
                {
                    AKBackgroundTexture = AKBackground4Texture;
                }
                else if (AKinds == AKindfor5)
                {
                    AKBackgroundTexture = AKBackground5Texture;
                }
                else if (AKinds == AKindfor6)
                {
                    AKBackgroundTexture = AKBackground6Texture;
                }
                else if (AKinds == AKindfor7)
                {
                    AKBackgroundTexture = AKBackground7Texture;
                }
                else if (AKinds == AKindfor8)
                {
                    AKBackgroundTexture = AKBackground8Texture;
                }
                else if (AKinds == AKindfor9)
                {
                    AKBackgroundTexture = AKBackground9Texture;
                }
                else if (AKinds == AKindfor10)
                {
                    AKBackgroundTexture = AKBackground10Texture;
                }
                else if (AKinds == AKindfor11)
                {
                    AKBackgroundTexture = AKBackground11Texture;
                }
                else if (AKinds == AKindfor12)
                {
                    AKBackgroundTexture = AKBackground12Texture;
                }
                else if (AKinds == AKindfor13)
                {
                    AKBackgroundTexture = AKBackground13Texture;
                }
                else if (AKinds == AKindfor14)
                {
                    AKBackgroundTexture = AKBackground14Texture;
                }
                else if (AKinds == AKindfor15)
                {
                    AKBackgroundTexture = AKBackground15Texture;
                }
                else if (AKinds == AKindfor16)
                {
                    AKBackgroundTexture = AKBackground16Texture;
                }
                else if (AKinds == AKindfor17)
                {
                    AKBackgroundTexture = AKBackground17Texture;
                }
                else if (AKinds == AKindfor18)
                {
                    AKBackgroundTexture = AKBackground18Texture;
                }
                else if (AKinds == AKindfor19)
                {
                    AKBackgroundTexture = AKBackground19Texture;
                }
                else if (AKinds == AKindfor20)
                {
                    AKBackgroundTexture = AKBackground20Texture;
                }

                else if (AKinds == AKindfor21)
                {
                    AKBackgroundTexture = AKBackground21Texture;
                }
                else if (AKinds == AKindfor22)
                {
                    AKBackgroundTexture = AKBackground22Texture;
                }
                else if (AKinds == AKindfor23)
                {
                    AKBackgroundTexture = AKBackground23Texture;
                }
                else if (AKinds == AKindfor24)
                {
                    AKBackgroundTexture = AKBackground24Texture;
                }
                else if (AKinds == AKindfor25)
                {
                    AKBackgroundTexture = AKBackground25Texture;
                }
                else if (AKinds == AKindfor26)
                {
                    AKBackgroundTexture = AKBackground26Texture;
                }
                else if (AKinds == AKindfor27)
                {
                    AKBackgroundTexture = AKBackground27Texture;
                }
                else if (AKinds == AKindfor28)
                {
                    AKBackgroundTexture = AKBackground28Texture;
                }
                  else
            
                {
                    AKBackgroundTexture = AKBackground0Texture;
                }
            }
            //↑判断建筑种类
        }
        
        internal void SetPosition(ShowPosition showPosition)
        {
            Rectangle rectDes = new Rectangle(0, 0, this.screen.viewportSize.X, this.screen.viewportSize.Y);
            Rectangle rect = new Rectangle(0, 0, this.BackgroundSize.X, this.BackgroundSize.Y);
            switch (showPosition)
            {
                case ShowPosition.Center:
                    rect = StaticMethods.GetCenterRectangle(rectDes, rect);
                    break;

                case ShowPosition.Top:
                    rect = StaticMethods.GetTopRectangle(rectDes, rect);
                    break;

                case ShowPosition.Left:
                    rect = StaticMethods.GetLeftRectangle(rectDes, rect);
                    break;

                case ShowPosition.Right:
                    rect = StaticMethods.GetRightRectangle(rectDes, rect);
                    break;

                case ShowPosition.Bottom:
                    rect = StaticMethods.GetBottomRectangle(rectDes, rect);
                    break;

                case ShowPosition.TopLeft:
                    rect = StaticMethods.GetTopLeftRectangle(rectDes, rect);
                    break;

                case ShowPosition.TopRight:
                    rect = StaticMethods.GetTopRightRectangle(rectDes, rect);
                    break;

                case ShowPosition.BottomLeft:
                    rect = StaticMethods.GetBottomLeftRectangle(rectDes, rect);
                    break;

                case ShowPosition.BottomRight:
                    rect = StaticMethods.GetBottomRightRectangle(rectDes, rect);
                    break;
            }
            this.DisplayOffset = new Point(rect.X, rect.Y);
            foreach (LabelText text in this.LabelTexts)
            {
                text.Label.DisplayOffset = this.DisplayOffset;
                text.Text.DisplayOffset = this.DisplayOffset;
            }
            this.CharacteristicText.DisplayOffset = new Point(this.DisplayOffset.X + this.CharacteristicClient.X, this.DisplayOffset.Y + this.CharacteristicClient.Y);
            this.FacilityText.DisplayOffset = new Point(this.DisplayOffset.X + this.FacilityClient.X, this.DisplayOffset.Y + this.FacilityClient.Y);
            this.FacilityAText.DisplayOffset = new Point(this.DisplayOffset.X + this.FacilityATextClient.X, this.DisplayOffset.Y + this.FacilityATextClient.Y);
            this.FacilityBText.DisplayOffset = new Point(this.DisplayOffset.X + this.FacilityBTextClient.X, this.DisplayOffset.Y + this.FacilityBTextClient.Y);
            this.FacilityCText.DisplayOffset = new Point(this.DisplayOffset.X + this.FacilityCTextClient.X, this.DisplayOffset.Y + this.FacilityCTextClient.Y);
            this.FacilityDText.DisplayOffset = new Point(this.DisplayOffset.X + this.FacilityDTextClient.X, this.DisplayOffset.Y + this.FacilityDTextClient.Y);
            this.FacilityEText.DisplayOffset = new Point(this.DisplayOffset.X + this.FacilityETextClient.X, this.DisplayOffset.Y + this.FacilityETextClient.Y);
            this.FacilityZText.DisplayOffset = new Point(this.DisplayOffset.X + this.FacilityZTextClient.X, this.DisplayOffset.Y + this.FacilityZTextClient.Y);
            this.FacilitySText.DisplayOffset = new Point(this.DisplayOffset.X + this.FacilitySTextClient.X, this.DisplayOffset.Y + this.FacilitySTextClient.Y);
        }

        private Rectangle BackgroundDisplayPosition
        {
            get
            {
                return new Rectangle(this.DisplayOffset.X, this.DisplayOffset.Y, this.BackgroundSize.X, this.BackgroundSize.Y);
            }
        }
        //////////↓背景图片大小及位置判定
        //↓建筑图片大小及位置判定
        private Rectangle BackgroundforArchitectureDisplayPosition
        {
            get
            {
                if (NewArchitectureButton == true)
                {
                    return new Rectangle(this.BackgroundforArchitectureClient.X + this.DisplayOffset.X, this.BackgroundforArchitectureClient.Y + this.DisplayOffset.Y, this.BackgroundforArchitectureClient.Width, this.BackgroundforArchitectureClient.Height);
                }
                else
                {
                    return new Rectangle(this.BackgroundforArchitectureClient.X + this.DisplayOffset.X, this.BackgroundforArchitectureClient.Y + this.DisplayOffset.Y, 0, 0);
                }

            }
        }
        private Rectangle ACBackgroundDisplayPosition
        {
            get
            {
                if (NewArchitectureButton == true)
                {
                    return new Rectangle(this.ACBackgroundClient.X + this.DisplayOffset.X, this.ACBackgroundClient.Y + this.DisplayOffset.Y, this.ACBackgroundClient.Width, this.ACBackgroundClient.Height);
                }
                else
                {
                    return new Rectangle(this.ACBackgroundClient.X + this.DisplayOffset.X, this.ACBackgroundClient.Y + this.DisplayOffset.Y, 0, 0);
                }

            }
        }
         private Rectangle TextBackgroundDisplayPosition
        {
            get
            {
                if (FacilityTexton == true)
                {
                    return new Rectangle(this.TextBackgroundClient.X + this.DisplayOffset.X, this.TextBackgroundClient.Y + this.DisplayOffset.Y, this.TextBackgroundClient.Width, this.TextBackgroundClient.Height);
                }
                else
                {
                    return new Rectangle(this.TextBackgroundClient.X + this.DisplayOffset.X, this.TextBackgroundClient.Y + this.DisplayOffset.Y, 0, 0);
                }

            }
        }
         private Rectangle AuxiliaryBackgroundDisplayPosition
         {
             get
             {
                 if (FacilityforSButton == true)
                 {
                     return new Rectangle(this.AuxiliaryBackgroundClient.X + this.DisplayOffset.X, this.AuxiliaryBackgroundClient.Y + this.DisplayOffset.Y, this.AuxiliaryBackgroundClient.Width, this.AuxiliaryBackgroundClient.Height);
                 }
                 else
                 {
                     return new Rectangle(this.AuxiliaryBackgroundClient.X + this.DisplayOffset.X, this.AuxiliaryBackgroundClient.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
        
        //↓建筑类型图片大小及位置判定
        private Rectangle AKBackgroundDisplayPosition
        {
            get
            {
                if (Switch9 == "1" && NewArchitectureButton == true)
                {
                    return new Rectangle(this.AKBackground0Client.X + this.DisplayOffset.X, this.AKBackground0Client.Y + this.DisplayOffset.Y, this.AKBackground0Client.Width, this.AKBackground0Client.Height);
                }
                else
                {
                    return new Rectangle(this.AKBackground0Client.X + this.DisplayOffset.X, this.AKBackground0Client.Y + this.DisplayOffset.Y,0,0);
                }
              
            }
        }
        private Rectangle AIDDisplayPosition
        {
            get
            {
                if (Switch10 == "1" && NewArchitectureButton == true)
                {
                    return new Rectangle(this.AIDClient.X + this.DisplayOffset.X, this.AIDClient.Y + this.DisplayOffset.Y, this.AIDClient.Width, this.AIDClient.Height);
                }
                else
                {
                    return new Rectangle(this.AIDClient.X + this.DisplayOffset.X, this.AIDClient.Y + this.DisplayOffset.Y, 0, 0);
                }

            }
        }
        //↓设施A区图片大小及位置判定
        private Rectangle FABackgroundDisplayPosition
        {
            get
            {
                if (FacilityforAButton == true)
                {
                    return new Rectangle(this.FABackground0Client.X + this.DisplayOffset.X, this.FABackground0Client.Y + this.DisplayOffset.Y, this.FABackground0Client.Width, this.FABackground0Client.Height);
                }
                else
                {
                    return new Rectangle(this.FABackground0Client.X + this.DisplayOffset.X, this.FABackground0Client.Y + this.DisplayOffset.Y, 0, 0);
                }

            }
        }
        //↓设施B区图片大小及位置判定
        private Rectangle FBBackgroundDisplayPosition
        {
            get
            {
                if (FacilityforBButton == true)
                {
                    return new Rectangle(this.FBBackground0Client.X + this.DisplayOffset.X, this.FBBackground0Client.Y + this.DisplayOffset.Y, this.FBBackground0Client.Width, this.FBBackground0Client.Height);
                }
                else
                {
                    return new Rectangle(this.FBBackground0Client.X + this.DisplayOffset.X, this.FBBackground0Client.Y + this.DisplayOffset.Y, 0, 0);
                }

            }
        }
        //↓设施C区图片大小及位置判定
        private Rectangle FCBackgroundDisplayPosition
        {
            get
            {
                if (FacilityforCButton == true)
                {
                    return new Rectangle(this.FCBackground0Client.X + this.DisplayOffset.X, this.FCBackground0Client.Y + this.DisplayOffset.Y, this.FCBackground0Client.Width, this.FCBackground0Client.Height);
                }
                else
                {
                    return new Rectangle(this.FCBackground0Client.X + this.DisplayOffset.X, this.FCBackground0Client.Y + this.DisplayOffset.Y, 0, 0);
                }

            }
        }
        //↓设施D区图片大小及位置判定
        private Rectangle FDBackgroundDisplayPosition
        {
            get
            {
                if (FacilityforDButton == true)
                {
                    return new Rectangle(this.FDBackground0Client.X + this.DisplayOffset.X, this.FDBackground0Client.Y + this.DisplayOffset.Y, this.FDBackground0Client.Width, this.FDBackground0Client.Height);
                }
                else
                {
                    return new Rectangle(this.FDBackground0Client.X + this.DisplayOffset.X, this.FDBackground0Client.Y + this.DisplayOffset.Y, 0, 0);
                }

            }
        }
        //↓设施E区图片大小及位置判定
        private Rectangle FEBackgroundDisplayPosition
        {
            get
            {
                if (FacilityforEButton == true)
                {
                    return new Rectangle(this.FEBackground0Client.X + this.DisplayOffset.X, this.FEBackground0Client.Y + this.DisplayOffset.Y, this.FEBackground0Client.Width, this.FEBackground0Client.Height);
                }
                else
                {
                    return new Rectangle(this.FEBackground0Client.X + this.DisplayOffset.X, this.FEBackground0Client.Y + this.DisplayOffset.Y, 0, 0);
                }

            }
        }
        //////////↓按钮图片大小及位置判定
        //↓原建筑图片按钮大小及位置判定
        private Rectangle ArchitectureButtonDisplayPosition
        {
            get
            {
                if (Switch1 == "1" && ArchitectureButton == false)
                {
                    return new Rectangle(this.ArchitectureButtonClient.X + this.DisplayOffset.X, this.ArchitectureButtonClient.Y + this.DisplayOffset.Y, this.ArchitectureButtonClient.Width, this.ArchitectureButtonClient.Height);
                }
                else
                {
                    return new Rectangle(this.ArchitectureButtonClient.X + this.DisplayOffset.X, this.ArchitectureButtonClient.Y + this.DisplayOffset.Y, 0, 0);
                }

            }
        }
        private Rectangle ArchitecturePressedDisplayPosition
        {
            get
            {
                if (Switch1 == "1" && ArchitectureButton == true)
                {
                    return new Rectangle(this.ArchitectureButtonClient.X + this.DisplayOffset.X, this.ArchitectureButtonClient.Y + this.DisplayOffset.Y, this.ArchitectureButtonClient.Width, this.ArchitectureButtonClient.Height);
                }
                else
                {
                    return new Rectangle(this.ArchitectureButtonClient.X + this.DisplayOffset.X, this.ArchitectureButtonClient.Y + this.DisplayOffset.Y, 0, 0);
                }

            }
        }

        //↓新建筑按钮大小及位置判定
        private Rectangle ArchitectureKindButtonDisplayPosition
        {
            get
            {
                if (Switch2 == "1" && NewArchitectureButton == false)
                {
                    return new Rectangle(this.ArchitectureKindButtonClient.X + this.DisplayOffset.X, this.ArchitectureKindButtonClient.Y + this.DisplayOffset.Y, this.ArchitectureKindButtonClient.Width, this.ArchitectureKindButtonClient.Height);
                }
                else
                {
                    return new Rectangle(this.ArchitectureKindButtonClient.X + this.DisplayOffset.X, this.ArchitectureKindButtonClient.Y + this.DisplayOffset.Y,0,0);
                }

            }
        }
        private Rectangle ArchitectureKindPressedDisplayPosition
        {
            get
            {
                if (Switch2 == "1" && NewArchitectureButton == true)
                {
                    return new Rectangle(this.ArchitectureKindButtonClient.X + this.DisplayOffset.X, this.ArchitectureKindButtonClient.Y + this.DisplayOffset.Y, this.ArchitectureKindButtonClient.Width, this.ArchitectureKindButtonClient.Height);
                }
                else
                {
                    return new Rectangle(this.ArchitectureKindButtonClient.X + this.DisplayOffset.X, this.ArchitectureKindButtonClient.Y + this.DisplayOffset.Y, 0, 0);
                }

            }
        }
        //↓设施A区按钮大小及位置判定
        private Rectangle FacilityforAButtonDisplayPosition
        {
            get
            {
                if (Switch4 == "1" && FacilityforAButton == false)
                {
                    return new Rectangle(this.FacilityforAButtonClient.X + this.DisplayOffset.X, this.FacilityforAButtonClient.Y + this.DisplayOffset.Y, this.FacilityforAButtonClient.Width, this.FacilityforAButtonClient.Height);
                }
                else
                {
                    return new Rectangle(this.FacilityforAButtonClient.X + this.DisplayOffset.X, this.FacilityforAButtonClient.Y + this.DisplayOffset.Y, 0, 0);
                }

            }
        }
        private Rectangle FacilityforAPressedDisplayPosition
        {
            get
            {
                if (Switch4 == "1" && FacilityforAButton == true)
                {
                    return new Rectangle(this.FacilityforAButtonClient.X + this.DisplayOffset.X, this.FacilityforAButtonClient.Y + this.DisplayOffset.Y, this.FacilityforAButtonClient.Width, this.FacilityforAButtonClient.Height);
                }
                else
                {
                    return new Rectangle(this.FacilityforAButtonClient.X + this.DisplayOffset.X, this.FacilityforAButtonClient.Y + this.DisplayOffset.Y, 0, 0);
                }

            }
        }
        //↓设施B区按钮大小及位置判定
        private Rectangle FacilityforBButtonDisplayPosition
        {
            get
            {
                if (Switch5 == "1" && FacilityforBButton == false)
                {
                    return new Rectangle(this.FacilityforBButtonClient.X + this.DisplayOffset.X, this.FacilityforBButtonClient.Y + this.DisplayOffset.Y, this.FacilityforBButtonClient.Width, this.FacilityforBButtonClient.Height);
                }
                else
                {
                    return new Rectangle(this.FacilityforBButtonClient.X + this.DisplayOffset.X, this.FacilityforBButtonClient.Y + this.DisplayOffset.Y, 0, 0);
                }

            }
        }
        private Rectangle FacilityforBPressedDisplayPosition
        {
            get
            {
                if (Switch5 == "1" && FacilityforBButton == true)
                {
                    return new Rectangle(this.FacilityforBButtonClient.X + this.DisplayOffset.X, this.FacilityforBButtonClient.Y + this.DisplayOffset.Y, this.FacilityforBButtonClient.Width, this.FacilityforBButtonClient.Height);
                }
                else
                {
                    return new Rectangle(this.FacilityforBButtonClient.X + this.DisplayOffset.X, this.FacilityforBButtonClient.Y + this.DisplayOffset.Y, 0, 0);
                }

            }
        }
        //↓设施C区按钮大小及位置判定
        private Rectangle FacilityforCButtonDisplayPosition
        {
            get
            {
                if (Switch6 == "1" && FacilityforCButton == false)
                {
                    return new Rectangle(this.FacilityforCButtonClient.X + this.DisplayOffset.X, this.FacilityforCButtonClient.Y + this.DisplayOffset.Y, this.FacilityforCButtonClient.Width, this.FacilityforCButtonClient.Height);
                }
                else
                {
                    return new Rectangle(this.FacilityforCButtonClient.X + this.DisplayOffset.X, this.FacilityforCButtonClient.Y + this.DisplayOffset.Y, 0, 0);
                }

            }
        }
        private Rectangle FacilityforCPressedDisplayPosition
        {
            get
            {
                if (Switch6 == "1" && FacilityforCButton == true)
                {
                    return new Rectangle(this.FacilityforCButtonClient.X + this.DisplayOffset.X, this.FacilityforCButtonClient.Y + this.DisplayOffset.Y, this.FacilityforCButtonClient.Width, this.FacilityforCButtonClient.Height);
                }
                else
                {
                    return new Rectangle(this.FacilityforCButtonClient.X + this.DisplayOffset.X, this.FacilityforCButtonClient.Y + this.DisplayOffset.Y, 0, 0);
                }

            }
        }
        //↓设施D区按钮大小及位置判定
        private Rectangle FacilityforDButtonDisplayPosition
        {
            get
            {
                if (Switch7 == "1" && FacilityforDButton == false)
                {
                    return new Rectangle(this.FacilityforDButtonClient.X + this.DisplayOffset.X, this.FacilityforDButtonClient.Y + this.DisplayOffset.Y, this.FacilityforDButtonClient.Width, this.FacilityforDButtonClient.Height);
                }
                else
                {
                    return new Rectangle(this.FacilityforDButtonClient.X + this.DisplayOffset.X, this.FacilityforDButtonClient.Y + this.DisplayOffset.Y, 0, 0);
                }

            }
        }
        private Rectangle FacilityforDPressedDisplayPosition
        {
            get
            {
                if (Switch7 == "1" && FacilityforDButton == true)
                {
                    return new Rectangle(this.FacilityforDButtonClient.X + this.DisplayOffset.X, this.FacilityforDButtonClient.Y + this.DisplayOffset.Y, this.FacilityforDButtonClient.Width, this.FacilityforDButtonClient.Height);
                }
                else
                {
                    return new Rectangle(this.FacilityforDButtonClient.X + this.DisplayOffset.X, this.FacilityforDButtonClient.Y + this.DisplayOffset.Y, 0, 0);
                }

            }
        }
        //↓设施E区按钮大小及位置判定
        private Rectangle FacilityforEButtonDisplayPosition
        {
            get
            {
                if (Switch8 == "1" && FacilityforEButton == false)
                {
                    return new Rectangle(this.FacilityforEButtonClient.X + this.DisplayOffset.X, this.FacilityforEButtonClient.Y + this.DisplayOffset.Y, this.FacilityforEButtonClient.Width, this.FacilityforEButtonClient.Height);
                }
                else
                {
                    return new Rectangle(this.FacilityforEButtonClient.X + this.DisplayOffset.X, this.FacilityforEButtonClient.Y + this.DisplayOffset.Y, 0, 0);
                }

            }
        }
        private Rectangle FacilityforEPressedDisplayPosition
        {
            get
            {
                if (Switch8 == "1" && FacilityforEButton == true)
                {
                    return new Rectangle(this.FacilityforEButtonClient.X + this.DisplayOffset.X, this.FacilityforEButtonClient.Y + this.DisplayOffset.Y, this.FacilityforEButtonClient.Width, this.FacilityforEButtonClient.Height);
                }
                else
                {
                    return new Rectangle(this.FacilityforEButtonClient.X + this.DisplayOffset.X, this.FacilityforEButtonClient.Y + this.DisplayOffset.Y, 0, 0);
                }

            }
        }
        //↓辅助页按钮大小及位置判定
        private Rectangle FacilityforSButtonDisplayPosition
        {
            get
            {
                if (Switch13 == "1" && FacilityforSButton == false)
                {
                    return new Rectangle(this.FacilityforSButtonClient.X + this.DisplayOffset.X, this.FacilityforSButtonClient.Y + this.DisplayOffset.Y, this.FacilityforSButtonClient.Width, this.FacilityforSButtonClient.Height);
                }
                else
                {
                    return new Rectangle(this.FacilityforSButtonClient.X + this.DisplayOffset.X, this.FacilityforSButtonClient.Y + this.DisplayOffset.Y, 0, 0);
                }

            }
        }
        private Rectangle FacilityforSPressedDisplayPosition
        {
            get
            {
                if (Switch13 == "1" && FacilityforSButton == true)
                {
                    return new Rectangle(this.FacilityforSButtonClient.X + this.DisplayOffset.X, this.FacilityforSButtonClient.Y + this.DisplayOffset.Y, this.FacilityforSButtonClient.Width, this.FacilityforSButtonClient.Height);
                }
                else
                {
                    return new Rectangle(this.FacilityforSButtonClient.X + this.DisplayOffset.X, this.FacilityforSButtonClient.Y + this.DisplayOffset.Y, 0, 0);
                }

            }
        }
       //////////↓设施图片大小及位置设置判定
        //↓A区设施
         private Rectangle FacilityforA1DisplayPosition
        {
            get
            {
                if (FA1 == true && FacilityforAButton == true)
                {
                    return new Rectangle(this.FacilityforA1Client.X + this.DisplayOffset.X, this.FacilityforA1Client.Y + this.DisplayOffset.Y, this.FacilityforA1Client.Width, this.FacilityforA1Client.Height);
                }
                else
                {
                    return new Rectangle(this.FacilityforA1Client.X + this.DisplayOffset.X, this.FacilityforA1Client.Y + this.DisplayOffset.Y, 0, 0);
                }

            }
        }
         private Rectangle FacilityforA2DisplayPosition
         {
             get
             {
                 if (FA2 == true && FacilityforAButton == true)
                 {
                     return new Rectangle(this.FacilityforA2Client.X + this.DisplayOffset.X, this.FacilityforA2Client.Y + this.DisplayOffset.Y, this.FacilityforA2Client.Width, this.FacilityforA2Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforA2Client.X + this.DisplayOffset.X, this.FacilityforA2Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforA3DisplayPosition
         {
             get
             {
                 if (FA3 == true && FacilityforAButton == true)
                 {
                     return new Rectangle(this.FacilityforA3Client.X + this.DisplayOffset.X, this.FacilityforA3Client.Y + this.DisplayOffset.Y, this.FacilityforA3Client.Width, this.FacilityforA3Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforA3Client.X + this.DisplayOffset.X, this.FacilityforA3Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforA4DisplayPosition
         {
             get
             {
                 if (FA4 == true && FacilityforAButton == true)
                 {
                     return new Rectangle(this.FacilityforA4Client.X + this.DisplayOffset.X, this.FacilityforA4Client.Y + this.DisplayOffset.Y, this.FacilityforA4Client.Width, this.FacilityforA4Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforA4Client.X + this.DisplayOffset.X, this.FacilityforA4Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforA5DisplayPosition
         {
             get
             {
                 if (FA5 == true && FacilityforAButton == true)
                 {
                     return new Rectangle(this.FacilityforA5Client.X + this.DisplayOffset.X, this.FacilityforA5Client.Y + this.DisplayOffset.Y, this.FacilityforA5Client.Width, this.FacilityforA5Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforA5Client.X + this.DisplayOffset.X, this.FacilityforA5Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforA6DisplayPosition
         {
             get
             {
                 if (FA6 == true && FacilityforAButton == true)
                 {
                     return new Rectangle(this.FacilityforA6Client.X + this.DisplayOffset.X, this.FacilityforA6Client.Y + this.DisplayOffset.Y, this.FacilityforA6Client.Width, this.FacilityforA6Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforA6Client.X + this.DisplayOffset.X, this.FacilityforA6Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforA7DisplayPosition
         {
             get
             {
                 if (FA7 == true && FacilityforAButton == true)
                 {
                     return new Rectangle(this.FacilityforA7Client.X + this.DisplayOffset.X, this.FacilityforA7Client.Y + this.DisplayOffset.Y, this.FacilityforA7Client.Width, this.FacilityforA7Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforA7Client.X + this.DisplayOffset.X, this.FacilityforA7Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforA8DisplayPosition
         {
             get
             {
                 if (FA8 == true && FacilityforAButton == true)
                 {
                     return new Rectangle(this.FacilityforA8Client.X + this.DisplayOffset.X, this.FacilityforA8Client.Y + this.DisplayOffset.Y, this.FacilityforA8Client.Width, this.FacilityforA8Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforA8Client.X + this.DisplayOffset.X, this.FacilityforA8Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforA9DisplayPosition
         {
             get
             {
                 if (FA9 == true && FacilityforAButton == true)
                 {
                     return new Rectangle(this.FacilityforA9Client.X + this.DisplayOffset.X, this.FacilityforA9Client.Y + this.DisplayOffset.Y, this.FacilityforA9Client.Width, this.FacilityforA9Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforA9Client.X + this.DisplayOffset.X, this.FacilityforA9Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforA10DisplayPosition
         {
             get
             {
                 if (FA10 == true && FacilityforAButton == true)
                 {
                     return new Rectangle(this.FacilityforA10Client.X + this.DisplayOffset.X, this.FacilityforA10Client.Y + this.DisplayOffset.Y, this.FacilityforA10Client.Width, this.FacilityforA10Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforA10Client.X + this.DisplayOffset.X, this.FacilityforA10Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforA11DisplayPosition
         {
             get
             {
                 if (FA11 == true && FacilityforAButton == true)
                 {
                     return new Rectangle(this.FacilityforA11Client.X + this.DisplayOffset.X, this.FacilityforA11Client.Y + this.DisplayOffset.Y, this.FacilityforA11Client.Width, this.FacilityforA11Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforA11Client.X + this.DisplayOffset.X, this.FacilityforA11Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforA12DisplayPosition
         {
             get
             {
                 if (FA12 == true && FacilityforAButton == true)
                 {
                     return new Rectangle(this.FacilityforA12Client.X + this.DisplayOffset.X, this.FacilityforA12Client.Y + this.DisplayOffset.Y, this.FacilityforA12Client.Width, this.FacilityforA12Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforA12Client.X + this.DisplayOffset.X, this.FacilityforA12Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforA13DisplayPosition
         {
             get
             {
                 if (FA13 == true && FacilityforAButton == true)
                 {
                     return new Rectangle(this.FacilityforA13Client.X + this.DisplayOffset.X, this.FacilityforA13Client.Y + this.DisplayOffset.Y, this.FacilityforA13Client.Width, this.FacilityforA13Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforA13Client.X + this.DisplayOffset.X, this.FacilityforA13Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforA14DisplayPosition
         {
             get
             {
                 if (FA14 == true && FacilityforAButton == true)
                 {
                     return new Rectangle(this.FacilityforA14Client.X + this.DisplayOffset.X, this.FacilityforA14Client.Y + this.DisplayOffset.Y, this.FacilityforA14Client.Width, this.FacilityforA14Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforA14Client.X + this.DisplayOffset.X, this.FacilityforA14Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforA15DisplayPosition
         {
             get
             {
                 if (FA15 == true && FacilityforAButton == true)
                 {
                     return new Rectangle(this.FacilityforA15Client.X + this.DisplayOffset.X, this.FacilityforA15Client.Y + this.DisplayOffset.Y, this.FacilityforA15Client.Width, this.FacilityforA15Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforA15Client.X + this.DisplayOffset.X, this.FacilityforA15Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforA16DisplayPosition
         {
             get
             {
                 if (FA16 == true && FacilityforAButton == true)
                 {
                     return new Rectangle(this.FacilityforA16Client.X + this.DisplayOffset.X, this.FacilityforA16Client.Y + this.DisplayOffset.Y, this.FacilityforA16Client.Width, this.FacilityforA16Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforA16Client.X + this.DisplayOffset.X, this.FacilityforA16Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforA17DisplayPosition
         {
             get
             {
                 if (FA17 == true && FacilityforAButton == true)
                 {
                     return new Rectangle(this.FacilityforA17Client.X + this.DisplayOffset.X, this.FacilityforA17Client.Y + this.DisplayOffset.Y, this.FacilityforA17Client.Width, this.FacilityforA17Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforA17Client.X + this.DisplayOffset.X, this.FacilityforA17Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforA18DisplayPosition
         {
             get
             {
                 if (FA18 == true && FacilityforAButton == true)
                 {
                     return new Rectangle(this.FacilityforA18Client.X + this.DisplayOffset.X, this.FacilityforA18Client.Y + this.DisplayOffset.Y, this.FacilityforA18Client.Width, this.FacilityforA18Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforA18Client.X + this.DisplayOffset.X, this.FacilityforA18Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforA19DisplayPosition
         {
             get
             {
                 if (FA19 == true && FacilityforAButton == true)
                 {
                     return new Rectangle(this.FacilityforA19Client.X + this.DisplayOffset.X, this.FacilityforA19Client.Y + this.DisplayOffset.Y, this.FacilityforA19Client.Width, this.FacilityforA19Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforA19Client.X + this.DisplayOffset.X, this.FacilityforA19Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforA20DisplayPosition
         {
             get
             {
                 if (FA20 == true && FacilityforAButton == true)
                 {
                     return new Rectangle(this.FacilityforA20Client.X + this.DisplayOffset.X, this.FacilityforA20Client.Y + this.DisplayOffset.Y, this.FacilityforA20Client.Width, this.FacilityforA20Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforA20Client.X + this.DisplayOffset.X, this.FacilityforA20Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforA21DisplayPosition
         {
             get
             {
                 if (FA21 == true && FacilityforAButton == true)
                 {
                     return new Rectangle(this.FacilityforA21Client.X + this.DisplayOffset.X, this.FacilityforA21Client.Y + this.DisplayOffset.Y, this.FacilityforA21Client.Width, this.FacilityforA21Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforA21Client.X + this.DisplayOffset.X, this.FacilityforA21Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforA22DisplayPosition
         {
             get
             {
                 if (FA22 == true && FacilityforAButton == true)
                 {
                     return new Rectangle(this.FacilityforA22Client.X + this.DisplayOffset.X, this.FacilityforA22Client.Y + this.DisplayOffset.Y, this.FacilityforA22Client.Width, this.FacilityforA22Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforA22Client.X + this.DisplayOffset.X, this.FacilityforA22Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforA23DisplayPosition
         {
             get
             {
                 if (FA23 == true && FacilityforAButton == true)
                 {
                     return new Rectangle(this.FacilityforA23Client.X + this.DisplayOffset.X, this.FacilityforA23Client.Y + this.DisplayOffset.Y, this.FacilityforA23Client.Width, this.FacilityforA23Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforA23Client.X + this.DisplayOffset.X, this.FacilityforA23Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforA24DisplayPosition
         {
             get
             {
                 if (FA24 == true && FacilityforAButton == true)
                 {
                     return new Rectangle(this.FacilityforA24Client.X + this.DisplayOffset.X, this.FacilityforA24Client.Y + this.DisplayOffset.Y, this.FacilityforA24Client.Width, this.FacilityforA24Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforA24Client.X + this.DisplayOffset.X, this.FacilityforA24Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforA25DisplayPosition
         {
             get
             {
                 if (FA25 == true && FacilityforAButton == true)
                 {
                     return new Rectangle(this.FacilityforA25Client.X + this.DisplayOffset.X, this.FacilityforA25Client.Y + this.DisplayOffset.Y, this.FacilityforA25Client.Width, this.FacilityforA25Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforA25Client.X + this.DisplayOffset.X, this.FacilityforA25Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforA26DisplayPosition
         {
             get
             {
                 if (FA26 == true && FacilityforAButton == true)
                 {
                     return new Rectangle(this.FacilityforA26Client.X + this.DisplayOffset.X, this.FacilityforA26Client.Y + this.DisplayOffset.Y, this.FacilityforA26Client.Width, this.FacilityforA26Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforA26Client.X + this.DisplayOffset.X, this.FacilityforA26Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforA27DisplayPosition
         {
             get
             {
                 if (FA27 == true && FacilityforAButton == true)
                 {
                     return new Rectangle(this.FacilityforA27Client.X + this.DisplayOffset.X, this.FacilityforA27Client.Y + this.DisplayOffset.Y, this.FacilityforA27Client.Width, this.FacilityforA27Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforA27Client.X + this.DisplayOffset.X, this.FacilityforA27Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforA28DisplayPosition
         {
             get
             {
                 if (FA28 == true && FacilityforAButton == true)
                 {
                     return new Rectangle(this.FacilityforA28Client.X + this.DisplayOffset.X, this.FacilityforA28Client.Y + this.DisplayOffset.Y, this.FacilityforA28Client.Width, this.FacilityforA28Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforA28Client.X + this.DisplayOffset.X, this.FacilityforA28Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         //↓B区设施
         private Rectangle FacilityforB1DisplayPosition
         {
             get
             {
                 if (FB1 == true && FacilityforBButton == true)
                 {
                     return new Rectangle(this.FacilityforB1Client.X + this.DisplayOffset.X, this.FacilityforB1Client.Y + this.DisplayOffset.Y, this.FacilityforB1Client.Width, this.FacilityforB1Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforB1Client.X + this.DisplayOffset.X, this.FacilityforB1Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforB2DisplayPosition
         {
             get
             {
                 if (FB2 == true && FacilityforBButton == true)
                 {
                     return new Rectangle(this.FacilityforB2Client.X + this.DisplayOffset.X, this.FacilityforB2Client.Y + this.DisplayOffset.Y, this.FacilityforB2Client.Width, this.FacilityforB2Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforB2Client.X + this.DisplayOffset.X, this.FacilityforB2Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforB3DisplayPosition
         {
             get
             {
                 if (FB3 == true && FacilityforBButton == true)
                 {
                     return new Rectangle(this.FacilityforB3Client.X + this.DisplayOffset.X, this.FacilityforB3Client.Y + this.DisplayOffset.Y, this.FacilityforB3Client.Width, this.FacilityforB3Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforB3Client.X + this.DisplayOffset.X, this.FacilityforB3Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforB4DisplayPosition
         {
             get
             {
                 if (FB4 == true && FacilityforBButton == true)
                 {
                     return new Rectangle(this.FacilityforB4Client.X + this.DisplayOffset.X, this.FacilityforB4Client.Y + this.DisplayOffset.Y, this.FacilityforB4Client.Width, this.FacilityforB4Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforB4Client.X + this.DisplayOffset.X, this.FacilityforB4Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforB5DisplayPosition
         {
             get
             {
                 if (FB5 == true && FacilityforBButton == true)
                 {
                     return new Rectangle(this.FacilityforB5Client.X + this.DisplayOffset.X, this.FacilityforB5Client.Y + this.DisplayOffset.Y, this.FacilityforB5Client.Width, this.FacilityforB5Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforB5Client.X + this.DisplayOffset.X, this.FacilityforB5Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforB6DisplayPosition
         {
             get
             {
                 if (FB6 == true && FacilityforBButton == true)
                 {
                     return new Rectangle(this.FacilityforB6Client.X + this.DisplayOffset.X, this.FacilityforB6Client.Y + this.DisplayOffset.Y, this.FacilityforB6Client.Width, this.FacilityforB6Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforB6Client.X + this.DisplayOffset.X, this.FacilityforB6Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforB7DisplayPosition
         {
             get
             {
                 if (FB7 == true && FacilityforBButton == true)
                 {
                     return new Rectangle(this.FacilityforB7Client.X + this.DisplayOffset.X, this.FacilityforB7Client.Y + this.DisplayOffset.Y, this.FacilityforB7Client.Width, this.FacilityforB7Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforB7Client.X + this.DisplayOffset.X, this.FacilityforB7Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforB8DisplayPosition
         {
             get
             {
                 if (FB8 == true && FacilityforBButton == true)
                 {
                     return new Rectangle(this.FacilityforB8Client.X + this.DisplayOffset.X, this.FacilityforB8Client.Y + this.DisplayOffset.Y, this.FacilityforB8Client.Width, this.FacilityforB8Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforB8Client.X + this.DisplayOffset.X, this.FacilityforB8Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforB9DisplayPosition
         {
             get
             {
                 if (FB9 == true && FacilityforBButton == true)
                 {
                     return new Rectangle(this.FacilityforB9Client.X + this.DisplayOffset.X, this.FacilityforB9Client.Y + this.DisplayOffset.Y, this.FacilityforB9Client.Width, this.FacilityforB9Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforB9Client.X + this.DisplayOffset.X, this.FacilityforB9Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforB10DisplayPosition
         {
             get
             {
                 if (FB10 == true && FacilityforBButton == true)
                 {
                     return new Rectangle(this.FacilityforB10Client.X + this.DisplayOffset.X, this.FacilityforB10Client.Y + this.DisplayOffset.Y, this.FacilityforB10Client.Width, this.FacilityforB10Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforB10Client.X + this.DisplayOffset.X, this.FacilityforB10Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforB11DisplayPosition
         {
             get
             {
                 if (FB11 == true && FacilityforBButton == true)
                 {
                     return new Rectangle(this.FacilityforB11Client.X + this.DisplayOffset.X, this.FacilityforB11Client.Y + this.DisplayOffset.Y, this.FacilityforB11Client.Width, this.FacilityforB11Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforB11Client.X + this.DisplayOffset.X, this.FacilityforB11Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforB12DisplayPosition
         {
             get
             {
                 if (FB12 == true && FacilityforBButton == true)
                 {
                     return new Rectangle(this.FacilityforB12Client.X + this.DisplayOffset.X, this.FacilityforB12Client.Y + this.DisplayOffset.Y, this.FacilityforB12Client.Width, this.FacilityforB12Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforB12Client.X + this.DisplayOffset.X, this.FacilityforB12Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforB13DisplayPosition
         {
             get
             {
                 if (FB13 == true && FacilityforBButton == true)
                 {
                     return new Rectangle(this.FacilityforB13Client.X + this.DisplayOffset.X, this.FacilityforB13Client.Y + this.DisplayOffset.Y, this.FacilityforB13Client.Width, this.FacilityforB13Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforB13Client.X + this.DisplayOffset.X, this.FacilityforB13Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforB14DisplayPosition
         {
             get
             {
                 if (FB14 == true && FacilityforBButton == true)
                 {
                     return new Rectangle(this.FacilityforB14Client.X + this.DisplayOffset.X, this.FacilityforB14Client.Y + this.DisplayOffset.Y, this.FacilityforB14Client.Width, this.FacilityforB14Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforB14Client.X + this.DisplayOffset.X, this.FacilityforB14Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforB15DisplayPosition
         {
             get
             {
                 if (FB15 == true && FacilityforBButton == true)
                 {
                     return new Rectangle(this.FacilityforB15Client.X + this.DisplayOffset.X, this.FacilityforB15Client.Y + this.DisplayOffset.Y, this.FacilityforB15Client.Width, this.FacilityforB15Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforB15Client.X + this.DisplayOffset.X, this.FacilityforB15Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforB16DisplayPosition
         {
             get
             {
                 if (FB16 == true && FacilityforBButton == true)
                 {
                     return new Rectangle(this.FacilityforB16Client.X + this.DisplayOffset.X, this.FacilityforB16Client.Y + this.DisplayOffset.Y, this.FacilityforB16Client.Width, this.FacilityforB16Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforB16Client.X + this.DisplayOffset.X, this.FacilityforB16Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforB17DisplayPosition
         {
             get
             {
                 if (FB17 == true && FacilityforBButton == true)
                 {
                     return new Rectangle(this.FacilityforB17Client.X + this.DisplayOffset.X, this.FacilityforB17Client.Y + this.DisplayOffset.Y, this.FacilityforB17Client.Width, this.FacilityforB17Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforB17Client.X + this.DisplayOffset.X, this.FacilityforB17Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforB18DisplayPosition
         {
             get
             {
                 if (FB18 == true && FacilityforBButton == true)
                 {
                     return new Rectangle(this.FacilityforB18Client.X + this.DisplayOffset.X, this.FacilityforB18Client.Y + this.DisplayOffset.Y, this.FacilityforB18Client.Width, this.FacilityforB18Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforB18Client.X + this.DisplayOffset.X, this.FacilityforB18Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforB19DisplayPosition
         {
             get
             {
                 if (FB19 == true && FacilityforBButton == true)
                 {
                     return new Rectangle(this.FacilityforB19Client.X + this.DisplayOffset.X, this.FacilityforB19Client.Y + this.DisplayOffset.Y, this.FacilityforB19Client.Width, this.FacilityforB19Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforB19Client.X + this.DisplayOffset.X, this.FacilityforB19Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforB20DisplayPosition
         {
             get
             {
                 if (FB20 == true && FacilityforBButton == true)
                 {
                     return new Rectangle(this.FacilityforB20Client.X + this.DisplayOffset.X, this.FacilityforB20Client.Y + this.DisplayOffset.Y, this.FacilityforB20Client.Width, this.FacilityforB20Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforB20Client.X + this.DisplayOffset.X, this.FacilityforB20Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforB21DisplayPosition
         {
             get
             {
                 if (FB21 == true && FacilityforBButton == true)
                 {
                     return new Rectangle(this.FacilityforB21Client.X + this.DisplayOffset.X, this.FacilityforB21Client.Y + this.DisplayOffset.Y, this.FacilityforB21Client.Width, this.FacilityforB21Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforB21Client.X + this.DisplayOffset.X, this.FacilityforB21Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforB22DisplayPosition
         {
             get
             {
                 if (FB22 == true && FacilityforBButton == true)
                 {
                     return new Rectangle(this.FacilityforB22Client.X + this.DisplayOffset.X, this.FacilityforB22Client.Y + this.DisplayOffset.Y, this.FacilityforB22Client.Width, this.FacilityforB22Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforB22Client.X + this.DisplayOffset.X, this.FacilityforB22Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforB23DisplayPosition
         {
             get
             {
                 if (FB23 == true && FacilityforBButton == true)
                 {
                     return new Rectangle(this.FacilityforB23Client.X + this.DisplayOffset.X, this.FacilityforB23Client.Y + this.DisplayOffset.Y, this.FacilityforB23Client.Width, this.FacilityforB23Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforB23Client.X + this.DisplayOffset.X, this.FacilityforB23Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforB24DisplayPosition
         {
             get
             {
                 if (FB24 == true && FacilityforBButton == true)
                 {
                     return new Rectangle(this.FacilityforB24Client.X + this.DisplayOffset.X, this.FacilityforB24Client.Y + this.DisplayOffset.Y, this.FacilityforB24Client.Width, this.FacilityforB24Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforB24Client.X + this.DisplayOffset.X, this.FacilityforB24Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforB25DisplayPosition
         {
             get
             {
                 if (FB25 == true && FacilityforBButton == true)
                 {
                     return new Rectangle(this.FacilityforB25Client.X + this.DisplayOffset.X, this.FacilityforB25Client.Y + this.DisplayOffset.Y, this.FacilityforB25Client.Width, this.FacilityforB25Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforB25Client.X + this.DisplayOffset.X, this.FacilityforB25Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforB26DisplayPosition
         {
             get
             {
                 if (FB26 == true && FacilityforBButton == true)
                 {
                     return new Rectangle(this.FacilityforB26Client.X + this.DisplayOffset.X, this.FacilityforB26Client.Y + this.DisplayOffset.Y, this.FacilityforB26Client.Width, this.FacilityforB26Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforB26Client.X + this.DisplayOffset.X, this.FacilityforB26Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforB27DisplayPosition
         {
             get
             {
                 if (FB27 == true && FacilityforBButton == true)
                 {
                     return new Rectangle(this.FacilityforB27Client.X + this.DisplayOffset.X, this.FacilityforB27Client.Y + this.DisplayOffset.Y, this.FacilityforB27Client.Width, this.FacilityforB27Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforB27Client.X + this.DisplayOffset.X, this.FacilityforB27Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforB28DisplayPosition
         {
             get
             {
                 if (FB28 == true && FacilityforBButton == true)
                 {
                     return new Rectangle(this.FacilityforB28Client.X + this.DisplayOffset.X, this.FacilityforB28Client.Y + this.DisplayOffset.Y, this.FacilityforB28Client.Width, this.FacilityforB28Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforB28Client.X + this.DisplayOffset.X, this.FacilityforB28Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         //↓C区设施
         private Rectangle FacilityforC1DisplayPosition
         {
             get
             {
                 if (FC1 == true && FacilityforCButton == true)
                 {
                     return new Rectangle(this.FacilityforC1Client.X + this.DisplayOffset.X, this.FacilityforC1Client.Y + this.DisplayOffset.Y, this.FacilityforC1Client.Width, this.FacilityforC1Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforC1Client.X + this.DisplayOffset.X, this.FacilityforC1Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforC2DisplayPosition
         {
             get
             {
                 if (FC2 == true && FacilityforCButton == true)
                 {
                     return new Rectangle(this.FacilityforC2Client.X + this.DisplayOffset.X, this.FacilityforC2Client.Y + this.DisplayOffset.Y, this.FacilityforC2Client.Width, this.FacilityforC2Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforC2Client.X + this.DisplayOffset.X, this.FacilityforC2Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforC3DisplayPosition
         {
             get
             {
                 if (FC3 == true && FacilityforCButton == true)
                 {
                     return new Rectangle(this.FacilityforC3Client.X + this.DisplayOffset.X, this.FacilityforC3Client.Y + this.DisplayOffset.Y, this.FacilityforC3Client.Width, this.FacilityforC3Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforC3Client.X + this.DisplayOffset.X, this.FacilityforC3Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforC4DisplayPosition
         {
             get
             {
                 if (FC4 == true && FacilityforCButton == true)
                 {
                     return new Rectangle(this.FacilityforC4Client.X + this.DisplayOffset.X, this.FacilityforC4Client.Y + this.DisplayOffset.Y, this.FacilityforC4Client.Width, this.FacilityforC4Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforC4Client.X + this.DisplayOffset.X, this.FacilityforC4Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforC5DisplayPosition
         {
             get
             {
                 if (FC5 == true && FacilityforCButton == true)
                 {
                     return new Rectangle(this.FacilityforC5Client.X + this.DisplayOffset.X, this.FacilityforC5Client.Y + this.DisplayOffset.Y, this.FacilityforC5Client.Width, this.FacilityforC5Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforC5Client.X + this.DisplayOffset.X, this.FacilityforC5Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforC6DisplayPosition
         {
             get
             {
                 if (FC6 == true && FacilityforCButton == true)
                 {
                     return new Rectangle(this.FacilityforC6Client.X + this.DisplayOffset.X, this.FacilityforC6Client.Y + this.DisplayOffset.Y, this.FacilityforC6Client.Width, this.FacilityforC6Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforC6Client.X + this.DisplayOffset.X, this.FacilityforC6Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforC7DisplayPosition
         {
             get
             {
                 if (FC7 == true && FacilityforCButton == true)
                 {
                     return new Rectangle(this.FacilityforC7Client.X + this.DisplayOffset.X, this.FacilityforC7Client.Y + this.DisplayOffset.Y, this.FacilityforC7Client.Width, this.FacilityforC7Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforC7Client.X + this.DisplayOffset.X, this.FacilityforC7Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforC8DisplayPosition
         {
             get
             {
                 if (FC8 == true && FacilityforCButton == true)
                 {
                     return new Rectangle(this.FacilityforC8Client.X + this.DisplayOffset.X, this.FacilityforC8Client.Y + this.DisplayOffset.Y, this.FacilityforC8Client.Width, this.FacilityforC8Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforC8Client.X + this.DisplayOffset.X, this.FacilityforC8Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforC9DisplayPosition
         {
             get
             {
                 if (FC9 == true && FacilityforCButton == true)
                 {
                     return new Rectangle(this.FacilityforC9Client.X + this.DisplayOffset.X, this.FacilityforC9Client.Y + this.DisplayOffset.Y, this.FacilityforC9Client.Width, this.FacilityforC9Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforC9Client.X + this.DisplayOffset.X, this.FacilityforC9Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforC10DisplayPosition
         {
             get
             {
                 if (FC10 == true && FacilityforCButton == true)
                 {
                     return new Rectangle(this.FacilityforC10Client.X + this.DisplayOffset.X, this.FacilityforC10Client.Y + this.DisplayOffset.Y, this.FacilityforC10Client.Width, this.FacilityforC10Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforC10Client.X + this.DisplayOffset.X, this.FacilityforC10Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforC11DisplayPosition
         {
             get
             {
                 if (FC11 == true && FacilityforCButton == true)
                 {
                     return new Rectangle(this.FacilityforC11Client.X + this.DisplayOffset.X, this.FacilityforC11Client.Y + this.DisplayOffset.Y, this.FacilityforC11Client.Width, this.FacilityforC11Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforC11Client.X + this.DisplayOffset.X, this.FacilityforC11Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforC12DisplayPosition
         {
             get
             {
                 if (FC12 == true && FacilityforCButton == true)
                 {
                     return new Rectangle(this.FacilityforC12Client.X + this.DisplayOffset.X, this.FacilityforC12Client.Y + this.DisplayOffset.Y, this.FacilityforC12Client.Width, this.FacilityforC12Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforC12Client.X + this.DisplayOffset.X, this.FacilityforC12Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforC13DisplayPosition
         {
             get
             {
                 if (FC13 == true && FacilityforCButton == true)
                 {
                     return new Rectangle(this.FacilityforC13Client.X + this.DisplayOffset.X, this.FacilityforC13Client.Y + this.DisplayOffset.Y, this.FacilityforC13Client.Width, this.FacilityforC13Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforC13Client.X + this.DisplayOffset.X, this.FacilityforC13Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforC14DisplayPosition
         {
             get
             {
                 if (FC14 == true && FacilityforCButton == true)
                 {
                     return new Rectangle(this.FacilityforC14Client.X + this.DisplayOffset.X, this.FacilityforC14Client.Y + this.DisplayOffset.Y, this.FacilityforC14Client.Width, this.FacilityforC14Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforC14Client.X + this.DisplayOffset.X, this.FacilityforC14Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforC15DisplayPosition
         {
             get
             {
                 if (FC15 == true && FacilityforCButton == true)
                 {
                     return new Rectangle(this.FacilityforC15Client.X + this.DisplayOffset.X, this.FacilityforC15Client.Y + this.DisplayOffset.Y, this.FacilityforC15Client.Width, this.FacilityforC15Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforC15Client.X + this.DisplayOffset.X, this.FacilityforC15Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforC16DisplayPosition
         {
             get
             {
                 if (FC16 == true && FacilityforCButton == true)
                 {
                     return new Rectangle(this.FacilityforC16Client.X + this.DisplayOffset.X, this.FacilityforC16Client.Y + this.DisplayOffset.Y, this.FacilityforC16Client.Width, this.FacilityforC16Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforC16Client.X + this.DisplayOffset.X, this.FacilityforC16Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforC17DisplayPosition
         {
             get
             {
                 if (FC17 == true && FacilityforCButton == true)
                 {
                     return new Rectangle(this.FacilityforC17Client.X + this.DisplayOffset.X, this.FacilityforC17Client.Y + this.DisplayOffset.Y, this.FacilityforC17Client.Width, this.FacilityforC17Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforC17Client.X + this.DisplayOffset.X, this.FacilityforC17Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforC18DisplayPosition
         {
             get
             {
                 if (FC18 == true && FacilityforCButton == true)
                 {
                     return new Rectangle(this.FacilityforC18Client.X + this.DisplayOffset.X, this.FacilityforC18Client.Y + this.DisplayOffset.Y, this.FacilityforC18Client.Width, this.FacilityforC18Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforC18Client.X + this.DisplayOffset.X, this.FacilityforC18Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforC19DisplayPosition
         {
             get
             {
                 if (FC19 == true && FacilityforCButton == true)
                 {
                     return new Rectangle(this.FacilityforC19Client.X + this.DisplayOffset.X, this.FacilityforC19Client.Y + this.DisplayOffset.Y, this.FacilityforC19Client.Width, this.FacilityforC19Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforC19Client.X + this.DisplayOffset.X, this.FacilityforC19Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforC20DisplayPosition
         {
             get
             {
                 if (FC20 == true && FacilityforCButton == true)
                 {
                     return new Rectangle(this.FacilityforC20Client.X + this.DisplayOffset.X, this.FacilityforC20Client.Y + this.DisplayOffset.Y, this.FacilityforC20Client.Width, this.FacilityforC20Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforC20Client.X + this.DisplayOffset.X, this.FacilityforC20Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforC21DisplayPosition
         {
             get
             {
                 if (FC21 == true && FacilityforCButton == true)
                 {
                     return new Rectangle(this.FacilityforC21Client.X + this.DisplayOffset.X, this.FacilityforC21Client.Y + this.DisplayOffset.Y, this.FacilityforC21Client.Width, this.FacilityforC21Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforC21Client.X + this.DisplayOffset.X, this.FacilityforC21Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforC22DisplayPosition
         {
             get
             {
                 if (FC22 == true && FacilityforCButton == true)
                 {
                     return new Rectangle(this.FacilityforC22Client.X + this.DisplayOffset.X, this.FacilityforC22Client.Y + this.DisplayOffset.Y, this.FacilityforC22Client.Width, this.FacilityforC22Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforC22Client.X + this.DisplayOffset.X, this.FacilityforC22Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforC23DisplayPosition
         {
             get
             {
                 if (FC23 == true && FacilityforCButton == true)
                 {
                     return new Rectangle(this.FacilityforC23Client.X + this.DisplayOffset.X, this.FacilityforC23Client.Y + this.DisplayOffset.Y, this.FacilityforC23Client.Width, this.FacilityforC23Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforC23Client.X + this.DisplayOffset.X, this.FacilityforC23Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforC24DisplayPosition
         {
             get
             {
                 if (FC24 == true && FacilityforCButton == true)
                 {
                     return new Rectangle(this.FacilityforC24Client.X + this.DisplayOffset.X, this.FacilityforC24Client.Y + this.DisplayOffset.Y, this.FacilityforC24Client.Width, this.FacilityforC24Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforC24Client.X + this.DisplayOffset.X, this.FacilityforC24Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforC25DisplayPosition
         {
             get
             {
                 if (FC25 == true && FacilityforCButton == true)
                 {
                     return new Rectangle(this.FacilityforC25Client.X + this.DisplayOffset.X, this.FacilityforC25Client.Y + this.DisplayOffset.Y, this.FacilityforC25Client.Width, this.FacilityforC25Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforC25Client.X + this.DisplayOffset.X, this.FacilityforC25Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforC26DisplayPosition
         {
             get
             {
                 if (FC26 == true && FacilityforCButton == true)
                 {
                     return new Rectangle(this.FacilityforC26Client.X + this.DisplayOffset.X, this.FacilityforC26Client.Y + this.DisplayOffset.Y, this.FacilityforC26Client.Width, this.FacilityforC26Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforC26Client.X + this.DisplayOffset.X, this.FacilityforC26Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforC27DisplayPosition
         {
             get
             {
                 if (FC27 == true && FacilityforCButton == true)
                 {
                     return new Rectangle(this.FacilityforC27Client.X + this.DisplayOffset.X, this.FacilityforC27Client.Y + this.DisplayOffset.Y, this.FacilityforC27Client.Width, this.FacilityforC27Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforC27Client.X + this.DisplayOffset.X, this.FacilityforC27Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforC28DisplayPosition
         {
             get
             {
                 if (FC28 == true && FacilityforCButton == true)
                 {
                     return new Rectangle(this.FacilityforC28Client.X + this.DisplayOffset.X, this.FacilityforC28Client.Y + this.DisplayOffset.Y, this.FacilityforC28Client.Width, this.FacilityforC28Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforC28Client.X + this.DisplayOffset.X, this.FacilityforC28Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         //↓D区设施
         private Rectangle FacilityforD1DisplayPosition
         {
             get
             {
                 if (FD1 == true && FacilityforDButton == true)
                 {
                     return new Rectangle(this.FacilityforD1Client.X + this.DisplayOffset.X, this.FacilityforD1Client.Y + this.DisplayOffset.Y, this.FacilityforD1Client.Width, this.FacilityforD1Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforD1Client.X + this.DisplayOffset.X, this.FacilityforD1Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforD2DisplayPosition
         {
             get
             {
                 if (FD2 == true && FacilityforDButton == true)
                 {
                     return new Rectangle(this.FacilityforD2Client.X + this.DisplayOffset.X, this.FacilityforD2Client.Y + this.DisplayOffset.Y, this.FacilityforD2Client.Width, this.FacilityforD2Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforD2Client.X + this.DisplayOffset.X, this.FacilityforD2Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforD3DisplayPosition
         {
             get
             {
                 if (FD3 == true && FacilityforDButton == true)
                 {
                     return new Rectangle(this.FacilityforD3Client.X + this.DisplayOffset.X, this.FacilityforD3Client.Y + this.DisplayOffset.Y, this.FacilityforD3Client.Width, this.FacilityforD3Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforD3Client.X + this.DisplayOffset.X, this.FacilityforD3Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforD4DisplayPosition
         {
             get
             {
                 if (FD4 == true && FacilityforDButton == true)
                 {
                     return new Rectangle(this.FacilityforD4Client.X + this.DisplayOffset.X, this.FacilityforD4Client.Y + this.DisplayOffset.Y, this.FacilityforD4Client.Width, this.FacilityforD4Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforD4Client.X + this.DisplayOffset.X, this.FacilityforD4Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforD5DisplayPosition
         {
             get
             {
                 if (FD5 == true && FacilityforDButton == true)
                 {
                     return new Rectangle(this.FacilityforD5Client.X + this.DisplayOffset.X, this.FacilityforD5Client.Y + this.DisplayOffset.Y, this.FacilityforD5Client.Width, this.FacilityforD5Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforD5Client.X + this.DisplayOffset.X, this.FacilityforD5Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforD6DisplayPosition
         {
             get
             {
                 if (FD6 == true && FacilityforDButton == true)
                 {
                     return new Rectangle(this.FacilityforD6Client.X + this.DisplayOffset.X, this.FacilityforD6Client.Y + this.DisplayOffset.Y, this.FacilityforD6Client.Width, this.FacilityforD6Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforD6Client.X + this.DisplayOffset.X, this.FacilityforD6Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforD7DisplayPosition
         {
             get
             {
                 if (FD7 == true && FacilityforDButton == true)
                 {
                     return new Rectangle(this.FacilityforD7Client.X + this.DisplayOffset.X, this.FacilityforD7Client.Y + this.DisplayOffset.Y, this.FacilityforD7Client.Width, this.FacilityforD7Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforD7Client.X + this.DisplayOffset.X, this.FacilityforD7Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforD8DisplayPosition
         {
             get
             {
                 if (FD8 == true && FacilityforDButton == true)
                 {
                     return new Rectangle(this.FacilityforD8Client.X + this.DisplayOffset.X, this.FacilityforD8Client.Y + this.DisplayOffset.Y, this.FacilityforD8Client.Width, this.FacilityforD8Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforD8Client.X + this.DisplayOffset.X, this.FacilityforD8Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforD9DisplayPosition
         {
             get
             {
                 if (FD9 == true && FacilityforDButton == true)
                 {
                     return new Rectangle(this.FacilityforD9Client.X + this.DisplayOffset.X, this.FacilityforD9Client.Y + this.DisplayOffset.Y, this.FacilityforD9Client.Width, this.FacilityforD9Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforD9Client.X + this.DisplayOffset.X, this.FacilityforD9Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforD10DisplayPosition
         {
             get
             {
                 if (FD10 == true && FacilityforDButton == true)
                 {
                     return new Rectangle(this.FacilityforD10Client.X + this.DisplayOffset.X, this.FacilityforD10Client.Y + this.DisplayOffset.Y, this.FacilityforD10Client.Width, this.FacilityforD10Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforD10Client.X + this.DisplayOffset.X, this.FacilityforD10Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforD11DisplayPosition
         {
             get
             {
                 if (FD11 == true && FacilityforDButton == true)
                 {
                     return new Rectangle(this.FacilityforD11Client.X + this.DisplayOffset.X, this.FacilityforD11Client.Y + this.DisplayOffset.Y, this.FacilityforD11Client.Width, this.FacilityforD11Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforD11Client.X + this.DisplayOffset.X, this.FacilityforD11Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforD12DisplayPosition
         {
             get
             {
                 if (FD12 == true && FacilityforDButton == true)
                 {
                     return new Rectangle(this.FacilityforD12Client.X + this.DisplayOffset.X, this.FacilityforD12Client.Y + this.DisplayOffset.Y, this.FacilityforD12Client.Width, this.FacilityforD12Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforD12Client.X + this.DisplayOffset.X, this.FacilityforD12Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforD13DisplayPosition
         {
             get
             {
                 if (FD13 == true && FacilityforDButton == true)
                 {
                     return new Rectangle(this.FacilityforD13Client.X + this.DisplayOffset.X, this.FacilityforD13Client.Y + this.DisplayOffset.Y, this.FacilityforD13Client.Width, this.FacilityforD13Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforD13Client.X + this.DisplayOffset.X, this.FacilityforD13Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforD14DisplayPosition
         {
             get
             {
                 if (FD14 == true && FacilityforDButton == true)
                 {
                     return new Rectangle(this.FacilityforD14Client.X + this.DisplayOffset.X, this.FacilityforD14Client.Y + this.DisplayOffset.Y, this.FacilityforD14Client.Width, this.FacilityforD14Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforD14Client.X + this.DisplayOffset.X, this.FacilityforD14Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforD15DisplayPosition
         {
             get
             {
                 if (FD15 == true && FacilityforDButton == true)
                 {
                     return new Rectangle(this.FacilityforD15Client.X + this.DisplayOffset.X, this.FacilityforD15Client.Y + this.DisplayOffset.Y, this.FacilityforD15Client.Width, this.FacilityforD15Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforD15Client.X + this.DisplayOffset.X, this.FacilityforD15Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforD16DisplayPosition
         {
             get
             {
                 if (FD16 == true && FacilityforDButton == true)
                 {
                     return new Rectangle(this.FacilityforD16Client.X + this.DisplayOffset.X, this.FacilityforD16Client.Y + this.DisplayOffset.Y, this.FacilityforD16Client.Width, this.FacilityforD16Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforD16Client.X + this.DisplayOffset.X, this.FacilityforD16Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforD17DisplayPosition
         {
             get
             {
                 if (FD17 == true && FacilityforDButton == true)
                 {
                     return new Rectangle(this.FacilityforD17Client.X + this.DisplayOffset.X, this.FacilityforD17Client.Y + this.DisplayOffset.Y, this.FacilityforD17Client.Width, this.FacilityforD17Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforD17Client.X + this.DisplayOffset.X, this.FacilityforD17Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforD18DisplayPosition
         {
             get
             {
                 if (FD18 == true && FacilityforDButton == true)
                 {
                     return new Rectangle(this.FacilityforD18Client.X + this.DisplayOffset.X, this.FacilityforD18Client.Y + this.DisplayOffset.Y, this.FacilityforD18Client.Width, this.FacilityforD18Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforD18Client.X + this.DisplayOffset.X, this.FacilityforD18Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforD19DisplayPosition
         {
             get
             {
                 if (FD19 == true && FacilityforDButton == true)
                 {
                     return new Rectangle(this.FacilityforD19Client.X + this.DisplayOffset.X, this.FacilityforD19Client.Y + this.DisplayOffset.Y, this.FacilityforD19Client.Width, this.FacilityforD19Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforD19Client.X + this.DisplayOffset.X, this.FacilityforD19Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforD20DisplayPosition
         {
             get
             {
                 if (FD20 == true && FacilityforDButton == true)
                 {
                     return new Rectangle(this.FacilityforD20Client.X + this.DisplayOffset.X, this.FacilityforD20Client.Y + this.DisplayOffset.Y, this.FacilityforD20Client.Width, this.FacilityforD20Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforD20Client.X + this.DisplayOffset.X, this.FacilityforD20Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforD21DisplayPosition
         {
             get
             {
                 if (FD21 == true && FacilityforDButton == true)
                 {
                     return new Rectangle(this.FacilityforD21Client.X + this.DisplayOffset.X, this.FacilityforD21Client.Y + this.DisplayOffset.Y, this.FacilityforD21Client.Width, this.FacilityforD21Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforD21Client.X + this.DisplayOffset.X, this.FacilityforD21Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforD22DisplayPosition
         {
             get
             {
                 if (FD22 == true && FacilityforDButton == true)
                 {
                     return new Rectangle(this.FacilityforD22Client.X + this.DisplayOffset.X, this.FacilityforD22Client.Y + this.DisplayOffset.Y, this.FacilityforD22Client.Width, this.FacilityforD22Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforD22Client.X + this.DisplayOffset.X, this.FacilityforD22Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforD23DisplayPosition
         {
             get
             {
                 if (FD23 == true && FacilityforDButton == true)
                 {
                     return new Rectangle(this.FacilityforD23Client.X + this.DisplayOffset.X, this.FacilityforD23Client.Y + this.DisplayOffset.Y, this.FacilityforD23Client.Width, this.FacilityforD23Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforD23Client.X + this.DisplayOffset.X, this.FacilityforD23Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforD24DisplayPosition
         {
             get
             {
                 if (FD24 == true && FacilityforDButton == true)
                 {
                     return new Rectangle(this.FacilityforD24Client.X + this.DisplayOffset.X, this.FacilityforD24Client.Y + this.DisplayOffset.Y, this.FacilityforD24Client.Width, this.FacilityforD24Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforD24Client.X + this.DisplayOffset.X, this.FacilityforD24Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforD25DisplayPosition
         {
             get
             {
                 if (FD25 == true && FacilityforDButton == true)
                 {
                     return new Rectangle(this.FacilityforD25Client.X + this.DisplayOffset.X, this.FacilityforD25Client.Y + this.DisplayOffset.Y, this.FacilityforD25Client.Width, this.FacilityforD25Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforD25Client.X + this.DisplayOffset.X, this.FacilityforD25Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforD26DisplayPosition
         {
             get
             {
                 if (FD26 == true && FacilityforDButton == true)
                 {
                     return new Rectangle(this.FacilityforD26Client.X + this.DisplayOffset.X, this.FacilityforD26Client.Y + this.DisplayOffset.Y, this.FacilityforD26Client.Width, this.FacilityforD26Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforD26Client.X + this.DisplayOffset.X, this.FacilityforD26Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforD27DisplayPosition
         {
             get
             {
                 if (FD27 == true && FacilityforDButton == true)
                 {
                     return new Rectangle(this.FacilityforD27Client.X + this.DisplayOffset.X, this.FacilityforD27Client.Y + this.DisplayOffset.Y, this.FacilityforD27Client.Width, this.FacilityforD27Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforD27Client.X + this.DisplayOffset.X, this.FacilityforD27Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforD28DisplayPosition
         {
             get
             {
                 if (FD28 == true && FacilityforDButton == true)
                 {
                     return new Rectangle(this.FacilityforD28Client.X + this.DisplayOffset.X, this.FacilityforD28Client.Y + this.DisplayOffset.Y, this.FacilityforD28Client.Width, this.FacilityforD28Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforD28Client.X + this.DisplayOffset.X, this.FacilityforD28Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         //↓E区设施
         private Rectangle FacilityforE1DisplayPosition
         {
             get
             {
                 if (FE1 == true && FacilityforEButton == true)
                 {
                     return new Rectangle(this.FacilityforE1Client.X + this.DisplayOffset.X, this.FacilityforE1Client.Y + this.DisplayOffset.Y, this.FacilityforE1Client.Width, this.FacilityforE1Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforE1Client.X + this.DisplayOffset.X, this.FacilityforE1Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforE2DisplayPosition
         {
             get
             {
                 if (FE2 == true && FacilityforEButton == true)
                 {
                     return new Rectangle(this.FacilityforE2Client.X + this.DisplayOffset.X, this.FacilityforE2Client.Y + this.DisplayOffset.Y, this.FacilityforE2Client.Width, this.FacilityforE2Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforE2Client.X + this.DisplayOffset.X, this.FacilityforE2Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforE3DisplayPosition
         {
             get
             {
                 if (FE3 == true && FacilityforEButton == true)
                 {
                     return new Rectangle(this.FacilityforE3Client.X + this.DisplayOffset.X, this.FacilityforE3Client.Y + this.DisplayOffset.Y, this.FacilityforE3Client.Width, this.FacilityforE3Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforE3Client.X + this.DisplayOffset.X, this.FacilityforE3Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforE4DisplayPosition
         {
             get
             {
                 if (FE4 == true && FacilityforEButton == true)
                 {
                     return new Rectangle(this.FacilityforE4Client.X + this.DisplayOffset.X, this.FacilityforE4Client.Y + this.DisplayOffset.Y, this.FacilityforE4Client.Width, this.FacilityforE4Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforE4Client.X + this.DisplayOffset.X, this.FacilityforE4Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforE5DisplayPosition
         {
             get
             {
                 if (FE5 == true && FacilityforEButton == true)
                 {
                     return new Rectangle(this.FacilityforE5Client.X + this.DisplayOffset.X, this.FacilityforE5Client.Y + this.DisplayOffset.Y, this.FacilityforE5Client.Width, this.FacilityforE5Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforE5Client.X + this.DisplayOffset.X, this.FacilityforE5Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforE6DisplayPosition
         {
             get
             {
                 if (FE6 == true && FacilityforEButton == true)
                 {
                     return new Rectangle(this.FacilityforE6Client.X + this.DisplayOffset.X, this.FacilityforE6Client.Y + this.DisplayOffset.Y, this.FacilityforE6Client.Width, this.FacilityforE6Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforE6Client.X + this.DisplayOffset.X, this.FacilityforE6Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforE7DisplayPosition
         {
             get
             {
                 if (FE7 == true && FacilityforEButton == true)
                 {
                     return new Rectangle(this.FacilityforE7Client.X + this.DisplayOffset.X, this.FacilityforE7Client.Y + this.DisplayOffset.Y, this.FacilityforE7Client.Width, this.FacilityforE7Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforE7Client.X + this.DisplayOffset.X, this.FacilityforE7Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforE8DisplayPosition
         {
             get
             {
                 if (FE8 == true && FacilityforEButton == true)
                 {
                     return new Rectangle(this.FacilityforE8Client.X + this.DisplayOffset.X, this.FacilityforE8Client.Y + this.DisplayOffset.Y, this.FacilityforE8Client.Width, this.FacilityforE8Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforE8Client.X + this.DisplayOffset.X, this.FacilityforE8Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforE9DisplayPosition
         {
             get
             {
                 if (FE9 == true && FacilityforEButton == true)
                 {
                     return new Rectangle(this.FacilityforE9Client.X + this.DisplayOffset.X, this.FacilityforE9Client.Y + this.DisplayOffset.Y, this.FacilityforE9Client.Width, this.FacilityforE9Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforE9Client.X + this.DisplayOffset.X, this.FacilityforE9Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforE10DisplayPosition
         {
             get
             {
                 if (FE10 == true && FacilityforEButton == true)
                 {
                     return new Rectangle(this.FacilityforE10Client.X + this.DisplayOffset.X, this.FacilityforE10Client.Y + this.DisplayOffset.Y, this.FacilityforE10Client.Width, this.FacilityforE10Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforE10Client.X + this.DisplayOffset.X, this.FacilityforE10Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforE11DisplayPosition
         {
             get
             {
                 if (FE11 == true && FacilityforEButton == true)
                 {
                     return new Rectangle(this.FacilityforE11Client.X + this.DisplayOffset.X, this.FacilityforE11Client.Y + this.DisplayOffset.Y, this.FacilityforE11Client.Width, this.FacilityforE11Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforE11Client.X + this.DisplayOffset.X, this.FacilityforE11Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforE12DisplayPosition
         {
             get
             {
                 if (FE12 == true && FacilityforEButton == true)
                 {
                     return new Rectangle(this.FacilityforE12Client.X + this.DisplayOffset.X, this.FacilityforE12Client.Y + this.DisplayOffset.Y, this.FacilityforE12Client.Width, this.FacilityforE12Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforE12Client.X + this.DisplayOffset.X, this.FacilityforE12Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforE13DisplayPosition
         {
             get
             {
                 if (FE13 == true && FacilityforEButton == true)
                 {
                     return new Rectangle(this.FacilityforE13Client.X + this.DisplayOffset.X, this.FacilityforE13Client.Y + this.DisplayOffset.Y, this.FacilityforE13Client.Width, this.FacilityforE13Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforE13Client.X + this.DisplayOffset.X, this.FacilityforE13Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforE14DisplayPosition
         {
             get
             {
                 if (FE14 == true && FacilityforEButton == true)
                 {
                     return new Rectangle(this.FacilityforE14Client.X + this.DisplayOffset.X, this.FacilityforE14Client.Y + this.DisplayOffset.Y, this.FacilityforE14Client.Width, this.FacilityforE14Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforE14Client.X + this.DisplayOffset.X, this.FacilityforE14Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforE15DisplayPosition
         {
             get
             {
                 if (FE15 == true && FacilityforEButton == true)
                 {
                     return new Rectangle(this.FacilityforE15Client.X + this.DisplayOffset.X, this.FacilityforE15Client.Y + this.DisplayOffset.Y, this.FacilityforE15Client.Width, this.FacilityforE15Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforE15Client.X + this.DisplayOffset.X, this.FacilityforE15Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforE16DisplayPosition
         {
             get
             {
                 if (FE16 == true && FacilityforEButton == true)
                 {
                     return new Rectangle(this.FacilityforE16Client.X + this.DisplayOffset.X, this.FacilityforE16Client.Y + this.DisplayOffset.Y, this.FacilityforE16Client.Width, this.FacilityforE16Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforE16Client.X + this.DisplayOffset.X, this.FacilityforE16Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforE17DisplayPosition
         {
             get
             {
                 if (FE17 == true && FacilityforEButton == true)
                 {
                     return new Rectangle(this.FacilityforE17Client.X + this.DisplayOffset.X, this.FacilityforE17Client.Y + this.DisplayOffset.Y, this.FacilityforE17Client.Width, this.FacilityforE17Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforE17Client.X + this.DisplayOffset.X, this.FacilityforE17Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforE18DisplayPosition
         {
             get
             {
                 if (FE18 == true && FacilityforEButton == true)
                 {
                     return new Rectangle(this.FacilityforE18Client.X + this.DisplayOffset.X, this.FacilityforE18Client.Y + this.DisplayOffset.Y, this.FacilityforE18Client.Width, this.FacilityforE18Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforE18Client.X + this.DisplayOffset.X, this.FacilityforE18Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforE19DisplayPosition
         {
             get
             {
                 if (FE19 == true && FacilityforEButton == true)
                 {
                     return new Rectangle(this.FacilityforE19Client.X + this.DisplayOffset.X, this.FacilityforE19Client.Y + this.DisplayOffset.Y, this.FacilityforE19Client.Width, this.FacilityforE19Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforE19Client.X + this.DisplayOffset.X, this.FacilityforE19Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforE20DisplayPosition
         {
             get
             {
                 if (FE20 == true && FacilityforEButton == true)
                 {
                     return new Rectangle(this.FacilityforE20Client.X + this.DisplayOffset.X, this.FacilityforE20Client.Y + this.DisplayOffset.Y, this.FacilityforE20Client.Width, this.FacilityforE20Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforE20Client.X + this.DisplayOffset.X, this.FacilityforE20Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforE21DisplayPosition
         {
             get
             {
                 if (FE21 == true && FacilityforEButton == true)
                 {
                     return new Rectangle(this.FacilityforE21Client.X + this.DisplayOffset.X, this.FacilityforE21Client.Y + this.DisplayOffset.Y, this.FacilityforE21Client.Width, this.FacilityforE21Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforE21Client.X + this.DisplayOffset.X, this.FacilityforE21Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforE22DisplayPosition
         {
             get
             {
                 if (FE22 == true && FacilityforEButton == true)
                 {
                     return new Rectangle(this.FacilityforE22Client.X + this.DisplayOffset.X, this.FacilityforE22Client.Y + this.DisplayOffset.Y, this.FacilityforE22Client.Width, this.FacilityforE22Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforE22Client.X + this.DisplayOffset.X, this.FacilityforE22Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforE23DisplayPosition
         {
             get
             {
                 if (FE23 == true && FacilityforEButton == true)
                 {
                     return new Rectangle(this.FacilityforE23Client.X + this.DisplayOffset.X, this.FacilityforE23Client.Y + this.DisplayOffset.Y, this.FacilityforE23Client.Width, this.FacilityforE23Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforE23Client.X + this.DisplayOffset.X, this.FacilityforE23Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforE24DisplayPosition
         {
             get
             {
                 if (FE24 == true && FacilityforEButton == true)
                 {
                     return new Rectangle(this.FacilityforE24Client.X + this.DisplayOffset.X, this.FacilityforE24Client.Y + this.DisplayOffset.Y, this.FacilityforE24Client.Width, this.FacilityforE24Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforE24Client.X + this.DisplayOffset.X, this.FacilityforE24Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforE25DisplayPosition
         {
             get
             {
                 if (FE25 == true && FacilityforEButton == true)
                 {
                     return new Rectangle(this.FacilityforE25Client.X + this.DisplayOffset.X, this.FacilityforE25Client.Y + this.DisplayOffset.Y, this.FacilityforE25Client.Width, this.FacilityforE25Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforE25Client.X + this.DisplayOffset.X, this.FacilityforE25Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforE26DisplayPosition
         {
             get
             {
                 if (FE26 == true && FacilityforEButton == true)
                 {
                     return new Rectangle(this.FacilityforE26Client.X + this.DisplayOffset.X, this.FacilityforE26Client.Y + this.DisplayOffset.Y, this.FacilityforE26Client.Width, this.FacilityforE26Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforE26Client.X + this.DisplayOffset.X, this.FacilityforE26Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforE27DisplayPosition
         {
             get
             {
                 if (FE27 == true && FacilityforEButton == true)
                 {
                     return new Rectangle(this.FacilityforE27Client.X + this.DisplayOffset.X, this.FacilityforE27Client.Y + this.DisplayOffset.Y, this.FacilityforE27Client.Width, this.FacilityforE27Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforE27Client.X + this.DisplayOffset.X, this.FacilityforE27Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
         private Rectangle FacilityforE28DisplayPosition
         {
             get
             {
                 if (FE28 == true && FacilityforEButton == true)
                 {
                     return new Rectangle(this.FacilityforE28Client.X + this.DisplayOffset.X, this.FacilityforE28Client.Y + this.DisplayOffset.Y, this.FacilityforE28Client.Width, this.FacilityforE28Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityforE28Client.X + this.DisplayOffset.X, this.FacilityforE28Client.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }

         //////////↓在设施图片定义
         private Rectangle FacilityforIngDisplayPosition
         {
             get
             {
                 if (FacilityforIng == FacilityforA1 && FacilityforAButton == true)
                 {
                     return new Rectangle(this.FacilityforA1Client.X + this.DisplayOffset.X, this.FacilityforA1Client.Y + this.DisplayOffset.Y, this.FacilityforA1Client.Width, this.FacilityforA1Client.Height);
                 }
                 else if (FacilityforIng == FacilityforA2 && FacilityforAButton == true)
                 {
                     return new Rectangle(this.FacilityforA2Client.X + this.DisplayOffset.X, this.FacilityforA2Client.Y + this.DisplayOffset.Y, this.FacilityforA2Client.Width, this.FacilityforA2Client.Height);
                 }
                 else if (FacilityforIng == FacilityforA3 && FacilityforAButton == true) { return new Rectangle(this.FacilityforA3Client.X + this.DisplayOffset.X, this.FacilityforA3Client.Y + this.DisplayOffset.Y, this.FacilityforA3Client.Width, this.FacilityforA3Client.Height); }
                 else if (FacilityforIng == FacilityforA4 && FacilityforAButton == true) { return new Rectangle(this.FacilityforA4Client.X + this.DisplayOffset.X, this.FacilityforA4Client.Y + this.DisplayOffset.Y, this.FacilityforA4Client.Width, this.FacilityforA4Client.Height); }
                 else if (FacilityforIng == FacilityforA5 && FacilityforAButton == true) { return new Rectangle(this.FacilityforA5Client.X + this.DisplayOffset.X, this.FacilityforA5Client.Y + this.DisplayOffset.Y, this.FacilityforA5Client.Width, this.FacilityforA5Client.Height); }
                 else if (FacilityforIng == FacilityforA6 && FacilityforAButton == true) { return new Rectangle(this.FacilityforA6Client.X + this.DisplayOffset.X, this.FacilityforA6Client.Y + this.DisplayOffset.Y, this.FacilityforA6Client.Width, this.FacilityforA6Client.Height); }
                 else if (FacilityforIng == FacilityforA7 && FacilityforAButton == true) { return new Rectangle(this.FacilityforA7Client.X + this.DisplayOffset.X, this.FacilityforA7Client.Y + this.DisplayOffset.Y, this.FacilityforA7Client.Width, this.FacilityforA7Client.Height); }
                 else if (FacilityforIng == FacilityforA8 && FacilityforAButton == true) { return new Rectangle(this.FacilityforA8Client.X + this.DisplayOffset.X, this.FacilityforA8Client.Y + this.DisplayOffset.Y, this.FacilityforA8Client.Width, this.FacilityforA8Client.Height); }
                 else if (FacilityforIng == FacilityforA9 && FacilityforAButton == true) { return new Rectangle(this.FacilityforA9Client.X + this.DisplayOffset.X, this.FacilityforA9Client.Y + this.DisplayOffset.Y, this.FacilityforA9Client.Width, this.FacilityforA9Client.Height); }
                 else if (FacilityforIng == FacilityforA10 && FacilityforAButton == true) { return new Rectangle(this.FacilityforA10Client.X + this.DisplayOffset.X, this.FacilityforA10Client.Y + this.DisplayOffset.Y, this.FacilityforA10Client.Width, this.FacilityforA10Client.Height); }
                 else if (FacilityforIng == FacilityforA11 && FacilityforAButton == true) { return new Rectangle(this.FacilityforA11Client.X + this.DisplayOffset.X, this.FacilityforA11Client.Y + this.DisplayOffset.Y, this.FacilityforA11Client.Width, this.FacilityforA11Client.Height); }
                 else if (FacilityforIng == FacilityforA12 && FacilityforAButton == true) { return new Rectangle(this.FacilityforA12Client.X + this.DisplayOffset.X, this.FacilityforA12Client.Y + this.DisplayOffset.Y, this.FacilityforA12Client.Width, this.FacilityforA12Client.Height); }
                 else if (FacilityforIng == FacilityforA13 && FacilityforAButton == true) { return new Rectangle(this.FacilityforA13Client.X + this.DisplayOffset.X, this.FacilityforA13Client.Y + this.DisplayOffset.Y, this.FacilityforA13Client.Width, this.FacilityforA13Client.Height); }
                 else if (FacilityforIng == FacilityforA14 && FacilityforAButton == true) { return new Rectangle(this.FacilityforA14Client.X + this.DisplayOffset.X, this.FacilityforA14Client.Y + this.DisplayOffset.Y, this.FacilityforA14Client.Width, this.FacilityforA14Client.Height); }
                 else if (FacilityforIng == FacilityforA15 && FacilityforAButton == true) { return new Rectangle(this.FacilityforA15Client.X + this.DisplayOffset.X, this.FacilityforA15Client.Y + this.DisplayOffset.Y, this.FacilityforA15Client.Width, this.FacilityforA15Client.Height); }
                 else if (FacilityforIng == FacilityforA16 && FacilityforAButton == true) { return new Rectangle(this.FacilityforA16Client.X + this.DisplayOffset.X, this.FacilityforA16Client.Y + this.DisplayOffset.Y, this.FacilityforA16Client.Width, this.FacilityforA16Client.Height); }
                 else if (FacilityforIng == FacilityforA17 && FacilityforAButton == true) { return new Rectangle(this.FacilityforA17Client.X + this.DisplayOffset.X, this.FacilityforA17Client.Y + this.DisplayOffset.Y, this.FacilityforA17Client.Width, this.FacilityforA17Client.Height); }
                 else if (FacilityforIng == FacilityforA18 && FacilityforAButton == true) { return new Rectangle(this.FacilityforA18Client.X + this.DisplayOffset.X, this.FacilityforA18Client.Y + this.DisplayOffset.Y, this.FacilityforA18Client.Width, this.FacilityforA18Client.Height); }
                 else if (FacilityforIng == FacilityforA19 && FacilityforAButton == true) { return new Rectangle(this.FacilityforA19Client.X + this.DisplayOffset.X, this.FacilityforA19Client.Y + this.DisplayOffset.Y, this.FacilityforA19Client.Width, this.FacilityforA19Client.Height); }
                 else if (FacilityforIng == FacilityforA20 && FacilityforAButton == true) { return new Rectangle(this.FacilityforA20Client.X + this.DisplayOffset.X, this.FacilityforA20Client.Y + this.DisplayOffset.Y, this.FacilityforA20Client.Width, this.FacilityforA20Client.Height); }
                 else if (FacilityforIng == FacilityforA21 && FacilityforAButton == true) { return new Rectangle(this.FacilityforA21Client.X + this.DisplayOffset.X, this.FacilityforA21Client.Y + this.DisplayOffset.Y, this.FacilityforA21Client.Width, this.FacilityforA21Client.Height); }
                 else if (FacilityforIng == FacilityforA22 && FacilityforAButton == true) { return new Rectangle(this.FacilityforA22Client.X + this.DisplayOffset.X, this.FacilityforA22Client.Y + this.DisplayOffset.Y, this.FacilityforA22Client.Width, this.FacilityforA22Client.Height); }
                 else if (FacilityforIng == FacilityforA23 && FacilityforAButton == true) { return new Rectangle(this.FacilityforA23Client.X + this.DisplayOffset.X, this.FacilityforA23Client.Y + this.DisplayOffset.Y, this.FacilityforA23Client.Width, this.FacilityforA23Client.Height); }
                 else if (FacilityforIng == FacilityforA24 && FacilityforAButton == true) { return new Rectangle(this.FacilityforA24Client.X + this.DisplayOffset.X, this.FacilityforA24Client.Y + this.DisplayOffset.Y, this.FacilityforA24Client.Width, this.FacilityforA24Client.Height); }
                 else if (FacilityforIng == FacilityforA25 && FacilityforAButton == true) { return new Rectangle(this.FacilityforA25Client.X + this.DisplayOffset.X, this.FacilityforA25Client.Y + this.DisplayOffset.Y, this.FacilityforA25Client.Width, this.FacilityforA25Client.Height); }
                 else if (FacilityforIng == FacilityforA26 && FacilityforAButton == true) { return new Rectangle(this.FacilityforA26Client.X + this.DisplayOffset.X, this.FacilityforA26Client.Y + this.DisplayOffset.Y, this.FacilityforA26Client.Width, this.FacilityforA26Client.Height); }
                 else if (FacilityforIng == FacilityforA27 && FacilityforAButton == true) { return new Rectangle(this.FacilityforA27Client.X + this.DisplayOffset.X, this.FacilityforA27Client.Y + this.DisplayOffset.Y, this.FacilityforA27Client.Width, this.FacilityforA27Client.Height); }
                 else if (FacilityforIng == FacilityforA28 && FacilityforAButton == true) { return new Rectangle(this.FacilityforA28Client.X + this.DisplayOffset.X, this.FacilityforA28Client.Y + this.DisplayOffset.Y, this.FacilityforA28Client.Width, this.FacilityforA28Client.Height); }
                 else if (FacilityforIng == FacilityforB1 && FacilityforBButton == true) { return new Rectangle(this.FacilityforB1Client.X + this.DisplayOffset.X, this.FacilityforB1Client.Y + this.DisplayOffset.Y, this.FacilityforB1Client.Width, this.FacilityforB1Client.Height); }
                 else if (FacilityforIng == FacilityforB2 && FacilityforBButton == true) { return new Rectangle(this.FacilityforB2Client.X + this.DisplayOffset.X, this.FacilityforB2Client.Y + this.DisplayOffset.Y, this.FacilityforB2Client.Width, this.FacilityforB2Client.Height); }
                 else if (FacilityforIng == FacilityforB3 && FacilityforBButton == true) { return new Rectangle(this.FacilityforB3Client.X + this.DisplayOffset.X, this.FacilityforB3Client.Y + this.DisplayOffset.Y, this.FacilityforB3Client.Width, this.FacilityforB3Client.Height); }
                 else if (FacilityforIng == FacilityforB4 && FacilityforBButton == true) { return new Rectangle(this.FacilityforB4Client.X + this.DisplayOffset.X, this.FacilityforB4Client.Y + this.DisplayOffset.Y, this.FacilityforB4Client.Width, this.FacilityforB4Client.Height); }
                 else if (FacilityforIng == FacilityforB5 && FacilityforBButton == true) { return new Rectangle(this.FacilityforB5Client.X + this.DisplayOffset.X, this.FacilityforB5Client.Y + this.DisplayOffset.Y, this.FacilityforB5Client.Width, this.FacilityforB5Client.Height); }
                 else if (FacilityforIng == FacilityforB6 && FacilityforBButton == true) { return new Rectangle(this.FacilityforB6Client.X + this.DisplayOffset.X, this.FacilityforB6Client.Y + this.DisplayOffset.Y, this.FacilityforB6Client.Width, this.FacilityforB6Client.Height); }
                 else if (FacilityforIng == FacilityforB7 && FacilityforBButton == true) { return new Rectangle(this.FacilityforB7Client.X + this.DisplayOffset.X, this.FacilityforB7Client.Y + this.DisplayOffset.Y, this.FacilityforB7Client.Width, this.FacilityforB7Client.Height); }
                 else if (FacilityforIng == FacilityforB8 && FacilityforBButton == true) { return new Rectangle(this.FacilityforB8Client.X + this.DisplayOffset.X, this.FacilityforB8Client.Y + this.DisplayOffset.Y, this.FacilityforB8Client.Width, this.FacilityforB8Client.Height); }
                 else if (FacilityforIng == FacilityforB9 && FacilityforBButton == true) { return new Rectangle(this.FacilityforB9Client.X + this.DisplayOffset.X, this.FacilityforB9Client.Y + this.DisplayOffset.Y, this.FacilityforB9Client.Width, this.FacilityforB9Client.Height); }
                 else if (FacilityforIng == FacilityforB10 && FacilityforBButton == true) { return new Rectangle(this.FacilityforB10Client.X + this.DisplayOffset.X, this.FacilityforB10Client.Y + this.DisplayOffset.Y, this.FacilityforB10Client.Width, this.FacilityforB10Client.Height); }
                 else if (FacilityforIng == FacilityforB11 && FacilityforBButton == true) { return new Rectangle(this.FacilityforB11Client.X + this.DisplayOffset.X, this.FacilityforB11Client.Y + this.DisplayOffset.Y, this.FacilityforB11Client.Width, this.FacilityforB11Client.Height); }
                 else if (FacilityforIng == FacilityforB12 && FacilityforBButton == true) { return new Rectangle(this.FacilityforB12Client.X + this.DisplayOffset.X, this.FacilityforB12Client.Y + this.DisplayOffset.Y, this.FacilityforB12Client.Width, this.FacilityforB12Client.Height); }
                 else if (FacilityforIng == FacilityforB13 && FacilityforBButton == true) { return new Rectangle(this.FacilityforB13Client.X + this.DisplayOffset.X, this.FacilityforB13Client.Y + this.DisplayOffset.Y, this.FacilityforB13Client.Width, this.FacilityforB13Client.Height); }
                 else if (FacilityforIng == FacilityforB14 && FacilityforBButton == true) { return new Rectangle(this.FacilityforB14Client.X + this.DisplayOffset.X, this.FacilityforB14Client.Y + this.DisplayOffset.Y, this.FacilityforB14Client.Width, this.FacilityforB14Client.Height); }
                 else if (FacilityforIng == FacilityforB15 && FacilityforBButton == true) { return new Rectangle(this.FacilityforB15Client.X + this.DisplayOffset.X, this.FacilityforB15Client.Y + this.DisplayOffset.Y, this.FacilityforB15Client.Width, this.FacilityforB15Client.Height); }
                 else if (FacilityforIng == FacilityforB16 && FacilityforBButton == true) { return new Rectangle(this.FacilityforB16Client.X + this.DisplayOffset.X, this.FacilityforB16Client.Y + this.DisplayOffset.Y, this.FacilityforB16Client.Width, this.FacilityforB16Client.Height); }
                 else if (FacilityforIng == FacilityforB17 && FacilityforBButton == true) { return new Rectangle(this.FacilityforB17Client.X + this.DisplayOffset.X, this.FacilityforB17Client.Y + this.DisplayOffset.Y, this.FacilityforB17Client.Width, this.FacilityforB17Client.Height); }
                 else if (FacilityforIng == FacilityforB18 && FacilityforBButton == true) { return new Rectangle(this.FacilityforB18Client.X + this.DisplayOffset.X, this.FacilityforB18Client.Y + this.DisplayOffset.Y, this.FacilityforB18Client.Width, this.FacilityforB18Client.Height); }
                 else if (FacilityforIng == FacilityforB19 && FacilityforBButton == true) { return new Rectangle(this.FacilityforB19Client.X + this.DisplayOffset.X, this.FacilityforB19Client.Y + this.DisplayOffset.Y, this.FacilityforB19Client.Width, this.FacilityforB19Client.Height); }
                 else if (FacilityforIng == FacilityforB20 && FacilityforBButton == true) { return new Rectangle(this.FacilityforB20Client.X + this.DisplayOffset.X, this.FacilityforB20Client.Y + this.DisplayOffset.Y, this.FacilityforB20Client.Width, this.FacilityforB20Client.Height); }
                 else if (FacilityforIng == FacilityforB21 && FacilityforBButton == true) { return new Rectangle(this.FacilityforB21Client.X + this.DisplayOffset.X, this.FacilityforB21Client.Y + this.DisplayOffset.Y, this.FacilityforB21Client.Width, this.FacilityforB21Client.Height); }
                 else if (FacilityforIng == FacilityforB22 && FacilityforBButton == true) { return new Rectangle(this.FacilityforB22Client.X + this.DisplayOffset.X, this.FacilityforB22Client.Y + this.DisplayOffset.Y, this.FacilityforB22Client.Width, this.FacilityforB22Client.Height); }
                 else if (FacilityforIng == FacilityforB23 && FacilityforBButton == true) { return new Rectangle(this.FacilityforB23Client.X + this.DisplayOffset.X, this.FacilityforB23Client.Y + this.DisplayOffset.Y, this.FacilityforB23Client.Width, this.FacilityforB23Client.Height); }
                 else if (FacilityforIng == FacilityforB24 && FacilityforBButton == true) { return new Rectangle(this.FacilityforB24Client.X + this.DisplayOffset.X, this.FacilityforB24Client.Y + this.DisplayOffset.Y, this.FacilityforB24Client.Width, this.FacilityforB24Client.Height); }
                 else if (FacilityforIng == FacilityforB25 && FacilityforBButton == true) { return new Rectangle(this.FacilityforB25Client.X + this.DisplayOffset.X, this.FacilityforB25Client.Y + this.DisplayOffset.Y, this.FacilityforB25Client.Width, this.FacilityforB25Client.Height); }
                 else if (FacilityforIng == FacilityforB26 && FacilityforBButton == true) { return new Rectangle(this.FacilityforB26Client.X + this.DisplayOffset.X, this.FacilityforB26Client.Y + this.DisplayOffset.Y, this.FacilityforB26Client.Width, this.FacilityforB26Client.Height); }
                 else if (FacilityforIng == FacilityforB27 && FacilityforBButton == true) { return new Rectangle(this.FacilityforB27Client.X + this.DisplayOffset.X, this.FacilityforB27Client.Y + this.DisplayOffset.Y, this.FacilityforB27Client.Width, this.FacilityforB27Client.Height); }
                 else if (FacilityforIng == FacilityforB28 && FacilityforBButton == true) { return new Rectangle(this.FacilityforB28Client.X + this.DisplayOffset.X, this.FacilityforB28Client.Y + this.DisplayOffset.Y, this.FacilityforB28Client.Width, this.FacilityforB28Client.Height); }
                 else if (FacilityforIng == FacilityforC1 && FacilityforCButton == true) { return new Rectangle(this.FacilityforC1Client.X + this.DisplayOffset.X, this.FacilityforC1Client.Y + this.DisplayOffset.Y, this.FacilityforC1Client.Width, this.FacilityforC1Client.Height); }
                 else if (FacilityforIng == FacilityforC2 && FacilityforCButton == true) { return new Rectangle(this.FacilityforC2Client.X + this.DisplayOffset.X, this.FacilityforC2Client.Y + this.DisplayOffset.Y, this.FacilityforC2Client.Width, this.FacilityforC2Client.Height); }
                 else if (FacilityforIng == FacilityforC3 && FacilityforCButton == true) { return new Rectangle(this.FacilityforC3Client.X + this.DisplayOffset.X, this.FacilityforC3Client.Y + this.DisplayOffset.Y, this.FacilityforC3Client.Width, this.FacilityforC3Client.Height); }
                 else if (FacilityforIng == FacilityforC4 && FacilityforCButton == true) { return new Rectangle(this.FacilityforC4Client.X + this.DisplayOffset.X, this.FacilityforC4Client.Y + this.DisplayOffset.Y, this.FacilityforC4Client.Width, this.FacilityforC4Client.Height); }
                 else if (FacilityforIng == FacilityforC5 && FacilityforCButton == true) { return new Rectangle(this.FacilityforC5Client.X + this.DisplayOffset.X, this.FacilityforC5Client.Y + this.DisplayOffset.Y, this.FacilityforC5Client.Width, this.FacilityforC5Client.Height); }
                 else if (FacilityforIng == FacilityforC6 && FacilityforCButton == true) { return new Rectangle(this.FacilityforC6Client.X + this.DisplayOffset.X, this.FacilityforC6Client.Y + this.DisplayOffset.Y, this.FacilityforC6Client.Width, this.FacilityforC6Client.Height); }
                 else if (FacilityforIng == FacilityforC7 && FacilityforCButton == true) { return new Rectangle(this.FacilityforC7Client.X + this.DisplayOffset.X, this.FacilityforC7Client.Y + this.DisplayOffset.Y, this.FacilityforC7Client.Width, this.FacilityforC7Client.Height); }
                 else if (FacilityforIng == FacilityforC8 && FacilityforCButton == true) { return new Rectangle(this.FacilityforC8Client.X + this.DisplayOffset.X, this.FacilityforC8Client.Y + this.DisplayOffset.Y, this.FacilityforC8Client.Width, this.FacilityforC8Client.Height); }
                 else if (FacilityforIng == FacilityforC9 && FacilityforCButton == true) { return new Rectangle(this.FacilityforC9Client.X + this.DisplayOffset.X, this.FacilityforC9Client.Y + this.DisplayOffset.Y, this.FacilityforC9Client.Width, this.FacilityforC9Client.Height); }
                 else if (FacilityforIng == FacilityforC10 && FacilityforCButton == true) { return new Rectangle(this.FacilityforC10Client.X + this.DisplayOffset.X, this.FacilityforC10Client.Y + this.DisplayOffset.Y, this.FacilityforC10Client.Width, this.FacilityforC10Client.Height); }
                 else if (FacilityforIng == FacilityforC11 && FacilityforCButton == true) { return new Rectangle(this.FacilityforC11Client.X + this.DisplayOffset.X, this.FacilityforC11Client.Y + this.DisplayOffset.Y, this.FacilityforC11Client.Width, this.FacilityforC11Client.Height); }
                 else if (FacilityforIng == FacilityforC12 && FacilityforCButton == true) { return new Rectangle(this.FacilityforC12Client.X + this.DisplayOffset.X, this.FacilityforC12Client.Y + this.DisplayOffset.Y, this.FacilityforC12Client.Width, this.FacilityforC12Client.Height); }
                 else if (FacilityforIng == FacilityforC13 && FacilityforCButton == true) { return new Rectangle(this.FacilityforC13Client.X + this.DisplayOffset.X, this.FacilityforC13Client.Y + this.DisplayOffset.Y, this.FacilityforC13Client.Width, this.FacilityforC13Client.Height); }
                 else if (FacilityforIng == FacilityforC14 && FacilityforCButton == true) { return new Rectangle(this.FacilityforC14Client.X + this.DisplayOffset.X, this.FacilityforC14Client.Y + this.DisplayOffset.Y, this.FacilityforC14Client.Width, this.FacilityforC14Client.Height); }
                 else if (FacilityforIng == FacilityforC15 && FacilityforCButton == true) { return new Rectangle(this.FacilityforC15Client.X + this.DisplayOffset.X, this.FacilityforC15Client.Y + this.DisplayOffset.Y, this.FacilityforC15Client.Width, this.FacilityforC15Client.Height); }
                 else if (FacilityforIng == FacilityforC16 && FacilityforCButton == true) { return new Rectangle(this.FacilityforC16Client.X + this.DisplayOffset.X, this.FacilityforC16Client.Y + this.DisplayOffset.Y, this.FacilityforC16Client.Width, this.FacilityforC16Client.Height); }
                 else if (FacilityforIng == FacilityforC17 && FacilityforCButton == true) { return new Rectangle(this.FacilityforC17Client.X + this.DisplayOffset.X, this.FacilityforC17Client.Y + this.DisplayOffset.Y, this.FacilityforC17Client.Width, this.FacilityforC17Client.Height); }
                 else if (FacilityforIng == FacilityforC18 && FacilityforCButton == true) { return new Rectangle(this.FacilityforC18Client.X + this.DisplayOffset.X, this.FacilityforC18Client.Y + this.DisplayOffset.Y, this.FacilityforC18Client.Width, this.FacilityforC18Client.Height); }
                 else if (FacilityforIng == FacilityforC19 && FacilityforCButton == true) { return new Rectangle(this.FacilityforC19Client.X + this.DisplayOffset.X, this.FacilityforC19Client.Y + this.DisplayOffset.Y, this.FacilityforC19Client.Width, this.FacilityforC19Client.Height); }
                 else if (FacilityforIng == FacilityforC20 && FacilityforCButton == true) { return new Rectangle(this.FacilityforC20Client.X + this.DisplayOffset.X, this.FacilityforC20Client.Y + this.DisplayOffset.Y, this.FacilityforC20Client.Width, this.FacilityforC20Client.Height); }
                 else if (FacilityforIng == FacilityforC21 && FacilityforCButton == true) { return new Rectangle(this.FacilityforC21Client.X + this.DisplayOffset.X, this.FacilityforC21Client.Y + this.DisplayOffset.Y, this.FacilityforC21Client.Width, this.FacilityforC21Client.Height); }
                 else if (FacilityforIng == FacilityforC22 && FacilityforCButton == true) { return new Rectangle(this.FacilityforC22Client.X + this.DisplayOffset.X, this.FacilityforC22Client.Y + this.DisplayOffset.Y, this.FacilityforC22Client.Width, this.FacilityforC22Client.Height); }
                 else if (FacilityforIng == FacilityforC23 && FacilityforCButton == true) { return new Rectangle(this.FacilityforC23Client.X + this.DisplayOffset.X, this.FacilityforC23Client.Y + this.DisplayOffset.Y, this.FacilityforC23Client.Width, this.FacilityforC23Client.Height); }
                 else if (FacilityforIng == FacilityforC24 && FacilityforCButton == true) { return new Rectangle(this.FacilityforC24Client.X + this.DisplayOffset.X, this.FacilityforC24Client.Y + this.DisplayOffset.Y, this.FacilityforC24Client.Width, this.FacilityforC24Client.Height); }
                 else if (FacilityforIng == FacilityforC25 && FacilityforCButton == true) { return new Rectangle(this.FacilityforC25Client.X + this.DisplayOffset.X, this.FacilityforC25Client.Y + this.DisplayOffset.Y, this.FacilityforC25Client.Width, this.FacilityforC25Client.Height); }
                 else if (FacilityforIng == FacilityforC26 && FacilityforCButton == true) { return new Rectangle(this.FacilityforC26Client.X + this.DisplayOffset.X, this.FacilityforC26Client.Y + this.DisplayOffset.Y, this.FacilityforC26Client.Width, this.FacilityforC26Client.Height); }
                 else if (FacilityforIng == FacilityforC27 && FacilityforCButton == true) { return new Rectangle(this.FacilityforC27Client.X + this.DisplayOffset.X, this.FacilityforC27Client.Y + this.DisplayOffset.Y, this.FacilityforC27Client.Width, this.FacilityforC27Client.Height); }
                 else if (FacilityforIng == FacilityforC28 && FacilityforCButton == true) { return new Rectangle(this.FacilityforC28Client.X + this.DisplayOffset.X, this.FacilityforC28Client.Y + this.DisplayOffset.Y, this.FacilityforC28Client.Width, this.FacilityforC28Client.Height); }
                 else if (FacilityforIng == FacilityforD1 && FacilityforDButton == true) { return new Rectangle(this.FacilityforD1Client.X + this.DisplayOffset.X, this.FacilityforD1Client.Y + this.DisplayOffset.Y, this.FacilityforD1Client.Width, this.FacilityforD1Client.Height); }
                 else if (FacilityforIng == FacilityforD2 && FacilityforDButton == true) { return new Rectangle(this.FacilityforD2Client.X + this.DisplayOffset.X, this.FacilityforD2Client.Y + this.DisplayOffset.Y, this.FacilityforD2Client.Width, this.FacilityforD2Client.Height); }
                 else if (FacilityforIng == FacilityforD3 && FacilityforDButton == true) { return new Rectangle(this.FacilityforD3Client.X + this.DisplayOffset.X, this.FacilityforD3Client.Y + this.DisplayOffset.Y, this.FacilityforD3Client.Width, this.FacilityforD3Client.Height); }
                 else if (FacilityforIng == FacilityforD4 && FacilityforDButton == true) { return new Rectangle(this.FacilityforD4Client.X + this.DisplayOffset.X, this.FacilityforD4Client.Y + this.DisplayOffset.Y, this.FacilityforD4Client.Width, this.FacilityforD4Client.Height); }
                 else if (FacilityforIng == FacilityforD5 && FacilityforDButton == true) { return new Rectangle(this.FacilityforD5Client.X + this.DisplayOffset.X, this.FacilityforD5Client.Y + this.DisplayOffset.Y, this.FacilityforD5Client.Width, this.FacilityforD5Client.Height); }
                 else if (FacilityforIng == FacilityforD6 && FacilityforDButton == true) { return new Rectangle(this.FacilityforD6Client.X + this.DisplayOffset.X, this.FacilityforD6Client.Y + this.DisplayOffset.Y, this.FacilityforD6Client.Width, this.FacilityforD6Client.Height); }
                 else if (FacilityforIng == FacilityforD7 && FacilityforDButton == true) { return new Rectangle(this.FacilityforD7Client.X + this.DisplayOffset.X, this.FacilityforD7Client.Y + this.DisplayOffset.Y, this.FacilityforD7Client.Width, this.FacilityforD7Client.Height); }
                 else if (FacilityforIng == FacilityforD8 && FacilityforDButton == true) { return new Rectangle(this.FacilityforD8Client.X + this.DisplayOffset.X, this.FacilityforD8Client.Y + this.DisplayOffset.Y, this.FacilityforD8Client.Width, this.FacilityforD8Client.Height); }
                 else if (FacilityforIng == FacilityforD9 && FacilityforDButton == true) { return new Rectangle(this.FacilityforD9Client.X + this.DisplayOffset.X, this.FacilityforD9Client.Y + this.DisplayOffset.Y, this.FacilityforD9Client.Width, this.FacilityforD9Client.Height); }
                 else if (FacilityforIng == FacilityforD10 && FacilityforDButton == true) { return new Rectangle(this.FacilityforD10Client.X + this.DisplayOffset.X, this.FacilityforD10Client.Y + this.DisplayOffset.Y, this.FacilityforD10Client.Width, this.FacilityforD10Client.Height); }
                 else if (FacilityforIng == FacilityforD11 && FacilityforDButton == true) { return new Rectangle(this.FacilityforD11Client.X + this.DisplayOffset.X, this.FacilityforD11Client.Y + this.DisplayOffset.Y, this.FacilityforD11Client.Width, this.FacilityforD11Client.Height); }
                 else if (FacilityforIng == FacilityforD12 && FacilityforDButton == true) { return new Rectangle(this.FacilityforD12Client.X + this.DisplayOffset.X, this.FacilityforD12Client.Y + this.DisplayOffset.Y, this.FacilityforD12Client.Width, this.FacilityforD12Client.Height); }
                 else if (FacilityforIng == FacilityforD13 && FacilityforDButton == true) { return new Rectangle(this.FacilityforD13Client.X + this.DisplayOffset.X, this.FacilityforD13Client.Y + this.DisplayOffset.Y, this.FacilityforD13Client.Width, this.FacilityforD13Client.Height); }
                 else if (FacilityforIng == FacilityforD14 && FacilityforDButton == true) { return new Rectangle(this.FacilityforD14Client.X + this.DisplayOffset.X, this.FacilityforD14Client.Y + this.DisplayOffset.Y, this.FacilityforD14Client.Width, this.FacilityforD14Client.Height); }
                 else if (FacilityforIng == FacilityforD15 && FacilityforDButton == true) { return new Rectangle(this.FacilityforD15Client.X + this.DisplayOffset.X, this.FacilityforD15Client.Y + this.DisplayOffset.Y, this.FacilityforD15Client.Width, this.FacilityforD15Client.Height); }
                 else if (FacilityforIng == FacilityforD16 && FacilityforDButton == true) { return new Rectangle(this.FacilityforD16Client.X + this.DisplayOffset.X, this.FacilityforD16Client.Y + this.DisplayOffset.Y, this.FacilityforD16Client.Width, this.FacilityforD16Client.Height); }
                 else if (FacilityforIng == FacilityforD17 && FacilityforDButton == true) { return new Rectangle(this.FacilityforD17Client.X + this.DisplayOffset.X, this.FacilityforD17Client.Y + this.DisplayOffset.Y, this.FacilityforD17Client.Width, this.FacilityforD17Client.Height); }
                 else if (FacilityforIng == FacilityforD18 && FacilityforDButton == true) { return new Rectangle(this.FacilityforD18Client.X + this.DisplayOffset.X, this.FacilityforD18Client.Y + this.DisplayOffset.Y, this.FacilityforD18Client.Width, this.FacilityforD18Client.Height); }
                 else if (FacilityforIng == FacilityforD19 && FacilityforDButton == true) { return new Rectangle(this.FacilityforD19Client.X + this.DisplayOffset.X, this.FacilityforD19Client.Y + this.DisplayOffset.Y, this.FacilityforD19Client.Width, this.FacilityforD19Client.Height); }
                 else if (FacilityforIng == FacilityforD20 && FacilityforDButton == true) { return new Rectangle(this.FacilityforD20Client.X + this.DisplayOffset.X, this.FacilityforD20Client.Y + this.DisplayOffset.Y, this.FacilityforD20Client.Width, this.FacilityforD20Client.Height); }
                 else if (FacilityforIng == FacilityforD21 && FacilityforDButton == true) { return new Rectangle(this.FacilityforD21Client.X + this.DisplayOffset.X, this.FacilityforD21Client.Y + this.DisplayOffset.Y, this.FacilityforD21Client.Width, this.FacilityforD21Client.Height); }
                 else if (FacilityforIng == FacilityforD22 && FacilityforDButton == true) { return new Rectangle(this.FacilityforD22Client.X + this.DisplayOffset.X, this.FacilityforD22Client.Y + this.DisplayOffset.Y, this.FacilityforD22Client.Width, this.FacilityforD22Client.Height); }
                 else if (FacilityforIng == FacilityforD23 && FacilityforDButton == true) { return new Rectangle(this.FacilityforD23Client.X + this.DisplayOffset.X, this.FacilityforD23Client.Y + this.DisplayOffset.Y, this.FacilityforD23Client.Width, this.FacilityforD23Client.Height); }
                 else if (FacilityforIng == FacilityforD24 && FacilityforDButton == true) { return new Rectangle(this.FacilityforD24Client.X + this.DisplayOffset.X, this.FacilityforD24Client.Y + this.DisplayOffset.Y, this.FacilityforD24Client.Width, this.FacilityforD24Client.Height); }
                 else if (FacilityforIng == FacilityforD25 && FacilityforDButton == true) { return new Rectangle(this.FacilityforD25Client.X + this.DisplayOffset.X, this.FacilityforD25Client.Y + this.DisplayOffset.Y, this.FacilityforD25Client.Width, this.FacilityforD25Client.Height); }
                 else if (FacilityforIng == FacilityforD26 && FacilityforDButton == true) { return new Rectangle(this.FacilityforD26Client.X + this.DisplayOffset.X, this.FacilityforD26Client.Y + this.DisplayOffset.Y, this.FacilityforD26Client.Width, this.FacilityforD26Client.Height); }
                 else if (FacilityforIng == FacilityforD27 && FacilityforDButton == true) { return new Rectangle(this.FacilityforD27Client.X + this.DisplayOffset.X, this.FacilityforD27Client.Y + this.DisplayOffset.Y, this.FacilityforD27Client.Width, this.FacilityforD27Client.Height); }
                 else if (FacilityforIng == FacilityforD28 && FacilityforDButton == true) { return new Rectangle(this.FacilityforD28Client.X + this.DisplayOffset.X, this.FacilityforD28Client.Y + this.DisplayOffset.Y, this.FacilityforD28Client.Width, this.FacilityforD28Client.Height); }
                 else if (FacilityforIng == FacilityforE1 && FacilityforEButton == true) { return new Rectangle(this.FacilityforE1Client.X + this.DisplayOffset.X, this.FacilityforE1Client.Y + this.DisplayOffset.Y, this.FacilityforE1Client.Width, this.FacilityforE1Client.Height); }
                 else if (FacilityforIng == FacilityforE2 && FacilityforEButton == true) { return new Rectangle(this.FacilityforE2Client.X + this.DisplayOffset.X, this.FacilityforE2Client.Y + this.DisplayOffset.Y, this.FacilityforE2Client.Width, this.FacilityforE2Client.Height); }
                 else if (FacilityforIng == FacilityforE3 && FacilityforEButton == true) { return new Rectangle(this.FacilityforE3Client.X + this.DisplayOffset.X, this.FacilityforE3Client.Y + this.DisplayOffset.Y, this.FacilityforE3Client.Width, this.FacilityforE3Client.Height); }
                 else if (FacilityforIng == FacilityforE4 && FacilityforEButton == true) { return new Rectangle(this.FacilityforE4Client.X + this.DisplayOffset.X, this.FacilityforE4Client.Y + this.DisplayOffset.Y, this.FacilityforE4Client.Width, this.FacilityforE4Client.Height); }
                 else if (FacilityforIng == FacilityforE5 && FacilityforEButton == true) { return new Rectangle(this.FacilityforE5Client.X + this.DisplayOffset.X, this.FacilityforE5Client.Y + this.DisplayOffset.Y, this.FacilityforE5Client.Width, this.FacilityforE5Client.Height); }
                 else if (FacilityforIng == FacilityforE6 && FacilityforEButton == true) { return new Rectangle(this.FacilityforE6Client.X + this.DisplayOffset.X, this.FacilityforE6Client.Y + this.DisplayOffset.Y, this.FacilityforE6Client.Width, this.FacilityforE6Client.Height); }
                 else if (FacilityforIng == FacilityforE7 && FacilityforEButton == true) { return new Rectangle(this.FacilityforE7Client.X + this.DisplayOffset.X, this.FacilityforE7Client.Y + this.DisplayOffset.Y, this.FacilityforE7Client.Width, this.FacilityforE7Client.Height); }
                 else if (FacilityforIng == FacilityforE8 && FacilityforEButton == true) { return new Rectangle(this.FacilityforE8Client.X + this.DisplayOffset.X, this.FacilityforE8Client.Y + this.DisplayOffset.Y, this.FacilityforE8Client.Width, this.FacilityforE8Client.Height); }
                 else if (FacilityforIng == FacilityforE9 && FacilityforEButton == true) { return new Rectangle(this.FacilityforE9Client.X + this.DisplayOffset.X, this.FacilityforE9Client.Y + this.DisplayOffset.Y, this.FacilityforE9Client.Width, this.FacilityforE9Client.Height); }
                 else if (FacilityforIng == FacilityforE10 && FacilityforEButton == true) { return new Rectangle(this.FacilityforE10Client.X + this.DisplayOffset.X, this.FacilityforE10Client.Y + this.DisplayOffset.Y, this.FacilityforE10Client.Width, this.FacilityforE10Client.Height); }
                 else if (FacilityforIng == FacilityforE11 && FacilityforEButton == true) { return new Rectangle(this.FacilityforE11Client.X + this.DisplayOffset.X, this.FacilityforE11Client.Y + this.DisplayOffset.Y, this.FacilityforE11Client.Width, this.FacilityforE11Client.Height); }
                 else if (FacilityforIng == FacilityforE12 && FacilityforEButton == true) { return new Rectangle(this.FacilityforE12Client.X + this.DisplayOffset.X, this.FacilityforE12Client.Y + this.DisplayOffset.Y, this.FacilityforE12Client.Width, this.FacilityforE12Client.Height); }
                 else if (FacilityforIng == FacilityforE13 && FacilityforEButton == true) { return new Rectangle(this.FacilityforE13Client.X + this.DisplayOffset.X, this.FacilityforE13Client.Y + this.DisplayOffset.Y, this.FacilityforE13Client.Width, this.FacilityforE13Client.Height); }
                 else if (FacilityforIng == FacilityforE14 && FacilityforEButton == true) { return new Rectangle(this.FacilityforE14Client.X + this.DisplayOffset.X, this.FacilityforE14Client.Y + this.DisplayOffset.Y, this.FacilityforE14Client.Width, this.FacilityforE14Client.Height); }
                 else if (FacilityforIng == FacilityforE15 && FacilityforEButton == true) { return new Rectangle(this.FacilityforE15Client.X + this.DisplayOffset.X, this.FacilityforE15Client.Y + this.DisplayOffset.Y, this.FacilityforE15Client.Width, this.FacilityforE15Client.Height); }
                 else if (FacilityforIng == FacilityforE16 && FacilityforEButton == true) { return new Rectangle(this.FacilityforE16Client.X + this.DisplayOffset.X, this.FacilityforE16Client.Y + this.DisplayOffset.Y, this.FacilityforE16Client.Width, this.FacilityforE16Client.Height); }
                 else if (FacilityforIng == FacilityforE17 && FacilityforEButton == true) { return new Rectangle(this.FacilityforE17Client.X + this.DisplayOffset.X, this.FacilityforE17Client.Y + this.DisplayOffset.Y, this.FacilityforE17Client.Width, this.FacilityforE17Client.Height); }
                 else if (FacilityforIng == FacilityforE18 && FacilityforEButton == true) { return new Rectangle(this.FacilityforE18Client.X + this.DisplayOffset.X, this.FacilityforE18Client.Y + this.DisplayOffset.Y, this.FacilityforE18Client.Width, this.FacilityforE18Client.Height); }
                 else if (FacilityforIng == FacilityforE19 && FacilityforEButton == true) { return new Rectangle(this.FacilityforE19Client.X + this.DisplayOffset.X, this.FacilityforE19Client.Y + this.DisplayOffset.Y, this.FacilityforE19Client.Width, this.FacilityforE19Client.Height); }
                 else if (FacilityforIng == FacilityforE20 && FacilityforEButton == true) { return new Rectangle(this.FacilityforE20Client.X + this.DisplayOffset.X, this.FacilityforE20Client.Y + this.DisplayOffset.Y, this.FacilityforE20Client.Width, this.FacilityforE20Client.Height); }
                 else if (FacilityforIng == FacilityforE21 && FacilityforEButton == true) { return new Rectangle(this.FacilityforE21Client.X + this.DisplayOffset.X, this.FacilityforE21Client.Y + this.DisplayOffset.Y, this.FacilityforE21Client.Width, this.FacilityforE21Client.Height); }
                 else if (FacilityforIng == FacilityforE22 && FacilityforEButton == true) { return new Rectangle(this.FacilityforE22Client.X + this.DisplayOffset.X, this.FacilityforE22Client.Y + this.DisplayOffset.Y, this.FacilityforE22Client.Width, this.FacilityforE22Client.Height); }
                 else if (FacilityforIng == FacilityforE23 && FacilityforEButton == true) { return new Rectangle(this.FacilityforE23Client.X + this.DisplayOffset.X, this.FacilityforE23Client.Y + this.DisplayOffset.Y, this.FacilityforE23Client.Width, this.FacilityforE23Client.Height); }
                 else if (FacilityforIng == FacilityforE24 && FacilityforEButton == true) { return new Rectangle(this.FacilityforE24Client.X + this.DisplayOffset.X, this.FacilityforE24Client.Y + this.DisplayOffset.Y, this.FacilityforE24Client.Width, this.FacilityforE24Client.Height); }
                 else if (FacilityforIng == FacilityforE25 && FacilityforEButton == true) { return new Rectangle(this.FacilityforE25Client.X + this.DisplayOffset.X, this.FacilityforE25Client.Y + this.DisplayOffset.Y, this.FacilityforE25Client.Width, this.FacilityforE25Client.Height); }
                 else if (FacilityforIng == FacilityforE26 && FacilityforEButton == true) { return new Rectangle(this.FacilityforE26Client.X + this.DisplayOffset.X, this.FacilityforE26Client.Y + this.DisplayOffset.Y, this.FacilityforE26Client.Width, this.FacilityforE26Client.Height); }
                 else if (FacilityforIng == FacilityforE27 && FacilityforEButton == true) { return new Rectangle(this.FacilityforE27Client.X + this.DisplayOffset.X, this.FacilityforE27Client.Y + this.DisplayOffset.Y, this.FacilityforE27Client.Width, this.FacilityforE27Client.Height); }
                 else if (FacilityforIng == FacilityforE28 && FacilityforEButton == true) { return new Rectangle(this.FacilityforE28Client.X + this.DisplayOffset.X, this.FacilityforE28Client.Y + this.DisplayOffset.Y, this.FacilityforE28Client.Width, this.FacilityforE28Client.Height); }

                 else 
                 {
                     return new Rectangle(this.FacilityforIngClient.X + this.DisplayOffset.X, this.FacilityforIngClient.Y + this.DisplayOffset.Y, 0, 0);
                 }

             }
         }
        
        //设施介绍位置定义
        
        private Rectangle FacilityATextDisplayPosition
         {
             get
             {
                 if (FacilityforAButton == true)
                 {
                     return new Rectangle(this.FacilityAText.DisplayOffset.X, this.FacilityAText.DisplayOffset.Y, this.FacilityAText.ClientWidth, this.FacilityAText.ClientHeight);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityAText.DisplayOffset.X, this.FacilityAText.DisplayOffset.Y, 0, 0);
                 }
                 
             }
         }
       
       private Rectangle FacilityBTextDisplayPosition
         {
             get
             {
                 if (FacilityforBButton == true)
                 {
                     return new Rectangle(this.FacilityBText.DisplayOffset.X, this.FacilityBText.DisplayOffset.Y, this.FacilityBText.ClientWidth, this.FacilityBText.ClientHeight);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityBText.DisplayOffset.X, this.FacilityBText.DisplayOffset.Y, 0, 0);
                 }
                 
             }
         }
         private Rectangle FacilityCTextDisplayPosition
         {
             get
             {
                 if (FacilityforCButton == true)
                 {
                     return new Rectangle(this.FacilityCText.DisplayOffset.X, this.FacilityCText.DisplayOffset.Y, this.FacilityCText.ClientWidth, this.FacilityCText.ClientHeight);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityCText.DisplayOffset.X, this.FacilityCText.DisplayOffset.Y, 0, 0);
                 }
                 
             }
         }
         private Rectangle FacilityDTextDisplayPosition
         {
             get
             {
                 if (FacilityforDButton == true)
                 {
                     return new Rectangle(this.FacilityDText.DisplayOffset.X, this.FacilityDText.DisplayOffset.Y, this.FacilityDText.ClientWidth, this.FacilityDText.ClientHeight);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityDText.DisplayOffset.X, this.FacilityDText.DisplayOffset.Y, 0, 0);
                 }
                 
             }
         }
         private Rectangle FacilityETextDisplayPosition
         {
             get
             {
                 if (FacilityforEButton == true)
                 {
                     return new Rectangle(this.FacilityEText.DisplayOffset.X, this.FacilityEText.DisplayOffset.Y, this.FacilityEText.ClientWidth, this.FacilityEText.ClientHeight);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityEText.DisplayOffset.X, this.FacilityEText.DisplayOffset.Y, 0, 0);
                 }
                 
             }
         }
 
         private Rectangle FacilityZTextDisplayPosition
         {
             get
             {
                 if (FacilityIng == true)
                 {
                     return new Rectangle(this.FacilityZText.DisplayOffset.X, this.FacilityZText.DisplayOffset.Y, this.FacilityZText.ClientWidth, this.FacilityZText.ClientHeight);
                 }
                 else
                 {
                     return new Rectangle(this.FacilityZText.DisplayOffset.X, this.FacilityZText.DisplayOffset.Y, 0, 0);
                 }
                 
             }
         }
         private Rectangle FacilitySTextDisplayPosition
         {
             get
             {
                 if (FacilityIng == true)
                 {
                     return new Rectangle(this.FacilitySText.DisplayOffset.X, this.FacilitySText.DisplayOffset.Y, this.FacilitySText.ClientWidth, this.FacilitySText.ClientHeight);
                 }
                 else
                 {
                     return new Rectangle(this.FacilitySText.DisplayOffset.X, this.FacilitySText.DisplayOffset.Y, 0, 0);
                 }

             }
         }
        
       //↓进度条大小
         private Rectangle ArmyBarDisplayPosition
         {
             get
             {
                 
                if (Switch12 == "1" && NewArchitectureButton == true)
                 {
                     if (this.ShowingArchitecture.MilitaryCount == 0 || this.ShowingArchitecture.ArmyQuantity == 0)
                     {
                         return new Rectangle(this.ArmyBarClient.X + this.DisplayOffset.X, this.ArmyBarClient.Y + this.DisplayOffset.Y, 0, this.ArmyBarClient.Height);

                     }
                    
                    return new Rectangle(this.ArmyBarClient.X + this.DisplayOffset.X, this.ArmyBarClient.Y + this.DisplayOffset.Y, this.ArmyBarClient.Width * this.ShowingArchitecture.MilitaryCount / this.ShowingArchitecture.ArmyQuantity, this.ArmyBarClient.Height);
                 }
                 return new Rectangle(this.ArmyBarClient.X + this.DisplayOffset.X, this.ArmyBarClient.Y + this.DisplayOffset.Y, 0, 0);
             }

         }
         private Rectangle DominationBarDisplayPosition
         {
             get
             {
                 if (Switch12 == "1" && NewArchitectureButton == true) 
                 {
                      if (this.ShowingArchitecture.Domination == 0 || this.ShowingArchitecture.DominationCeiling == 0)
                     {
                         return new Rectangle(this.DominationBarClient.X + this.DisplayOffset.X, this.DominationBarClient.Y + this.DisplayOffset.Y, 0, this.DominationBarClient.Height);

                     }
                      return new Rectangle(this.DominationBarClient.X + this.DisplayOffset.X, this.DominationBarClient.Y + this.DisplayOffset.Y, this.DominationBarClient.Width * this.ShowingArchitecture.Domination / this.ShowingArchitecture.DominationCeiling, this.DominationBarClient.Height);

                 }
                 return new Rectangle(this.DominationBarClient.X + this.DisplayOffset.X, this.DominationBarClient.Y + this.DisplayOffset.Y,0, 0);

             }
         }
         private Rectangle EnduranceBarDisplayPosition
         {
             get
             {
                 if (Switch12 == "1" && NewArchitectureButton == true ) 
                 {
                     if (this.ShowingArchitecture.Endurance == 0 || this.ShowingArchitecture.EnduranceCeiling == 0)
                     {
                         return new Rectangle(this.EnduranceBarClient.X + this.DisplayOffset.X, this.EnduranceBarClient.Y + this.DisplayOffset.Y, 0, this.EnduranceBarClient.Height);

                     }
                     return new Rectangle(this.EnduranceBarClient.X + this.DisplayOffset.X, this.EnduranceBarClient.Y + this.DisplayOffset.Y, this.EnduranceBarClient.Width * this.ShowingArchitecture.Endurance / this.ShowingArchitecture.EnduranceCeiling, this.EnduranceBarClient.Height);

                 }
                 return new Rectangle(this.EnduranceBarClient.X + this.DisplayOffset.X, this.EnduranceBarClient.Y + this.DisplayOffset.Y, 0, 0);

             }
         }
         private Rectangle AgricultureBarDisplayPosition
         {
             get
             {
                 if (Switch12 == "1" && NewArchitectureButton == true)
                 {
                     if (this.ShowingArchitecture.Agriculture == 0 || this.ShowingArchitecture.AgricultureCeiling == 0)
                     {
                         return new Rectangle(this.AgricultureBarClient.X + this.DisplayOffset.X, this.AgricultureBarClient.Y + this.DisplayOffset.Y, 0, this.AgricultureBarClient.Height);

                     }
                     return new Rectangle(this.AgricultureBarClient.X + this.DisplayOffset.X, this.AgricultureBarClient.Y + this.DisplayOffset.Y, this.AgricultureBarClient.Width * this.ShowingArchitecture.Agriculture / this.ShowingArchitecture.AgricultureCeiling, this.AgricultureBarClient.Height);

                 }
                 return new Rectangle(this.AgricultureBarClient.X + this.DisplayOffset.X, this.AgricultureBarClient.Y + this.DisplayOffset.Y, 0, 0);
             }
         }
         private Rectangle CommerceBarDisplayPosition
         {
             get
             {
                 if (Switch12 == "1" && NewArchitectureButton == true)
                 {
                     if (this.ShowingArchitecture.Commerce == 0 || this.ShowingArchitecture.CommerceCeiling == 0)
                     {
                         return new Rectangle(this.CommerceBarClient.X + this.DisplayOffset.X, this.CommerceBarClient.Y + this.DisplayOffset.Y, 0, this.CommerceBarClient.Height);

                     }
                     return new Rectangle(this.CommerceBarClient.X + this.DisplayOffset.X, this.CommerceBarClient.Y + this.DisplayOffset.Y, this.CommerceBarClient.Width * this.ShowingArchitecture.Commerce / this.ShowingArchitecture.CommerceCeiling, this.CommerceBarClient.Height);
                 }
                 return new Rectangle(this.CommerceBarClient.X + this.DisplayOffset.X, this.CommerceBarClient.Y + this.DisplayOffset.Y, 0, 0);

             }
         }
         private Rectangle TechnologyBarDisplayPosition
         {
             get
             {
                 if (Switch12 == "1" && NewArchitectureButton == true)
                 {
                     if (this.ShowingArchitecture.Technology == 0 || this.ShowingArchitecture.TechnologyCeiling == 0)
                     {
                         return new Rectangle(this.TechnologyBarClient.X + this.DisplayOffset.X, this.TechnologyBarClient.Y + this.DisplayOffset.Y, 0, this.TechnologyBarClient.Height);

                     }
                     return new Rectangle(this.TechnologyBarClient.X + this.DisplayOffset.X, this.TechnologyBarClient.Y + this.DisplayOffset.Y, this.TechnologyBarClient.Width * this.ShowingArchitecture.Technology / this.ShowingArchitecture.TechnologyCeiling, this.TechnologyBarClient.Height);
                 }
                 return new Rectangle(this.TechnologyBarClient.X + this.DisplayOffset.X, this.TechnologyBarClient.Y + this.DisplayOffset.Y, 0, 0);

             }
         }
         private Rectangle MoraleBarDisplayPosition
         {
             get
             {
                 if (Switch12 == "1" && NewArchitectureButton == true)
                 {
                     if (this.ShowingArchitecture.Morale == 0 || this.ShowingArchitecture.MoraleCeiling == 0)
                     {
                         return new Rectangle(this.MoraleBarClient.X + this.DisplayOffset.X, this.MoraleBarClient.Y + this.DisplayOffset.Y, 0, this.MoraleBarClient.Height);

                     }
                     return new Rectangle(this.MoraleBarClient.X + this.DisplayOffset.X, this.MoraleBarClient.Y + this.DisplayOffset.Y, this.MoraleBarClient.Width * this.ShowingArchitecture.Morale / this.ShowingArchitecture.MoraleCeiling, this.MoraleBarClient.Height);
                 }
                 return new Rectangle(this.MoraleBarClient.X + this.DisplayOffset.X, this.MoraleBarClient.Y + this.DisplayOffset.Y, 0, 0);

             }
         }
         private Rectangle FacilityCountBarDisplayPosition
         {
             get
             {
                 if (Switch12 == "1" && NewArchitectureButton == true)
                 {
                     if (this.ShowingArchitecture.FacilityPositionCount - this.ShowingArchitecture.FacilityPositionLeft == 0 || this.ShowingArchitecture.FacilityPositionCount == 0)
                     {
                         return new Rectangle(this.FacilityCountBarClient.X + this.DisplayOffset.X, this.FacilityCountBarClient.Y + this.DisplayOffset.Y, 0, this.FacilityCountBarClient.Height);
                     }
                     return new Rectangle(this.FacilityCountBarClient.X + this.DisplayOffset.X, this.FacilityCountBarClient.Y + this.DisplayOffset.Y, this.FacilityCountBarClient.Width * (this.ShowingArchitecture.FacilityPositionCount - this.ShowingArchitecture.FacilityPositionLeft) / this.ShowingArchitecture.FacilityPositionCount, this.FacilityCountBarClient.Height);
                 }
                 return new Rectangle(this.FacilityCountBarClient.X + this.DisplayOffset.X, this.FacilityCountBarClient.Y + this.DisplayOffset.Y, 0, 0);
        
             }
         }





        //↓建筑特色图片
         private Rectangle AC1DisplayPosition
         {
             get
             {
                 if (Switch11 == "1" && NewArchitectureButton == true)
                 {
                     return new Rectangle(this.AC1Client.X + this.DisplayOffset.X, this.AC1Client.Y + this.DisplayOffset.Y, this.AC1Client.Width, this.AC1Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.AC1Client.X + this.DisplayOffset.X, this.AC1Client.Y + this.DisplayOffset.Y, 0, 0);
                 }
             }
         }
         private Rectangle AC2DisplayPosition
         {
             get
             {
                 if (Switch11 == "1" && NewArchitectureButton == true)
                 {
                     return new Rectangle(this.AC2Client.X + this.DisplayOffset.X, this.AC2Client.Y + this.DisplayOffset.Y, this.AC2Client.Width, this.AC2Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.AC2Client.X + this.DisplayOffset.X, this.AC2Client.Y + this.DisplayOffset.Y, 0, 0);
                 }
             }
         }
         private Rectangle AC3DisplayPosition
         {
             get
             {
                 if (Switch11 == "1" && NewArchitectureButton == true)
                 {
                     return new Rectangle(this.AC3Client.X + this.DisplayOffset.X, this.AC3Client.Y + this.DisplayOffset.Y, this.AC3Client.Width, this.AC3Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.AC3Client.X + this.DisplayOffset.X, this.AC3Client.Y + this.DisplayOffset.Y, 0, 0);
                 }
             }
         }
         private Rectangle AC4DisplayPosition
         {
             get
             {
                 if (Switch11 == "1" && NewArchitectureButton == true)
                 {
                     return new Rectangle(this.AC4Client.X + this.DisplayOffset.X, this.AC4Client.Y + this.DisplayOffset.Y, this.AC4Client.Width, this.AC4Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.AC4Client.X + this.DisplayOffset.X, this.AC4Client.Y + this.DisplayOffset.Y, 0, 0);
                 }
             }
         }
         private Rectangle AC5DisplayPosition
         {
             get
             {
                 if (Switch11 == "1" && NewArchitectureButton == true)
                 {
                     return new Rectangle(this.AC5Client.X + this.DisplayOffset.X, this.AC5Client.Y + this.DisplayOffset.Y, this.AC5Client.Width, this.AC5Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.AC5Client.X + this.DisplayOffset.X, this.AC5Client.Y + this.DisplayOffset.Y, 0, 0);
                 }
             }
         }
         private Rectangle AC6DisplayPosition
         {
             get
             {
                 if (Switch11 == "1" && NewArchitectureButton == true)
                 {
                     return new Rectangle(this.AC6Client.X + this.DisplayOffset.X, this.AC6Client.Y + this.DisplayOffset.Y, this.AC6Client.Width, this.AC6Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.AC6Client.X + this.DisplayOffset.X, this.AC6Client.Y + this.DisplayOffset.Y, 0, 0);
                 }
             }
         }
         private Rectangle AC7DisplayPosition
         {
             get
             {
                 if (Switch11 == "1" && NewArchitectureButton == true)
                 {
                     return new Rectangle(this.AC7Client.X + this.DisplayOffset.X, this.AC7Client.Y + this.DisplayOffset.Y, this.AC7Client.Width, this.AC7Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.AC7Client.X + this.DisplayOffset.X, this.AC7Client.Y + this.DisplayOffset.Y, 0, 0);
                 }
             }
         }
         private Rectangle AC8DisplayPosition
         {
             get
             {
                 if (Switch11 == "1" && NewArchitectureButton == true)
                 {
                     return new Rectangle(this.AC8Client.X + this.DisplayOffset.X, this.AC8Client.Y + this.DisplayOffset.Y, this.AC8Client.Width, this.AC8Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.AC8Client.X + this.DisplayOffset.X, this.AC8Client.Y + this.DisplayOffset.Y, 0, 0);
                 }
             }
         }
         private Rectangle AC9DisplayPosition
         {
             get
             {
                 if (Switch11 == "1" && NewArchitectureButton == true)
                 {
                     return new Rectangle(this.AC9Client.X + this.DisplayOffset.X, this.AC9Client.Y + this.DisplayOffset.Y, this.AC9Client.Width, this.AC9Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.AC9Client.X + this.DisplayOffset.X, this.AC9Client.Y + this.DisplayOffset.Y, 0, 0);
                 }
             }
         }
         private Rectangle AC10DisplayPosition
         {
             get
             {
                 if (Switch11 == "1" && NewArchitectureButton == true)
                 {
                     return new Rectangle(this.AC10Client.X + this.DisplayOffset.X, this.AC10Client.Y + this.DisplayOffset.Y, this.AC10Client.Width, this.AC10Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.AC10Client.X + this.DisplayOffset.X, this.AC10Client.Y + this.DisplayOffset.Y, 0, 0);
                 }
             }
         }
         private Rectangle AC11DisplayPosition
         {
             get
             {
                 if (Switch11 == "1" && NewArchitectureButton == true)
                 {
                     return new Rectangle(this.AC11Client.X + this.DisplayOffset.X, this.AC11Client.Y + this.DisplayOffset.Y, this.AC11Client.Width, this.AC11Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.AC11Client.X + this.DisplayOffset.X, this.AC11Client.Y + this.DisplayOffset.Y, 0, 0);
                 }
             }
         }
         private Rectangle AC12DisplayPosition
         {
             get
             {
                 if (Switch11 == "1" && NewArchitectureButton == true)
                 {
                     return new Rectangle(this.AC12Client.X + this.DisplayOffset.X, this.AC12Client.Y + this.DisplayOffset.Y, this.AC12Client.Width, this.AC12Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.AC12Client.X + this.DisplayOffset.X, this.AC12Client.Y + this.DisplayOffset.Y, 0, 0);
                 }
             }
         }
         private Rectangle AC13DisplayPosition
         {
             get
             {
                 if (Switch11 == "1" && NewArchitectureButton == true)
                 {
                     return new Rectangle(this.AC13Client.X + this.DisplayOffset.X, this.AC13Client.Y + this.DisplayOffset.Y, this.AC13Client.Width, this.AC13Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.AC13Client.X + this.DisplayOffset.X, this.AC13Client.Y + this.DisplayOffset.Y, 0, 0);
                 }
             }
         }
         private Rectangle AC14DisplayPosition
         {
             get
             {
                 if (Switch11 == "1" && NewArchitectureButton == true)
                 {
                     return new Rectangle(this.AC14Client.X + this.DisplayOffset.X, this.AC14Client.Y + this.DisplayOffset.Y, this.AC14Client.Width, this.AC14Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.AC14Client.X + this.DisplayOffset.X, this.AC14Client.Y + this.DisplayOffset.Y, 0, 0);
                 }
             }
         }
         private Rectangle AC15DisplayPosition
         {
             get
             {
                 if (Switch11 == "1" && NewArchitectureButton == true)
                 {
                     return new Rectangle(this.AC15Client.X + this.DisplayOffset.X, this.AC15Client.Y + this.DisplayOffset.Y, this.AC15Client.Width, this.AC15Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.AC15Client.X + this.DisplayOffset.X, this.AC15Client.Y + this.DisplayOffset.Y, 0, 0);
                 }
             }
         }
         private Rectangle AC16DisplayPosition
         {
             get
             {
                 if (Switch11 == "1" && NewArchitectureButton == true)
                 {
                     return new Rectangle(this.AC16Client.X + this.DisplayOffset.X, this.AC16Client.Y + this.DisplayOffset.Y, this.AC16Client.Width, this.AC16Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.AC16Client.X + this.DisplayOffset.X, this.AC16Client.Y + this.DisplayOffset.Y, 0, 0);
                 }
             }
         }
         private Rectangle AC17DisplayPosition
         {
             get
             {
                 if (Switch11 == "1" && NewArchitectureButton == true)
                 {
                     return new Rectangle(this.AC17Client.X + this.DisplayOffset.X, this.AC17Client.Y + this.DisplayOffset.Y, this.AC17Client.Width, this.AC17Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.AC17Client.X + this.DisplayOffset.X, this.AC17Client.Y + this.DisplayOffset.Y, 0, 0);
                 }
             }
         }
         private Rectangle AC18DisplayPosition
         {
             get
             {
                 if (Switch11 == "1" && NewArchitectureButton == true)
                 {
                     return new Rectangle(this.AC18Client.X + this.DisplayOffset.X, this.AC18Client.Y + this.DisplayOffset.Y, this.AC18Client.Width, this.AC18Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.AC18Client.X + this.DisplayOffset.X, this.AC18Client.Y + this.DisplayOffset.Y, 0, 0);
                 }
             }
         }
         private Rectangle AC19DisplayPosition
         {
             get
             {
                 if (Switch11 == "1" && NewArchitectureButton == true)
                 {
                     return new Rectangle(this.AC19Client.X + this.DisplayOffset.X, this.AC19Client.Y + this.DisplayOffset.Y, this.AC19Client.Width, this.AC19Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.AC19Client.X + this.DisplayOffset.X, this.AC19Client.Y + this.DisplayOffset.Y, 0, 0);
                 }
             }
         }
         private Rectangle AC20DisplayPosition
         {
             get
             {
                 if (Switch11 == "1" && NewArchitectureButton == true)
                 {
                     return new Rectangle(this.AC20Client.X + this.DisplayOffset.X, this.AC20Client.Y + this.DisplayOffset.Y, this.AC20Client.Width, this.AC20Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.AC20Client.X + this.DisplayOffset.X, this.AC20Client.Y + this.DisplayOffset.Y, 0, 0);
                 }
             }
         }
         private Rectangle AC21DisplayPosition
         {
             get
             {
                 if (Switch11 == "1" && NewArchitectureButton == true)
                 {
                     return new Rectangle(this.AC21Client.X + this.DisplayOffset.X, this.AC21Client.Y + this.DisplayOffset.Y, this.AC21Client.Width, this.AC21Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.AC21Client.X + this.DisplayOffset.X, this.AC21Client.Y + this.DisplayOffset.Y, 0, 0);
                 }
             }
         }
         private Rectangle AC22DisplayPosition
         {
             get
             {
                 if (Switch11 == "1" && NewArchitectureButton == true)
                 {
                     return new Rectangle(this.AC22Client.X + this.DisplayOffset.X, this.AC22Client.Y + this.DisplayOffset.Y, this.AC22Client.Width, this.AC22Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.AC22Client.X + this.DisplayOffset.X, this.AC22Client.Y + this.DisplayOffset.Y, 0, 0);
                 }
             }
         }
         private Rectangle AC23DisplayPosition
         {
             get
             {
                 if (Switch11 == "1" && NewArchitectureButton == true)
                 {
                     return new Rectangle(this.AC23Client.X + this.DisplayOffset.X, this.AC23Client.Y + this.DisplayOffset.Y, this.AC23Client.Width, this.AC23Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.AC23Client.X + this.DisplayOffset.X, this.AC23Client.Y + this.DisplayOffset.Y, 0, 0);
                 }
             }
         }
         private Rectangle AC24DisplayPosition
         {
             get
             {
                 if (Switch11 == "1" && NewArchitectureButton == true)
                 {
                     return new Rectangle(this.AC24Client.X + this.DisplayOffset.X, this.AC24Client.Y + this.DisplayOffset.Y, this.AC24Client.Width, this.AC24Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.AC24Client.X + this.DisplayOffset.X, this.AC24Client.Y + this.DisplayOffset.Y, 0, 0);
                 }
             }
         }
         private Rectangle AC25DisplayPosition
         {
             get
             {
                 if (Switch11 == "1" && NewArchitectureButton == true)
                 {
                     return new Rectangle(this.AC25Client.X + this.DisplayOffset.X, this.AC25Client.Y + this.DisplayOffset.Y, this.AC25Client.Width, this.AC25Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.AC25Client.X + this.DisplayOffset.X, this.AC25Client.Y + this.DisplayOffset.Y, 0, 0);
                 }
             }
         }
         private Rectangle AC26DisplayPosition
         {
             get
             {
                 if (Switch11 == "1" && NewArchitectureButton == true)
                 {
                     return new Rectangle(this.AC26Client.X + this.DisplayOffset.X, this.AC26Client.Y + this.DisplayOffset.Y, this.AC26Client.Width, this.AC26Client.Height);
                 }
                 else
                 {
                     return new Rectangle(this.AC26Client.X + this.DisplayOffset.X, this.AC26Client.Y + this.DisplayOffset.Y, 0, 0);
                 }
             }
         }


      //↑增加的内容
       
        
        
        
        
        private Rectangle CharacteristicDisplayPosition
        {
            get
            {
               
                    return new Rectangle(this.CharacteristicText.DisplayOffset.X, this.CharacteristicText.DisplayOffset.Y, this.CharacteristicText.ClientWidth, this.CharacteristicText.ClientHeight);
                
            }

        }

        private Rectangle FacilityDisplayPosition
        {
            get
            {
                
                    return new Rectangle(this.FacilityText.DisplayOffset.X, this.FacilityText.DisplayOffset.Y, this.FacilityText.ClientWidth, this.FacilityText.ClientHeight);
                
            }
        }

        public bool IsShowing
        {
            get
            {
                return this.isShowing;
            }
            set
            {
                this.isShowing = value;
                if (value)
                {
                    this.screen.PushUndoneWork(new UndoneWorkItem(UndoneWorkKind.SubDialog, DialogKind.ArchitectureDetail));
                    this.screen.OnMouseMove += new Screen.MouseMove(this.screen_OnMouseMove);
                    this.screen.OnMouseLeftDown += new Screen.MouseLeftDown(this.screen_OnMouseLeftDown);
                    this.screen.OnMouseRightUp += new Screen.MouseRightUp(this.screen_OnMouseRightUp);
                }
                else
                {
                    if (this.screen.PopUndoneWork().Kind != UndoneWorkKind.SubDialog)
                    {
                        throw new Exception("The UndoneWork is not a SubDialog.");
                    }
                    this.screen.OnMouseMove -= new Screen.MouseMove(this.screen_OnMouseMove);
                    this.screen.OnMouseLeftDown -= new Screen.MouseLeftDown(this.screen_OnMouseLeftDown);
                    this.screen.OnMouseRightUp -= new Screen.MouseRightUp(this.screen_OnMouseRightUp);
                    this.CharacteristicText.Clear();
                    this.FacilityText.Clear();
                    this.FacilityAText.Clear();
                    this.FacilityBText.Clear();
                    this.FacilityCText.Clear();
                    this.FacilityDText.Clear();
                    this.FacilityEText.Clear();
                    this.FacilityZText.Clear();
                    this.FacilitySText.Clear();
                }
            }
        }
    }
}

