namespace KoiShowManagementSystem.Services.Services
{
    // Interface định nghĩa các phương thức dịch vụ liên quan đến cá Koi
    public interface IKoiService
    {
        List<Koi> GetAllKoi(); // Lấy tất cả các cá Koi
        Koi GetKoiById(int koiId); // Lấy cá Koi theo ID
        void CreateKoi(Koi koi); // Tạo mới cá Koi
        void UpdateKoi(Koi koi); // Cập nhật thông tin cá Koi
        void DeleteKoi(int koiId); // Xóa cá Koi
        List<Koi> GetKoiByUserId(int userId); // Lấy cá Koi của người dùng theo UserId
    }

    // Lớp thực thi các phương thức trong interface
    public class KoiService : IKoiService
    {
        private readonly IKoiRepository _koiRepository; // Repository để tương tác với cơ sở dữ liệu cá Koi

        // Constructor nhận vào repository để khởi tạo dịch vụ
        public KoiService(IKoiRepository koiRepository)
        {
            _koiRepository = koiRepository;
        }

        // Phương thức lấy tất cả các cá Koi
        public List<Koi> GetAllKoi()
        {
            return _koiRepository.GetAllKoi(); // Gọi phương thức của repository để lấy tất cả cá Koi
        }

        // Phương thức lấy cá Koi theo ID
        public Koi GetKoiById(int koiId)
        {
            return _koiRepository.GetKoiById(koiId); // Gọi phương thức của repository để lấy cá Koi theo ID
        }

        // Phương thức lấy cá Koi của người dùng theo UserId
        public List<Koi> GetKoiByUserId(int userId)
        {
            return _koiRepository.GetKoiByUserId(userId); // Gọi phương thức của repository để lấy cá Koi theo UserId
        }

        // Phương thức tạo mới cá Koi
        public void CreateKoi(Koi koi)
        {
            _koiRepository.Add(koi); // Gọi phương thức Add của repository để thêm cá Koi mới vào cơ sở dữ liệu
        }

        // Phương thức cập nhật thông tin cá Koi
        public void UpdateKoi(Koi koi)
        {
            _koiRepository.Update(koi); // Gọi phương thức Update của repository để cập nhật cá Koi
        }

        // Phương thức xóa cá Koi theo ID
        public void DeleteKoi(int koiId)
        {
            var koiToDelete = _koiRepository.GetKoiById(koiId); // Tìm cá Koi theo ID
            if (koiToDelete != null)
            {
                _koiRepository.Delete(koiToDelete); // Gọi phương thức Delete để xóa cá Koi khỏi cơ sở dữ liệu
            }
        }
    }
}
