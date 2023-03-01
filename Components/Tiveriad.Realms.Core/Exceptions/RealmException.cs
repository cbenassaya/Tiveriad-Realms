namespace Tiveriad.Realms.Core.Exceptions;

public class RealmException:Exception
{
    public RealmException(RealmError error) : base(error.ToString())
    {
        Error = error;
    }
    

    public RealmError Error { get; }
}

public class RealmError
{
    public static RealmError BAD_REQUEST = new("BAD_REQUEST", "BAD REQUEST");
    public static RealmError USER_UNKNOWN = new("USER_UNKNOWN", "USER UNKNOWN");
    public static RealmError INTERNAL_ERROR = new("INTERNAL_ERROR", "INTERNAL ERROR");
    
    private RealmError(string code, string label)
    {
        Code = code;
        Label = label;
    }

    public string Code { get; }

    public string Label { get; }

    public override string ToString()
    {
        return $"{Code} - {Label}";
    }
   
}