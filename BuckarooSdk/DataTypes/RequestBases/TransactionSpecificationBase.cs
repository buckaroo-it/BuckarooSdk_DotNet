using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuckarooSdk.DataTypes.RequestBases
{
	public class TransactionSpecificationBase : IRequestBase
	{
		public List<SpecificationRequestedService> Services { get; set; }

		public TransactionSpecificationBase()
		{
			this.Services = new List<SpecificationRequestedService>();
		}

		public TransactionSpecificationBase AddService(string service, int version = 1)
		{
			var serviceToBeAdded = new SpecificationRequestedService()
			{
				Name = service,
				Version = version,
			};

			this.Services.Add(serviceToBeAdded);

			return this;
		}

		public TransactionSpecificationBase AddService(SpecificationRequestedService addedService)
		{
			this.Services.Add(addedService);

			return this;
		}
	}
}
