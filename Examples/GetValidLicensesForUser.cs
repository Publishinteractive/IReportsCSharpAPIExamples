using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace IReportsApiExamples.Examples
{
    public class GetValidLicensesForUser
    {
        /// <summary>Gets all the category and reports licenses for a specified user and determines whether
        /// they are valid for the whole duration inbetween the two dates</summary>
        /// <param name="wrapper">The ApiWrapper object to use</param>
        /// <param name="username">The username of the desired user to get the licenses from</param>
        /// <param name="startDate">The start date</param>
        /// <param name="endDate">The end date</param>
        public static async Task DoWork(
            ApiWrapper wrapper,
            string username,
            DateTime startDate,
            DateTime endDate)
        {
            var categoryLicensesQuery = await wrapper.GetCategoryLicensesForUser(username, 0, null);
            var reportsLicensesQuery = await wrapper.GetReportLicensesForUserAsync(username, 0, null);

            PrintValidCategoryLicenses(GetValidLicenses<CategoryLicenseModel>(
                                categoryLicensesQuery.Licenses,
                                startDate,
                                endDate).ToList());

            PrintValidReportLicenses(GetValidLicenses<ReportLicenseModel>(
                                reportsLicensesQuery.Licenses,
                                startDate,
                                endDate).ToList());
        }

        /// <summary>Prints how many and which licenses are valid</summary>
        /// <param name="validCategoryLicenses">The list of valid category licenses to loop through</param>
        private static void PrintValidCategoryLicenses(List<CategoryLicenseModel> validCategoryLicenses)
        {
            Console.WriteLine($"{validCategoryLicenses.Count} Category Licenses are valid:");

            validCategoryLicenses.ForEach(l =>
                Console.WriteLine($"'{l.Category}' license is valid between the two dates"));
        }

        /// <summary>Prints how many and which licenses are valid</summary>
        /// <param name="validReportLicenses">The list of valid report licenses to loop through</param>
        private static void PrintValidReportLicenses(List<ReportLicenseModel> validReportLicenses)
        {
            Console.WriteLine($"{validReportLicenses.Count} Category Licenses are valid:");

            validReportLicenses.ForEach(l =>
                Console.WriteLine($"'{l.Report}' license is valid between the two dates"));
        }

        /// <summary>Creates a list of valid licenses by looping through all the licenses the desired user
        /// has and determining whether they are valid between the two specified dates</summary>
        /// <T>CategoryLicenseModel or ReportLicenseModel</T>
        /// <param name="licenses">The list of licenses to loop through</param>
        /// <param name="startDate">The start date</param>
        /// <param name="endDate">The end date</param>
        private static IEnumerable<T> GetValidLicenses<T>(
            List<T> licenses,
            DateTime startDate,
            DateTime endDate)
        where T : LicenseModel
        {
            foreach (var license in licenses)
            {
                if (license.ActiveDates != null)
                {
                    if (license.ActiveDates.StartDate.Value.CompareTo(startDate) < 0 &&
                        license.ActiveDates.EndDate.Value.CompareTo(endDate) > 0)
                    {
                        yield return license;
                    }
                }
            }
        }
    }
}