using MessageAppDemo2.Backend.ReportSystem.Interfaces;
using MessageAppDemo2.Backend.SystemData.Enums;
using MessageAppDemo2.Backend.Users.UserData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.Backend.ReportSystem
{
    public record class UserReport : ReportBase
    {
        public User Reported { get; init; }
        public Level ReportLevel { get; init; }
        public string ReportReason { get; init; }
        public UserReport(User Reporter, User Reported, Level ReportLevel, string ReportReason)
        {
            this.Reporter = Reporter;
            this.Reported = Reported;
            this.ReportLevel = ReportLevel;
            this.ReportReason = ReportReason;
        }
    }
}
