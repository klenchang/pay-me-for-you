using System;
using System.Data;

namespace PayMeForYou.Entity.Entities
{
    public class DBReaderHandler
    {
        public bool IsFirstResult { get; set; }
        public Action<IDataReader> Handler { get; set; }
    }
}
