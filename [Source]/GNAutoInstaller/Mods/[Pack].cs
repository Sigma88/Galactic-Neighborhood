using System.IO;
using UnityEngine;


namespace GNAutoInstallerPlugin
{
    class Pack<T> : MonoBehaviour where T : Pack<T>
    {
        internal virtual string archive { get; set; }
        internal virtual string path { get; set; }
        internal virtual string[] filter { get; set; }

        static T Instance;
        internal static T Mod { get { return Instance = Instance ?? new GameObject(typeof(T).ToString()).AddComponent<T>(); } }

        void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
                return;
            }

            Instance = (T)this;

            if (Check()) Events.InstallMods.Add(Install);
        }

        internal virtual bool Check()
        {
            return File.Exists(archive) || Directory.Exists(path);
        }

        internal virtual void Install()
        {
            if (!Directory.Exists(path))
            {
                Archive.UnZip(archive, path, path, filter);
            }
        }
    }
}
