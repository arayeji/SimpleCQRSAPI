
using FlightBookingAPI.Data;
using FlightBookingAPI.Domain.Models;
using FlightBookingAPI.Domain.Models.DataSets;
using FlightBookingAPI.Queries;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace FlightBookingAPI.Repositories
{
    public class DatabaseAirportsRepository : IAirportsRepository
    {
        private readonly DbContextClass dbContext;
        private readonly IConfiguration configuration;

        public async Task<FlightDetails> Add(FlightDetails flight)
        {
            var result = dbContext.FlightDetails.Add(flight);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public DatabaseAirportsRepository(DbContextClass dbContext,IConfiguration configuration)
        {
            this.dbContext = dbContext;
            this.configuration = configuration;
        }

        
        public static Expression<Func<Airport, bool>> CreateExpression(string propertyName, object value, SearchParameters.SearchOperators Operator)
        {
            var param = Expression.Parameter(typeof(Airport), "p");
            var member = Expression.Property(param, propertyName);
            var constant = Expression.Constant(value);
            var body = Expression.Equal(member, constant);
            switch (Operator)
            {
                case SearchParameters.SearchOperators.Equal:
                    break;
                case SearchParameters.SearchOperators.LessThan:
                    body = Expression.LessThan(member, constant);
                    break;
                case SearchParameters.SearchOperators.GreaterThan:
                    body = Expression.GreaterThan(member, constant);
                    break;
                case SearchParameters.SearchOperators.LessThanOrEqual:
                    body = Expression.LessThanOrEqual(member, constant);
                    break;
                case SearchParameters.SearchOperators.GreaterThanOrEqual:
                    body = Expression.GreaterThanOrEqual(member, constant);
                    break;
                case SearchParameters.SearchOperators.Like:
                    var propertyType = ((PropertyInfo)member.Member).PropertyType;
                    var binarybody = Expression.Call(typeof(Enumerable), "Contains", new[] { propertyType }, constant, member);
                    return Expression.Lambda<Func<Airport, bool>>(binarybody, param);


            }

            return Expression.Lambda<Func<Airport, bool>>(body, param);
        }

        public async Task<List<Airport>> Get(GetAirportsQuery Query)
        {
            AviationStackAirportsRepository rep = new AviationStackAirportsRepository(configuration);

            List<Expression<Func<Airport, bool>>> filters = new List<Expression<Func<Airport, bool>>>();
            if (Query.apiRequest.SearchParameters.Count > 0)
            {
                foreach (SearchParameters param in Query.apiRequest.SearchParameters)
                    filters.Add(CreateExpression(param.FieldName, param.FieldValue, param.Operator));
            }

            await dbContext.Database.ExecuteSqlRawAsync("delete from airports;");
            var ApiResponse = await rep.Get(Query);
            
            await dbContext.BulkInsertAsync(ApiResponse);
            await dbContext.SaveChangesAsync();
            return await LinqExtensions.BuildDynamicQuery(dbContext.Airports.AsQueryable(), filters, Query.apiRequest.PaginationParameters).ToListAsync();

        }

        public async Task<int> BulkInsert(List<Airport> flightDetails)
        {
            dbContext.BulkInsert(flightDetails);
            return await dbContext.SaveChangesAsync();
        }
    }
}
