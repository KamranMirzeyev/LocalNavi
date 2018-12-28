$(document).ready(function() {


    $.validate({

        modules: 'location, date, security, file'
       

    });


    //$("#registerForm").submit(function(ev) {
    //    ev.preventDefault();

    //    $.ajax({
    //        url: $(this).attr("action"),
    //        type: $(this).attr("method"),
    //        dataType: "json",
    //        data: $(this).serialize(),
    //        success: function(responce) {
    //            console.log(responce);
    //        }

    //});
    //});


    //login omayibsa add Listing gire bilmesin
    $("#AddList").click(function() {

        $.ajax({
            url: "/Account/AccessLogin",
            type: "get",
            dataType: "json",
            success: function (responce) {
                if (responce.status === 404) {
                    $('#ModalLogReg').modal('show');
                }
                if (responce.status===200) {
                   window.location = responce.url;
                }
               
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





    //map
    var User = {
        lat: 40.4287711,
        lng: 49.2481203
    }
    function getLocation() {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(showPosition);
        } else {
            console.log("Geolocation is not supported by this browser.");
        }
    }

    function showPosition(position) {
        map.setCenter({ lat: position.coords.latitude, lng: position.coords.longitude });
    }

    getLocation();

    var markerAdd = false;

    map = new GMaps({
        div: '#map',
        zoom: 14,
        lat: User.lat,
        lng: User.lng,
        click: function (e) {
            if (!markerAdd) {
                UpdateLocation(e.latLng.lat(), e.latLng.lng());
                map.addMarker({
                    lat: e.latLng.lat(),
                    lng: e.latLng.lng(),
                    title: 'Lima',
                    draggable: true,
                    dragend: function (e) {
                        UpdateLocation(e.latLng.lat(), e.latLng.lng());
                    }
                });
                markerAdd = true;
            }
        }
    });

    function UpdateLocation(lat, lng) {
        $("input[name='lat']").val(lat);
        $("input[name='lng']").val(lng);
    }


    //map end



    //categoriye gore servicelerin gelmesi
    $("#CategoryId").change(function() {
        var id = $(this).val();

        $("#servis").text('');

        $.ajax({
            url: "/Place/CategoryService",
            type: "get",
            data: {id:id},
            dataType: "json",
            success: function (responce) {
                
                $.each(responce,function(index,item) {
                    $("#servis").append(` <div class="col-md-4 responsive-wrap">
                                            <div class="md-checkbox">
                                                <input id="i${item.ServiceId}" name="${item.ServiceId}" type="checkbox">
                                                <label for="i${item.ServiceId}">${item.Name}</label>
                                            </div>
                                        </div>`
                    );
                });


            },
            error: function (response) {
                    console.log(response);
                }

        });



   
    });




    //Categoriyaya gore place servislerin add olunmasi
    $(document).on("click", "#servis input",function (ev) {
            ev.preventDefault();
            console.log($(this).attr("name"));

    });


    //Hefte gunlerinin yoxlanilmasi ve add olunmasi
    function weekDays() {
        $('input[name="sunday"]').click(function() {
            if ($(this).prop("checked") == true) {
                console.log($('input[name="bazar"]').find('option:selected').text());
            }
        });


        $("select[name='bazar']").change(function() {
            var week = {
                time: $(this).find('option:selected').text()
        }
            console.log(week);
        });
        
    }

    weekDays();

});


