
using FlightBookingAPI.Data;
using FlightBookingAPI.Domain.Models;
using FlightBookingAPI.Domain.Models.DataSets;
using FlightBookingAPI.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace FlightBookingAPI.Repositories
{
    public class DatabaseFlightDetailsRepository : IFlightDetailsRepository
    {
        private readonly DbContextClass dbContext;
        private readonly IConfiguration configuration;

        public async Task<FlightDetails> Add(FlightDetails flight)
        {
            var result = dbContext.FlightDetails.Add(flight);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public DatabaseFlightDetailsRepository(DbContextClass dbContext,IConfiguration configuration)
        {
            this.dbContext = dbContext;
            this.configuration = configuration;
        }
        public static Expression<Func<FlightDetails, bool>> CreateExpression(string propertyName, object value, SearchParameters.SearchOperators Operator)
        {
            var param = Expression.Parameter(typeof(FlightDetails), "p");
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
                    return Expression.Lambda<Func<FlightDetails, bool>>(binarybody, param);
                
               
            }
         
            return Expression.Lambda<Func<FlightDetails, bool>>(body, param);
        }

       
        public async Task<List<FlightDetails>> Get(GetFlightDetailsQuery Query)
        { 
            AviationstackFlightRepository rep = new AviationstackFlightRepository(configuration);
            List<Expression<Func<FlightDetails, bool>>> filters = new List<Expression<Func<FlightDetails, bool>>>();
            if (Query.apiRequest.SearchParameters.Count>0)
            {
                foreach (SearchParameters param in Query.apiRequest.SearchParameters)
                    filters.Add(CreateExpression(param.FieldName, param.FieldValue, param.Operator));
            }
            var ApiResponse = await rep.Get(Query);
            await dbContext.Database.ExecuteSqlRawAsync("delete from flightdetails;");
            //await _dbContext.BulkInsertAsync(ApiResponse.Select<FlightDetails, Airline>(a => a.airline));
            //await _dbContext.BulkInsertAsync(ApiResponse.Select<FlightDetails, Arrival>(a => a.arrival));
            //await _dbContext.BulkInsertAsync(ApiResponse.Select<FlightDetails, Departure>(a => a.departure));
            ////await _dbContext.BulkInsertAsync(ApiResponse.Select<FlightDetails, Flight>(a => a.flight).Select<Flight,CodeShared>(a=>a.codeshared)) ;
            //await _dbContext.BulkInsertAsync(ApiResponse.Select<FlightDetails, Flight>(a => a.flight));

            await dbContext.BulkInsertAsync(ApiResponse);
            await dbContext.SaveChangesAsync();
            return await LinqExtensions.BuildDynamicQuery(dbContext.FlightDetails.AsQueryable(), filters, Query.apiRequest.PaginationParameters).ToListAsync();

        }

        public async Task<int> BulkInsert(List<FlightDetails> flightDetails)
        {
            dbContext.BulkInsert(flightDetails);
            return await dbContext.SaveChangesAsync();
        }
    }
}
