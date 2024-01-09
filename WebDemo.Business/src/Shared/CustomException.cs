namespace WebDemo.Business.src.Shared
{
    public class CustomException(int statusCode, string message) : Exception(message)
    {
        public int StatusCode { get; set; } = statusCode;

        public static CustomException NotFound(string message = "Item is not found")
        {
            return new CustomException(404, message);
        }

        public static CustomException BadRequest(string message = "Cannot perform the action")
        {
            return new CustomException(404, message);
        }

        public static CustomException UnAuthorized(string message = "Cannot log in")
        {
            return new CustomException(401, message);
        }
    }
}