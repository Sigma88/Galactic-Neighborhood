using UnityEngine;
using Kopernicus;
using Kopernicus.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;


namespace GalacticNeighborhoodPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class ConfigNodeFixer : MonoBehaviour
    {
        void Start()
        {
            foreach (UrlDir.UrlConfig node in GameDatabase.Instance.GetConfigs("GalacticNeighborhood").Where(c => c.url != "GalacticNeighborhood/Settings/GalacticNeighborhood"))
            {
                node.parent.configs.Remove(node);
            }
        }
    }

    [ParserTargetExternal("Body", "ScaledVersion", "Kopernicus")]
    public class SettingsLoader : BaseLoader
    {
        [ParserTarget("Light", optional = true, allowMerge = true)]
        public ActiveFlareLoader activeFlareLoader;

        [ParserTargetCollection("GNCoronae", nameSignificance = NameSignificance.Key, key = "Corona")]
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
                                material.mainTexture = value[i].mainTexture.value;
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
                                        transform.localScale.x * value[i].localScaleMult.value.x,
                                        transform.localScale.y * value[i].localScaleMult.value.y,
                                        transform.localScale.z * value[i].localScaleMult.value.z
                                    );
                        }
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

    [RequireConfigType(ConfigType.Node)]
    public class GNCorona
    {
        [ParserTarget("mainTexture", optional = true)]
        public Texture2DParser mainTexture = null;

        [ParserTarget("mainTextureOffset", optional = true)]
        public Vector2Parser mainTextureOffset = null;

        [ParserTarget("mainTextureScale", optional = true)]
        public Vector2Parser mainTextureScale = null;

        [ParserTarget("localScaleMult", optional = true)]
        public Vector3Parser localScaleMult = new Vector3(1, 1, 1);

        public GNCorona()
        {
        }
    }
}
