using Redis.OM.Modeling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KisTechTest.Models
{
    [Document(StorageType = StorageType.Json)]
    internal class WordRedis
    {
        [RedisIdField]
        public Ulid MyProperty { get; set; }
        [Indexed]
        public string? Word { get; set; }
        [Indexed]
        public string? Translation { get; set; }
    }
}
