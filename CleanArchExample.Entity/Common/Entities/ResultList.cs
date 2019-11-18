using CleanArchExample.Entity.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchExample.Entity.Common.Entities
{
    public class ResultList<T> where T : new()
    {
        public ResultList()
        {
            List = new List<T>();
        }

        public string Details { get; set; }
        public string DetailsEnglish { get; set; }
        public List<T> List { get; set; }
        public StatusTypeEnum Status { get; set; }
        public string Message { get; set; }
        public string MessageEnglish { get; set; }
        public int ItemCount { set; get; }
        public int TotalPages { set; get; }

    }
}