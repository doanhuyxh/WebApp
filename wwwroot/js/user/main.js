
$(document).ready(function () {
    //các config hệ thống
    fetch("/Home/ConFig")
        .then(res => res.json())
        .then(data => {
            document.title = data.object.titleWeb;
            $("#Logo_src").attr("src", data.object.loGo);
            $("#Logo_footer").attr("src", data.object.loGo);

            $('#tel_href').attr('href', `tel:${data.object.phoneNumber}`);
            $('#tel_number').html('<strong>' + data.object.phoneNumber + '</strong>');
            $('#PhoneFooter').attr('href', `tel:${data.object.phoneNumber}`);
            $('#PhoneFooter').html(data.object.phoneNumber);

            $('#Fb_href').attr('href', `${data.object.linkChatFaceBook}`).attr('target', '_blank');
            $('#address_footer').html(data.object.address);


        })
    //các code khác viết ở dưới
});