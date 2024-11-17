using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KoiShowManagementSystem.Repositories.Data
{
    // Lớp cơ sở trừu tượng cho các repository, cung cấp các phương thức CRUD cơ bản và hỗ trợ truy vấn dữ liệu.
    public abstract class RepositoryBase<T> where T : class
    {
        protected ApplicationDbContext _dbContext; // Context của Entity Framework.
        protected readonly DbSet<T> dbset; // Tập hợp thực thể (DbSet) của kiểu T.

        // Khởi tạo repository với ApplicationDbContext.
        protected RepositoryBase(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            dbset = _dbContext.Set<T>();
        }

        // Thêm một thực thể vào cơ sở dữ liệu.
        public virtual void Add(T entity)
        {
            dbset.Add(entity);
            _dbContext.SaveChanges();
        }

        // Cập nhật thông tin của một thực thể.
        public virtual void Update(T entity)
        {
            dbset.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges(true); // Lưu thay đổi với kiểm tra đồng bộ.
        }

        // Xóa một thực thể khỏi cơ sở dữ liệu.
        public virtual void Delete(T entity)
        {
            dbset.Remove(entity);
            _dbContext.SaveChanges();
        }

        // Xóa các thực thể dựa trên điều kiện lọc.
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbset.Remove(obj);
        }

        // Đếm số lượng thực thể thỏa mãn điều kiện.
        public virtual int Count(Expression<Func<T, bool>> where)
        {
            return dbset.Count<T>(where);
        }

        // Lấy danh sách các thực thể với các tùy chọn bộ lọc, sắp xếp, và phân trang.
        public virtual IEnumerable<T> GetList(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "", // Các thuộc tính cần tải kèm.
            int skip = 0, // Số lượng bản ghi bỏ qua (phân trang).
            int take = 0) // Số lượng bản ghi cần lấy (phân trang).
        {
            IQueryable<T> query = dbset;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty); // Tải các thuộc tính liên quan.
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip > 0)
            {
                query = query.Skip(skip);
            }

            if (take > 0)
            {
                query = query.Take(take);
            }

            return query.ToList();
        }

        // Lấy một thực thể dựa trên Id.
        public virtual T GetById(object id)
        {
            return dbset.Find(id);
        }

        // Lấy tất cả các thực thể trong DbSet.
        public virtual IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        // Lấy nhiều thực thể dựa trên điều kiện.
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).ToList();
        }

        // Lấy một thực thể đầu tiên thỏa mãn điều kiện.
        public T Get(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).FirstOrDefault<T>();
        }

        // Kiểm tra xem có thực thể nào thỏa mãn điều kiện không.
        public virtual bool Any(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).Any<T>();
        }        
    }
}
