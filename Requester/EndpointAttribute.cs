using System;

namespace Requester
{
	[AttributeUsage(AttributeTargets.Class, Inherited = false)]
	public class EndpointAttribute : Attribute
	{
        internal string Route { get; set; }
        public EndpointAttribute(string route)
        {
            Route = route;
        }
    }
}
