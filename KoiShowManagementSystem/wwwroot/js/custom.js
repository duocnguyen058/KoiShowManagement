/* General Styles */
body {
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    background-image: linear-gradient(rgba(0, 0, 0, 0.5), rgba(0, 0, 0, 0.5)), url('../images/koi-background.jpg');
    background-size: cover;
    background-position: center;
    background-attachment: fixed;
    color: #fff;
    margin: 0;
    padding: 0;
    display: flex;
    flex-direction: column;
    min-height: 100vh;
}

/* Navbar Styles */
.navbar {
    background: linear-gradient(45deg, #3498db, #1abc9c);
    box-shadow: 0 4px 10px rgba(0, 0, 0, 0.15);
    transition: background 0.3s;
}

    .navbar:hover {
        background: linear-gradient(45deg, #1abc9c, #3498db);
    }

.navbar-brand, .nav-link {
    color: #fff !important;
    font-weight: 500;
    transition: color 0.3s;
}

    .navbar-brand:hover, .nav-link:hover {
        color: #ecf0f1 !important;
    }

.navbar-toggler-icon {
    filter: invert(1);
}

/* Logo Styles */
.logo-img {
    width: 40px;
    height: 40px;
    border-radius: 50%;
    object-fit: cover;
    border: 2px solid #fff;
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.2);
    margin-right: 10px;
}

/* Content Styles */
.content {
    flex-grow: 1;
    padding: 20px;
    background: rgba(255, 255, 255, 0.9);
    color: #333;
    border-radius: 8px;
    box-shadow: 0 8px 15px rgba(0, 0, 0, 0.2);
    margin-top: 20px;
}

/* Footer Styles */
footer {
    background: linear-gradient(45deg, #2c3e50, #34495e);
    color: #ecf0f1;
    padding: 20px 0;
    text-align: center;
    font-size: 0.9rem;
    margin-top: auto;
    box-shadow: 0 -4px 10px rgba(0, 0, 0, 0.15);
}

    footer a {
        color: #1abc9c;
        text-decoration: none;
        transition: color 0.3s;
    }

        footer a:hover {
            color: #3498db;
            text-decoration: underline;
        }

/* Button Styles */
.btn-custom {
    background: #1abc9c;
    color: #fff;
    border: none;
    transition: background 0.3s, transform 0.3s;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.15);
}

    .btn-custom:hover {
        background: #16a085;
        transform: translateY(-2px);
        box-shadow: 0 6px 12px rgba(0, 0, 0, 0.2);
    }

/* Utility Classes */
.text-shadow {
    text-shadow: 1px 1px 3px rgba(0, 0, 0, 0.3);
}

.shadow-lg {
    box-shadow: 0 10px 20px rgba(0, 0, 0, 0.25) !important;
}

/* Responsive */
@media (max-width: 768px) {
    .content {
        padding: 10px;
    }

    .navbar-nav {
        text-align: center;
    }
}
﻿
