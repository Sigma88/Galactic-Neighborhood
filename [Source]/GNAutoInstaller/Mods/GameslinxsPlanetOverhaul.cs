using System.IO;


namespace GNAutoInstallerPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class GPO : Pack<GPO>
    {
        internal override string archive { get { return "PluginData/GalacticNeighborhood/Gameslinxs_Planet_Overhaul_Stockalike_Planet_Pack-3.0.1.zip"; } }
        internal override string path { get { return "GameData/GPO/"; } }
        internal override string[] filter
        {
            get
            {
                return new string[]
                {
                    path + "Configs/FixPQS.cfg",
                    path + "EVE/",
                    path + "LSM/",
                    path + "scatterer/",
                    path + "GPO_RemoteTech.cfg",
                    path + "GPO_Scatterer.cfg",
                    path + "GPO_Scatterer_Settings.cfg",
                    path + "GPO_Science Balance Pass.cfg"
                };
            }
        }

        internal override void Install()
        {
            if (!Directory.Exists(path))
            {
                Archive.UnZip(archive, path, path, filter);

                string file = "Configs/Teloslate.cfg";

                string[] fix = File.ReadAllLines(path + file);
                fix[0] = "@Kopernicus:FOR[GPO]";
                File.Delete(path + file);
                File.WriteAllLines(path + file, fix);


                file = "Configs/Quarta.cfg";

                fix = File.ReadAllLines(path + file);
                fix[0] = "@Kopernicus:FOR[GPO]";
                File.Delete(path + file);
                File.WriteAllLines(path + file, fix);


                file = "Configs/Olemut.cfg";

                fix = File.ReadAllLines(path + file);
                fix[0] = "@Kopernicus:FOR[GPO]";
                File.Delete(path + file);
                File.WriteAllLines(path + file, fix);


                file = "Configs/Kibbos.cfg";

                fix = File.ReadAllLines(path + file);
                fix[0] = "@Kopernicus:FOR[GPO]";
                File.Delete(path + file);
                File.WriteAllLines(path + file, fix);


                file = "Configs/Gullis.cfg";

                fix = File.ReadAllLines(path + file);
                fix[0] = "@Kopernicus:FOR[GPO]";
                File.Delete(path + file);
                File.WriteAllLines(path + file, fix);


                file = "Configs/Golden.cfg";

                fix = File.ReadAllLines(path + file);
                fix[0] = "@Kopernicus:FOR[GPO]";
                File.Delete(path + file);
                File.WriteAllLines(path + file, fix);


                file = "Configs/Gol.cfg";

                fix = File.ReadAllLines(path + file);
                fix[0] = "@Kopernicus:FOR[GPO]";
                File.Delete(path + file);
                File.WriteAllLines(path + file, fix);


                file = "Configs/Dread.cfg";

                fix = File.ReadAllLines(path + file);
                fix[0] = "@Kopernicus:FOR[GPO]";
                File.Delete(path + file);
                File.WriteAllLines(path + file, fix);

                CTTP.Install();
            }
        }
    }
}
