using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.Data
{
    /// <summary>
    /// Holds the text of the review and the time stamp.
    /// </summary>
    public class Review
    {
        /// <summary>
        /// The text in the review.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// The time stamp the review was placed.
        /// </summary>
        public DateTime TimeStamp { get; init; }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="text">The text for the review.</param>
        public Review(string text)
        {
            Text = text;
            //TimeStamp = DateTime.Now;
        }

        /// <summary>
        /// Converts the time stamp to a string.
        /// </summary>
        /// <returns>The text and time stamp in that format.</returns>
        public override string ToString()
        {
            return $"{Text} \n {TimeStamp: MM-dd-yyyy HH:mm:ss}";
        }
    }
}
