using System;
using System.Collections.Generic;
using System.Text;

namespace Starbucks.Application.Abstractions
{

    public abstract class GlobalResult 
    {
        public bool IsSuccess { get; set; }
        public bool IsFailure => !IsSuccess;

        public List<Error> Errors { get; set; } = new();
        protected GlobalResult()
        {

        }
    }
    public class Result<T> :GlobalResult
    {
        
        public T? Value { get; set; }
        
        public static Result<T> Success(T value) => new Result<T>
        {
            IsSuccess = true,
            Value = value
        };

        public static Result<T> Failure(params Error[] errors) => new Result<T>
        {
            IsSuccess = false,
            Errors = errors.ToList()
        };
    }
    public class Result : GlobalResult
    {
        
        public static Result Success() => new Result
        {
            IsSuccess = true
        };
        public static Result Failure(params Error[] errors) => new Result
        {
            IsSuccess = false,
            Errors = errors.ToList()
        };

    }
}
