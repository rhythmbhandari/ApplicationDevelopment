namespace Coursework
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="FileLocation" />.
    /// </summary>
    internal class FileLocation
    {
        /// <summary>
        /// Defines the visitorDetailsFile.
        /// </summary>
        public static String visitorDetailsFile = System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString() + "/visitor_details.xml";

        /// <summary>
        /// Defines the ticketRatesFile.
        /// </summary>
        public static String ticketRatesFile = System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString() + "/ticket_rates.csv";
    }
}
