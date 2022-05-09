var contactIcons = document.querySelectorAll('.contact_icon');
    var contactInfos = document.querySelectorAll('.contact_info');
    for (var i=0; i<contactIcons.length; i++) {
        contactIcons[i].addEventListener('mouseover', function () {
            this.classList.add('contact_icon-hover');
        })
        contactIcons[i].addEventListener('mouseleave', function () {
            this.classList.remove('contact_icon-hover');
        })

        contactInfos[i].index = i;
        contactInfos[i].addEventListener('mouseover', function () {
            contactIcons[this.index].classList.add('contact_icon-hover');
            this.classList.add('contact_info-hover');
        })
        contactInfos[i].addEventListener('mouseleave', function () {
            contactIcons[this.index].classList.remove('contact_icon-hover');
            this.classList.remove('contact_info-hover');
        })
    }
