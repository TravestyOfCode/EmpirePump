using EmpirePump.Web.QBSDK.Enums;

namespace EmpirePump.Web.QBSDK.Types;

public class QBContext
{
    public QBEdition Edition { get; set; }

    public int MajorVersion { get; set; }

    public int MinorVersion { get; set; }

    public QBContext(QBEdition edition = QBEdition.Any, int majorVersion = 13, int minorVersion = 0)
    {
        Edition = edition;
        MajorVersion = majorVersion;
        MinorVersion = minorVersion;
    }
    public QBContext(int majorVersion) : this(QBEdition.Any, majorVersion, 0) { }

    public QBContext(int majorVersion, int minorVersion) : this(QBEdition.Any, majorVersion, minorVersion) { }

    public bool Supports(QBEdition edition, int majorVersion, int minorVersion)
    {
        if (!Edition.HasFlag(edition) || MajorVersion < majorVersion)
        {
            return false;
        }

        return majorVersion == MajorVersion ? MinorVersion >= minorVersion : true;
    }
}