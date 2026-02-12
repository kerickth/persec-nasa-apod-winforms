using System.Text.Json.Serialization;

namespace NasaApod_App.Models
{
    public class ApodItem
    {
        public string Title { get; set; }
        public string Date { get; set; }  
        public string Explanation { get; set; }
        public string Url { get; set; }
        public string HdUrl { get; set; }
        public string Media_Type { get; set; }
    }
    public class MonthItem
    {
        public int Value { get; set; }
        public string Text { get; set; } = "";
    }
}
