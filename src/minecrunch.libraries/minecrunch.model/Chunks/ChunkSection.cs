using minecrunch.model.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace minecrunch.model.Chunks
{
    [Serializable]
    public class ChunkSection
    {
        public string name;
        public int number;
        public Block[,,] blocks = new Block[16, 16, 16];


        public ChunkSection()
        {

        }

        public List<Block> GetAllBlocks()
        {
            return blocks.Cast<Block>().ToList();
        }
    }
}
