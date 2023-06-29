namespace ORIS_Exam_4sem.Middlewares;

public class RequestDetectMiddleware
{
    private readonly RequestDelegate _next;

    public RequestDetectMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        await File.AppendAllTextAsync("request_time.txt", $"{DateTime.Now}\n");
        //await File.WriteAllTextAsync("request_time.txt", DateTime.Now.ToString());
        await _next(httpContext);
    }
}