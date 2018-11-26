using System;
using System.Collections.Generic;
using Wallace.Common.Models;
namespace Wallace.UI.Models
{
    public class TeamEditPageModel
    {
        //public string RequestId { get; set; }
        public Team team= new Team();
        public bool isNew = false;
        //public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}