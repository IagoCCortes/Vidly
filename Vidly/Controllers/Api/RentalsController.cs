using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        //POST /api/rentals
        //Current approach is optimistic because the api is only going to be used by the front end
        //if it is ever made public uncomment the edge cases
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateRental(RentalDto rentalDto)
        {
            //if (rentalDto.MovieIds.Count == 0)
            //    return BadRequest("No movie id's have been given.");

            //var customer = _context.Customers.SingleOrDefault(c => c.Id == rentalDto.CustomerId);
            var customer = _context.Customers.Single(c => c.Id == rentalDto.CustomerId);

            //if (customer == null)
            //    return BadRequest("Customer id is not valid.");
            

            var movies = _context.Movies.Where(m => rentalDto.MovieIds.Contains(m.Id)).ToList();

            //if (movies.Count != rentalDto.MovieIds.Count)
            //    return BadRequest("One or more movie id's are invalid.");

            foreach(var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie out of stock");

                movie.NumberAvailable--;
                
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
