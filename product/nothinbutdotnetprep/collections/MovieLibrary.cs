using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        IList<Movie> movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            this.movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            foreach (var movie in movies)
            {
                yield return movie;
            }
        }

        public void add(Movie movie)
        {
            if (!movies.Contains(movie))
                movies.Add((movie));
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending
        {
            get
            {
                List<Movie> result = new List<Movie>(movies);
                result.Sort(new MovieTitleComparer(ListSortDirection.Descending));
                return result;
            }
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            foreach (Movie movie in movies)
            {
                if (movie.production_studio == ProductionStudio.Pixar)
                    yield return movie;
            }
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            foreach (Movie movie in movies)
            {
                if (movie.production_studio == ProductionStudio.Pixar || movie.production_studio == ProductionStudio.Disney)
                    yield return movie;
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending
        {
            get
            {
                List<Movie> result = new List<Movie>(movies);
               result.Sort(new MovieTitleComparer(ListSortDirection.Ascending));
                return result;
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            List<Movie> result = new List<Movie>(movies);
            result.Sort(new MovieStudioRankingAndYearPublishedComparer());
            return result;
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            foreach (Movie movie in movies)
            {
                if (movie.production_studio != ProductionStudio.Pixar)
                    yield return movie;
            }
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            foreach (Movie movie in movies)
            {
                if (movie.date_published.Year > year)
                    yield return movie;
            }
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            foreach (Movie movie in movies)
            {
                if (movie.date_published.Year <= endingYear && movie.date_published.Year >= startingYear)
                    yield return movie;
            }
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            foreach (Movie movie in movies)
            {
                if (movie.genre == Genre.kids)
                    yield return movie;
            }
        }

        public IEnumerable<Movie> all_action_movies()
        {
            foreach (Movie movie in movies)
            {
                if (movie.genre == Genre.action)
                    yield return movie;
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            List<Movie> result = new List<Movie>(movies);
            result.Sort(new MoviePublishDateComparer(ListSortDirection.Descending));
            return result;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            List<Movie> result = new List<Movie>(movies);
            result.Sort(new MoviePublishDateComparer(ListSortDirection.Ascending));
            return result;
        }
    }
}