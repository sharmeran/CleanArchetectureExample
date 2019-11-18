using CleanArchExample.Entity.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchExample.Entity.Common.Entities
{
    public class SearchEntity<T> where T : new()
    {
        public SearchEntity()
        {
            Entity = new T();
        }

        public T Entity { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public string Query { get; set; }
        public string Details { get; set; }
        public string DetailsEnglish { get; set; }
        public StatusTypeEnum Status { get; set; }
        public string Message { get; set; }
        public string MessageEnglish { get; set; }
    }
}
