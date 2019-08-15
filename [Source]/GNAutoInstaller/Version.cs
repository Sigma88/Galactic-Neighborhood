using UnityEngine;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    public class Version : MonoBehaviour
    {
        public static readonly System.Version number = new System.Version("0.2.0");

        void Awake()
        {
            Debug.Log("[SigmaLog] Version Check:   GN Auto Installer v" + number);
        }
    }
}
