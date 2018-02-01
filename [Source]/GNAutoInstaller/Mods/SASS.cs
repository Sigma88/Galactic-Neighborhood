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
            if (Directory.Exists(path)) return true;
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
