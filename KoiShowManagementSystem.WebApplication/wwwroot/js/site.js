document.addEventListener('DOMContentLoaded', function () {
    // Kiểm tra và thay đổi màu nền menu dựa trên trang hiện tại
    var currentPage = window.location.pathname;
    var menu = document.querySelector('.menu');

    // Thay đổi màu nền menu nếu không phải là trang chủ hoặc danh sách cuộc thi
    if (currentPage !== "/Home/Index" && currentPage !== "/Home/CompetitionList") {
        menu.style.backgroundColor = '#2980b9'; // Màu nền mới
    }

    // Tự động thu nhỏ menu khi cuộn trang xuống
    window.addEventListener("scroll", function () {
        var menu = document.querySelector('.menu');
        var header = document.querySelector('header');

        if (window.scrollY > 50) {
            menu.classList.add('shrink');
            header.style.padding = '10px 0'; // Giảm padding của header khi cuộn
        } else {
            menu.classList.remove('shrink');
            header.style.padding = '25px 0'; // Trả về padding ban đầu khi không cuộn
        }
    });

    // Các hiệu ứng hover cho menu và dropdown
    var menuItems = document.querySelectorAll('.menu li a');
    menuItems.forEach(function (item) {
        item.addEventListener('mouseenter', function () {
            item.style.transform = 'scale(1.1)';
            item.style.transition = 'transform 0.3s ease';
        });

        item.addEventListener('mouseleave', function () {
            item.style.transform = 'scale(1)';
        });
    });

    var accountDropdown = document.querySelector('.account');
    if (accountDropdown) {
        accountDropdown.addEventListener('mouseenter', function () {
            var dropdownContent = accountDropdown.querySelector('.dropdown-content');
            dropdownContent.style.display = 'block';
            dropdownContent.style.opacity = '1';
            dropdownContent.style.transition = 'opacity 0.3s ease';
        });

        accountDropdown.addEventListener('mouseleave', function () {
            var dropdownContent = accountDropdown.querySelector('.dropdown-content');
            dropdownContent.style.display = 'none';
            dropdownContent.style.opacity = '0';
        });
    }
});
