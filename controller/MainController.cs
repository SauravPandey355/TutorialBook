using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TutorialBook.Models;
namespace TutorialBook.controller
{
    public class MainController : Controller
    {
        private readonly AppDBContext _dbContext;

        public MainController(AppDBContext context)
        {
            _dbContext = context;
        }
        
        [HttpGet]
        [Route($"/show")]
        public object ShowData ()
        {
            var data = _dbContext.TutorialBooks.ToList();
            return data;
        }
        [HttpPost]
        [Route($"/post")]
        public string PostData(TutorialBookInput input)
        {
            try
            {
                var data = new TutorialBookData()
                {
                    Id = Guid.NewGuid(),
                    Name = input?.Name,
                    TutorialBookId = input?.TutorialBookId
                };
                _dbContext.Add(data);
                _dbContext.SaveChanges();
                return "Added Successfully";
            }
            catch (Exception ex)
            {
                return "Exception Occured while adding " + ex.Message;
            }
        }
        [HttpPut]
        [Route($"/update")]
        public string PutData(TutorialBookInput input)
        {
            try
            {
                var data = new TutorialBookData()
                {
                    Id = Guid.Parse(input.Id),
                    Name = input?.Name,
                    TutorialBookId = input?.TutorialBookId
                };
                _dbContext.Update(data);
                _dbContext.SaveChanges();
                return "Updated Successfully";
            }
            catch (Exception ex)
            {
                return "Exception Occured while updating " + ex.Message;
            }
        }
        [HttpDelete]
        [Route($"/delete")]
        public string DeleteData(TutorialBookData input)
        {
            try
            {
                _dbContext.TutorialBooks.Remove(_dbContext.TutorialBooks.FirstOrDefault(e => e.Id == input.Id));
                _dbContext.SaveChanges();
                return "Deleted Successfully";
            }
            catch (Exception ex)
            {
                return "Exception Occured while deleting " + ex.Message;
            }
        }
    }
}
