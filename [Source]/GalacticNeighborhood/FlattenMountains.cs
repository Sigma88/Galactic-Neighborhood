/**
 * FlattenMountains Plugin for KerbolPlus
 * All Rights Reserved - Thomas P. and KillAshley
 */

using Kopernicus.ConfigParser.Attributes;
using Kopernicus.ConfigParser.BuiltinTypeParsers;
using Kopernicus.ConfigParser.Enumerations;
using Kopernicus.Configuration.ModLoader;


namespace KerbolPlus
{
    public class PQSMod_FlattenMountains : PQSMod
    {
        public double altitude = 0;
        public override void OnVertexBuildHeight(PQS.VertexBuildData data)
        {
            if (data.vertHeight > (altitude + sphere.radius))
                data.vertHeight = sphere.radius + altitude;
        }
    }

    [RequireConfigType(ConfigType.Node)]
    public class FlattenMountains : ModLoader<PQSMod_FlattenMountains>
    {
        // The altitude for the flatten
        [ParserTarget("altitude", Optional = true)]
        private NumericParser<double> altitude
        {
            get { return Mod.altitude; }
            set { Mod.altitude = value; }
        }
    }
}
