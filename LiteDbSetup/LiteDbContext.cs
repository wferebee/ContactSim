using ContactSim.Interfaces.ILiteDbSetup;
using LiteDB;
using Microsoft.Extensions.Options;

namespace ContactSim.LiteDbSetup
{
    public class LiteDbContext : ILiteDbContext
    {
        private readonly LiteDbOptions _options;
        public LiteDatabase Database { get; }


        public LiteDbContext(IOptions<LiteDbOptions> options)
        {
            _options = options.Value;
            Database = new LiteDatabase(_options.DatabaseLocation);
        }
    }
}
