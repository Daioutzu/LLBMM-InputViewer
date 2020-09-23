using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace InputViewer
{
    public static class IVStyle
    {

        readonly static string resourceFolder = Application.dataPath + "/Managed/InputViewerResources";
        readonly static string UiFolder = "assets/ui/texture2D/";

        public static AssetBundle uiBundle;
        public static Font inputViewerFont;
        public static Dictionary<string, Texture2D> uiAssets = new Dictionary<string, Texture2D>();
        public static Texture2D viewerBG;

        static void LoadAssets()
        {
            uiBundle = AssetBundle.LoadFromFile(resourceFolder + "/Bundles/UI");
            foreach (var assetPathAndName in uiBundle.GetAllAssetNames())
            {
                var name = Path.GetFileNameWithoutExtension(assetPathAndName);
                var nameExt = Path.GetFileName(assetPathAndName);
                uiAssets.Add(name, uiBundle.LoadAsset<Texture2D>(UiFolder + nameExt));
            }
            inputViewerFont = uiBundle.LoadAsset<Font>("assets/ui/elements.ttf");
        }

        public static void ATInit()
        {
            LoadAssets();
        }

        public static GUIStyle InputViewerBG
        {
            get
            {
                GUIStyleState bg = new GUIStyleState();
                switch (InputViewer.Instance.BackgroundTransparency)
                {
                    case 5:
                        bg.background = uiAssets["viewerbg_50"]; break;
                    case 4:
                        bg.background = uiAssets["viewerbg_60"]; break;
                    case 3:
                        bg.background = uiAssets["viewerbg_70"]; break;
                    case 2:
                        bg.background = uiAssets["viewerbg_80"]; break;
                    case 1:
                        bg.background = uiAssets["viewerbg_90"]; break;
                    default:
                        bg.background = uiAssets["viewerbg"]; break;
                }
                bg.textColor = Color.white;

                GUIStyle gUIStyle = new GUIStyle()
                {
                    font = inputViewerFont,
                    padding = new RectOffset(4, 4, 4, 4),
                    normal = bg,
                    onNormal = bg,
                    hover = bg,
                    onHover = bg,
                    active = bg,
                    onActive = bg,
                };
                return gUIStyle;
            }
        }

        static readonly int combatKeySize = 30;
        static readonly RectOffset btnMargin = new RectOffset(-1, -1, -1, -1);

        public static GUIStyle CombatBtnStyle
        {
            get
            {
                GUIStyle gUIStyle = new GUIStyle(GUI.skin.label)
                {
                    fontSize = 20,
                    alignment = TextAnchor.MiddleCenter,
                    fontStyle = FontStyle.Bold,
                    padding = new RectOffset(4, 4, 4, 4),
                    margin = btnMargin,
                    fixedHeight = combatKeySize,
                    fixedWidth = combatKeySize,
                };
                return gUIStyle;
            }
        }

        public static GUIStyle SwingStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState
                {
                    background = uiAssets["swingoff"],
                    textColor = Color.black
                };

                GUIStyleState on = new GUIStyleState
                {
                    background = uiAssets["swingon"],
                    textColor = Color.black
                };

                GUIStyle gUIStyle = new GUIStyle(CombatBtnStyle)
                {
                    normal = off,
                    hover = off,
                    active = off,
                    onNormal = on,
                    onHover = on,
                    onActive = on,
                };
                return gUIStyle;
            }
        }

        public static GUIStyle BuntStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState
                {
                    background = uiAssets["buntoff"],
                    textColor = Color.black
                };

                GUIStyleState on = new GUIStyleState
                {
                    background = uiAssets["bunton"],
                    textColor = Color.black
                };

                GUIStyle gUIStyle = new GUIStyle(CombatBtnStyle)
                {
                    normal = off,
                    hover = off,
                    active = off,
                    onNormal = on,
                    onHover = on,
                    onActive = on,
                };
                return gUIStyle;
            }
        }
        public static GUIStyle GrabStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState
                {
                    background = uiAssets["graboff"],
                    textColor = Color.black
                };

                GUIStyleState on = new GUIStyleState
                {
                    background = uiAssets["grabon"],
                    textColor = Color.black
                };

                GUIStyle gUIStyle = new GUIStyle(CombatBtnStyle)
                {
                    normal = off,
                    hover = off,
                    active = off,
                    onNormal = on,
                    onHover = on,
                    onActive = on,
                };
                return gUIStyle;
            }
        }
        public static GUIStyle TauntStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState
                {
                    background = uiAssets["tauntoff"],
                    textColor = Color.black
                };

                GUIStyleState on = new GUIStyleState
                {
                    background = uiAssets["taunton"],
                    textColor = Color.black
                };

                GUIStyle gUIStyle = new GUIStyle(CombatBtnStyle)
                {
                    normal = off,
                    hover = off,
                    active = off,
                    onNormal = on,
                    onHover = on,
                    onActive = on,
                };
                return gUIStyle;
            }
        }
        public static GUIStyle JumpStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState
                {
                    background = uiAssets["jumpoff"],
                    textColor = Color.black
                };

                GUIStyleState on = new GUIStyleState
                {
                    background = uiAssets["jumpon"],
                    textColor = Color.black
                };

                GUIStyle gUIStyle = new GUIStyle(CombatBtnStyle)
                {
                    normal = off,
                    hover = off,
                    active = off,
                    onNormal = on,
                    onHover = on,
                    onActive = on,
                };
                return gUIStyle;
            }
        }
        public static GUIStyle DirUpStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState
                {
                    background = uiAssets["arrowuoff"],
                    textColor = Color.black
                };

                GUIStyleState on = new GUIStyleState
                {
                    background = uiAssets["arrowuon"],
                    textColor = Color.white
                };

                GUIStyle gUIStyle = new GUIStyle(CombatBtnStyle)
                {
                    normal = off,
                    hover = off,
                    active = off,
                    onNormal = on,
                    onHover = on,
                    onActive = on,
                };
                return gUIStyle;
            }
        }

        public static GUIStyle DirDwnStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState
                {
                    background = uiAssets["arrowdoff"],
                    textColor = Color.black
                };

                GUIStyleState on = new GUIStyleState
                {
                    background = uiAssets["arrowdon"],
                    textColor = Color.white
                };

                GUIStyle gUIStyle = new GUIStyle(CombatBtnStyle)
                {
                    normal = off,
                    hover = off,
                    active = off,
                    onNormal = on,
                    onHover = on,
                    onActive = on,
                };
                return gUIStyle;
            }
        }
        public static GUIStyle DirLefStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState
                {
                    background = uiAssets["arrowloff"],
                    textColor = Color.black
                };

                GUIStyleState on = new GUIStyleState
                {
                    background = uiAssets["arrowlon"],
                    textColor = Color.white
                };

                GUIStyle gUIStyle = new GUIStyle(CombatBtnStyle)
                {
                    normal = off,
                    hover = off,
                    active = off,
                    onNormal = on,
                    onHover = on,
                    onActive = on,
                };
                return gUIStyle;
            }
        }
        public static GUIStyle DirRigStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState
                {
                    background = uiAssets["arrowroff"],
                    textColor = Color.black
                };

                GUIStyleState on = new GUIStyleState
                {
                    background = uiAssets["arrowron"],
                    textColor = Color.white
                };

                GUIStyle gUIStyle = new GUIStyle(CombatBtnStyle)
                {
                    normal = off,
                    hover = off,
                    active = off,
                    onNormal = on,
                    onHover = on,
                    onActive = on,
                };
                return gUIStyle;
            }
        }
        public static GUIStyle ExpressStyle
        {
            get
            {
                GUIStyle gUIStyle = new GUIStyle(GUI.skin.label)
                {
                    fontSize = 14,
                    alignment = TextAnchor.MiddleCenter,
                    fontStyle = FontStyle.Bold,
                    padding = new RectOffset(0, 0, 0, 0),
                    margin = new RectOffset(0, 0, 0, 0),
                    fixedWidth = 68,
                    fixedHeight = 34,
                };
                return gUIStyle;
            }
        }

        public static GUIStyle ExpNiceStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState
                {
                    background = uiAssets["niceoff"],
                    textColor = Color.white
                };

                GUIStyleState on = new GUIStyleState
                {
                    background = uiAssets["niceon"],
                    textColor = Color.white
                };

                GUIStyle gUIStyle = new GUIStyle(ExpressStyle)
                {
                    normal = off,
                    hover = off,
                    active = off,
                    onNormal = on,
                    onHover = on,
                    onActive = on,
                };
                return gUIStyle;
            }
        }

        public static GUIStyle ExpOopsStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState
                {
                    background = uiAssets["oopsoff"],
                    textColor = Color.white
                };

                GUIStyleState on = new GUIStyleState
                {
                    background = uiAssets["oopson"],
                    textColor = Color.white
                };

                GUIStyle gUIStyle = new GUIStyle(ExpressStyle)
                {
                    normal = off,
                    hover = off,
                    active = off,
                    onNormal = on,
                    onHover = on,
                    onActive = on,
                };
                return gUIStyle;
            }
        }
        public static GUIStyle ExpWowStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState
                {
                    background = uiAssets["wowoff"],
                    textColor = Color.white
                };

                GUIStyleState on = new GUIStyleState
                {
                    background = uiAssets["wowon"],
                    textColor = Color.white
                };

                GUIStyle gUIStyle = new GUIStyle(ExpressStyle)
                {
                    normal = off,
                    hover = off,
                    active = off,
                    onNormal = on,
                    onHover = on,
                    onActive = on,
                };
                return gUIStyle;
            }
        }

        public static GUIStyle ExpBringItStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState
                {
                    background = uiAssets["bringitoff"],
                    textColor = Color.white
                };

                GUIStyleState on = new GUIStyleState
                {
                    background = uiAssets["bringiton"],
                    textColor = Color.white
                };

                GUIStyle gUIStyle = new GUIStyle(ExpressStyle)
                {
                    normal = off,
                    hover = off,
                    active = off,
                    onNormal = on,
                    onHover = on,
                    onActive = on,
                };
                return gUIStyle;
            }
        }

    }
}
