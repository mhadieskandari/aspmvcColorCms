using AutoMapper;
using CMS_Golbarg.Dtos;
using CMS_Golbarg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace CMS_Golbarg.Controllers.api
{
    public class ContentsController : ApiController
    {
        ApplicationDbContext _content;


        public ContentsController()
        {
            _content = new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _content.Dispose();
        }

        public IEnumerable<ContentDto> GetContents()
        {
            return _content.Contents.ToList().Select(Mapper.Map<Content,ContentDto>);            
        }

        public IHttpActionResult GetContents(int id)
        {
            var content =_content.Contents.SingleOrDefault(m => m.ID == id);
            if (content == null)
            {
                return NotFound();
            }
            return Ok( Mapper.Map<Content,ContentDto>(content));
        }

        [HttpPost]
        public IHttpActionResult CreateContents(ContentDto contentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var content = Mapper.Map<ContentDto, Content>(contentDto);
            _content.Contents.Add(content);
            _content.SaveChanges();
            contentDto.ID = content.ID;

            return Created(new Uri(Request.RequestUri+"/"+content.ID),contentDto);


        }

        [HttpPut]
        public void UpdateContents(int id,ContentDto contentDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var contentindb = _content.Contents.SingleOrDefault(m => m.ID == id);

            if (contentindb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Mapper.Map<ContentDto, Content>(contentDto, contentindb);

            _content.SaveChanges();





        }

        [HttpDelete]
        public void DeleteContents(int id)
        {
            var contentindb = _content.Contents.SingleOrDefault(m => m.ID == id);

            if (contentindb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _content.Contents.Remove(contentindb);
            _content.SaveChanges();
        }




    }
}
