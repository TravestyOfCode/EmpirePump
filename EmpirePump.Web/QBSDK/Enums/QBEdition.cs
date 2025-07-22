namespace EmpirePump.Web.QBSDK.Enums;

[Flags]
public enum QBEdition
{
    US = 1 << 0,
    CA = 1 << 1,
    UK = 1 << 2,
    Any = US | CA | UK
}
