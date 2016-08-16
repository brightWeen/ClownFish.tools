using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClownFish.Data.Tools.EntityGenerator
{
	//public enum CsClassMemberStyle
	//{
	//	//Field,
	//	AutoProperty,
	//	//ClassicProperty
	//}

	public class CsClassStyle
	{
		//public CsClassMemberStyle MemberStyle { get; set; }
		public bool SupportWCF { get; set; }
		public bool SortByName { get; set; }
	}
}
