using CMS.API.Models;
using CMS.API.Services.ServicesInterface;
using CMS.DATA.DTO;
using CMS.DATA.Entities;
using CMS.DATA.Repository.RepositoryInterface;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace CMS.API.Services
{
    public class QuizesService : IQuizesService
    {
        private readonly IQuizesRepo _quizesRepo;

        public QuizesService(IQuizesRepo quizesRepo)
        {
            _quizesRepo = quizesRepo;
        }

        public async Task<ResponseDto<Quiz>> AddQuiz(AddQuizDto addQuizDto)
        {
            var response = new ResponseDto<Quiz>();
            try
            {
                var NewQuiz = new Quiz
                {
                    AddedById = addQuizDto.AddedById,
                    AnswerType = addQuizDto.AnswerType,
                    Instruction = addQuizDto.Instruction,
                    Question = addQuizDto.Question,
                    LessonId = addQuizDto.LessonId,
                    DateCreated = DateTime.Now,
                    PreferedAnswer = addQuizDto.PreferedAnswer,
                };

                var QuizResult = await _quizesRepo.AddQuiz(NewQuiz);
                if (QuizResult != null)
                {
                    response.StatusCode = 200;
                    response.DisplayMessage = "You have successfully added a quiz";
                    response.Result = QuizResult;
                    return response;
                }

                response.ErrorMessages = new List<string> { "Error trying to add a quiz" };
                response.StatusCode = 404;
                response.Result = null;
                return response;
            }
            catch (Exception)
            {
                response.ErrorMessages = new List<string> { "Error trying to add a quiz" };
                response.StatusCode = 400;
                return response;
            }
        }
        
        public async Task<ResponseDto<Quiz>> UpdateQuiz(string Id, [FromBody] UpdateDto updateDto)
        {
            var response = new ResponseDto<Quiz>();
            try
            {

                var NewQuiz = await _quizesRepo.GetQuizByIdAsync(Id);
                if (NewQuiz != null)
                {
                    NewQuiz.AnswerType = updateDto.AnswerType;
                    NewQuiz.DateUpdated = DateTime.Now;
                    NewQuiz.Instruction = updateDto.Instruction;
                    NewQuiz.Question = updateDto.Question;
                    NewQuiz.PreferedAnswer = updateDto.PreferedAnswer;
                    NewQuiz.IsDeleted = updateDto.IsDeleted;

                };

                var QuizResult = await _quizesRepo.UpdateQuiz(NewQuiz);

                if (QuizResult != null)
                {
                    response.StatusCode = 200;
                    response.DisplayMessage = "You have successfully updated quiz";
                    response.Result = QuizResult;
                    return response;
                }

                response.ErrorMessages = new List<string> { "Error trying to update a quiz" };
                response.StatusCode = 404;
                response.Result = null;
                return response;
            }
            catch
            {
                response.ErrorMessages = new List<string> { "Error trying to update a quiz" };
                response.StatusCode = 400;
                return response;
            }
        }

        public async Task<ResponseDto<bool>> DeleteQuiz(string Id)
        {
            var response = new ResponseDto<bool>();

            try
            {
                var GetQuiz = await _quizesRepo.GetQuizByIdAsync(Id);
                if (GetQuiz != null)
                {
                    var DeleteQuiz = _quizesRepo.DeleteQuizAsync(GetQuiz);

                    response.StatusCode = 200;
                    response.DisplayMessage = "Quiz deleted successfully";
                    response.Result = true;
                    return response;
                }
                response.ErrorMessages = new List<string> { "Error trying to update a quiz" };
                response.StatusCode = 404;
                response.Result = false;
                return response;
            }
            catch
            {
                response.ErrorMessages = new List<string> { "Error trying to update a quiz" };
                response.StatusCode = 400;
                return response;
            }
        }



        public async Task<ResponseDto<Quiz>> GetByLesson(string lessonId)
        { 
            var lesson = await _quizesRepo.GetQuizByLessonAsync(lessonId);
            var response = new ResponseDto<Quiz>();
            if (lesson == null)
            {
                response.StatusCode = 404;
                response.ErrorMessages = new List<string> { "Lesson not Found" };
            }
            else
            {
                response.StatusCode = 200;
                response.DisplayMessage = "Operation Successful";
                response.Result = (Quiz)lesson;
                
            }

           return response;
          
        }

        public async Task<ResponseDto<Quiz>> GetByUser(string userId)
        {
            var getUser = await _quizesRepo.GetQuizByUserAsync(userId);
            if (getUser == null)
                return new ResponseDto<Quiz> 
                { 
                    StatusCode = 404, 
                    ErrorMessages = new List<string> { "User not Found" } 
                };

            return new ResponseDto<Quiz>
            {
                StatusCode = 200,
                DisplayMessage = "Operation Successful",
                Result = (Quiz)getUser
            };
     
        }

        public async Task<IEnumerable<Quiz>> GetQuizAysnc()
        {
            var result = await _quizesRepo.GetAllQuizAsync();
            if (result != null && result.Any())
            {
                return result;
            }
            
            return null;


        }

        public async Task<ResponseDto<Quiz>> GetQuizByIdAsync(string id)
        {
            var quizId = await _quizesRepo.GetQuizByIdAsync(id);

            if (quizId == null)
                return new ResponseDto<Quiz> 
                { 
                    StatusCode = 404, 
                    ErrorMessages = new List<string> { "Quiz not found" }
                };

            return new ResponseDto<Quiz> 
            { 
                StatusCode = 200, 
                DisplayMessage = "Operation Successful",
                Result = new Quiz
                {
                    Question = quizId.Question,
                    AnswerType = quizId.AnswerType,
                    PreferedAnswer = quizId.PreferedAnswer,
                    AddedById = quizId.AddedById,
                    DateCreated = quizId.DateCreated,
                    DateUpdated = quizId.DateUpdated
                }
            };
        }
    }
}
