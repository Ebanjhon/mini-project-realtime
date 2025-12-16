public class ResponseData<T>
{
    public bool Success { get; set; } = true; // Thành công hay không
    public string Message { get; set; } = "OK";
    public T? Data { get; set; }

    private int? _statusCode; // Nếu muốn override thủ công

    public int StatusCode
    {
        get
        {
            // Nếu đã set thủ công thì dùng luôn
            if (_statusCode.HasValue) return _statusCode.Value;

            // Nếu Success = true => 200, nếu false => 400
            return Success ? 200 : 400;
        }
        set => _statusCode = value; // cho phép override nếu cần
    }
}
