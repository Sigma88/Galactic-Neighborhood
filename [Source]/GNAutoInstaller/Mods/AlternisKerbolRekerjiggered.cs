using System.IO;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class AKR : Pack<AKR>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/AlternisKerbolRekerjiggered2.3.0.4.zip"; } }
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
                Archive.UnZip(archive, "AlternisKerbolRekerjiggered/", path, filter);
                Archive.UnZip(archive, "AlternisKerbolRekerjiggered/ModCompatibility/PlanetPackCompatibility/GalacticNeighborhood.cfg", path + "ModCompatibility/PlanetPackCompatibility/GalacticNeighborhood.cfg");
            }
        }
    }
}
