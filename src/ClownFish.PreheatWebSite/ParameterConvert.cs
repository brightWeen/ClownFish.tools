//using System;
//using System.Collections.Generic;
//using System.Security.Cryptography;
//using System.Text;

//namespace ClownFish.PreheatWebSite.Script
//{
//	public class ParameterConvert
//	{
//		public void Execute(Dictionary<string, string> parameters)
//		{
//			// 计算密码的MD5值
//			byte[] passwordBytes = Encoding.Default.GetBytes(parameters["password"]);
//			byte[] md5Bytes = (new MD5CryptoServiceProvider()).ComputeHash(passwordBytes);
//			string md5Password = BitConverter.ToString(md5Bytes).Replace("-", "").ToLower();

//			// 构造登录表单的提交数据，并写回到字典中供脚本中读取
//			string usernameData = System.Web.HttpUtility.UrlEncode(parameters["username"]);
//			parameters["loginPostData"] = string.Format("u={0}&p={1}", usernameData, md5Password);
//		}
//	}
//}
