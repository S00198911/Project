using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    // This class holds the name and image of each of the 12 characters
    public partial class Characters
    {
        // Properties
        public string Name { get; set; }
        public string Image { get; set; }

        // Constructors
        public Characters(string Name, string Image)
        {
            this.Name = Name;
            this.Image = Image;
        }

        // Default Contructor
        public Characters() : this("", "")
        {

        }

        // Methods
        public override string ToString()
        {
            return Name;
        }

       
    }
}
