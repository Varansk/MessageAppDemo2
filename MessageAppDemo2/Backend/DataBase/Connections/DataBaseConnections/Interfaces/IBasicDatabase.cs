﻿namespace MessageAppDemo2.Backend.DataBase.Connections.DataBaseConnections.Interfaces
{
    public interface IBasicDatabase
    {
        void InitializeConnector();
        void DeactivateConnections();
        void OpenConnection();
        void CloseConnection();
    }
}
