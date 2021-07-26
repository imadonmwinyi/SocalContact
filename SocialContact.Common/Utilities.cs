using Microsoft.AspNetCore.Mvc.ModelBinding;
using SocialContact.Data.DTOs;
using System;
using System.Collections.Generic;

namespace SocialContact.Common
{
    public class Utilities
    {
        public static ResponseDto<T> CreateResponse<T>(string message, ModelStateDictionary errs, T data)
        {
            
            var errors = new Dictionary<string, string>();
            if (errs != null)
            {
                foreach (var err in errs)
                {
                    var counter = 0;
                    var key = err.Key;
                    var errVals = err.Value;
                    foreach (var errMsg in errVals.Errors)
                    {
                        errors.Add($"{(counter + 1)} - {key}", errMsg.ErrorMessage);
                        counter++;
                    }
                }
            }

            var response = new ResponseDto<T>
            {
                Message = message,
                Errs = errors,
                Data = data
            };

            return response;
        }
    }
}
