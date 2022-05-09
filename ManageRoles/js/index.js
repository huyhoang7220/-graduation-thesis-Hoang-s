var banner = new Swiper('.banner_slider', {
    spaceBetween: 30,
    effect: 'fade',
    pagination: {
        el: '.banner_slider_pagination',
        clickable: true,
    },
});

var swiperPagination = document.querySelectorAll('.swiper-pagination-bullet');
swiperPagination.forEach (x => {
    x.classList.add('customize-swiper-pagination');
})

var slideBestProduct = new Swiper('.product-best_slide', {
    slidesPerView: 2,
    spaceBetween: 10,
    slidesPerGroup: 2,
    loop: true,
    loopFillGroupWithBlank: true,
    navigation: {
        nextEl: '.product-best_slide-next',
        prevEl: '.product-best_slide-prev',
    },
    breakpoints: {
        426: {
          slidesPerView: 3,
          spaceBetween: 10,
        },

        1024: {
          slidesPerView: 4,
          spaceBetween: 10,
        },
    }
});

var slideBestProduct = new Swiper('.list-product_slide', {
    slidesPerView: 4,
    spaceBetween: 20,
    slidesPerGroup: 4,
    loop: true,
    loopFillGroupWithBlank: true,
    navigation: {
        nextEl: '.list-product_slide_next',
        prevEl: '.list-product_slide_prev',
    },
});

var slideNewspaper = new Swiper('.list-newspaper_slide', {
    slidesPerView: 3,
    spaceBetween: 20,
    slidesPerGroup: 3,
    loop: true,
    loopFillGroupWithBlank: true,
    navigation: {
        nextEl: '.list-newspaper_slide_next',
        prevEl: '.list-newspaper_slide_prev',
    },
});
