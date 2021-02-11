using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    // This class deals with the frame data of each move e.g. Start up, on block and active on frames for Up Tilt
    public partial class Frames
    {
        // Properties
        public int startUp { get; set; }
        public int onBlock { get; set; }
        public int activeOn { get; set; }
        public string moveImage { get; set; }

        // Constructors
        public Frames(int startUp, int onBlock, int activeOn, string moveImage)
        {
            this.startUp = startUp;
            this.onBlock = onBlock;
            this.activeOn = activeOn;
            this.moveImage = moveImage;
        }

        // Default Contructor
        public Frames() : this(0, 0, 0, "")
        {

        }

        // Methods
        public override string ToString()
        {
            return string.Format($"{startUp}, {onBlock}, {activeOn}"); 
        }
    }
}
