using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClownFish.Data.Tools.EntityGenerator
{
	public class Field : Entity
	{
		public virtual string Name { get; set; }
		public virtual string DataType { get; set; }
		public virtual int Length { get; set; }
		public virtual int scale { get; set; }
		public virtual int Precision { get; set; }
		public virtual bool Identity { get; set; }
		public virtual bool Nullable { get; set; }
		public virtual bool Computed { get; set; }
		public virtual bool IsPersisted { get; set; }
		public virtual string DefaultValue { get; set; }
		public virtual string Formular { get; set; }
		public virtual int SeedValue { get; set; }
		public virtual int IncrementValue { get; set; }

		public string GetCsDataType()
		{
			return DataTypeHelper.SqlTypeToCsType(this.DataType) +
				(this.Nullable ? (DataTypeHelper.IsCsNullableType(this.DataType) ? "?" : "") : "");
		}
	}


	

}
