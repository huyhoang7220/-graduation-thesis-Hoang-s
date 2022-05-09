// back to top
window.addEventListener("scroll", (event) => {
    let scrollY = this.scrollY;
    if (scrollY >= 200) {
        document.getElementById('backtotop').style.visibility = 'unset';
    }

    if (scrollY < 200) {
        document.getElementById('backtotop').style.visibility = 'hidden';
    }
});

function backToTop() {
    var top = document.querySelector('.header');
    top.scrollIntoView();
}

// check placeholder search bar is typing
var isInputPlaceholderTyping = false;

// open search bar 
function openSearchBar() {
    var searchBar = document.querySelector('.search-bar');
    var mask      = document.querySelector('.mask');
    mask.classList.add('mask-active');
    searchBar.classList.add('search-bar-show');
    mask.addEventListener('click', function () {
        closeSearchBar();
    })
    if (!isInputPlaceholderTyping) {
        autoTypePlaceholder();
    }
}

// close search bar
function closeSearchBar() {
    var searchBar = document.querySelector('.search-bar');
    var mask      = document.querySelector('.mask');
    mask.classList.remove('mask-active');
    searchBar.classList.remove('search-bar-show');
}

// auto type 
function autoTypePlaceholder () {
    var options = {
        strings: [
            'Bạn muốn tìm gì?', 
            'Trang sức cưới?',
            'Trang sức kim cương?',
            'Dịch vụ cưới hỏi?',
            'Quà tặng đính hôn?'],
        backSpeed: 50,
        typeSpeed: 50,
        loop: true,
        loopCount: Infinity,
        attr: 'placeholder',
    };

    var placeholderSearchBar = new Typed('.search-bar_input', options);
    isInputPlaceholderTyping = true;
}

// menu in mobile view 
function showMenuMobile() {
    var menuMobile = document.querySelector('.menu-sub-mobile');
    menuMobile.classList.toggle('menu-sub-mobile-active');
}


var subMenus           = document.querySelectorAll('.sub-menu-hide');
var buttonShowSubMenus = document.querySelectorAll('.show-sub-menu');
for (var i = 0; i < subMenus.length; i++) {
    buttonShowSubMenus[i].index = i;
    buttonShowSubMenus[i].addEventListener('click', function () {
        subMenus[this.index].classList.toggle('sub-menu-show');
    });
}