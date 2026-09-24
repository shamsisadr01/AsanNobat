using System;
using System.Collections.Generic;
using System.Text;

namespace AsanNobat.Domain.Common.Exceptions;

public abstract class DomainException : Exception
{
    protected DomainException(string code) : base(code)
    {
        Code = code;
    }

    public string Code { get; }
}
