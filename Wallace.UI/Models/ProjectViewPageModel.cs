using System;
using System.Collections.Generic;
using Wallace.Common.Models;
namespace Wallace.UI.Models
{
    public class ProjectViewPageModel
    {
        //public string RequestId { get; set; }
        public Project project;
        public ProjectViewPageModel(Project _project)
        {
            project = _project;
        }

        //public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}