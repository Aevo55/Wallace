using System;
using System.Collections.Generic;
using Wallace.Common.Models;
namespace Wallace.UI.Models
{
    public class ProjectEditPageModel
    {
        //public string RequestId { get; set; }
        public Project project;
        public ProjectEditPageModel(Project _project)
        {
            project = _project;
        }

        //public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}