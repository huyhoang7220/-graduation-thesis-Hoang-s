var address = document.querySelectorAll('.address_item');
var maps    = document.querySelectorAll('.map_item');
for (var i=0; i<address.length; i++) {
    address[i].index = i;
    address[i].addEventListener('click', function () {
        this.classList.add('address_item-active');
        maps[this.index].classList.add('map_item-active');
        for (var j=0; j < address.length; j++) {
            if (j != this.index) {
                address[j].classList.remove('address_item-active');
                maps[j].classList.remove('map_item-active');
            }
        }
    });
}