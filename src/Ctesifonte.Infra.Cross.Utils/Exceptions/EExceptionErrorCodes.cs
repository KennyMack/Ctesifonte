using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ctesifonte.Infra.Cross.Utils.Exceptions
{
    public enum EExceptionErrorCodes
    {
        UnhandledException = 900,
        InvalidRequest = 997,
        UnauthorizedRequest = 998,
        InvalidEstablishmentKey = 999,
        ValidationError = -10000,
        RegisterNotFound = -15000,
        RegisterChild = -16000,
        InsertSQLError = -20001,
        UpdateSQLError = -20002,
        DeleteSQLError = -20003,
        SaveSQLError = -20004,
        SQLCommandError = -20005,
    }
}
