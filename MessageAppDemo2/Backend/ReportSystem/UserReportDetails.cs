using MessageAppDemo2.Backend.ReportSystem.Interfaces;
using MessageAppDemo2.Backend.SystemData.Enums;
using MessageAppDemo2.Backend.Users.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.Backend.ReportSystem
{
    public record class UserReportDetails(User Reported, Level ReportLevel, string ReportReason) : IReport
    {

    }
}
