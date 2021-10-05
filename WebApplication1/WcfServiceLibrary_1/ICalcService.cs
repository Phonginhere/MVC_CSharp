using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Calc
{
	[ServiceContract]
	public interface ICalcService
	{
		[OperationContract]
		double Add(double n1, double n2);
		[OperationContract]
		double Subtract(double n1, double n2);
		[OperationContract]
		double Multiply(double n1, double n2);
		[OperationContract]
		double Divide(double n1, double n2);
	}
}
