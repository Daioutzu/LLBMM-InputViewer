using System.IO;
using UnityEngine;

namespace InputViewer
{

    static class SaveSystem
    {
        //static readonly string SAVE_FOLDER = Application.dataPath + @"/Saves/";
        static readonly string SAVE_FOLDER = Path.GetDirectoryName(Application.dataPath) + @"\ModSettings\";

        public static void Init()
        {
            if (!Directory.Exists(SAVE_FOLDER))
            {
                Directory.CreateDirectory(SAVE_FOLDER);
            }
        }

        public static void Save(string saveString)
        {
            File.WriteAllText(SAVE_FOLDER + $"inputViewerPos.json", saveString);
        }

        public static string Load()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(SAVE_FOLDER);
            FileInfo[] saveFiles = directoryInfo.GetFiles("inputViewerPos.json");
            FileInfo mostRecentFile = null;

            foreach (var fileInfo in saveFiles)
            {
                if (mostRecentFile == null)
                {
                    mostRecentFile = fileInfo;
                }
                else
                {
                    if (fileInfo.LastWriteTime > mostRecentFile.LastWriteTime)
                    {
                        mostRecentFile = fileInfo;
                    }
                }
            }

            if (mostRecentFile != null)
            {
                string saveString = File.ReadAllText(mostRecentFile.FullName);
                return saveString;
            }
            else
            {
                return null;
            }
        }
    } 
}
