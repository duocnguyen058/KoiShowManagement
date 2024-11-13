// JavaScript cho Member
document.addEventListener('DOMContentLoaded', function () {
    // Xử lý đăng ký cá Koi
    const registerKoiButton = document.querySelector('.register-koi-btn');
    if (registerKoiButton) {
        registerKoiButton.addEventListener('click', function () {
            alert('Đăng ký cá Koi thành công!');
        });
    }

    // Lịch sử cuộc thi
    const competitionHistoryButton = document.querySelector('.competition-history-btn');
    if (competitionHistoryButton) {
        competitionHistoryButton.addEventListener('click', function () {
            alert('Hiển thị lịch sử cuộc thi');
        });
    }

    // Cập nhật thông tin cá nhân
    const updateProfileButton = document.querySelector('.update-profile-btn');
    if (updateProfileButton) {
        updateProfileButton.addEventListener('click', function () {
            alert('Cập nhật thông tin cá nhân');
        });
    }

    // Đăng xuất
    const logoutButton = document.querySelector('.logout-btn');
    if (logoutButton) {
        logoutButton.addEventListener('click', function () {
            alert('Đăng xuất thành công!');
            // Thực hiện logic đăng xuất (ví dụ: xóa session, cookie, v.v.)
            window.location.href = '/Account/Login'; // Chuyển hướng về trang đăng nhập
        });
    }
});
