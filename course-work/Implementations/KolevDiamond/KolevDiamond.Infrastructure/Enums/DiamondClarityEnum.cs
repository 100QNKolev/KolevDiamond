namespace KolevDiamond.Infrastructure.Enums
{
    public enum DiamondClarity
    {
        FL = 1,   // Flawless: No internal or external flaws visible under 10x magnification.
        IF = 2,   // Internally Flawless: No internal flaws, slight external blemishes.
        VVS1 = 3, // Very Very Slightly Included 1: Minute inclusions difficult to detect under 10x magnification.
        VVS2 = 4, // Very Very Slightly Included 2: Slightly more noticeable inclusions than VVS1.
        VS1 = 5,  // Very Slightly Included 1: Minor inclusions visible under 10x magnification.
        VS2 = 6,  // Very Slightly Included 2: Slightly more noticeable inclusions than VS1.
        SI1 = 7,  // Slightly Included 1: Noticeable inclusions under 10x magnification, may be visible to the naked eye.
        SI2 = 8,  // Slightly Included 2: More noticeable inclusions than SI1, may affect brilliance.
        I1 = 9,   // Included 1: Obvious inclusions visible to the naked eye, may affect transparency and brilliance.
        I2 = 10,  // Included 2: More prominent inclusions than I1, significantly affect transparency and brilliance.
        I3 = 11   // Included 3: Prominent inclusions severely affect transparency, brilliance, and durability.
    }
}
