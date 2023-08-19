using AutoMarket.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMarket.Domain.Interfaces
{
	public interface IBaseResponse<T>
	{
		T Data { get; set; }
		string Description { get; set; }
		StatusCode StatusCode { get; set; }
	}
}
