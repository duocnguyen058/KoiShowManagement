using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Repositories.Interface;
using KoiShowManagement.Services.Interface;

namespace KoiShowManagement.Services.Service
{
    public class ScoreKoiService : IScoreKoiService
    {
        private readonly IScoreKoiRepository _repository;

        public ScoreKoiService(IScoreKoiRepository repository)
        {
            _repository = repository;
        }

        // Them mot ket qua cham diem cho Koi
        public async Task<bool> AddScoreKoiAsync(ScoreKoi scoreKoi)
        {
            ValidateScoreKoi(scoreKoi);
            return await _repository.AddScoreKoiAsync(scoreKoi);
        }

        // Xoa ket qua cham diem theo ScoreId
        public async Task<bool> DelScoreKoiAsync(int scoreId)
        {
            if (scoreId <= 0)
                throw new ArgumentException("ID khong hop le, chi chap nhan so nguyen duong", nameof(scoreId));

            return await _repository.DelScoreKoiAsync(scoreId);
        }

        // Xoa ket qua cham diem theo doi tuong ScoreKoi
        public async Task<bool> DelScoreKoiAsync(ScoreKoi scoreKoi)
        {
            if (scoreKoi == null)
                throw new ArgumentNullException(nameof(scoreKoi), "Ket qua cham diem khong duoc de trong");

            return await _repository.DelScoreKoiAsync(scoreKoi);
        }

        // Lay tat ca ket qua cham diem
        public async Task<List<ScoreKoi>> GetAllScoreKoisAsync()
        {
            return await _repository.GetAllScoreKoisAsync();
        }

        // Lay ket qua cham diem theo ScoreId
        public async Task<ScoreKoi> GetScoreKoiByIdAsync(int scoreId)
        {
            if (scoreId <= 0)
                throw new ArgumentException("ID khong hop le, chi chap nhan so nguyen duong", nameof(scoreId));

            return await _repository.GetScoreKoiByIdAsync(scoreId);
        }

        // Cap nhat ket qua cham diem
        public async Task<bool> UpdScoreKoiAsync(ScoreKoi scoreKoi)
        {
            ValidateScoreKoi(scoreKoi);
            return await _repository.UpdScoreKoiAsync(scoreKoi);
        }

        // Ham xac thuc cac thong tin can thiet truoc khi thuc hien thao tac
        private void ValidateScoreKoi(ScoreKoi scoreKoi)
        {
            if (scoreKoi == null)
                throw new ArgumentNullException(nameof(scoreKoi), "Ket qua cham diem khong duoc de trong");

            if (scoreKoi.ScoreId <= 0)
                throw new ArgumentException("Ma ket qua cham diem phai la so nguyen duong.", nameof(scoreKoi.ScoreId));

            if (scoreKoi.KoiId.HasValue && scoreKoi.KoiId <= 0)
                throw new ArgumentException("Ma Koi phai la so nguyen duong.", nameof(scoreKoi.KoiId));

            if (scoreKoi.RefereeId.HasValue && scoreKoi.RefereeId <= 0)
                throw new ArgumentException("Ma trong tai phai la so nguyen duong.", nameof(scoreKoi.RefereeId));

            if (scoreKoi.EventId.HasValue && scoreKoi.EventId <= 0)
                throw new ArgumentException("Ma su kien phai la so nguyen duong.", nameof(scoreKoi.EventId));

            if (scoreKoi.Score.HasValue && (scoreKoi.Score < 0 || scoreKoi.Score > 10))
                throw new ArgumentException("Diem phai nam trong khoang tu 0 den 10.", nameof(scoreKoi.Score));

            if (string.IsNullOrWhiteSpace(scoreKoi.Feedback))
                throw new ArgumentException("Ghi nhan xet khong duoc de trong hoac chi chua khoang trong.", nameof(scoreKoi.Feedback));

            if (scoreKoi.Event != null && scoreKoi.Event.EventId <= 0)
                throw new ArgumentException("Ma su kien cua doi tuong su kien phai la so nguyen duong.", nameof(scoreKoi.Event));

            if (scoreKoi.Koi != null && scoreKoi.Koi.KoiId <= 0)
                throw new ArgumentException("Ma Koi cua doi tuong Koi phai la so nguyen duong.", nameof(scoreKoi.Koi));

            if (scoreKoi.Referee != null && scoreKoi.Referee.RefereeId <= 0)
                throw new ArgumentException("Ma trong tai cua doi tuong trong tai phai la so nguyen duong.", nameof(scoreKoi.Referee));

            // Kiem tra ScoreDate neu can thiet
            if (scoreKoi.ScoreDate == null)
                throw new ArgumentException("Ngay cham diem khong duoc de trong.", nameof(scoreKoi.ScoreDate));

            if (string.IsNullOrWhiteSpace(scoreKoi.JudgeName))
                throw new ArgumentException("Ten trong tai khong duoc de trong.", nameof(scoreKoi.JudgeName));

            if (scoreKoi.ScoreValue <= 0)
                throw new ArgumentException("Diem cham phai la so nguyen duong.", nameof(scoreKoi.ScoreValue));

            if (scoreKoi.FishId <= 0)
                throw new ArgumentException("Ma ca phai la so nguyen duong.", nameof(scoreKoi.FishId));
        }
    }
}
