namespace KoiShowManagementSystem.Repositories.Repositories
{
    // Interface định nghĩa các phương thức cho repository quản lý cá Koi.
    public interface IKoiRepository : IRepository<Koi>
    {
        // Phương thức lấy tất cả cá Koi.
        List<Koi> GetAllKoi();

        // Phương thức lấy cá Koi theo ID.
        Koi GetKoiById(int koiId);

        // Phương thức lấy danh sách cá Koi của người dùng theo UserId.
        List<Koi> GetKoiByUserId(int userId);

        // Phương thức xóa cá Koi.
        void Delete(Koi koi); // Thêm phương thức Delete vào interface
    }

    // Repository triển khai các phương thức đã định nghĩa trong IKoiRepository.
    public class KoiRepository : RepositoryBase<Koi>, IKoiRepository
    {
        // Constructor nhận vào ApplicationDbContext để thao tác với cơ sở dữ liệu.
        public KoiRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        // Phương thức trả về danh sách tất cả cá Koi.
        public List<Koi> GetAllKoi()
        {
            // Truy vấn và trả về tất cả các cá Koi trong bảng `Kois`.
            return _dbContext.Kois.ToList();
        }

        // Phương thức trả về cá Koi theo ID.
        public Koi GetKoiById(int koiId)
        {
            // Tìm kiếm cá Koi theo `koiId`.
            return _dbContext.Kois.Find(koiId);
        }

        // Phương thức trả về danh sách cá Koi của người dùng theo `UserId`.
        public List<Koi> GetKoiByUserId(int userId)
        {
            // Truy vấn các cá Koi thuộc về người dùng có `UsersId` khớp với `userId`.
            return _dbContext.Kois.Where(k => k.UsersId == userId).ToList();
        }

        // Phương thức xóa cá Koi.
        public void Delete(Koi koi)
        {
            // Xóa cá Koi khỏi DbContext.
            _dbContext.Kois.Remove(koi);
            // Lưu thay đổi vào cơ sở dữ liệu.
            _dbContext.SaveChanges();
        }
    }
}
