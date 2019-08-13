using System.IO;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class AKR : Pack<AKR>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/AlternisKerbolRekerjiggered2.5.0.zip"; } }
        internal override string path { get { return "GameData/AlternisKerbolRekerjiggered/"; } }
        internal override string[] filter
        {
            get
            {
                return new string[]
                {
                    path + "ModCompatibility/",
                    path + "KopernicusFiles/000"
                };
            }
        }

        internal override void Install()
        {
            if (!Directory.Exists(path))
            {
                Archive.UnZip(archive, path, path, filter);
                Archive.UnZip(archive, path + "ModCompatibility/PlanetPackCompatibility/GalacticNeighborhood.cfg", path + "ModCompatibility/PlanetPackCompatibility/GalacticNeighborhood.cfg");
            }
        }
    }
}
