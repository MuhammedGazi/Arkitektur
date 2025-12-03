using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.ContactDtos;
using Arkitektur.DataAccess.Repositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;

namespace Arkitektur.Business.Services.ContactServices
{
    public class ContactService(IGenericRepository<Contact> _repository,
                                IUnitOfWork _unitOfWork,
                                IValidator<Contact> _validator) : IContactService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateContactDto dto)
        {
            var contact = dto.Adapt<Contact>();
            var validation = await _validator.ValidateAsync(contact);
            if (!validation.IsValid)
            {
                return BaseResult<object>.Fail(validation.Errors);
            }
            await _repository.CreateAsync(contact);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success(contact) : BaseResult<object>.Fail("Create Failed");
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var contact = await _repository.GetByIdAsync(id);
            if (contact is null)
            {
                return BaseResult<object>.Fail("Contact Not Found");
            }
            _repository.Delete(contact);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Delete Failed");
        }

        public async Task<BaseResult<List<ResultContactDto>>> GetAllAsync()
        {
            var contacts = await _repository.GetAllAsync();
            var result = contacts.Adapt<List<ResultContactDto>>();
            return BaseResult<List<ResultContactDto>>.Success(result);
        }

        public async Task<BaseResult<ResultContactDto>> GetByIdAsync(int id)
        {
            var contact = await _repository.GetByIdAsync(id);
            if (contact is null)
            {
                return BaseResult<ResultContactDto>.Fail("Contact Not Found");
            }
            var result = contact.Adapt<ResultContactDto>();
            return BaseResult<ResultContactDto>.Success(result);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateContactDto dto)
        {
            var contact = dto.Adapt<Contact>();
            var validation = await _validator.ValidateAsync(contact);
            if (!validation.IsValid)
            {
                return BaseResult<object>.Fail(validation.Errors);
            }
            _repository.Update(contact);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Update Fail");
        }
    }
}
