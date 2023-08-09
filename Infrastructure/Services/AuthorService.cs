using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using DTO.DataModels;
using Infrastructure.Models;
using Infrastructure.Repositories;
using Synaplic.UniRH.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{

    public interface IAuthorService
    {
        Task<List<Author>> GetAuthors();
        Task<Result<int>> AddAuthor(Author author);
    }
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork<int> _unitOfWork;
        public AuthorService(IUnitOfWork<int> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<int>> AddAuthor(Author author)
        {
            try
            {
                await _unitOfWork.Repository<Author>().AddAsync(author);

                var res = await _unitOfWork.Commit();

                return await Result<int>.SuccessAsync(res);
            } catch (Exception ex) {

                return await Result<int>.FailAsync(ex.Message);
            }

        }

        public async  Task<List<Author>> GetAuthors() {
           var authors = await _unitOfWork.Repository<Author>().GetAllAsync();
          
            return  authors; 

    }
}
}
