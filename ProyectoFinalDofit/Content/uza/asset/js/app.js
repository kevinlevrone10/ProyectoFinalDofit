const iconMenu = document.querySelector('.header__icon-menu');
const menu = document.querySelector('.header__nav');

iconMenu.addEventListener('click', () => menu.classList.toggle('toggle'));