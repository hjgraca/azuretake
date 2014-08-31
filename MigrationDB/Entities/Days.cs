using System;

namespace MigrationDB.Entities
{
    [Flags]
    public enum Days
    {
        Mon = 1,
        Tue = 1 << 1, 
        Wed = 1 << 2, 
        Thu = 1 << 3, 
        Fri = 1 << 4,
        Sat = 1 << 5,
        Sun = 1 << 6
    };
}