using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using ToolsForHire.Data;

namespace ToolsForHire.Pages
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IProductData productData;
        
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime HireStartDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime HireEndDate { get; set; }

        public IEnumerable<Product> Products { get; set; }

        public ListModel(IConfiguration config, IProductData productData)
        {
            this.config = config;
            this.productData = productData;
        }

        /// <summary>
        /// Calculates the total cost of hiring a tool.
        /// ASSUMPTIONS: The duration is inclusive: that is, a hire that begins on the 24th and ends on
        ///              the 25th will be counted as two days.
        /// </summary>
        /// <param name="startDate">The starting date of hire.</param>
        /// <param name="endDate">The ending date of hire.</param>
        /// <param name="dailyCost">The daily cost of hiring the tool.</param>
        /// <returns></returns>
        public decimal CalculateTotalCostOfHire(DateTime startDate, DateTime endDate, decimal dailyCost)
        {
            // Get the total number of days between the start.
            int totalDays = (endDate - startDate).Days + 1;

            // Subtract the number of Sundays from the total days.
            totalDays -= GetNumberOfSundaysBetween(startDate, endDate);

            // Subtract the number of Saturdays from the total days.
            totalDays -= GetNumberOfSaturdaysBetween(startDate, endDate);

            // ...but DO include Saturdays if the start date or end date falls on a Saturday
            if (startDate.DayOfWeek == DayOfWeek.Saturday)
            {
                ++totalDays;
            }
            if (endDate.DayOfWeek == DayOfWeek.Saturday)
            {
                ++totalDays;
            }

            return totalDays * dailyCost;

        }

        /// <summary>
        /// Gets the number of Sundays between two dates.
        /// </summary>
        /// <param name="startDate">The starting date.</param>
        /// <param name="endDate">The ending date.</param>
        /// <returns></returns>
        public int GetNumberOfSundaysBetween(DateTime startDate, DateTime endDate)
        {
            return GetDaysBetween(startDate, endDate)
                   .Where(d => d.DayOfWeek == DayOfWeek.Sunday).Count();
        }

        /// <summary>
        /// Gets the number of Saturdays between two dates.
        /// </summary>
        /// <param name="startDate">The starting date.</param>
        /// <param name="endDate">The ending date.</param>
        /// <returns></returns>
        public int GetNumberOfSaturdaysBetween(DateTime startDate, DateTime endDate)
        {
            return GetDaysBetween(startDate, endDate)
                   .Where(d => d.DayOfWeek == DayOfWeek.Saturday).Count();
        }

        /// <summary>
        /// Gets the days between two dates.
        /// </summary>
        /// <param name="start">The starting date.</param>
        /// <param name="end">The ending date.</param>
        /// <returns></returns>
        IEnumerable<DateTime> GetDaysBetween(DateTime start, DateTime end)
        {
            for (DateTime i = start; i < end; i = i.AddDays(1))
            {
                yield return i;
            }
        }

        public void OnGet()
        {
            if (String.IsNullOrWhiteSpace(SearchString))
            {
                Products = productData.GetAllProducts();
            }
            else
            {
                if (SearchString.Contains("/"))
                {
                    Products = productData.GetProductsByProductCode(SearchString);
                    if (Products.Any())
                    {
                        return;
                    }
                }

                Products = productData.GetProductsByName(SearchString);
            }
        }
    }
}