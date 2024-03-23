namespace PWSoftware.BaseApplication.Exceptions;

public sealed record ValidationError(string PropertyName, string ErrorMessage);
