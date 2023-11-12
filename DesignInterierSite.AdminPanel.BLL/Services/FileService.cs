using Microsoft.AspNetCore.Http;
using System.Net;

namespace DesignInterierSite.AdminPanel.BLL.Services
{
	public class FileService
	{
		/// <summary>
		/// Скачивание файла в папку. Возврашает путь к файлу
		/// </summary>
		/// <param name="uploadedFile"></param>
		/// <returns></returns>
		public static async Task<string?> UploadFileAsync(IFormFile formFile)
		{
			var result = await Task.Run(() =>
			{
				if (formFile != null)
				{
					var filePath = Path.GetTempFileName() + formFile.FileName;

					string extension = Path.GetExtension(formFile.FileName);

					if ((extension == ".png") || (extension == ".jpg") || (extension == ".jpeg"))

					{
						using (var stream = File.Create(filePath))
						{
							formFile.CopyTo(stream);
						}

						WebClient webClient = new WebClient();

						var newName = RandomString(20) + Path.GetExtension(formFile.FileName);

						webClient.DownloadFile(filePath, "wwwroot/images/" + newName);

						var newFilePath = "/images/" + newName;

						return newFilePath;
					}
				}
				
				return default;
			});

			return result;
		}

		private static string RandomString(int length)
		{
			var random = new Random();
			const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
			return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
		}

	}
}
