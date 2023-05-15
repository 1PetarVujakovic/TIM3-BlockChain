using Common.Interfejsi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Klase
{
    public class BlockChain : IBlockChain
    {
        public List<Block> Blocks { get; set; }


        public BlockChain()
        {
            Blocks = new List<Block>();
        }

        public void DodajUBlockChain(Block block)
        {
            if (Blocks.Count > 0)
            {
                block.PrethodniId = Blocks[Blocks.Count - 1].Id;
            }

            Blocks.Add(block);
        }
    }
}
