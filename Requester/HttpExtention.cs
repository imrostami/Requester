using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Requester
{
	public static class HttpExtention
	{
		public static async Task LogAsync(this HttpRequestMessage request)
		{
			var sb = new StringBuilder();

			sb.AppendLine($"Method: {request.Method}");
			sb.AppendLine($"RequestUri: {request.RequestUri}");

			sb.AppendLine("Headers:");
			foreach (var header in request.Headers)
			{
				sb.AppendLine($"  {header.Key}: {string.Join(", ", header.Value)}");
			}


			if (request.Content != null)
			{
				sb.AppendLine("Content Headers:");
				foreach (var header in request.Content.Headers)
				{
					sb.AppendLine($"  {header.Key}: {string.Join(", ", header.Value)}");
				}

				var content = await request.Content.ReadAsStringAsync();
				sb.AppendLine($"Body: {content}");
			}


			Console.ForegroundColor = ConsoleColor.Yellow;

			Console.WriteLine("Request Body : ");
			
			Console.ForegroundColor = ConsoleColor.Red;

			Console.WriteLine($"{sb.ToString()}");


		}
		public static async Task LogAsync(this HttpResponseMessage response)
		{
			var sb = new StringBuilder();

			sb.AppendLine($"Status Code: {response.StatusCode} ({(int)response.StatusCode})");
			sb.AppendLine($"Reason Phrase: {response.ReasonPhrase}");

			
			sb.AppendLine("Headers:");
			foreach (var header in response.Headers)
			{
				sb.AppendLine($"  {header.Key}: {string.Join(", ", header.Value)}");
			}

			
			if (response.Content != null)
			{
				sb.AppendLine("Content Headers:");
				foreach (var header in response.Content.Headers)
				{
					sb.AppendLine($"  {header.Key}: {string.Join(", ", header.Value)}");
				}

				var content = await response.Content.ReadAsStringAsync();
				sb.AppendLine($"Body: {content}");
			}



			Console.ForegroundColor = ConsoleColor.Yellow;
			
			Console.WriteLine("Response Body : ");
			
			Console.ForegroundColor = ConsoleColor.Red;
			
			Console.WriteLine($" {sb.ToString()}");
		}
	}
}
