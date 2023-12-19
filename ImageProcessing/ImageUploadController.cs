using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

namespace ImageProcessing
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageUploadController : ControllerBase
    {
        public static IWebHostEnvironment _environment;
        public ImageUploadController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost]
        public Task<common> Post([FromForm] FileUploadAPI objFile)
        {
            common obj = new common();
            obj.LstCustomer = new List<Customer>();
            obj._fileAPI = new FileUploadAPI();
            try
            {
                obj.LstCustomer = new List<Customer>() { new Customer() { CustName = objFile.Customers,CustID = 1,CustomerType ="vendor"} };
                //List<Customer> list = JsonConvert.DeserializeObject<List<Customer>>(objFile.Customers);
                //obj.LstCustomer = list;
                obj._fileAPI.ImgID = objFile.ImgID;
                obj._fileAPI.ImgName = "\\Upload\\" + objFile.files.FileName;
                if (objFile.files.Length > 0)
                {
                    if (!Directory.Exists(_environment.ContentRootPath + "\\Upload"))
                    {
                        Directory.CreateDirectory(_environment.ContentRootPath + "\\Upload\\");
                    }
                    using (FileStream filestream = System.IO.File.Create(_environment.ContentRootPath + "\\Upload\\" + objFile.files.FileName))
                    {
                        objFile.files.CopyTo(filestream);
                        filestream.Flush();
                        //  return "\\Upload\\" + objFile.files.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return Task.FromResult(obj);
        }
    }
}



