var detailLeftMobile = new Swiper('.detail_left-mobile_slider', {
    spaceBetween: 30,
    effect: 'fade',
    pagination: {
        el: '.detail_left-mobile_pagination',
        clickable: true,
    },
});

var swiperPagination = document.querySelectorAll('.detail_left-mobile_slider .swiper-pagination-bullet');
swiperPagination.forEach (x => {
    x.classList.add('customize-swiper-pagination');
})




var thumbnails  = document.querySelectorAll('.detail_thumbnail img');
    var productPics = document.querySelectorAll('.detail_img img'); 
    var currentThumbnail = 0;
    for (var i=0; i<thumbnails.length; i++) {
        thumbnails[i].index = i;
        thumbnails[i].addEventListener('click', function () {
            currentThumbnail = this.index;
            changeThumbnail(currentThumbnail);
        })
    }

    function changeThumbnail(currentThumbnail) {
        thumbnails[currentThumbnail].classList.add('thumbnail-active');
        productPics[currentThumbnail].scrollIntoView({block: "end"});
        for (var i=0; i<thumbnails.length; i++) {
            if (i != currentThumbnail) {
                thumbnails[i].classList.remove('thumbnail-active');
            }
        }
    }

    var slideProduct = new Swiper('.list-product_slide', {
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