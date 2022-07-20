export function toggleNavbarBurger() {
    var burger = document.querySelector('.navbar-burger');
    var menu = document.querySelector('#' + burger.dataset.target);
    burger.classList.toggle('is-active');
    menu.classList.toggle('is-active');
}
