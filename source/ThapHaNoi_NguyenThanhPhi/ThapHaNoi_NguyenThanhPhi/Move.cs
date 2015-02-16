using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThapHaNoi_NguyenThanhPhi
{
    public class Move
    {
        public readonly int From;
		public readonly int To;

		public Move(int from, int to) {
			From = from; To = to;
		}


		public override string ToString() {
			return string.Format("Move {0} to {1}", From, To);

		}

        /*
        public Pole FromPole { get; set; }
        public Pole ToPole { get; set; }

        public Move(Pole fromPole, Pole toPole)
        {
            this.FromPole = fromPole;
            this.ToPole = toPole;
        }


        public Move(int fromPoleNumber, int toPoleNumber)
        {
            this.FromPole = GameState.Poles[fromPoleNumber];
            this.ToPole = GameState.Poles[toPoleNumber];
        }


        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }
            // If parameter cannot be cast to Move return false.
            Move move = obj as Move;
            if ((System.Object)move == null)
            {
                return false;
            }
            return move.FromPole.Number == move.FromPole.Number &&
                move.ToPole.Number == move.ToPole.Number;
        }
         * 
         * */
         
    }
}
