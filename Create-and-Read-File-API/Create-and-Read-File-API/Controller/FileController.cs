using Microsoft.AspNetCore.Mvc;

namespace Create_and_Read_File_API.Controllers
{
    public class FileController : Controller
    {
        [HttpGet("/file")]
        [Route("/")]
        public IActionResult Index()
        {
            // fetch the current directory path
            string currentDirectory = Directory.GetCurrentDirectory();
            string folderName = "TextHolder";

            // combine the current directory with the folder name
            string folderPath = Path.Combine(currentDirectory, folderName);

            // check if the folder exists, if not create it
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string fileName = "Text.txt";
            // combine the folder path with the file name
            string filePath = Path.Combine(folderPath, fileName);
            // check if the file exists, if not create it and write some text
            System.IO.File.WriteAllText(filePath, "Hello .NET Devlopers. Here we go\n");
            return Content(System.IO.File.ReadAllText(filePath));
        }
    }
}
