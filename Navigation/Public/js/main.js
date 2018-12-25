$(document).ready(function() {


    $.validate({

        modules: 'location, date, security, file'
       

    });


    $("#registerForm").submit(function(ev) {
        ev.preventDefault();

        $.ajax({
            url: $(this).attr("action"),
            type: $(this).attr("method"),
            dataType: "json",
            data: $(this).serialize(),
            success: function(responce) {
                console.log(responce);
            }

    });
    });




    //mail yoxlama varsa register tekrar olmalidi
    $(window).on("load", function () {
     
        if (location.hash == '#registered') {
           
            $("#login").attr("area-selected", "false");
            $('#login').removeClass("active");
            $('#sign-up').addClass("active");
            $('#sign-up').addClass("show");
            $('#pills-home').removeClass("active");
            $('#pills-home').removeClass("show");
            $('#pills-profile').addClass("active");
            $('#pills-profile').addClass("show");
            $('#pills-home').remove("class", "show");
            $("#sign-up").attr("aria-selected", "true");
                $('#ModalLogReg').modal('show');
                

        } else {
            $("#sign-up").attr("aria-selected", "false");
            $('#sing-up').removeClass("active");
            $('#sing-up').removeClass("show");
            $('#pills-profile').removeClass("active");
            $('#pills-profile').removeClass("show");
        }



        });


});


