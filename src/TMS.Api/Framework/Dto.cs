using System.Collections.Generic;

namespace TMS.Api.Framework
{
    public abstract class Dto
    {
        public IList<Link> Links { get; set; } = new List<Link>();
    }
}