using System.IO;
using System.Reflection.Emit;

namespace Wetenschappers
{
    public class levendeWetenschapper
    {
        public int jaar { get; set; }
        public int count { get; set; }

        public levendeWetenschapper(int jaar, int count)
        {
            this.jaar = jaar;
            this.count = count;
        }

        public levendeWetenschapper()
        {
            
        }

        public override string ToString()
        {
            return "jaar: " + jaar + " || aantal: " + count;
        }
    }
}