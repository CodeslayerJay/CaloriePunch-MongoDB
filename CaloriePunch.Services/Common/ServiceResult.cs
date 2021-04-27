using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaloriePunch.Services.Common
{
    public class ServiceResult
    {
        public ServiceResult()
        {
            Errors = new List<string>();
            ResultCollection = new List<IServiceResultDTO>();
        }

        public List<string> Errors { get; set; }
        public bool Success => Errors.Any() == false;

        public List<IServiceResultDTO> ResultCollection { get; set; }

        /// <summary>
        /// Get first or default IServiceResultDTO from the ResultCollection
        /// </summary>
        public IServiceResultDTO Result => ResultCollection.FirstOrDefault();
    }
}
