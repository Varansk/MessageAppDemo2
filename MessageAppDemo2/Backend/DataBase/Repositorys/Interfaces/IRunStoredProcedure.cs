namespace MessageAppDemo2.Backend.DataBase.Repositorys.Interfaces
{
    internal interface IRunStoredProcedure<Command, Reader> where Command : class, new() where Reader : class
    {
        void ExecuteStoredProcedure(Command cmd, string SPName, string[] ParameterNames, object[] Values);
        Reader ExecuteStoredProcedureAndRead(Command cmd, string SPName, string[] ParameterNames, object[] Values);
    }
}
