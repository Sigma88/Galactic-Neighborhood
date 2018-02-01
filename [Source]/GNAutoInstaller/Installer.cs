using UnityEngine;
using KSP.Localization;
using ICSharpCode.SharpZipLib.Zip;

namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class Installer : MonoBehaviour
    {
        void Awake()
        {
            ZipConstants.DefaultCodePage = 0;
            
            Events.InstallMods.Fire();
        }

        void Start()
        {
            Localizer.SwitchToLanguage(Localizer.CurrentLanguage);
        }
    }
}
