﻿using UnityEngine;
using KSP.Localization;
using ICSharpCode.SharpZipLib.Zip;

namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    public class Installer : MonoBehaviour
    {
        void Awake()
        {
            ZipConstants.DefaultCodePage = 0;

            Debug.Log("SigmaLog: Installing added mods");
            Events.InstallMods.Fire();
        }

        void Start()
        {
            Localizer.SwitchToLanguage(Localizer.CurrentLanguage);
        }
    }
}