using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public partial class Frames
    {
        // Properties
        public int startUp { get; set; }
        public int onBlock { get; set; }

        // Constructors
        public Frames(string startUp, string Image)
        {
            this.Name = Name;
            this.Image = Image;
        }

        // Default Contructor
        public Frames() : this("", "")
        {

        }

        // Methods
        public override string ToString()
        {
            
        }
    }
}
