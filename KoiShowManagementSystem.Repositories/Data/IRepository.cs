using System.Linq.Expressions;

namespace KoiShowManagementSystem.Repositories.Data
{
    // Interface IRepository với các phương thức cơ bản để thao tác với dữ liệu trong một repository.
    public interface IRepository<T> where T : class
    {
        // Thêm một thực thể vào repository.
        void Add(T entity);

        // Cập nhật thông tin của một thực thể.
        void Update(T entity);

        // Xóa một thực thể khỏi repository.
        void Delete(T entity);

        // Xóa các thực thể dựa trên một điều kiện.
        void Delete(Expression<Func<T, bool>> where);

        // Đếm số lượng thực thể thỏa mãn điều kiện.
        int Count(Expression<Func<T, bool>> where);

        // Lấy danh sách các thực thể với các tùy chọn bộ lọc, sắp xếp, và phân trang.
        IEnumerable<T> GetList(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "", // Các thuộc tính liên quan cần được tải cùng.
            int skip = 0, // Số lượng bản ghi bỏ qua (phân trang).
            int take = 0); // Số lượng bản ghi cần lấy (phân trang).

        // Lấy một thực thể theo Id.
        T GetById(object Id);

        // Lấy một thực thể dựa trên điều kiện.
        T Get(Expression<Func<T, bool>> where);

        // Lấy tất cả các thực thể trong repository.
        IEnumerable<T> GetAll();

        // Lấy nhiều thực thể dựa trên điều kiện.
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);

        // Kiểm tra xem có thực thể nào thỏa mãn điều kiện hay không.
        bool Any(Expression<Func<T, bool>> where);
    }
}
