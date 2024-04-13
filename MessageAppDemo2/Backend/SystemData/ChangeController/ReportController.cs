using MessageAppDemo2.Backend.ReportSystem.Interfaces;
using MessageAppDemo2.Backend.SystemData.ChangeController.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.Backend.SystemData.ChangeController
{
    public class ReportController : BaseController<ReportBase>
    {
        public override Func<ReportBase, ReportBase, bool> AddRemoveController
        {
            get
            {
                Func<ReportBase, ReportBase, bool> result = (Report1, Report2) =>
                {
                    return Report1.ReportID == Report2.ReportID;
                };

                return result;
            }
        }

        public override Func<ReportBase, ReportBase, bool> UpdateController
        {
            get
            {
                Func<ReportBase, ReportBase, bool> result = (Report1, Report2) =>
                {

                    bool A = Report1.ReportID == Report2.ReportID;
                    bool b = Report1.Reporter.UserGUİD == Report2.Reporter.UserGUİD;

                    return A && !(b);
                };

                return result;
            }
        }
    }
}
