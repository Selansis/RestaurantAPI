using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;

namespace RestaurantAPI.Services
{
    public interface IRestaurantService
    {
        RestaurantDto Get(int id);
        IEnumerable<RestaurantDto> GetAll();
        void Create(CreateRestaurantDto dto);

    }
    public class RestaurantService
    {
        private RestaurantDbContext _dbContext;
        private IMapper _mapper;

        public RestaurantService(RestaurantDbContext dbContext, IMapper mapper) 
        { 
            _dbContext=dbContext;
            _mapper=mapper;
        }
        public RestaurantDto GetById(int id)
        { 
            var restaurant = _dbContext
                .Restaurants
                .Include(r => r.Adress)
                .Include(r => r.Dishes)
                .FirstOrDefault(r => r.Id == id);
            if(restaurant == null)
            {
                return null;
            }
            var result = _mapper.Map<RestaurantDto>(restaurant);
            return result;
        }
        public IEnumerable<RestaurantDto> GetAll()
        {
            var restaurants = _dbContext
                .Restaurants
                .Include(r => r.Adress)
                .Include(r => r.Dishes)
                .ToList();

            var restaurantsDtos = _mapper.Map<List<RestaurantDto>>(restaurants);
            return restaurantsDtos;
        }

        public void Create(RestaurantDto dto)
        {
            var restaurant = _mapper.Map<Restaurant>(dto);
            _dbContext.Restaurants.Add(restaurant);
            _dbContext.SaveChanges();
        }



    }
}
