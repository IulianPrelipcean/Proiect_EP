using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCheckers
{
    public class AttackMove
    {
        public int PieceId { get; set; }
        public List<Move> Moves { get; set; }
        public AttackMove()
        {
            Moves = new List<Move>();
        }
    }
}
