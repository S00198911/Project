using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    // This class deals with the frame data of each move e.g. Start up, on block and active on frames for Up Tilt
    public abstract class Frames
    {
        // Properties
        public string startUp { get; set; }
        public string onBlock { get; set; }
        public string activeOn { get; set; }

        // Constructors
        public Frames(string startUp, string onBlock, string activeOn)
        {
            this.startUp = startUp;
            this.onBlock = onBlock;
            this.activeOn = activeOn;
        }

        // Default Contructor
        public Frames() : this("","", "")
        {
            
        }
    }


    public class ForwardTilt : Frames
    {
        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class UpTilt : Frames
    {
        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class DownTilt : Frames
    {
        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class ForwardSmash : Frames
    {
        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class USmash : Frames
    {
        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class DSmash : Frames
    {
        public override string ToString()
        {
            return base.ToString();
        }
    }

    // Side B
    public class SideSpecial: Frames
    {
        public override string ToString()
        {
            return base.ToString();
        }
    }

    // Up B
    public class UpSpecial : Frames
    {
        public override string ToString()
        {
            return base.ToString();
        }
    }

    // Down B
    public class DownSpecial : Frames
    {
        public override string ToString()
        {
            return base.ToString();
        }
    }

    // Neutral B
    public class NeutralSpecial : Frames
    {
        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class FAir : Frames
    {
        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class UAir : Frames
    {
        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class DAir : Frames
    {
        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class BAir : Frames
    {
        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class NAir : Frames
    {
        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class Grabs : Frames
    {
        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class DashGrabs : Frames
    {
        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class PivotGrabs : Frames
    {
        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class Pummels : Frames
    {
        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class ForwardThrow : Frames
    {
        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class BackThrow : Frames
    {
        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class UpThrow : Frames
    {
        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class DownThrow : Frames
    {
        public override string ToString()
        {
            return base.ToString();
        }
    }
}