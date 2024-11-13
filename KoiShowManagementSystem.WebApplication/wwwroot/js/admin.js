// JavaScript cho Admin
document.addEventListener('DOMContentLoaded', function () {
    // Xử lý khi nhấn vào nút "Quản lý cá Koi"
    const manageKoiButton = document.querySelector('.manage-koi-btn');
    if (manageKoiButton) {
        manageKoiButton.addEventListener('click', function () {
            alert('Đang quản lý cá Koi');
        });
    }

    // Xử lý chấm điểm cá Koi trong phần "Referee"
    const scoreKoiButton = document.querySelector('.score-koi-btn');
    if (scoreKoiButton) {
        scoreKoiButton.addEventListener('click', function () {
            alert('Chấm điểm cá Koi');
        });
    }

    // Cập nhật kết quả cuộc thi
    const updateResultButton = document.querySelector('.update-result-btn');
    if (updateResultButton) {
        updateResultButton.addEventListener('click', function () {
            alert('Cập nhật kết quả cuộc thi');
        });
    }

    // Xử lý khi nhấn vào "Quản lý người dùng"
    const manageUsersButton = document.querySelector('.manage-users-btn');
    if (manageUsersButton) {
        manageUsersButton.addEventListener('click', function () {
            alert('Quản lý người dùng');
        });
    }
});
