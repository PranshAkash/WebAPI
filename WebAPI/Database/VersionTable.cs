using FluentMigrator.Runner.VersionTableInfo;

namespace Database
{
    [VersionTableMetaData]
    public class VersionTable : DefaultVersionTableMetaData
    {
        public override string TableName => "version";
    }
}
