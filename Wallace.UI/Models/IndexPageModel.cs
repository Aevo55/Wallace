using System;
using System.Collections.Generic;
using Wallace.Common.Models;
namespace Wallace.UI.Models
{
    public class IndexPageModel
    {
        //public string RequestId { get; set; }
        public List<Project> Projects = new List<Project>();

        //public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}