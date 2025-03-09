﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CKRShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        [HttpPost, DisableRequestSizeLimit]
        [Route("UploadProduct")]
        public async Task<IActionResult> UploadProduct()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();

                var folderName = Path.Combine("Resources", "Images/Products");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("UploadProductMultiProduct")]
        public IActionResult UploadProductMultiProduct()
        {
            try
            {
                var files = Request.Form.Files;
                var folderName = Path.Combine("Resources", "Images/Products");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (files.Any(f => f.Length == 0))
                {
                    return BadRequest();
                }
                foreach (var file in files)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName); //you can add this path to a list and then return all dbPaths to the client if require
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                return Ok("All the files are successfully uploaded.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPost, DisableRequestSizeLimit]
        [Route("UploadUser")]

        public async Task<IActionResult> UploadUser()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();

                var folderName = Path.Combine("Resources", "Images/Users");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }


        [HttpPost, DisableRequestSizeLimit]
        [Route("UploadAdvertisement")]
        public async Task<IActionResult> UploadAdvertisement()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();

                var folderName = Path.Combine("Resources", "Images/Advertisements");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }



        [HttpGet]
        [Route("GetImageProduct")]
        public IActionResult GetImageProduct(string name)
        {
            IEnumerable<string> names = name.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var listImage = names.FirstOrDefault();
            try
            {
                Byte[] b = System.IO.File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Images", @$"Products\{listImage}"));
                return File(b, "image/jpeg");
            }
            catch {
                Byte[] b = System.IO.File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Images", @$"Products\no_image.jpg"));
                return File(b, "image/jpeg");
            }
        }

        [HttpGet]
        [Route("GetImageUser")]
        public IActionResult GetImageUser(string name)
        {
            try
            {
                Byte[] b = System.IO.File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Images", @$"Users\{name}"));
                return File(b, "image/jpeg");
            }
            catch {
                Byte[] b = System.IO.File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Images", @$"Users\no_image.jpg"));
                return File(b, "image/jpeg");
            }
           
        }

        [HttpGet]
        [Route("GetImageAdvertisement")]
        public IActionResult GetImageAdvertisement(string name)
        {
            try
            {
                Byte[] b = System.IO.File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Images", @$"Advertisements\{name}"));
                return File(b, "image/jpeg");
            }
            catch 
            {
                Byte[] b = System.IO.File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Images", @$"Advertisements\no_image.jpg"));
                return File(b, "image/jpeg");
            }
            
        }
    }
}
