using UnityEngine;
using Kopernicus;
using Kopernicus.Configuration;
using System.Linq;
using System;
using System.Collections.Generic;


namespace GalacticNeighborhoodPlugin
{
    [ParserTargetExternal("Body", "ScaledVersion")]
    public class SettingsLoader : BaseLoader
    {
        [ParserTarget("Light", optional = true, allowMerge = true)]
        public ActiveFlareLoader activeFlareLoader;

        [ParserTargetCollection("GNCoronas", nameSignificance = NameSignificance.None)]
        public List<GNCorona> GNcoronas
        {
            set
            {
                SunCoronas[] coronas = generatedBody.scaledVersion?.GetComponentsInChildren<SunCoronas>(true);

                for (int i = 0; i < Math.Min(coronas.Length, value.Count); i++)
                {
                    Material material = coronas[i]?.GetComponent<Renderer>()?.material;
                    Texture mainTexture = Resources.FindObjectsOfTypeAll<Texture>().FirstOrDefault(t => t.name == value[i].mainTexture);

                    if (mainTexture != null && material != null)
                        material.mainTexture = mainTexture;
                    if (value[i].mainTextureOffset != null && material != null)
                        material.mainTextureOffset = value[i].mainTextureOffset;
                    if (value[i].mainTextureScale != null && material != null)
                        material.mainTextureScale = value[i].mainTextureScale;
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
        public string mainTexture { get; set; }

        [ParserTarget("mainTextureOffset", optional = true)]
        public Vector2Parser mainTextureOffset { get; set; }

        [ParserTarget("mainTextureScale", optional = true)]
        public Vector2Parser mainTextureScale { get; set; }

        public GNCorona()
        {
        }
    }
}
