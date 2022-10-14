using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinF_MVP.Interfaces
{
    internal interface IUpdateView
    {
        string FirstName { get; }
        string LastName { get; }
        decimal Score { get; }
        DateTime BirthDate { get; }
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;
    }
}
