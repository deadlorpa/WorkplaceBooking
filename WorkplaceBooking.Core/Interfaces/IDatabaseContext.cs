﻿using System.Data;

namespace WorkplaceBooking.Core.Interfaces
{
    public interface IDatabaseContext
    {
        IDbConnection Connection { get; }

        // TODO: add init database method. needs for not Sqlite dbs!
    }
}
