using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    // Hem data içerecek hem de mesaj ve ya başarı döndürecek o sebeple IResult inharite ettik.
    public interface IDataResult<T>:IResult
    {
        T Data { get; }
    }
}
