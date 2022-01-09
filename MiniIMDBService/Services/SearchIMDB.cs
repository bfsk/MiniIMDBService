using MiniIMDBService.DL.Data.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace MiniIMDBService.Services
{
    public class SearchIMDB : ServiceInterfaces.ISearchIMDB
    {
        private readonly DL.DBContext.NiceMoviesContext niceMoviesContext;
        public SearchIMDB(DL.DBContext.NiceMoviesContext _NiceMoviesContext) {
            niceMoviesContext = _NiceMoviesContext;
        }
        private const string ExceptionQueryNullMsg = "Query can't be null!";
        private const string ExceptionQueryTooShortMsg = "Query can't be null!";
        public async Task<IEnumerable<TopContent>> GetByQuery(string query, bool contentType, int page = 0)
        {
            if (String.IsNullOrEmpty(query))
                throw new ArgumentException(ExceptionQueryNullMsg);
            if(query.Length < 2)
                throw new ArgumentException(ExceptionQueryTooShortMsg);

            query = query.ToLower();

            string queryForSearch = "";

            const int numOfResults = 10;


            float greaterThanStars = -1;
            float upperStar = 5;
            float lowerStar = 0;
            int lowerYear = -1;
            int upperYear = DateTime.Today.Year;

            Regex atLeastStars = new Regex("^at least [+]?([0-9]*) stars$", RegexOptions.IgnoreCase);
            Regex NStars = new Regex("^[+]?([0-9]*) stars$", RegexOptions.IgnoreCase);
            Regex AfterYear = new Regex("^after [+]?([0-9]*)$", RegexOptions.IgnoreCase);
            Regex OlderThan = new Regex("^older than [+]?([0-9]*) years$", RegexOptions.IgnoreCase);

            if (atLeastStars.IsMatch(query))
            {
                greaterThanStars = Int32.Parse(query.Replace("at least ", "").Replace(" stars", ""));
            }
            else if (NStars.IsMatch(query))
            {
                lowerStar = Int32.Parse(query.Replace(" stars", ""));
                upperStar = lowerStar + 1;
            }
            else if (AfterYear.IsMatch(query))
            {
                lowerYear = Int32.Parse(query.Replace("after ", ""));
            }
            else if (OlderThan.IsMatch(query))
            {
                upperYear -= Int32.Parse(query.Replace("older than ", "").Replace(" years", ""));
            }
            else {
                queryForSearch = query;
            }

            var rezMovies = new List<DL.Data.Models.Movie>();
            var rezTVShows = new List<DL.Data.Models.TVShow>();
            if (contentType)
            {
                rezMovies = niceMoviesContext.Movies.Include(e => e.Casts).ThenInclude(e => e.Actor)
                    .Where(
                    e => (
                        (e.Title.ToLower().Contains(queryForSearch)
                        || e.Description.ToLower().Contains(queryForSearch)
                        || e.Casts.Any(e => e.Actor.Name.ToLower().Contains(queryForSearch))
                        || e.Casts.Any(e => e.Actor.LastName.ToLower().Contains(queryForSearch)))
                        && queryForSearch.Length != 0
                    )
                    ||
                    (
                        (e.Score > greaterThanStars
                        && (e.Score >= lowerStar && e.Score < upperStar)
                        && e.Release.Year >= lowerYear
                        && e.Release.Year <= upperYear
                        )
                        && queryForSearch.Length == 0
                    )).Skip(numOfResults*page).Take(numOfResults).OrderByDescending(e=>e.Score).ToList();
            }
            else {
                rezTVShows = niceMoviesContext.TV_Shows.Include(e => e.Casts).ThenInclude(e => e.Actor)
                    .Where(
                    e => (
                        (e.Title.ToLower().Contains(queryForSearch)
                        || e.Description.ToLower().Contains(queryForSearch)
                        || e.Casts.Any(e => e.Actor.Name.ToLower().Contains(queryForSearch))
                        || e.Casts.Any(e => e.Actor.LastName.ToLower().Contains(queryForSearch)))
                        && queryForSearch.Length != 0
                    )
                    ||
                    (
                        (e.Score > greaterThanStars
                        && (e.Score >= lowerStar && e.Score < upperStar)
                        && e.Release.Year >= lowerYear
                        && e.Release.Year <= upperYear
                        )
                        && queryForSearch.Length == 0
                    )).Skip(numOfResults * page).Take(numOfResults).OrderByDescending(e => e.Score).ToList();
            }
            var retVal = new List<TopContent>();
            if (contentType){
                retVal = rezMovies.Select(e => new TopContent
                {
                    Id = e.Id,
                    Title = e.Title,
                    Release = e.Release,
                    Description = e.Description,
                    Score = e.Score,
                    ImageLocation = e.ImageLocation,
                    Actors = e.Casts.Select(e => new ActorView { Name = e.Actor.Name, LastName = e.Actor.LastName }).ToList()
                }).ToList();
            }
            else {
                retVal = rezTVShows.Select(e => new TopContent
                {
                    Id = e.Id,
                    Title = e.Title,
                    Release = e.Release,
                    Description = e.Description,
                    Score = e.Score,
                    ImageLocation = e.ImageLocation,
                    Actors = e.Casts.Select(e => new ActorView { Name = e.Actor.Name, LastName = e.Actor.LastName }).ToList()
                }).ToList();
            }
            return retVal;
        }
    }
}
