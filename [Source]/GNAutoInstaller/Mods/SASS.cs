using System.IO;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class SASS : Pack<SASS>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/StockalikeSolarSystem.v0.5.4.zip"; } }
        internal override string path { get { return "GameData/StockalikeSolarSystem/"; } }

        internal override bool Check()
        {
            UnityEngine.Debug.Log("SigmaLog: SASS path exists = " + Directory.Exists(path));
            if (Directory.Exists(path)) return true;

            UnityEngine.Debug.Log("SigmaLog: SASS dependancy1 = " + File.Exists(archive));
            UnityEngine.Debug.Log("SigmaLog: SASS dependancy2 = " + SD.Check());
            UnityEngine.Debug.Log("SigmaLog: SASS dependancy3 = " + DRP.Check());
            UnityEngine.Debug.Log("SigmaLog: SASS dependancy4 = " + NewHorizons.Mod.Check());
            UnityEngine.Debug.Log("SigmaLog: SASS dependancy5 = " + OPM.Mod.Check());
            UnityEngine.Debug.Log("SigmaLog: SASS dependancy6 = " + RevSS.Check());
            UnityEngine.Debug.Log("SigmaLog: SASS dependancy7 = " + RevJ.Check());
            UnityEngine.Debug.Log("SigmaLog: SASS dependancy8 = " + Saru.Mod.Check());
            UnityEngine.Debug.Log("SigmaLog: SASS dependancy9 = " + Sentar.Mod.Check());
            UnityEngine.Debug.Log("SigmaLog: SASS dependancy10 = " + SER.Check());
            UnityEngine.Debug.Log("SigmaLog: SASS dependancy11 = " + SNep.Check());
            UnityEngine.Debug.Log("SigmaLog: SASS dependancy12 = " + UnchartedLands.Mod.Check());

            return File.Exists(archive) && SD.Check() && DRP.Check() && NewHorizons.Mod.Check() && OPM.Mod.Check() && RevSS.Check() && RevJ.Check() && Saru.Mod.Check() && Sentar.Mod.Check() && SER.Check() && SNep.Check() && UnchartedLands.Mod.Check();
        }

        internal override void Install()
        {
            SER.Install();
            SNep.Install();
            RevSS.Install();
            RevJ.Install();
            DRP.Install();

            if (!Directory.Exists(path))
            {
                Archive.UnZip(archive, path, path);
            }
        }
    }
}
