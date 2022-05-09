// Demo product gallery
var demoGallery = new Swiper('.demo-gallery_slide', {
    spaceBetween: 15,
    slidesPerView: 3,
    freeMode: true,
    pagination: {
        el: '.demo-gallery_pagination',
        clickable: true,
    },
});

var demoGalleryMobile = new Swiper('.demo-gallery-mobile_slide', {
    pagination: {
        el: '.demo-gallery-mobile_pagination',
        clickable: true,
    },
});

var swiperPagination = document.querySelectorAll('.swiper-pagination-bullet');
    swiperPagination.forEach (x => {
        x.classList.add('customize-swiper-pagination');
})

// Process checkbox
var checkboxs = document.querySelectorAll('.content_main-left input[type="checkbox"]');
for (var i = 0; i < checkboxs.length; i++) {
    let fakeCheckbox = checkboxs[i].nextElementSibling;
    var type_param = getParam("typePrice");
    if (type_param == fakeCheckbox.getAttribute("data-type"))
        fakeCheckbox.classList.toggle('fake-checkbox-active');

    checkboxs[i].addEventListener('change', function () {
        let fakeCheckbox = this.nextElementSibling;
        fakeCheckbox.classList.toggle('fake-checkbox-active');

        // filter
        var type_price = fakeCheckbox.getAttribute("data-type");

        var type = getParam("type");
        var Category = getParam("Category");
        var min, max;
        switch (type_price) {
            case "1":
                min = 0;
                max = 100000;
                break;
            case "2":
                min = 100000;
                max = 200000;
                break;
            case "3":
                min = 200000;
                max = 300000;
                break;
            case "4":
                min = 300000;
                max = 500000;
                break;
            case "5":
                min = 500000;
                max = 1000000;
                break;
            case "6":
                min = 1000000;
                max = "";
                break;
        }
        var params = "";

        params += "minPrice=" + min;
        params += "&maxPrice=" + max;
        params += "&typePrice=" + type_price;
        if (type != null)
            params += "&type=" + type;

        if (Category != null)
            params += "&Category=" + Category;

        window.location.href = "/home/product?" + params;
    });
}

//data-type: 1 a-z ; 2 z-a; 3 new ; 4 price up; 5 price down 
var checkboxs = document.querySelectorAll('.content_main-right input[type="checkbox"]');
for (var i = 0; i < checkboxs.length; i++) {
    let fakeCheckbox = checkboxs[i].nextElementSibling;
    var type_param = getParam("type");
    if (type_param == fakeCheckbox.getAttribute("data-type"))
        fakeCheckbox.classList.toggle('fake-checkbox-active');

    checkboxs[i].addEventListener('change', function () {
        for (var j = 0; j < checkboxs.length; j++) {
            checkboxs[j].nextElementSibling.classList.remove('fake-checkbox-active');
        }

        let fakeCheckbox = this.nextElementSibling;
        fakeCheckbox.classList.toggle('fake-checkbox-active');

        //filter
        var type = fakeCheckbox.getAttribute("data-type");

        var Category = getParam("Category");
        var minPrice = getParam("minPrice");
        var maxPrice = getParam("maxPrice");
        var typePrice = getParam("typePrice");

        var params = "";
        params += "type=" + type;

        if (Category != null)
            params += "&Category=" + Category;

        if (minPrice != null)
            params += "&minPrice=" + minPrice;

        if (maxPrice != null)
            params += "&maxPrice=" + maxPrice;

        if (typePrice != null)
            params += "&typePrice=" + typePrice;

        window.location.href = "/home/product?" + params;
    });
}

// Sub menu 
var buttonToOpenDropMenus = document.querySelectorAll('span.show-drop-menu');
var dropMenus             = document.querySelectorAll('ul.drop-menu')
for (var i=0; i<buttonToOpenDropMenus.length; i++) {
    buttonToOpenDropMenus[i].index = i;
    buttonToOpenDropMenus[i].addEventListener('click', function () {
        this.classList.toggle('show-drop-menu-active');
        dropMenus[this.index].classList.toggle('drop-menu-active');
    });
}

// Filter box in mobile view
var boxFilter = document.querySelector('.filter-mobile');

boxFilter.addEventListener('click', function () {
    this.classList.toggle('filter-mobile-active');
})

function getParam(param) {
    return new URLSearchParams(window.location.search).get(param);
}