using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace InputViewer
{
    public static class IVStyle
    {

        private static string resourceFolder = Application.dataPath + "/Managed/InputViewerResources";
        private static string UiFolder = "assets/ui/texture2D/";

        public static AssetBundle uiBundle;
        public static Font inputViewerFont;
        public static Dictionary<string, Texture2D> uiAssets = new Dictionary<string, Texture2D>();

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

        public static GUIStyle inputViewerBG
        {
            get
            {
                GUIStyleState bg = new GUIStyleState();
                bg.background = uiAssets["viewerbg"];
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

        static int combatKeySize = 30;
        static RectOffset btnMargin = new RectOffset(-1, -1, -1, -1);

        public static GUIStyle combatBtnStyle
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

        public static GUIStyle swingStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState();
                off.background = uiAssets["swingoff"];
                off.textColor = Color.black;

                GUIStyleState on = new GUIStyleState();
                on.background = uiAssets["swingon"];
                on.textColor = Color.black;

                GUIStyle gUIStyle = new GUIStyle(combatBtnStyle)
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

        public static GUIStyle buntStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState();
                off.background = uiAssets["buntoff"];
                off.textColor = Color.black;

                GUIStyleState on = new GUIStyleState();
                on.background = uiAssets["bunton"];
                on.textColor = Color.black;

                GUIStyle gUIStyle = new GUIStyle(combatBtnStyle)
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
        public static GUIStyle grabStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState();
                off.background = uiAssets["graboff"];
                off.textColor = Color.black;

                GUIStyleState on = new GUIStyleState();
                on.background = uiAssets["grabon"];
                on.textColor = Color.black;

                GUIStyle gUIStyle = new GUIStyle(combatBtnStyle)
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
        public static GUIStyle tauntStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState();
                off.background = uiAssets["tauntoff"];
                off.textColor = Color.black;

                GUIStyleState on = new GUIStyleState();
                on.background = uiAssets["taunton"];
                on.textColor = Color.black;

                GUIStyle gUIStyle = new GUIStyle(combatBtnStyle)
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
        public static GUIStyle jumpStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState();
                off.background = uiAssets["jumpoff"];
                off.textColor = Color.black;

                GUIStyleState on = new GUIStyleState();
                on.background = uiAssets["jumpon"];
                on.textColor = Color.black;

                GUIStyle gUIStyle = new GUIStyle(combatBtnStyle)
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
        public static GUIStyle dirUpStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState();
                off.background = uiAssets["arrowuoff"];
                off.textColor = Color.black;

                GUIStyleState on = new GUIStyleState();
                on.background = uiAssets["arrowuon"];
                on.textColor = Color.white;

                GUIStyle gUIStyle = new GUIStyle(combatBtnStyle)
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

        public static GUIStyle dirDwnStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState();
                off.background = uiAssets["arrowdoff"];
                off.textColor = Color.black;

                GUIStyleState on = new GUIStyleState();
                on.background = uiAssets["arrowdon"];
                on.textColor = Color.white;

                GUIStyle gUIStyle = new GUIStyle(combatBtnStyle)
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
        public static GUIStyle dirLefStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState();
                off.background = uiAssets["arrowloff"];
                off.textColor = Color.black;

                GUIStyleState on = new GUIStyleState();
                on.background = uiAssets["arrowlon"];
                on.textColor = Color.white;

                GUIStyle gUIStyle = new GUIStyle(combatBtnStyle)
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
        public static GUIStyle dirRigStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState();
                off.background = uiAssets["arrowroff"];
                off.textColor = Color.black;

                GUIStyleState on = new GUIStyleState();
                on.background = uiAssets["arrowron"];
                on.textColor = Color.white;

                GUIStyle gUIStyle = new GUIStyle(combatBtnStyle)
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
        public static GUIStyle expressStyle
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

        public static GUIStyle expNiceStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState();
                off.background = uiAssets["niceoff"];
                off.textColor = Color.white;

                GUIStyleState on = new GUIStyleState();
                on.background = uiAssets["niceon"];
                on.textColor = Color.white;

                GUIStyle gUIStyle = new GUIStyle(expressStyle)
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

        public static GUIStyle expOopsStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState();
                off.background = uiAssets["oopsoff"];
                off.textColor = Color.white;

                GUIStyleState on = new GUIStyleState();
                on.background = uiAssets["oopson"];
                on.textColor = Color.white;

                GUIStyle gUIStyle = new GUIStyle(expressStyle)
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
        public static GUIStyle expWowStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState();
                off.background = uiAssets["wowoff"];
                off.textColor = Color.white;

                GUIStyleState on = new GUIStyleState();
                on.background = uiAssets["wowon"];
                on.textColor = Color.white;

                GUIStyle gUIStyle = new GUIStyle(expressStyle)
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

        public static GUIStyle expBringItStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState();
                off.background = uiAssets["bringitoff"];
                off.textColor = Color.white;

                GUIStyleState on = new GUIStyleState();
                on.background = uiAssets["bringiton"];
                on.textColor = Color.white;

                GUIStyle gUIStyle = new GUIStyle(expressStyle)
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
