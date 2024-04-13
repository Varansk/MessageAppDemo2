using MessageAppDemo2.Backend.DataBase.Connections.DataBaseConnections;
using MessageAppDemo2.Backend.DataBase.Repositorys.Interfaces.RepositoryBase;
using MessageAppDemo2.Backend.ReportSystem.Interfaces;
using MessageAppDemo2.Backend.SystemData.ChangeController;
using MessageAppDemo2.Backend.SystemData.CollectionChangeDedector.ChangeDedector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageAppDemo2.Backend.SystemData.ExtensionClasses.CollectionExtensions;

namespace MessageAppDemo2.Backend.DataBase.Repositorys.AllRepositorys.ReportRepository
{
    public class VirtualDatabaseReportRepository : Repository<ReportBase, Guid>
    {
        private VirtualDatabase virtualDatabase;
        public VirtualDatabaseReportRepository(VirtualDatabase VDB)
        {
            this.virtualDatabase = VDB;
            UpdateVirtualList();
        }




        public override ReportBase GetByID(Guid ID)
        {
            return _Items.Find((I) => I.ReportID == ID);
        }

        public override void SaveAllChanges()
        {

            ReportController reportController = new ReportController();
            virtualDatabase.OpenConnection();
            ListChangesDedector<ReportBase> ChangeDedector = new();

            ChangeInfo<ReportBase> ChangeInfo = ChangeDedector.GetChanges(reportController, virtualDatabase.ReportsList, _Items);

            if (ChangeInfo.IsChanged)
            {
                for (int k = 0; k < ChangeInfo.AddedItems.Count; k++)
                {
                    virtualDatabase.ReportsList.Add(ChangeInfo.AddedItems[k]);
                }

                for (int i = 0; i < ChangeInfo.RemovedItems.Count; i++)
                {
                    virtualDatabase.ReportsList.RemoveAt(virtualDatabase.ReportsList.IndexOf(ChangeInfo.RemovedItems[i], reportController));
                }
                for (int v = 0; v < ChangeInfo.UpdatedItems.Count; v++)
                {
                    virtualDatabase.ReportsList
                        [virtualDatabase.ReportsList.IndexOf(ChangeInfo.UpdatedItems[v], reportController)] = ChangeInfo.UpdatedItems[v];
                }
            }

            virtualDatabase.CloseConnection();
        }

        public override void UpdateVirtualList()
        {
            ReportController reportController = new ReportController();

            virtualDatabase.OpenConnection();
            ListChangesDedector<ReportBase> ChangeDedector = new();

            ChangeInfo<ReportBase> ChangeInfo = ChangeDedector.GetChanges(reportController, _Items, virtualDatabase.ReportsList);

            if (ChangeInfo.IsChanged)
            {
                for (int k = 0; k < ChangeInfo.AddedItems.Count; k++)
                {
                    _Items.Add(ChangeInfo.AddedItems[k]);
                }

                for (int i = 0; i < ChangeInfo.RemovedItems.Count; i++)
                {
                    _Items.RemoveAt(_Items.IndexOf(ChangeInfo.RemovedItems[i], reportController));
                }
                for (int v = 0; v < ChangeInfo.UpdatedItems.Count; v++)
                {
                    _Items[ChangeInfo.UpdatedItems.IndexOf(ChangeInfo.UpdatedItems[v], reportController)] = ChangeInfo.UpdatedItems[v];
                }
            }

            virtualDatabase.CloseConnection();
        }
    }
}
