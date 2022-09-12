function changePhotoNew(id) {
    var oFReader = new FileReader();
    var file = document.getElementById(`Photo_${id}`).files[0];

    oFReader.readAsDataURL(file);
    oFReader.onloadend = function (oFRevent) {
        var src = oFRevent.target.result;
        $(`#NewPhoto${id}`).attr('src', src);
        $('#ChangePhoto').empty();
        $('#ChangePhoto').append(`預覽新照片 : `);
        /*$('#ChangeNewPhoto').empty();*/
        $('#ChangeNewPhoto').append(`<img src="${src}" id="NewPhoto${id}" class="rounded-3 shado carousel-item" data-bs-interval="1000000"/>`);

        for (var k = 1; k <= 6; k++) {
            $(`#ChangeNewPhoto img:nth-child(${k})`).removeClass().addClass("rounded-3 shado carousel-item");
        }

        $("#ChangeNewPhoto img:last-child").addClass("active");
    }
}