using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TSIApiWebApp.Core;
using TSIApiWebApp.Data;

namespace TSIApiWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadImagesController : ControllerBase
    {
        private readonly TSIApiWebAppDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public UploadImagesController(TSIApiWebAppDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: api/UploadImages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UploadedImage>>> GetUploadedImages()
        {
            return await _context.UploadedImage.ToListAsync();
        }

        // GET: api/UploadImages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UploadedImage>> GetUploadedImage(int id)
        {
            var uploadedImage = await _context.UploadedImage.FindAsync(id);

            if (uploadedImage == null)
            {
                return NotFound();
            }

            return uploadedImage;
        }

        // PUT: api/UploadImages/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUploadedImage(int id, UploadedImage uploadedImage)
        {
            if (id != uploadedImage.Id)
            {
                return BadRequest();
            }

            _context.Entry(uploadedImage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UploadedImageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /*// POST: api/UploadImages
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<UploadedImage>> PostUploadedImage() //UploadedImage uploadedImage,  
        {
            UploadedImage uploadedImage = new UploadedImage();
            try
            {
                var imageFile = Request.Form.Files[0];
                if (imageFile.Length > 0)
                {
                    var fileName = Path.GetFileName(imageFile.FileName);
                    var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                    var filePath = Path.Combine(uploads, fileName);
                    imageFile.CopyTo(new FileStream(filePath, FileMode.Create));
                    uploadedImage.Name = fileName; // Set the file name
                    uploadedImage.Format = Path.GetExtension(imageFile.FileName);
                    uploadedImage.Size = imageFile.Length;

                    _context.UploadedImage.Add(uploadedImage);
                    await _context.SaveChangesAsync();

                    //return CreatedAtAction("GetUploadedImage", new { id = uploadedImage.Id }, uploadedImage);
                    return new OkObjectResult(new { Name = uploadedImage.Name, Format = uploadedImage.Format, Size = uploadedImage.Size });
                }
                else
                {
                    //return CreatedAtAction("GetUploadedImage", new { error = "" });
                    return new OkObjectResult(new { error="Image is corrupted" });
                }
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    Console.WriteLine(e.Message);
                }

                //return CreatedAtAction("GetUploadedImage", new { error = e.Message });
                return new OkObjectResult(new { error = e.Message });
            }
        }*/

        // POST: api/UploadImages
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public Object PostUploadedImage() //UploadedImage uploadedImage,  
        {
            UploadedImage uploadedImage = new UploadedImage();
            try
            {
                var imageFile = Request.Form.Files[0];
                if (imageFile.Length > 0)
                {
                    var fileName = Path.GetFileName(imageFile.FileName);
                    var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                    var filePath = Path.Combine(uploads, fileName);
                    imageFile.CopyTo(new FileStream(filePath, FileMode.Create));
                    uploadedImage.Name = fileName; // Set the file name
                    uploadedImage.Format = Path.GetExtension(imageFile.FileName);
                    uploadedImage.Size = imageFile.Length;

                    //return CreatedAtAction("GetUploadedImage", new { id = uploadedImage.Id }, uploadedImage);
                    return new OkObjectResult(new { Name = uploadedImage.Name, Format = uploadedImage.Format, Size = uploadedImage.Size });
                }
                else
                {
                    //return CreatedAtAction("GetUploadedImage", new { error = "" });
                    return new OkObjectResult(new { error = "Image is corrupted" });
                }
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    Console.WriteLine(e.Message);
                }

                //return CreatedAtAction("GetUploadedImage", new { error = e.Message });
                return new OkObjectResult(new { error = e.Message });
            }
        }

        // DELETE: api/UploadImages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UploadedImage>> DeleteUploadedImage(int id)
        {
            var uploadedImage = await _context.UploadedImage.FindAsync(id);
            if (uploadedImage == null)
            {
                return NotFound();
            }

            _context.UploadedImage.Remove(uploadedImage);
            await _context.SaveChangesAsync();

            return uploadedImage;
        }

        private bool UploadedImageExists(int id)
        {
            return _context.UploadedImage.Any(e => e.Id == id);
        }
    }
   
}
