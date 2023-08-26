namespace Application.Helpers
{
    public class ResponseException : Exception
    {
        public EResponse Code { get; set; }

        public ResponseException(EResponse code, string message) :base(message)
        {
            Code = code;
        }
    }
}