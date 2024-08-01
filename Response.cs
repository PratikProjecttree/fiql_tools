namespace fiql_tools
{
    public class Response<T>
    {
        public bool Succeeded { get; set; }

        public T Data { get; set; }

        public string Message { get; set; }

        public Response(T data)
        {
            Succeeded = true;
            Message = string.Empty;
            Data = data;
        }
    }
}
