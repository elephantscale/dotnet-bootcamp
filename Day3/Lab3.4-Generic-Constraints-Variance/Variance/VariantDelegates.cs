namespace Lab3._4_Generic_Constraints_Variance.Variance;

public static class VariantDelegates
{
    public static (string funcResult, string actionResult) Run()
    {
        // We'll capture text here from the Action delegate.
        string captured = "";

        // FUNC VARIANCE (covariant return):
        // Func<TIn, TResult> is covariant in TResult.
        // You can assign a Func<string, string> to a Func<string, object>.
        Func<string, string> strToStr = s => $"[{s.ToUpper()}]";
        Func<string, object> strToObj = strToStr; // covariance on TResult

        // ACTION VARIANCE (contravariant parameter):
        // Action<T> is contravariant in T.
        // You can assign an Action<object> to an Action<string>.
        Action<object> objAction = o => captured = $"Handled: {o}";
        Action<string> strAction = objAction; // contravariance on T

        // Exercise both delegates
        strAction("message");
        var funcResult = (string)strToObj("hello"); // cast from object variable to string value

        return (funcResult, captured);
    }
}