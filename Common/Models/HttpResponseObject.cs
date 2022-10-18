namespace Common.Models
{
    using System.Net;

    /// <summary>
    /// The http response definition.
    /// </summary>
    public class HttpResponseObject
    {
        /// <summary>
        /// Gets or sets whether the status code is success ot not.
        /// </summary>
        public bool IsSuccessStatusCode { get; set; }

        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the response value.
        /// </summary>
        public string JsonValue { get; set; }
    }
}
