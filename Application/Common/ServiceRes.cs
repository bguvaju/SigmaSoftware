using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common;

public class ServiceRes
{
    public int code { get; set; }
    public string message { get; set; }
    public string description { get; set; }
}

public class ServiceResData<T> : ServiceRes
{
    public T Data { get; set; }
}

public class ServiceResList<T> : ServiceRes
{
    public List<T> Data { get; set; }
}
