using System;
using System.Collections.Generic;
using UnityEngine;
using Kopernicus.ConfigParser.Attributes;
using Kopernicus.ConfigParser.BuiltinTypeParsers;
using Kopernicus.ConfigParser.Enumerations;
using Kopernicus.Configuration.Parsing;


namespace GalacticNeighborhoodPlugin
{
    [ParserTargetExternal("Body", "ScaledVersion", "Kopernicus")]
    public class SettingsLoader : BaseLoader
    {
        [ParserTarget("Light", Optional = true, AllowMerge = true)]
        public ActiveFlareLoader activeFlareLoader;

        [ParserTargetCollection("GNCoronae", NameSignificance = NameSignificance.Key, Key = "Corona")]
        public List<GNCorona> GNcoronae
        {
            set
            {
                SunCoronas[] coronae = generatedBody.scaledVersion?.GetComponentsInChildren<SunCoronas>(true);

                for (int i = 0; i < Math.Min(coronae.Length, value.Count); i++)
                {
                    Renderer renderer = coronae[i]?.GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        if (renderer.material != null)
                        {
                            Material material = renderer.material;

                            if (value[i].mainTexture != null)
                                material.mainTexture = value[i].mainTexture.Value;
                            if (value[i].mainTextureOffset != null)
                                material.mainTextureOffset = value[i].mainTextureOffset;
                            if (value[i].mainTextureScale != null)
                                material.mainTextureScale = value[i].mainTextureScale;
                        }

                        if (renderer.transform != null)
                        {
                            Transform transform = renderer.transform;

                            if (transform.localScale != null)
                                transform.localScale =
                                    new Vector3
                                    (
                                        transform.localScale.x * value[i].localScaleMult.Value.x,
                                        transform.localScale.y * value[i].localScaleMult.Value.y,
                                        transform.localScale.z * value[i].localScaleMult.Value.z
                                    );
                        }
                    }
                }
            }
        }
    }

    public class ActiveFlareLoader : BaseLoader
    {
        [ParserTarget("activeSunFlare", Optional = true)]
        public AssetParser<Flare> activeFlare
        {
            set
            {
                if (value.Value != null && !SunFlareSwitcher.activeFlares.ContainsKey(generatedBody.name))
                    SunFlareSwitcher.activeFlares.Add(generatedBody.name, value.Value);
            }
        }
    }

    [RequireConfigType(ConfigType.Node)]
    public class GNCorona
    {
        [ParserTarget("mainTexture", Optional = true)]
        public Texture2DParser mainTexture = null;

        [ParserTarget("mainTextureOffset", Optional = true)]
        public Vector2Parser mainTextureOffset = null;

        [ParserTarget("mainTextureScale", Optional = true)]
        public Vector2Parser mainTextureScale = null;

        [ParserTarget("localScaleMult", Optional = true)]
        public Vector3Parser localScaleMult = new Vector3(1, 1, 1);

        public GNCorona()
        {
        }
    }
}
