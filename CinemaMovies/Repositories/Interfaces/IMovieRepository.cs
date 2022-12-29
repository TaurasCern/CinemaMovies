﻿
using CinemaMovies.Models;

namespace CinemaMovies.Repositories.Interfaces
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<Movie> UpdateAsync(Movie movie);
        Task<bool> ExistAsync(int id);


    }
}
