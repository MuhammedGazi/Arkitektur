using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.BannerDtos;
using Arkitektur.DataAccess.Repositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;

namespace Arkitektur.Business.Services.BannerServices
{
    public class BannerService(IGenericRepository<Banner> _bannerRepository,
                               IUnitOfWork _unitOfWork,
                               IValidator<Banner> _validator)
                               : IBannerService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateBannerDto dto)
        {
            var banner = dto.Adapt<Banner>();
            var validation = await _validator.ValidateAsync(banner);
            if (!validation.IsValid)
            {
                return BaseResult<object>.Fail(validation.Errors);
            }
            await _bannerRepository.CreateAsync(banner);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success(banner) : BaseResult<object>.Fail("Create Failed");
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var banner = await _bannerRepository.GetByIdAsync(id);
            if (banner is null)
            {
                return BaseResult<object>.Fail("Banner Not Found");
            }
            _bannerRepository.Delete(banner);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Delete Failed");
        }

        public async Task<BaseResult<List<ResultBannerDto>>> GetAllAsync()
        {
            var banners = await _bannerRepository.GetAllAsync();
            var result = banners.Adapt<List<ResultBannerDto>>();
            return BaseResult<List<ResultBannerDto>>.Success(result);
        }

        public async Task<BaseResult<ResultBannerDto>> GetByIdAsync(int id)
        {
            var banner = await _bannerRepository.GetByIdAsync(id);
            if (banner is null)
            {
                return BaseResult<ResultBannerDto>.Fail("Banner Not Found");
            }
            var result = banner.Adapt<ResultBannerDto>();
            return BaseResult<ResultBannerDto>.Success(result);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateBannerDto dto)
        {
            var banner = dto.Adapt<Banner>();
            var validation = await _validator.ValidateAsync(banner);
            if (!validation.IsValid)
            {
                return BaseResult<object>.Fail(validation.Errors);
            }
            _bannerRepository.Update(banner);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Update Failed");
        }
    }
}
