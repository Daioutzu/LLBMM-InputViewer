using LLHandlers;
using LLScreen;
using UnityEngine;

namespace InputViewer
{
    class InputViewer : MonoBehaviour
    {

        private const string modVersion = "1.0a";
        private const string repositoryOwner = "Daioutzu";
        private const string repositoryName = "LLBMM-InputViewer";

        public static InputViewer Instance { get; private set; } = null;
        public static ModMenuIntegration MMI = null;
        private bool modIntegrated;
        public static void Initialize()
        {
            GameObject gameObject = new GameObject("InputViewer"); //The game object is what we use to interact with our mod
            Instance = gameObject.AddComponent<InputViewer>();
            DontDestroyOnLoad(gameObject); // Makes sure our game object isn't destroyed
            IVStyle.ATInit();
        }

        private void Start()
        {
            if (MMI == null) { MMI = gameObject.AddComponent<ModMenuIntegration>(); Debug.Log("[LLBMM] InputViewer: Added GameObject \"ModMenuIntegration\""); }
            Debug.Log("[LLBMM] InputViewer Started");
        }

        private void OnDestroy()
        {
            Debug.Log("[LLBMM] InputViewer Destroyed");
        }

        bool InGame => World.instance != null && (GetCurrentGameState() == JOFJHDJHJGI.CDOFDJMLGLO || GetCurrentGameState() == JOFJHDJHJGI.LGILIJKMKOD) && !UIScreen.loadingScreenActive;
        float selectViewingMode = 4;
        bool showInLobby = false;

        private void ModMenuInit()
        {
            if ((MMI != null && !modIntegrated) || LLModMenu.ModMenu.Instance.currentOpenMod == "InputViewer")
            {
                selectViewingMode = MMI.GetSliderValue("(slider)selectViewingMode");
                showInLobby = MMI.GetTrueFalse(MMI.configBools["(bool)showInLobby"]);
                if (!modIntegrated) { Debug.Log("[LLBMM] InputViewer: ModMenuIntegration Done"); };
                modIntegrated = true;
            }
        }
        void Update()
        {
            ModMenuInit();
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Cursor.visible = !Cursor.visible;
            }
        }

        Rect inputRect = new Rect(30, Screen.height - 147, 300, 117);

        void OnGUI()
        {
            if (ViewingMode((ViewMode)selectViewingMode))
            {
                inputRect = GUI.Window(102289, inputRect, InputWindow, "", IVStyle.inputViewerBG);
            }
        }

        JOFJHDJHJGI GetCurrentGameState()
        {
            return DNPFJHMAIBP.HHMOGKIMBNM();
        }

        GameMode GetCurrentGameMode()
        {
            return JOMBNFKIHIC.GIGAKBJGFDI.PNJOKAICMNN;
        }

        bool isOnline()
        {
            return JOMBNFKIHIC.GDNFJCCCKDM;
        }

        enum ViewMode
        {
            Off,
            Training,
            local,
            Online,
            All,
        }

        enum GameState
        {
            LOBBY_STORY = 23,
            LOBBY_TUTORIAL = 12,
            LOBBY_TRAINING = 11,
            LOBBY_CHALLENGE = 6,
            LOBBY_LOCAL = 4,
            GAME = 19,
            GAME_PAUSE = 20,
            LOBBY_ONLINE = 5,
        }

        bool LocalLobby()
        {
            if (!showInLobby) return false;

            switch (GetCurrentGameState())
            {
                case (JOFJHDJHJGI)GameState.LOBBY_LOCAL:
                case (JOFJHDJHJGI)GameState.LOBBY_TRAINING:
                case (JOFJHDJHJGI)GameState.LOBBY_CHALLENGE:
                case (JOFJHDJHJGI)GameState.LOBBY_TUTORIAL:
                case (JOFJHDJHJGI)GameState.LOBBY_STORY:
                    return true;
                default:
                    return false;
            }
        }

        bool OnlineLobby()
        {
            if (!showInLobby) return false;

            switch (GetCurrentGameState())
            {
                case (JOFJHDJHJGI)GameState.LOBBY_ONLINE:
                    return true;
                default:
                    return false;
            }
        }

        bool ViewingMode(ViewMode selectedView)
        {
            switch (selectedView)
            {
                case ViewMode.Off:
                    return false;
                case ViewMode.Training:
                    return GetCurrentGameMode() == GameMode.TRAINING && (InGame || (showInLobby && GetCurrentGameState() == (JOFJHDJHJGI)GameState.LOBBY_TRAINING));
                case ViewMode.local:
                    return !isOnline() && (InGame || LocalLobby());
                case ViewMode.Online:
                    return isOnline() && (InGame || OnlineLobby());
                case ViewMode.All:
                    return InGame || LocalLobby() || OnlineLobby();
                default:
                    return false;
            }
        }

        void InputWindow(int wId)
        {
            int index = 0;
            for (int i = 0; i < 4; i++)
            {
                if (ALDOKEMAOMB.BJDPHEHJJJK(i).GAFCIHKIGNM && ALDOKEMAOMB.BJDPHEHJJJK(i).NGLDMOLLPLK)
                {
                    index = i;
                    i = 4;
                }
            };
            ALDOKEMAOMB player = ALDOKEMAOMB.BJDPHEHJJJK(index);

            GUIStyle headerStyle = new GUIStyle(GUI.skin.label)
            {
                font = IVStyle.inputViewerFont,
                fontSize = 20,
                alignment = TextAnchor.MiddleLeft,
                margin = new RectOffset(10, 0, 3, 14),
                wordWrap = false,
            };

            GUIStyle border = new GUIStyle()
            {
                padding = new RectOffset(4, 4, 0, 0),
            };

            GUIStyle expressBorder = new GUIStyle()
            {
                padding = new RectOffset(8, 8, 8, 8),
                fixedWidth = 150,
            };

            GUI.DragWindow();
            GUILayout.BeginArea(new Rect(0, 0, inputRect.width, inputRect.height));
            GUILayout.BeginHorizontal(border);

            GUILayout.BeginVertical();
            GUILayout.Label("Input Viewer", headerStyle);
            GUILayout.BeginHorizontal();

            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();
            GUILayout.Toggle(InputHandler.currentInput[player.CJFLMDNNMIE, InputAction.ActionToIndex(InputAction.JUMP)] == 100 ? true : false, "", IVStyle.jumpStyle);
            GUILayout.Toggle(InputHandler.currentInput[player.CJFLMDNNMIE, InputAction.ActionToIndex(InputAction.UP)] == 100 ? true : false, "", IVStyle.dirUpStyle);
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Toggle(InputHandler.currentInput[player.CJFLMDNNMIE, InputAction.ActionToIndex(InputAction.LEFT)] == 100 ? true : false, "", IVStyle.dirLefStyle);
            GUILayout.Toggle(InputHandler.currentInput[player.CJFLMDNNMIE, InputAction.ActionToIndex(InputAction.DOWN)] == 100 ? true : false, "", IVStyle.dirDwnStyle);
            GUILayout.Toggle(InputHandler.currentInput[player.CJFLMDNNMIE, InputAction.ActionToIndex(InputAction.RIGHT)] == 100 ? true : false, "", IVStyle.dirRigStyle);
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();

            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();
            GUILayout.Toggle(InputHandler.currentInput[player.CJFLMDNNMIE, InputAction.ActionToIndex(InputAction.SWING)] == 100 ? true : false, "", IVStyle.swingStyle); //Swing Button
            GUILayout.Toggle(InputHandler.currentInput[player.CJFLMDNNMIE, InputAction.ActionToIndex(InputAction.BUNT)] == 100 ? true : false, "", IVStyle.buntStyle); //Bunt Button
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Toggle(InputHandler.currentInput[player.CJFLMDNNMIE, InputAction.ActionToIndex(InputAction.GRAB)] == 100 ? true : false, "", IVStyle.grabStyle); //Grab Button
            GUILayout.Toggle(InputHandler.currentInput[player.CJFLMDNNMIE, InputAction.ActionToIndex(InputAction.TAUNT)] == 100 ? true : false, "", IVStyle.tauntStyle); //Taunt Button
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();

            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
            GUILayout.FlexibleSpace();

            GUILayout.BeginVertical(expressBorder);
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Toggle(InputHandler.currentInput[player.CJFLMDNNMIE, InputAction.ActionToIndex(InputAction.EXPRESS_UP)] == 100 ? true : false, "", IVStyle.expNiceStyle);
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Toggle(InputHandler.currentInput[player.CJFLMDNNMIE, InputAction.ActionToIndex(InputAction.EXPRESS_LEFT)] == 100 ? true : false, "", IVStyle.expOopsStyle);
            GUILayout.Toggle(InputHandler.currentInput[player.CJFLMDNNMIE, InputAction.ActionToIndex(InputAction.EXPRESS_RIGHT)] == 100 ? true : false, "", IVStyle.expWowStyle);
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Toggle(InputHandler.currentInput[player.CJFLMDNNMIE, InputAction.ActionToIndex(InputAction.EXPRESS_DOWN)] == 100 ? true : false, "", IVStyle.expBringItStyle);
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.EndVertical();

            GUILayout.EndHorizontal();
            GUILayout.EndArea();
        }

    }
}
