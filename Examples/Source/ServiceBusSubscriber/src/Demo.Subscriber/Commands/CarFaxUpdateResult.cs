namespace Demo.Subscriber.Commands
{
    /// <summary>
    /// Response to an asynchronous sent command used to return
    /// the response on a reply queue at a later time. 
    /// </summary>
    public class CarFaxUpdateResult
    {
        public string ReportId { get; set; }
        public string ReportUrl { get; set; }
        public string ResultStatus { get; set; }
    }
}
