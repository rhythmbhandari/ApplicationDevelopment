namespace Coursework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="TicketPrices" />.
    /// </summary>
    internal class TicketPrices
    {
        /// <summary>
        /// Gets or sets the RateID.
        /// </summary>
        public int RateID { get; set; }

        /// <summary>
        /// Gets or sets the TicketGroup.
        /// </summary>
        public String TicketGroup { get; set; }

        /// <summary>
        /// Gets or sets the OneHour.
        /// </summary>
        public String OneHour { get; set; }

        /// <summary>
        /// Gets or sets the TwoHours.
        /// </summary>
        public String TwoHours { get; set; }

        /// <summary>
        /// Gets or sets the ThreeHours.
        /// </summary>
        public String ThreeHours { get; set; }

        /// <summary>
        /// Gets or sets the FourHours.
        /// </summary>
        public String FourHours { get; set; }

        /// <summary>
        /// Gets or sets the Unlimited.
        /// </summary>
        public String Unlimited { get; set; }
    }
}
