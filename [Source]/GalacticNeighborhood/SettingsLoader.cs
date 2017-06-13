using UnityEngine;
using Kopernicus;
using Kopernicus.Configuration;
using System;
using System.Collections.Generic;


namespace GalacticNeighborhoodPlugin
{
    [ParserTargetExternal("Body", "ScaledVersion")]
    public class SettingsLoader : BaseLoader
    {
        [ParserTarget("Light", optional = true, allowMerge = true)]
        public ActiveFlareLoader activeFlareLoader;

        [ParserTargetCollection("GNCoronae", nameSignificance = NameSignificance.None)]
        public List<GNCorona> GNcoronae
        {
            set
            {
                SunCoronas[] coronae = generatedBody.scaledVersion?.GetComponentsInChildren<SunCoronas>(true);

                for (int i = 0; i < Math.Min(coronae.Length, value.Count); i++)
                {
                    Material material = coronae[i]?.GetComponent<Renderer>()?.material;

                    if (material != null)
                    {
                        if (value[i].mainTexture != null)
                            material.mainTexture = value[i].mainTexture.value;
                        if (value[i].mainTextureOffset != null)
                            material.mainTextureOffset = value[i].mainTextureOffset;
                        if (value[i].mainTextureScale != null)
                            material.mainTextureScale = value[i].mainTextureScale;
                    }
                }
            }
        }
    }

    public class ActiveFlareLoader : BaseLoader
    {
        [ParserTarget("activeSunFlare", optional = true)]
        public AssetParser<Flare> activeFlare
        {
            set
            {
                if (value.value != null && !SunFlareSwitcher.activeFlares.ContainsKey(generatedBody.name))
                    SunFlareSwitcher.activeFlares.Add(generatedBody.name, value.value);
            }
        }
    }

    public class GNCorona
    {
        [ParserTarget("mainTexture", optional = true)]
        public Texture2DParser mainTexture = null;

        [ParserTarget("mainTextureOffset", optional = true)]
        public Vector2Parser mainTextureOffset = null;

        [ParserTarget("mainTextureScale", optional = true)]
        public Vector2Parser mainTextureScale = null;

        public GNCorona()
        {
        }
    }
}
