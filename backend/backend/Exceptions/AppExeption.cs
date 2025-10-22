namespace backend.Exxceptions
{
    /// <summary>
    /// Exeption for app errors
    /// </summary>
    public class AppExceeption : Exception
    {
        /// <summary>
        /// Neew instance of class with specific message error
        /// </summary>
        /// <param name="message">Describes the error</param>
        public AppExceeption(string message) : base(message) { }
    }
}