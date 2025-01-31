﻿using EasyLOB.Library;
using System;

namespace EasyLOB.Persistence
{
    public static partial class ZOperationResultExtensions
    {
        public static void ParseExceptionRedis(this ZOperationResult operationResult, Exception exception)
        {
            operationResult.ParseException(exception);
        }
    }
}