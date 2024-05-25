using MessageAppDemo2.Backend.Users.UserData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.Backend.ReportSystem.Interfaces
{
    public abstract record class ReportBase
    {
        public ReportBase() : this(Guid.NewGuid())
        {

        }
        protected ReportBase(Guid ReportID)
        {
            this.ReportID = ReportID;
        }
        public Guid ReportID { get; set; }
        public User Reporter { get; set; }
    }
}
