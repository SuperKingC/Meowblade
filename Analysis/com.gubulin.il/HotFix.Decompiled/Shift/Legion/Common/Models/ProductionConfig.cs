using System.Collections.Generic;
using System.Linq;
using Shift.Legion.ClientApi.Protocol.Building;

namespace Shift.Legion.Common.Models;

public class ProductionConfig
{
	public List<string> ProductList = new List<string>();

	public int Workers;

	public ProductionConfig Clone()
	{
		ProductionConfig productionConfig = new ProductionConfig
		{
			Workers = Workers
		};
		if (ProductList != null)
		{
			foreach (string product in ProductList)
			{
				productionConfig.ProductList.Add(product);
			}
		}
		return productionConfig;
	}

	public Shift.Legion.ClientApi.Protocol.Building.ProductionConfig ToProto()
	{
		return new Shift.Legion.ClientApi.Protocol.Building.ProductionConfig
		{
			ProductList = ProductList.ToList(),
			Workers = Workers
		};
	}
}
