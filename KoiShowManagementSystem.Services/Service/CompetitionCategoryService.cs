using KoiShowManagementSystem.Repositories.Entities;
using KoiShowManagementSystem.Repositories.Interface;
using KoiShowManagementSystem.Services.CompetitionService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiShowManagementSystem.Services.Service
{
    public class CompetitionCategoryService : ICompetitionCategoryService
    {
        private readonly ICompetitionCategoryRepository _repository;

        public CompetitionCategoryService(ICompetitionCategoryRepository repository)
        {
            _repository = repository;
        }

        // Thêm danh mục thi đấu mới
        public async Task<bool> AddCompetitionCategoryAsync(CompetitionCategory category)
        {
            ValidateCompetitionCategory(category);
            return await _repository.AddCompetitionCategoryAsync(category);
        }

        // Tạo danh mục thi đấu mới (phương thức missing trong lỗi)
        public async Task<bool> CreateCompetitionCategoryAsync(CompetitionCategory category)
        {
            ValidateCompetitionCategory(category);
            return await _repository.AddCompetitionCategoryAsync(category);  // Tái sử dụng phương thức Add nếu cần
        }

        // Xóa danh mục thi đấu theo ID
        public async Task<bool> DeleteCompetitionCategoryAsync(int Id)
        {
            if (Id <= 0)
                throw new ArgumentException("ID không hợp lệ chỉ chấp nhận số nguyên dương", nameof(Id));

            return await _repository.DeleteCompetitionCategoryAsync(Id);
        }

        // Xóa danh mục thi đấu theo đối tượng
        public async Task<bool> DeleteCompetitionCategoryAsync(CompetitionCategory category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category), "Danh mục thi đấu không được để trống");

            return await _repository.DeleteCompetitionCategoryAsync(category);
        }

        // Lấy tất cả danh mục thi đấu
        public async Task<List<CompetitionCategory>> GetAllCompetitionCategoriesAsync()
        {
            return await _repository.GetAllCompetitionCategoriesAsync();
        }

        // Lấy danh mục thi đấu theo ID
        public async Task<CompetitionCategory> GetCompetitionCategoryByIdAsync(int Id)
        {
            if (Id <= 0)
                throw new ArgumentException("ID không hợp lệ chỉ chấp nhận số nguyên dương", nameof(Id));

            return await _repository.GetCompetitionCategoryByIdAsync(Id);
        }

        // Cập nhật danh mục thi đấu
        public async Task<bool> UpdateCompetitionCategoryAsync(CompetitionCategory category)
        {
            ValidateCompetitionCategory(category);
            return await _repository.UpdateCompetitionCategoryAsync(category);
        }

        // Kiểm tra tính hợp lệ của danh mục thi đấu
        private void ValidateCompetitionCategory(CompetitionCategory category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category), "Danh mục thi đấu không được để trống.");

            if (category.CategoryId <= 0)
                throw new ArgumentException("Mã danh mục thi đấu phải là số nguyên dương.", nameof(category.CategoryId));

            if (string.IsNullOrWhiteSpace(category.Name))
                throw new ArgumentException("Tên danh mục thi đấu không được để trống.", nameof(category.Name));

            if (category.Name.Length > 100)
                throw new ArgumentException("Tên danh mục thi đấu không được dài quá 100 ký tự.", nameof(category.Name));

            // Kiểm tra tính hợp lệ của mô tả nếu cần
            if (category.Description?.Length > 500)
                throw new ArgumentException("Mô tả không được dài quá 500 ký tự.", nameof(category.Description));
        }
    }
}
