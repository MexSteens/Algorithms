namespace Wetenschappers
{
    public class Wetenschapper
    {
        public string naam { get; set; }
        public int geboorteJaar { get; set; }
        public int sterfJaar { get; set; }

        public Wetenschapper(string naam, int geboorteJaar, int sterfJaar)
        {
            this.naam = naam;
            this.geboorteJaar = geboorteJaar;
            this.sterfJaar = sterfJaar;
        }

        public override string ToString()
        {
            return "Naam: " + naam + " || Geboortejaar: " + geboorteJaar + " || sterfjaar: " + sterfJaar;
        }
    }
}