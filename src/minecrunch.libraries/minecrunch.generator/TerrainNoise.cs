using SharpNoise.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minecrunch.generator
{
    public class TerrainNoise
    {
        readonly WorldGenerator worldGenerator;
        readonly WorldGenerationSettings worldGenSettings;
        readonly Module worldGenModule;
        
        const double WORLD_HORIZONTAL_STRETCH = 1 / 256;

        private static readonly Lazy<TerrainNoise> lazy = new Lazy<TerrainNoise>(() => new TerrainNoise());

        public static TerrainNoise Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        /// <summary>
        /// ctor
        /// </summary>
        private TerrainNoise()
        {
            worldGenSettings = new WorldGenerationSettings();
            worldGenerator = new WorldGenerator(worldGenSettings);
            worldGenModule = worldGenerator.CreateModule();
        }

        public double Terrain(double x, double z)
        {
            return worldGenModule.GetValue(x * WORLD_HORIZONTAL_STRETCH, 0, z * WORLD_HORIZONTAL_STRETCH);
        }
    }
}
