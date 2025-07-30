namespace EmpirePump.Web.QBSDK;

public static class ListExtensions
{
    public static void TryAdd<T>(this List<T> list, T? value)
    {
        if (value != null)
        {
            list.Add(value);
        }
    }
}
