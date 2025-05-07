using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DairyBarn.Data
{
    /// <summary>
    /// Holds a list of reviews in a json file.
    /// </summary>
    public static class ReviewDatabase
    {
        /// <summary>
        /// The reviews that are in the list.
        /// </summary>
        private static List<Review> _reviews;

        /// <summary>
        /// The constructor.
        /// </summary>
        static ReviewDatabase()
        {
            _reviews = new List<Review>();
            if(File.Exists("reviews.json"))
            {
                string json = File.ReadAllText("reviews.json");
                _reviews = JsonConvert.DeserializeObject<List<Review>>(json);
            }
            if(_reviews == null)
            {
                _reviews = new List<Review>();
            }
        }

        /// <summary>
        /// An enumeration of the list of reviews.
        /// </summary>
        public static IEnumerable<Review> Reviews => _reviews;

        /// <summary>
        /// Adds the reviews to the json file.
        /// </summary>
        /// <param name="r">The text with in the review.</param>
        public static void AddReview(Review r)
        {
            if(r != null)
            {
                _reviews.Add(r);
                File.WriteAllText("reviews.json", JsonConvert.SerializeObject(Reviews));
            }
        }
    }
}
