using System.IO;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class AKR : Pack<AKR>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/AlternisKerbolRekerjiggered2.3.0.4.zip"; } }
        internal override string path { get { return "AlternisKerbolRekerjiggered/"; } }
        internal override string[] filter
        {
            get
            {
                return new string[]
                {
                    path + "ModCompatibility/"
                };
            }
        }

        internal override void Install()
        {
            if (!Directory.Exists("GameData/" + path))
            {
                Archive.UnZip(archive, path, "GameData/" + path, filter);
                Archive.UnZip(archive, path + "ModCompatibility/PlanetPackCompatibility/GalacticNeighborhood.cfg", "GameData/" + path + "ModCompatibility/PlanetPackCompatibility/GalacticNeighborhood.cfg");
            }
        }
    }
}
