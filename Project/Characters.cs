using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
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
