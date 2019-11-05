using System;

namespace Mailbox
{   
    [Flags]
    public enum Sizes
    {
        Unspecified =0b000,

        Small = 0b001,
        Medium = 0b0010,
        Large = 0b0011,

        Premium= 0b100,

        SmallPremium = Small | Premium,
        MediumPremium = Medium | Premium,
        LargePremium = Large | Premium
    }
}
