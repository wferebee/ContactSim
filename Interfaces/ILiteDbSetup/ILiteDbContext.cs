using LiteDB;

namespace ContactSim.Interfaces.ILiteDbSetup
{
    public interface ILiteDbContext
    {
        LiteDatabase Database { get; }
    }
}
