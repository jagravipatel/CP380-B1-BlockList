using System;
using System.Collections.Generic;

namespace CP380_B1_BlockList.Models
{
    public class BlockList
    {
        public IList<Block> Chain { get; set; }

        public int Difficulty { get; set; } = 2;

        public BlockList()
        {
            Chain = new List<Block>();
            MakeFirstBlock();
        }

        public void MakeFirstBlock()
        {
            var block = new Block(DateTime.Now, null, new List<Payload>());
            block.Mine(Difficulty);
            Chain.Add(block);
        }

        public void AddBlock(Block block)
        {
            block.PreviousHash = Chain[Chain.Count - 1].Hash;

            block.Mine(Difficulty);

            Chain.Add(block);
        }

        public bool IsValid()
        {
            string hash = new String('C', Difficulty);
            int error = 0;
            for (int i = 1; i < Chain.Count; i++)
            {
                string block = Chain[i].Hash;
                if (block.Substring(0, Difficulty) != hash || Chain[i].PreviousHash != Chain[i - 1].Hash)
                { return false; }
            }
             return true; 
        }
    }
}
