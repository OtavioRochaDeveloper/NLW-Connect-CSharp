using FluentValidation.Results;
using TechLibrary.Api.Domain.Entities;
using TechLibrary.Api.infraestructure.DataAccess;
using TechLibrary.Api.infraestructure.Security.Cryptography;
using TechLibrary.Api.infraestructure.Security.Tokens.Access;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;
using TechLibrary.Exception;

namespace TechLibrary.Api.UseCases.Users.Register
{
    public class RegisterUserUseCase
    {
        private object dbContext;

        public ResponseRegisteredUserJson Execute(RequestUserJson request)
        {

            Validate(request);

            var cryptography = new BCryptAlgorithm();
            var entity = new User
            {
                Email = request.Email,
                Name = request.Name,
                Password = cryptography.HashPassword(request.Password),
            };

            var dbContext = new TechLibraryDbContext();

            dbContext.Users.Add(entity);
            dbContext.SaveChanges();

            var tokenGenerator = new JwtTokenGenerator();

            return new ResponseRegisteredUserJson
            {
                Name = entity.Name,
                AccessToken = tokenGenerator.Generate(entity)
            };
           
        }

        private void Validate(RequestUserJson request)
        {
            var Validator = new RegisterUserValidator();

            var result = Validator.Validate(request);

            var existUserWithEmail = dbContext.Users.Any(user => user.Email.Equals(request.Email));
            if (existUserWithEmail)
                result.Errors.Add(new ValidationFailure("Email", "E-mail ja registrado na plataforma"));

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
