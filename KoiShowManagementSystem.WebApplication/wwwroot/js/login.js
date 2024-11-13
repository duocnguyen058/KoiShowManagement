// JavaScript cho trang đăng nhập và đăng ký
document.addEventListener('DOMContentLoaded', function () {
    // Xử lý đăng nhập
    const loginForm = document.querySelector('#loginForm');
    if (loginForm) {
        loginForm.addEventListener('submit', function (e) {
            e.preventDefault();
            // Logic đăng nhập
            const username = document.querySelector('#username').value;
            const password = document.querySelector('#password').value;

            if (username && password) {
                alert('Đăng nhập thành công!');
                window.location.href = '/Home/Index'; // Chuyển hướng sau khi đăng nhập thành công
            } else {
                alert('Vui lòng nhập đầy đủ thông tin đăng nhập');
            }
        });
    }

    // Xử lý đăng ký
    const registerForm = document.querySelector('#registerForm');
    if (registerForm) {
        registerForm.addEventListener('submit', function (e) {
            e.preventDefault();
            // Logic đăng ký
            const username = document.querySelector('#registerUsername').value;
            const password = document.querySelector('#registerPassword').value;
            const confirmPassword = document.querySelector('#confirmPassword').value;

            if (password === confirmPassword) {
                alert('Đăng ký thành công!');
                window.location.href = '/Account/Login'; // Chuyển hướng về trang đăng nhập
            } else {
                alert('Mật khẩu không khớp');
            }
        });
    }
});
