using System;
using System.Collections.Generic;
using FFImageLoading.Helpers.Exif;

namespace DrRobo.Modules.Home.Models
{
    public class NewsModel
    {
        public string MainImage { get; set; }

        public List<Tags> Tags { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }
    }

    public class Tags
    {
        public string Text { get; set; }
    }
}