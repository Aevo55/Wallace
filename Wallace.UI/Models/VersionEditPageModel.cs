using System;
using System.Collections.Generic;
using Wallace.Common.Models;
namespace Wallace.UI.Models
{
    public class VersionEditPageModel
    {
        public PVersion version;
        public int pid;
        public List<Spec> projectSpecifications = new List<Spec>();

        public List<Spec> NotMetSpecs = new List<Spec>();
    }
}