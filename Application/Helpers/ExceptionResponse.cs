namespace Application.Helpers
{
    public class ExceptionResponse : Exception
    {
        public EResponse Code { get; set; }

        public ExceptionResponse(EResponse code, string message) :base(message)
        {
            Code = code;
        }
    }
}