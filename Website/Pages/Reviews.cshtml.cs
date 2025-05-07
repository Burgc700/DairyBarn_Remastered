using DairyBarn.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Website.Pages
{
    /// <summary>
    /// The review model for the reviews page.
    /// </summary>
    public class ReviewsModel : PageModel
    {
        /// <summary>
        /// Interface to get the logger.
        /// </summary>
        private readonly ILogger<IndexModel> _logger;

        public ReviewsModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Finds get request on the reviews page.
        /// </summary>
        public void OnGet()
        {
        }

        /// <summary>
        /// Finds post requests on reviews page.
        /// </summary>
        public void OnPost()
        {
            Review addReview = new Review(Review) { TimeStamp = DateTime.Now };
            
            ReviewDatabase.AddReview(addReview);
            Review = null;
        }

        /// <summary>
        /// The review we are adding to the list.
        /// </summary>
        [BindProperty]
        public string? Review { get; set; }

        /// <summary>
        /// All the reviews already in the list.
        /// </summary>
        public IEnumerable<Review> AllReviews => ReviewDatabase.Reviews.OrderByDescending(r => r.TimeStamp);
    }
}
